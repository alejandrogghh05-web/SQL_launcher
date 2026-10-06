using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using SqlLauncher.Config;

namespace SqlLauncher.Services
{
    public class SqlAgentService
    {
        private readonly Server _server;
        private readonly Action<string> _log;

        public SqlAgentService(SqlServerConfig config, Action<string> log = null)
        {
            _log = log ?? (msg => { });

            var conn = new ServerConnection(config.Server);

            if (config.IntegratedSecurity)
            {
                conn.LoginSecure = true;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(config.UserId))
                    throw new ArgumentException(
                        "UserId es obligatorio cuando IntegratedSecurity = false.", "UserId");

                if (string.IsNullOrWhiteSpace(config.Password))
                    throw new ArgumentException(
                        "Password es obligatorio cuando IntegratedSecurity = false.", "Password");

                conn.LoginSecure = false;
                conn.Login = config.UserId;
                conn.Password = config.Password;
            }

            conn.TrustServerCertificate = config.TrustServerCertificate;

            _server = new Server(conn);

            // Verificar connexio immediatament
            Version version = _server.Information.Version;
            _log("Connectat a: " + config.Server + "  (SQL Server " + version + ")");
        }

        //Retorna la llista de noms de bases de dades del servidor
        public IList<string> GetDatabases()
        {
            var result = new List<string>();

            foreach (Database db in _server.Databases)
                result.Add(db.Name);

            return result;
        }

        // Retorna els jobs del SQL Agent nomes retorna els jobs que tenen almenys un pas sobre aquella BD.
        public IList<JobInfo> GetJobs(string databaseFilter = null)
        {
            var result = new List<JobInfo>();
            bool sinFiltro = string.IsNullOrEmpty(databaseFilter);

            _server.JobServer.Jobs.Refresh();

            foreach (Job job in _server.JobServer.Jobs)
            {
                if (sinFiltro || JobUsaBaseDeDades(job, databaseFilter))
                {
                    result.Add(new JobInfo
                    {
                        Name = job.Name,
                        Enabled = job.IsEnabled,
                        LastRunOutcome = job.LastRunOutcome.ToString(),
                        LastRunDate = job.LastRunDate
                    });
                }
            }

            return result;
        }

        private bool JobUsaBaseDeDades(Job job, string databaseFilter)
        {
            foreach (JobStep step in job.JobSteps)
            {
                if (string.IsNullOrWhiteSpace(job.Name)) continue;
                if (!string.IsNullOrEmpty(step.DatabaseName) &&
                    step.DatabaseName.Equals(databaseFilter, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        //Llanca un job de SQL Agent. Lanca excepcio si no existeix o ja esta en execucio.
        public void LaunchJob(string jobName)
        {
            _server.JobServer.Jobs.Refresh();
            Job job = _server.JobServer.Jobs[jobName];

            if (job == null)
                throw new InvalidOperationException(
                    "Job no trobat a SQL Agent: '" + jobName + "'");

            if (job.CurrentRunStatus != JobExecutionStatus.Idle)
                throw new InvalidOperationException(
                    "El job '" + jobName + "' ja esta en estat: " + job.CurrentRunStatus);

            _log("[" + DateTime.Now.ToString("HH:mm:ss") + "] Lancant: " + jobName);
            job.Start();
        }

        //Espera que el job finalitzi retorna true si ha completat amb exit, false si ha fallat o ha fet timeout.
        public bool WaitForCompletion(string jobName, int timeoutMinutes)
        {
            DateTime deadline = DateTime.Now.AddMinutes(timeoutMinutes);

            while (DateTime.Now < deadline)
            {
                Thread.Sleep(5000);

                _server.JobServer.Jobs.Refresh();
                Job job = _server.JobServer.Jobs[jobName];
                JobExecutionStatus status = job.CurrentRunStatus;

                _log("  [" + DateTime.Now.ToString("HH:mm:ss") + "] Estat: " + status);

                if (status == JobExecutionStatus.Idle)
                {
                    CompletionResult outcome = job.LastRunOutcome;
                    _log("  Resultat: " + outcome);
                    return outcome == CompletionResult.Succeeded;
                }
            }

            _log("  [TIMEOUT] S'han esgotat els " + timeoutMinutes + " min per a: " + jobName);
            return false;
        }

        //Carrega totes les dades d'un job existents per mostrar-les a FrmJobEditor.
        public JobEditorData GetJobEditorData(string jobName)
        {
            _server.JobServer.Jobs.Refresh();
            Job job = _server.JobServer.Jobs[jobName];

            if (job == null)
                throw new InvalidOperationException("Job no trobat: '" + jobName + "'");

            var data = new JobEditorData
            {
                Name = job.Name,
                Description = job.Description ?? string.Empty,
                Enabled = job.IsEnabled
            };

            // Passos
            foreach (JobStep step in job.JobSteps)
            {
                data.Steps.Add(new JobStepDto
                {
                    StepId = step.ID,
                    StepName = step.Name,
                    DatabaseName = step.DatabaseName,
                    Command = step.Command
                });
            }

            // Schedules
            foreach (JobSchedule sched in job.JobSchedules)
            {
                var dto = new JobScheduleDto
                {
                    Name = sched.Name,
                    Enabled = sched.IsEnabled
                };

                MapScheduleFromSmo(sched, dto);
                data.Schedules.Add(dto);
            }

            return data;
        }

        //Crea un nou job al SQL Agent a partir del DTO del formulari.
        public void CreateJob(JobEditorData data)
        {
            if (string.IsNullOrWhiteSpace(data.Name))
                throw new ArgumentException("El nom del job no pot estar buit.");

            _server.JobServer.Jobs.Refresh();

            if (_server.JobServer.Jobs[data.Name] != null)
                throw new InvalidOperationException(
                    "Ja existeix un job amb el nom '" + data.Name + "'.");

            var job = new Job(_server.JobServer, data.Name)
            {
                Description = data.Description ?? string.Empty,
                IsEnabled = data.Enabled
            };

            job.Create();
            _log("Job creat: " + data.Name);

            AplicarPasos(job, data.Steps);
            AplicarSchedules(job, data.Schedules);

            job.ApplyToTargetServer("(local)");
        }

        //Actualitza un job existent. Gestiona canvi de nom, passos i schedules.
        public void UpdateJob(string originalName, JobEditorData data)
        {
            _server.JobServer.Jobs.Refresh();
            Job job = _server.JobServer.Jobs[originalName];

            if (job == null)
                throw new InvalidOperationException(
                    "Job no trobat per actualitzar: '" + originalName + "'");

            // Camps basics
            job.Description = data.Description ?? string.Empty;
            job.IsEnabled = data.Enabled;
            job.Alter();

            // Renombrar si el nom ha canviat
            if (!string.Equals(originalName, data.Name, StringComparison.OrdinalIgnoreCase))
            {
                job.Rename(data.Name);
                _log("Job renombrat: " + originalName + " -> " + data.Name);
            }

            // Passos: eliminar tots i recrear en ordre
            while (job.JobSteps.Count > 0)
                job.JobSteps[0].Drop();

            AplicarPasos(job, data.Steps);

            // Schedules: eliminar tots i recrear
            while (job.JobSchedules.Count > 0)
                job.JobSchedules[0].Drop();

            AplicarSchedules(job, data.Schedules);

            _log("Job actualitzat: " + data.Name);
        }

        //  HELPERS PRIVATS
        private void AplicarPasos(Job job, List<JobStepDto> pasos)
        {
            for (int i = 0; i < pasos.Count; i++)
            {
                JobStepDto dto = pasos[i];

                var step = new JobStep(job, dto.StepName)
                {
                    SubSystem = AgentSubSystem.TransactSql,
                    DatabaseName = string.IsNullOrWhiteSpace(dto.DatabaseName)
                                       ? "master"
                                       : dto.DatabaseName,
                    Command = dto.Command,
                    ID = i + 1,
                    OnSuccessAction = i < pasos.Count - 1
                                       ? StepCompletionAction.GoToNextStep
                                       : StepCompletionAction.QuitWithSuccess,
                    OnFailAction = StepCompletionAction.QuitWithFailure
                };

                step.Create();
            }

            if (pasos.Count > 0)
            {
                job.StartStepID = 1;
                job.Alter();
            }
        }

        private void AplicarSchedules(Job job, List<JobScheduleDto> schedules)
        {
            foreach (JobScheduleDto dto in schedules)
            {
                var sched = new JobSchedule(job, dto.Name)
                {
                    IsEnabled = dto.Enabled
                };

                MapScheduleToSmo(dto, sched);
                sched.Create();
            }
        }

        //Mapeja un DTO al SMO JobSchedule abans de crear/actualitzar.
        private void MapScheduleToSmo(JobScheduleDto dto, JobSchedule sched)
        {
            switch (dto.FrequencyType)
            {
                case ScheduleFrequency.Once:
                    sched.FrequencyTypes = FrequencyTypes.OneTime;
                    sched.ActiveStartTimeOfDay = dto.StartTime;
                    break;

                case ScheduleFrequency.Daily:
                    sched.FrequencyTypes = FrequencyTypes.Daily;
                    sched.FrequencyInterval = dto.EveryDays;
                    sched.ActiveStartTimeOfDay = dto.StartTime;
                    sched.ActiveEndTimeOfDay = dto.EndTime;
                    break;

                case ScheduleFrequency.Weekly:
                    sched.FrequencyTypes = FrequencyTypes.Weekly;
                    sched.FrequencyInterval = MapWeekDaysToSmo(dto.WeekDays);
                    sched.FrequencyRecurrenceFactor = 1;
                    sched.ActiveStartTimeOfDay = dto.StartTime;
                    sched.ActiveEndTimeOfDay = dto.EndTime;
                    break;

                case ScheduleFrequency.Monthly:
                    sched.FrequencyTypes = FrequencyTypes.Monthly;
                    sched.FrequencyInterval = dto.DayOfMonth;
                    sched.FrequencyRecurrenceFactor = 1;
                    sched.ActiveStartTimeOfDay = dto.StartTime;
                    sched.ActiveEndTimeOfDay = dto.EndTime;
                    break;
            }
        }

        //Mapeja un SMO JobSchedule existent a DTO (per carregar a l'editor).
        private void MapScheduleFromSmo(JobSchedule sched, JobScheduleDto dto)
        {
            dto.StartTime = sched.ActiveStartTimeOfDay;
            dto.EndTime = sched.ActiveEndTimeOfDay;

            switch (sched.FrequencyTypes)
            {
                case FrequencyTypes.OneTime:
                    dto.FrequencyType = ScheduleFrequency.Once;
                    break;

                case FrequencyTypes.Daily:
                    dto.FrequencyType = ScheduleFrequency.Daily;
                    dto.EveryDays = sched.FrequencyInterval;
                    break;

                case FrequencyTypes.Weekly:
                    dto.FrequencyType = ScheduleFrequency.Weekly;
                    dto.WeekDays = MapWeekDaysFromSmo(sched.FrequencyInterval);
                    break;

                case FrequencyTypes.Monthly:
                    dto.FrequencyType = ScheduleFrequency.Monthly;
                    dto.DayOfMonth = sched.FrequencyInterval;
                    break;

                default:
                    dto.FrequencyType = ScheduleFrequency.Daily;
                    break;
            }
        }

        // Converteix WeekDayFlags del DTO a l'enter de bits que usa SMO.
        // SMO: 1=Dg, 2=Dl, 4=Dm, 8=Dc, 16=Dj, 32=Dv, 64=Ds
        private int MapWeekDaysToSmo(WeekDayFlags flags)
        {
            int smo = 0;
            if ((flags & WeekDayFlags.Sunday) != 0) smo |= 1;
            if ((flags & WeekDayFlags.Monday) != 0) smo |= 2;
            if ((flags & WeekDayFlags.Tuesday) != 0) smo |= 4;
            if ((flags & WeekDayFlags.Wednesday) != 0) smo |= 8;
            if ((flags & WeekDayFlags.Thursday) != 0) smo |= 16;
            if ((flags & WeekDayFlags.Friday) != 0) smo |= 32;
            if ((flags & WeekDayFlags.Saturday) != 0) smo |= 64;
            return smo;
        }

        private WeekDayFlags MapWeekDaysFromSmo(int smo)
        {
            WeekDayFlags flags = WeekDayFlags.None;
            if ((smo & 1) != 0) flags |= WeekDayFlags.Sunday;
            if ((smo & 2) != 0) flags |= WeekDayFlags.Monday;
            if ((smo & 4) != 0) flags |= WeekDayFlags.Tuesday;
            if ((smo & 8) != 0) flags |= WeekDayFlags.Wednesday;
            if ((smo & 16) != 0) flags |= WeekDayFlags.Thursday;
            if ((smo & 32) != 0) flags |= WeekDayFlags.Friday;
            if ((smo & 64) != 0) flags |= WeekDayFlags.Saturday;
            return flags;
        }
    }

    //  JobInfo: dades del job mostrades al ListBox principal
    public class JobInfo
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string LastRunOutcome { get; set; }
        public DateTime LastRunDate { get; set; }

        public override string ToString() => Name;
    }
}
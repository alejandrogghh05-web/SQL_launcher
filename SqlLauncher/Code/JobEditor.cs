using System;
using System.Collections.Generic;

namespace SqlLauncher.Services
{
    //  DTO principal que viaja entre el formulario y SqlAgentService
    public class JobEditorData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public List<JobStepDto> Steps { get; set; } = new List<JobStepDto>();
        public List<JobScheduleDto> Schedules { get; set; } = new List<JobScheduleDto>();
    }

    //  Paso T-SQL
    public class JobStepDto
    {
        public int StepId { get; set; }
        public string StepName { get; set; }
        public string DatabaseName { get; set; }
        public string Command { get; set; }

        // Mostrado en el ListBox del formulario
        public override string ToString()
        {
            return string.Format("{0}. {1}  [{2}]", StepId, StepName, DatabaseName ?? "master");
        }
    }

    //  Schedule
    public class JobScheduleDto
    {
        public string Name { get; set; }
        public bool Enabled { get; set; } = true;
        public ScheduleFrequency FrequencyType { get; set; } = ScheduleFrequency.Daily;
        public TimeSpan StartTime { get; set; } = TimeSpan.FromHours(6);
        public TimeSpan EndTime { get; set; } = TimeSpan.FromHours(22);

        // Diaria
        public int EveryDays { get; set; } = 1;

        // Mensual
        public int DayOfMonth { get; set; } = 1;

        // Semanal
        public WeekDayFlags WeekDays { get; set; } = WeekDayFlags.None;

        // Mostrado en el ListBox del formulario
        public override string ToString()
        {
            string estado = Enabled ? "" : " [Desactivat]";

            switch (FrequencyType)
            {
                case ScheduleFrequency.Once:
                    return string.Format("Una vegada  {0:hh\\:mm}{1}", StartTime, estado);

                case ScheduleFrequency.Daily:
                    return string.Format("Cada {0} dia(es)  {1:hh\\:mm} - {2:hh\\:mm}{3}", EveryDays, StartTime, EndTime, estado);

                case ScheduleFrequency.Weekly:
                    return string.Format("Setmanal [{0}]  {1:hh\\:mm} - {2:hh\\:mm}{3}", WeekDays, StartTime, EndTime, estado);

                case ScheduleFrequency.Monthly:
                    return string.Format("Mensual dia {0}  {1:hh\\:mm} - {2:hh\\:mm}{3}", DayOfMonth, StartTime, EndTime, estado);

                default:
                    return Name ?? "(sense nom)";
            }
        }
    }

    //  Enums
    public enum ScheduleFrequency
    {
        Once,
        Daily,
        Weekly,
        Monthly
    }

    [Flags]
    public enum WeekDayFlags
    {
        None = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }
}
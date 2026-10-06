using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SqlLauncher.Services;

namespace SqlLauncher
{
    public partial class FrmJobEditor : Form
    {
        private readonly SqlAgentService _service;
        private readonly Action<string> _log;
        private readonly string _jobNameOriginal; 
        private readonly string _selectedDatabase; 

        private bool _modoEdicion => _jobNameOriginal != null;

        private readonly List<JobStepDto> _pasos = new List<JobStepDto>();
        private readonly List<JobScheduleDto> _schedules = new List<JobScheduleDto>();

        public FrmJobEditor(SqlAgentService service, Action<string> log, string databaseName, string jobName = null)
        {
            _service = service ?? throw new ArgumentNullException("service");
            _log = log ?? (m => { });
            _selectedDatabase = databaseName ?? string.Empty;
            _jobNameOriginal = jobName;

            InitializeComponent();
        }

        private void FrmJobEditor_Load(object sender, EventArgs e)
        {
            if (_modoEdicion)
            {
                this.Text = "Editar Job";
                CargarDadesJob(_jobNameOriginal);
            }
            else
            {
                this.Text = "Nou Job";
                ActualitzarListaPasos();
                ActualitzarListaSchedules();
            }
        }

        //  Carga de datos del servidor
        private void CargarDadesJob(string jobName)
        {
            try
            {
                JobEditorData data = _service.GetJobEditorData(jobName);

                txtJobName.Text = data.Name;
                txtDescription.Text = data.Description;
                chkEnabled.Checked = data.Enabled;

                _pasos.Clear();
                _pasos.AddRange(data.Steps);
                ActualitzarListaPasos();

                _schedules.Clear();
                _schedules.AddRange(data.Schedules);
                ActualitzarListaSchedules();

                _log("Job carregat per editar: " + jobName);
            }
            catch (Exception ex)
            {
                _log("[ERROR] CargarDadesJob: " + ex.Message);
                MessageBox.Show("Error carregant el job:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //  PESTANYA PASOS
        private void ActualitzarListaPasos()
        {
            lstPasos.Items.Clear();
            foreach (JobStepDto s in _pasos)
                lstPasos.Items.Add(s);
            ActualitzarBotonesPasos();
        }

        private void ActualitzarBotonesPasos()
        {
            bool sel = lstPasos.SelectedIndex >= 0;
            btnEditStep.Enabled = sel;
            btnDeleteStep.Enabled = sel;
            btnStepUp.Enabled = sel && lstPasos.SelectedIndex > 0;
            btnStepDown.Enabled = sel && lstPasos.SelectedIndex < lstPasos.Items.Count - 1;
        }

        private void lstPasos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualitzarBotonesPasos();
        }

        private void btnAddStep_Click(object sender, EventArgs e)
        {
            using (FrmStepEditor dlg = new FrmStepEditor(_pasos.Count + 1, null, _selectedDatabase))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    _pasos.Add(dlg.Result);
                    RenumerarPasos();
                    ActualitzarListaPasos();
                }
            }
        }

        private void btnEditStep_Click(object sender, EventArgs e)
        {
            if (lstPasos.SelectedItem == null) return;
            int idx = lstPasos.SelectedIndex;

            using (FrmStepEditor dlg = new FrmStepEditor(idx + 1, _pasos[idx], _selectedDatabase))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    _pasos[idx] = dlg.Result;
                    RenumerarPasos();
                    ActualitzarListaPasos();
                    lstPasos.SelectedIndex = idx;
                }
            }
        }

        private void btnDeleteStep_Click(object sender, EventArgs e)
        {
            if (lstPasos.SelectedItem == null) return;
            int idx = lstPasos.SelectedIndex;

            if (MessageBox.Show("Eliminar el pas seleccionat?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _pasos.RemoveAt(idx);
                RenumerarPasos();
                ActualitzarListaPasos();
            }
        }

        private void btnStepUp_Click(object sender, EventArgs e)
        {
            int idx = lstPasos.SelectedIndex;
            if (idx <= 0) return;
            JobStepDto tmp = _pasos[idx];
            _pasos[idx] = _pasos[idx - 1];
            _pasos[idx - 1] = tmp;
            RenumerarPasos();
            ActualitzarListaPasos();
            lstPasos.SelectedIndex = idx - 1;
        }

        private void btnStepDown_Click(object sender, EventArgs e)
        {
            int idx = lstPasos.SelectedIndex;
            if (idx < 0 || idx >= _pasos.Count - 1) return;
            JobStepDto tmp = _pasos[idx];
            _pasos[idx] = _pasos[idx + 1];
            _pasos[idx + 1] = tmp;
            RenumerarPasos();
            ActualitzarListaPasos();
            lstPasos.SelectedIndex = idx + 1;
        }

        private void RenumerarPasos()
        {
            for (int i = 0; i < _pasos.Count; i++)
                _pasos[i].StepId = i + 1;
        }


        //  PESTANYA SCHEDULES
        private void ActualitzarListaSchedules()
        {
            lstSchedules.Items.Clear();
            foreach (JobScheduleDto s in _schedules)
                lstSchedules.Items.Add(s);
            ActualitzarBotonesSchedules();
        }

        private void ActualitzarBotonesSchedules()
        {
            bool sel = lstSchedules.SelectedIndex >= 0;
            btnEditSchedule.Enabled = sel;
            btnDeleteSchedule.Enabled = sel;
        }

        private void lstSchedules_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualitzarBotonesSchedules();
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            using (FrmScheduleEditor dlg = new FrmScheduleEditor(null))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    _schedules.Add(dlg.Result);
                    ActualitzarListaSchedules();
                }
            }
        }

        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItem == null) return;
            int idx = lstSchedules.SelectedIndex;

            using (FrmScheduleEditor dlg = new FrmScheduleEditor(_schedules[idx]))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    _schedules[idx] = dlg.Result;
                    ActualitzarListaSchedules();
                    lstSchedules.SelectedIndex = idx;
                }
            }
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            if (lstSchedules.SelectedItem == null) return;
            int idx = lstSchedules.SelectedIndex;

            if (MessageBox.Show("Eliminar el schedule seleccionat?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _schedules.RemoveAt(idx);
                ActualitzarListaSchedules();
            }
        }

        //  GUARDAR / CANCELAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobName.Text))
            {
                MessageBox.Show("El nom del job es obligatori.", "Validacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl.SelectedIndex = 0;
                txtJobName.Focus();
                return;
            }

            if (_pasos.Count == 0)
            {
                MessageBox.Show("El job ha de tenir almenys un pas.", "Validacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl.SelectedIndex = 1;
                return;
            }

            try
            {
                var data = new JobEditorData
                {
                    Name = txtJobName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Enabled = chkEnabled.Checked,
                    Steps = _pasos,
                    Schedules = _schedules
                };

                if (_modoEdicion)
                {
                    _service.UpdateJob(_jobNameOriginal, data);
                    _log("Job actualitzat: " + data.Name);
                }
                else
                {
                    _service.CreateJob(data);
                    _log("Job creat: " + data.Name);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                _log("[ERROR] Guardar job: " + ex.Message);
                MessageBox.Show("Error guardant el job:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
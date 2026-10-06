using SqlLauncher.Services;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SqlLauncher
{
    //Dialeg modal per crear o editar un JobSchedule.
    //Suporta: Una vegada, Diaria, Setmanal, Mensual.
    public partial class FrmScheduleEditor : Form
    {
        //  Resultat
        public JobScheduleDto Result { get; private set; }

        //  Constructor
        public FrmScheduleEditor(JobScheduleDto existing)
        {
            InitializeComponent();

            if (existing != null)
            {
                this.Text = "Editar Schedule";
                txtName.Text = existing.Name;
                chkEnabled.Checked = existing.Enabled;
                dtpStartTime.Value = DateTime.Today.Add(existing.StartTime);
                dtpEndTime.Value = DateTime.Today.Add(existing.EndTime);

                switch (existing.FrequencyType)
                {
                    case ScheduleFrequency.Once: cmbFrequency.SelectedIndex = 0; break;
                    case ScheduleFrequency.Daily: cmbFrequency.SelectedIndex = 1; break;
                    case ScheduleFrequency.Weekly: cmbFrequency.SelectedIndex = 2; break;
                    case ScheduleFrequency.Monthly: cmbFrequency.SelectedIndex = 3; break;
                    default: cmbFrequency.SelectedIndex = 1; break;
                }

                numEveryDays.Value = existing.EveryDays > 0 ? existing.EveryDays : 1;
                numDayOfMonth.Value = existing.DayOfMonth > 0 ? existing.DayOfMonth : 1;

                chkLun.Checked = (existing.WeekDays & WeekDayFlags.Monday) != 0;
                chkMar.Checked = (existing.WeekDays & WeekDayFlags.Tuesday) != 0;
                chkMie.Checked = (existing.WeekDays & WeekDayFlags.Wednesday) != 0;
                chkJue.Checked = (existing.WeekDays & WeekDayFlags.Thursday) != 0;
                chkVie.Checked = (existing.WeekDays & WeekDayFlags.Friday) != 0;
                chkSab.Checked = (existing.WeekDays & WeekDayFlags.Saturday) != 0;
                chkDom.Checked = (existing.WeekDays & WeekDayFlags.Sunday) != 0;
            }
            else
            {
                this.Text = "Nou Schedule";
                cmbFrequency.SelectedIndex = 1; // Diaria per defecte
            }
        }

        //  Canvi de frequencia: mostra/oculta panells
        private void cmbFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDaily.Visible = cmbFrequency.SelectedIndex == 1;
            panelWeekly.Visible = cmbFrequency.SelectedIndex == 2;
            panelMonthly.Visible = cmbFrequency.SelectedIndex == 3;
        }

        //  Acceptar
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("El nom del schedule es obligatori.", "Validacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            if (dtpEndTime.Value.TimeOfDay <= dtpStartTime.Value.TimeOfDay && cmbFrequency.SelectedIndex != 0)
            {
                MessageBox.Show("L'hora de fi ha de ser posterior a l'hora d'inici.", "Validacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndTime.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            ScheduleFrequency freq;
            switch (cmbFrequency.SelectedIndex)
            {
                case 0: freq = ScheduleFrequency.Once; break;
                case 2: freq = ScheduleFrequency.Weekly; break;
                case 3: freq = ScheduleFrequency.Monthly; break;
                default: freq = ScheduleFrequency.Daily; break;
            }

            WeekDayFlags days = WeekDayFlags.None;
            if (chkLun.Checked) days |= WeekDayFlags.Monday;
            if (chkMar.Checked) days |= WeekDayFlags.Tuesday;
            if (chkMie.Checked) days |= WeekDayFlags.Wednesday;
            if (chkJue.Checked) days |= WeekDayFlags.Thursday;
            if (chkVie.Checked) days |= WeekDayFlags.Friday;
            if (chkSab.Checked) days |= WeekDayFlags.Saturday;
            if (chkDom.Checked) days |= WeekDayFlags.Sunday;

            if (freq == ScheduleFrequency.Weekly && days == WeekDayFlags.None)
            {
                MessageBox.Show("Selecciona almenys un dia de la setmana.", "Validacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            Result = new JobScheduleDto
            {
                Name = txtName.Text.Trim(),
                Enabled = chkEnabled.Checked,
                FrequencyType = freq,
                StartTime = dtpStartTime.Value.TimeOfDay,
                EndTime = dtpEndTime.Value.TimeOfDay,
                EveryDays = (int)numEveryDays.Value,
                DayOfMonth = (int)numDayOfMonth.Value,
                WeekDays = days
            };
        }

        //  Cancelar
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
using System;
using System.Configuration;
using System.Windows.Forms;
using SqlLauncher.Config;
using SqlLauncher.Services;

namespace SqlLauncher
{
    public partial class FrmLanzadera : Form
    {
        private SqlAgentService _sqlAgentService;
        private ProgressBar _progressBar;
        private readonly int _defaultTimeoutMinutes;
        
        public FrmLanzadera()
        {
            InitializeComponent(); 
            lstJobs.SelectedIndexChanged += LstJobs_SelectedIndexChanged;

            int timeout;
            _defaultTimeoutMinutes = int.TryParse(ConfigurationManager.AppSettings["Job.DefaultTimeoutMinutes"], out timeout) ? timeout : 60;
        }

        private string GetSelectedDatabase()
        {
            string sel = cmbB_bd.SelectedItem != null ? cmbB_bd.SelectedItem.ToString() : cmbB_bd.Text.Trim();

            return (sel == "(Totes les BD)" || string.IsNullOrEmpty(sel)) ? null : sel;
        }

        private void FrmLanzadera_Load(object sender, EventArgs e)
        {
            CargarServidores();
        }

        private void CargarServidores()
        {
            string servidores = ConfigurationManager.AppSettings["SqlServer.Servers"] ?? string.Empty;

            cmb_srvr.Items.Clear();

            foreach (string srv in servidores.Split(';'))
            {
                string s = srv.Trim();
                if (!string.IsNullOrEmpty(s))
                    cmb_srvr.Items.Add(s);
            }
        }

        private void cmb_srvr_Leave(object sender, EventArgs e)
        {
            if (cmb_srvr.SelectedItem != null)
                ConectarAlServidor(cmb_srvr.SelectedItem.ToString());
            else if (!string.IsNullOrWhiteSpace(cmb_srvr.Text))
                ConectarAlServidor(cmb_srvr.Text.Trim());
        }

        private void ConectarAlServidor(string servidor)
        {
            _sqlAgentService = null;
            btnRunSelected.Enabled = false;
            btnNouJob.Enabled = false;
            btnEditarJob.Enabled = false;
            lstJobs.Items.Clear();
            cmbB_bd.Items.Clear();
            cmb_srvr.Enabled = false;

            try
            {
                string userId = ConfigurationManager.AppSettings["SqlServer.UserId"] ?? string.Empty;
                string password = ConfigurationManager.AppSettings["SqlServer.Password"] ?? string.Empty;
                bool trust = bool.Parse(
                    ConfigurationManager.AppSettings["SqlServer.TrustServerCertificate"] ?? "true");

                var config = SqlServerConfig.FromValues(
                    server: servidor,
                    integratedSecurity: false,
                    userId: userId,
                    password: password,
                    trustServerCertificate: trust
                );

                _sqlAgentService = new SqlAgentService(config, Log);
                btnNouJob.Enabled = true;

                CargarBasesDeDades();
            }
            catch (Exception ex)
            {
                _sqlAgentService = null;
                Log("[ERROR] " + ex.Message);
                MessageBox.Show(
                    "No s'ha pogut connectar a " + servidor + ":\n" + ex.Message,
                    "Error de connexio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cmb_srvr.Enabled = true;
            }
        }
        private void CargarBasesDeDades()
        {
            cmbB_bd.Items.Clear();
            cmbB_bd.Items.Add("(Totes les BD)");

            foreach (string bd in _sqlAgentService.GetDatabases())
                cmbB_bd.Items.Add(bd);

            Log("Bases de dades carregades: " + (cmbB_bd.Items.Count - 1));
        }
        
        private void CargarJobs()
        {
            lstJobs.Items.Clear();
            btnRunSelected.Enabled = false;
            btnEditarJob.Enabled = false;

            string filtro = GetSelectedDatabase();

            var jobs = _sqlAgentService.GetJobs(filtro);

            foreach (JobInfo job in jobs)
                if (!string.IsNullOrWhiteSpace(job.Name))
                    lstJobs.Items.Add(job);

            Log("Jobs carregats: " + lstJobs.Items.Count + (filtro != null ? "  (filtre BD: " + filtro + ")" : "  (tots)"));

            btnRunSelected.Enabled = lstJobs.Items.Count > 0;
        }

        private void LstJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditarJob.Enabled = lstJobs.SelectedItem != null;
        }

        private async void btnRunSelected_Click(object sender, EventArgs e)
        {
            if (lstJobs.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un job.", "Informacio",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            JobInfo jobInfo = lstJobs.SelectedItem as JobInfo;
            if (jobInfo == null) return;

            btnRunSelected.Enabled = false;
            btnNouJob.Enabled = false;
            btnEditarJob.Enabled = false;
            cmb_srvr.Enabled = false;
            cmbB_bd.Enabled = false;
            _progressBar.Visible = true;

            try
            {
                Log("--------------------------------------");
                Log("Iniciant job: " + jobInfo.Name);

                int timeout = _defaultTimeoutMinutes;

                await System.Threading.Tasks.Task.Run(() =>
                {
                    _sqlAgentService.LaunchJob(jobInfo.Name);

                    bool success = _sqlAgentService.WaitForCompletion(jobInfo.Name, timeout);

                    if (!success)
                        throw new Exception("El job ha finalitzat amb error o timeout.");
                });

                Log("Job completat correctament.");
                MessageBox.Show("Job completat correctament.", "Resultat",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log("[ERROR] " + ex.Message);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _progressBar.Visible = false;
                btnRunSelected.Enabled = true;
                btnNouJob.Enabled = _sqlAgentService != null;
                btnEditarJob.Enabled = lstJobs.SelectedItem != null;
                cmb_srvr.Enabled = true;
                cmbB_bd.Enabled = true;
            }
        }

        private void btnNouJob_Click(object sender, EventArgs e)
        {
            if (_sqlAgentService == null) return;

            string dbName = GetSelectedDatabase();

            using (var frm = new FrmJobEditor(_sqlAgentService, Log, dbName))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    CargarJobs();
            }
        }

        private void btnEditarJob_Click(object sender, EventArgs e)
        {
            if (_sqlAgentService == null) return;

            JobInfo jobInfo = lstJobs.SelectedItem as JobInfo;
            if (jobInfo == null) return;

            string dbName = GetSelectedDatabase();

            using (var frm = new FrmJobEditor(_sqlAgentService, Log, dbName, jobInfo.Name))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    CargarJobs();
            }
        }

        private void Log(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(Log), message);
                return;
            }

            txtLog.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message + Environment.NewLine);
        }

        private void cmbB_bd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_sqlAgentService == null) 
                return;
            CargarJobs();
        }
    }
}
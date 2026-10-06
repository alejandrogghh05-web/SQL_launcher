using System;
using System.Windows.Forms;
using SqlLauncher.Services;

namespace SqlLauncher
{
    public partial class FrmStepEditor : Form
    {
        public JobStepDto Result { get; private set; }

        public FrmStepEditor(int stepNumber, JobStepDto existing, string databaseName)
        {
            InitializeComponent();

            if (!string.IsNullOrWhiteSpace(databaseName))
            {
                txtDatabase.Text = databaseName;
                txtDatabase.Enabled = false;
                txtDatabase.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                txtDatabase.Text = string.Empty;
                txtDatabase.Enabled = true;
                txtDatabase.BackColor = System.Drawing.SystemColors.Window;
            }

            if (existing != null)
            {
                this.Text = "Editar Pas";
                txtStepName.Text = existing.StepName;
                txtDatabase.Text = !string.IsNullOrWhiteSpace(databaseName)
                                    ? databaseName
                                    : existing.DatabaseName;
                txtCommand.Text = existing.Command;
            }
            else
            {
                this.Text = "Nou Pas";
                txtStepName.Text = "Pas " + stepNumber;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStepName.Text))
            {
                MessageBox.Show("El nom del pas es obligatori.", "Validacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStepName.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDatabase.Text))
            {
                MessageBox.Show("La base de dades es obligatoria.", "Validacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDatabase.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCommand.Text))
            {
                MessageBox.Show("El comandament T-SQL es obligatori.", "Validacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCommand.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            Result = new JobStepDto
            {
                StepName = txtStepName.Text.Trim(),
                DatabaseName = txtDatabase.Text.Trim(),
                Command = txtCommand.Text.Trim()
            };
        }

        //Cancelar
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
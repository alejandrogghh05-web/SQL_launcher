namespace SqlLauncher
{
    partial class FrmJobEditor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabPasos = new System.Windows.Forms.TabPage();
            this.tabSchedules = new System.Windows.Forms.TabPage();

            // --- Tab General ---
            this.lblJobName = new System.Windows.Forms.Label();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();

            // --- Tab Pasos ---
            this.lstPasos = new System.Windows.Forms.ListBox();
            this.btnAddStep = new System.Windows.Forms.Button();
            this.btnEditStep = new System.Windows.Forms.Button();
            this.btnDeleteStep = new System.Windows.Forms.Button();
            this.btnStepUp = new System.Windows.Forms.Button();
            this.btnStepDown = new System.Windows.Forms.Button();
            this.cmbStepDatabase = new System.Windows.Forms.ComboBox();

            // --- Tab Schedules ---
            this.lstSchedules = new System.Windows.Forms.ListBox();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.btnEditSchedule = new System.Windows.Forms.Button();
            this.btnDeleteSchedule = new System.Windows.Forms.Button();

            // --- Botones principales ---
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.tabControl.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabPasos.SuspendLayout();
            this.tabSchedules.SuspendLayout();
            this.SuspendLayout();

            // ----------------------------------------------------------------
            // tabControl
            // ----------------------------------------------------------------
            this.tabControl.Controls.Add(this.tabGeneral);
            this.tabControl.Controls.Add(this.tabPasos);
            this.tabControl.Controls.Add(this.tabSchedules);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.Size = new System.Drawing.Size(760, 460);
            this.tabControl.TabIndex = 0;

            // ----------------------------------------------------------------
            // tabGeneral
            // ----------------------------------------------------------------
            this.tabGeneral.Text = "General";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(10);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.UseVisualStyleBackColor = true;

            this.lblJobName.Text = "Nom del Job:";
            this.lblJobName.Location = new System.Drawing.Point(16, 20);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.AutoSize = true;

            this.txtJobName.Location = new System.Drawing.Point(130, 17);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(400, 22);
            this.txtJobName.TabIndex = 0;

            this.lblDescription.Text = "Descripció:";
            this.lblDescription.Location = new System.Drawing.Point(16, 58);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.AutoSize = true;

            this.txtDescription.Location = new System.Drawing.Point(130, 55);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(580, 80);
            this.txtDescription.Multiline = true;
            this.txtDescription.TabIndex = 1;

            this.chkEnabled.Text = "Job habilitat";
            this.chkEnabled.Location = new System.Drawing.Point(130, 148);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.TabIndex = 2;

            this.tabGeneral.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblJobName,    this.txtJobName,
                this.lblDescription, this.txtDescription,
                this.chkEnabled
            });

            // ----------------------------------------------------------------
            // tabPasos
            // ----------------------------------------------------------------
            this.tabPasos.Text = "Passos";
            this.tabPasos.Padding = new System.Windows.Forms.Padding(10);
            this.tabPasos.Name = "tabPasos";
            this.tabPasos.UseVisualStyleBackColor = true;

            this.lstPasos.Location = new System.Drawing.Point(16, 16);
            this.lstPasos.Name = "lstPasos";
            this.lstPasos.Size = new System.Drawing.Size(620, 390);
            this.lstPasos.TabIndex = 0;
            this.lstPasos.SelectedIndexChanged +=
                new System.EventHandler(this.lstPasos_SelectedIndexChanged);

            // Botons de pasos – coordenades constants
            this.btnAddStep.Text = "Afegir";
            this.btnAddStep.Location = new System.Drawing.Point(648, 16);
            this.btnAddStep.Name = "btnAddStep";
            this.btnAddStep.Size = new System.Drawing.Size(96, 28);
            this.btnAddStep.TabIndex = 1;
            this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);

            this.btnEditStep.Text = "Editar";
            this.btnEditStep.Location = new System.Drawing.Point(648, 50);
            this.btnEditStep.Name = "btnEditStep";
            this.btnEditStep.Size = new System.Drawing.Size(96, 28);
            this.btnEditStep.Enabled = false;
            this.btnEditStep.TabIndex = 2;
            this.btnEditStep.Click += new System.EventHandler(this.btnEditStep_Click);

            this.btnDeleteStep.Text = "Eliminar";
            this.btnDeleteStep.Location = new System.Drawing.Point(648, 84);
            this.btnDeleteStep.Name = "btnDeleteStep";
            this.btnDeleteStep.Size = new System.Drawing.Size(96, 28);
            this.btnDeleteStep.Enabled = false;
            this.btnDeleteStep.TabIndex = 3;
            this.btnDeleteStep.Click += new System.EventHandler(this.btnDeleteStep_Click);

            this.btnStepUp.Text = "▲ Amunt";
            this.btnStepUp.Location = new System.Drawing.Point(648, 132);
            this.btnStepUp.Name = "btnStepUp";
            this.btnStepUp.Size = new System.Drawing.Size(96, 28);
            this.btnStepUp.Enabled = false;
            this.btnStepUp.TabIndex = 4;
            this.btnStepUp.Click += new System.EventHandler(this.btnStepUp_Click);

            this.btnStepDown.Text = "▼ Avall";
            this.btnStepDown.Location = new System.Drawing.Point(648, 166);
            this.btnStepDown.Name = "btnStepDown";
            this.btnStepDown.Size = new System.Drawing.Size(96, 28);
            this.btnStepDown.Enabled = false;
            this.btnStepDown.TabIndex = 5;
            this.btnStepDown.Click += new System.EventHandler(this.btnStepDown_Click);

            // cmbStepDatabase: invisible, s'usa internament per passar BD a FrmStepEditor.
            // Ha d'estar dins d'un contenidor perquè el designer no llanci NullReference.
            this.cmbStepDatabase.Location = new System.Drawing.Point(0, 0);
            this.cmbStepDatabase.Name = "cmbStepDatabase";
            this.cmbStepDatabase.Size = new System.Drawing.Size(1, 1);
            this.cmbStepDatabase.TabIndex = 99;
            this.cmbStepDatabase.Visible = false;

            this.tabPasos.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lstPasos,
                this.btnAddStep,    this.btnEditStep,  this.btnDeleteStep,
                this.btnStepUp,     this.btnStepDown,
                this.cmbStepDatabase
            });

            // ----------------------------------------------------------------
            // tabSchedules
            // ----------------------------------------------------------------
            this.tabSchedules.Text = "Schedules";
            this.tabSchedules.Padding = new System.Windows.Forms.Padding(10);
            this.tabSchedules.Name = "tabSchedules";
            this.tabSchedules.UseVisualStyleBackColor = true;

            this.lstSchedules.Location = new System.Drawing.Point(16, 16);
            this.lstSchedules.Name = "lstSchedules";
            this.lstSchedules.Size = new System.Drawing.Size(620, 390);
            this.lstSchedules.TabIndex = 0;
            this.lstSchedules.SelectedIndexChanged +=
                new System.EventHandler(this.lstSchedules_SelectedIndexChanged);

            this.btnAddSchedule.Text = "Afegir";
            this.btnAddSchedule.Location = new System.Drawing.Point(648, 16);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(96, 28);
            this.btnAddSchedule.TabIndex = 1;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);

            this.btnEditSchedule.Text = "Editar";
            this.btnEditSchedule.Location = new System.Drawing.Point(648, 50);
            this.btnEditSchedule.Name = "btnEditSchedule";
            this.btnEditSchedule.Size = new System.Drawing.Size(96, 28);
            this.btnEditSchedule.Enabled = false;
            this.btnEditSchedule.TabIndex = 2;
            this.btnEditSchedule.Click += new System.EventHandler(this.btnEditSchedule_Click);

            this.btnDeleteSchedule.Text = "Eliminar";
            this.btnDeleteSchedule.Location = new System.Drawing.Point(648, 84);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(96, 28);
            this.btnDeleteSchedule.Enabled = false;
            this.btnDeleteSchedule.TabIndex = 3;
            this.btnDeleteSchedule.Click += new System.EventHandler(this.btnDeleteSchedule_Click);

            this.tabSchedules.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lstSchedules,
                this.btnAddSchedule, this.btnEditSchedule, this.btnDeleteSchedule
            });

            // ----------------------------------------------------------------
            // btnGuardar
            // ----------------------------------------------------------------
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(588, 484);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // ----------------------------------------------------------------
            // btnCancelar
            // ----------------------------------------------------------------
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(684, 484);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ----------------------------------------------------------------
            // FrmJobEditor
            // ----------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 526);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.tabControl, this.btnGuardar, this.btnCancelar
            });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmJobEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Job Editor";
            this.Load += new System.EventHandler(this.FrmJobEditor_Load);

            this.tabControl.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabPasos.ResumeLayout(false);
            this.tabSchedules.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ----------------------------------------------------------------
        // Declaració de controls
        // ----------------------------------------------------------------
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabPasos;
        private System.Windows.Forms.TabPage tabSchedules;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.ListBox lstPasos;
        private System.Windows.Forms.Button btnAddStep;
        private System.Windows.Forms.Button btnEditStep;
        private System.Windows.Forms.Button btnDeleteStep;
        private System.Windows.Forms.Button btnStepUp;
        private System.Windows.Forms.Button btnStepDown;
        private System.Windows.Forms.ComboBox cmbStepDatabase;
        private System.Windows.Forms.ListBox lstSchedules;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnEditSchedule;
        private System.Windows.Forms.Button btnDeleteSchedule;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
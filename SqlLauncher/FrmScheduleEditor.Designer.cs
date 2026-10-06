namespace SqlLauncher
{
    partial class FrmScheduleEditor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.cmbFrequency = new System.Windows.Forms.ComboBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.panelDaily = new System.Windows.Forms.Panel();
            this.lblEveryDays = new System.Windows.Forms.Label();
            this.numEveryDays = new System.Windows.Forms.NumericUpDown();
            this.panelWeekly = new System.Windows.Forms.Panel();
            this.chkLun = new System.Windows.Forms.CheckBox();
            this.chkMar = new System.Windows.Forms.CheckBox();
            this.chkMie = new System.Windows.Forms.CheckBox();
            this.chkJue = new System.Windows.Forms.CheckBox();
            this.chkVie = new System.Windows.Forms.CheckBox();
            this.chkSab = new System.Windows.Forms.CheckBox();
            this.chkDom = new System.Windows.Forms.CheckBox();
            this.panelMonthly = new System.Windows.Forms.Panel();
            this.lblDayOfMonth = new System.Windows.Forms.Label();
            this.numDayOfMonth = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)this.numEveryDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numDayOfMonth).BeginInit();
            this.panelDaily.SuspendLayout();
            this.panelWeekly.SuspendLayout();
            this.panelMonthly.SuspendLayout();
            this.SuspendLayout();

            // ----------------------------------------------------------------
            // lblName
            // ----------------------------------------------------------------
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 16);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Nom:";

            // ----------------------------------------------------------------
            // txtName
            // ----------------------------------------------------------------
            this.txtName.Location = new System.Drawing.Point(145, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(265, 22);
            this.txtName.TabIndex = 0;

            // ----------------------------------------------------------------
            // chkEnabled
            // ----------------------------------------------------------------
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(145, 46);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Text = "Habilitat";
            this.chkEnabled.TabIndex = 1;

            // ----------------------------------------------------------------
            // lblFrequency
            // ----------------------------------------------------------------
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(12, 78);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Text = "Freqüència:";

            // ----------------------------------------------------------------
            // cmbFrequency
            // ----------------------------------------------------------------
            this.cmbFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrequency.Location = new System.Drawing.Point(145, 75);
            this.cmbFrequency.Name = "cmbFrequency";
            this.cmbFrequency.Size = new System.Drawing.Size(200, 22);
            this.cmbFrequency.TabIndex = 2;
            this.cmbFrequency.Items.AddRange(new object[]
                { "Una vegada", "Diària", "Setmanal", "Mensual" });
            this.cmbFrequency.SelectedIndexChanged +=
                new System.EventHandler(this.cmbFrequency_SelectedIndexChanged);

            // ----------------------------------------------------------------
            // lblStartTime
            // ----------------------------------------------------------------
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(12, 114);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Text = "Hora inici:";

            // ----------------------------------------------------------------
            // dtpStartTime
            // ----------------------------------------------------------------
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(145, 111);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(120, 22);
            this.dtpStartTime.TabIndex = 3;
            this.dtpStartTime.Value = new System.DateTime(2000, 1, 1, 6, 0, 0, 0);

            // ----------------------------------------------------------------
            // lblEndTime
            // ----------------------------------------------------------------
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(12, 148);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Text = "Hora fi:";

            // ----------------------------------------------------------------
            // dtpEndTime
            // ----------------------------------------------------------------
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(145, 145);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(120, 22);
            this.dtpEndTime.TabIndex = 4;
            this.dtpEndTime.Value = new System.DateTime(2000, 1, 1, 22, 0, 0, 0);

            // ----------------------------------------------------------------
            // panelDaily – contenido
            // ----------------------------------------------------------------
            this.lblEveryDays.AutoSize = true;
            this.lblEveryDays.Location = new System.Drawing.Point(0, 9);
            this.lblEveryDays.Name = "lblEveryDays";
            this.lblEveryDays.Text = "Cada (dies):";

            this.numEveryDays.Location = new System.Drawing.Point(118, 7);
            this.numEveryDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numEveryDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            this.numEveryDays.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numEveryDays.Width = 60;
            this.numEveryDays.Name = "numEveryDays";
            this.numEveryDays.TabIndex = 0;

            this.panelDaily.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblEveryDays, this.numEveryDays });
            this.panelDaily.Location = new System.Drawing.Point(12, 184);
            this.panelDaily.Name = "panelDaily";
            this.panelDaily.Size = new System.Drawing.Size(420, 36);
            this.panelDaily.Visible = false;

            // ----------------------------------------------------------------
            // panelWeekly – contenido
            // ----------------------------------------------------------------
            this.chkLun.AutoSize = true;
            this.chkLun.Text = "Dl";
            this.chkLun.Location = new System.Drawing.Point(0, 9);
            this.chkLun.Name = "chkLun";
            this.chkLun.TabIndex = 0;

            this.chkMar.AutoSize = true;
            this.chkMar.Text = "Dm";
            this.chkMar.Location = new System.Drawing.Point(52, 9);
            this.chkMar.Name = "chkMar";
            this.chkMar.TabIndex = 1;

            this.chkMie.AutoSize = true;
            this.chkMie.Text = "Dc";
            this.chkMie.Location = new System.Drawing.Point(104, 9);
            this.chkMie.Name = "chkMie";
            this.chkMie.TabIndex = 2;

            this.chkJue.AutoSize = true;
            this.chkJue.Text = "Dj";
            this.chkJue.Location = new System.Drawing.Point(156, 9);
            this.chkJue.Name = "chkJue";
            this.chkJue.TabIndex = 3;

            this.chkVie.AutoSize = true;
            this.chkVie.Text = "Dv";
            this.chkVie.Location = new System.Drawing.Point(208, 9);
            this.chkVie.Name = "chkVie";
            this.chkVie.TabIndex = 4;

            this.chkSab.AutoSize = true;
            this.chkSab.Text = "Ds";
            this.chkSab.Location = new System.Drawing.Point(260, 9);
            this.chkSab.Name = "chkSab";
            this.chkSab.TabIndex = 5;

            this.chkDom.AutoSize = true;
            this.chkDom.Text = "Dg";
            this.chkDom.Location = new System.Drawing.Point(312, 9);
            this.chkDom.Name = "chkDom";
            this.chkDom.TabIndex = 6;

            this.panelWeekly.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.chkLun, this.chkMar, this.chkMie, this.chkJue,
                  this.chkVie, this.chkSab, this.chkDom });
            this.panelWeekly.Location = new System.Drawing.Point(12, 184);
            this.panelWeekly.Name = "panelWeekly";
            this.panelWeekly.Size = new System.Drawing.Size(420, 36);
            this.panelWeekly.Visible = false;

            // ----------------------------------------------------------------
            // panelMonthly – contenido
            // ----------------------------------------------------------------
            this.lblDayOfMonth.AutoSize = true;
            this.lblDayOfMonth.Location = new System.Drawing.Point(0, 9);
            this.lblDayOfMonth.Name = "lblDayOfMonth";
            this.lblDayOfMonth.Text = "Dia del mes:";

            this.numDayOfMonth.Location = new System.Drawing.Point(118, 7);
            this.numDayOfMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDayOfMonth.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            this.numDayOfMonth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDayOfMonth.Width = 60;
            this.numDayOfMonth.Name = "numDayOfMonth";
            this.numDayOfMonth.TabIndex = 0;

            this.panelMonthly.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblDayOfMonth, this.numDayOfMonth });
            this.panelMonthly.Location = new System.Drawing.Point(12, 184);
            this.panelMonthly.Name = "panelMonthly";
            this.panelMonthly.Size = new System.Drawing.Size(420, 36);
            this.panelMonthly.Visible = false;

            // ----------------------------------------------------------------
            // btnOk
            // ----------------------------------------------------------------
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(252, 238);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 28);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Acceptar";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);

            // ----------------------------------------------------------------
            // btnCancel
            // ----------------------------------------------------------------
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(340, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ----------------------------------------------------------------
            // FrmScheduleEditor
            // ----------------------------------------------------------------
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 280);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblName,      this.txtName,
                this.chkEnabled,
                this.lblFrequency, this.cmbFrequency,
                this.lblStartTime, this.dtpStartTime,
                this.lblEndTime,   this.dtpEndTime,
                this.panelDaily,   this.panelWeekly,  this.panelMonthly,
                this.btnOk,        this.btnCancel
            });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmScheduleEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schedule";

            ((System.ComponentModel.ISupportInitialize)this.numEveryDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numDayOfMonth).EndInit();
            this.panelDaily.ResumeLayout(false);
            this.panelWeekly.ResumeLayout(false);
            this.panelMonthly.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ----------------------------------------------------------------
        // Declaració de controls
        // ----------------------------------------------------------------
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.ComboBox cmbFrequency;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Panel panelDaily;
        private System.Windows.Forms.Label lblEveryDays;
        private System.Windows.Forms.NumericUpDown numEveryDays;
        private System.Windows.Forms.Panel panelWeekly;
        private System.Windows.Forms.CheckBox chkLun;
        private System.Windows.Forms.CheckBox chkMar;
        private System.Windows.Forms.CheckBox chkMie;
        private System.Windows.Forms.CheckBox chkJue;
        private System.Windows.Forms.CheckBox chkVie;
        private System.Windows.Forms.CheckBox chkSab;
        private System.Windows.Forms.CheckBox chkDom;
        private System.Windows.Forms.Panel panelMonthly;
        private System.Windows.Forms.Label lblDayOfMonth;
        private System.Windows.Forms.NumericUpDown numDayOfMonth;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
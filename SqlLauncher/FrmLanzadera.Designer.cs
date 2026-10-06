namespace SqlLauncher
{
    partial class FrmLanzadera
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstJobs = new System.Windows.Forms.ListBox();
            this.gbLstJobs = new System.Windows.Forms.GroupBox();
            this.btnRunSelected = new System.Windows.Forms.Button();
            this.gbAutentificacion = new System.Windows.Forms.GroupBox();
            this.btnEditarJob = new System.Windows.Forms.Button();
            this.btnNouJob = new System.Windows.Forms.Button();
            this.lbl_bd = new System.Windows.Forms.Label();
            this.cmb_srvr = new System.Windows.Forms.ComboBox();
            this.cmbB_bd = new System.Windows.Forms.ComboBox();
            this.lbl_Servidor = new System.Windows.Forms.Label();
            this.gb_Logs = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.gbLstJobs.SuspendLayout();
            this.gbAutentificacion.SuspendLayout();
            this.gb_Logs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstJobs
            // 
            this.lstJobs.FormattingEnabled = true;
            this.lstJobs.Location = new System.Drawing.Point(6, 29);
            this.lstJobs.Name = "lstJobs";
            this.lstJobs.Size = new System.Drawing.Size(401, 186);
            this.lstJobs.TabIndex = 0;
            // 
            // gbLstJobs
            // 
            this.gbLstJobs.Controls.Add(this.lstJobs);
            this.gbLstJobs.Location = new System.Drawing.Point(12, 26);
            this.gbLstJobs.Name = "gbLstJobs";
            this.gbLstJobs.Size = new System.Drawing.Size(429, 230);
            this.gbLstJobs.TabIndex = 1;
            this.gbLstJobs.TabStop = false;
            this.gbLstJobs.Text = "Jobs Configurats";
            // 
            // btnRunSelected
            // 
            this.btnRunSelected.Enabled = false;
            this.btnRunSelected.Location = new System.Drawing.Point(320, 192);
            this.btnRunSelected.Name = "btnRunSelected";
            this.btnRunSelected.Size = new System.Drawing.Size(144, 23);
            this.btnRunSelected.TabIndex = 2;
            this.btnRunSelected.Text = "Executar Job Seleccionat";
            this.btnRunSelected.UseVisualStyleBackColor = true;
            this.btnRunSelected.Click += new System.EventHandler(this.btnRunSelected_Click);
            // 
            // gbAutentificacion
            // 
            this.gbAutentificacion.Controls.Add(this.btnEditarJob);
            this.gbAutentificacion.Controls.Add(this.btnNouJob);
            this.gbAutentificacion.Controls.Add(this.lbl_bd);
            this.gbAutentificacion.Controls.Add(this.cmb_srvr);
            this.gbAutentificacion.Controls.Add(this.cmbB_bd);
            this.gbAutentificacion.Controls.Add(this.btnRunSelected);
            this.gbAutentificacion.Controls.Add(this.lbl_Servidor);
            this.gbAutentificacion.Location = new System.Drawing.Point(457, 26);
            this.gbAutentificacion.Name = "gbAutentificacion";
            this.gbAutentificacion.Size = new System.Drawing.Size(479, 230);
            this.gbAutentificacion.TabIndex = 3;
            this.gbAutentificacion.TabStop = false;
            this.gbAutentificacion.Text = "Auntentificació";
            // 
            // btnEditarJob
            // 
            this.btnEditarJob.Location = new System.Drawing.Point(239, 192);
            this.btnEditarJob.Name = "btnEditarJob";
            this.btnEditarJob.Size = new System.Drawing.Size(75, 23);
            this.btnEditarJob.TabIndex = 15;
            this.btnEditarJob.Text = "Editar Job";
            this.btnEditarJob.UseVisualStyleBackColor = true;
            this.btnEditarJob.Click += new System.EventHandler(this.btnEditarJob_Click);
            // 
            // btnNouJob
            // 
            this.btnNouJob.Location = new System.Drawing.Point(158, 192);
            this.btnNouJob.Name = "btnNouJob";
            this.btnNouJob.Size = new System.Drawing.Size(75, 23);
            this.btnNouJob.TabIndex = 14;
            this.btnNouJob.Text = "Nou Job";
            this.btnNouJob.UseVisualStyleBackColor = true;
            this.btnNouJob.Click += new System.EventHandler(this.btnNouJob_Click);
            // 
            // lbl_bd
            // 
            this.lbl_bd.AutoSize = true;
            this.lbl_bd.Location = new System.Drawing.Point(29, 82);
            this.lbl_bd.Name = "lbl_bd";
            this.lbl_bd.Size = new System.Drawing.Size(100, 15);
            this.lbl_bd.TabIndex = 13;
            this.lbl_bd.Text = "Bases de Dades:";
            // 
            // cmb_srvr
            // 
            this.cmb_srvr.FormattingEnabled = true;
            this.cmb_srvr.Items.AddRange(new object[] {
            "ARCTURUS2.COMB1.ORG,1280",
            "ARCTURUS.COMB1.ORG,1280"});
            this.cmb_srvr.Location = new System.Drawing.Point(127, 41);
            this.cmb_srvr.Name = "cmb_srvr";
            this.cmb_srvr.Size = new System.Drawing.Size(218, 21);
            this.cmb_srvr.TabIndex = 12;
            this.cmb_srvr.Leave += new System.EventHandler(this.cmb_srvr_Leave);
            // 
            // cmbB_bd
            // 
            this.cmbB_bd.FormattingEnabled = true;
            this.cmbB_bd.Location = new System.Drawing.Point(127, 79);
            this.cmbB_bd.Name = "cmbB_bd";
            this.cmbB_bd.Size = new System.Drawing.Size(218, 21);
            this.cmbB_bd.TabIndex = 11;
            this.cmbB_bd.SelectedIndexChanged += new System.EventHandler(this.cmbB_bd_SelectedIndexChanged);
            // 
            // lbl_Servidor
            // 
            this.lbl_Servidor.AutoSize = true;
            this.lbl_Servidor.Location = new System.Drawing.Point(29, 44);
            this.lbl_Servidor.Name = "lbl_Servidor";
            this.lbl_Servidor.Size = new System.Drawing.Size(55, 15);
            this.lbl_Servidor.TabIndex = 3;
            this.lbl_Servidor.Text = "Servidor:";
            // 
            // gb_Logs
            // 
            this.gb_Logs.Controls.Add(this.txtLog);
            this.gb_Logs.Location = new System.Drawing.Point(12, 276);
            this.gb_Logs.Name = "gb_Logs";
            this.gb_Logs.Size = new System.Drawing.Size(924, 293);
            this.gb_Logs.TabIndex = 4;
            this.gb_Logs.TabStop = false;
            this.gb_Logs.Text = "Logs";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(7, 20);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(911, 267);
            this.txtLog.TabIndex = 0;
            // 
            // FrmLanzadera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 581);
            this.Controls.Add(this.gb_Logs);
            this.Controls.Add(this.gbAutentificacion);
            this.Controls.Add(this.gbLstJobs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLanzadera";
            this.Text = "Lanzadera";
            this.Load += new System.EventHandler(this.FrmLanzadera_Load);
            this.gbLstJobs.ResumeLayout(false);
            this.gbAutentificacion.ResumeLayout(false);
            this.gbAutentificacion.PerformLayout();
            this.gb_Logs.ResumeLayout(false);
            this.gb_Logs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstJobs;
        private System.Windows.Forms.GroupBox gbLstJobs;
        private System.Windows.Forms.Button btnRunSelected;
        private System.Windows.Forms.GroupBox gbAutentificacion;
        private System.Windows.Forms.Label lbl_Servidor;
        private System.Windows.Forms.GroupBox gb_Logs;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lbl_bd;
        private System.Windows.Forms.ComboBox cmb_srvr;
        private System.Windows.Forms.ComboBox cmbB_bd;
        private System.Windows.Forms.Button btnNouJob;
        private System.Windows.Forms.Button btnEditarJob;
    }
}


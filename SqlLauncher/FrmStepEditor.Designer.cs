namespace SqlLauncher
{
    partial class FrmStepEditor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblStepName = new System.Windows.Forms.Label();
            this.txtStepName = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblCommand = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.RichTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ── lblStepName ───────────────────────────────────────
            this.lblStepName.AutoSize = true;
            this.lblStepName.Location = new System.Drawing.Point(12, 18);
            this.lblStepName.Name = "lblStepName";
            this.lblStepName.Size = new System.Drawing.Size(85, 15);
            this.lblStepName.TabIndex = 0;
            this.lblStepName.Text = "Nom del pas:";

            // ── txtStepName ───────────────────────────────────────
            this.txtStepName.Anchor = System.Windows.Forms.AnchorStyles.Top
                                      | System.Windows.Forms.AnchorStyles.Left
                                      | System.Windows.Forms.AnchorStyles.Right;
            this.txtStepName.Location = new System.Drawing.Point(130, 15);
            this.txtStepName.Name = "txtStepName";
            this.txtStepName.Size = new System.Drawing.Size(342, 23);
            this.txtStepName.TabIndex = 1;

            // ── lblDatabase ───────────────────────────────────────
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(12, 53);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(95, 15);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Base de dades:";

            // ── txtDatabase ───────────────────────────────────────
            this.txtDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top
                                      | System.Windows.Forms.AnchorStyles.Left
                                      | System.Windows.Forms.AnchorStyles.Right;
            this.txtDatabase.Location = new System.Drawing.Point(130, 50);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(342, 23);
            this.txtDatabase.TabIndex = 3;

            // ── lblCommand ────────────────────────────────────────
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(12, 90);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(140, 15);
            this.lblCommand.TabIndex = 4;
            this.lblCommand.Text = "Comandament T-SQL:";

            // ── txtCommand ────────────────────────────────────────
            this.txtCommand.Anchor = System.Windows.Forms.AnchorStyles.Top
                                       | System.Windows.Forms.AnchorStyles.Bottom
                                       | System.Windows.Forms.AnchorStyles.Left
                                       | System.Windows.Forms.AnchorStyles.Right;
            this.txtCommand.Location = new System.Drawing.Point(12, 112);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(460, 295);
            this.txtCommand.TabIndex = 5;
            this.txtCommand.Font = new System.Drawing.Font("Consolas", 9.5f,
                                             System.Drawing.FontStyle.Regular,
                                             System.Drawing.GraphicsUnit.Point);
            this.txtCommand.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.txtCommand.WordWrap = false;
            this.txtCommand.AcceptsTab = true;

            // ── pnlBottom ─────────────────────────────────────────
            this.pnlBottom.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                     | System.Windows.Forms.AnchorStyles.Left
                                     | System.Windows.Forms.AnchorStyles.Right;
            this.pnlBottom.Location = new System.Drawing.Point(0, 420);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(484, 50);
            this.pnlBottom.TabIndex = 6;
            this.pnlBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOk);

            // ── btnOk ─────────────────────────────────────────────
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                    | System.Windows.Forms.AnchorStyles.Right;
            this.btnOk.Location = new System.Drawing.Point(264, 10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 30);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Acceptar";
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 9f,
                                          System.Drawing.FontStyle.Regular,
                                          System.Drawing.GraphicsUnit.Point);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);

            // ── btnCancel ─────────────────────────────────────────
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                        | System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Location = new System.Drawing.Point(374, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel·lar";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ── FrmStepEditor ─────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 471);
            this.MinimumSize = new System.Drawing.Size(500, 510);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "FrmStepEditor";
            this.Text = "Pas";
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;

            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblStepName,
                this.txtStepName,
                this.lblDatabase,
                this.txtDatabase,
                this.lblCommand,
                this.txtCommand,
                this.pnlBottom
            });

            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ── Declaració de controls ────────────────────────────────
        private System.Windows.Forms.Label lblStepName;
        private System.Windows.Forms.TextBox txtStepName;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.RichTextBox txtCommand;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlBottom;
    }
}
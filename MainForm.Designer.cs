namespace MassPdfSigner
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBoxSingle = new System.Windows.Forms.GroupBox();
            this.rdoSingleLast = new System.Windows.Forms.RadioButton();
            this.rdoSingleFirst = new System.Windows.Forms.RadioButton();
            this.btnPreviewSingle = new System.Windows.Forms.Button();
            this.pnlManualPosSingle = new System.Windows.Forms.Panel();
            this.chkAutoFreeSingle = new System.Windows.Forms.CheckBox();
            this.cmbPositionSingle = new System.Windows.Forms.ComboBox();
            this.labelPosSingle = new System.Windows.Forms.Label();
            this.btnSignSingle = new System.Windows.Forms.Button();
            this.btnBrowseSingle = new System.Windows.Forms.Button();
            this.txtSingleFile = new System.Windows.Forms.TextBox();
            this.lblSingleFile = new System.Windows.Forms.Label();
            this.groupBoxBatch = new System.Windows.Forms.GroupBox();
            this.rdoBatchLast = new System.Windows.Forms.RadioButton();
            this.rdoBatchFirst = new System.Windows.Forms.RadioButton();
            this.chkAutoFreeBatch = new System.Windows.Forms.CheckBox();
            this.cmbPositionBatch = new System.Windows.Forms.ComboBox();
            this.labelPosBatch = new System.Windows.Forms.Label();
            this.btnSignBatch = new System.Windows.Forms.Button();
            this.btnBrowseArchiveFolder = new System.Windows.Forms.Button();
            this.txtArchiveFolder = new System.Windows.Forms.TextBox();
            this.lblArchiveFolder = new System.Windows.Forms.Label();
            this.chkArchiveOriginals = new System.Windows.Forms.CheckBox();
            this.btnBrowseOutputFolder = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.btnBrowseInputFolder = new System.Windows.Forms.Button();
            this.txtInputFolder = new System.Windows.Forms.TextBox();
            this.lblInputFolder = new System.Windows.Forms.Label();
            this.groupBoxSingle.SuspendLayout();
            this.groupBoxBatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSingle
            // 
            this.groupBoxSingle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSingle.Controls.Add(this.rdoSingleLast);
            this.groupBoxSingle.Controls.Add(this.rdoSingleFirst);
            this.groupBoxSingle.Controls.Add(this.btnPreviewSingle);
            this.groupBoxSingle.Controls.Add(this.pnlManualPosSingle);
            this.groupBoxSingle.Controls.Add(this.chkAutoFreeSingle);
            this.groupBoxSingle.Controls.Add(this.cmbPositionSingle);
            this.groupBoxSingle.Controls.Add(this.labelPosSingle);
            this.groupBoxSingle.Controls.Add(this.btnSignSingle);
            this.groupBoxSingle.Controls.Add(this.btnBrowseSingle);
            this.groupBoxSingle.Controls.Add(this.txtSingleFile);
            this.groupBoxSingle.Controls.Add(this.lblSingleFile);
            this.groupBoxSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxSingle.Location = new System.Drawing.Point(14, 13);
            this.groupBoxSingle.Name = "groupBoxSingle";
            this.groupBoxSingle.Size = new System.Drawing.Size(983, 341);
            this.groupBoxSingle.TabIndex = 0;
            this.groupBoxSingle.TabStop = false;
            this.groupBoxSingle.Text = "Pojedinačno potpisivanje";
            // 
            // rdoSingleLast
            // 
            this.rdoSingleLast.AutoSize = true;
            this.rdoSingleLast.Location = new System.Drawing.Point(433, 112);
            this.rdoSingleLast.Name = "rdoSingleLast";
            this.rdoSingleLast.Size = new System.Drawing.Size(139, 22);
            this.rdoSingleLast.TabIndex = 10;
            this.rdoSingleLast.TabStop = true;
            this.rdoSingleLast.Text = "Poslednja strana";
            this.rdoSingleLast.UseVisualStyleBackColor = true;
            // 
            // rdoSingleFirst
            // 
            this.rdoSingleFirst.AutoSize = true;
            this.rdoSingleFirst.Location = new System.Drawing.Point(433, 84);
            this.rdoSingleFirst.Name = "rdoSingleFirst";
            this.rdoSingleFirst.Size = new System.Drawing.Size(104, 22);
            this.rdoSingleFirst.TabIndex = 9;
            this.rdoSingleFirst.TabStop = true;
            this.rdoSingleFirst.Text = "Prva strana";
            this.rdoSingleFirst.UseVisualStyleBackColor = true;
            // 
            // btnPreviewSingle
            // 
            this.btnPreviewSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewSingle.Location = new System.Drawing.Point(839, 235);
            this.btnPreviewSingle.Name = "btnPreviewSingle";
            this.btnPreviewSingle.Size = new System.Drawing.Size(137, 27);
            this.btnPreviewSingle.TabIndex = 8;
            this.btnPreviewSingle.Text = "Preview potpisa";
            this.btnPreviewSingle.UseVisualStyleBackColor = true;
            this.btnPreviewSingle.Click += new System.EventHandler(this.btnPreviewSingle_Click);
            // 
            // pnlManualPosSingle
            // 
            this.pnlManualPosSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlManualPosSingle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlManualPosSingle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlManualPosSingle.Location = new System.Drawing.Point(607, 91);
            this.pnlManualPosSingle.Name = "pnlManualPosSingle";
            this.pnlManualPosSingle.Size = new System.Drawing.Size(169, 224);
            this.pnlManualPosSingle.TabIndex = 7;
            this.pnlManualPosSingle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlManualPosSingle_Paint);
            this.pnlManualPosSingle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlManualPosSingle_MouseClick);
            // 
            // chkAutoFreeSingle
            // 
            this.chkAutoFreeSingle.AutoSize = true;
            this.chkAutoFreeSingle.Location = new System.Drawing.Point(17, 140);
            this.chkAutoFreeSingle.Name = "chkAutoFreeSingle";
            this.chkAutoFreeSingle.Size = new System.Drawing.Size(340, 22);
            this.chkAutoFreeSingle.TabIndex = 4;
            this.chkAutoFreeSingle.Text = "Automatski odaberi slobodan ugao (ako može)";
            this.chkAutoFreeSingle.UseVisualStyleBackColor = true;
            // 
            // cmbPositionSingle
            // 
            this.cmbPositionSingle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPositionSingle.FormattingEnabled = true;
            this.cmbPositionSingle.Items.AddRange(new object[] {
            "Gore levo",
            "Gore desno",
            "Dole levo",
            "Dole desno",
            "Centar",
            "Ručno (miš)"});
            this.cmbPositionSingle.Location = new System.Drawing.Point(131, 91);
            this.cmbPositionSingle.Name = "cmbPositionSingle";
            this.cmbPositionSingle.Size = new System.Drawing.Size(205, 26);
            this.cmbPositionSingle.TabIndex = 3;
            // 
            // labelPosSingle
            // 
            this.labelPosSingle.AutoSize = true;
            this.labelPosSingle.Location = new System.Drawing.Point(14, 94);
            this.labelPosSingle.Name = "labelPosSingle";
            this.labelPosSingle.Size = new System.Drawing.Size(145, 23);
            this.labelPosSingle.TabIndex = 2;
            this.labelPosSingle.Text = "Pozicija potpisa:";
            // 
            // btnSignSingle
            // 
            this.btnSignSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignSingle.Location = new System.Drawing.Point(839, 192);
            this.btnSignSingle.Name = "btnSignSingle";
            this.btnSignSingle.Size = new System.Drawing.Size(137, 27);
            this.btnSignSingle.TabIndex = 6;
            this.btnSignSingle.Text = "Potpiši fajl";
            this.btnSignSingle.UseVisualStyleBackColor = true;
            this.btnSignSingle.Click += new System.EventHandler(this.btnSignSingle_Click);
            // 
            // btnBrowseSingle
            // 
            this.btnBrowseSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBrowseSingle.Location = new System.Drawing.Point(941, 41);
            this.btnBrowseSingle.Name = "btnBrowseSingle";
            this.btnBrowseSingle.Size = new System.Drawing.Size(34, 25);
            this.btnBrowseSingle.TabIndex = 1;
            this.btnBrowseSingle.Text = "...";
            this.btnBrowseSingle.UseVisualStyleBackColor = true;
            this.btnBrowseSingle.Click += new System.EventHandler(this.btnBrowseSingle_Click);
            // 
            // txtSingleFile
            // 
            this.txtSingleFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSingleFile.Location = new System.Drawing.Point(13, 41);
            this.txtSingleFile.Name = "txtSingleFile";
            this.txtSingleFile.Size = new System.Drawing.Size(922, 24);
            this.txtSingleFile.TabIndex = 0;
            // 
            // lblSingleFile
            // 
            this.lblSingleFile.AutoSize = true;
            this.lblSingleFile.Location = new System.Drawing.Point(14, 20);
            this.lblSingleFile.Name = "lblSingleFile";
            this.lblSingleFile.Size = new System.Drawing.Size(249, 18);
            this.lblSingleFile.TabIndex = 0;
            this.lblSingleFile.Text = "PDF fajl za pojedinačno potpisivanje:";
            // 
            // groupBoxBatch
            // 
            this.groupBoxBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBatch.Controls.Add(this.rdoBatchLast);
            this.groupBoxBatch.Controls.Add(this.rdoBatchFirst);
            this.groupBoxBatch.Controls.Add(this.chkAutoFreeBatch);
            this.groupBoxBatch.Controls.Add(this.cmbPositionBatch);
            this.groupBoxBatch.Controls.Add(this.labelPosBatch);
            this.groupBoxBatch.Controls.Add(this.btnSignBatch);
            this.groupBoxBatch.Controls.Add(this.btnBrowseArchiveFolder);
            this.groupBoxBatch.Controls.Add(this.txtArchiveFolder);
            this.groupBoxBatch.Controls.Add(this.lblArchiveFolder);
            this.groupBoxBatch.Controls.Add(this.chkArchiveOriginals);
            this.groupBoxBatch.Controls.Add(this.btnBrowseOutputFolder);
            this.groupBoxBatch.Controls.Add(this.txtOutputFolder);
            this.groupBoxBatch.Controls.Add(this.lblOutputFolder);
            this.groupBoxBatch.Controls.Add(this.btnBrowseInputFolder);
            this.groupBoxBatch.Controls.Add(this.txtInputFolder);
            this.groupBoxBatch.Controls.Add(this.lblInputFolder);
            this.groupBoxBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxBatch.Location = new System.Drawing.Point(14, 361);
            this.groupBoxBatch.Name = "groupBoxBatch";
            this.groupBoxBatch.Size = new System.Drawing.Size(983, 289);
            this.groupBoxBatch.TabIndex = 1;
            this.groupBoxBatch.TabStop = false;
            this.groupBoxBatch.Text = "Masovno potpisivanje";
            // 
            // rdoBatchLast
            // 
            this.rdoBatchLast.AutoSize = true;
            this.rdoBatchLast.Location = new System.Drawing.Point(433, 243);
            this.rdoBatchLast.Name = "rdoBatchLast";
            this.rdoBatchLast.Size = new System.Drawing.Size(139, 22);
            this.rdoBatchLast.TabIndex = 14;
            this.rdoBatchLast.TabStop = true;
            this.rdoBatchLast.Text = "Poslednja strana";
            this.rdoBatchLast.UseVisualStyleBackColor = true;
            // 
            // rdoBatchFirst
            // 
            this.rdoBatchFirst.AutoSize = true;
            this.rdoBatchFirst.Location = new System.Drawing.Point(433, 215);
            this.rdoBatchFirst.Name = "rdoBatchFirst";
            this.rdoBatchFirst.Size = new System.Drawing.Size(104, 22);
            this.rdoBatchFirst.TabIndex = 13;
            this.rdoBatchFirst.TabStop = true;
            this.rdoBatchFirst.Text = "Prva strana";
            this.rdoBatchFirst.UseVisualStyleBackColor = true;
            // 
            // chkAutoFreeBatch
            // 
            this.chkAutoFreeBatch.AutoSize = true;
            this.chkAutoFreeBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkAutoFreeBatch.Location = new System.Drawing.Point(13, 261);
            this.chkAutoFreeBatch.Name = "chkAutoFreeBatch";
            this.chkAutoFreeBatch.Size = new System.Drawing.Size(340, 22);
            this.chkAutoFreeBatch.TabIndex = 9;
            this.chkAutoFreeBatch.Text = "Automatski odaberi slobodan ugao (ako može)";
            this.chkAutoFreeBatch.UseVisualStyleBackColor = true;
            // 
            // cmbPositionBatch
            // 
            this.cmbPositionBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPositionBatch.FormattingEnabled = true;
            this.cmbPositionBatch.Items.AddRange(new object[] {
            "Gore levo",
            "Gore desno",
            "Dole levo",
            "Dole desno",
            "Centar",
            "Ručno (miš)"});
            this.cmbPositionBatch.Location = new System.Drawing.Point(131, 221);
            this.cmbPositionBatch.Name = "cmbPositionBatch";
            this.cmbPositionBatch.Size = new System.Drawing.Size(205, 26);
            this.cmbPositionBatch.TabIndex = 8;
            // 
            // labelPosBatch
            // 
            this.labelPosBatch.AutoSize = true;
            this.labelPosBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPosBatch.Location = new System.Drawing.Point(10, 224);
            this.labelPosBatch.Name = "labelPosBatch";
            this.labelPosBatch.Size = new System.Drawing.Size(116, 18);
            this.labelPosBatch.TabIndex = 7;
            this.labelPosBatch.Text = "Pozicija potpisa:";
            // 
            // btnSignBatch
            // 
            this.btnSignBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignBatch.Location = new System.Drawing.Point(839, 243);
            this.btnSignBatch.Name = "btnSignBatch";
            this.btnSignBatch.Size = new System.Drawing.Size(137, 29);
            this.btnSignBatch.TabIndex = 12;
            this.btnSignBatch.Text = "Potpiši sve PDF-ove";
            this.btnSignBatch.UseVisualStyleBackColor = true;
            this.btnSignBatch.Click += new System.EventHandler(this.btnSignBatch_Click);
            // 
            // btnBrowseArchiveFolder
            // 
            this.btnBrowseArchiveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseArchiveFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBrowseArchiveFolder.Location = new System.Drawing.Point(940, 185);
            this.btnBrowseArchiveFolder.Name = "btnBrowseArchiveFolder";
            this.btnBrowseArchiveFolder.Size = new System.Drawing.Size(35, 25);
            this.btnBrowseArchiveFolder.TabIndex = 6;
            this.btnBrowseArchiveFolder.Text = "...";
            this.btnBrowseArchiveFolder.UseVisualStyleBackColor = true;
            this.btnBrowseArchiveFolder.Click += new System.EventHandler(this.btnBrowseArchiveFolder_Click);
            // 
            // txtArchiveFolder
            // 
            this.txtArchiveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArchiveFolder.Location = new System.Drawing.Point(13, 185);
            this.txtArchiveFolder.Name = "txtArchiveFolder";
            this.txtArchiveFolder.Size = new System.Drawing.Size(921, 24);
            this.txtArchiveFolder.TabIndex = 5;
            // 
            // lblArchiveFolder
            // 
            this.lblArchiveFolder.AutoSize = true;
            this.lblArchiveFolder.Location = new System.Drawing.Point(14, 164);
            this.lblArchiveFolder.Name = "lblArchiveFolder";
            this.lblArchiveFolder.Size = new System.Drawing.Size(104, 18);
            this.lblArchiveFolder.TabIndex = 4;
            this.lblArchiveFolder.Text = "Arhivski folder:";
            // 
            // chkArchiveOriginals
            // 
            this.chkArchiveOriginals.AutoSize = true;
            this.chkArchiveOriginals.Location = new System.Drawing.Point(13, 139);
            this.chkArchiveOriginals.Name = "chkArchiveOriginals";
            this.chkArchiveOriginals.Size = new System.Drawing.Size(140, 22);
            this.chkArchiveOriginals.TabIndex = 3;
            this.chkArchiveOriginals.Text = "Arhiviraj originale";
            this.chkArchiveOriginals.UseVisualStyleBackColor = true;
            // 
            // btnBrowseOutputFolder
            // 
            this.btnBrowseOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBrowseOutputFolder.Location = new System.Drawing.Point(940, 108);
            this.btnBrowseOutputFolder.Name = "btnBrowseOutputFolder";
            this.btnBrowseOutputFolder.Size = new System.Drawing.Size(35, 25);
            this.btnBrowseOutputFolder.TabIndex = 2;
            this.btnBrowseOutputFolder.Text = "...";
            this.btnBrowseOutputFolder.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFolder.Click += new System.EventHandler(this.btnBrowseOutputFolder_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFolder.Location = new System.Drawing.Point(13, 109);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(922, 24);
            this.txtOutputFolder.TabIndex = 1;
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(13, 88);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(228, 18);
            this.lblOutputFolder.TabIndex = 0;
            this.lblOutputFolder.Text = "Izlazni folder za potpisane fajlove:";
            // 
            // btnBrowseInputFolder
            // 
            this.btnBrowseInputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseInputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBrowseInputFolder.Location = new System.Drawing.Point(940, 54);
            this.btnBrowseInputFolder.Name = "btnBrowseInputFolder";
            this.btnBrowseInputFolder.Size = new System.Drawing.Size(35, 25);
            this.btnBrowseInputFolder.TabIndex = 0;
            this.btnBrowseInputFolder.Text = "...";
            this.btnBrowseInputFolder.UseVisualStyleBackColor = true;
            this.btnBrowseInputFolder.Click += new System.EventHandler(this.btnBrowseInputFolder_Click);
            // 
            // txtInputFolder
            // 
            this.txtInputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFolder.Location = new System.Drawing.Point(17, 54);
            this.txtInputFolder.Name = "txtInputFolder";
            this.txtInputFolder.Size = new System.Drawing.Size(918, 24);
            this.txtInputFolder.TabIndex = 0;
            // 
            // lblInputFolder
            // 
            this.lblInputFolder.AutoSize = true;
            this.lblInputFolder.Location = new System.Drawing.Point(14, 34);
            this.lblInputFolder.Name = "lblInputFolder";
            this.lblInputFolder.Size = new System.Drawing.Size(242, 18);
            this.lblInputFolder.TabIndex = 0;
            this.lblInputFolder.Text = "Ulazni folder sa PDF dokumentima:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 683);
            this.Controls.Add(this.groupBoxBatch);
            this.Controls.Add(this.groupBoxSingle);
            this.MinimumSize = new System.Drawing.Size(1026, 701);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MassPdfSigner - elektronsko potpisivanje PDF dokumenata";
            this.groupBoxSingle.ResumeLayout(false);
            this.groupBoxSingle.PerformLayout();
            this.groupBoxBatch.ResumeLayout(false);
            this.groupBoxBatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSingle;
        private System.Windows.Forms.Label lblSingleFile;
        private System.Windows.Forms.TextBox txtSingleFile;
        private System.Windows.Forms.Button btnBrowseSingle;
        private System.Windows.Forms.Button btnSignSingle;
        private System.Windows.Forms.ComboBox cmbPositionSingle;
        private System.Windows.Forms.Label labelPosSingle;
        private System.Windows.Forms.CheckBox chkAutoFreeSingle;
        private System.Windows.Forms.Panel pnlManualPosSingle;
        private System.Windows.Forms.Button btnPreviewSingle;
        private System.Windows.Forms.GroupBox groupBoxBatch;
        private System.Windows.Forms.Label lblInputFolder;
        private System.Windows.Forms.TextBox txtInputFolder;
        private System.Windows.Forms.Button btnBrowseInputFolder;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnBrowseOutputFolder;
        private System.Windows.Forms.CheckBox chkArchiveOriginals;
        private System.Windows.Forms.Label lblArchiveFolder;
        private System.Windows.Forms.TextBox txtArchiveFolder;
        private System.Windows.Forms.Button btnBrowseArchiveFolder;
        private System.Windows.Forms.Button btnSignBatch;
        private System.Windows.Forms.ComboBox cmbPositionBatch;
        private System.Windows.Forms.Label labelPosBatch;
        private System.Windows.Forms.CheckBox chkAutoFreeBatch;
        private System.Windows.Forms.RadioButton rdoSingleLast;
        private System.Windows.Forms.RadioButton rdoSingleFirst;
        private System.Windows.Forms.RadioButton rdoBatchLast;
        private System.Windows.Forms.RadioButton rdoBatchFirst;
    }
}

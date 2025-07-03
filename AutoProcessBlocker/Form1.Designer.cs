namespace AutoProcessBlocker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Tasarımda kullandığımız kontroller
        private System.Windows.Forms.ListBox lstBannedPrograms;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkstartup;
        private System.Windows.Forms.Label lblStats;

        /// <summary>
        /// Temizlik metodu
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lstBannedPrograms = new System.Windows.Forms.ListBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkstartup = new System.Windows.Forms.CheckBox();
            this.lblStats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstBannedPrograms
            // 
            this.lstBannedPrograms.FormattingEnabled = true;
            this.lstBannedPrograms.ItemHeight = 16;
            this.lstBannedPrograms.Location = new System.Drawing.Point(12, 12);
            this.lstBannedPrograms.Name = "lstBannedPrograms";
            this.lstBannedPrograms.Size = new System.Drawing.Size(200, 196);
            this.lstBannedPrograms.TabIndex = 0;
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.ItemHeight = 16;
            this.lstLog.Location = new System.Drawing.Point(12, 250);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(306, 148);
            this.lstLog.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(218, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(218, 48);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 30);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Sil";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(218, 120);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Yükle";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(218, 84);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkstartup
            // 
            this.chkstartup.AutoSize = true;
            this.chkstartup.Location = new System.Drawing.Point(201, 220);
            this.chkstartup.Name = "chkstartup";
            this.chkstartup.Size = new System.Drawing.Size(141, 20);
            this.chkstartup.TabIndex = 6;
            this.chkstartup.Text = "Başlangıçta çalıştır";
            this.chkstartup.UseVisualStyleBackColor = true;
            this.chkstartup.CheckedChanged += new System.EventHandler(this.chkStartup_CheckedChanged);
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(12, 220);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(149, 16);
            this.lblStats.TabIndex = 5;
            this.lblStats.Text = "Kapatılan: 0 - RAM: 0MB";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(340, 410);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.chkstartup);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstBannedPrograms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Process Blocker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

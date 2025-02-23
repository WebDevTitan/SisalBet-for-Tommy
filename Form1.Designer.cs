namespace SisalBet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPage = new System.Windows.Forms.TabControl();
            this.SettingPage = new System.Windows.Forms.TabPage();
            this.qwe = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.ad = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStake = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatch5 = new System.Windows.Forms.TextBox();
            this.txtMatch4 = new System.Windows.Forms.TextBox();
            this.txtMatch3 = new System.Windows.Forms.TextBox();
            this.txtMatch2 = new System.Windows.Forms.TextBox();
            this.txtMatch1 = new System.Windows.Forms.TextBox();
            this.Main = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtLogs = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSportType = new System.Windows.Forms.ComboBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.txtOutcome = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnScanStop = new System.Windows.Forms.Button();
            this.MainPage.SuspendLayout();
            this.SettingPage.SuspendLayout();
            this.Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPage
            // 
            this.MainPage.Controls.Add(this.SettingPage);
            this.MainPage.Controls.Add(this.Main);
            this.MainPage.Location = new System.Drawing.Point(0, 0);
            this.MainPage.Name = "MainPage";
            this.MainPage.SelectedIndex = 0;
            this.MainPage.Size = new System.Drawing.Size(799, 503);
            this.MainPage.TabIndex = 0;
            // 
            // SettingPage
            // 
            this.SettingPage.Controls.Add(this.txtOutcome);
            this.SettingPage.Controls.Add(this.txtSportType);
            this.SettingPage.Controls.Add(this.label7);
            this.SettingPage.Controls.Add(this.qwe);
            this.SettingPage.Controls.Add(this.label11);
            this.SettingPage.Controls.Add(this.txtUsername);
            this.SettingPage.Controls.Add(this.txtPassword);
            this.SettingPage.Controls.Add(this.btnSave);
            this.SettingPage.Controls.Add(this.ad);
            this.SettingPage.Controls.Add(this.label6);
            this.SettingPage.Controls.Add(this.txtStake);
            this.SettingPage.Controls.Add(this.label5);
            this.SettingPage.Controls.Add(this.label4);
            this.SettingPage.Controls.Add(this.label3);
            this.SettingPage.Controls.Add(this.label2);
            this.SettingPage.Controls.Add(this.label1);
            this.SettingPage.Controls.Add(this.txtMatch5);
            this.SettingPage.Controls.Add(this.txtMatch4);
            this.SettingPage.Controls.Add(this.txtMatch3);
            this.SettingPage.Controls.Add(this.txtMatch2);
            this.SettingPage.Controls.Add(this.txtMatch1);
            this.SettingPage.Location = new System.Drawing.Point(4, 22);
            this.SettingPage.Name = "SettingPage";
            this.SettingPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingPage.Size = new System.Drawing.Size(791, 477);
            this.SettingPage.TabIndex = 0;
            this.SettingPage.Text = "Setting";
            this.SettingPage.UseVisualStyleBackColor = true;
            // 
            // qwe
            // 
            this.qwe.AutoSize = true;
            this.qwe.Location = new System.Drawing.Point(496, 112);
            this.qwe.Name = "qwe";
            this.qwe.Size = new System.Drawing.Size(53, 13);
            this.qwe.TabIndex = 18;
            this.qwe.Text = "Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(496, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(564, 73);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(121, 20);
            this.txtUsername.TabIndex = 16;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(564, 109);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(349, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 40);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ad
            // 
            this.ad.AutoSize = true;
            this.ad.Location = new System.Drawing.Point(496, 223);
            this.ad.Name = "ad";
            this.ad.Size = new System.Drawing.Size(38, 13);
            this.ad.TabIndex = 13;
            this.ad.Text = "Stake:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(496, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Outcome:";
            // 
            // txtStake
            // 
            this.txtStake.Location = new System.Drawing.Point(564, 220);
            this.txtStake.Name = "txtStake";
            this.txtStake.Size = new System.Drawing.Size(121, 20);
            this.txtStake.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Match5:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Match4:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Match3:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Match2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Match1:";
            // 
            // txtMatch5
            // 
            this.txtMatch5.Location = new System.Drawing.Point(152, 220);
            this.txtMatch5.Name = "txtMatch5";
            this.txtMatch5.Size = new System.Drawing.Size(196, 20);
            this.txtMatch5.TabIndex = 4;
            // 
            // txtMatch4
            // 
            this.txtMatch4.Location = new System.Drawing.Point(152, 183);
            this.txtMatch4.Name = "txtMatch4";
            this.txtMatch4.Size = new System.Drawing.Size(196, 20);
            this.txtMatch4.TabIndex = 3;
            // 
            // txtMatch3
            // 
            this.txtMatch3.Location = new System.Drawing.Point(152, 148);
            this.txtMatch3.Name = "txtMatch3";
            this.txtMatch3.Size = new System.Drawing.Size(196, 20);
            this.txtMatch3.TabIndex = 2;
            // 
            // txtMatch2
            // 
            this.txtMatch2.Location = new System.Drawing.Point(152, 109);
            this.txtMatch2.Name = "txtMatch2";
            this.txtMatch2.Size = new System.Drawing.Size(196, 20);
            this.txtMatch2.TabIndex = 1;
            // 
            // txtMatch1
            // 
            this.txtMatch1.Location = new System.Drawing.Point(152, 73);
            this.txtMatch1.Name = "txtMatch1";
            this.txtMatch1.Size = new System.Drawing.Size(196, 20);
            this.txtMatch1.TabIndex = 0;
            // 
            // Main
            // 
            this.Main.Controls.Add(this.btnScanStop);
            this.Main.Controls.Add(this.btnLoad);
            this.Main.Controls.Add(this.btnScan);
            this.Main.Controls.Add(this.label10);
            this.Main.Controls.Add(this.labelUser);
            this.Main.Controls.Add(this.btnStop);
            this.Main.Controls.Add(this.btnStart);
            this.Main.Controls.Add(this.txtLogs);
            this.Main.Location = new System.Drawing.Point(4, 22);
            this.Main.Name = "Main";
            this.Main.Padding = new System.Windows.Forms.Padding(3);
            this.Main.Size = new System.Drawing.Size(791, 477);
            this.Main.TabIndex = 1;
            this.Main.Text = "Main";
            this.Main.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Logs";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(414, 20);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(55, 13);
            this.labelUser.TabIndex = 4;
            this.labelUser.Text = "Username";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(675, 434);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(583, 434);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(6, 44);
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Size = new System.Drawing.Size(550, 425);
            this.txtLogs.TabIndex = 0;
            this.txtLogs.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(496, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Sport:";
            // 
            // txtSportType
            // 
            this.txtSportType.FormattingEnabled = true;
            this.txtSportType.Items.AddRange(new object[] {
            "Soccer",
            "Basketball",
            "Volleyball",
            "PingPong"});
            this.txtSportType.Location = new System.Drawing.Point(564, 183);
            this.txtSportType.Name = "txtSportType";
            this.txtSportType.Size = new System.Drawing.Size(121, 21);
            this.txtSportType.TabIndex = 21;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(584, 105);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(74, 23);
            this.btnScan.TabIndex = 6;
            this.btnScan.Text = "Scan Start";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtOutcome
            // 
            this.txtOutcome.Location = new System.Drawing.Point(564, 146);
            this.txtOutcome.Name = "txtOutcome";
            this.txtOutcome.Size = new System.Drawing.Size(121, 20);
            this.txtOutcome.TabIndex = 22;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(583, 203);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(167, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Roading saved eventIDs";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnScanStop
            // 
            this.btnScanStop.Location = new System.Drawing.Point(675, 105);
            this.btnScanStop.Name = "btnScanStop";
            this.btnScanStop.Size = new System.Drawing.Size(75, 23);
            this.btnScanStop.TabIndex = 8;
            this.btnScanStop.Text = "ScanStop";
            this.btnScanStop.UseVisualStyleBackColor = true;
            this.btnScanStop.Click += new System.EventHandler(this.btnScanStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 503);
            this.Controls.Add(this.MainPage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MainPage.ResumeLayout(false);
            this.SettingPage.ResumeLayout(false);
            this.SettingPage.PerformLayout();
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainPage;
        private System.Windows.Forms.TabPage SettingPage;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.Label ad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStake;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatch5;
        private System.Windows.Forms.TextBox txtMatch4;
        private System.Windows.Forms.TextBox txtMatch3;
        private System.Windows.Forms.TextBox txtMatch2;
        private System.Windows.Forms.TextBox txtMatch1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox txtLogs;
        private System.Windows.Forms.Label qwe;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox txtSportType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtOutcome;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnScanStop;
    }
}


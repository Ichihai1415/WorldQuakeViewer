namespace WorldQuakeViewer
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.JsonTimer = new System.Windows.Forms.Timer(this.components);
            this.USGS0 = new System.Windows.Forms.Label();
            this.USGS1 = new System.Windows.Forms.Label();
            this.USGS6 = new System.Windows.Forms.Label();
            this.USGS4 = new System.Windows.Forms.Label();
            this.RightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RC1Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1Bar1 = new System.Windows.Forms.ToolStripSeparator();
            this.RC1Sites = new System.Windows.Forms.ToolStripMenuItem();
            this.RCMapUSGS = new System.Windows.Forms.ToolStripMenuItem();
            this.RCMapEWSC = new System.Windows.Forms.ToolStripMenuItem();
            this.RCThisInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.RCTsunamiGov = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1Bar2 = new System.Windows.Forms.ToolStripSeparator();
            this.RC1PSInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.RCTwitter = new System.Windows.Forms.ToolStripMenuItem();
            this.RCGitHub = new System.Windows.Forms.ToolStripMenuItem();
            this.RCiInfoPage = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1Bar3 = new System.Windows.Forms.ToolStripSeparator();
            this.RC1RebootExit = new System.Windows.Forms.ToolStripMenuItem();
            this.RCreboot = new System.Windows.Forms.ToolStripMenuItem();
            this.RCexit = new System.Windows.Forms.ToolStripMenuItem();
            this.USGS2 = new System.Windows.Forms.Label();
            this.USGS3 = new System.Windows.Forms.Label();
            this.USGS5 = new System.Windows.Forms.Label();
            this.ErrorText = new System.Windows.Forms.Label();
            this.MainImg = new System.Windows.Forms.PictureBox();
            this.HistoryBack = new System.Windows.Forms.Label();
            this.History1 = new System.Windows.Forms.Label();
            this.History2 = new System.Windows.Forms.Label();
            this.History3 = new System.Windows.Forms.Label();
            this.History4 = new System.Windows.Forms.Label();
            this.History5 = new System.Windows.Forms.Label();
            this.History6 = new System.Windows.Forms.Label();
            this.RCbar3 = new System.Windows.Forms.ToolStripSeparator();
            this.RCbar5 = new System.Windows.Forms.ToolStripSeparator();
            this.RCopenreadme = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainImg)).BeginInit();
            this.SuspendLayout();
            // 
            // JsonTimer
            // 
            this.JsonTimer.Enabled = true;
            this.JsonTimer.Interval = 300;
            this.JsonTimer.Tick += new System.EventHandler(this.JsonTimer_Tick);
            // 
            // USGS0
            // 
            this.USGS0.BackColor = System.Drawing.Color.Black;
            this.USGS0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.USGS0.Font = new System.Drawing.Font("Koruri Regular", 9.5F);
            this.USGS0.Location = new System.Drawing.Point(0, 0);
            this.USGS0.Margin = new System.Windows.Forms.Padding(0);
            this.USGS0.Name = "USGS0";
            this.USGS0.Size = new System.Drawing.Size(400, 100);
            this.USGS0.TabIndex = 1;
            this.USGS0.Text = "USGS地震情報";
            // 
            // USGS1
            // 
            this.USGS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.USGS1.Font = new System.Drawing.Font("Koruri Regular", 11F);
            this.USGS1.Location = new System.Drawing.Point(2, 18);
            this.USGS1.Margin = new System.Windows.Forms.Padding(0);
            this.USGS1.Name = "USGS1";
            this.USGS1.Size = new System.Drawing.Size(396, 81);
            this.USGS1.TabIndex = 2;
            // 
            // USGS6
            // 
            this.USGS6.AutoSize = true;
            this.USGS6.Font = new System.Drawing.Font("Koruri Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.USGS6.Location = new System.Drawing.Point(259, 432);
            this.USGS6.Name = "USGS6";
            this.USGS6.Size = new System.Drawing.Size(0, 21);
            this.USGS6.TabIndex = 8;
            // 
            // USGS4
            // 
            this.USGS4.Font = new System.Drawing.Font("Koruri Regular", 11F);
            this.USGS4.Location = new System.Drawing.Point(215, 58);
            this.USGS4.Name = "USGS4";
            this.USGS4.Size = new System.Drawing.Size(104, 38);
            this.USGS4.TabIndex = 10;
            // 
            // RightClick
            // 
            this.RightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RC1Setting,
            this.RC1Bar1,
            this.RC1Sites,
            this.RC1Bar2,
            this.RC1PSInfo,
            this.RC1Bar3,
            this.RC1RebootExit});
            this.RightClick.Name = "RightClick";
            this.RightClick.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.RightClick.Size = new System.Drawing.Size(243, 118);
            this.RightClick.TabStop = true;
            this.RightClick.Text = "メニュー";
            // 
            // RC1Setting
            // 
            this.RC1Setting.Name = "RC1Setting";
            this.RC1Setting.Size = new System.Drawing.Size(242, 24);
            this.RC1Setting.Text = "設定";
            this.RC1Setting.Click += new System.EventHandler(this.RCsetting_Click);
            // 
            // RC1Bar1
            // 
            this.RC1Bar1.Name = "RC1Bar1";
            this.RC1Bar1.Size = new System.Drawing.Size(239, 6);
            // 
            // RC1Sites
            // 
            this.RC1Sites.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RC1Sites.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCMapUSGS,
            this.RCMapEWSC,
            this.RCThisInfo,
            this.RCTsunamiGov});
            this.RC1Sites.Name = "RC1Sites";
            this.RC1Sites.Size = new System.Drawing.Size(242, 24);
            this.RC1Sites.Text = "各種サイト";
            // 
            // RCMapUSGS
            // 
            this.RCMapUSGS.Name = "RCMapUSGS";
            this.RCMapUSGS.Size = new System.Drawing.Size(272, 26);
            this.RCMapUSGS.Text = "マップ(USGS)";
            this.RCMapUSGS.Click += new System.EventHandler(this.RCusgsmap_Click);
            // 
            // RCMapEWSC
            // 
            this.RCMapEWSC.Name = "RCMapEWSC";
            this.RCMapEWSC.Size = new System.Drawing.Size(272, 26);
            this.RCMapEWSC.Text = "マップ(EMSC)";
            this.RCMapEWSC.Click += new System.EventHandler(this.RCMapEWSC_Click);
            // 
            // RCThisInfo
            // 
            this.RCThisInfo.Name = "RCThisInfo";
            this.RCThisInfo.Size = new System.Drawing.Size(272, 26);
            this.RCThisInfo.Text = "最新の地震の詳細(USGS)";
            this.RCThisInfo.Click += new System.EventHandler(this.RCusgsthis_Click);
            // 
            // RCTsunamiGov
            // 
            this.RCTsunamiGov.Name = "RCTsunamiGov";
            this.RCTsunamiGov.Size = new System.Drawing.Size(272, 26);
            this.RCTsunamiGov.Text = "世界津波情報(tsunami.gov)";
            this.RCTsunamiGov.Click += new System.EventHandler(this.RCtsunami_Click);
            // 
            // RC1Bar2
            // 
            this.RC1Bar2.Name = "RC1Bar2";
            this.RC1Bar2.Size = new System.Drawing.Size(239, 6);
            // 
            // RC1PSInfo
            // 
            this.RC1PSInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RC1PSInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCTwitter,
            this.RCGitHub,
            this.RCiInfoPage});
            this.RC1PSInfo.Name = "RC1PSInfo";
            this.RC1PSInfo.Size = new System.Drawing.Size(242, 24);
            this.RC1PSInfo.Text = "制作者ページ/解説ページ等";
            // 
            // RCTwitter
            // 
            this.RCTwitter.Name = "RCTwitter";
            this.RCTwitter.Size = new System.Drawing.Size(206, 26);
            this.RCTwitter.Text = "Twitter";
            this.RCTwitter.Click += new System.EventHandler(this.RCtwitter_Click);
            // 
            // RCGitHub
            // 
            this.RCGitHub.Name = "RCGitHub";
            this.RCGitHub.Size = new System.Drawing.Size(206, 26);
            this.RCGitHub.Text = "GitHub(リポジトリ)";
            this.RCGitHub.Click += new System.EventHandler(this.RCgithub_Click);
            // 
            // RCiInfoPage
            // 
            this.RCiInfoPage.Name = "RCiInfoPage";
            this.RCiInfoPage.Size = new System.Drawing.Size(206, 26);
            this.RCiInfoPage.Text = "解説ページ";
            this.RCiInfoPage.Click += new System.EventHandler(this.RCinfopage_Click);
            // 
            // RC1Bar3
            // 
            this.RC1Bar3.Name = "RC1Bar3";
            this.RC1Bar3.Size = new System.Drawing.Size(239, 6);
            // 
            // RC1RebootExit
            // 
            this.RC1RebootExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RC1RebootExit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCreboot,
            this.RCexit});
            this.RC1RebootExit.Name = "RC1RebootExit";
            this.RC1RebootExit.Size = new System.Drawing.Size(242, 24);
            this.RC1RebootExit.Text = "再起動/終了";
            // 
            // RCreboot
            // 
            this.RCreboot.Name = "RCreboot";
            this.RCreboot.Size = new System.Drawing.Size(137, 26);
            this.RCreboot.Text = "再起動";
            this.RCreboot.Click += new System.EventHandler(this.RCreboot_Click);
            // 
            // RCexit
            // 
            this.RCexit.Name = "RCexit";
            this.RCexit.Size = new System.Drawing.Size(137, 26);
            this.RCexit.Text = "終了";
            this.RCexit.Click += new System.EventHandler(this.RCexit_Click);
            // 
            // USGS2
            // 
            this.USGS2.Font = new System.Drawing.Font("Koruri Regular", 11F);
            this.USGS2.Location = new System.Drawing.Point(110, 78);
            this.USGS2.Name = "USGS2";
            this.USGS2.Size = new System.Drawing.Size(50, 20);
            this.USGS2.TabIndex = 12;
            this.USGS2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // USGS3
            // 
            this.USGS3.Font = new System.Drawing.Font("Koruri Regular", 20F);
            this.USGS3.Location = new System.Drawing.Point(153, 60);
            this.USGS3.Name = "USGS3";
            this.USGS3.Size = new System.Drawing.Size(69, 38);
            this.USGS3.TabIndex = 13;
            this.USGS3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // USGS5
            // 
            this.USGS5.Font = new System.Drawing.Font("Koruri Regular", 20F);
            this.USGS5.Location = new System.Drawing.Point(314, 59);
            this.USGS5.Name = "USGS5";
            this.USGS5.Size = new System.Drawing.Size(84, 38);
            this.USGS5.TabIndex = 14;
            this.USGS5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrorText
            // 
            this.ErrorText.AutoSize = true;
            this.ErrorText.Font = new System.Drawing.Font("Koruri Regular", 12F);
            this.ErrorText.ForeColor = System.Drawing.Color.Yellow;
            this.ErrorText.Location = new System.Drawing.Point(0, 100);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(0, 28);
            this.ErrorText.TabIndex = 15;
            // 
            // MainImg
            // 
            this.MainImg.BackColor = System.Drawing.Color.Black;
            this.MainImg.Location = new System.Drawing.Point(400, 500);
            this.MainImg.Margin = new System.Windows.Forms.Padding(0);
            this.MainImg.Name = "MainImg";
            this.MainImg.Size = new System.Drawing.Size(1840, 900);
            this.MainImg.TabIndex = 0;
            this.MainImg.TabStop = false;
            // 
            // HistoryBack
            // 
            this.HistoryBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.HistoryBack.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.HistoryBack.Location = new System.Drawing.Point(400, 0);
            this.HistoryBack.Name = "HistoryBack";
            this.HistoryBack.Size = new System.Drawing.Size(400, 500);
            this.HistoryBack.TabIndex = 16;
            this.HistoryBack.Text = "履歴(2~7)";
            // 
            // History1
            // 
            this.History1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History1.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History1.Location = new System.Drawing.Point(403, 20);
            this.History1.Name = "History1";
            this.History1.Size = new System.Drawing.Size(394, 77);
            this.History1.TabIndex = 17;
            // 
            // History2
            // 
            this.History2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History2.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History2.Location = new System.Drawing.Point(403, 100);
            this.History2.Name = "History2";
            this.History2.Size = new System.Drawing.Size(394, 77);
            this.History2.TabIndex = 18;
            // 
            // History3
            // 
            this.History3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History3.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History3.Location = new System.Drawing.Point(403, 180);
            this.History3.Name = "History3";
            this.History3.Size = new System.Drawing.Size(394, 77);
            this.History3.TabIndex = 19;
            // 
            // History4
            // 
            this.History4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History4.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History4.Location = new System.Drawing.Point(403, 260);
            this.History4.Name = "History4";
            this.History4.Size = new System.Drawing.Size(394, 77);
            this.History4.TabIndex = 20;
            // 
            // History5
            // 
            this.History5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History5.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History5.Location = new System.Drawing.Point(403, 340);
            this.History5.Name = "History5";
            this.History5.Size = new System.Drawing.Size(394, 77);
            this.History5.TabIndex = 21;
            // 
            // History6
            // 
            this.History6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History6.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History6.Location = new System.Drawing.Point(403, 420);
            this.History6.Name = "History6";
            this.History6.Size = new System.Drawing.Size(394, 77);
            this.History6.TabIndex = 22;
            // 
            // RCbar3
            // 
            this.RCbar3.Name = "RCbar3";
            this.RCbar3.Size = new System.Drawing.Size(204, 6);
            // 
            // RCbar5
            // 
            this.RCbar5.Name = "RCbar5";
            this.RCbar5.Size = new System.Drawing.Size(204, 6);
            // 
            // RCopenreadme
            // 
            this.RCopenreadme.Name = "RCopenreadme";
            this.RCopenreadme.Size = new System.Drawing.Size(207, 22);
            this.RCopenreadme.Text = "readmeを見る(GitHub)";
            this.RCopenreadme.Click += new System.EventHandler(this.RCopenreadme_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.ContextMenuStrip = this.RightClick;
            this.Controls.Add(this.History6);
            this.Controls.Add(this.History5);
            this.Controls.Add(this.History4);
            this.Controls.Add(this.History3);
            this.Controls.Add(this.History2);
            this.Controls.Add(this.History1);
            this.Controls.Add(this.HistoryBack);
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.USGS4);
            this.Controls.Add(this.USGS5);
            this.Controls.Add(this.USGS2);
            this.Controls.Add(this.USGS3);
            this.Controls.Add(this.USGS6);
            this.Controls.Add(this.USGS1);
            this.Controls.Add(this.USGS0);
            this.Controls.Add(this.MainImg);
            this.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.ForeColor = System.Drawing.Color.White;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WorldQuakeViewer";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainForm_HelpButtonClicked);
            this.RightClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer JsonTimer;
        private System.Windows.Forms.PictureBox MainImg;
        private System.Windows.Forms.Label USGS0;
        private System.Windows.Forms.Label USGS1;
        private System.Windows.Forms.Label USGS6;
        private System.Windows.Forms.Label USGS4;
        private System.Windows.Forms.ContextMenuStrip RightClick;
        private System.Windows.Forms.Label USGS2;
        private System.Windows.Forms.Label USGS3;
        private System.Windows.Forms.Label USGS5;
        private System.Windows.Forms.ToolStripSeparator RC1Bar1;
        private System.Windows.Forms.ToolStripMenuItem RC1Sites;
        private System.Windows.Forms.ToolStripMenuItem RC1PSInfo;
        private System.Windows.Forms.ToolStripMenuItem RC1RebootExit;
        private System.Windows.Forms.ToolStripMenuItem RC1Setting;
        private System.Windows.Forms.ToolStripSeparator RC1Bar2;
        private System.Windows.Forms.ToolStripMenuItem RCMapUSGS;
        private System.Windows.Forms.ToolStripMenuItem RCThisInfo;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.ToolStripMenuItem RCreboot;
        private System.Windows.Forms.ToolStripMenuItem RCexit;
        private System.Windows.Forms.ToolStripMenuItem RCGitHub;
        private System.Windows.Forms.ToolStripMenuItem RCTwitter;
        private System.Windows.Forms.Label HistoryBack;
        private System.Windows.Forms.Label History1;
        private System.Windows.Forms.Label History2;
        private System.Windows.Forms.Label History3;
        private System.Windows.Forms.Label History4;
        private System.Windows.Forms.Label History5;
        private System.Windows.Forms.Label History6;
        private System.Windows.Forms.ToolStripMenuItem RCTsunamiGov;
        private System.Windows.Forms.ToolStripMenuItem RCiInfoPage;
        private System.Windows.Forms.ToolStripSeparator RC1Bar3;
        private System.Windows.Forms.ToolStripSeparator RCbar3;
        private System.Windows.Forms.ToolStripSeparator RCbar5;
        private System.Windows.Forms.ToolStripMenuItem RCopenreadme;
        private System.Windows.Forms.ToolStripMenuItem RCMapEWSC;
    }
}


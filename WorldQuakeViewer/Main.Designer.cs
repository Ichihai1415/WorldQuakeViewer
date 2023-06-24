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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.USGSget = new System.Windows.Forms.Timer(this.components);
            this.RightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RC1Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1Bar1 = new System.Windows.Forms.ToolStripSeparator();
            this.RC1CacheClear = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1ExeLogOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1Bar2 = new System.Windows.Forms.ToolStripSeparator();
            this.RC1Sites = new System.Windows.Forms.ToolStripMenuItem();
            this.RCThisInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.RCEarlyEst = new System.Windows.Forms.ToolStripMenuItem();
            this.RCMapUSGS = new System.Windows.Forms.ToolStripMenuItem();
            this.RCMapEWSC = new System.Windows.Forms.ToolStripMenuItem();
            this.RCTsunamiGov = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1TextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1IntConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1DevInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.RCTwitter = new System.Windows.Forms.ToolStripMenuItem();
            this.RCGitHub = new System.Windows.Forms.ToolStripMenuItem();
            this.RCiInfoPage = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1Bar3 = new System.Windows.Forms.ToolStripSeparator();
            this.RC1RebootExit = new System.Windows.Forms.ToolStripMenuItem();
            this.RCreboot = new System.Windows.Forms.ToolStripMenuItem();
            this.RCexit = new System.Windows.Forms.ToolStripMenuItem();
            this.ErrorText = new System.Windows.Forms.Label();
            this.RCbar3 = new System.Windows.Forms.ToolStripSeparator();
            this.RCbar5 = new System.Windows.Forms.ToolStripSeparator();
            this.ExeLogAutoDelete = new System.Windows.Forms.Timer(this.components);
            this.EMSCget = new System.Windows.Forms.Timer(this.components);
            this.RightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // USGSget
            // 
            this.USGSget.Interval = 500;
            this.USGSget.Tick += new System.EventHandler(this.USGSget_Tick);
            // 
            // RightClick
            // 
            this.RightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RC1Setting,
            this.RC1Bar1,
            this.RC1CacheClear,
            this.RC1ExeLogOpen,
            this.RC1Bar2,
            this.RC1Sites,
            this.RC1TextCopy,
            this.RC1IntConvert,
            this.RC1DevInfo,
            this.RC1Bar3,
            this.RC1RebootExit});
            this.RightClick.Name = "RightClick";
            this.RightClick.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.RightClick.Size = new System.Drawing.Size(243, 214);
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
            // RC1CacheClear
            // 
            this.RC1CacheClear.Name = "RC1CacheClear";
            this.RC1CacheClear.Size = new System.Drawing.Size(242, 24);
            this.RC1CacheClear.Text = "キャッシュクリア";
            this.RC1CacheClear.Click += new System.EventHandler(this.RC1CacheClear_Click);
            // 
            // RC1ExeLogOpen
            // 
            this.RC1ExeLogOpen.Name = "RC1ExeLogOpen";
            this.RC1ExeLogOpen.Size = new System.Drawing.Size(242, 24);
            this.RC1ExeLogOpen.Text = "動作ログ表示";
            this.RC1ExeLogOpen.Click += new System.EventHandler(this.RC1ExeLogOpen_Click);
            // 
            // RC1Bar2
            // 
            this.RC1Bar2.Name = "RC1Bar2";
            this.RC1Bar2.Size = new System.Drawing.Size(239, 6);
            // 
            // RC1Sites
            // 
            this.RC1Sites.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RC1Sites.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCThisInfo,
            this.RCEarlyEst,
            this.RCMapUSGS,
            this.RCMapEWSC,
            this.RCTsunamiGov});
            this.RC1Sites.Name = "RC1Sites";
            this.RC1Sites.Size = new System.Drawing.Size(242, 24);
            this.RC1Sites.Text = "各サイト";
            // 
            // RCThisInfo
            // 
            this.RCThisInfo.Name = "RCThisInfo";
            this.RCThisInfo.Size = new System.Drawing.Size(252, 26);
            this.RCThisInfo.Text = "最新の地震の詳細(USGS)";
            this.RCThisInfo.Click += new System.EventHandler(this.RCusgsthis_Click);
            // 
            // RCEarlyEst
            // 
            this.RCEarlyEst.Name = "RCEarlyEst";
            this.RCEarlyEst.Size = new System.Drawing.Size(252, 26);
            this.RCEarlyEst.Text = "Early-est";
            this.RCEarlyEst.Click += new System.EventHandler(this.RCEarlyEst_Click);
            // 
            // RCMapUSGS
            // 
            this.RCMapUSGS.Name = "RCMapUSGS";
            this.RCMapUSGS.Size = new System.Drawing.Size(252, 26);
            this.RCMapUSGS.Text = "USGS";
            this.RCMapUSGS.Click += new System.EventHandler(this.RCusgsmap_Click);
            // 
            // RCMapEWSC
            // 
            this.RCMapEWSC.Name = "RCMapEWSC";
            this.RCMapEWSC.Size = new System.Drawing.Size(252, 26);
            this.RCMapEWSC.Text = "EMSC";
            this.RCMapEWSC.Click += new System.EventHandler(this.RCMapEWSC_Click);
            // 
            // RCTsunamiGov
            // 
            this.RCTsunamiGov.Name = "RCTsunamiGov";
            this.RCTsunamiGov.Size = new System.Drawing.Size(252, 26);
            this.RCTsunamiGov.Text = "PTWC";
            this.RCTsunamiGov.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RCTsunamiGov.Click += new System.EventHandler(this.RCtsunami_Click);
            // 
            // RC1TextCopy
            // 
            this.RC1TextCopy.Name = "RC1TextCopy";
            this.RC1TextCopy.Size = new System.Drawing.Size(242, 24);
            this.RC1TextCopy.Text = "最新の情報をコピー";
            this.RC1TextCopy.Click += new System.EventHandler(this.RC1TextCopy_Click);
            // 
            // RC1IntConvert
            // 
            this.RC1IntConvert.Name = "RC1IntConvert";
            this.RC1IntConvert.Size = new System.Drawing.Size(242, 24);
            this.RC1IntConvert.Text = "簡易震度変換ツール";
            this.RC1IntConvert.Click += new System.EventHandler(this.RC1IntConvert_Click);
            // 
            // RC1DevInfo
            // 
            this.RC1DevInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RC1DevInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCTwitter,
            this.RCGitHub,
            this.RCiInfoPage});
            this.RC1DevInfo.Name = "RC1DevInfo";
            this.RC1DevInfo.Size = new System.Drawing.Size(242, 24);
            this.RC1DevInfo.Text = "制作者ページ/解説ページ等";
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
            // ErrorText
            // 
            this.ErrorText.AutoSize = true;
            this.ErrorText.Font = new System.Drawing.Font("Koruri Regular", 12F);
            this.ErrorText.ForeColor = System.Drawing.Color.Yellow;
            this.ErrorText.Location = new System.Drawing.Point(0, 100);
            this.ErrorText.MaximumSize = new System.Drawing.Size(400, 400);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(0, 28);
            this.ErrorText.TabIndex = 15;
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
            // ExeLogAutoDelete
            // 
            this.ExeLogAutoDelete.Enabled = true;
            this.ExeLogAutoDelete.Interval = 3600000;
            this.ExeLogAutoDelete.Tick += new System.EventHandler(this.ExeLogAutoDelete_Tick);
            // 
            // EMSCget
            // 
            this.EMSCget.Interval = 500;
            this.EMSCget.Tick += new System.EventHandler(this.EMSCget_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(798, 492);
            this.ContextMenuStrip = this.RightClick;
            this.Controls.Add(this.ErrorText);
            this.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.ForeColor = System.Drawing.Color.White;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 539);
            this.MinimumSize = new System.Drawing.Size(416, 139);
            this.Name = "MainForm";
            this.Text = "WorldQuakeViewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.RightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer USGSget;
        private System.Windows.Forms.ContextMenuStrip RightClick;
        private System.Windows.Forms.ToolStripSeparator RC1Bar1;
        private System.Windows.Forms.ToolStripMenuItem RC1Sites;
        private System.Windows.Forms.ToolStripMenuItem RC1DevInfo;
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
        private System.Windows.Forms.ToolStripMenuItem RCTsunamiGov;
        private System.Windows.Forms.ToolStripMenuItem RCiInfoPage;
        private System.Windows.Forms.ToolStripSeparator RC1Bar3;
        private System.Windows.Forms.ToolStripSeparator RCbar3;
        private System.Windows.Forms.ToolStripSeparator RCbar5;
        private System.Windows.Forms.ToolStripMenuItem RCMapEWSC;
        private System.Windows.Forms.ToolStripMenuItem RCEarlyEst;
        private System.Windows.Forms.ToolStripMenuItem RC1CacheClear;
        private System.Windows.Forms.ToolStripMenuItem RC1ExeLogOpen;
        private System.Windows.Forms.Timer ExeLogAutoDelete;
        private System.Windows.Forms.ToolStripMenuItem RC1IntConvert;
        private System.Windows.Forms.ToolStripMenuItem RC1TextCopy;
        private System.Windows.Forms.Timer EMSCget;
    }
}


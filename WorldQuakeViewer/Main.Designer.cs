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
            this.RC1IntConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1MapGenerator = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1Bar2 = new System.Windows.Forms.ToolStripSeparator();
            this.RC1CacheClear = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1ExeLogOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1Bar3 = new System.Windows.Forms.ToolStripSeparator();
            this.RC1Sites = new System.Windows.Forms.ToolStripMenuItem();
            this.RCThisEMSC = new System.Windows.Forms.ToolStripMenuItem();
            this.RCThisUSGS = new System.Windows.Forms.ToolStripMenuItem();
            this.RCMapEWSC = new System.Windows.Forms.ToolStripMenuItem();
            this.RCMapUSGS = new System.Windows.Forms.ToolStripMenuItem();
            this.RCNOAA = new System.Windows.Forms.ToolStripMenuItem();
            this.RCEarlyEst = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1DevInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.RCTwitter = new System.Windows.Forms.ToolStripMenuItem();
            this.RCiInfoPage = new System.Windows.Forms.ToolStripMenuItem();
            this.RCGitHub = new System.Windows.Forms.ToolStripMenuItem();
            this.RCSoftDiscord = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1TextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.RCTextCopyEMSC = new System.Windows.Forms.ToolStripMenuItem();
            this.RCTextCopyUSGS = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1Bar4 = new System.Windows.Forms.ToolStripSeparator();
            this.RC1Reboot = new System.Windows.Forms.ToolStripMenuItem();
            this.ErrorText = new System.Windows.Forms.Label();
            this.RCbar3 = new System.Windows.Forms.ToolStripSeparator();
            this.RCbar5 = new System.Windows.Forms.ToolStripSeparator();
            this.ExeLogAutoDelete = new System.Windows.Forms.Timer(this.components);
            this.EMSCget = new System.Windows.Forms.Timer(this.components);
            this.MainImage = new System.Windows.Forms.PictureBox();
            this.RightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // USGSget
            // 
            this.USGSget.Tick += new System.EventHandler(this.USGSget_Tick);
            // 
            // RightClick
            // 
            this.RightClick.Font = new System.Drawing.Font("Koruri Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RC1Setting,
            this.RC1Bar1,
            this.RC1IntConvert,
            this.RC1MapGenerator,
            this.RC1Bar2,
            this.RC1CacheClear,
            this.RC1ExeLogOpen,
            this.RC1Bar3,
            this.RC1Sites,
            this.RC1DevInfo,
            this.RC1TextCopy,
            this.RC1Bar4,
            this.RC1Reboot});
            this.RightClick.Name = "RightClick";
            this.RightClick.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.RightClick.Size = new System.Drawing.Size(225, 226);
            this.RightClick.TabStop = true;
            this.RightClick.Text = "メニュー";
            // 
            // RC1Setting
            // 
            this.RC1Setting.Name = "RC1Setting";
            this.RC1Setting.Size = new System.Drawing.Size(224, 22);
            this.RC1Setting.Text = "設定";
            this.RC1Setting.Click += new System.EventHandler(this.RCsetting_Click);
            // 
            // RC1Bar1
            // 
            this.RC1Bar1.Name = "RC1Bar1";
            this.RC1Bar1.Size = new System.Drawing.Size(221, 6);
            // 
            // RC1IntConvert
            // 
            this.RC1IntConvert.Name = "RC1IntConvert";
            this.RC1IntConvert.Size = new System.Drawing.Size(224, 22);
            this.RC1IntConvert.Text = "簡易震度変換ツール";
            this.RC1IntConvert.Click += new System.EventHandler(this.RC1IntConvert_Click);
            // 
            // RC1MapGenerator
            // 
            this.RC1MapGenerator.Name = "RC1MapGenerator";
            this.RC1MapGenerator.Size = new System.Drawing.Size(224, 22);
            this.RC1MapGenerator.Text = "マップ生成ツール";
            this.RC1MapGenerator.Click += new System.EventHandler(this.RC1MapGenerator_Click);
            // 
            // RC1Bar2
            // 
            this.RC1Bar2.Name = "RC1Bar2";
            this.RC1Bar2.Size = new System.Drawing.Size(221, 6);
            // 
            // RC1CacheClear
            // 
            this.RC1CacheClear.Name = "RC1CacheClear";
            this.RC1CacheClear.Size = new System.Drawing.Size(224, 22);
            this.RC1CacheClear.Text = "キャッシュクリア";
            this.RC1CacheClear.Click += new System.EventHandler(this.RC1CacheClear_Click);
            // 
            // RC1ExeLogOpen
            // 
            this.RC1ExeLogOpen.Name = "RC1ExeLogOpen";
            this.RC1ExeLogOpen.Size = new System.Drawing.Size(224, 22);
            this.RC1ExeLogOpen.Text = "動作ログ表示";
            this.RC1ExeLogOpen.Click += new System.EventHandler(this.RC1ExeLogOpen_Click);
            // 
            // RC1Bar3
            // 
            this.RC1Bar3.Name = "RC1Bar3";
            this.RC1Bar3.Size = new System.Drawing.Size(221, 6);
            // 
            // RC1Sites
            // 
            this.RC1Sites.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RC1Sites.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCThisEMSC,
            this.RCThisUSGS,
            this.RCMapEWSC,
            this.RCMapUSGS,
            this.RCNOAA,
            this.RCEarlyEst});
            this.RC1Sites.Name = "RC1Sites";
            this.RC1Sites.Size = new System.Drawing.Size(224, 22);
            this.RC1Sites.Text = "各サイト";
            // 
            // RCThisEMSC
            // 
            this.RCThisEMSC.Name = "RCThisEMSC";
            this.RCThisEMSC.Size = new System.Drawing.Size(213, 22);
            this.RCThisEMSC.Text = "最新の地震の詳細(EMSC)";
            this.RCThisEMSC.Click += new System.EventHandler(this.RCThisEMSC_Click);
            // 
            // RCThisUSGS
            // 
            this.RCThisUSGS.Name = "RCThisUSGS";
            this.RCThisUSGS.Size = new System.Drawing.Size(213, 22);
            this.RCThisUSGS.Text = "最新の地震の詳細(USGS)";
            this.RCThisUSGS.Click += new System.EventHandler(this.RCusgsthis_Click);
            // 
            // RCMapEWSC
            // 
            this.RCMapEWSC.Name = "RCMapEWSC";
            this.RCMapEWSC.Size = new System.Drawing.Size(213, 22);
            this.RCMapEWSC.Text = "EMSC";
            this.RCMapEWSC.Click += new System.EventHandler(this.RCMapEWSC_Click);
            // 
            // RCMapUSGS
            // 
            this.RCMapUSGS.Name = "RCMapUSGS";
            this.RCMapUSGS.Size = new System.Drawing.Size(213, 22);
            this.RCMapUSGS.Text = "USGS";
            this.RCMapUSGS.Click += new System.EventHandler(this.RCusgsmap_Click);
            // 
            // RCNOAA
            // 
            this.RCNOAA.Name = "RCNOAA";
            this.RCNOAA.Size = new System.Drawing.Size(213, 22);
            this.RCNOAA.Text = "NOAA";
            this.RCNOAA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RCNOAA.Click += new System.EventHandler(this.RCNOAA_Click);
            // 
            // RCEarlyEst
            // 
            this.RCEarlyEst.Name = "RCEarlyEst";
            this.RCEarlyEst.Size = new System.Drawing.Size(213, 22);
            this.RCEarlyEst.Text = "Early-est";
            this.RCEarlyEst.Click += new System.EventHandler(this.RCEarlyEst_Click);
            // 
            // RC1DevInfo
            // 
            this.RC1DevInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RC1DevInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCTwitter,
            this.RCiInfoPage,
            this.RCGitHub,
            this.RCSoftDiscord});
            this.RC1DevInfo.Name = "RC1DevInfo";
            this.RC1DevInfo.Size = new System.Drawing.Size(224, 22);
            this.RC1DevInfo.Text = "制作者ページ/解説ページ等";
            // 
            // RCTwitter
            // 
            this.RCTwitter.Name = "RCTwitter";
            this.RCTwitter.Size = new System.Drawing.Size(183, 22);
            this.RCTwitter.Text = "Twitter";
            this.RCTwitter.Click += new System.EventHandler(this.RCtwitter_Click);
            // 
            // RCiInfoPage
            // 
            this.RCiInfoPage.Name = "RCiInfoPage";
            this.RCiInfoPage.Size = new System.Drawing.Size(183, 22);
            this.RCiInfoPage.Text = "解説ページ";
            this.RCiInfoPage.Click += new System.EventHandler(this.RCinfopage_Click);
            // 
            // RCGitHub
            // 
            this.RCGitHub.Name = "RCGitHub";
            this.RCGitHub.Size = new System.Drawing.Size(183, 22);
            this.RCGitHub.Text = "GitHub(リポジトリ)";
            this.RCGitHub.Click += new System.EventHandler(this.RCgithub_Click);
            // 
            // RCSoftDiscord
            // 
            this.RCSoftDiscord.Name = "RCSoftDiscord";
            this.RCSoftDiscord.Size = new System.Drawing.Size(183, 22);
            this.RCSoftDiscord.Text = "ソフト情報Discord";
            this.RCSoftDiscord.Click += new System.EventHandler(this.RCSoftDiscord_Click);
            // 
            // RC1TextCopy
            // 
            this.RC1TextCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCTextCopyEMSC,
            this.RCTextCopyUSGS});
            this.RC1TextCopy.Name = "RC1TextCopy";
            this.RC1TextCopy.Size = new System.Drawing.Size(224, 22);
            this.RC1TextCopy.Text = "最新の情報をコピー";
            // 
            // RCTextCopyEMSC
            // 
            this.RCTextCopyEMSC.Name = "RCTextCopyEMSC";
            this.RCTextCopyEMSC.Size = new System.Drawing.Size(109, 22);
            this.RCTextCopyEMSC.Text = "EMSC";
            this.RCTextCopyEMSC.Click += new System.EventHandler(this.RCTextCopyEMSC_Click);
            // 
            // RCTextCopyUSGS
            // 
            this.RCTextCopyUSGS.Name = "RCTextCopyUSGS";
            this.RCTextCopyUSGS.Size = new System.Drawing.Size(109, 22);
            this.RCTextCopyUSGS.Text = "USGS";
            this.RCTextCopyUSGS.Click += new System.EventHandler(this.RCTextCopyUSGS_Click);
            // 
            // RC1Bar4
            // 
            this.RC1Bar4.Name = "RC1Bar4";
            this.RC1Bar4.Size = new System.Drawing.Size(221, 6);
            // 
            // RC1Reboot
            // 
            this.RC1Reboot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RC1Reboot.Name = "RC1Reboot";
            this.RC1Reboot.Size = new System.Drawing.Size(224, 22);
            this.RC1Reboot.Text = "再起動";
            this.RC1Reboot.Click += new System.EventHandler(this.RC1Reboot_Click);
            // 
            // ErrorText
            // 
            this.ErrorText.AutoSize = true;
            this.ErrorText.Font = new System.Drawing.Font("Koruri Regular", 12F);
            this.ErrorText.ForeColor = System.Drawing.Color.Yellow;
            this.ErrorText.Location = new System.Drawing.Point(1, 101);
            this.ErrorText.MaximumSize = new System.Drawing.Size(398, 398);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(0, 22);
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
            this.EMSCget.Tick += new System.EventHandler(this.EMSCget_Tick);
            // 
            // MainImage
            // 
            this.MainImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainImage.Image = global::WorldQuakeViewer.Properties.Resources.Back;
            this.MainImage.Location = new System.Drawing.Point(0, 0);
            this.MainImage.Name = "MainImage";
            this.MainImage.Size = new System.Drawing.Size(800, 500);
            this.MainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MainImage.TabIndex = 16;
            this.MainImage.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(798, 492);
            this.ContextMenuStrip = this.RightClick;
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.MainImage);
            this.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.ForeColor = System.Drawing.Color.White;
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
            ((System.ComponentModel.ISupportInitialize)(this.MainImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer USGSget;
        private System.Windows.Forms.ContextMenuStrip RightClick;
        private System.Windows.Forms.ToolStripSeparator RC1Bar1;
        private System.Windows.Forms.ToolStripMenuItem RC1Sites;
        private System.Windows.Forms.ToolStripMenuItem RC1DevInfo;
        private System.Windows.Forms.ToolStripMenuItem RC1Reboot;
        private System.Windows.Forms.ToolStripMenuItem RC1Setting;
        private System.Windows.Forms.ToolStripSeparator RC1Bar2;
        private System.Windows.Forms.ToolStripMenuItem RCMapUSGS;
        private System.Windows.Forms.ToolStripMenuItem RCThisUSGS;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.ToolStripMenuItem RCGitHub;
        private System.Windows.Forms.ToolStripMenuItem RCTwitter;
        private System.Windows.Forms.ToolStripMenuItem RCNOAA;
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
        private System.Windows.Forms.PictureBox MainImage;
        private System.Windows.Forms.ToolStripMenuItem RCTextCopyEMSC;
        private System.Windows.Forms.ToolStripMenuItem RCTextCopyUSGS;
        private System.Windows.Forms.ToolStripSeparator RC1Bar4;
        private System.Windows.Forms.ToolStripMenuItem RC1MapGenerator;
        private System.Windows.Forms.ToolStripMenuItem RCSoftDiscord;
        private System.Windows.Forms.ToolStripMenuItem RCThisEMSC;
    }
}


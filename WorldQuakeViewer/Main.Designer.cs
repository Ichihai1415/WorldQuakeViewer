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
            this.JsonTimer = new System.Windows.Forms.Timer(this.components);
            this.USGS0 = new System.Windows.Forms.Label();
            this.USGS1 = new System.Windows.Forms.Label();
            this.USGS6 = new System.Windows.Forms.Label();
            this.USGS4 = new System.Windows.Forms.Label();
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
            this.RC1IntConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.RC1DevInfo = new System.Windows.Forms.ToolStripMenuItem();
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
            this.HistoryBack = new System.Windows.Forms.Label();
            this.History10 = new System.Windows.Forms.Label();
            this.History20 = new System.Windows.Forms.Label();
            this.History30 = new System.Windows.Forms.Label();
            this.History40 = new System.Windows.Forms.Label();
            this.History50 = new System.Windows.Forms.Label();
            this.History60 = new System.Windows.Forms.Label();
            this.RCbar3 = new System.Windows.Forms.ToolStripSeparator();
            this.RCbar5 = new System.Windows.Forms.ToolStripSeparator();
            this.MainImg = new System.Windows.Forms.PictureBox();
            this.History11 = new System.Windows.Forms.Label();
            this.History21 = new System.Windows.Forms.Label();
            this.History31 = new System.Windows.Forms.Label();
            this.History41 = new System.Windows.Forms.Label();
            this.History51 = new System.Windows.Forms.Label();
            this.History61 = new System.Windows.Forms.Label();
            this.History12 = new System.Windows.Forms.Label();
            this.History13 = new System.Windows.Forms.Label();
            this.History22 = new System.Windows.Forms.Label();
            this.History32 = new System.Windows.Forms.Label();
            this.History42 = new System.Windows.Forms.Label();
            this.History52 = new System.Windows.Forms.Label();
            this.History62 = new System.Windows.Forms.Label();
            this.History23 = new System.Windows.Forms.Label();
            this.History33 = new System.Windows.Forms.Label();
            this.History43 = new System.Windows.Forms.Label();
            this.History53 = new System.Windows.Forms.Label();
            this.History63 = new System.Windows.Forms.Label();
            this.ExeLogAutoDelete = new System.Windows.Forms.Timer(this.components);
            this.USGS01 = new System.Windows.Forms.Label();
            this.RightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainImg)).BeginInit();
            this.SuspendLayout();
            // 
            // JsonTimer
            // 
            this.JsonTimer.Interval = 1000;
            this.JsonTimer.Tick += new System.EventHandler(this.JsonTimer_Tick);
            // 
            // USGS0
            // 
            this.USGS0.BackColor = System.Drawing.Color.Black;
            this.USGS0.Font = new System.Drawing.Font("Koruri Regular", 9F);
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
            this.USGS1.Location = new System.Drawing.Point(2, 17);
            this.USGS1.Margin = new System.Windows.Forms.Padding(0);
            this.USGS1.Name = "USGS1";
            this.USGS1.Size = new System.Drawing.Size(798, 81);
            this.USGS1.TabIndex = 2;
            // 
            // USGS6
            // 
            this.USGS6.AutoSize = true;
            this.USGS6.Font = new System.Drawing.Font("Koruri Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.USGS6.Location = new System.Drawing.Point(259, 432);
            this.USGS6.Name = "USGS6";
            this.USGS6.Size = new System.Drawing.Size(0, 17);
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
            this.RC1CacheClear,
            this.RC1ExeLogOpen,
            this.RC1Bar2,
            this.RC1Sites,
            this.RC1IntConvert,
            this.RC1DevInfo,
            this.RC1Bar3,
            this.RC1RebootExit});
            this.RightClick.Name = "RightClick";
            this.RightClick.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.RightClick.Size = new System.Drawing.Size(208, 176);
            this.RightClick.TabStop = true;
            this.RightClick.Text = "メニュー";
            // 
            // RC1Setting
            // 
            this.RC1Setting.Name = "RC1Setting";
            this.RC1Setting.Size = new System.Drawing.Size(207, 22);
            this.RC1Setting.Text = "設定";
            this.RC1Setting.Click += new System.EventHandler(this.RCsetting_Click);
            // 
            // RC1Bar1
            // 
            this.RC1Bar1.Name = "RC1Bar1";
            this.RC1Bar1.Size = new System.Drawing.Size(204, 6);
            // 
            // RC1CacheClear
            // 
            this.RC1CacheClear.Name = "RC1CacheClear";
            this.RC1CacheClear.Size = new System.Drawing.Size(207, 22);
            this.RC1CacheClear.Text = "キャッシュクリア";
            this.RC1CacheClear.Click += new System.EventHandler(this.RC1CacheClear_Click);
            // 
            // RC1ExeLogOpen
            // 
            this.RC1ExeLogOpen.Name = "RC1ExeLogOpen";
            this.RC1ExeLogOpen.Size = new System.Drawing.Size(207, 22);
            this.RC1ExeLogOpen.Text = "動作ログ表示";
            this.RC1ExeLogOpen.Click += new System.EventHandler(this.RC1ExeLogOpen_Click);
            // 
            // RC1Bar2
            // 
            this.RC1Bar2.Name = "RC1Bar2";
            this.RC1Bar2.Size = new System.Drawing.Size(204, 6);
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
            this.RC1Sites.Size = new System.Drawing.Size(207, 22);
            this.RC1Sites.Text = "各サイト";
            // 
            // RCThisInfo
            // 
            this.RCThisInfo.Name = "RCThisInfo";
            this.RCThisInfo.Size = new System.Drawing.Size(202, 22);
            this.RCThisInfo.Text = "最新の地震の詳細(USGS)";
            this.RCThisInfo.Click += new System.EventHandler(this.RCusgsthis_Click);
            // 
            // RCEarlyEst
            // 
            this.RCEarlyEst.Name = "RCEarlyEst";
            this.RCEarlyEst.Size = new System.Drawing.Size(202, 22);
            this.RCEarlyEst.Text = "Early-est";
            this.RCEarlyEst.Click += new System.EventHandler(this.RCEarlyEst_Click);
            // 
            // RCMapUSGS
            // 
            this.RCMapUSGS.Name = "RCMapUSGS";
            this.RCMapUSGS.Size = new System.Drawing.Size(202, 22);
            this.RCMapUSGS.Text = "USGS";
            this.RCMapUSGS.Click += new System.EventHandler(this.RCusgsmap_Click);
            // 
            // RCMapEWSC
            // 
            this.RCMapEWSC.Name = "RCMapEWSC";
            this.RCMapEWSC.Size = new System.Drawing.Size(202, 22);
            this.RCMapEWSC.Text = "EMSC";
            this.RCMapEWSC.Click += new System.EventHandler(this.RCMapEWSC_Click);
            // 
            // RCTsunamiGov
            // 
            this.RCTsunamiGov.Name = "RCTsunamiGov";
            this.RCTsunamiGov.Size = new System.Drawing.Size(202, 22);
            this.RCTsunamiGov.Text = "PTWC(tsunami.gov)";
            this.RCTsunamiGov.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RCTsunamiGov.Click += new System.EventHandler(this.RCtsunami_Click);
            // 
            // RC1IntConvert
            // 
            this.RC1IntConvert.Name = "RC1IntConvert";
            this.RC1IntConvert.Size = new System.Drawing.Size(207, 22);
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
            this.RC1DevInfo.Size = new System.Drawing.Size(207, 22);
            this.RC1DevInfo.Text = "制作者ページ/解説ページ等";
            // 
            // RCTwitter
            // 
            this.RCTwitter.Name = "RCTwitter";
            this.RCTwitter.Size = new System.Drawing.Size(164, 22);
            this.RCTwitter.Text = "Twitter";
            this.RCTwitter.Click += new System.EventHandler(this.RCtwitter_Click);
            // 
            // RCGitHub
            // 
            this.RCGitHub.Name = "RCGitHub";
            this.RCGitHub.Size = new System.Drawing.Size(164, 22);
            this.RCGitHub.Text = "GitHub(リポジトリ)";
            this.RCGitHub.Click += new System.EventHandler(this.RCgithub_Click);
            // 
            // RCiInfoPage
            // 
            this.RCiInfoPage.Name = "RCiInfoPage";
            this.RCiInfoPage.Size = new System.Drawing.Size(164, 22);
            this.RCiInfoPage.Text = "解説ページ";
            this.RCiInfoPage.Click += new System.EventHandler(this.RCinfopage_Click);
            // 
            // RC1Bar3
            // 
            this.RC1Bar3.Name = "RC1Bar3";
            this.RC1Bar3.Size = new System.Drawing.Size(204, 6);
            // 
            // RC1RebootExit
            // 
            this.RC1RebootExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RC1RebootExit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCreboot,
            this.RCexit});
            this.RC1RebootExit.Name = "RC1RebootExit";
            this.RC1RebootExit.Size = new System.Drawing.Size(207, 22);
            this.RC1RebootExit.Text = "再起動/終了";
            // 
            // RCreboot
            // 
            this.RCreboot.Name = "RCreboot";
            this.RCreboot.Size = new System.Drawing.Size(110, 22);
            this.RCreboot.Text = "再起動";
            this.RCreboot.Click += new System.EventHandler(this.RCreboot_Click);
            // 
            // RCexit
            // 
            this.RCexit.Name = "RCexit";
            this.RCexit.Size = new System.Drawing.Size(110, 22);
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
            this.ErrorText.MaximumSize = new System.Drawing.Size(400, 400);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(0, 22);
            this.ErrorText.TabIndex = 15;
            // 
            // HistoryBack
            // 
            this.HistoryBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.HistoryBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HistoryBack.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.HistoryBack.Location = new System.Drawing.Point(400, 0);
            this.HistoryBack.Name = "HistoryBack";
            this.HistoryBack.Size = new System.Drawing.Size(400, 500);
            this.HistoryBack.TabIndex = 16;
            this.HistoryBack.Text = "履歴";
            // 
            // History10
            // 
            this.History10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History10.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History10.Location = new System.Drawing.Point(403, 20);
            this.History10.Name = "History10";
            this.History10.Size = new System.Drawing.Size(394, 77);
            this.History10.TabIndex = 17;
            // 
            // History20
            // 
            this.History20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History20.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History20.Location = new System.Drawing.Point(403, 100);
            this.History20.Name = "History20";
            this.History20.Size = new System.Drawing.Size(394, 77);
            this.History20.TabIndex = 18;
            // 
            // History30
            // 
            this.History30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History30.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History30.Location = new System.Drawing.Point(403, 180);
            this.History30.Name = "History30";
            this.History30.Size = new System.Drawing.Size(394, 77);
            this.History30.TabIndex = 19;
            // 
            // History40
            // 
            this.History40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History40.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History40.Location = new System.Drawing.Point(403, 260);
            this.History40.Name = "History40";
            this.History40.Size = new System.Drawing.Size(394, 77);
            this.History40.TabIndex = 20;
            // 
            // History50
            // 
            this.History50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History50.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History50.Location = new System.Drawing.Point(403, 340);
            this.History50.Name = "History50";
            this.History50.Size = new System.Drawing.Size(394, 77);
            this.History50.TabIndex = 21;
            // 
            // History60
            // 
            this.History60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History60.Font = new System.Drawing.Font("Koruri Regular", 10.5F);
            this.History60.Location = new System.Drawing.Point(403, 420);
            this.History60.Name = "History60";
            this.History60.Size = new System.Drawing.Size(394, 77);
            this.History60.TabIndex = 22;
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
            // MainImg
            // 
            this.MainImg.BackColor = System.Drawing.Color.Black;
            this.MainImg.Location = new System.Drawing.Point(400, 500);
            this.MainImg.Margin = new System.Windows.Forms.Padding(0);
            this.MainImg.Name = "MainImg";
            this.MainImg.Size = new System.Drawing.Size(2500, 900);
            this.MainImg.TabIndex = 0;
            this.MainImg.TabStop = false;
            // 
            // History11
            // 
            this.History11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History11.Font = new System.Drawing.Font("Koruri Regular", 9.5F);
            this.History11.Location = new System.Drawing.Point(406, 22);
            this.History11.Name = "History11";
            this.History11.Size = new System.Drawing.Size(388, 73);
            this.History11.TabIndex = 23;
            // 
            // History21
            // 
            this.History21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History21.Font = new System.Drawing.Font("Koruri Regular", 9.5F);
            this.History21.Location = new System.Drawing.Point(406, 102);
            this.History21.Name = "History21";
            this.History21.Size = new System.Drawing.Size(388, 73);
            this.History21.TabIndex = 24;
            // 
            // History31
            // 
            this.History31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History31.Font = new System.Drawing.Font("Koruri Regular", 9.5F);
            this.History31.Location = new System.Drawing.Point(406, 182);
            this.History31.Name = "History31";
            this.History31.Size = new System.Drawing.Size(388, 73);
            this.History31.TabIndex = 25;
            // 
            // History41
            // 
            this.History41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History41.Font = new System.Drawing.Font("Koruri Regular", 9.5F);
            this.History41.Location = new System.Drawing.Point(406, 262);
            this.History41.Name = "History41";
            this.History41.Size = new System.Drawing.Size(388, 73);
            this.History41.TabIndex = 26;
            // 
            // History51
            // 
            this.History51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History51.Font = new System.Drawing.Font("Koruri Regular", 9.5F);
            this.History51.Location = new System.Drawing.Point(406, 342);
            this.History51.Name = "History51";
            this.History51.Size = new System.Drawing.Size(388, 73);
            this.History51.TabIndex = 27;
            // 
            // History61
            // 
            this.History61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History61.Font = new System.Drawing.Font("Koruri Regular", 9.5F);
            this.History61.Location = new System.Drawing.Point(406, 422);
            this.History61.Name = "History61";
            this.History61.Size = new System.Drawing.Size(388, 73);
            this.History61.TabIndex = 28;
            // 
            // History12
            // 
            this.History12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History12.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.History12.Location = new System.Drawing.Point(672, 75);
            this.History12.Name = "History12";
            this.History12.Size = new System.Drawing.Size(50, 20);
            this.History12.TabIndex = 29;
            this.History12.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // History13
            // 
            this.History13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History13.Font = new System.Drawing.Font("Koruri Regular", 22F);
            this.History13.Location = new System.Drawing.Point(717, 57);
            this.History13.Name = "History13";
            this.History13.Size = new System.Drawing.Size(77, 38);
            this.History13.TabIndex = 30;
            this.History13.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // History22
            // 
            this.History22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History22.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.History22.Location = new System.Drawing.Point(672, 155);
            this.History22.Name = "History22";
            this.History22.Size = new System.Drawing.Size(50, 20);
            this.History22.TabIndex = 31;
            this.History22.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // History32
            // 
            this.History32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History32.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.History32.Location = new System.Drawing.Point(672, 235);
            this.History32.Name = "History32";
            this.History32.Size = new System.Drawing.Size(50, 20);
            this.History32.TabIndex = 32;
            this.History32.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // History42
            // 
            this.History42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History42.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.History42.Location = new System.Drawing.Point(672, 315);
            this.History42.Name = "History42";
            this.History42.Size = new System.Drawing.Size(50, 20);
            this.History42.TabIndex = 33;
            this.History42.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // History52
            // 
            this.History52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History52.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.History52.Location = new System.Drawing.Point(672, 395);
            this.History52.Name = "History52";
            this.History52.Size = new System.Drawing.Size(50, 20);
            this.History52.TabIndex = 34;
            this.History52.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // History62
            // 
            this.History62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History62.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.History62.Location = new System.Drawing.Point(672, 475);
            this.History62.Name = "History62";
            this.History62.Size = new System.Drawing.Size(50, 20);
            this.History62.TabIndex = 35;
            this.History62.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // History23
            // 
            this.History23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History23.Font = new System.Drawing.Font("Koruri Regular", 22F);
            this.History23.Location = new System.Drawing.Point(717, 137);
            this.History23.Name = "History23";
            this.History23.Size = new System.Drawing.Size(77, 38);
            this.History23.TabIndex = 36;
            this.History23.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // History33
            // 
            this.History33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History33.Font = new System.Drawing.Font("Koruri Regular", 22F);
            this.History33.Location = new System.Drawing.Point(717, 217);
            this.History33.Name = "History33";
            this.History33.Size = new System.Drawing.Size(77, 38);
            this.History33.TabIndex = 37;
            this.History33.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // History43
            // 
            this.History43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History43.Font = new System.Drawing.Font("Koruri Regular", 22F);
            this.History43.Location = new System.Drawing.Point(717, 297);
            this.History43.Name = "History43";
            this.History43.Size = new System.Drawing.Size(77, 38);
            this.History43.TabIndex = 38;
            this.History43.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // History53
            // 
            this.History53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History53.Font = new System.Drawing.Font("Koruri Regular", 22F);
            this.History53.Location = new System.Drawing.Point(717, 377);
            this.History53.Name = "History53";
            this.History53.Size = new System.Drawing.Size(77, 38);
            this.History53.TabIndex = 39;
            this.History53.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // History63
            // 
            this.History63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.History63.Font = new System.Drawing.Font("Koruri Regular", 22F);
            this.History63.Location = new System.Drawing.Point(717, 457);
            this.History63.Name = "History63";
            this.History63.Size = new System.Drawing.Size(77, 38);
            this.History63.TabIndex = 40;
            this.History63.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ExeLogAutoDelete
            // 
            this.ExeLogAutoDelete.Enabled = true;
            this.ExeLogAutoDelete.Interval = 3600000;
            this.ExeLogAutoDelete.Tick += new System.EventHandler(this.ExeLogAutoDelete_Tick);
            // 
            // USGS01
            // 
            this.USGS01.BackColor = System.Drawing.Color.Black;
            this.USGS01.Font = new System.Drawing.Font("Koruri Regular", 11F);
            this.USGS01.Location = new System.Drawing.Point(398, 17);
            this.USGS01.Margin = new System.Windows.Forms.Padding(0);
            this.USGS01.Name = "USGS01";
            this.USGS01.Size = new System.Drawing.Size(2, 81);
            this.USGS01.TabIndex = 41;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(798, 492);
            this.ContextMenuStrip = this.RightClick;
            this.Controls.Add(this.USGS01);
            this.Controls.Add(this.History63);
            this.Controls.Add(this.History53);
            this.Controls.Add(this.History43);
            this.Controls.Add(this.History33);
            this.Controls.Add(this.History23);
            this.Controls.Add(this.History62);
            this.Controls.Add(this.History52);
            this.Controls.Add(this.History42);
            this.Controls.Add(this.History32);
            this.Controls.Add(this.History22);
            this.Controls.Add(this.History13);
            this.Controls.Add(this.History12);
            this.Controls.Add(this.History61);
            this.Controls.Add(this.History51);
            this.Controls.Add(this.History41);
            this.Controls.Add(this.History31);
            this.Controls.Add(this.History21);
            this.Controls.Add(this.History11);
            this.Controls.Add(this.History60);
            this.Controls.Add(this.History50);
            this.Controls.Add(this.History40);
            this.Controls.Add(this.History30);
            this.Controls.Add(this.History20);
            this.Controls.Add(this.History10);
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
        private System.Windows.Forms.Label HistoryBack;
        private System.Windows.Forms.Label History10;
        private System.Windows.Forms.Label History20;
        private System.Windows.Forms.Label History30;
        private System.Windows.Forms.Label History40;
        private System.Windows.Forms.Label History50;
        private System.Windows.Forms.Label History60;
        private System.Windows.Forms.ToolStripMenuItem RCTsunamiGov;
        private System.Windows.Forms.ToolStripMenuItem RCiInfoPage;
        private System.Windows.Forms.ToolStripSeparator RC1Bar3;
        private System.Windows.Forms.ToolStripSeparator RCbar3;
        private System.Windows.Forms.ToolStripSeparator RCbar5;
        private System.Windows.Forms.ToolStripMenuItem RCMapEWSC;
        private System.Windows.Forms.ToolStripMenuItem RCEarlyEst;
        private System.Windows.Forms.Label History11;
        private System.Windows.Forms.Label History21;
        private System.Windows.Forms.Label History31;
        private System.Windows.Forms.Label History41;
        private System.Windows.Forms.Label History51;
        private System.Windows.Forms.Label History61;
        private System.Windows.Forms.Label History12;
        private System.Windows.Forms.Label History13;
        private System.Windows.Forms.Label History22;
        private System.Windows.Forms.Label History32;
        private System.Windows.Forms.Label History42;
        private System.Windows.Forms.Label History52;
        private System.Windows.Forms.Label History62;
        private System.Windows.Forms.Label History23;
        private System.Windows.Forms.Label History33;
        private System.Windows.Forms.Label History43;
        private System.Windows.Forms.Label History53;
        private System.Windows.Forms.Label History63;
        private System.Windows.Forms.ToolStripMenuItem RC1CacheClear;
        private System.Windows.Forms.ToolStripMenuItem RC1ExeLogOpen;
        private System.Windows.Forms.Timer ExeLogAutoDelete;
        private System.Windows.Forms.ToolStripMenuItem RC1IntConvert;
        private System.Windows.Forms.Label USGS01;
    }
}


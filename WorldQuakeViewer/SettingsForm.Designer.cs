namespace WorldQuakeViewer
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.SettingSave = new System.Windows.Forms.Button();
            this.SettingReset = new System.Windows.Forms.Button();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Tab_Info = new System.Windows.Forms.TabPage();
            this.LinkMap = new System.Windows.Forms.LinkLabel();
            this.LinkOtoLogic = new System.Windows.Forms.LinkLabel();
            this.LinkKoruri = new System.Windows.Forms.LinkLabel();
            this.LinkJMA = new System.Windows.Forms.LinkLabel();
            this.LinkFE = new System.Windows.Forms.LinkLabel();
            this.LinkUSGS = new System.Windows.Forms.LinkLabel();
            this.Tab_Info_Text = new System.Windows.Forms.Label();
            this.Version = new System.Windows.Forms.Label();
            this.Tab_View = new System.Windows.Forms.TabPage();
            this.Tab_View_LogTime = new System.Windows.Forms.NumericUpDown();
            this.Tab_View_LogEnable = new System.Windows.Forms.CheckBox();
            this.Tab_View_Text = new System.Windows.Forms.Label();
            this.Tab_View_LatLonDecimal = new System.Windows.Forms.CheckBox();
            this.Tab_View_HideMap = new System.Windows.Forms.CheckBox();
            this.Tab_View_HideHist = new System.Windows.Forms.CheckBox();
            this.Tab_Update = new System.Windows.Forms.TabPage();
            this.Tab_Update_Time = new System.Windows.Forms.CheckBox();
            this.Tab_Update_Alert = new System.Windows.Forms.CheckBox();
            this.Tab_Update_MMI = new System.Windows.Forms.CheckBox();
            this.Tab_Update_Mag = new System.Windows.Forms.CheckBox();
            this.Tab_Update_MagType = new System.Windows.Forms.CheckBox();
            this.Tab_Update_Depth = new System.Windows.Forms.CheckBox();
            this.Tab_Update_LatLon = new System.Windows.Forms.CheckBox();
            this.Tab_Update_HypoEN = new System.Windows.Forms.CheckBox();
            this.Tab_Update_HypoJP = new System.Windows.Forms.CheckBox();
            this.Tab_Update_Text = new System.Windows.Forms.Label();
            this.Tab_Sound = new System.Windows.Forms.TabPage();
            this.Tab_Sound_Test_M80u = new System.Windows.Forms.Button();
            this.Tab_Sound_Test_M60u = new System.Windows.Forms.Button();
            this.Tab_Sound_Test_M45u = new System.Windows.Forms.Button();
            this.Tab_Sound_Test_M80 = new System.Windows.Forms.Button();
            this.Tab_Sound_Test_M60 = new System.Windows.Forms.Button();
            this.Tab_Sound_Test_M45 = new System.Windows.Forms.Button();
            this.Tab_Sound_Updt = new System.Windows.Forms.CheckBox();
            this.Tab_Sound_M80 = new System.Windows.Forms.CheckBox();
            this.Tab_Sound_M60 = new System.Windows.Forms.CheckBox();
            this.Tab_Sound_M45 = new System.Windows.Forms.CheckBox();
            this.Tab_Sound_Text = new System.Windows.Forms.Label();
            this.Tab_Yomi = new System.Windows.Forms.TabPage();
            this.Tab_Yomi_Text2 = new System.Windows.Forms.Label();
            this.Tab_Yomi_Voice = new System.Windows.Forms.NumericUpDown();
            this.Tab_Yomi_LowerAnd = new System.Windows.Forms.RadioButton();
            this.Tab_Yomi_LowerOr = new System.Windows.Forms.RadioButton();
            this.Tab_Yomi_LowerMMI = new System.Windows.Forms.NumericUpDown();
            this.Tab_Yomi_LowerMag = new System.Windows.Forms.NumericUpDown();
            this.Tab_Yomi_Port = new System.Windows.Forms.NumericUpDown();
            this.Tab_Yomi_Host = new System.Windows.Forms.TextBox();
            this.Tab_Yomi_Test = new System.Windows.Forms.Button();
            this.Tab_Yomi_Volume = new System.Windows.Forms.NumericUpDown();
            this.Tab_Yomi_Tone = new System.Windows.Forms.NumericUpDown();
            this.Tab_Yomi_Speed = new System.Windows.Forms.NumericUpDown();
            this.Tab_Yomi_Enable = new System.Windows.Forms.CheckBox();
            this.Tab_Yomi_Text = new System.Windows.Forms.Label();
            this.Tab_Tweet = new System.Windows.Forms.TabPage();
            this.Tab_Tweet_Test = new System.Windows.Forms.Button();
            this.Tab_Tweet_Text2 = new System.Windows.Forms.Label();
            this.Tab_Tweet_ViewToken = new System.Windows.Forms.CheckBox();
            this.Tab_Tweet_LowerMMI = new System.Windows.Forms.NumericUpDown();
            this.Tab_Tweet_LowerMag = new System.Windows.Forms.NumericUpDown();
            this.Tab_Tweet_LowerAnd = new System.Windows.Forms.RadioButton();
            this.Tab_Tweet_LowerOr = new System.Windows.Forms.RadioButton();
            this.Tab_Tweet_Text3 = new System.Windows.Forms.Label();
            this.Tab_Tweet_AccSec = new System.Windows.Forms.TextBox();
            this.Tab_Tweet_AccTok = new System.Windows.Forms.TextBox();
            this.Tab_Tweet_ConSec = new System.Windows.Forms.TextBox();
            this.Tab_Tweet_ConKey = new System.Windows.Forms.TextBox();
            this.Tab_Tweet_Enable = new System.Windows.Forms.CheckBox();
            this.Tab_Tweet_Text = new System.Windows.Forms.Label();
            this.Tab_Socket = new System.Windows.Forms.TabPage();
            this.Tab_Socket_Test = new System.Windows.Forms.Button();
            this.Tab_Socket_Enable = new System.Windows.Forms.CheckBox();
            this.Tab_Socket_TextFormat = new System.Windows.Forms.TextBox();
            this.Tab_Socket_Port = new System.Windows.Forms.NumericUpDown();
            this.Tab_Socket_Host = new System.Windows.Forms.TextBox();
            this.Tab_Socket_Text = new System.Windows.Forms.Label();
            this.Tab_ProInfo = new System.Windows.Forms.TabPage();
            this.Tab_ProInfo_Text = new System.Windows.Forms.Label();
            this.ProInfoChange = new System.Windows.Forms.Timer(this.components);
            this.Tabs.SuspendLayout();
            this.Tab_Info.SuspendLayout();
            this.Tab_View.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_View_LogTime)).BeginInit();
            this.Tab_Update.SuspendLayout();
            this.Tab_Sound.SuspendLayout();
            this.Tab_Yomi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_Voice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_LowerMMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_LowerMag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_Port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_Volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_Tone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_Speed)).BeginInit();
            this.Tab_Tweet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Tweet_LowerMMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Tweet_LowerMag)).BeginInit();
            this.Tab_Socket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Socket_Port)).BeginInit();
            this.Tab_ProInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingSave
            // 
            this.SettingSave.Location = new System.Drawing.Point(85, 320);
            this.SettingSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SettingSave.Name = "SettingSave";
            this.SettingSave.Size = new System.Drawing.Size(100, 30);
            this.SettingSave.TabIndex = 1;
            this.SettingSave.Text = "保存";
            this.SettingSave.UseVisualStyleBackColor = true;
            this.SettingSave.Click += new System.EventHandler(this.SettingSave_Click);
            // 
            // SettingReset
            // 
            this.SettingReset.Location = new System.Drawing.Point(455, 320);
            this.SettingReset.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SettingReset.Name = "SettingReset";
            this.SettingReset.Size = new System.Drawing.Size(100, 30);
            this.SettingReset.TabIndex = 2;
            this.SettingReset.Text = "リセット";
            this.SettingReset.UseVisualStyleBackColor = true;
            this.SettingReset.Click += new System.EventHandler(this.SettingReset_Click);
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.Tab_Info);
            this.Tabs.Controls.Add(this.Tab_View);
            this.Tabs.Controls.Add(this.Tab_Update);
            this.Tabs.Controls.Add(this.Tab_Sound);
            this.Tabs.Controls.Add(this.Tab_Yomi);
            this.Tabs.Controls.Add(this.Tab_Tweet);
            this.Tabs.Controls.Add(this.Tab_Socket);
            this.Tabs.Controls.Add(this.Tab_ProInfo);
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(640, 310);
            this.Tabs.TabIndex = 4;
            // 
            // Tab_Info
            // 
            this.Tab_Info.BackColor = System.Drawing.Color.Transparent;
            this.Tab_Info.Controls.Add(this.LinkMap);
            this.Tab_Info.Controls.Add(this.LinkOtoLogic);
            this.Tab_Info.Controls.Add(this.LinkKoruri);
            this.Tab_Info.Controls.Add(this.LinkJMA);
            this.Tab_Info.Controls.Add(this.LinkFE);
            this.Tab_Info.Controls.Add(this.LinkUSGS);
            this.Tab_Info.Controls.Add(this.Tab_Info_Text);
            this.Tab_Info.Controls.Add(this.Version);
            this.Tab_Info.Location = new System.Drawing.Point(4, 31);
            this.Tab_Info.Name = "Tab_Info";
            this.Tab_Info.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Info.Size = new System.Drawing.Size(632, 275);
            this.Tab_Info.TabIndex = 0;
            this.Tab_Info.Text = "情報";
            // 
            // LinkMap
            // 
            this.LinkMap.AutoSize = true;
            this.LinkMap.Location = new System.Drawing.Point(2, 207);
            this.LinkMap.Name = "LinkMap";
            this.LinkMap.Size = new System.Drawing.Size(278, 22);
            this.LinkMap.TabIndex = 7;
            this.LinkMap.TabStop = true;
            this.LinkMap.Text = "https://www.naturalearthdata.com/";
            this.LinkMap.UseMnemonic = false;
            this.LinkMap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkMap_LinkClicked);
            // 
            // LinkOtoLogic
            // 
            this.LinkOtoLogic.AutoSize = true;
            this.LinkOtoLogic.Location = new System.Drawing.Point(287, 250);
            this.LinkOtoLogic.Name = "LinkOtoLogic";
            this.LinkOtoLogic.Size = new System.Drawing.Size(145, 22);
            this.LinkOtoLogic.TabIndex = 6;
            this.LinkOtoLogic.TabStop = true;
            this.LinkOtoLogic.Text = "https://otologic.jp";
            this.LinkOtoLogic.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkOtoLogic_LinkClicked);
            // 
            // LinkKoruri
            // 
            this.LinkKoruri.AutoSize = true;
            this.LinkKoruri.Location = new System.Drawing.Point(3, 250);
            this.LinkKoruri.Name = "LinkKoruri";
            this.LinkKoruri.Size = new System.Drawing.Size(189, 22);
            this.LinkKoruri.TabIndex = 5;
            this.LinkKoruri.TabStop = true;
            this.LinkKoruri.Text = "https://koruri.github.io/";
            this.LinkKoruri.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkKoruri_LinkClicked);
            // 
            // LinkJMA
            // 
            this.LinkJMA.AutoSize = true;
            this.LinkJMA.Location = new System.Drawing.Point(3, 162);
            this.LinkJMA.Name = "LinkJMA";
            this.LinkJMA.Size = new System.Drawing.Size(318, 22);
            this.LinkJMA.TabIndex = 4;
            this.LinkJMA.TabStop = true;
            this.LinkJMA.Text = "http://xml.kishou.go.jp/tec_material.html";
            this.LinkJMA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkJMA_LinkClicked);
            // 
            // LinkFE
            // 
            this.LinkFE.AutoSize = true;
            this.LinkFE.Location = new System.Drawing.Point(3, 96);
            this.LinkFE.Name = "LinkFE";
            this.LinkFE.Size = new System.Drawing.Size(421, 22);
            this.LinkFE.TabIndex = 3;
            this.LinkFE.TabStop = true;
            this.LinkFE.Text = "https://earthquake.usgs.gov/ws/geoserve/regions.php";
            this.LinkFE.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkFE_LinkClicked);
            // 
            // LinkUSGS
            // 
            this.LinkUSGS.AutoSize = true;
            this.LinkUSGS.Location = new System.Drawing.Point(3, 52);
            this.LinkUSGS.Name = "LinkUSGS";
            this.LinkUSGS.Size = new System.Drawing.Size(499, 22);
            this.LinkUSGS.TabIndex = 2;
            this.LinkUSGS.TabStop = true;
            this.LinkUSGS.Text = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php";
            this.LinkUSGS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkUSGS_LinkClicked);
            // 
            // Tab_Info_Text
            // 
            this.Tab_Info_Text.AutoSize = true;
            this.Tab_Info_Text.Location = new System.Drawing.Point(3, 30);
            this.Tab_Info_Text.Name = "Tab_Info_Text";
            this.Tab_Info_Text.Size = new System.Drawing.Size(632, 220);
            this.Tab_Info_Text.TabIndex = 1;
            this.Tab_Info_Text.Text = resources.GetString("Tab_Info_Text.Text");
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Font = new System.Drawing.Font("Koruri Regular", 16F);
            this.Version.Location = new System.Drawing.Point(0, 0);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(211, 31);
            this.Version.TabIndex = 0;
            this.Version.Text = "WorldQuakeViewer";
            // 
            // Tab_View
            // 
            this.Tab_View.Controls.Add(this.Tab_View_LogTime);
            this.Tab_View.Controls.Add(this.Tab_View_LogEnable);
            this.Tab_View.Controls.Add(this.Tab_View_Text);
            this.Tab_View.Controls.Add(this.Tab_View_LatLonDecimal);
            this.Tab_View.Controls.Add(this.Tab_View_HideMap);
            this.Tab_View.Controls.Add(this.Tab_View_HideHist);
            this.Tab_View.Location = new System.Drawing.Point(4, 31);
            this.Tab_View.Name = "Tab_View";
            this.Tab_View.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_View.Size = new System.Drawing.Size(632, 275);
            this.Tab_View.TabIndex = 4;
            this.Tab_View.Text = "表示・ログ";
            this.Tab_View.UseVisualStyleBackColor = true;
            // 
            // Tab_View_LogTime
            // 
            this.Tab_View_LogTime.Location = new System.Drawing.Point(263, 140);
            this.Tab_View_LogTime.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.Tab_View_LogTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Tab_View_LogTime.Name = "Tab_View_LogTime";
            this.Tab_View_LogTime.Size = new System.Drawing.Size(58, 31);
            this.Tab_View_LogTime.TabIndex = 9;
            this.Tab_View_LogTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tab_View_LogTime.Value = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            // 
            // Tab_View_LogEnable
            // 
            this.Tab_View_LogEnable.AutoSize = true;
            this.Tab_View_LogEnable.Location = new System.Drawing.Point(8, 142);
            this.Tab_View_LogEnable.Name = "Tab_View_LogEnable";
            this.Tab_View_LogEnable.Size = new System.Drawing.Size(333, 26);
            this.Tab_View_LogEnable.TabIndex = 8;
            this.Tab_View_LogEnable.Text = "動作ログを保存する     自動削除:                s";
            this.Tab_View_LogEnable.UseVisualStyleBackColor = true;
            // 
            // Tab_View_Text
            // 
            this.Tab_View_Text.AutoSize = true;
            this.Tab_View_Text.Location = new System.Drawing.Point(19, 99);
            this.Tab_View_Text.Name = "Tab_View_Text";
            this.Tab_View_Text.Size = new System.Drawing.Size(365, 22);
            this.Tab_View_Text.TabIndex = 7;
            this.Tab_View_Text.Text = "(表示:12°34\' -> 12.58,ログ:12°34\'56\'\' -> 12.5822°)";
            // 
            // Tab_View_LatLonDecimal
            // 
            this.Tab_View_LatLonDecimal.AutoSize = true;
            this.Tab_View_LatLonDecimal.Location = new System.Drawing.Point(6, 70);
            this.Tab_View_LatLonDecimal.Name = "Tab_View_LatLonDecimal";
            this.Tab_View_LatLonDecimal.Size = new System.Drawing.Size(237, 26);
            this.Tab_View_LatLonDecimal.TabIndex = 6;
            this.Tab_View_LatLonDecimal.Text = "緯度経度を度のみで表示する";
            this.Tab_View_LatLonDecimal.UseVisualStyleBackColor = true;
            // 
            // Tab_View_HideMap
            // 
            this.Tab_View_HideMap.AutoSize = true;
            this.Tab_View_HideMap.Location = new System.Drawing.Point(23, 38);
            this.Tab_View_HideMap.Name = "Tab_View_HideMap";
            this.Tab_View_HideMap.Size = new System.Drawing.Size(173, 26);
            this.Tab_View_HideMap.TabIndex = 5;
            this.Tab_View_HideMap.Text = "地図も非表示にする";
            this.Tab_View_HideMap.UseVisualStyleBackColor = true;
            // 
            // Tab_View_HideHist
            // 
            this.Tab_View_HideHist.AutoSize = true;
            this.Tab_View_HideHist.Location = new System.Drawing.Point(8, 6);
            this.Tab_View_HideHist.Name = "Tab_View_HideHist";
            this.Tab_View_HideHist.Size = new System.Drawing.Size(279, 26);
            this.Tab_View_HideHist.TabIndex = 4;
            this.Tab_View_HideHist.Text = "履歴を非表示にする(取得はします)";
            this.Tab_View_HideHist.UseVisualStyleBackColor = true;
            // 
            // Tab_Update
            // 
            this.Tab_Update.Controls.Add(this.Tab_Update_Time);
            this.Tab_Update.Controls.Add(this.Tab_Update_Alert);
            this.Tab_Update.Controls.Add(this.Tab_Update_MMI);
            this.Tab_Update.Controls.Add(this.Tab_Update_Mag);
            this.Tab_Update.Controls.Add(this.Tab_Update_MagType);
            this.Tab_Update.Controls.Add(this.Tab_Update_Depth);
            this.Tab_Update.Controls.Add(this.Tab_Update_LatLon);
            this.Tab_Update.Controls.Add(this.Tab_Update_HypoEN);
            this.Tab_Update.Controls.Add(this.Tab_Update_HypoJP);
            this.Tab_Update.Controls.Add(this.Tab_Update_Text);
            this.Tab_Update.Location = new System.Drawing.Point(4, 31);
            this.Tab_Update.Name = "Tab_Update";
            this.Tab_Update.Size = new System.Drawing.Size(632, 275);
            this.Tab_Update.TabIndex = 8;
            this.Tab_Update.Text = "更新検知";
            this.Tab_Update.UseVisualStyleBackColor = true;
            // 
            // Tab_Update_Time
            // 
            this.Tab_Update_Time.AutoSize = true;
            this.Tab_Update_Time.Location = new System.Drawing.Point(27, 38);
            this.Tab_Update_Time.Name = "Tab_Update_Time";
            this.Tab_Update_Time.Size = new System.Drawing.Size(93, 26);
            this.Tab_Update_Time.TabIndex = 9;
            this.Tab_Update_Time.Text = "発生時刻";
            this.Tab_Update_Time.UseVisualStyleBackColor = true;
            // 
            // Tab_Update_Alert
            // 
            this.Tab_Update_Alert.AutoSize = true;
            this.Tab_Update_Alert.Location = new System.Drawing.Point(313, 207);
            this.Tab_Update_Alert.Name = "Tab_Update_Alert";
            this.Tab_Update_Alert.Size = new System.Drawing.Size(153, 26);
            this.Tab_Update_Alert.TabIndex = 8;
            this.Tab_Update_Alert.Text = "アラート(PAGER)";
            this.Tab_Update_Alert.UseVisualStyleBackColor = true;
            // 
            // Tab_Update_MMI
            // 
            this.Tab_Update_MMI.AutoSize = true;
            this.Tab_Update_MMI.Location = new System.Drawing.Point(27, 207);
            this.Tab_Update_MMI.Name = "Tab_Update_MMI";
            this.Tab_Update_MMI.Size = new System.Drawing.Size(189, 26);
            this.Tab_Update_MMI.TabIndex = 7;
            this.Tab_Update_MMI.Text = "改正メルカリ震度階級";
            this.Tab_Update_MMI.UseVisualStyleBackColor = true;
            // 
            // Tab_Update_Mag
            // 
            this.Tab_Update_Mag.AutoSize = true;
            this.Tab_Update_Mag.Location = new System.Drawing.Point(313, 164);
            this.Tab_Update_Mag.Name = "Tab_Update_Mag";
            this.Tab_Update_Mag.Size = new System.Drawing.Size(141, 26);
            this.Tab_Update_Mag.TabIndex = 6;
            this.Tab_Update_Mag.Text = "マグニチュード";
            this.Tab_Update_Mag.UseVisualStyleBackColor = true;
            // 
            // Tab_Update_MagType
            // 
            this.Tab_Update_MagType.AutoSize = true;
            this.Tab_Update_MagType.Location = new System.Drawing.Point(27, 164);
            this.Tab_Update_MagType.Name = "Tab_Update_MagType";
            this.Tab_Update_MagType.Size = new System.Drawing.Size(189, 26);
            this.Tab_Update_MagType.TabIndex = 5;
            this.Tab_Update_MagType.Text = "マグニチュードの種類";
            this.Tab_Update_MagType.UseVisualStyleBackColor = true;
            // 
            // Tab_Update_Depth
            // 
            this.Tab_Update_Depth.AutoSize = true;
            this.Tab_Update_Depth.Location = new System.Drawing.Point(313, 120);
            this.Tab_Update_Depth.Name = "Tab_Update_Depth";
            this.Tab_Update_Depth.Size = new System.Drawing.Size(61, 26);
            this.Tab_Update_Depth.TabIndex = 4;
            this.Tab_Update_Depth.Text = "深さ";
            this.Tab_Update_Depth.UseVisualStyleBackColor = true;
            // 
            // Tab_Update_LatLon
            // 
            this.Tab_Update_LatLon.AutoSize = true;
            this.Tab_Update_LatLon.Location = new System.Drawing.Point(27, 120);
            this.Tab_Update_LatLon.Name = "Tab_Update_LatLon";
            this.Tab_Update_LatLon.Size = new System.Drawing.Size(109, 26);
            this.Tab_Update_LatLon.TabIndex = 3;
            this.Tab_Update_LatLon.Text = "緯度・経度";
            this.Tab_Update_LatLon.UseVisualStyleBackColor = true;
            // 
            // Tab_Update_HypoEN
            // 
            this.Tab_Update_HypoEN.AutoSize = true;
            this.Tab_Update_HypoEN.Location = new System.Drawing.Point(313, 78);
            this.Tab_Update_HypoEN.Name = "Tab_Update_HypoEN";
            this.Tab_Update_HypoEN.Size = new System.Drawing.Size(161, 26);
            this.Tab_Update_HypoEN.TabIndex = 2;
            this.Tab_Update_HypoEN.Text = "震源名(USGS表記)";
            this.Tab_Update_HypoEN.UseVisualStyleBackColor = true;
            // 
            // Tab_Update_HypoJP
            // 
            this.Tab_Update_HypoJP.AutoSize = true;
            this.Tab_Update_HypoJP.Location = new System.Drawing.Point(27, 78);
            this.Tab_Update_HypoJP.Name = "Tab_Update_HypoJP";
            this.Tab_Update_HypoJP.Size = new System.Drawing.Size(135, 26);
            this.Tab_Update_HypoJP.TabIndex = 1;
            this.Tab_Update_HypoJP.Text = "震源名(日本語)";
            this.Tab_Update_HypoJP.UseVisualStyleBackColor = true;
            // 
            // Tab_Update_Text
            // 
            this.Tab_Update_Text.AutoSize = true;
            this.Tab_Update_Text.Location = new System.Drawing.Point(8, 3);
            this.Tab_Update_Text.Name = "Tab_Update_Text";
            this.Tab_Update_Text.Size = new System.Drawing.Size(426, 22);
            this.Tab_Update_Text.TabIndex = 0;
            this.Tab_Update_Text.Text = "チェックをつけたものが変わった場合更新と判定します。";
            // 
            // Tab_Sound
            // 
            this.Tab_Sound.Controls.Add(this.Tab_Sound_Test_M80u);
            this.Tab_Sound.Controls.Add(this.Tab_Sound_Test_M60u);
            this.Tab_Sound.Controls.Add(this.Tab_Sound_Test_M45u);
            this.Tab_Sound.Controls.Add(this.Tab_Sound_Test_M80);
            this.Tab_Sound.Controls.Add(this.Tab_Sound_Test_M60);
            this.Tab_Sound.Controls.Add(this.Tab_Sound_Test_M45);
            this.Tab_Sound.Controls.Add(this.Tab_Sound_Updt);
            this.Tab_Sound.Controls.Add(this.Tab_Sound_M80);
            this.Tab_Sound.Controls.Add(this.Tab_Sound_M60);
            this.Tab_Sound.Controls.Add(this.Tab_Sound_M45);
            this.Tab_Sound.Controls.Add(this.Tab_Sound_Text);
            this.Tab_Sound.Location = new System.Drawing.Point(4, 31);
            this.Tab_Sound.Name = "Tab_Sound";
            this.Tab_Sound.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Sound.Size = new System.Drawing.Size(632, 275);
            this.Tab_Sound.TabIndex = 5;
            this.Tab_Sound.Text = "音声";
            this.Tab_Sound.UseVisualStyleBackColor = true;
            // 
            // Tab_Sound_Test_M80u
            // 
            this.Tab_Sound_Test_M80u.Location = new System.Drawing.Point(530, 208);
            this.Tab_Sound_Test_M80u.Name = "Tab_Sound_Test_M80u";
            this.Tab_Sound_Test_M80u.Size = new System.Drawing.Size(94, 30);
            this.Tab_Sound_Test_M80u.TabIndex = 15;
            this.Tab_Sound_Test_M80u.Text = "M80u.wav";
            this.Tab_Sound_Test_M80u.UseVisualStyleBackColor = true;
            this.Tab_Sound_Test_M80u.Click += new System.EventHandler(this.Tab_Sound_Test_M80u_Click);
            // 
            // Tab_Sound_Test_M60u
            // 
            this.Tab_Sound_Test_M60u.Location = new System.Drawing.Point(530, 172);
            this.Tab_Sound_Test_M60u.Name = "Tab_Sound_Test_M60u";
            this.Tab_Sound_Test_M60u.Size = new System.Drawing.Size(94, 30);
            this.Tab_Sound_Test_M60u.TabIndex = 14;
            this.Tab_Sound_Test_M60u.Text = "M60u.wav";
            this.Tab_Sound_Test_M60u.UseVisualStyleBackColor = true;
            this.Tab_Sound_Test_M60u.Click += new System.EventHandler(this.Tab_Sound_Test_M60u_Click);
            // 
            // Tab_Sound_Test_M45u
            // 
            this.Tab_Sound_Test_M45u.Location = new System.Drawing.Point(530, 136);
            this.Tab_Sound_Test_M45u.Name = "Tab_Sound_Test_M45u";
            this.Tab_Sound_Test_M45u.Size = new System.Drawing.Size(94, 30);
            this.Tab_Sound_Test_M45u.TabIndex = 13;
            this.Tab_Sound_Test_M45u.Text = "M45u.wav";
            this.Tab_Sound_Test_M45u.UseVisualStyleBackColor = true;
            this.Tab_Sound_Test_M45u.Click += new System.EventHandler(this.Tab_Sound_Test_M45u_Click);
            // 
            // Tab_Sound_Test_M80
            // 
            this.Tab_Sound_Test_M80.Location = new System.Drawing.Point(530, 100);
            this.Tab_Sound_Test_M80.Name = "Tab_Sound_Test_M80";
            this.Tab_Sound_Test_M80.Size = new System.Drawing.Size(94, 30);
            this.Tab_Sound_Test_M80.TabIndex = 12;
            this.Tab_Sound_Test_M80.Text = "M80.wav";
            this.Tab_Sound_Test_M80.UseVisualStyleBackColor = true;
            this.Tab_Sound_Test_M80.Click += new System.EventHandler(this.Tab_Sound_Test_M80_Click);
            // 
            // Tab_Sound_Test_M60
            // 
            this.Tab_Sound_Test_M60.Location = new System.Drawing.Point(532, 64);
            this.Tab_Sound_Test_M60.Name = "Tab_Sound_Test_M60";
            this.Tab_Sound_Test_M60.Size = new System.Drawing.Size(94, 30);
            this.Tab_Sound_Test_M60.TabIndex = 11;
            this.Tab_Sound_Test_M60.Text = "M60.wav";
            this.Tab_Sound_Test_M60.UseVisualStyleBackColor = true;
            this.Tab_Sound_Test_M60.Click += new System.EventHandler(this.Tab_Sound_Test_M60_Click);
            // 
            // Tab_Sound_Test_M45
            // 
            this.Tab_Sound_Test_M45.Location = new System.Drawing.Point(532, 28);
            this.Tab_Sound_Test_M45.Name = "Tab_Sound_Test_M45";
            this.Tab_Sound_Test_M45.Size = new System.Drawing.Size(94, 30);
            this.Tab_Sound_Test_M45.TabIndex = 10;
            this.Tab_Sound_Test_M45.Text = "M45.wav";
            this.Tab_Sound_Test_M45.UseVisualStyleBackColor = true;
            this.Tab_Sound_Test_M45.Click += new System.EventHandler(this.Tab_Sound_Test_M45_Click);
            // 
            // Tab_Sound_Updt
            // 
            this.Tab_Sound_Updt.AutoSize = true;
            this.Tab_Sound_Updt.Location = new System.Drawing.Point(12, 134);
            this.Tab_Sound_Updt.Name = "Tab_Sound_Updt";
            this.Tab_Sound_Updt.Size = new System.Drawing.Size(318, 26);
            this.Tab_Sound_Updt.TabIndex = 8;
            this.Tab_Sound_Updt.Text = "更新時(M45u.wav,M60u.wav,M80u.wav)";
            this.Tab_Sound_Updt.UseVisualStyleBackColor = true;
            // 
            // Tab_Sound_M80
            // 
            this.Tab_Sound_M80.AutoSize = true;
            this.Tab_Sound_M80.Location = new System.Drawing.Point(12, 92);
            this.Tab_Sound_M80.Name = "Tab_Sound_M80";
            this.Tab_Sound_M80.Size = new System.Drawing.Size(172, 26);
            this.Tab_Sound_M80.TabIndex = 7;
            this.Tab_Sound_M80.Text = "M8.0以上(M80.wav)";
            this.Tab_Sound_M80.UseVisualStyleBackColor = true;
            // 
            // Tab_Sound_M60
            // 
            this.Tab_Sound_M60.AutoSize = true;
            this.Tab_Sound_M60.Location = new System.Drawing.Point(12, 60);
            this.Tab_Sound_M60.Name = "Tab_Sound_M60";
            this.Tab_Sound_M60.Size = new System.Drawing.Size(240, 26);
            this.Tab_Sound_M60.TabIndex = 6;
            this.Tab_Sound_M60.Text = "M6.0以上M8.0未満(M60.wav)";
            this.Tab_Sound_M60.UseVisualStyleBackColor = true;
            // 
            // Tab_Sound_M45
            // 
            this.Tab_Sound_M45.AutoSize = true;
            this.Tab_Sound_M45.Location = new System.Drawing.Point(12, 28);
            this.Tab_Sound_M45.Name = "Tab_Sound_M45";
            this.Tab_Sound_M45.Size = new System.Drawing.Size(172, 26);
            this.Tab_Sound_M45.TabIndex = 5;
            this.Tab_Sound_M45.Text = "M6.0未満(M45.wav)";
            this.Tab_Sound_M45.UseVisualStyleBackColor = true;
            // 
            // Tab_Sound_Text
            // 
            this.Tab_Sound_Text.AutoSize = true;
            this.Tab_Sound_Text.Location = new System.Drawing.Point(8, 3);
            this.Tab_Sound_Text.Name = "Tab_Sound_Text";
            this.Tab_Sound_Text.Size = new System.Drawing.Size(618, 220);
            this.Tab_Sound_Text.TabIndex = 9;
            this.Tab_Sound_Text.Text = resources.GetString("Tab_Sound_Text.Text");
            // 
            // Tab_Yomi
            // 
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_Text2);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_Voice);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_LowerAnd);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_LowerOr);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_LowerMMI);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_LowerMag);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_Port);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_Host);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_Test);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_Volume);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_Tone);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_Speed);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_Enable);
            this.Tab_Yomi.Controls.Add(this.Tab_Yomi_Text);
            this.Tab_Yomi.Location = new System.Drawing.Point(4, 31);
            this.Tab_Yomi.Name = "Tab_Yomi";
            this.Tab_Yomi.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Yomi.Size = new System.Drawing.Size(632, 275);
            this.Tab_Yomi.TabIndex = 1;
            this.Tab_Yomi.Text = "読み上げ";
            this.Tab_Yomi.UseVisualStyleBackColor = true;
            // 
            // Tab_Yomi_Text2
            // 
            this.Tab_Yomi_Text2.AutoSize = true;
            this.Tab_Yomi_Text2.Location = new System.Drawing.Point(116, 128);
            this.Tab_Yomi_Text2.Name = "Tab_Yomi_Text2";
            this.Tab_Yomi_Text2.Size = new System.Drawing.Size(379, 44);
            this.Tab_Yomi_Text2.TabIndex = 27;
            this.Tab_Yomi_Text2.Text = "0:画面上の設定  1:女性1  2:女性2  3:男性1  4:男性2\r\n5:中性  6:ロボット  7:機械1  8:機械2  10001～:SAPI5";
            // 
            // Tab_Yomi_Voice
            // 
            this.Tab_Yomi_Voice.Location = new System.Drawing.Point(49, 133);
            this.Tab_Yomi_Voice.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Tab_Yomi_Voice.Name = "Tab_Yomi_Voice";
            this.Tab_Yomi_Voice.Size = new System.Drawing.Size(66, 31);
            this.Tab_Yomi_Voice.TabIndex = 26;
            // 
            // Tab_Yomi_LowerAnd
            // 
            this.Tab_Yomi_LowerAnd.AutoSize = true;
            this.Tab_Yomi_LowerAnd.Location = new System.Drawing.Point(120, 102);
            this.Tab_Yomi_LowerAnd.Name = "Tab_Yomi_LowerAnd";
            this.Tab_Yomi_LowerAnd.Size = new System.Drawing.Size(60, 26);
            this.Tab_Yomi_LowerAnd.TabIndex = 25;
            this.Tab_Yomi_LowerAnd.Text = "かつ";
            this.Tab_Yomi_LowerAnd.UseVisualStyleBackColor = true;
            // 
            // Tab_Yomi_LowerOr
            // 
            this.Tab_Yomi_LowerOr.AutoSize = true;
            this.Tab_Yomi_LowerOr.Checked = true;
            this.Tab_Yomi_LowerOr.Location = new System.Drawing.Point(120, 82);
            this.Tab_Yomi_LowerOr.Name = "Tab_Yomi_LowerOr";
            this.Tab_Yomi_LowerOr.Size = new System.Drawing.Size(76, 26);
            this.Tab_Yomi_LowerOr.TabIndex = 24;
            this.Tab_Yomi_LowerOr.TabStop = true;
            this.Tab_Yomi_LowerOr.Text = "または";
            this.Tab_Yomi_LowerOr.UseVisualStyleBackColor = true;
            // 
            // Tab_Yomi_LowerMMI
            // 
            this.Tab_Yomi_LowerMMI.DecimalPlaces = 1;
            this.Tab_Yomi_LowerMMI.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Tab_Yomi_LowerMMI.Location = new System.Drawing.Point(292, 88);
            this.Tab_Yomi_LowerMMI.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Tab_Yomi_LowerMMI.Name = "Tab_Yomi_LowerMMI";
            this.Tab_Yomi_LowerMMI.Size = new System.Drawing.Size(51, 31);
            this.Tab_Yomi_LowerMMI.TabIndex = 23;
            // 
            // Tab_Yomi_LowerMag
            // 
            this.Tab_Yomi_LowerMag.DecimalPlaces = 2;
            this.Tab_Yomi_LowerMag.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Tab_Yomi_LowerMag.Location = new System.Drawing.Point(26, 88);
            this.Tab_Yomi_LowerMag.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Tab_Yomi_LowerMag.Name = "Tab_Yomi_LowerMag";
            this.Tab_Yomi_LowerMag.Size = new System.Drawing.Size(51, 31);
            this.Tab_Yomi_LowerMag.TabIndex = 22;
            // 
            // Tab_Yomi_Port
            // 
            this.Tab_Yomi_Port.Location = new System.Drawing.Point(230, 45);
            this.Tab_Yomi_Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Tab_Yomi_Port.Name = "Tab_Yomi_Port";
            this.Tab_Yomi_Port.Size = new System.Drawing.Size(64, 31);
            this.Tab_Yomi_Port.TabIndex = 18;
            this.Tab_Yomi_Port.Value = new decimal(new int[] {
            50001,
            0,
            0,
            0});
            // 
            // Tab_Yomi_Host
            // 
            this.Tab_Yomi_Host.Location = new System.Drawing.Point(117, 45);
            this.Tab_Yomi_Host.Name = "Tab_Yomi_Host";
            this.Tab_Yomi_Host.Size = new System.Drawing.Size(106, 31);
            this.Tab_Yomi_Host.TabIndex = 17;
            this.Tab_Yomi_Host.Text = "127.0.0.1";
            // 
            // Tab_Yomi_Test
            // 
            this.Tab_Yomi_Test.Location = new System.Drawing.Point(10, 226);
            this.Tab_Yomi_Test.Name = "Tab_Yomi_Test";
            this.Tab_Yomi_Test.Size = new System.Drawing.Size(98, 32);
            this.Tab_Yomi_Test.TabIndex = 21;
            this.Tab_Yomi_Test.Text = "送信テスト";
            this.Tab_Yomi_Test.UseVisualStyleBackColor = true;
            this.Tab_Yomi_Test.Click += new System.EventHandler(this.Tab_Yomi_Test_Click);
            // 
            // Tab_Yomi_Volume
            // 
            this.Tab_Yomi_Volume.Location = new System.Drawing.Point(249, 177);
            this.Tab_Yomi_Volume.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Tab_Yomi_Volume.Name = "Tab_Yomi_Volume";
            this.Tab_Yomi_Volume.Size = new System.Drawing.Size(49, 31);
            this.Tab_Yomi_Volume.TabIndex = 20;
            this.Tab_Yomi_Volume.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // Tab_Yomi_Tone
            // 
            this.Tab_Yomi_Tone.Location = new System.Drawing.Point(149, 177);
            this.Tab_Yomi_Tone.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.Tab_Yomi_Tone.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Tab_Yomi_Tone.Name = "Tab_Yomi_Tone";
            this.Tab_Yomi_Tone.Size = new System.Drawing.Size(49, 31);
            this.Tab_Yomi_Tone.TabIndex = 19;
            this.Tab_Yomi_Tone.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // Tab_Yomi_Speed
            // 
            this.Tab_Yomi_Speed.Location = new System.Drawing.Point(50, 177);
            this.Tab_Yomi_Speed.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.Tab_Yomi_Speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Tab_Yomi_Speed.Name = "Tab_Yomi_Speed";
            this.Tab_Yomi_Speed.Size = new System.Drawing.Size(49, 31);
            this.Tab_Yomi_Speed.TabIndex = 15;
            this.Tab_Yomi_Speed.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // Tab_Yomi_Enable
            // 
            this.Tab_Yomi_Enable.AutoSize = true;
            this.Tab_Yomi_Enable.Location = new System.Drawing.Point(8, 6);
            this.Tab_Yomi_Enable.Name = "Tab_Yomi_Enable";
            this.Tab_Yomi_Enable.Size = new System.Drawing.Size(393, 26);
            this.Tab_Yomi_Enable.TabIndex = 14;
            this.Tab_Yomi_Enable.Text = "読み上げを有効にする(棒読みちゃんへSocket通信)";
            this.Tab_Yomi_Enable.UseVisualStyleBackColor = true;
            // 
            // Tab_Yomi_Text
            // 
            this.Tab_Yomi_Text.AutoSize = true;
            this.Tab_Yomi_Text.Location = new System.Drawing.Point(4, 4);
            this.Tab_Yomi_Text.Name = "Tab_Yomi_Text";
            this.Tab_Yomi_Text.Size = new System.Drawing.Size(461, 220);
            this.Tab_Yomi_Text.TabIndex = 13;
            this.Tab_Yomi_Text.Text = resources.GetString("Tab_Yomi_Text.Text");
            // 
            // Tab_Tweet
            // 
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_Test);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_Text2);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_ViewToken);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_LowerMMI);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_LowerMag);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_LowerAnd);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_LowerOr);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_Text3);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_AccSec);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_AccTok);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_ConSec);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_ConKey);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_Enable);
            this.Tab_Tweet.Controls.Add(this.Tab_Tweet_Text);
            this.Tab_Tweet.Location = new System.Drawing.Point(4, 31);
            this.Tab_Tweet.Name = "Tab_Tweet";
            this.Tab_Tweet.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Tweet.Size = new System.Drawing.Size(632, 275);
            this.Tab_Tweet.TabIndex = 2;
            this.Tab_Tweet.Text = "自動ツイート";
            this.Tab_Tweet.UseVisualStyleBackColor = true;
            // 
            // Tab_Tweet_Test
            // 
            this.Tab_Tweet_Test.Location = new System.Drawing.Point(518, 218);
            this.Tab_Tweet_Test.Name = "Tab_Tweet_Test";
            this.Tab_Tweet_Test.Size = new System.Drawing.Size(98, 32);
            this.Tab_Tweet_Test.TabIndex = 31;
            this.Tab_Tweet_Test.Text = "送信テスト";
            this.Tab_Tweet_Test.UseVisualStyleBackColor = true;
            this.Tab_Tweet_Test.Click += new System.EventHandler(this.Tab_Tweet_Test_Click);
            // 
            // Tab_Tweet_Text2
            // 
            this.Tab_Tweet_Text2.AutoSize = true;
            this.Tab_Tweet_Text2.Font = new System.Drawing.Font("Koruri Regular", 8F);
            this.Tab_Tweet_Text2.Location = new System.Drawing.Point(25, 33);
            this.Tab_Tweet_Text2.Name = "Tab_Tweet_Text2";
            this.Tab_Tweet_Text2.Size = new System.Drawing.Size(151, 16);
            this.Tab_Tweet_Text2.TabIndex = 30;
            this.Tab_Tweet_Text2.Text = "※Twitter API申請が必要です";
            // 
            // Tab_Tweet_ViewToken
            // 
            this.Tab_Tweet_ViewToken.AutoSize = true;
            this.Tab_Tweet_ViewToken.Location = new System.Drawing.Point(16, 219);
            this.Tab_Tweet_ViewToken.Name = "Tab_Tweet_ViewToken";
            this.Tab_Tweet_ViewToken.Size = new System.Drawing.Size(93, 48);
            this.Tab_Tweet_ViewToken.TabIndex = 29;
            this.Tab_Tweet_ViewToken.Text = "tokenを\r\n表示する";
            this.Tab_Tweet_ViewToken.UseVisualStyleBackColor = true;
            this.Tab_Tweet_ViewToken.CheckedChanged += new System.EventHandler(this.Tab_Tweet_ViewToken_CheckedChanged);
            // 
            // Tab_Tweet_LowerMMI
            // 
            this.Tab_Tweet_LowerMMI.DecimalPlaces = 1;
            this.Tab_Tweet_LowerMMI.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Tab_Tweet_LowerMMI.Location = new System.Drawing.Point(541, 6);
            this.Tab_Tweet_LowerMMI.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Tab_Tweet_LowerMMI.Name = "Tab_Tweet_LowerMMI";
            this.Tab_Tweet_LowerMMI.Size = new System.Drawing.Size(51, 31);
            this.Tab_Tweet_LowerMMI.TabIndex = 28;
            this.Tab_Tweet_LowerMMI.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Tab_Tweet_LowerMag
            // 
            this.Tab_Tweet_LowerMag.DecimalPlaces = 2;
            this.Tab_Tweet_LowerMag.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Tab_Tweet_LowerMag.Location = new System.Drawing.Point(277, 7);
            this.Tab_Tweet_LowerMag.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Tab_Tweet_LowerMag.Name = "Tab_Tweet_LowerMag";
            this.Tab_Tweet_LowerMag.Size = new System.Drawing.Size(51, 31);
            this.Tab_Tweet_LowerMag.TabIndex = 27;
            this.Tab_Tweet_LowerMag.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // Tab_Tweet_LowerAnd
            // 
            this.Tab_Tweet_LowerAnd.AutoSize = true;
            this.Tab_Tweet_LowerAnd.Location = new System.Drawing.Point(365, 20);
            this.Tab_Tweet_LowerAnd.Name = "Tab_Tweet_LowerAnd";
            this.Tab_Tweet_LowerAnd.Size = new System.Drawing.Size(60, 26);
            this.Tab_Tweet_LowerAnd.TabIndex = 26;
            this.Tab_Tweet_LowerAnd.Text = "かつ";
            this.Tab_Tweet_LowerAnd.UseVisualStyleBackColor = true;
            // 
            // Tab_Tweet_LowerOr
            // 
            this.Tab_Tweet_LowerOr.AutoSize = true;
            this.Tab_Tweet_LowerOr.Checked = true;
            this.Tab_Tweet_LowerOr.Location = new System.Drawing.Point(365, 0);
            this.Tab_Tweet_LowerOr.Name = "Tab_Tweet_LowerOr";
            this.Tab_Tweet_LowerOr.Size = new System.Drawing.Size(76, 26);
            this.Tab_Tweet_LowerOr.TabIndex = 25;
            this.Tab_Tweet_LowerOr.TabStop = true;
            this.Tab_Tweet_LowerOr.Text = "または";
            this.Tab_Tweet_LowerOr.UseVisualStyleBackColor = true;
            // 
            // Tab_Tweet_Text3
            // 
            this.Tab_Tweet_Text3.AutoSize = true;
            this.Tab_Tweet_Text3.ForeColor = System.Drawing.Color.Red;
            this.Tab_Tweet_Text3.Location = new System.Drawing.Point(141, 223);
            this.Tab_Tweet_Text3.Name = "Tab_Tweet_Text3";
            this.Tab_Tweet_Text3.Size = new System.Drawing.Size(484, 44);
            this.Tab_Tweet_Text3.TabIndex = 13;
            this.Tab_Tweet_Text3.Text = "!注意 tokenはそのまま保存されます。\r\n          心配な場合Socketで他ソフトに送信して処理してください。";
            // 
            // Tab_Tweet_AccSec
            // 
            this.Tab_Tweet_AccSec.Location = new System.Drawing.Point(151, 183);
            this.Tab_Tweet_AccSec.Name = "Tab_Tweet_AccSec";
            this.Tab_Tweet_AccSec.PasswordChar = '*';
            this.Tab_Tweet_AccSec.Size = new System.Drawing.Size(465, 31);
            this.Tab_Tweet_AccSec.TabIndex = 12;
            // 
            // Tab_Tweet_AccTok
            // 
            this.Tab_Tweet_AccTok.Location = new System.Drawing.Point(151, 139);
            this.Tab_Tweet_AccTok.Name = "Tab_Tweet_AccTok";
            this.Tab_Tweet_AccTok.PasswordChar = '*';
            this.Tab_Tweet_AccTok.Size = new System.Drawing.Size(465, 31);
            this.Tab_Tweet_AccTok.TabIndex = 11;
            // 
            // Tab_Tweet_ConSec
            // 
            this.Tab_Tweet_ConSec.Location = new System.Drawing.Point(151, 95);
            this.Tab_Tweet_ConSec.Name = "Tab_Tweet_ConSec";
            this.Tab_Tweet_ConSec.PasswordChar = '*';
            this.Tab_Tweet_ConSec.Size = new System.Drawing.Size(465, 31);
            this.Tab_Tweet_ConSec.TabIndex = 10;
            // 
            // Tab_Tweet_ConKey
            // 
            this.Tab_Tweet_ConKey.Location = new System.Drawing.Point(151, 51);
            this.Tab_Tweet_ConKey.Name = "Tab_Tweet_ConKey";
            this.Tab_Tweet_ConKey.PasswordChar = '*';
            this.Tab_Tweet_ConKey.Size = new System.Drawing.Size(465, 31);
            this.Tab_Tweet_ConKey.TabIndex = 9;
            // 
            // Tab_Tweet_Enable
            // 
            this.Tab_Tweet_Enable.AutoSize = true;
            this.Tab_Tweet_Enable.Location = new System.Drawing.Point(8, 10);
            this.Tab_Tweet_Enable.Name = "Tab_Tweet_Enable";
            this.Tab_Tweet_Enable.Size = new System.Drawing.Size(221, 26);
            this.Tab_Tweet_Enable.TabIndex = 7;
            this.Tab_Tweet_Enable.Text = "自動ツイートを有効にする";
            this.Tab_Tweet_Enable.UseVisualStyleBackColor = true;
            // 
            // Tab_Tweet_Text
            // 
            this.Tab_Tweet_Text.AutoSize = true;
            this.Tab_Tweet_Text.Location = new System.Drawing.Point(12, 10);
            this.Tab_Tweet_Text.Name = "Tab_Tweet_Text";
            this.Tab_Tweet_Text.Size = new System.Drawing.Size(620, 198);
            this.Tab_Tweet_Text.TabIndex = 8;
            this.Tab_Tweet_Text.Text = "                                                             M              以上   " +
    "                 メルカリ震度              以上\r\n\r\nConsumerKey:\r\n\r\nConsumerSecret:\r\n\r\nAc" +
    "cessToken:\r\n\r\nAccessSecret:";
            // 
            // Tab_Socket
            // 
            this.Tab_Socket.Controls.Add(this.Tab_Socket_Test);
            this.Tab_Socket.Controls.Add(this.Tab_Socket_Enable);
            this.Tab_Socket.Controls.Add(this.Tab_Socket_TextFormat);
            this.Tab_Socket.Controls.Add(this.Tab_Socket_Port);
            this.Tab_Socket.Controls.Add(this.Tab_Socket_Host);
            this.Tab_Socket.Controls.Add(this.Tab_Socket_Text);
            this.Tab_Socket.Location = new System.Drawing.Point(4, 31);
            this.Tab_Socket.Name = "Tab_Socket";
            this.Tab_Socket.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Socket.Size = new System.Drawing.Size(632, 275);
            this.Tab_Socket.TabIndex = 6;
            this.Tab_Socket.Text = "Socket通信";
            this.Tab_Socket.UseVisualStyleBackColor = true;
            // 
            // Tab_Socket_Test
            // 
            this.Tab_Socket_Test.Location = new System.Drawing.Point(526, 78);
            this.Tab_Socket_Test.Name = "Tab_Socket_Test";
            this.Tab_Socket_Test.Size = new System.Drawing.Size(98, 32);
            this.Tab_Socket_Test.TabIndex = 32;
            this.Tab_Socket_Test.Text = "送信テスト";
            this.Tab_Socket_Test.UseVisualStyleBackColor = true;
            this.Tab_Socket_Test.Click += new System.EventHandler(this.Tab_Socket_Test_Click);
            // 
            // Tab_Socket_Enable
            // 
            this.Tab_Socket_Enable.AutoSize = true;
            this.Tab_Socket_Enable.Location = new System.Drawing.Point(8, 6);
            this.Tab_Socket_Enable.Name = "Tab_Socket_Enable";
            this.Tab_Socket_Enable.Size = new System.Drawing.Size(157, 26);
            this.Tab_Socket_Enable.TabIndex = 23;
            this.Tab_Socket_Enable.Text = "送信を有効にする";
            this.Tab_Socket_Enable.UseVisualStyleBackColor = true;
            // 
            // Tab_Socket_TextFormat
            // 
            this.Tab_Socket_TextFormat.Location = new System.Drawing.Point(6, 116);
            this.Tab_Socket_TextFormat.Multiline = true;
            this.Tab_Socket_TextFormat.Name = "Tab_Socket_TextFormat";
            this.Tab_Socket_TextFormat.Size = new System.Drawing.Size(620, 153);
            this.Tab_Socket_TextFormat.TabIndex = 22;
            this.Tab_Socket_TextFormat.Text = "{Text}";
            // 
            // Tab_Socket_Port
            // 
            this.Tab_Socket_Port.Location = new System.Drawing.Point(227, 45);
            this.Tab_Socket_Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Tab_Socket_Port.Name = "Tab_Socket_Port";
            this.Tab_Socket_Port.Size = new System.Drawing.Size(64, 31);
            this.Tab_Socket_Port.TabIndex = 21;
            // 
            // Tab_Socket_Host
            // 
            this.Tab_Socket_Host.Location = new System.Drawing.Point(115, 44);
            this.Tab_Socket_Host.Name = "Tab_Socket_Host";
            this.Tab_Socket_Host.Size = new System.Drawing.Size(106, 31);
            this.Tab_Socket_Host.TabIndex = 20;
            // 
            // Tab_Socket_Text
            // 
            this.Tab_Socket_Text.AutoSize = true;
            this.Tab_Socket_Text.Location = new System.Drawing.Point(3, 3);
            this.Tab_Socket_Text.Name = "Tab_Socket_Text";
            this.Tab_Socket_Text.Size = new System.Drawing.Size(311, 110);
            this.Tab_Socket_Text.TabIndex = 19;
            this.Tab_Socket_Text.Text = "\r\n\r\nホスト,ポート:\r\n\r\nテキスト:  　置換: {Text}:本文(ログと同じ)";
            // 
            // Tab_ProInfo
            // 
            this.Tab_ProInfo.Controls.Add(this.Tab_ProInfo_Text);
            this.Tab_ProInfo.Location = new System.Drawing.Point(4, 31);
            this.Tab_ProInfo.Name = "Tab_ProInfo";
            this.Tab_ProInfo.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_ProInfo.Size = new System.Drawing.Size(632, 275);
            this.Tab_ProInfo.TabIndex = 7;
            this.Tab_ProInfo.Text = "稼働状況";
            this.Tab_ProInfo.UseVisualStyleBackColor = true;
            // 
            // Tab_ProInfo_Text
            // 
            this.Tab_ProInfo_Text.AutoSize = true;
            this.Tab_ProInfo_Text.Location = new System.Drawing.Point(8, 3);
            this.Tab_ProInfo_Text.Name = "Tab_ProInfo_Text";
            this.Tab_ProInfo_Text.Size = new System.Drawing.Size(192, 66);
            this.Tab_ProInfo_Text.TabIndex = 0;
            this.Tab_ProInfo_Text.Text = "起動時間:0d00:00:00\r\nUSGS Feedアクセス回数:\r\nUSGE FE アクセス回数:";
            // 
            // ProInfoChange
            // 
            this.ProInfoChange.Enabled = true;
            this.ProInfoChange.Interval = 1000;
            this.ProInfoChange.Tick += new System.EventHandler(this.ProInfoChange_Tick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.SettingReset);
            this.Controls.Add(this.SettingSave);
            this.Font = new System.Drawing.Font("Koruri Regular", 12F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(656, 399);
            this.MinimumSize = new System.Drawing.Size(656, 399);
            this.Name = "SettingsForm";
            this.Text = "WQV - 設定画面";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.Tabs.ResumeLayout(false);
            this.Tab_Info.ResumeLayout(false);
            this.Tab_Info.PerformLayout();
            this.Tab_View.ResumeLayout(false);
            this.Tab_View.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_View_LogTime)).EndInit();
            this.Tab_Update.ResumeLayout(false);
            this.Tab_Update.PerformLayout();
            this.Tab_Sound.ResumeLayout(false);
            this.Tab_Sound.PerformLayout();
            this.Tab_Yomi.ResumeLayout(false);
            this.Tab_Yomi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_Voice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_LowerMMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_LowerMag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_Port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_Volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_Tone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Yomi_Speed)).EndInit();
            this.Tab_Tweet.ResumeLayout(false);
            this.Tab_Tweet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Tweet_LowerMMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Tweet_LowerMag)).EndInit();
            this.Tab_Socket.ResumeLayout(false);
            this.Tab_Socket.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tab_Socket_Port)).EndInit();
            this.Tab_ProInfo.ResumeLayout(false);
            this.Tab_ProInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SettingSave;
        private System.Windows.Forms.Button SettingReset;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Tab_Info;
        private System.Windows.Forms.TabPage Tab_Yomi;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.LinkLabel LinkUSGS;
        private System.Windows.Forms.Label Tab_Info_Text;
        private System.Windows.Forms.LinkLabel LinkJMA;
        private System.Windows.Forms.LinkLabel LinkFE;
        private System.Windows.Forms.LinkLabel LinkOtoLogic;
        private System.Windows.Forms.LinkLabel LinkKoruri;
        private System.Windows.Forms.LinkLabel LinkMap;
        private System.Windows.Forms.TabPage Tab_Tweet;
        private System.Windows.Forms.TabPage Tab_View;
        private System.Windows.Forms.TabPage Tab_Sound;
        private System.Windows.Forms.TabPage Tab_Socket;
        private System.Windows.Forms.Label Tab_View_Text;
        private System.Windows.Forms.CheckBox Tab_View_LatLonDecimal;
        private System.Windows.Forms.CheckBox Tab_View_HideMap;
        private System.Windows.Forms.CheckBox Tab_View_HideHist;
        private System.Windows.Forms.Label Tab_Sound_Text;
        private System.Windows.Forms.CheckBox Tab_Sound_Updt;
        private System.Windows.Forms.CheckBox Tab_Sound_M80;
        private System.Windows.Forms.CheckBox Tab_Sound_M60;
        private System.Windows.Forms.CheckBox Tab_Sound_M45;
        private System.Windows.Forms.Label Tab_Tweet_Text3;
        private System.Windows.Forms.TextBox Tab_Tweet_AccSec;
        private System.Windows.Forms.TextBox Tab_Tweet_AccTok;
        private System.Windows.Forms.TextBox Tab_Tweet_ConSec;
        private System.Windows.Forms.TextBox Tab_Tweet_ConKey;
        private System.Windows.Forms.CheckBox Tab_Tweet_Enable;
        private System.Windows.Forms.Label Tab_Tweet_Text;
        private System.Windows.Forms.NumericUpDown Tab_Yomi_LowerMMI;
        private System.Windows.Forms.NumericUpDown Tab_Yomi_LowerMag;
        private System.Windows.Forms.NumericUpDown Tab_Yomi_Port;
        private System.Windows.Forms.TextBox Tab_Yomi_Host;
        private System.Windows.Forms.Button Tab_Yomi_Test;
        private System.Windows.Forms.NumericUpDown Tab_Yomi_Volume;
        private System.Windows.Forms.NumericUpDown Tab_Yomi_Tone;
        private System.Windows.Forms.NumericUpDown Tab_Yomi_Speed;
        private System.Windows.Forms.CheckBox Tab_Yomi_Enable;
        private System.Windows.Forms.Label Tab_Yomi_Text;
        private System.Windows.Forms.RadioButton Tab_Yomi_LowerAnd;
        private System.Windows.Forms.RadioButton Tab_Yomi_LowerOr;
        private System.Windows.Forms.RadioButton Tab_Tweet_LowerOr;
        private System.Windows.Forms.RadioButton Tab_Tweet_LowerAnd;
        private System.Windows.Forms.NumericUpDown Tab_Tweet_LowerMag;
        private System.Windows.Forms.NumericUpDown Tab_Tweet_LowerMMI;
        private System.Windows.Forms.CheckBox Tab_Tweet_ViewToken;
        private System.Windows.Forms.Label Tab_Tweet_Text2;
        private System.Windows.Forms.NumericUpDown Tab_Yomi_Voice;
        private System.Windows.Forms.Label Tab_Yomi_Text2;
        private System.Windows.Forms.NumericUpDown Tab_Socket_Port;
        private System.Windows.Forms.TextBox Tab_Socket_Host;
        private System.Windows.Forms.Label Tab_Socket_Text;
        private System.Windows.Forms.Button Tab_Tweet_Test;
        private System.Windows.Forms.TextBox Tab_Socket_TextFormat;
        private System.Windows.Forms.Button Tab_Sound_Test_M45;
        private System.Windows.Forms.Button Tab_Sound_Test_M80u;
        private System.Windows.Forms.Button Tab_Sound_Test_M60u;
        private System.Windows.Forms.Button Tab_Sound_Test_M45u;
        private System.Windows.Forms.Button Tab_Sound_Test_M80;
        private System.Windows.Forms.Button Tab_Sound_Test_M60;
        private System.Windows.Forms.CheckBox Tab_Socket_Enable;
        private System.Windows.Forms.Button Tab_Socket_Test;
        private System.Windows.Forms.TabPage Tab_ProInfo;
        private System.Windows.Forms.Label Tab_ProInfo_Text;
        private System.Windows.Forms.Timer ProInfoChange;
        private System.Windows.Forms.CheckBox Tab_View_LogEnable;
        private System.Windows.Forms.TabPage Tab_Update;
        private System.Windows.Forms.Label Tab_Update_Text;
        private System.Windows.Forms.CheckBox Tab_Update_HypoEN;
        private System.Windows.Forms.CheckBox Tab_Update_HypoJP;
        private System.Windows.Forms.CheckBox Tab_Update_LatLon;
        private System.Windows.Forms.CheckBox Tab_Update_Alert;
        private System.Windows.Forms.CheckBox Tab_Update_MMI;
        private System.Windows.Forms.CheckBox Tab_Update_Mag;
        private System.Windows.Forms.CheckBox Tab_Update_MagType;
        private System.Windows.Forms.CheckBox Tab_Update_Depth;
        private System.Windows.Forms.CheckBox Tab_Update_Time;
        private System.Windows.Forms.NumericUpDown Tab_View_LogTime;
    }
}
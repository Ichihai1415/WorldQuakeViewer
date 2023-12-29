namespace WorldQuakeViewer
{
    partial class CtrlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlForm));
            this.TabCtrl_Main = new System.Windows.Forms.TabControl();
            this.Tab_Main_Info = new System.Windows.Forms.TabPage();
            this.InfoPageLink = new System.Windows.Forms.LinkLabel();
            this.InfoText0 = new System.Windows.Forms.Label();
            this.InfoText1 = new System.Windows.Forms.Label();
            this.Tab_Main_Log = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.Tab_Main_Tool = new System.Windows.Forms.TabPage();
            this.MapGenOpen = new System.Windows.Forms.Button();
            this.GroupBox_ConfigMerge = new System.Windows.Forms.GroupBox();
            this.ConfigMerge_CurrentDir = new System.Windows.Forms.Button();
            this.ConfigMerge_Write = new System.Windows.Forms.Button();
            this.ConfigMerge_Read = new System.Windows.Forms.Button();
            this.ConfigMerge_Select3 = new System.Windows.Forms.ComboBox();
            this.ConfigMerge_Select2 = new System.Windows.Forms.NumericUpDown();
            this.ConfigMerge_Text2 = new System.Windows.Forms.Label();
            this.ConfigMerge_PathBox = new System.Windows.Forms.TextBox();
            this.ConfigMerge_Select1 = new System.Windows.Forms.ComboBox();
            this.ConfigMerge_Text = new System.Windows.Forms.Label();
            this.GroupBox_IntConv = new System.Windows.Forms.GroupBox();
            this.IntConv_Conv4 = new System.Windows.Forms.Button();
            this.IntConv_Conv2 = new System.Windows.Forms.Button();
            this.IntConv_Link = new System.Windows.Forms.LinkLabel();
            this.IntConv_Text = new System.Windows.Forms.Label();
            this.IntConv_Conv3 = new System.Windows.Forms.Button();
            this.IntConv_Conv1 = new System.Windows.Forms.Button();
            this.IntConv_NumBox3 = new System.Windows.Forms.NumericUpDown();
            this.IntConv_NumBox2 = new System.Windows.Forms.NumericUpDown();
            this.IntConv_NumBox1 = new System.Windows.Forms.NumericUpDown();
            this.IntConv_ComBox3 = new System.Windows.Forms.ComboBox();
            this.IntConv_ComBox2 = new System.Windows.Forms.ComboBox();
            this.IntConv_ComBox1 = new System.Windows.Forms.ComboBox();
            this.Tab_Main_Setting = new System.Windows.Forms.TabPage();
            this.ConfigNoFirstCheck = new System.Windows.Forms.CheckBox();
            this.Config_Reset = new System.Windows.Forms.Button();
            this.Config_Save = new System.Windows.Forms.Button();
            this.ConfigWebLink = new System.Windows.Forms.LinkLabel();
            this.ConfigInfoText = new System.Windows.Forms.Label();
            this.TabCtrl_Setting = new System.Windows.Forms.TabControl();
            this.Tab_Setting_Pro = new System.Windows.Forms.TabPage();
            this.ProG_pro_ClearHist = new System.Windows.Forms.Button();
            this.ProG_pro_Text1 = new System.Windows.Forms.Label();
            this.ProG_pro = new System.Windows.Forms.PropertyGrid();
            this.Tab_Setting_View = new System.Windows.Forms.TabPage();
            this.ProG_view_OpenAll = new System.Windows.Forms.Button();
            this.ProG_view_Open = new System.Windows.Forms.Button();
            this.ProG_view_OpenNum = new System.Windows.Forms.NumericUpDown();
            this.ProG_view_CopyNum = new System.Windows.Forms.NumericUpDown();
            this.ProG_view_Copy = new System.Windows.Forms.Button();
            this.ProG_view_Text1 = new System.Windows.Forms.Label();
            this.ProG_view_Delete = new System.Windows.Forms.Button();
            this.ProG_view_Add = new System.Windows.Forms.Button();
            this.ProG_view = new System.Windows.Forms.PropertyGrid();
            this.Tab_Setting_Other = new System.Windows.Forms.TabPage();
            this.ProG_other = new System.Windows.Forms.PropertyGrid();
            this.GetTimer = new System.Windows.Forms.Timer(this.components);
            this.LogClearTimer = new System.Windows.Forms.Timer(this.components);
            this.UpdtProEnabler = new System.Windows.Forms.Timer(this.components);
            this.TabCtrl_Main.SuspendLayout();
            this.Tab_Main_Info.SuspendLayout();
            this.Tab_Main_Log.SuspendLayout();
            this.Tab_Main_Tool.SuspendLayout();
            this.GroupBox_ConfigMerge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigMerge_Select2)).BeginInit();
            this.GroupBox_IntConv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntConv_NumBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntConv_NumBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntConv_NumBox1)).BeginInit();
            this.Tab_Main_Setting.SuspendLayout();
            this.TabCtrl_Setting.SuspendLayout();
            this.Tab_Setting_Pro.SuspendLayout();
            this.Tab_Setting_View.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProG_view_OpenNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProG_view_CopyNum)).BeginInit();
            this.Tab_Setting_Other.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabCtrl_Main
            // 
            this.TabCtrl_Main.Controls.Add(this.Tab_Main_Info);
            this.TabCtrl_Main.Controls.Add(this.Tab_Main_Log);
            this.TabCtrl_Main.Controls.Add(this.Tab_Main_Tool);
            this.TabCtrl_Main.Controls.Add(this.Tab_Main_Setting);
            this.TabCtrl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCtrl_Main.Location = new System.Drawing.Point(0, 0);
            this.TabCtrl_Main.Name = "TabCtrl_Main";
            this.TabCtrl_Main.SelectedIndex = 0;
            this.TabCtrl_Main.Size = new System.Drawing.Size(500, 500);
            this.TabCtrl_Main.TabIndex = 0;
            // 
            // Tab_Main_Info
            // 
            this.Tab_Main_Info.Controls.Add(this.InfoPageLink);
            this.Tab_Main_Info.Controls.Add(this.InfoText0);
            this.Tab_Main_Info.Controls.Add(this.InfoText1);
            this.Tab_Main_Info.Location = new System.Drawing.Point(4, 27);
            this.Tab_Main_Info.Name = "Tab_Main_Info";
            this.Tab_Main_Info.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Main_Info.Size = new System.Drawing.Size(492, 469);
            this.Tab_Main_Info.TabIndex = 1;
            this.Tab_Main_Info.Text = "情報";
            this.Tab_Main_Info.UseVisualStyleBackColor = true;
            // 
            // InfoPageLink
            // 
            this.InfoPageLink.AutoSize = true;
            this.InfoPageLink.Font = new System.Drawing.Font("メイリオ", 12F);
            this.InfoPageLink.Location = new System.Drawing.Point(3, 40);
            this.InfoPageLink.Name = "InfoPageLink";
            this.InfoPageLink.Size = new System.Drawing.Size(168, 24);
            this.InfoPageLink.TabIndex = 2;
            this.InfoPageLink.TabStop = true;
            this.InfoPageLink.Text = "解説ページ(確認推奨)";
            this.InfoPageLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.InfoPageLink_LinkClicked);
            // 
            // InfoText0
            // 
            this.InfoText0.AutoSize = true;
            this.InfoText0.Font = new System.Drawing.Font("メイリオ", 20F);
            this.InfoText0.Location = new System.Drawing.Point(0, 0);
            this.InfoText0.Name = "InfoText0";
            this.InfoText0.Size = new System.Drawing.Size(362, 41);
            this.InfoText0.TabIndex = 1;
            this.InfoText0.Text = "WorldQuakeViewer v0.0.0";
            // 
            // InfoText1
            // 
            this.InfoText1.AutoSize = true;
            this.InfoText1.Font = new System.Drawing.Font("メイリオ", 9F);
            this.InfoText1.Location = new System.Drawing.Point(4, 80);
            this.InfoText1.Name = "InfoText1";
            this.InfoText1.Size = new System.Drawing.Size(490, 342);
            this.InfoText1.TabIndex = 0;
            this.InfoText1.Text = resources.GetString("InfoText1.Text");
            // 
            // Tab_Main_Log
            // 
            this.Tab_Main_Log.Controls.Add(this.LogTextBox);
            this.Tab_Main_Log.Location = new System.Drawing.Point(4, 22);
            this.Tab_Main_Log.Name = "Tab_Main_Log";
            this.Tab_Main_Log.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Main_Log.Size = new System.Drawing.Size(492, 474);
            this.Tab_Main_Log.TabIndex = 0;
            this.Tab_Main_Log.Text = "ログ";
            this.Tab_Main_Log.UseVisualStyleBackColor = true;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(0, 0);
            this.LogTextBox.MaxLength = 0;
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(492, 469);
            this.LogTextBox.TabIndex = 0;
            // 
            // Tab_Main_Tool
            // 
            this.Tab_Main_Tool.Controls.Add(this.MapGenOpen);
            this.Tab_Main_Tool.Controls.Add(this.GroupBox_ConfigMerge);
            this.Tab_Main_Tool.Controls.Add(this.GroupBox_IntConv);
            this.Tab_Main_Tool.Location = new System.Drawing.Point(4, 27);
            this.Tab_Main_Tool.Name = "Tab_Main_Tool";
            this.Tab_Main_Tool.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Main_Tool.Size = new System.Drawing.Size(492, 469);
            this.Tab_Main_Tool.TabIndex = 3;
            this.Tab_Main_Tool.Text = "ツール";
            this.Tab_Main_Tool.UseVisualStyleBackColor = true;
            // 
            // MapGenOpen
            // 
            this.MapGenOpen.Location = new System.Drawing.Point(35, 424);
            this.MapGenOpen.Name = "MapGenOpen";
            this.MapGenOpen.Size = new System.Drawing.Size(112, 23);
            this.MapGenOpen.TabIndex = 2;
            this.MapGenOpen.Text = "マップ生成ツール";
            this.MapGenOpen.UseVisualStyleBackColor = true;
            this.MapGenOpen.Click += new System.EventHandler(this.MapGenOpen_Click);
            // 
            // GroupBox_ConfigMerge
            // 
            this.GroupBox_ConfigMerge.Controls.Add(this.ConfigMerge_CurrentDir);
            this.GroupBox_ConfigMerge.Controls.Add(this.ConfigMerge_Write);
            this.GroupBox_ConfigMerge.Controls.Add(this.ConfigMerge_Read);
            this.GroupBox_ConfigMerge.Controls.Add(this.ConfigMerge_Select3);
            this.GroupBox_ConfigMerge.Controls.Add(this.ConfigMerge_Select2);
            this.GroupBox_ConfigMerge.Controls.Add(this.ConfigMerge_Text2);
            this.GroupBox_ConfigMerge.Controls.Add(this.ConfigMerge_PathBox);
            this.GroupBox_ConfigMerge.Controls.Add(this.ConfigMerge_Select1);
            this.GroupBox_ConfigMerge.Controls.Add(this.ConfigMerge_Text);
            this.GroupBox_ConfigMerge.Location = new System.Drawing.Point(8, 138);
            this.GroupBox_ConfigMerge.Name = "GroupBox_ConfigMerge";
            this.GroupBox_ConfigMerge.Size = new System.Drawing.Size(478, 124);
            this.GroupBox_ConfigMerge.TabIndex = 1;
            this.GroupBox_ConfigMerge.TabStop = false;
            this.GroupBox_ConfigMerge.Text = "設定結合ツール";
            // 
            // ConfigMerge_CurrentDir
            // 
            this.ConfigMerge_CurrentDir.Location = new System.Drawing.Point(408, 60);
            this.ConfigMerge_CurrentDir.Name = "ConfigMerge_CurrentDir";
            this.ConfigMerge_CurrentDir.Size = new System.Drawing.Size(64, 25);
            this.ConfigMerge_CurrentDir.TabIndex = 8;
            this.ConfigMerge_CurrentDir.Text = "current";
            this.ConfigMerge_CurrentDir.UseVisualStyleBackColor = true;
            this.ConfigMerge_CurrentDir.Click += new System.EventHandler(this.ConfigMerge_CurrentDir_Click);
            // 
            // ConfigMerge_Write
            // 
            this.ConfigMerge_Write.Location = new System.Drawing.Point(408, 90);
            this.ConfigMerge_Write.Name = "ConfigMerge_Write";
            this.ConfigMerge_Write.Size = new System.Drawing.Size(64, 26);
            this.ConfigMerge_Write.TabIndex = 7;
            this.ConfigMerge_Write.Text = "書き出す";
            this.ConfigMerge_Write.UseVisualStyleBackColor = true;
            this.ConfigMerge_Write.Click += new System.EventHandler(this.ConfigMerge_Write_Click);
            // 
            // ConfigMerge_Read
            // 
            this.ConfigMerge_Read.Location = new System.Drawing.Point(344, 90);
            this.ConfigMerge_Read.Name = "ConfigMerge_Read";
            this.ConfigMerge_Read.Size = new System.Drawing.Size(64, 26);
            this.ConfigMerge_Read.TabIndex = 6;
            this.ConfigMerge_Read.Text = "読み込む";
            this.ConfigMerge_Read.UseVisualStyleBackColor = true;
            this.ConfigMerge_Read.Click += new System.EventHandler(this.ConfigMerge_Read_Click);
            // 
            // ConfigMerge_Select3
            // 
            this.ConfigMerge_Select3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConfigMerge_Select3.FormattingEnabled = true;
            this.ConfigMerge_Select3.Location = new System.Drawing.Point(157, 90);
            this.ConfigMerge_Select3.Name = "ConfigMerge_Select3";
            this.ConfigMerge_Select3.Size = new System.Drawing.Size(100, 26);
            this.ConfigMerge_Select3.TabIndex = 5;
            // 
            // ConfigMerge_Select2
            // 
            this.ConfigMerge_Select2.Location = new System.Drawing.Point(107, 90);
            this.ConfigMerge_Select2.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.ConfigMerge_Select2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.ConfigMerge_Select2.Name = "ConfigMerge_Select2";
            this.ConfigMerge_Select2.Size = new System.Drawing.Size(32, 25);
            this.ConfigMerge_Select2.TabIndex = 4;
            // 
            // ConfigMerge_Text2
            // 
            this.ConfigMerge_Text2.AutoSize = true;
            this.ConfigMerge_Text2.Location = new System.Drawing.Point(6, 63);
            this.ConfigMerge_Text2.Name = "ConfigMerge_Text2";
            this.ConfigMerge_Text2.Size = new System.Drawing.Size(37, 18);
            this.ConfigMerge_Text2.TabIndex = 3;
            this.ConfigMerge_Text2.Text = "パス:";
            // 
            // ConfigMerge_PathBox
            // 
            this.ConfigMerge_PathBox.Location = new System.Drawing.Point(42, 60);
            this.ConfigMerge_PathBox.Name = "ConfigMerge_PathBox";
            this.ConfigMerge_PathBox.Size = new System.Drawing.Size(366, 25);
            this.ConfigMerge_PathBox.TabIndex = 2;
            // 
            // ConfigMerge_Select1
            // 
            this.ConfigMerge_Select1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConfigMerge_Select1.FormattingEnabled = true;
            this.ConfigMerge_Select1.Items.AddRange(new object[] {
            "Data",
            "View",
            "Other"});
            this.ConfigMerge_Select1.Location = new System.Drawing.Point(7, 90);
            this.ConfigMerge_Select1.Name = "ConfigMerge_Select1";
            this.ConfigMerge_Select1.Size = new System.Drawing.Size(100, 26);
            this.ConfigMerge_Select1.TabIndex = 1;
            this.ConfigMerge_Select1.SelectionChangeCommitted += new System.EventHandler(this.ConfigMerge_Select1_SelectionChangeCommitted);
            // 
            // ConfigMerge_Text
            // 
            this.ConfigMerge_Text.AutoSize = true;
            this.ConfigMerge_Text.Location = new System.Drawing.Point(6, 21);
            this.ConfigMerge_Text.Name = "ConfigMerge_Text";
            this.ConfigMerge_Text.Size = new System.Drawing.Size(464, 90);
            this.ConfigMerge_Text.TabIndex = 0;
            this.ConfigMerge_Text.Text = "部分的な設定のファイルの読み込みや書き出しができます。\r\n設定は上書きされるので注意してください。設定例を詳細ページで公開しています。\r\n\r\n\r\n        " +
    "                         の                           を";
            // 
            // GroupBox_IntConv
            // 
            this.GroupBox_IntConv.Controls.Add(this.IntConv_Conv4);
            this.GroupBox_IntConv.Controls.Add(this.IntConv_Conv2);
            this.GroupBox_IntConv.Controls.Add(this.IntConv_Link);
            this.GroupBox_IntConv.Controls.Add(this.IntConv_Text);
            this.GroupBox_IntConv.Controls.Add(this.IntConv_Conv3);
            this.GroupBox_IntConv.Controls.Add(this.IntConv_Conv1);
            this.GroupBox_IntConv.Controls.Add(this.IntConv_NumBox3);
            this.GroupBox_IntConv.Controls.Add(this.IntConv_NumBox2);
            this.GroupBox_IntConv.Controls.Add(this.IntConv_NumBox1);
            this.GroupBox_IntConv.Controls.Add(this.IntConv_ComBox3);
            this.GroupBox_IntConv.Controls.Add(this.IntConv_ComBox2);
            this.GroupBox_IntConv.Controls.Add(this.IntConv_ComBox1);
            this.GroupBox_IntConv.Location = new System.Drawing.Point(8, 6);
            this.GroupBox_IntConv.Name = "GroupBox_IntConv";
            this.GroupBox_IntConv.Size = new System.Drawing.Size(478, 126);
            this.GroupBox_IntConv.TabIndex = 0;
            this.GroupBox_IntConv.TabStop = false;
            this.GroupBox_IntConv.Text = "震度変換ツール";
            // 
            // IntConv_Conv4
            // 
            this.IntConv_Conv4.Location = new System.Drawing.Point(318, 56);
            this.IntConv_Conv4.Name = "IntConv_Conv4";
            this.IntConv_Conv4.Size = new System.Drawing.Size(25, 25);
            this.IntConv_Conv4.TabIndex = 13;
            this.IntConv_Conv4.Text = "→";
            this.IntConv_Conv4.UseVisualStyleBackColor = true;
            this.IntConv_Conv4.Click += new System.EventHandler(this.IntConv_Conv4_Click);
            // 
            // IntConv_Conv2
            // 
            this.IntConv_Conv2.Location = new System.Drawing.Point(160, 56);
            this.IntConv_Conv2.Name = "IntConv_Conv2";
            this.IntConv_Conv2.Size = new System.Drawing.Size(25, 25);
            this.IntConv_Conv2.TabIndex = 12;
            this.IntConv_Conv2.Text = "→";
            this.IntConv_Conv2.UseVisualStyleBackColor = true;
            this.IntConv_Conv2.Click += new System.EventHandler(this.IntConv_Conv2_Click);
            // 
            // IntConv_Link
            // 
            this.IntConv_Link.AutoSize = true;
            this.IntConv_Link.Location = new System.Drawing.Point(175, 84);
            this.IntConv_Link.Name = "IntConv_Link";
            this.IntConv_Link.Size = new System.Drawing.Size(56, 18);
            this.IntConv_Link.TabIndex = 11;
            this.IntConv_Link.TabStop = true;
            this.IntConv_Link.Text = "式の詳細";
            this.IntConv_Link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IntConv_Link_LinkClicked);
            // 
            // IntConv_Text
            // 
            this.IntConv_Text.AutoSize = true;
            this.IntConv_Text.Location = new System.Drawing.Point(6, 84);
            this.IntConv_Text.Name = "IntConv_Text";
            this.IntConv_Text.Size = new System.Drawing.Size(460, 36);
            this.IntConv_Text.TabIndex = 10;
            this.IntConv_Text.Text = "参考程度に利用してください。\r\n最大速度と気象庁震度階級との変換は藤本･翠川(2005)の換算式を利用しています。";
            // 
            // IntConv_Conv3
            // 
            this.IntConv_Conv3.Location = new System.Drawing.Point(293, 56);
            this.IntConv_Conv3.Name = "IntConv_Conv3";
            this.IntConv_Conv3.Size = new System.Drawing.Size(25, 25);
            this.IntConv_Conv3.TabIndex = 9;
            this.IntConv_Conv3.Text = "←";
            this.IntConv_Conv3.UseVisualStyleBackColor = true;
            this.IntConv_Conv3.Click += new System.EventHandler(this.IntConv_Conv3_Click);
            // 
            // IntConv_Conv1
            // 
            this.IntConv_Conv1.Location = new System.Drawing.Point(135, 56);
            this.IntConv_Conv1.Name = "IntConv_Conv1";
            this.IntConv_Conv1.Size = new System.Drawing.Size(25, 25);
            this.IntConv_Conv1.TabIndex = 8;
            this.IntConv_Conv1.Text = "←";
            this.IntConv_Conv1.UseVisualStyleBackColor = true;
            this.IntConv_Conv1.Click += new System.EventHandler(this.IntConv_Conv1_Click);
            // 
            // IntConv_NumBox3
            // 
            this.IntConv_NumBox3.DecimalPlaces = 3;
            this.IntConv_NumBox3.Location = new System.Drawing.Point(367, 56);
            this.IntConv_NumBox3.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.IntConv_NumBox3.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147352576});
            this.IntConv_NumBox3.Name = "IntConv_NumBox3";
            this.IntConv_NumBox3.Size = new System.Drawing.Size(60, 25);
            this.IntConv_NumBox3.TabIndex = 7;
            this.IntConv_NumBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IntConv_NumBox2
            // 
            this.IntConv_NumBox2.DecimalPlaces = 3;
            this.IntConv_NumBox2.Location = new System.Drawing.Point(209, 56);
            this.IntConv_NumBox2.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.IntConv_NumBox2.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147352576});
            this.IntConv_NumBox2.Name = "IntConv_NumBox2";
            this.IntConv_NumBox2.Size = new System.Drawing.Size(60, 25);
            this.IntConv_NumBox2.TabIndex = 6;
            this.IntConv_NumBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IntConv_NumBox1
            // 
            this.IntConv_NumBox1.DecimalPlaces = 3;
            this.IntConv_NumBox1.Location = new System.Drawing.Point(51, 56);
            this.IntConv_NumBox1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.IntConv_NumBox1.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147352576});
            this.IntConv_NumBox1.Name = "IntConv_NumBox1";
            this.IntConv_NumBox1.Size = new System.Drawing.Size(60, 25);
            this.IntConv_NumBox1.TabIndex = 5;
            this.IntConv_NumBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IntConv_ComBox3
            // 
            this.IntConv_ComBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IntConv_ComBox3.FormattingEnabled = true;
            this.IntConv_ComBox3.Items.AddRange(new object[] {
            "改正メルカリ震度階級",
            "最大速度(cm/s)",
            "気象庁震度階級"});
            this.IntConv_ComBox3.Location = new System.Drawing.Point(322, 24);
            this.IntConv_ComBox3.Name = "IntConv_ComBox3";
            this.IntConv_ComBox3.Size = new System.Drawing.Size(150, 26);
            this.IntConv_ComBox3.TabIndex = 2;
            // 
            // IntConv_ComBox2
            // 
            this.IntConv_ComBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IntConv_ComBox2.FormattingEnabled = true;
            this.IntConv_ComBox2.Items.AddRange(new object[] {
            "改正メルカリ震度階級",
            "最大速度(cm/s)",
            "気象庁震度階級"});
            this.IntConv_ComBox2.Location = new System.Drawing.Point(164, 24);
            this.IntConv_ComBox2.Name = "IntConv_ComBox2";
            this.IntConv_ComBox2.Size = new System.Drawing.Size(150, 26);
            this.IntConv_ComBox2.TabIndex = 1;
            // 
            // IntConv_ComBox1
            // 
            this.IntConv_ComBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IntConv_ComBox1.FormattingEnabled = true;
            this.IntConv_ComBox1.Items.AddRange(new object[] {
            "改正メルカリ震度階級",
            "最大速度(cm/s)",
            "気象庁震度階級"});
            this.IntConv_ComBox1.Location = new System.Drawing.Point(6, 24);
            this.IntConv_ComBox1.Name = "IntConv_ComBox1";
            this.IntConv_ComBox1.Size = new System.Drawing.Size(150, 26);
            this.IntConv_ComBox1.TabIndex = 0;
            // 
            // Tab_Main_Setting
            // 
            this.Tab_Main_Setting.Controls.Add(this.ConfigNoFirstCheck);
            this.Tab_Main_Setting.Controls.Add(this.Config_Reset);
            this.Tab_Main_Setting.Controls.Add(this.Config_Save);
            this.Tab_Main_Setting.Controls.Add(this.ConfigWebLink);
            this.Tab_Main_Setting.Controls.Add(this.ConfigInfoText);
            this.Tab_Main_Setting.Controls.Add(this.TabCtrl_Setting);
            this.Tab_Main_Setting.Location = new System.Drawing.Point(4, 22);
            this.Tab_Main_Setting.Name = "Tab_Main_Setting";
            this.Tab_Main_Setting.Size = new System.Drawing.Size(492, 474);
            this.Tab_Main_Setting.TabIndex = 2;
            this.Tab_Main_Setting.Text = "設定";
            this.Tab_Main_Setting.UseVisualStyleBackColor = true;
            // 
            // ConfigNoFirstCheck
            // 
            this.ConfigNoFirstCheck.AutoSize = true;
            this.ConfigNoFirstCheck.ForeColor = System.Drawing.Color.Red;
            this.ConfigNoFirstCheck.Location = new System.Drawing.Point(161, 448);
            this.ConfigNoFirstCheck.Name = "ConfigNoFirstCheck";
            this.ConfigNoFirstCheck.Size = new System.Drawing.Size(181, 22);
            this.ConfigNoFirstCheck.TabIndex = 5;
            this.ConfigNoFirstCheck.Text = "更新処理無効(内部変更あり)";
            this.ConfigNoFirstCheck.UseVisualStyleBackColor = true;
            this.ConfigNoFirstCheck.CheckedChanged += new System.EventHandler(this.ConfigNoFirstCheck_CheckedChanged);
            // 
            // Config_Reset
            // 
            this.Config_Reset.Location = new System.Drawing.Point(417, 446);
            this.Config_Reset.Name = "Config_Reset";
            this.Config_Reset.Size = new System.Drawing.Size(75, 23);
            this.Config_Reset.TabIndex = 4;
            this.Config_Reset.Text = "リセット";
            this.Config_Reset.UseVisualStyleBackColor = true;
            this.Config_Reset.Click += new System.EventHandler(this.Config_Reset_Click);
            // 
            // Config_Save
            // 
            this.Config_Save.Location = new System.Drawing.Point(342, 446);
            this.Config_Save.Name = "Config_Save";
            this.Config_Save.Size = new System.Drawing.Size(75, 23);
            this.Config_Save.TabIndex = 3;
            this.Config_Save.Text = "保存";
            this.Config_Save.UseVisualStyleBackColor = true;
            this.Config_Save.Click += new System.EventHandler(this.Config_Save_Click);
            // 
            // ConfigWebLink
            // 
            this.ConfigWebLink.AutoSize = true;
            this.ConfigWebLink.Font = new System.Drawing.Font("メイリオ", 10F);
            this.ConfigWebLink.Location = new System.Drawing.Point(358, 405);
            this.ConfigWebLink.Name = "ConfigWebLink";
            this.ConfigWebLink.Size = new System.Drawing.Size(134, 21);
            this.ConfigWebLink.TabIndex = 2;
            this.ConfigWebLink.TabStop = true;
            this.ConfigWebLink.Text = "設定の詳細(要確認)";
            this.ConfigWebLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ConfigWebLink_LinkClicked);
            // 
            // ConfigInfoText
            // 
            this.ConfigInfoText.AutoSize = true;
            this.ConfigInfoText.Location = new System.Drawing.Point(4, 373);
            this.ConfigInfoText.Name = "ConfigInfoText";
            this.ConfigInfoText.Size = new System.Drawing.Size(488, 90);
            this.ConfigInfoText.TabIndex = 1;
            this.ConfigInfoText.Text = "> ←これを押して展開してください。保存を押さないと反映されません。\r\n《処理》取得先別の処理の設定。Otherは処理できれば自由です。\r\n《表示》表示する処理の" +
    "設定。[0]はコピー用で表示されません。\r\n追加を押して画面を追加できます。削除は一番最後のを削除するので注意してください。\r\n《その他》上記以外の設定。   " +
    "      ";
            // 
            // TabCtrl_Setting
            // 
            this.TabCtrl_Setting.Controls.Add(this.Tab_Setting_Pro);
            this.TabCtrl_Setting.Controls.Add(this.Tab_Setting_View);
            this.TabCtrl_Setting.Controls.Add(this.Tab_Setting_Other);
            this.TabCtrl_Setting.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabCtrl_Setting.Location = new System.Drawing.Point(0, 0);
            this.TabCtrl_Setting.Name = "TabCtrl_Setting";
            this.TabCtrl_Setting.SelectedIndex = 0;
            this.TabCtrl_Setting.Size = new System.Drawing.Size(492, 369);
            this.TabCtrl_Setting.TabIndex = 0;
            // 
            // Tab_Setting_Pro
            // 
            this.Tab_Setting_Pro.Controls.Add(this.ProG_pro_ClearHist);
            this.Tab_Setting_Pro.Controls.Add(this.ProG_pro_Text1);
            this.Tab_Setting_Pro.Controls.Add(this.ProG_pro);
            this.Tab_Setting_Pro.Location = new System.Drawing.Point(4, 27);
            this.Tab_Setting_Pro.Name = "Tab_Setting_Pro";
            this.Tab_Setting_Pro.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Setting_Pro.Size = new System.Drawing.Size(484, 338);
            this.Tab_Setting_Pro.TabIndex = 1;
            this.Tab_Setting_Pro.Text = "処理";
            this.Tab_Setting_Pro.UseVisualStyleBackColor = true;
            // 
            // ProG_pro_ClearHist
            // 
            this.ProG_pro_ClearHist.Location = new System.Drawing.Point(393, 3);
            this.ProG_pro_ClearHist.Name = "ProG_pro_ClearHist";
            this.ProG_pro_ClearHist.Size = new System.Drawing.Size(88, 23);
            this.ProG_pro_ClearHist.TabIndex = 6;
            this.ProG_pro_ClearHist.Text = "履歴のクリア";
            this.ProG_pro_ClearHist.UseVisualStyleBackColor = true;
            this.ProG_pro_ClearHist.Click += new System.EventHandler(this.ProG_pro_ClearHist_Click);
            // 
            // ProG_pro_Text1
            // 
            this.ProG_pro_Text1.AutoSize = true;
            this.ProG_pro_Text1.BackColor = System.Drawing.SystemColors.Control;
            this.ProG_pro_Text1.Location = new System.Drawing.Point(86, 7);
            this.ProG_pro_Text1.Name = "ProG_pro_Text1";
            this.ProG_pro_Text1.Size = new System.Drawing.Size(269, 18);
            this.ProG_pro_Text1.TabIndex = 1;
            this.ProG_pro_Text1.Text = "取得先名は展開して\"Name\"のところにあります";
            // 
            // ProG_pro
            // 
            this.ProG_pro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProG_pro.Location = new System.Drawing.Point(3, 3);
            this.ProG_pro.Name = "ProG_pro";
            this.ProG_pro.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.ProG_pro.Size = new System.Drawing.Size(478, 332);
            this.ProG_pro.TabIndex = 0;
            // 
            // Tab_Setting_View
            // 
            this.Tab_Setting_View.Controls.Add(this.ProG_view_OpenAll);
            this.Tab_Setting_View.Controls.Add(this.ProG_view_Open);
            this.Tab_Setting_View.Controls.Add(this.ProG_view_OpenNum);
            this.Tab_Setting_View.Controls.Add(this.ProG_view_CopyNum);
            this.Tab_Setting_View.Controls.Add(this.ProG_view_Copy);
            this.Tab_Setting_View.Controls.Add(this.ProG_view_Text1);
            this.Tab_Setting_View.Controls.Add(this.ProG_view_Delete);
            this.Tab_Setting_View.Controls.Add(this.ProG_view_Add);
            this.Tab_Setting_View.Controls.Add(this.ProG_view);
            this.Tab_Setting_View.Location = new System.Drawing.Point(4, 22);
            this.Tab_Setting_View.Name = "Tab_Setting_View";
            this.Tab_Setting_View.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Setting_View.Size = new System.Drawing.Size(484, 343);
            this.Tab_Setting_View.TabIndex = 2;
            this.Tab_Setting_View.Text = "表示";
            this.Tab_Setting_View.UseVisualStyleBackColor = true;
            // 
            // ProG_view_OpenAll
            // 
            this.ProG_view_OpenAll.Font = new System.Drawing.Font("メイリオ", 9F);
            this.ProG_view_OpenAll.Location = new System.Drawing.Point(427, 4);
            this.ProG_view_OpenAll.Name = "ProG_view_OpenAll";
            this.ProG_view_OpenAll.Size = new System.Drawing.Size(52, 23);
            this.ProG_view_OpenAll.TabIndex = 9;
            this.ProG_view_OpenAll.Text = "全表示";
            this.ProG_view_OpenAll.UseVisualStyleBackColor = true;
            this.ProG_view_OpenAll.Click += new System.EventHandler(this.ProG_view_OpenAll_Click);
            // 
            // ProG_view_Open
            // 
            this.ProG_view_Open.Font = new System.Drawing.Font("メイリオ", 9F);
            this.ProG_view_Open.Location = new System.Drawing.Point(380, 4);
            this.ProG_view_Open.Name = "ProG_view_Open";
            this.ProG_view_Open.Size = new System.Drawing.Size(40, 23);
            this.ProG_view_Open.TabIndex = 8;
            this.ProG_view_Open.Text = "表示";
            this.ProG_view_Open.UseVisualStyleBackColor = true;
            this.ProG_view_Open.Click += new System.EventHandler(this.ProG_view_Open_Click);
            // 
            // ProG_view_OpenNum
            // 
            this.ProG_view_OpenNum.Location = new System.Drawing.Point(335, 3);
            this.ProG_view_OpenNum.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.ProG_view_OpenNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ProG_view_OpenNum.Name = "ProG_view_OpenNum";
            this.ProG_view_OpenNum.Size = new System.Drawing.Size(30, 25);
            this.ProG_view_OpenNum.TabIndex = 7;
            this.ProG_view_OpenNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProG_view_OpenNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ProG_view_CopyNum
            // 
            this.ProG_view_CopyNum.Location = new System.Drawing.Point(222, 3);
            this.ProG_view_CopyNum.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.ProG_view_CopyNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ProG_view_CopyNum.Name = "ProG_view_CopyNum";
            this.ProG_view_CopyNum.Size = new System.Drawing.Size(30, 25);
            this.ProG_view_CopyNum.TabIndex = 6;
            this.ProG_view_CopyNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProG_view_CopyNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ProG_view_CopyNum.ValueChanged += new System.EventHandler(this.ProG_view_CopyNum_ValueChanged);
            // 
            // ProG_view_Copy
            // 
            this.ProG_view_Copy.Font = new System.Drawing.Font("メイリオ", 9F);
            this.ProG_view_Copy.Location = new System.Drawing.Point(270, 4);
            this.ProG_view_Copy.Name = "ProG_view_Copy";
            this.ProG_view_Copy.Size = new System.Drawing.Size(55, 23);
            this.ProG_view_Copy.TabIndex = 5;
            this.ProG_view_Copy.Text = "コピー";
            this.ProG_view_Copy.UseVisualStyleBackColor = true;
            this.ProG_view_Copy.Click += new System.EventHandler(this.ProG_view_Copy_Click);
            // 
            // ProG_view_Text1
            // 
            this.ProG_view_Text1.AutoSize = true;
            this.ProG_view_Text1.BackColor = System.Drawing.SystemColors.Control;
            this.ProG_view_Text1.Location = new System.Drawing.Point(175, 7);
            this.ProG_view_Text1.Name = "ProG_view_Text1";
            this.ProG_view_Text1.Size = new System.Drawing.Size(209, 18);
            this.ProG_view_Text1.TabIndex = 4;
            this.ProG_view_Text1.Text = "[0]から　　　に　　 　　　　　　を";
            // 
            // ProG_view_Delete
            // 
            this.ProG_view_Delete.Font = new System.Drawing.Font("メイリオ", 9F);
            this.ProG_view_Delete.Location = new System.Drawing.Point(130, 4);
            this.ProG_view_Delete.Name = "ProG_view_Delete";
            this.ProG_view_Delete.Size = new System.Drawing.Size(40, 23);
            this.ProG_view_Delete.TabIndex = 3;
            this.ProG_view_Delete.Text = "削除";
            this.ProG_view_Delete.UseVisualStyleBackColor = true;
            this.ProG_view_Delete.Click += new System.EventHandler(this.ProG_view_Delete_Click);
            // 
            // ProG_view_Add
            // 
            this.ProG_view_Add.Font = new System.Drawing.Font("メイリオ", 9F);
            this.ProG_view_Add.Location = new System.Drawing.Point(90, 4);
            this.ProG_view_Add.Name = "ProG_view_Add";
            this.ProG_view_Add.Size = new System.Drawing.Size(40, 23);
            this.ProG_view_Add.TabIndex = 2;
            this.ProG_view_Add.Text = "追加";
            this.ProG_view_Add.UseVisualStyleBackColor = true;
            this.ProG_view_Add.Click += new System.EventHandler(this.ProG_view_Add_Click);
            // 
            // ProG_view
            // 
            this.ProG_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProG_view.Location = new System.Drawing.Point(3, 3);
            this.ProG_view.Name = "ProG_view";
            this.ProG_view.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.ProG_view.Size = new System.Drawing.Size(478, 337);
            this.ProG_view.TabIndex = 1;
            // 
            // Tab_Setting_Other
            // 
            this.Tab_Setting_Other.Controls.Add(this.ProG_other);
            this.Tab_Setting_Other.Location = new System.Drawing.Point(4, 22);
            this.Tab_Setting_Other.Name = "Tab_Setting_Other";
            this.Tab_Setting_Other.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Setting_Other.Size = new System.Drawing.Size(484, 343);
            this.Tab_Setting_Other.TabIndex = 3;
            this.Tab_Setting_Other.Text = "その他";
            this.Tab_Setting_Other.UseVisualStyleBackColor = true;
            // 
            // ProG_other
            // 
            this.ProG_other.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProG_other.Location = new System.Drawing.Point(3, 3);
            this.ProG_other.Name = "ProG_other";
            this.ProG_other.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.ProG_other.Size = new System.Drawing.Size(478, 337);
            this.ProG_other.TabIndex = 2;
            // 
            // GetTimer
            // 
            this.GetTimer.Tick += new System.EventHandler(this.GetTimer_Tick);
            // 
            // LogClearTimer
            // 
            this.LogClearTimer.Interval = 1000;
            this.LogClearTimer.Tick += new System.EventHandler(this.LogClearTimer_Tick);
            // 
            // UpdtProEnabler
            // 
            this.UpdtProEnabler.Interval = 60000;
            this.UpdtProEnabler.Tick += new System.EventHandler(this.UpdtProEnabler_Tick);
            // 
            // CtrlForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.TabCtrl_Main);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CtrlForm";
            this.Text = "WorldQuakeViewer - コントロール画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CtrlForm_FormClosing);
            this.Load += new System.EventHandler(this.CtrlForm_Load);
            this.TabCtrl_Main.ResumeLayout(false);
            this.Tab_Main_Info.ResumeLayout(false);
            this.Tab_Main_Info.PerformLayout();
            this.Tab_Main_Log.ResumeLayout(false);
            this.Tab_Main_Log.PerformLayout();
            this.Tab_Main_Tool.ResumeLayout(false);
            this.GroupBox_ConfigMerge.ResumeLayout(false);
            this.GroupBox_ConfigMerge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigMerge_Select2)).EndInit();
            this.GroupBox_IntConv.ResumeLayout(false);
            this.GroupBox_IntConv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntConv_NumBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntConv_NumBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntConv_NumBox1)).EndInit();
            this.Tab_Main_Setting.ResumeLayout(false);
            this.Tab_Main_Setting.PerformLayout();
            this.TabCtrl_Setting.ResumeLayout(false);
            this.Tab_Setting_Pro.ResumeLayout(false);
            this.Tab_Setting_Pro.PerformLayout();
            this.Tab_Setting_View.ResumeLayout(false);
            this.Tab_Setting_View.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProG_view_OpenNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProG_view_CopyNum)).EndInit();
            this.Tab_Setting_Other.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabCtrl_Main;
        private System.Windows.Forms.TabPage Tab_Main_Log;
        private System.Windows.Forms.TabPage Tab_Main_Info;
        private System.Windows.Forms.TabPage Tab_Main_Setting;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.TabControl TabCtrl_Setting;
        private System.Windows.Forms.TabPage Tab_Setting_Pro;
        private System.Windows.Forms.Timer GetTimer;
        private System.Windows.Forms.PropertyGrid ProG_pro;
        private System.Windows.Forms.TabPage Tab_Setting_View;
        private System.Windows.Forms.PropertyGrid ProG_view;
        private System.Windows.Forms.TabPage Tab_Setting_Other;
        private System.Windows.Forms.PropertyGrid ProG_other;
        private System.Windows.Forms.Button ProG_view_Add;
        private System.Windows.Forms.Button ProG_view_Delete;
        private System.Windows.Forms.Label ProG_view_Text1;
        private System.Windows.Forms.Label ProG_pro_Text1;
        private System.Windows.Forms.NumericUpDown ProG_view_CopyNum;
        private System.Windows.Forms.Button ProG_view_Copy;
        private System.Windows.Forms.Label ConfigInfoText;
        private System.Windows.Forms.LinkLabel ConfigWebLink;
        private System.Windows.Forms.Button Config_Reset;
        private System.Windows.Forms.Button Config_Save;
        private System.Windows.Forms.Timer LogClearTimer;
        private System.Windows.Forms.Button ProG_view_Open;
        private System.Windows.Forms.NumericUpDown ProG_view_OpenNum;
        private System.Windows.Forms.Button ProG_view_OpenAll;
        private System.Windows.Forms.Label InfoText0;
        private System.Windows.Forms.Label InfoText1;
        private System.Windows.Forms.LinkLabel InfoPageLink;
        private System.Windows.Forms.TabPage Tab_Main_Tool;
        private System.Windows.Forms.GroupBox GroupBox_IntConv;
        private System.Windows.Forms.ComboBox IntConv_ComBox1;
        private System.Windows.Forms.ComboBox IntConv_ComBox3;
        private System.Windows.Forms.ComboBox IntConv_ComBox2;
        private System.Windows.Forms.NumericUpDown IntConv_NumBox3;
        private System.Windows.Forms.NumericUpDown IntConv_NumBox2;
        private System.Windows.Forms.NumericUpDown IntConv_NumBox1;
        private System.Windows.Forms.Button IntConv_Conv3;
        private System.Windows.Forms.Button IntConv_Conv1;
        private System.Windows.Forms.Label IntConv_Text;
        private System.Windows.Forms.LinkLabel IntConv_Link;
        private System.Windows.Forms.Button IntConv_Conv4;
        private System.Windows.Forms.Button IntConv_Conv2;
        private System.Windows.Forms.GroupBox GroupBox_ConfigMerge;
        private System.Windows.Forms.Label ConfigMerge_Text;
        private System.Windows.Forms.ComboBox ConfigMerge_Select1;
        private System.Windows.Forms.NumericUpDown ConfigMerge_Select2;
        private System.Windows.Forms.Label ConfigMerge_Text2;
        private System.Windows.Forms.TextBox ConfigMerge_PathBox;
        private System.Windows.Forms.ComboBox ConfigMerge_Select3;
        private System.Windows.Forms.Button ConfigMerge_Write;
        private System.Windows.Forms.Button ConfigMerge_Read;
        private System.Windows.Forms.Button ConfigMerge_CurrentDir;
        private System.Windows.Forms.Button ProG_pro_ClearHist;
        private System.Windows.Forms.CheckBox ConfigNoFirstCheck;
        private System.Windows.Forms.Timer UpdtProEnabler;
        private System.Windows.Forms.Button MapGenOpen;
    }
}
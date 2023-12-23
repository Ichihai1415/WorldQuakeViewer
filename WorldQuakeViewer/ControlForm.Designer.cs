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
            this.Tab_Main_Setting = new System.Windows.Forms.TabPage();
            this.Config_Reset = new System.Windows.Forms.Button();
            this.Config_Save = new System.Windows.Forms.Button();
            this.ConfigWebLink = new System.Windows.Forms.LinkLabel();
            this.ConsigInfoText = new System.Windows.Forms.Label();
            this.TabCtrl_Setting = new System.Windows.Forms.TabControl();
            this.Tab_Setting_Pro = new System.Windows.Forms.TabPage();
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
            this.TabCtrl_Main.SuspendLayout();
            this.Tab_Main_Info.SuspendLayout();
            this.Tab_Main_Log.SuspendLayout();
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
            this.InfoPageLink.Font = new System.Drawing.Font("メイリオ", 10F);
            this.InfoPageLink.Location = new System.Drawing.Point(406, 439);
            this.InfoPageLink.Name = "InfoPageLink";
            this.InfoPageLink.Size = new System.Drawing.Size(80, 21);
            this.InfoPageLink.TabIndex = 2;
            this.InfoPageLink.TabStop = true;
            this.InfoPageLink.Text = "解説ページ";
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
            this.InfoText1.Font = new System.Drawing.Font("メイリオ", 10F);
            this.InfoText1.Location = new System.Drawing.Point(-1, 40);
            this.InfoText1.Name = "InfoText1";
            this.InfoText1.Size = new System.Drawing.Size(497, 420);
            this.InfoText1.TabIndex = 0;
            this.InfoText1.Text = resources.GetString("InfoText1.Text");
            // 
            // Tab_Main_Log
            // 
            this.Tab_Main_Log.Controls.Add(this.LogTextBox);
            this.Tab_Main_Log.Location = new System.Drawing.Point(4, 27);
            this.Tab_Main_Log.Name = "Tab_Main_Log";
            this.Tab_Main_Log.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Main_Log.Size = new System.Drawing.Size(492, 469);
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
            // Tab_Main_Setting
            // 
            this.Tab_Main_Setting.Controls.Add(this.Config_Reset);
            this.Tab_Main_Setting.Controls.Add(this.Config_Save);
            this.Tab_Main_Setting.Controls.Add(this.ConfigWebLink);
            this.Tab_Main_Setting.Controls.Add(this.ConsigInfoText);
            this.Tab_Main_Setting.Controls.Add(this.TabCtrl_Setting);
            this.Tab_Main_Setting.Location = new System.Drawing.Point(4, 27);
            this.Tab_Main_Setting.Name = "Tab_Main_Setting";
            this.Tab_Main_Setting.Size = new System.Drawing.Size(492, 469);
            this.Tab_Main_Setting.TabIndex = 2;
            this.Tab_Main_Setting.Text = "設定";
            this.Tab_Main_Setting.UseVisualStyleBackColor = true;
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
            this.ConfigWebLink.Location = new System.Drawing.Point(220, 448);
            this.ConfigWebLink.Name = "ConfigWebLink";
            this.ConfigWebLink.Size = new System.Drawing.Size(116, 18);
            this.ConfigWebLink.TabIndex = 2;
            this.ConfigWebLink.TabStop = true;
            this.ConfigWebLink.Text = "設定の詳細はこちら";
            this.ConfigWebLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ConfigWebLink_LinkClicked);
            // 
            // ConsigInfoText
            // 
            this.ConsigInfoText.AutoSize = true;
            this.ConsigInfoText.Location = new System.Drawing.Point(4, 373);
            this.ConsigInfoText.Name = "ConsigInfoText";
            this.ConsigInfoText.Size = new System.Drawing.Size(488, 90);
            this.ConsigInfoText.TabIndex = 1;
            this.ConsigInfoText.Text = "> ←これを押して展開してください。保存を押さないと反映されません。\r\n《処理》取得先別の処理の設定。Otherは処理できれば自由です。\r\n《表示》表示する処理の" +
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
            this.Tab_Setting_View.Location = new System.Drawing.Point(4, 27);
            this.Tab_Setting_View.Name = "Tab_Setting_View";
            this.Tab_Setting_View.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Setting_View.Size = new System.Drawing.Size(484, 338);
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
            this.ProG_view.Size = new System.Drawing.Size(478, 332);
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
        private System.Windows.Forms.Label ConsigInfoText;
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
    }
}
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ConfigWebLink = new System.Windows.Forms.LinkLabel();
            this.ConsigInfoText = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ProG_pro_Text1 = new System.Windows.Forms.Label();
            this.ProG_pro = new System.Windows.Forms.PropertyGrid();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ProG_view_CopyNum = new System.Windows.Forms.NumericUpDown();
            this.ProG_view_Copy = new System.Windows.Forms.Button();
            this.ProG_view_Text1 = new System.Windows.Forms.Label();
            this.ProG_view_Delete = new System.Windows.Forms.Button();
            this.ProG_view_Add = new System.Windows.Forms.Button();
            this.ProG_view = new System.Windows.Forms.PropertyGrid();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.ProG_other = new System.Windows.Forms.PropertyGrid();
            this.GetTimer = new System.Windows.Forms.Timer(this.components);
            this.Config_Save = new System.Windows.Forms.Button();
            this.Config_Reset = new System.Windows.Forms.Button();
            this.TabCtrl_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProG_view_CopyNum)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabCtrl_Main
            // 
            this.TabCtrl_Main.Controls.Add(this.tabPage2);
            this.TabCtrl_Main.Controls.Add(this.tabPage1);
            this.TabCtrl_Main.Controls.Add(this.tabPage3);
            this.TabCtrl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCtrl_Main.Location = new System.Drawing.Point(0, 0);
            this.TabCtrl_Main.Name = "TabCtrl_Main";
            this.TabCtrl_Main.SelectedIndex = 0;
            this.TabCtrl_Main.Size = new System.Drawing.Size(500, 500);
            this.TabCtrl_Main.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "情報";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LogTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(492, 469);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ログ";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Config_Reset);
            this.tabPage3.Controls.Add(this.Config_Save);
            this.tabPage3.Controls.Add(this.ConfigWebLink);
            this.tabPage3.Controls.Add(this.ConsigInfoText);
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(492, 469);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "設定";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ConfigWebLink
            // 
            this.ConfigWebLink.AutoSize = true;
            this.ConfigWebLink.Location = new System.Drawing.Point(288, 373);
            this.ConfigWebLink.Name = "ConfigWebLink";
            this.ConfigWebLink.Size = new System.Drawing.Size(44, 18);
            this.ConfigWebLink.TabIndex = 2;
            this.ConfigWebLink.TabStop = true;
            this.ConfigWebLink.Text = "こちら";
            this.ConfigWebLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ConfigWebLink_LinkClicked);
            // 
            // ConsigInfoText
            // 
            this.ConsigInfoText.AutoSize = true;
            this.ConsigInfoText.Location = new System.Drawing.Point(4, 373);
            this.ConsigInfoText.Name = "ConsigInfoText";
            this.ConsigInfoText.Size = new System.Drawing.Size(488, 90);
            this.ConsigInfoText.TabIndex = 1;
            this.ConsigInfoText.Text = "> ←これを押して展開してください。設定の詳細は\r\n<処理>取得先別の処理の設定。Otherは処理できれば自由です。\r\n<表示>表示する処理の設定。[0]はコピー" +
    "用で表示されません。\r\n追加を押して画面を追加できます。削除は一番最後のを削除するので注意してください。\r\n<その他>上記以外の設定。";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(492, 369);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ProG_pro_Text1);
            this.tabPage5.Controls.Add(this.ProG_pro);
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(484, 338);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "処理";
            this.tabPage5.UseVisualStyleBackColor = true;
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
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ProG_view_CopyNum);
            this.tabPage6.Controls.Add(this.ProG_view_Copy);
            this.tabPage6.Controls.Add(this.ProG_view_Text1);
            this.tabPage6.Controls.Add(this.ProG_view_Delete);
            this.tabPage6.Controls.Add(this.ProG_view_Add);
            this.tabPage6.Controls.Add(this.ProG_view);
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(484, 338);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "表示";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ProG_view_CopyNum
            // 
            this.ProG_view_CopyNum.Location = new System.Drawing.Point(247, 3);
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
            // 
            // ProG_view_Copy
            // 
            this.ProG_view_Copy.Font = new System.Drawing.Font("メイリオ", 9F);
            this.ProG_view_Copy.Location = new System.Drawing.Point(294, 4);
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
            this.ProG_view_Text1.Location = new System.Drawing.Point(200, 7);
            this.ProG_view_Text1.Name = "ProG_view_Text1";
            this.ProG_view_Text1.Size = new System.Drawing.Size(97, 18);
            this.ProG_view_Text1.TabIndex = 4;
            this.ProG_view_Text1.Text = "[0]から　　　に";
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
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.ProG_other);
            this.tabPage7.Location = new System.Drawing.Point(4, 27);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(484, 338);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "その他";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // ProG_other
            // 
            this.ProG_other.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProG_other.Location = new System.Drawing.Point(3, 3);
            this.ProG_other.Name = "ProG_other";
            this.ProG_other.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.ProG_other.Size = new System.Drawing.Size(478, 332);
            this.ProG_other.TabIndex = 2;
            // 
            // GetTimer
            // 
            this.GetTimer.Tick += new System.EventHandler(this.GetTimer_Tick);
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
            this.Text = "ControlForm";
            this.Load += new System.EventHandler(this.CtrlForm_Load);
            this.TabCtrl_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProG_view_CopyNum)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabCtrl_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Timer GetTimer;
        private System.Windows.Forms.PropertyGrid ProG_pro;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.PropertyGrid ProG_view;
        private System.Windows.Forms.TabPage tabPage7;
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
    }
}
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
            this.TabCtrl_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.DGV_pro = new System.Windows.Forms.DataGridView();
            this.GDV_pro_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GDV_pro_USGS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GDV_pro_EMSC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GDV_pro_EarlyEst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GDV_pro_GFZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.TabCtrl_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_pro)).BeginInit();
            this.SuspendLayout();
            // 
            // TabCtrl_Main
            // 
            this.TabCtrl_Main.Controls.Add(this.tabPage1);
            this.TabCtrl_Main.Controls.Add(this.tabPage2);
            this.TabCtrl_Main.Controls.Add(this.tabPage3);
            this.TabCtrl_Main.Location = new System.Drawing.Point(0, 0);
            this.TabCtrl_Main.Name = "TabCtrl_Main";
            this.TabCtrl_Main.SelectedIndex = 0;
            this.TabCtrl_Main.Size = new System.Drawing.Size(500, 500);
            this.TabCtrl_Main.TabIndex = 0;
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "情報";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(492, 469);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "設定";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(492, 469);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(484, 438);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "基本";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.DGV_pro);
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(484, 438);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "処理";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // DGV_pro
            // 
            this.DGV_pro.AllowUserToAddRows = false;
            this.DGV_pro.AllowUserToDeleteRows = false;
            this.DGV_pro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_pro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GDV_pro_Name,
            this.GDV_pro_USGS,
            this.GDV_pro_EMSC,
            this.GDV_pro_EarlyEst,
            this.GDV_pro_GFZ});
            this.DGV_pro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_pro.Location = new System.Drawing.Point(3, 3);
            this.DGV_pro.Name = "DGV_pro";
            this.DGV_pro.RowHeadersVisible = false;
            this.DGV_pro.RowTemplate.Height = 21;
            this.DGV_pro.Size = new System.Drawing.Size(478, 432);
            this.DGV_pro.TabIndex = 1;
            // 
            // GDV_pro_Name
            // 
            this.GDV_pro_Name.HeaderText = "項目";
            this.GDV_pro_Name.Name = "GDV_pro_Name";
            this.GDV_pro_Name.ReadOnly = true;
            // 
            // GDV_pro_USGS
            // 
            this.GDV_pro_USGS.HeaderText = "USGS";
            this.GDV_pro_USGS.Name = "GDV_pro_USGS";
            this.GDV_pro_USGS.ReadOnly = true;
            // 
            // GDV_pro_EMSC
            // 
            this.GDV_pro_EMSC.HeaderText = "EMSC";
            this.GDV_pro_EMSC.Name = "GDV_pro_EMSC";
            // 
            // GDV_pro_EarlyEst
            // 
            this.GDV_pro_EarlyEst.HeaderText = "Early-est";
            this.GDV_pro_EarlyEst.Name = "GDV_pro_EarlyEst";
            // 
            // GDV_pro_GFZ
            // 
            this.GDV_pro_GFZ.HeaderText = "GFZ";
            this.GDV_pro_GFZ.Name = "GDV_pro_GFZ";
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(484, 443);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "表示";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // CtrlForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.TabCtrl_Main);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CtrlForm";
            this.Text = "ControlForm";
            this.TabCtrl_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_pro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabCtrl_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView DGV_pro;
        private System.Windows.Forms.DataGridViewTextBoxColumn GDV_pro_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn GDV_pro_USGS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GDV_pro_EMSC;
        private System.Windows.Forms.DataGridViewTextBoxColumn GDV_pro_EarlyEst;
        private System.Windows.Forms.DataGridViewTextBoxColumn GDV_pro_GFZ;
    }
}
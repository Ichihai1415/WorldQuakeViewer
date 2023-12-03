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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.GetTimer = new System.Windows.Forms.Timer(this.components);
            this.PropertyGrid_pro = new System.Windows.Forms.PropertyGrid();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.PropertyGrid_view = new System.Windows.Forms.PropertyGrid();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.PropertyGrid_other = new System.Windows.Forms.PropertyGrid();
            this.TabCtrl_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
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
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 469);
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
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(492, 469);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.PropertyGrid_pro);
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(484, 438);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "処理";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // GetTimer
            // 
            this.GetTimer.Tick += new System.EventHandler(this.GetTimer_Tick);
            // 
            // PropertyGrid_pro
            // 
            this.PropertyGrid_pro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid_pro.Location = new System.Drawing.Point(3, 3);
            this.PropertyGrid_pro.Name = "PropertyGrid_pro";
            this.PropertyGrid_pro.Size = new System.Drawing.Size(478, 432);
            this.PropertyGrid_pro.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.PropertyGrid_view);
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(484, 438);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "表示";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // PropertyGrid_view
            // 
            this.PropertyGrid_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid_view.Location = new System.Drawing.Point(3, 3);
            this.PropertyGrid_view.Name = "PropertyGrid_view";
            this.PropertyGrid_view.Size = new System.Drawing.Size(478, 432);
            this.PropertyGrid_view.TabIndex = 1;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.PropertyGrid_other);
            this.tabPage7.Location = new System.Drawing.Point(4, 27);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(484, 438);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "その他";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // PropertyGrid_other
            // 
            this.PropertyGrid_other.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid_other.Location = new System.Drawing.Point(3, 3);
            this.PropertyGrid_other.Name = "PropertyGrid_other";
            this.PropertyGrid_other.Size = new System.Drawing.Size(478, 432);
            this.PropertyGrid_other.TabIndex = 2;
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
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
        private System.Windows.Forms.PropertyGrid PropertyGrid_pro;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.PropertyGrid PropertyGrid_view;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.PropertyGrid PropertyGrid_other;
    }
}
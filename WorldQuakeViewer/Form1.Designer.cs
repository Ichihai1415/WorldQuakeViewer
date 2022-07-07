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
            this.MainImg = new System.Windows.Forms.PictureBox();
            this.USGS6 = new System.Windows.Forms.Label();
            this.USGS4 = new System.Windows.Forms.Label();
            this.RightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RCsetting = new System.Windows.Forms.ToolStripMenuItem();
            this.RCbar2 = new System.Windows.Forms.ToolStripSeparator();
            this.RCusgs = new System.Windows.Forms.ToolStripMenuItem();
            this.RCusgsmap = new System.Windows.Forms.ToolStripMenuItem();
            this.RCusgsthis = new System.Windows.Forms.ToolStripMenuItem();
            this.RCbar4 = new System.Windows.Forms.ToolStripSeparator();
            this.RCprojects = new System.Windows.Forms.ToolStripMenuItem();
            this.RCgithub = new System.Windows.Forms.ToolStripMenuItem();
            this.RCtwitter = new System.Windows.Forms.ToolStripMenuItem();
            this.RCameba = new System.Windows.Forms.ToolStripMenuItem();
            this.RCbar5 = new System.Windows.Forms.ToolStripSeparator();
            this.RCopenreadme = new System.Windows.Forms.ToolStripMenuItem();
            this.RCbar6 = new System.Windows.Forms.ToolStripSeparator();
            this.RCrebootexit = new System.Windows.Forms.ToolStripMenuItem();
            this.RCreboot = new System.Windows.Forms.ToolStripMenuItem();
            this.RCexit = new System.Windows.Forms.ToolStripMenuItem();
            this.USGS2 = new System.Windows.Forms.Label();
            this.USGS3 = new System.Windows.Forms.Label();
            this.USGS5 = new System.Windows.Forms.Label();
            this.ErrorText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainImg)).BeginInit();
            this.RightClick.SuspendLayout();
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
            this.USGS0.Font = new System.Drawing.Font("Koruri Regular", 10F);
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
            this.USGS1.Location = new System.Drawing.Point(3, 17);
            this.USGS1.Margin = new System.Windows.Forms.Padding(0);
            this.USGS1.Name = "USGS1";
            this.USGS1.Size = new System.Drawing.Size(396, 81);
            this.USGS1.TabIndex = 2;
            this.USGS1.Text = "情報取得中...\r\n";
            // 
            // MainImg
            // 
            this.MainImg.BackColor = System.Drawing.Color.Black;
            this.MainImg.Location = new System.Drawing.Point(400, 500);
            this.MainImg.Margin = new System.Windows.Forms.Padding(0);
            this.MainImg.Name = "MainImg";
            this.MainImg.Size = new System.Drawing.Size(1800, 900);
            this.MainImg.TabIndex = 0;
            this.MainImg.TabStop = false;
            // 
            // USGS6
            // 
            this.USGS6.AutoSize = true;
            this.USGS6.Font = new System.Drawing.Font("Koruri Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.USGS6.Location = new System.Drawing.Point(259, 449);
            this.USGS6.Name = "USGS6";
            this.USGS6.Size = new System.Drawing.Size(178, 63);
            this.USGS6.TabIndex = 8;
            this.USGS6.Text = "\r\n\r\nWorldQuakeViewer v2.4";
            // 
            // USGS4
            // 
            this.USGS4.Font = new System.Drawing.Font("Koruri Regular", 11F);
            this.USGS4.Location = new System.Drawing.Point(229, 58);
            this.USGS4.Name = "USGS4";
            this.USGS4.Size = new System.Drawing.Size(104, 38);
            this.USGS4.TabIndex = 10;
            // 
            // RightClick
            // 
            this.RightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCsetting,
            this.RCbar2,
            this.RCusgs,
            this.RCbar4,
            this.RCprojects,
            this.RCbar5,
            this.RCopenreadme,
            this.RCbar6,
            this.RCrebootexit});
            this.RightClick.Name = "RightClick";
            this.RightClick.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.RightClick.Size = new System.Drawing.Size(192, 148);
            this.RightClick.TabStop = true;
            this.RightClick.Text = "メニュー";
            // 
            // RCsetting
            // 
            this.RCsetting.Name = "RCsetting";
            this.RCsetting.Size = new System.Drawing.Size(191, 24);
            this.RCsetting.Text = "設定";
            this.RCsetting.Click += new System.EventHandler(this.RCsetting_Click);
            // 
            // RCbar2
            // 
            this.RCbar2.Name = "RCbar2";
            this.RCbar2.Size = new System.Drawing.Size(188, 6);
            // 
            // RCusgs
            // 
            this.RCusgs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RCusgs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCusgsmap,
            this.RCusgsthis});
            this.RCusgs.Name = "RCusgs";
            this.RCusgs.Size = new System.Drawing.Size(191, 24);
            this.RCusgs.Text = "USGSサイト";
            // 
            // RCusgsmap
            // 
            this.RCusgsmap.Name = "RCusgsmap";
            this.RCusgsmap.Size = new System.Drawing.Size(186, 26);
            this.RCusgsmap.Text = "マップ";
            this.RCusgsmap.Click += new System.EventHandler(this.RCusgsmap_Click);
            // 
            // RCusgsthis
            // 
            this.RCusgsthis.Name = "RCusgsthis";
            this.RCusgsthis.Size = new System.Drawing.Size(186, 26);
            this.RCusgsthis.Text = "この地震の詳細";
            this.RCusgsthis.Click += new System.EventHandler(this.RCusgsthis_Click);
            // 
            // RCbar4
            // 
            this.RCbar4.Name = "RCbar4";
            this.RCbar4.Size = new System.Drawing.Size(188, 6);
            // 
            // RCprojects
            // 
            this.RCprojects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RCprojects.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCgithub,
            this.RCtwitter,
            this.RCameba});
            this.RCprojects.Name = "RCprojects";
            this.RCprojects.Size = new System.Drawing.Size(191, 24);
            this.RCprojects.Text = "制作者ページ";
            // 
            // RCgithub
            // 
            this.RCgithub.Name = "RCgithub";
            this.RCgithub.Size = new System.Drawing.Size(183, 26);
            this.RCgithub.Text = "GitHub ";
            this.RCgithub.Click += new System.EventHandler(this.RCgithub_Click);
            // 
            // RCtwitter
            // 
            this.RCtwitter.Name = "RCtwitter";
            this.RCtwitter.Size = new System.Drawing.Size(183, 26);
            this.RCtwitter.Text = "Twitter";
            this.RCtwitter.Click += new System.EventHandler(this.RCtwitter_Click);
            // 
            // RCameba
            // 
            this.RCameba.Name = "RCameba";
            this.RCameba.Size = new System.Drawing.Size(183, 26);
            this.RCameba.Text = "Ameba Ownd";
            this.RCameba.Click += new System.EventHandler(this.RCameba_Click);
            // 
            // RCbar5
            // 
            this.RCbar5.Name = "RCbar5";
            this.RCbar5.Size = new System.Drawing.Size(188, 6);
            // 
            // RCopenreadme
            // 
            this.RCopenreadme.Name = "RCopenreadme";
            this.RCopenreadme.Size = new System.Drawing.Size(191, 24);
            this.RCopenreadme.Text = "readme.mdを見る";
            this.RCopenreadme.Click += new System.EventHandler(this.RCopenreadme_Click);
            // 
            // RCbar6
            // 
            this.RCbar6.Name = "RCbar6";
            this.RCbar6.Size = new System.Drawing.Size(188, 6);
            // 
            // RCrebootexit
            // 
            this.RCrebootexit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RCrebootexit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RCreboot,
            this.RCexit});
            this.RCrebootexit.Name = "RCrebootexit";
            this.RCrebootexit.Size = new System.Drawing.Size(191, 24);
            this.RCrebootexit.Text = "再起動/終了";
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
            this.USGS2.Location = new System.Drawing.Point(118, 75);
            this.USGS2.Name = "USGS2";
            this.USGS2.Size = new System.Drawing.Size(56, 20);
            this.USGS2.TabIndex = 12;
            this.USGS2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // USGS3
            // 
            this.USGS3.Font = new System.Drawing.Font("Koruri Regular", 20F);
            this.USGS3.Location = new System.Drawing.Point(167, 60);
            this.USGS3.Name = "USGS3";
            this.USGS3.Size = new System.Drawing.Size(70, 38);
            this.USGS3.TabIndex = 13;
            this.USGS3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // USGS5
            // 
            this.USGS5.Font = new System.Drawing.Font("Koruri Regular", 20F);
            this.USGS5.Location = new System.Drawing.Point(325, 59);
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
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.ContextMenuStrip = this.RightClick;
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.USGS4);
            this.Controls.Add(this.USGS5);
            this.Controls.Add(this.USGS2);
            this.Controls.Add(this.USGS3);
            this.Controls.Add(this.USGS6);
            this.Controls.Add(this.USGS1);
            this.Controls.Add(this.USGS0);
            this.Controls.Add(this.MainImg);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WorldQuakeViewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainImg)).EndInit();
            this.RightClick.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripSeparator RCbar2;
        private System.Windows.Forms.ToolStripMenuItem RCusgs;
        private System.Windows.Forms.ToolStripMenuItem RCprojects;
        private System.Windows.Forms.ToolStripSeparator RCbar5;
        private System.Windows.Forms.ToolStripMenuItem RCrebootexit;
        private System.Windows.Forms.ToolStripMenuItem RCsetting;
        private System.Windows.Forms.ToolStripSeparator RCbar4;
        private System.Windows.Forms.ToolStripMenuItem RCusgsmap;
        private System.Windows.Forms.ToolStripMenuItem RCusgsthis;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.ToolStripMenuItem RCreboot;
        private System.Windows.Forms.ToolStripMenuItem RCexit;
        private System.Windows.Forms.ToolStripSeparator RCbar6;
        private System.Windows.Forms.ToolStripMenuItem RCopenreadme;
        private System.Windows.Forms.ToolStripMenuItem RCgithub;
        private System.Windows.Forms.ToolStripMenuItem RCtwitter;
        private System.Windows.Forms.ToolStripMenuItem RCameba;
    }
}


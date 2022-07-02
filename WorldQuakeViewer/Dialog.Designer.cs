namespace WorldQuakeViewer
{
    partial class Dialog
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
            this.Main = new System.Windows.Forms.Label();
            this.DLStart = new System.Windows.Forms.Button();
            this.Finish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Main
            // 
            this.Main.AutoSize = true;
            this.Main.Font = new System.Drawing.Font("Koruri Regular", 14F);
            this.Main.ForeColor = System.Drawing.Color.White;
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(0, 26);
            this.Main.TabIndex = 1;
            // 
            // DLStart
            // 
            this.DLStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.DLStart.Font = new System.Drawing.Font("Koruri Regular", 12F);
            this.DLStart.Location = new System.Drawing.Point(140, 150);
            this.DLStart.Name = "DLStart";
            this.DLStart.Size = new System.Drawing.Size(120, 40);
            this.DLStart.TabIndex = 2;
            this.DLStart.Text = "DL・解凍開始";
            this.DLStart.UseVisualStyleBackColor = false;
            this.DLStart.Click += new System.EventHandler(this.DLStart_Click);
            // 
            // Finish
            // 
            this.Finish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.Finish.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Finish.Font = new System.Drawing.Font("Koruri Regular", 12F);
            this.Finish.Location = new System.Drawing.Point(140, 150);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(120, 40);
            this.Finish.TabIndex = 3;
            this.Finish.Text = "終了";
            this.Finish.UseVisualStyleBackColor = false;
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.DLStart);
            this.Controls.Add(this.Finish);
            this.Controls.Add(this.Main);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 239);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 239);
            this.Name = "Dialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorldQuakeViewer：アップデート通知";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Dialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Main;
        private System.Windows.Forms.Button DLStart;
        private System.Windows.Forms.Button Finish;
    }
}
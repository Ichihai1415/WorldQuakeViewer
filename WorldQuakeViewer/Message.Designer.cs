namespace WorldQuakeViewer
{
    partial class Message
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.MainText = new System.Windows.Forms.Label();
            this.MessageVersion = new System.Windows.Forms.ComboBox();
            this.View = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CloseButton.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.CloseButton.Location = new System.Drawing.Point(242, 114);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(63, 28);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "閉じる";
            this.CloseButton.UseVisualStyleBackColor = false;
            // 
            // MainText
            // 
            this.MainText.Location = new System.Drawing.Point(0, 0);
            this.MainText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MainText.Name = "MainText";
            this.MainText.Size = new System.Drawing.Size(305, 140);
            this.MainText.TabIndex = 1;
            this.MainText.Text = "メッセージバージョン:";
            // 
            // MessageVersion
            // 
            this.MessageVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.MessageVersion.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.MessageVersion.ForeColor = System.Drawing.Color.White;
            this.MessageVersion.FormattingEnabled = true;
            this.MessageVersion.Items.AddRange(new object[] {
            "v0.1",
            "v0.2",
            "v0.3",
            "v0.4",
            "v0.5",
            "v0.6",
            "v0.7",
            "v0.8",
            "v0.9",
            "v1.0",
            "v1.1",
            "v1.2",
            "v1.3",
            "v1.4",
            "v1.5",
            "v1.6",
            "v1.7",
            "v1.8",
            "v1.9",
            "v2.0",
            "v2.1",
            "v2.2",
            "v2.3",
            "v2.4",
            "v2.5",
            "v2.6",
            "v2.7",
            "v2.8",
            "v2.9",
            "v3.0",
            "v3.1",
            "v3.2",
            "v3.3",
            "v3.4",
            "v3.5",
            "v3.6",
            "v3.7",
            "v3.8",
            "v3.9",
            "v4.0",
            "v4.1",
            "v4.2",
            "v4.3",
            "v4.4",
            "v4.5",
            "v4.6",
            "v4.7",
            "v4.8",
            "v4.9",
            "v5.0",
            "v5.1",
            "v5.2",
            "v5.3",
            "v5.4",
            "v5.5",
            "v5.6",
            "v5.7",
            "v5.8",
            "v5.9"});
            this.MessageVersion.Location = new System.Drawing.Point(203, 2);
            this.MessageVersion.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MessageVersion.Name = "MessageVersion";
            this.MessageVersion.Size = new System.Drawing.Size(53, 26);
            this.MessageVersion.TabIndex = 2;
            this.MessageVersion.Text = "v0.0";
            // 
            // View
            // 
            this.View.Enabled = true;
            this.View.Tick += new System.EventHandler(this.View_Tick);
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(304, 141);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.MessageVersion);
            this.Controls.Add(this.MainText);
            this.Font = new System.Drawing.Font("Koruri Regular", 14F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 180);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 180);
            this.Name = "Message";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorldQuakeViewer：お知らせ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Message_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label MainText;
        private System.Windows.Forms.ComboBox MessageVersion;
        private System.Windows.Forms.Timer View;
    }
}
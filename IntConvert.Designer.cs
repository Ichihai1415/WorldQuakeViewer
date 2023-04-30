namespace WorldQuakeViewer
{
    partial class IntConvert
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
            this.MMItoPGV = new System.Windows.Forms.Button();
            this.Text1 = new System.Windows.Forms.Label();
            this.ExampleSite = new System.Windows.Forms.LinkLabel();
            this.MMIv = new System.Windows.Forms.NumericUpDown();
            this.PGVv = new System.Windows.Forms.NumericUpDown();
            this.JIv = new System.Windows.Forms.NumericUpDown();
            this.PGVtoMMI = new System.Windows.Forms.Button();
            this.JItoPGV = new System.Windows.Forms.Button();
            this.PGVtoJI = new System.Windows.Forms.Button();
            this.Text2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MMIv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PGVv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JIv)).BeginInit();
            this.SuspendLayout();
            // 
            // MMItoPGV
            // 
            this.MMItoPGV.Location = new System.Drawing.Point(77, 50);
            this.MMItoPGV.Margin = new System.Windows.Forms.Padding(4);
            this.MMItoPGV.Name = "MMItoPGV";
            this.MMItoPGV.Size = new System.Drawing.Size(27, 27);
            this.MMItoPGV.TabIndex = 0;
            this.MMItoPGV.Text = "→";
            this.MMItoPGV.UseVisualStyleBackColor = true;
            this.MMItoPGV.Click += new System.EventHandler(this.MMItoPGV_Click);
            // 
            // Text1
            // 
            this.Text1.AutoSize = true;
            this.Text1.Location = new System.Drawing.Point(14, 9);
            this.Text1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(285, 38);
            this.Text1.TabIndex = 1;
            this.Text1.Text = "改正メルカリ　　最大速度　　　　気象庁\r\n　震度階級　　　  (cm/s) 　　　　震度階級\r\n";
            // 
            // ExampleSite
            // 
            this.ExampleSite.AutoSize = true;
            this.ExampleSite.Location = new System.Drawing.Point(214, 84);
            this.ExampleSite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ExampleSite.Name = "ExampleSite";
            this.ExampleSite.Size = new System.Drawing.Size(93, 19);
            this.ExampleSite.TabIndex = 2;
            this.ExampleSite.TabStop = true;
            this.ExampleSite.Text = "式の導出・例";
            this.ExampleSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ExampleSite_LinkClicked);
            // 
            // MMIv
            // 
            this.MMIv.DecimalPlaces = 3;
            this.MMIv.Location = new System.Drawing.Point(17, 50);
            this.MMIv.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.MMIv.Name = "MMIv";
            this.MMIv.Size = new System.Drawing.Size(59, 27);
            this.MMIv.TabIndex = 3;
            this.MMIv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PGVv
            // 
            this.PGVv.DecimalPlaces = 3;
            this.PGVv.Location = new System.Drawing.Point(131, 50);
            this.PGVv.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.PGVv.Name = "PGVv";
            this.PGVv.Size = new System.Drawing.Size(59, 27);
            this.PGVv.TabIndex = 4;
            this.PGVv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // JIv
            // 
            this.JIv.DecimalPlaces = 3;
            this.JIv.Location = new System.Drawing.Point(245, 50);
            this.JIv.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            131072});
            this.JIv.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147352576});
            this.JIv.Name = "JIv";
            this.JIv.Size = new System.Drawing.Size(59, 27);
            this.JIv.TabIndex = 5;
            this.JIv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PGVtoMMI
            // 
            this.PGVtoMMI.Location = new System.Drawing.Point(103, 50);
            this.PGVtoMMI.Margin = new System.Windows.Forms.Padding(4);
            this.PGVtoMMI.Name = "PGVtoMMI";
            this.PGVtoMMI.Size = new System.Drawing.Size(27, 27);
            this.PGVtoMMI.TabIndex = 6;
            this.PGVtoMMI.Text = "←";
            this.PGVtoMMI.UseVisualStyleBackColor = true;
            this.PGVtoMMI.Click += new System.EventHandler(this.PGVtoMMI_Click);
            // 
            // JItoPGV
            // 
            this.JItoPGV.Location = new System.Drawing.Point(217, 50);
            this.JItoPGV.Margin = new System.Windows.Forms.Padding(4);
            this.JItoPGV.Name = "JItoPGV";
            this.JItoPGV.Size = new System.Drawing.Size(27, 27);
            this.JItoPGV.TabIndex = 8;
            this.JItoPGV.Text = "←";
            this.JItoPGV.UseVisualStyleBackColor = true;
            this.JItoPGV.Click += new System.EventHandler(this.JItoPGV_Click);
            // 
            // PGVtoJI
            // 
            this.PGVtoJI.Location = new System.Drawing.Point(191, 50);
            this.PGVtoJI.Margin = new System.Windows.Forms.Padding(4);
            this.PGVtoJI.Name = "PGVtoJI";
            this.PGVtoJI.Size = new System.Drawing.Size(27, 27);
            this.PGVtoJI.TabIndex = 7;
            this.PGVtoJI.Text = "→";
            this.PGVtoJI.UseVisualStyleBackColor = true;
            this.PGVtoJI.Click += new System.EventHandler(this.PGVtoJI_Click);
            // 
            // Text2
            // 
            this.Text2.AutoSize = true;
            this.Text2.Location = new System.Drawing.Point(7, 84);
            this.Text2.Name = "Text2";
            this.Text2.Size = new System.Drawing.Size(294, 57);
            this.Text2.TabIndex = 9;
            this.Text2.Text = "※参考程度に利用してください。\r\n最大速度と気象庁震度階級との変換は\r\n藤本･翠川(2005)の換算式を利用しています。";
            // 
            // IntConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 150);
            this.Controls.Add(this.JIv);
            this.Controls.Add(this.PGVv);
            this.Controls.Add(this.MMIv);
            this.Controls.Add(this.JItoPGV);
            this.Controls.Add(this.PGVtoJI);
            this.Controls.Add(this.PGVtoMMI);
            this.Controls.Add(this.ExampleSite);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.MMItoPGV);
            this.Controls.Add(this.Text2);
            this.Font = new System.Drawing.Font("Koruri Regular", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "IntConvert";
            this.Text = "WQV - 簡易震度変換ツール";
            ((System.ComponentModel.ISupportInitialize)(this.MMIv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PGVv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JIv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MMItoPGV;
        private System.Windows.Forms.Label Text1;
        private System.Windows.Forms.LinkLabel ExampleSite;
        private System.Windows.Forms.NumericUpDown MMIv;
        private System.Windows.Forms.NumericUpDown PGVv;
        private System.Windows.Forms.NumericUpDown JIv;
        private System.Windows.Forms.Button PGVtoMMI;
        private System.Windows.Forms.Button JItoPGV;
        private System.Windows.Forms.Button PGVtoJI;
        private System.Windows.Forms.Label Text2;
    }
}
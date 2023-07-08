namespace WorldQuakeViewer
{
    partial class MapGenerate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapGenerate));
            this.Img = new System.Windows.Forms.PictureBox();
            this.Text1 = new System.Windows.Forms.Label();
            this.ColorSetting = new System.Windows.Forms.DataGridView();
            this.Draw = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.LinkNaturalEarth = new System.Windows.Forms.LinkLabel();
            this.LinkPlate = new System.Windows.Forms.LinkLabel();
            this.Text2 = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.ColorSettingListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ColorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorAlpha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorRed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorGreen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorBlue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorSettingListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Img
            // 
            this.Img.Image = global::WorldQuakeViewer.Properties.Resources.map;
            this.Img.Location = new System.Drawing.Point(0, 360);
            this.Img.Name = "Img";
            this.Img.Size = new System.Drawing.Size(540, 180);
            this.Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Img.TabIndex = 0;
            this.Img.TabStop = false;
            // 
            // Text1
            // 
            this.Text1.AutoSize = true;
            this.Text1.Location = new System.Drawing.Point(0, 0);
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(544, 38);
            this.Text1.TabIndex = 1;
            this.Text1.Text = "「描画」で色設定を保存し描画　「保存」で描画したものを保存　「リセット」で色設定を初期化\r\n地図:                       プレート境界:  " +
    "                       描画を押さないと色設定は保存されません。";
            // 
            // ColorSetting
            // 
            this.ColorSetting.AllowUserToAddRows = false;
            this.ColorSetting.AllowUserToDeleteRows = false;
            this.ColorSetting.AllowUserToResizeColumns = false;
            this.ColorSetting.AutoGenerateColumns = false;
            this.ColorSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColorSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColorName,
            this.ColorAlpha,
            this.ColorRed,
            this.ColorGreen,
            this.ColorBlue});
            this.ColorSetting.DataSource = this.ColorSettingListBindingSource;
            this.ColorSetting.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.ColorSetting.Location = new System.Drawing.Point(0, 50);
            this.ColorSetting.MultiSelect = false;
            this.ColorSetting.Name = "ColorSetting";
            this.ColorSetting.RowHeadersWidth = 51;
            this.ColorSetting.RowTemplate.Height = 21;
            this.ColorSetting.Size = new System.Drawing.Size(540, 250);
            this.ColorSetting.TabIndex = 2;
            this.ColorSetting.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ColorSetting_CellValidating);
            this.ColorSetting.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ColorSetting_DataError);
            // 
            // Draw
            // 
            this.Draw.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.Draw.Location = new System.Drawing.Point(80, 315);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(70, 30);
            this.Draw.TabIndex = 3;
            this.Draw.Text = "描画";
            this.Draw.UseVisualStyleBackColor = true;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // Save
            // 
            this.Save.Enabled = false;
            this.Save.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.Save.Location = new System.Drawing.Point(235, 315);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(70, 30);
            this.Save.TabIndex = 4;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // LinkNaturalEarth
            // 
            this.LinkNaturalEarth.AutoSize = true;
            this.LinkNaturalEarth.Location = new System.Drawing.Point(36, 19);
            this.LinkNaturalEarth.Name = "LinkNaturalEarth";
            this.LinkNaturalEarth.Size = new System.Drawing.Size(90, 19);
            this.LinkNaturalEarth.TabIndex = 5;
            this.LinkNaturalEarth.TabStop = true;
            this.LinkNaturalEarth.Text = "Natural Earth";
            this.LinkNaturalEarth.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkNaturalEarth_LinkClicked);
            // 
            // LinkPlate
            // 
            this.LinkPlate.AutoSize = true;
            this.LinkPlate.Location = new System.Drawing.Point(199, 19);
            this.LinkPlate.Name = "LinkPlate";
            this.LinkPlate.Size = new System.Drawing.Size(93, 19);
            this.LinkPlate.TabIndex = 6;
            this.LinkPlate.TabStop = true;
            this.LinkPlate.Text = "tectonicplates";
            this.LinkPlate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkPlate_LinkClicked);
            // 
            // Text2
            // 
            this.Text2.AutoSize = true;
            this.Text2.Location = new System.Drawing.Point(0, 360);
            this.Text2.MaximumSize = new System.Drawing.Size(540, 180);
            this.Text2.Name = "Text2";
            this.Text2.Size = new System.Drawing.Size(0, 19);
            this.Text2.TabIndex = 7;
            // 
            // Reset
            // 
            this.Reset.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            this.Reset.Location = new System.Drawing.Point(390, 315);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(70, 30);
            this.Reset.TabIndex = 8;
            this.Reset.Text = "リセット";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // ColorSettingListBindingSource
            // 
            this.ColorSettingListBindingSource.DataSource = typeof(WorldQuakeViewer.ColorSettingList);
            // 
            // ColorName
            // 
            this.ColorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColorName.DataPropertyName = "Name";
            this.ColorName.HeaderText = "Name";
            this.ColorName.MinimumWidth = 6;
            this.ColorName.Name = "ColorName";
            this.ColorName.ReadOnly = true;
            this.ColorName.ToolTipText = "描画名";
            // 
            // ColorAlpha
            // 
            this.ColorAlpha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColorAlpha.DataPropertyName = "Alpha";
            this.ColorAlpha.HeaderText = "Alpha";
            this.ColorAlpha.MinimumWidth = 6;
            this.ColorAlpha.Name = "ColorAlpha";
            this.ColorAlpha.ToolTipText = "透明度(0で透明=描画無効)";
            this.ColorAlpha.Width = 69;
            // 
            // ColorRed
            // 
            this.ColorRed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColorRed.DataPropertyName = "Red";
            this.ColorRed.HeaderText = "Red";
            this.ColorRed.MinimumWidth = 6;
            this.ColorRed.Name = "ColorRed";
            this.ColorRed.ToolTipText = "赤";
            this.ColorRed.Width = 57;
            // 
            // ColorGreen
            // 
            this.ColorGreen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColorGreen.DataPropertyName = "Green";
            this.ColorGreen.HeaderText = "Green";
            this.ColorGreen.MinimumWidth = 6;
            this.ColorGreen.Name = "ColorGreen";
            this.ColorGreen.ToolTipText = "緑";
            this.ColorGreen.Width = 71;
            // 
            // ColorBlue
            // 
            this.ColorBlue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColorBlue.DataPropertyName = "Blue";
            this.ColorBlue.HeaderText = "Blue";
            this.ColorBlue.MinimumWidth = 6;
            this.ColorBlue.Name = "ColorBlue";
            this.ColorBlue.ToolTipText = "青";
            this.ColorBlue.Width = 60;
            // 
            // MapGenerate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(540, 540);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Text2);
            this.Controls.Add(this.LinkPlate);
            this.Controls.Add(this.LinkNaturalEarth);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Draw);
            this.Controls.Add(this.ColorSetting);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.Img);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MapGenerate";
            this.Text = "WQV - マップ生成";
            this.Load += new System.EventHandler(this.MagGenerate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorSettingListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Img;
        private System.Windows.Forms.Label Text1;
        private System.Windows.Forms.DataGridView ColorSetting;
        private System.Windows.Forms.BindingSource ColorSettingListBindingSource;
        private System.Windows.Forms.Button Draw;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.LinkLabel LinkNaturalEarth;
        private System.Windows.Forms.LinkLabel LinkPlate;
        private System.Windows.Forms.Label Text2;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorAlpha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorRed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorGreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorBlue;
    }
}
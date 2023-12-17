using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static WorldQuakeViewer.CtrlForm;
using static WorldQuakeViewer.Util_Class;
using static WorldQuakeViewer.Util_Conv;
using static WorldQuakeViewer.Util_Func;

namespace WorldQuakeViewer
{
    public partial class DataView : Form
    {
        readonly ViewData vD;
        readonly int viewType;
        readonly int i;
        readonly Dictionary<string, Data> data_;
        static Config.View_ config_view;

        public DataView(int viewIndex, ViewData viewData)
        {
            if (viewData == ViewData.Null)
                throw new ArgumentException($"ViewData({viewData})が不正です。", nameof(viewData));

            InitializeComponent();

            i = viewIndex;
            Text = $"WorldQuakeViewer - [{viewIndex}] ({viewData})";
            vD = viewData;
            viewType = (int)viewData % 10;
            switch (viewType)
            {
                case 1:
                case 2:
                    ClientSize = new Size(400, 500);
                    break;
                case 3:
                    ClientSize = new Size(800, 500);
                    break;
                default:
                    throw new Exception("DataViewの初期化に失敗しました。", new ArgumentException($"{viewType}は種類として不正です。", nameof(viewType)));
            }
            switch ((int)viewData / 10)
            {
                case 0:
                    data_ = data_Other;
                    break;
                case 1:
                    data_ = data_USGS;
                    break;
                case 2:
                    data_ = data_ = data_EMSC;
                    break;
                case 3:
                    data_ = data_GFZ;
                    break;
                case 4:
                    data_ = data_EarlyEst;
                    break;
                case 9:
                    data_ = data_All;
                    break;
                default:
                    throw new Exception("DataViewの初期化に失敗しました。", new ArgumentException($"{(int)viewData / 10}はデータ元として不正です。"));
            }




            config_view = config.Views[i];




        }

        private void DataView_Load(object sender, EventArgs e)
        {

        }

        public void Draw()
        {
            Data[] data = data_.Where(n => n.Value.Mag > config.Views[i].LowerMagLimit).Select(n => n.Value).ToArray();
            //data.ToList().Sort((x, y) => y.Time.CompareTo(x.Time));//並び替え
            switch (viewType)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }


        public Bitmap Draw_Latest(Data data)
        {
            Bitmap latestImg = new Bitmap(800, 1000);
            Graphics g = Graphics.FromImage(latestImg);


            int locX = data.Lon > 0 ? (int)Math.Round((data.Lon + 90d) * 10d, MidpointRounding.AwayFromZero) : (int)Math.Round((data.Lon + 450d) * 10d, MidpointRounding.AwayFromZero);
            int locY = (int)Math.Round((90d - data.Lat) * 10d, MidpointRounding.AwayFromZero);
            int locX_image = 400 - locX;
            int locY_image = 600 - locY;
            if (config_view.HypoShift)
                locY_image = Math.Min(200, Math.Max(-800, locY_image));
            g.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 90)), 0, 200, 800, 800);
            ImageCheck("map.png");
            g.DrawImage(Image.FromFile("Image\\map.png"), locX_image, locY_image, 5400, 1800);
            ImageCheck("hypo.png");
            g.DrawImage(Image.FromFile("Image\\hypo.png"), new Rectangle(360, locY + locY_image - 40, 80, 80), 0, 0, 80, 80, GraphicsUnit.Pixel, ia);
            g.FillRectangle(new SolidBrush(config_view.Colors.MapData_Back), 480, 950, 320, 50);
            g.DrawString("地図データ:Natural Earth", new Font(font, 19), new SolidBrush(config_view.Colors.MapData_Text), 490, 956);

            g.FillRectangle(new SolidBrush(config_view.Colors.Fore1_Back), 0, 0, 800, 200);
            g.FillRectangle(new SolidBrush(config_view.Colors.Back1_Back), 5, 40, 790, 155);
            g.DrawRectangle(new Pen(config_view.Colors.Border), 0, 0, 800, 200);
            g.DrawRectangle(new Pen(config_view.Colors.Border), 0, 200, 800, 800);

            g.DrawString(config_view.Title1Text, new Font(font, 20), Brushes.White, 0, 0);
            g.DrawString(Data2String(data, FormatPros.View, false, i), new Font(font, 20), new SolidBrush(config_view.Colors.Fore1_Text), 5, 42);




            return latestImg;
        }



        private void DataView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ok = MessageBox.Show("閉じてもいいですか？メイン画面から再表示できます。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (ok == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}

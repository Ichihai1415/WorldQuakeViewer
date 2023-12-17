﻿using System;
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
        readonly int viewType;
        readonly int i;
        readonly Dictionary<string, Data> data_;
        static Config.View_ config_view;
        public bool showing = false;

        public DataView(int viewIndex, ViewData viewData)
        {
            if (viewData == ViewData.Null)
                throw new ArgumentException($"ViewData({viewData})が不正です。", nameof(viewData));

            InitializeComponent();

            i = viewIndex;
            Text = $"WorldQuakeViewer[{viewIndex}] - {viewData}";
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
                    data_ = data_EMSC;
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

            //todo:一定時間でgreenにするやつ


        }

        private void DataView_Load(object sender, EventArgs e)
        {
            showing = true;
        }

        /// <summary>
        /// 描画して表示します。
        /// </summary>
        public void Draw()
        {
            Bitmap img;
            if (data_.Count == 0)
            {
                switch (viewType)
                {
                    case 1:
                        img = Draw_Latest(null);
                        break;
                    case 2:
                        img = Draw_History(null);
                        break;
                    case 3:
                        img = Draw_History(null, Draw_Latest(null));
                        break;
                    default:
                        return;
                }
            }
            else
            {
                List<Data> data = data_.Where(n => n.Value.Mag > config.Views[i].LowerMagLimit).Select(n => n.Value).ToList();
                data.Sort((x, y) => y.Time.CompareTo(x.Time));//並び替え
                switch (viewType)
                {
                    case 1:
                        img = Draw_Latest(data[0]);
                        break;
                    case 2:
                        img = Draw_History(data);
                        break;
                    case 3:
                        img = Draw_History(data.Skip(1).ToList(), Draw_Latest(data[0]));
                        break;
                    default:
                        return;
                }
            }
            BackgroundImage = null;
            BackgroundImage = img;
        }

        /// <summary>
        /// 最新の情報を描画します。
        /// </summary>
        /// <param name="data">描画するデータ</param>
        /// <returns>最新の情報の画像(800x1000)</returns>
        public Bitmap Draw_Latest(Data data)
        {
            Bitmap latestImg = new Bitmap(800, 1000);
            Graphics g = Graphics.FromImage(latestImg);
            if (data == null)
            {
                g.FillRectangle(new SolidBrush(config_view.Colors.Back1_Back), 0, 0, 800, 1000);
                g.FillRectangle(new SolidBrush(config_view.Colors.Fore1_Back), 4, 40, 792, 156);
                g.DrawString(config_view.Title1Text, new Font(font, 20), new SolidBrush(config_view.Colors.Back1_Text), 2, 2);
                g.DrawString("表示対象の情報を受信していません。", new Font(font, 20), new SolidBrush(config_view.Colors.Fore1_Text), 5, 42);
                g.DrawRectangle(new Pen(config_view.Colors.Border), 0, 0, 800, 200);
                g.DrawRectangle(new Pen(config_view.Colors.Border), 0, 200, 800, 800);

                g.Dispose();
                return latestImg;
            }
            //マップ
            int locX = data.Lon > 0 ? (int)Math.Round((data.Lon + 90d) * 10d, MidpointRounding.AwayFromZero) : (int)Math.Round((data.Lon + 450d) * 10d, MidpointRounding.AwayFromZero);
            int locY = (int)Math.Round((90d - data.Lat) * 10d, MidpointRounding.AwayFromZero);
            int locX_image = 400 - locX;
            int locY_image = 600 - locY;
            if (config_view.HypoShift)
                locY_image = Math.Min(200, Math.Max(-800, locY_image));
            g.FillRectangle(new SolidBrush(config_view.Colors.Fore1_Back), 0, 200, 800, 800);
            ImageCheck("map.png");
            g.DrawImage(Image.FromFile("Image\\map.png"), locX_image, locY_image, 5400, 1800);
            ImageCheck("hypo.png");
            g.DrawImage(Image.FromFile("Image\\hypo.png"), new Rectangle(360, locY + locY_image - 40, 80, 80), 0, 0, 80, 80, GraphicsUnit.Pixel, ia);
            g.FillRectangle(new SolidBrush(config_view.Colors.MapData_Back), 480, 950, 320, 50);
            g.DrawString("地図データ:Natural Earth", new Font(font, 19), new SolidBrush(config_view.Colors.MapData_Text), 490, 956);
            //最新
            g.FillRectangle(new SolidBrush(config_view.Colors.Back1_Back), 0, 0, 800, 200);
            g.FillRectangle(new SolidBrush(Alert2Color(data.Alert, 1, i)), 4, 40, 792, 156);//USGSアラート用
            g.FillRectangle(new SolidBrush(config_view.Colors.Fore1_Back), 8, 44, 784, 148);
            g.DrawString(config_view.Title1Text, new Font(font, 20), new SolidBrush(config_view.Colors.Back1_Text), 2, 2);
            g.DrawString(Data2String(data, FormatPros.View, false, i), new Font(font, 20), Mag2Brush(data.Mag, i), 5, 42);
            g.DrawString(data.MagType, new Font(font, 20), Mag2Brush(data.Mag, i), 640 - g.MeasureString(data.MagType, new Font(font, 20)).Width, 154);
            g.DrawString(data.Mag.ToString("0.0#"), new Font(font, 50), Mag2Brush(data.Mag, i), 640, 110);
            g.DrawRectangle(new Pen(config_view.Colors.Border), 0, 0, 800, 200);
            g.DrawRectangle(new Pen(config_view.Colors.Border), 0, 200, 800, 800);

            g.Dispose();
            return latestImg;
        }

        /// <summary>
        /// 履歴を描画します。
        /// </summary>
        /// <param name="datas">描画するデータのリスト</param>
        /// <param name="latestImage">最新の情報の画像(800x1000)、指定すれば最新+履歴画像になります(データのリストはSkip(1)してください)</param>
        /// <returns>履歴の情報の画像(800x1000)(latestImage=trueの場合1600x1000)</returns>
        public Bitmap Draw_History(List<Data> datas, Bitmap latestImage = null)
        {
            int w = latestImage == null ? 0 : 800;
            Bitmap histImg = new Bitmap(800 + w, 1000);
            Graphics g = Graphics.FromImage(histImg);
            if (w != 0)
                g.DrawImage(latestImage, 0, 0);
            if (datas == null)
            {
                g.FillRectangle(new SolidBrush(config_view.Colors.Fore2_Back), w, 0, 800, 200);
                g.DrawString(config_view.Title2Text, new Font(font, 20), new SolidBrush(config_view.Colors.Back2_Text), 2 + w, 2);
                for (int j = 0; j < 6; j++)
                    g.FillRectangle(new SolidBrush(config_view.Colors.Back2_Back), 4 + w, 40 + 160 * j, 792, 156);
                g.DrawRectangle(new Pen(config_view.Colors.Border), w, 0, 800, 1000);

                g.Dispose();
                return histImg;
            }
            g.FillRectangle(new SolidBrush(config_view.Colors.Fore1_Back), w, 0, 800, 1000);
            g.DrawString(config_view.Title1Text, new Font(font, 20), new SolidBrush(config_view.Colors.Back2_Text), 2 + w, 2);
            //履歴
            for (int j = 0; j < 6; j++)
                if (datas.Count > j)//データ不足対処
                {
                    Data data = datas[j];
                    g.FillRectangle(new SolidBrush(Alert2Color(data.Alert, 2, i)), 4 + w, 40 + 160 * j, 792, 156);//USGSアラート用
                    g.FillRectangle(new SolidBrush(config_view.Colors.Fore2_Back), 8 + w, 44, 784, 148);
                    g.DrawString(Data2String(data, FormatPros.View, false, i), new Font(font, 20), Mag2Brush(data.Mag, i), 5 + w, 42 + 160 * j);
                    g.DrawString(data.MagType, new Font(font, 20), Mag2Brush(data.Mag, i), 640 - g.MeasureString(data.MagType, new Font(font, 20)).Width + w, 154 + 160 * j);
                    g.DrawString(data.Mag.ToString("0.0#"), new Font(font, 50), Mag2Brush(data.Mag, i), 640 + w, 110 + 160 * j);
                }
                else
                    g.FillRectangle(new SolidBrush(config_view.Colors.Back2_Back), 4 + w, 40 + 160 * j, 792, 156);
            g.DrawRectangle(new Pen(config_view.Colors.Border), w, 0, 800, 1000);

            g.Dispose();
            return histImg;
        }


        private void DataView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ok = MessageBox.Show(topMost, "閉じてもいいですか？メイン画面から再表示できます。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (ok == DialogResult.Cancel)
                e.Cancel = true;
            else
                showing = false;
        }
    }
}

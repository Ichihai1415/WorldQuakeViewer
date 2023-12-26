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
    /// <summary>
    /// データ表示Form
    /// </summary>
    public partial class DataView : Form
    {
        readonly int viewType;
        readonly int i;
        readonly public int dataAuthorN;
        readonly Dictionary<string, Data> data_;
        private static Config.View_ config_view;
        public bool showing = false;

        /// <summary>
        /// データ表示Formを初期化します。
        /// </summary>
        /// <param name="viewIndex">表示インデックス</param>
        /// <param name="viewData">表示するデータ</param>
        /// <exception cref="ArgumentException">引数が不正な場合</exception>
        /// <exception cref="Exception">処理に失敗した場合</exception>
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
                case 4:
                    ClientSize = new Size(400, 500);
                    break;
                case 3:
                    ClientSize = new Size(800, 500);
                    break;
                default:
                    throw new Exception($"DataViewの初期化に失敗しました。{viewType}は種類として不正です。");
            }
            dataAuthorN = (int)viewData / 10;
            switch (dataAuthorN)
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
                    throw new Exception($"DataViewの初期化に失敗しました。{dataAuthorN}はデータ元として不正です。");
            }
            ConfigReload();
            ExeLog($"DataView[{i}]を初期化しました。");
            //todo:一定時間でgreenにするやつ(必要なら)
        }

        /// <summary>
        /// 設定を反映させます。
        /// </summary>
        private void ConfigReload()
        {
            config_view = config.Views[i];
            if (config_view.LockDataViewSize)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                MaximizeBox = false;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                MaximizeBox = true;
            }
        }

        private void DataView_Load(object sender, EventArgs e)
        {
            showing = true;
            Draw();
        }

        /// <summary>
        /// 描画して表示します。
        /// </summary>
        public void Draw()
        {
            ExeLog($"[Draw][{i}]描画中...");
            ConfigReload();
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
                    case 4:
                        img = Draw_AllLatestMulti(null);
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
                    case 4:
                        img = Draw_AllLatestMulti(data);
                        break;
                    default:
                        return;
                }
            }
            //BackgroundImage = null;
            ImageBox.BackgroundImage = img;
            ExeLog($"[Draw][{i}]描画完了");
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
                g.FillRectangle(new SolidBrush(config_view.Colors.Title_Latest_Back_Color), 0, 0, 800, 1000);
                g.FillRectangle(new SolidBrush(config_view.Colors.Main_Latest_Back_Color), 4, 40, 792, 156);
                g.DrawString(config_view.LatestTitleText, new Font(font, 20), new SolidBrush(config_view.Colors.Title_Latest_Text_Color), 2, 2);
                g.DrawString("表示対象の情報を受信していません。", new Font(font, 20), new SolidBrush(config_view.Colors.Main_Latest_Text_Color), 5, 42);
                g.DrawRectangle(new Pen(config_view.Colors.Border_Color), 0, 0, 800, 200);
                g.DrawRectangle(new Pen(config_view.Colors.Border_Color), 0, 200, 800, 800);

                g.Dispose();
                return latestImg;
            }
            //マップ
            double zoom = 800d / config_view.MapRange;//80°=>800px(x10)//40°=>800px(x20)
            int locX = data.Lon > 0 ? (int)Math.Round((data.Lon + 90) * zoom, MidpointRounding.AwayFromZero) : (int)Math.Round((data.Lon + 450) * zoom, MidpointRounding.AwayFromZero);//地図画像での経度の位置
            int locY = (int)Math.Round((90 - data.Lat) * zoom, MidpointRounding.AwayFromZero);//地図画像での緯度の位置
            int locX_image = 400 - locX;
            int locY_image = 600 - locY;
            if (config_view.HypoShift)
                locY_image = Math.Min(200, Math.Max((int)(-180 * zoom + 1000), locY_image));//-180*zoom+1000<locY_image<200
            g.FillRectangle(new SolidBrush(config_view.Colors.Main_Latest_Back_Color), 0, 200, 800, 800);
            ImageCheck("map.png");
            g.DrawImage(Image.FromFile("Image\\map.png"), locX_image, locY_image, (int)(540 * zoom), (int)(180 * zoom));
            ImageCheck("hypo.png");
            Image hypoImg = Image.FromFile("Image\\hypo.png");
            g.DrawImage(hypoImg, new Rectangle(400 - hypoImg.Width / 2, locY + locY_image - hypoImg.Height / 2, hypoImg.Width, hypoImg.Height), 0, 0, hypoImg.Width, hypoImg.Height, GraphicsUnit.Pixel, ia);
            g.FillRectangle(new SolidBrush(config_view.Colors.MapData_Back_Color), 504, 958, 296, 42);
            g.DrawString("地図データ:Natural Earth", new Font(font, 18), new SolidBrush(config_view.Colors.MapData_Text_Color), 510, 962);
            //最新
            g.FillRectangle(new SolidBrush(config_view.Colors.Title_Latest_Back_Color), 0, 0, 800, 200);
            g.FillRectangle(new SolidBrush(Alert2Color(data.Alert, 1, i)), 4, 40, 792, 156);//USGSアラート用
            g.FillRectangle(new SolidBrush(config_view.Colors.Main_Latest_Back_Color), 8, 44, 784, 148);
            g.DrawString(config_view.LatestTitleText, new Font(font, 20), new SolidBrush(config_view.Colors.Title_Latest_Text_Color), 2, 2);
            g.DrawString(Data2String(data, FormatPros.View, false, i), new Font(font, 19), Mag2Brush(data.Mag, 1, i), 8, 44);
            g.DrawString(data.MagType, new Font(font, 20), Mag2Brush(data.Mag, 1, i), 640 - g.MeasureString(data.MagType, new Font(font, 20)).Width, 154);
            g.DrawString(data.Mag.ToString("0.0#"), new Font(font, 50), Mag2Brush(data.Mag, 1, i), 640, 110);
            g.DrawRectangle(new Pen(config_view.Colors.Border_Color), 0, 0, 800, 200);
            g.DrawRectangle(new Pen(config_view.Colors.Border_Color), 0, 200, 800, 800);
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
                g.FillRectangle(new SolidBrush(config_view.Colors.Title_History_Back_Color), w, 0, 800, 1000);
                g.DrawString(config_view.HistoryTitleText, new Font(font, 20), new SolidBrush(config_view.Colors.Title_History_Text_Color), 2 + w, 2);
                for (int j = 0; j < 6; j++)
                    g.FillRectangle(new SolidBrush(config_view.Colors.Main_History_Back_Color), 4 + w, 40 + 160 * j, 792, 156);
                g.DrawRectangle(new Pen(config_view.Colors.Border_Color), w, 0, 800, 1000);

                g.Dispose();
                return histImg;
            }
            g.FillRectangle(new SolidBrush(config_view.Colors.Title_History_Back_Color), w, 0, 800, 1000);
            g.DrawString(config_view.HistoryTitleText, new Font(font, 20), new SolidBrush(config_view.Colors.Title_History_Text_Color), 2 + w, 2);
            //履歴
            for (int j = 0; j < 6; j++)
                if (datas.Count > j)//データ不足対処
                {
                    Data data = datas[j];
                    g.FillRectangle(new SolidBrush(Alert2Color(data.Alert, 2, i)), 4 + w, 40 + 160 * j, 792, 156);//USGSアラート用
                    g.FillRectangle(new SolidBrush(config_view.Colors.Main_History_Back_Color), 8 + w, 44 + 160 * j, 784, 148);
                    g.DrawString(Data2String(data, FormatPros.View, false, i), new Font(font, 19), Mag2Brush(data.Mag, 2, i), 8 + w, 44 + 160 * j);
                    g.DrawString(data.MagType, new Font(font, 20), Mag2Brush(data.Mag, 2, i), 640 - g.MeasureString(data.MagType, new Font(font, 20)).Width + w, 154 + 160 * j);
                    g.DrawString(data.Mag.ToString("0.0#"), new Font(font, 50), Mag2Brush(data.Mag, 2, i), 640 + w, 110 + 160 * j);
                }
                else
                    g.FillRectangle(new SolidBrush(config_view.Colors.Title_History_Back_Color), 4 + w, 40 + 160 * j, 792, 156);
            g.DrawRectangle(new Pen(config_view.Colors.Border_Color), w, 0, 800, 1000);
            g.Dispose();
            return histImg;
        }

        /// <summary>
        /// すべての最新1つずつ
        /// </summary>
        /// <remarks>ウィンドウサイズは自動で変更されます。</remarks>
        /// <param name="datas">描画するデータ</param>
        /// <returns>最新の情報の画像(800x(個数*200))</returns>
        public Bitmap Draw_AllLatestMulti(List<Data> datas)
        {
            if (datas == null)
            {
                Bitmap histImg_ = new Bitmap(800, 200);
                Graphics g_ = Graphics.FromImage(histImg_);

                g_.FillRectangle(new SolidBrush(config_view.Colors.Title_Latest_Back_Color), 0, 0, 800, 200);
                g_.FillRectangle(new SolidBrush(config_view.Colors.Main_Latest_Back_Color), 4, 40, 792, 156);
                g_.DrawString(config_view.LatestTitleText, new Font(font, 20), new SolidBrush(config_view.Colors.Title_Latest_Text_Color), 2, 2);
                g_.DrawString("表示対象の情報を受信していません。", new Font(font, 20), new SolidBrush(config_view.Colors.Main_Latest_Text_Color), 5, 42);
                g_.DrawRectangle(new Pen(config_view.Colors.Border_Color), 0, 0, 800, 200);

                g_.Dispose();
                ClientSize = new Size(400, 100);
                return histImg_;
            }
            int[] latests;
            string[] titles;
            try
            {
                latests = config_view.HistoryTitleText.Split(',').Select(n => int.Parse(n)).ToArray();
                titles = config_view.LatestTitleText.Split(',');
                if (latests.Count() != titles.Count())
                    throw new Exception($"表示用処理値が等しくありません。(latests:{latests.Count()},titles:{titles.Count()})設定を確認してください。");
            }
            catch (FormatException ex)
            {
                ExeLog($"[Draw_AllLatestMulti]エラー:{ex.Message}(設定を確認してください。)", true);
                LogSave(LogKind.Error, ex.ToString());
                return Draw_AllLatestMulti(null);
            }
            catch (Exception ex)
            {
                ExeLog($"[Draw_AllLatestMulti]エラー:{ex.Message}", true);
                LogSave(LogKind.Error, ex.ToString());
                return Draw_AllLatestMulti(null);
            }
            int h = 200 * latests.Count();
            Bitmap histImg = new Bitmap(800, h);
            Graphics g = Graphics.FromImage(histImg);

            g.FillRectangle(new SolidBrush(config_view.Colors.Title_Latest_Back_Color), 0, 0, 800, h);
            for (int j = 0; j < latests.Count(); j++)
            {
                IEnumerable<Data> datas_ = datas.Where(x => x.Author == (DataAuthor)latests[j]);//データ元一致
                g.DrawString(titles[j], new Font(font, 20), new SolidBrush(config_view.Colors.Title_Latest_Text_Color), 2, 2 + 200 * j);
                if (datas_.Count() == 0)
                {
                    g.FillRectangle(new SolidBrush(config_view.Colors.Main_Latest_Back_Color), 4, 40 + 200 * j, 792, 156);
                    g.DrawString("表示対象の情報を受信していません。", new Font(font, 19), new SolidBrush(config_view.Colors.Main_Latest_Text_Color), 8, 44 + 200 * j);
                }
                else
                {
                    Data data = datas_.First();
                    g.FillRectangle(new SolidBrush(Alert2Color(data.Alert, 1, i)), 4, 40 + 200 * j, 792, 156);//USGSアラート用
                    g.FillRectangle(new SolidBrush(config_view.Colors.Main_Latest_Back_Color), 8, 44 + 200 * j, 784, 148);
                    g.DrawString(Data2String(data, FormatPros.View, false, i), new Font(font, 19), Mag2Brush(data.Mag, 1, i), 8, 44 + 200 * j);
                    g.DrawString(data.MagType, new Font(font, 20), Mag2Brush(data.Mag, 1, i), 640 - g.MeasureString(data.MagType, new Font(font, 20)).Width, 154 + 200 * j);
                    g.DrawString(data.Mag.ToString("0.0#"), new Font(font, 50), Mag2Brush(data.Mag, 1, i), 640, 110 + 200 * j);
                }
                g.DrawRectangle(new Pen(config_view.Colors.Border_Color), 0, 200 * j, 800, 200);
            }
            g.Dispose();
            ClientSize = new Size(400, h / 2);
            return histImg;
        }

        private void DataView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                if (!DialogOK("閉じてもよろしいですか？メイン画面から再表示できます。"))
                {
                    e.Cancel = true;
                    return;
                }
            ExeLog($"[DataView_FormClosing]{e.CloseReason}により閉じられました。");
            showing = false;
        }
    }
}

using CoreTweet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using USGSQuakeClass;
using WorldQuakeViewer.Properties;

namespace WorldQuakeViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            NowVersion = "1.0.0";
        }
        private void MainForm_Load(object sender, EventArgs e)//設定読み込み
        {
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            if (File.Exists("setting.xml"))
                File.Copy("setting.xml", Config.FilePath, true);
            SettingReload();
        }
        private void JsonTimer_Tick(object sender, EventArgs e)//整理しろ
        {
            Console.WriteLine("///////////開始//////////");
            bool IsDebug = false;
            Settings.Default.Reload();
            JsonTimer.Interval = 30000;
            try
            {
                ErrorText.Text = "取得中…";
                WebClient WC = new WebClient
                {
                    Encoding = Encoding.UTF8
                };//↓？　暫定対処したやつかも
                string USGSQuakeJson_ = "[" + WC.DownloadString("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/4.5_day.geojson") + "]";
                Console.WriteLine("取得:https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/4.5_day.geojson");
                string Latestchecktime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                double StartTime = Convert.ToDouble(DateTime.Now.ToString("yyyyMMddHHmmss.ffff"));
                List<USGSQuake> USGSQuakeJson = JsonConvert.DeserializeObject<List<USGSQuake>>(USGSQuakeJson_);
                Console.WriteLine("各履歴処理開始");
                for (int i = 6; i >= 0; i--)//古い順に(消していくから)
                {
                    string ID = USGSQuakeJson[0].Features[i].Id;
                    DateTimeOffset Update = DateTimeOffset.FromUnixTimeMilliseconds((long)USGSQuakeJson[0].Features[i].Properties.Updated).ToLocalTime();
                    string UpdateTime = $"{Update:yyyy/MM/dd HH:mm:ss}";
                    string Updated = "";
                    if (Histories.ContainsKey(ID))
                        Updated = Histories[ID].UpdateTime;
                    if ($"{USGSQuakeJson[0].Features[i].Properties.Updated}" != Updated)
                    {
                        Console.WriteLine($"[{i}] 更新時刻変化検知");
                        string MaxInt = "-";
                        if (USGSQuakeJson[0].Features[i].Properties.Mmi < 1.5)
                            MaxInt = "I";
                        else if (USGSQuakeJson[0].Features[i].Properties.Mmi < 2.5)
                            MaxInt = "II";
                        else if (USGSQuakeJson[0].Features[i].Properties.Mmi < 3.5)
                            MaxInt = "III";
                        else if (USGSQuakeJson[0].Features[i].Properties.Mmi < 4.5)
                            MaxInt = "IV";
                        else if (USGSQuakeJson[0].Features[i].Properties.Mmi < 5.5)
                            MaxInt = "V";
                        else if (USGSQuakeJson[0].Features[i].Properties.Mmi < 6.5)
                            MaxInt = "VI";
                        else if (USGSQuakeJson[0].Features[i].Properties.Mmi < 7.5)
                            MaxInt = "VII";
                        else if (USGSQuakeJson[0].Features[i].Properties.Mmi < 8.5)
                            MaxInt = "VIII";
                        else if (USGSQuakeJson[0].Features[i].Properties.Mmi < 9.5)
                            MaxInt = "IX";
                        else if (USGSQuakeJson[0].Features[i].Properties.Mmi < 10.5)
                            MaxInt = "X";
                        else if (USGSQuakeJson[0].Features[i].Properties.Mmi < 11.5)
                            MaxInt = "XI";
                        else if (USGSQuakeJson[0].Features[i].Properties.Mmi >= 11.5)
                            MaxInt = "XII";
                        DateTimeOffset DataTimeOff = DateTimeOffset.FromUnixTimeMilliseconds((long)USGSQuakeJson[0].Features[i].Properties.Time).ToLocalTime();
                        string Time = Convert.ToString(DataTimeOff).Replace("+0", "※UTC +0").Replace("+1", "※UTC +1").Replace("-0", "※UTC -0").Replace("+1", "※UTC -1");
                        string Mag = $"{USGSQuakeJson[0].Features[i].Properties.Mag}";
                        if (Mag.Length == 1)
                            Mag += ".0";
                        LatestURL = USGSQuakeJson[0].Features[0].Properties.Url;
                        string MagType = USGSQuakeJson[0].Features[i].Properties.MagType;
                        double Lat = USGSQuakeJson[0].Features[i].Geometry.Coordinates[1];
                        double Long = USGSQuakeJson[0].Features[i].Geometry.Coordinates[0];
                        double LatShort = Math.Round(USGSQuakeJson[0].Features[i].Geometry.Coordinates[1], 2, MidpointRounding.AwayFromZero);
                        double LongShort = Math.Round(USGSQuakeJson[0].Features[i].Geometry.Coordinates[0], 2, MidpointRounding.AwayFromZero);
                        string Arart = "アラート:-";
                        if (USGSQuakeJson[0].Features[i].Properties.Alert != null)
                            Arart = Arart.Replace("-", USGSQuakeJson[0].Features[i].Properties.Alert.Replace("green", "緑").Replace("yellow", "黄").Replace("orange", "オレンジ").Replace("red", "赤").Replace("pending", "保留中"));
                        string LatStDecimal = $"N{Lat}".Replace("N-", "S");
                        string LongStDecimal = $"E{Long}".Replace("E-", "W");
                        TimeSpan LatTime = TimeSpan.FromHours(Lat);
                        TimeSpan LongTime = TimeSpan.FromHours(Long);
                        string LatStShort = $"{(int)Lat}ﾟ{LatTime.Minutes}'N";
                        string LongStShort = $"{(int)Long}ﾟ{LongTime.Minutes}'E";
                        if (Lat < 0)
                            LatStShort = $"{(int)Lat * -1}ﾟ{LatTime.Minutes * -1}'S";
                        if (Long < 0)
                            LongStShort = $"{(int)Long * -1}ﾟ{LongTime.Minutes * -1}'W";
                        string LatStLong = $"{(int)Lat}ﾟ{LatTime.Minutes}'{LatTime.Seconds}\"N";
                        string LongStLong = $"{(int)Long}ﾟ{LongTime.Minutes}'{LongTime.Seconds}\"E";
                        if (Lat < 0)
                            LatStLong = $"{(int)Lat * -1}ﾟ{LatTime.Minutes * -1}'{LatTime.Seconds * -1}\"S";
                        if (Long < 0)
                            LongStLong = $"{(int)Long * -1}ﾟ{LongTime.Minutes * -1}'{LongTime.Seconds * -1}\"W";
                        string LatStLongJP = $"北緯{(int)Lat}度{LatTime.Minutes}分{LatTime.Seconds}秒";
                        string LongStLongJP = $"東経{(int)Long}度{LongTime.Minutes}分{LongTime.Seconds}秒";
                        if (Lat < 0)
                            LatStLongJP = $"南緯{(int)Lat * -1}度{LatTime.Minutes * -1}分{LatTime.Seconds * -1}秒";
                        if (Long < 0)
                            LongStLongJP = $"西経{(int)Long * -1}度{LongTime.Minutes * -1}分{LongTime.Seconds * -1}秒";
                        if (Settings.Default.Text_LatLonDecimal)
                        {
                            LatStLongJP = $"北緯{Lat}度";
                            LongStLongJP = $"東経{Long}度";
                            if (Lat < 0)
                                LatStLongJP = $"南緯{Lat * -1}度";
                            if (Long < 0)
                                LongStLongJP = $"西経{Long * -1}度";
                        }
                        string LatView = LatStShort;
                        string LongView = LongStShort;
                        if (Settings.Default.Text_LatLonDecimal)
                        {
                            LatView = LatStDecimal;
                            LongView = LongStDecimal;
                        }
                        string Depth = $"深さ:約{(int)Math.Round(USGSQuakeJson[0].Features[i].Geometry.Coordinates[2], MidpointRounding.AwayFromZero)}km";
                        if (USGSQuakeJson[0].Features[i].Geometry.Coordinates[2] == (int)USGSQuakeJson[0].Features[i].Geometry.Coordinates[2])
                            Depth = $"(深さ:{USGSQuakeJson[0].Features[i].Geometry.Coordinates[2]}km?)";//整数
                        string DepthLong = $"深さ:{USGSQuakeJson[0].Features[i].Geometry.Coordinates[2]}km";
                        if (USGSQuakeJson[0].Features[i].Geometry.Coordinates[2] == (int)USGSQuakeJson[0].Features[i].Geometry.Coordinates[2])
                            DepthLong = Depth;
                        string MMI = "-";
                        if (USGSQuakeJson[0].Features[i].Properties.Mmi != null)
                            MMI = $"({Convert.ToString(USGSQuakeJson[0].Features[i].Properties.Mmi)})";
                        string Shingen = "震源の取得に失敗しました。";
                        string JPNameNotFoundLogText = "";
                        if (File.Exists("Log\\JPNameNotFound.txt"))
                            JPNameNotFoundLogText = $"{File.ReadAllText($"Log\\JPNameNotFound.txt")}";
                        Point HypoPoint = new Point((int)(LatShort * 100), (int)(LongShort * 100));
                        if (HypoIDs.ContainsKey(HypoPoint))
                        {
                            Shingen = "震源:" + HypoName[HypoIDs[HypoPoint]];
                            Console.WriteLine("震源キャッシュが存在します");
                        }
                        else
                        {
                            Console.WriteLine("震源キャッシュが存在しません。ダウンロードします。");
                            string USGSFERegion_ = "";
                            try
                            {
                                USGSFERegion_ = WC.DownloadString($"https://earthquake.usgs.gov/ws/geoserve/regions.json?latitude={LatShort}&longitude={LongShort}&type=fe");
                                Console.WriteLine($"取得:$\"https://earthquake.usgs.gov/ws/geoserve/regions.json?latitude={{LatShort}}&longitude={{LongShort}}&type=fe\"");
                                JObject USGSFERegion = JObject.Parse(USGSFERegion_);
                                for (int j = 0; j < (int)USGSFERegion.SelectToken("fe.count"); j++)
                                {
                                    if ((int?)USGSFERegion.SelectToken($"fe.features[{j}].properties.number") != null)
                                        if (HypoName.ContainsKey((int)USGSFERegion.SelectToken($"fe.features[{j}].properties.number")))
                                        {
                                            Shingen = "震源:" + HypoName[(int)USGSFERegion.SelectToken($"fe.features[{j}].properties.number")];
                                            HypoIDs.Add(HypoPoint, (int)USGSFERegion.SelectToken($"fe.features[{j}].properties.number"));
                                            break;
                                        }
                                    if (JPNameNotFoundLogText.Contains($"lat={LatShort},lon={LongShort},num=null,name={USGSFERegion.SelectToken($"fe.features[{j}].properties.name")}"))
                                        JPNameNotFoundLogText += $"\nlat={LatShort},lon={LongShort},num=null,name={USGSFERegion.SelectToken($"fe.features[{j}].properties.name")}";
                                }
                                File.WriteAllText($"Log\\JPNameNotFound.txt", JPNameNotFoundLogText);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("震源名取得に失敗しました。" + ex);
                            }
                        }
                        string Shingen2 = $"({USGSQuakeJson[0].Features[i].Properties.Place})";
                        string LogText_ = $"USGS地震情報【{MagType}{Mag}】{Time.Replace("※", "(")})\n{Shingen}{Shingen2}\n{LatView},{LongView}　{Depth}\n改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}　{Arart.Replace("アラート:-", "")}\n{USGSQuakeJson[0].Features[i].Properties.Url}";
                        string BouyomiText = $"USGS地震情報。マグニチュード{Mag}、震源、{Shingen.Replace(" ", "、").Replace("/", "、").Replace("震源:", "")}、{LatStLongJP}、{LongStLongJP}、深さ{DepthLong.Replace("深さ:", "")}。{$"推定最大改正メルカリ震度階級{MMI.Replace("(", "").Replace(")", "")}".Replace("改正メルカリ震度階級-", "")}。{Arart.Replace("アラート:-", "")}";
                        bool NewUpdt = false;
                        if (!Histories.ContainsKey(ID))//Keyないと探したときエラーになるから別化
                            NewUpdt = true;
                        else if (Histories[ID].Text != LogText_)
                            NewUpdt = true;
                        Console.WriteLine(LogText_);
                        if (NewUpdt)//更新、初回検知
                        {
                            Console.WriteLine("//////////更新または初回検知//////////");
                            if (Histories.ContainsKey(ID))
                            {
                                LogText_ = LogText_.Replace("USGS地震情報", "USGS地震情報(更新)");
                                BouyomiText = BouyomiText.Replace("USGS地震情報", "USGS地震情報、更新");
                            }
                            History history = new History
                            {
                                Text = LogText_,
                                UpdateTime = Updated,
                                TweetID = 0
                            };
                            if (Histories.ContainsKey(ID))//更新
                                Histories[ID] = history;
                            else//new
                            {
                                Histories.Add(ID, history);
                                if (Histories.Count > 7)
                                {
                                    Console.WriteLine($"{Histories.First().Key}を削除しました。");
                                    Histories.Remove(Histories.First().Key);
                                }

                            }
                            LogSave("Log\\M4.5+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                            if (i == 0)
                            {
                                //x:+200が中心 左余白-250 y:+300が中心
                                int LocX = (int)(Long + 180) * -5 - 50;//(-180,0,180) + 180 -> (0,180,360)
                                int LocY = (int)(90 - Lat) * -5 + 300;//90 - (90,0,-90) -> (0,90,180)
                                MainImg.Location = new Point(LocX, LocY);
                                Bitmap MainBitmap = new Bitmap(Resources.WorldMap);
                                Graphics graphics = Graphics.FromImage(MainBitmap);
                                graphics.DrawImage(Resources.Point, new Rectangle(LocX * -1 + 185, LocY * -1 + 285, 30, 30));
                                MainImg.Image = MainBitmap;
                                graphics.Dispose();
                                USGS0.Text = $"USGS地震情報　　　　　{Time}";
                                USGS1.Text = $"{Shingen}\n{Shingen2}\n{LatView},{LongView}\n{Depth}";
                                USGS2.Text = $"{MagType}";
                                USGS3.Text = $"{Mag}";
                                USGS4.Text = $"改正メルカリ\n　　震度階級:";
                                USGS5.Text = $"{MMI.Replace("(", "").Replace(")", "")}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    USGS0.ForeColor = Color.Yellow;
                                    USGS1.ForeColor = Color.Yellow;
                                    USGS2.ForeColor = Color.Yellow;
                                    USGS3.ForeColor = Color.Yellow;
                                    USGS4.ForeColor = Color.Yellow;
                                    USGS5.ForeColor = Color.Yellow;
                                    LogSave("Log\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);

                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
                                    {
                                        USGS0.ForeColor = Color.Red;
                                        USGS1.ForeColor = Color.Red;
                                        USGS2.ForeColor = Color.Red;
                                        USGS3.ForeColor = Color.Red;
                                        USGS4.ForeColor = Color.Red;
                                        USGS5.ForeColor = Color.Red;
                                        LogSave("Log\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    }
                                }
                                else
                                {
                                    USGS0.ForeColor = Color.White;
                                    USGS1.ForeColor = Color.White;
                                    USGS2.ForeColor = Color.White;
                                    USGS3.ForeColor = Color.White;
                                    USGS4.ForeColor = Color.White;
                                    USGS5.ForeColor = Color.White;
                                }
                                if (USGSQuakeJson[0].Features[i].Properties.Alert == null)
                                {
                                    USGS0.BackColor = Color.Black;
                                    USGS0.ForeColor = Color.White;
                                }
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "green")
                                {
                                    USGS0.BackColor = Color.Green;
                                    USGS0.ForeColor = Color.White;
                                }
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "yellow")
                                {
                                    USGS0.BackColor = Color.Yellow;
                                    USGS0.ForeColor = Color.Black;
                                }
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "orange")
                                {
                                    USGS0.BackColor = Color.Orange;
                                    USGS0.ForeColor = Color.Black;
                                }
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "red")
                                {
                                    USGS0.BackColor = Color.Red;
                                    USGS0.ForeColor = Color.White;
                                }
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "pending")
                                {
                                    USGS0.BackColor = Color.DimGray;
                                    USGS0.ForeColor = Color.White;
                                }
                                USGS6.Text = $"{UpdateTime}発表\n{Latestchecktime}取得\n地図データ:NationalEarth";
                                USGS6.Location = new Point(400 - USGS6.Width, 500 - USGS6.Height);
                            }
                            else if (i == 1)//履歴
                            {
                                History11.Text = $"{Time}発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History12.Text = $"{MagType}";
                                History13.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History11.ForeColor = Color.Yellow;
                                    History12.ForeColor = Color.Yellow;
                                    History13.ForeColor = Color.Yellow;
                                    LogSave("Log\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
                                    {
                                        History11.ForeColor = Color.Red;
                                        History12.ForeColor = Color.Red;
                                        History13.ForeColor = Color.Red;
                                        LogSave("Log\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    }
                                }
                                else
                                {
                                    History11.ForeColor = Color.White;
                                    History12.ForeColor = Color.White;
                                    History13.ForeColor = Color.White;
                                }
                                if (USGSQuakeJson[0].Features[i].Properties.Alert == null)
                                    History10.BackColor = Color.FromArgb(45, 45, 90);
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "green")
                                    History10.BackColor = Color.Green;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "yellow")
                                    History10.BackColor = Color.Yellow;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "orange")
                                    History10.BackColor = Color.Orange;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "red")
                                    History10.BackColor = Color.Red;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "pending")
                                    History10.BackColor = Color.DimGray;
                            }
                            else if (i == 2)
                            {
                                History21.Text = $"{Time}発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History22.Text = $"{MagType}";
                                History23.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History21.ForeColor = Color.Yellow;
                                    History22.ForeColor = Color.Yellow;
                                    History23.ForeColor = Color.Yellow;
                                    LogSave("Log\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
                                    {
                                        History21.ForeColor = Color.Red;
                                        History22.ForeColor = Color.Red;
                                        History23.ForeColor = Color.Red;
                                        LogSave("Log\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    }
                                }
                                else
                                {
                                    History21.ForeColor = Color.White;
                                    History22.ForeColor = Color.White;
                                    History23.ForeColor = Color.White;
                                }
                                if (USGSQuakeJson[0].Features[i].Properties.Alert == null)
                                    History20.BackColor = Color.FromArgb(45, 45, 90);
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "green")
                                    History20.BackColor = Color.Green;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "yellow")
                                    History20.BackColor = Color.Yellow;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "orange")
                                    History20.BackColor = Color.Orange;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "red")
                                    History20.BackColor = Color.Red;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "pending")
                                    History20.BackColor = Color.DimGray;
                            }
                            else if (i == 3)
                            {
                                History31.Text = $"{Time}発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History32.Text = $"{MagType}";
                                History33.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History31.ForeColor = Color.Yellow;
                                    History32.ForeColor = Color.Yellow;
                                    History33.ForeColor = Color.Yellow;
                                    LogSave("Log\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
                                    {
                                        History31.ForeColor = Color.Red;
                                        History32.ForeColor = Color.Red;
                                        History33.ForeColor = Color.Red;
                                        LogSave("Log\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    }
                                }
                                else
                                {
                                    History31.ForeColor = Color.White;
                                    History32.ForeColor = Color.White;
                                    History33.ForeColor = Color.White;
                                }
                                if (USGSQuakeJson[0].Features[i].Properties.Alert == null)
                                    History30.BackColor = Color.FromArgb(45, 45, 90);
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "green")
                                    History30.BackColor = Color.Green;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "yellow")
                                    History30.BackColor = Color.Yellow;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "orange")
                                    History30.BackColor = Color.Orange;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "red")
                                    History30.BackColor = Color.Red;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "pending")
                                    History30.BackColor = Color.DimGray;
                            }
                            else if (i == 4)
                            {
                                History41.Text = $"{Time}発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History42.Text = $"{MagType}";
                                History43.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History41.ForeColor = Color.Yellow;
                                    History42.ForeColor = Color.Yellow;
                                    History43.ForeColor = Color.Yellow;
                                    LogSave("Log\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
                                    {
                                        History41.ForeColor = Color.Red;
                                        History42.ForeColor = Color.Red;
                                        History43.ForeColor = Color.Red;
                                        LogSave("Log\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    }
                                }
                                else
                                {
                                    History41.ForeColor = Color.White;
                                    History42.ForeColor = Color.White;
                                    History43.ForeColor = Color.White;
                                }
                                if (USGSQuakeJson[0].Features[i].Properties.Alert == null)
                                    History40.BackColor = Color.FromArgb(45, 45, 90);
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "green")
                                    History40.BackColor = Color.Green;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "yellow")
                                    History40.BackColor = Color.Yellow;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "orange")
                                    History40.BackColor = Color.Orange;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "red")
                                    History40.BackColor = Color.Red;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "pending")
                                    History40.BackColor = Color.DimGray;
                            }
                            else if (i == 5)
                            {
                                History51.Text = $"{Time}発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History52.Text = $"{MagType}";
                                History53.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History51.ForeColor = Color.Yellow;
                                    History52.ForeColor = Color.Yellow;
                                    History53.ForeColor = Color.Yellow;
                                    LogSave("Log\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
                                    {
                                        History51.ForeColor = Color.Red;
                                        History52.ForeColor = Color.Red;
                                        History53.ForeColor = Color.Red;
                                        LogSave("Log\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    }
                                }
                                else
                                {
                                    History51.ForeColor = Color.White;
                                    History52.ForeColor = Color.White;
                                    History53.ForeColor = Color.White;
                                }
                                if (USGSQuakeJson[0].Features[i].Properties.Alert == null)
                                    History50.BackColor = Color.FromArgb(45, 45, 90);
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "green")
                                    History50.BackColor = Color.Green;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "yellow")
                                    History50.BackColor = Color.Yellow;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "orange")
                                    History50.BackColor = Color.Orange;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "red")
                                    History50.BackColor = Color.Red;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "pending")
                                    History50.BackColor = Color.DimGray;
                            }
                            else if (i == 6)
                            {
                                History61.Text = $"{Time}発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History62.Text = $"{MagType}";
                                History63.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History61.ForeColor = Color.Yellow;
                                    History62.ForeColor = Color.Yellow;
                                    History63.ForeColor = Color.Yellow;
                                    LogSave("Log\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
                                    {
                                        History61.ForeColor = Color.Red;
                                        History62.ForeColor = Color.Red;
                                        History63.ForeColor = Color.Red;
                                        LogSave("Log\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}", ID);
                                    }
                                }
                                else
                                {
                                    History61.ForeColor = Color.White;
                                    History62.ForeColor = Color.White;
                                    History63.ForeColor = Color.White;
                                }
                                if (USGSQuakeJson[0].Features[i].Properties.Alert == null)
                                    History60.BackColor = Color.FromArgb(45, 45, 90);
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "green")
                                    History60.BackColor = Color.Green;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "yellow")
                                    History60.BackColor = Color.Yellow;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "orange")
                                    History60.BackColor = Color.Orange;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "red")
                                    History60.BackColor = Color.Red;
                                else if (USGSQuakeJson[0].Features[i].Properties.Alert == "pending")
                                    History60.BackColor = Color.DimGray;
                            }
                            if (USGSQuakeJson[0].Features[i].Properties.Mag >= Settings.Default.Bouyomichan_LowerMagnitudeLimit || USGSQuakeJson[0].Features[i].Properties.Mmi >= Settings.Default.Bouyomichan_LowerMMILimit)
                                if (Settings.Default.Bouyomichan_Valid && IsDebug == false)//読み上げ
                                    try
                                    {
                                        byte[] Message = Encoding.UTF8.GetBytes(BouyomiText);
                                        int Length = Message.Length;
                                        using (TcpClient TcpClient = new TcpClient(Settings.Default.Bouyomichan_Host, Settings.Default.Bouyomichan_Port))
                                        using (NetworkStream NetworkStream = TcpClient.GetStream())
                                        using (BinaryWriter BinaryWriter = new BinaryWriter(NetworkStream))
                                        {
                                            BinaryWriter.Write(0);
                                            BinaryWriter.Write(Settings.Default.Bouyomichan_Speed);
                                            BinaryWriter.Write(Settings.Default.Bouyomichan_Tone);
                                            BinaryWriter.Write(Settings.Default.Bouyomichan_Volume);
                                            BinaryWriter.Write(Settings.Default.Bouyomichan_Voice);
                                            BinaryWriter.Write(0);
                                            BinaryWriter.Write(Message.Length);
                                            BinaryWriter.Write(Message);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception("読み上げ送信に失敗しました。内容:" + ex.Message);
                                    }
                            if (USGSQuakeJson[0].Features[i].Properties.Mag >= Settings.Default.Tweet_LowerMagnitudeLimit || USGSQuakeJson[0].Features[i].Properties.Mmi >= Settings.Default.Tweet_LowerMMILimit)
                                if (Settings.Default.Tweet_Valid && IsDebug == false)
                                    Tweet(LogText_, ID);
                        }
                        else
                            Console.WriteLine($"[{i}] 内容更新なし");
                    }
                    else
                        Console.WriteLine($"[{i}] 更新なし");
                }
            }
            catch (WebException ex)
            {
                ErrorText.Text = $"ネットワークエラーが発生しました。\n内容:" + ex.Message;
            }
            catch (Exception ex)
            {
                ErrorText.Text = $"エラーが発生しました。\nエラーログの内容を報告してください。\n内容:" + ex.Message;
                LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main Version:{NowVersion}\n{ex}");
            }
            ErrorText.Text = ErrorText.Text.Replace("取得中…", "");
            NoFirst = true;
            Console.WriteLine("処理終了");
        }
        public string NowVersion = "";
        public string LatestURL = "";
        public bool NoFirst = false;//最初はツイートしない
        public Dictionary<string, History> Histories = new Dictionary<string, History>();//ID,Data
        public Dictionary<Point, int> HypoIDs = new Dictionary<Point, int>();//Location,ID

        /// <summary>
        /// ログを保存します。
        /// </summary>
        /// <param name="SaveDirectory">保存するディレクトリ。Log\\[M4.5+,M6.0+,M8.0+,ErrorLog...]</param>
        /// <param name="SaveText">保存するテキスト。</param>
        /// <param name="ID">地震ログ保存時用地震ID。</param>
        public void LogSave(string SaveDirectory, string SaveText, string ID = null)
        {
            DateTime NowTime = DateTime.Now;
            if (Directory.Exists("Log") == false)
                Directory.CreateDirectory("Log");
            if (!Directory.Exists(SaveDirectory))
                Directory.CreateDirectory(SaveDirectory);
            if (SaveDirectory == "Log")
            {
                if (File.Exists($"Log\\log.txt"))
                    SaveText += "\n--------------------------------------------------\n" + File.ReadAllText($"Log\\log.txt");
                File.WriteAllText($"Log\\log.txt", SaveText);
            }
            else if (SaveDirectory == "Log\\ErrorLog")
            {
                if (File.Exists($"Log\\ErrorLog\\{NowTime:yyyyMM}.txt"))
                    SaveText += "\n--------------------------------------------------\n" + File.ReadAllText($"Log\\ErrorLog\\{NowTime:yyyyMM}.txt");
                File.WriteAllText($"Log\\ErrorLog\\{NowTime:yyyyMM}.txt", SaveText);
            }
            else if (SaveDirectory.Contains("Log\\M"))
            {
                if (!Directory.Exists($"{SaveDirectory}\\{NowTime:yyyyMM}"))
                    Directory.CreateDirectory($"{SaveDirectory}\\{NowTime:yyyyMM}");
                if (!Directory.Exists($"{SaveDirectory}\\{NowTime:yyyyMM}\\{NowTime:dd}"))
                    Directory.CreateDirectory($"{SaveDirectory}\\{NowTime:yyyyMM}\\{NowTime:dd}");
                if (File.Exists($"{SaveDirectory}\\{NowTime:yyyyMM}\\{NowTime:dd}\\{NowTime:yyyyMMdd}_{ID}.txt"))
                    SaveText = File.ReadAllText($"{SaveDirectory}\\{NowTime:yyyyMM}\\{NowTime:dd}\\{NowTime:yyyyMMdd}_{ID}.txt") + "\n--------------------------------------------------\n" + SaveText;
                File.WriteAllText($"{SaveDirectory}\\{NowTime:yyyyMM}\\{NowTime:dd}\\{NowTime:yyyyMMdd}_{ID}.txt", SaveText);
            }
            else
            {
                if (!Directory.Exists($"{SaveDirectory}\\{NowTime:yyyyMM}"))
                    Directory.CreateDirectory($"{SaveDirectory}\\{NowTime:yyyyMM}");
                if (File.Exists($"{SaveDirectory}\\{NowTime:yyyyMM}\\{NowTime:yyyyMMdd}.txt"))
                    SaveText = File.ReadAllText($"{SaveDirectory}\\{NowTime:yyyyMM}\\{NowTime:yyyyMMdd}.txt") + "\n--------------------------------------------------\n" + SaveText;
                File.WriteAllText($"{SaveDirectory}\\{NowTime:yyyyMM}\\{NowTime:yyyyMMdd}.txt", SaveText);
            }
        }
        /// <summary>
        /// ツイートします。
        /// </summary>
        /// <param name="Text">ツイートするテキスト。</param>
        /// <param name="ID">リプライ判別用ID。</param>
        public void Tweet(string Text, string ID)
        {
            if (NoFirst)
                try
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    Tokens tokens;
                    try
                    {
                        tokens = Tokens.Create(Settings.Default.Tweet_ConsumerKey, Settings.Default.Tweet_ConsumerSecret, Settings.Default.Tweet_AccessToken, Settings.Default.Tweet_AccessSecret);
                    }
                    catch
                    {
                        ErrorText.Text = $"Tokenが正しくありません。";
                        throw new Exception("Tokenが正しくありません。");
                    }
                    Status status = new Status();
                    if (Histories[ID].TweetID != 0)
                        try
                        {
                            status = tokens.Statuses.Update(new { status = Text, in_reply_to_status_id = Histories[ID].TweetID });
                        }
                        catch
                        {
                            status = tokens.Statuses.Update(new { status = Text });
                        }
                    else
                        status = tokens.Statuses.Update(new { status = Text });

                    Histories[ID].TweetID = status.Id;
                }
                catch (Exception ex)
                {
                    ErrorText.Text = $"ツイートに失敗しました。\nわからない場合エラーログの内容を報告してください。\n内容:" + ex.Message;
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Tweet Version:{NowVersion}\n{ex}");
                }
        }
        /// <summary>
        /// 設定を読み込みます。
        /// </summary>
        /// <remarks>即時サイズ変更を行います。</remarks>
        public void SettingReload()
        {
            Settings.Default.Reload();
            if (Settings.Default.Display_HideHistory)
                if (Settings.Default.Display_HideHistoryMap)
                    Size = new Size(416, 139);//400,100
                else
                    Size = new Size(416, 539);//400,500
            else
                Size = new Size(816, 539);//800,500
        }
        private void RCsetting_Click(object sender, EventArgs e)
        {
            SettingsForm Settings = new SettingsForm();
            Settings.Show();
        }
        private void RC1SettingReload_Click(object sender, EventArgs e)
        {
            SettingReload();
            MessageBox.Show("設定を再読み込みしました。一部の設定は情報受信または再起動が必要です。","WQV_Setting",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void RCusgsmap_Click(object sender, EventArgs e)
        {
            Process.Start("https://earthquake.usgs.gov/earthquakes/map/");
        }
        private void RCusgsthis_Click(object sender, EventArgs e)
        {
            Process.Start(LatestURL);
        }
        private void RCreboot_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void RCexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void RCgithub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Ichihai1415/WorldQuakeViewer");
        }
        private void RCtwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/ProjectS31415_1");
        }
        private void RCopenreadme_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ichihai1415/WorldQuakeViewer/blob/main/README.md");
        }
        private void RCtsunami_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.tsunami.gov/");
        }
        private void RCinfopage_Click(object sender, EventArgs e)
        {
            Process.Start("https://Ichihai1415.github.io/programs/released/world_quake_viewer");
        }
        private void MainForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Process.Start("https://Ichihai1415.github.io/programs/released/world_quake_viewer/#help");
        }
        private void RCMapEWSC_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.emsc-csem.org/#2w");
        }
        private void RCEarlyEst_Click(object sender, EventArgs e)
        {
            Process.Start("http://early-est.rm.ingv.it/warning.html");
        }
    }
}
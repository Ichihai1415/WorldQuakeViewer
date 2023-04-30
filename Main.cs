using CoreTweet;
using LL2FERC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using USGSQuakeClass;
using WorldQuakeViewer.Properties;

namespace WorldQuakeViewer
{
    public partial class MainForm : Form
    {
        public static readonly string Version = "1.1.0α4";//こことアセンブリを変える
        public static DateTime StartTime = new DateTime();
        public static int AccessedUSGS = 0;
        public string LatestURL = "";
        public static bool NoFirst = false;//最初はツイートとかしない
        public static string ExeLogs = "";
        public Dictionary<string, History> Histories = new Dictionary<string, History>();//EQID,Data
        public Font F9 = null;
        public Font F9_5 = null;
        public Font F10 = null;
        public Font F11 = null;
        public Font F12 = null;
        public Font F20 = null;
        public Font F22 = null;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)//ExeLog($"");
        {
            ExeLog($"起動処理開始");
            StartTime = DateTime.Now;
            HistoryBack.Text = $"履歴                                                                Version:{Version}";
            ErrorText.Text = "フォント読み込み中…";
            try
            {
                while (!File.Exists("Font\\Koruri-Regular.ttf"))
                {
                    if (!Directory.Exists("Font"))
                        Directory.CreateDirectory("Font");
                    Process.Start("https://koruri.github.io/");
                    Process.Start("explorer.exe", "Font");
                    DialogResult Result = MessageBox.Show($"フォントファイルが見つかりません。ダウンロードサイトとFontフォルダを開きます。\"Koruri-Regular.ttf\"をFontフォルダにコピーしてください。", "WQV_FontCheck", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation);
                    if (Result == DialogResult.Ignore)
                        break;
                    if (Result != DialogResult.Retry)
                    {
                        Application.Exit();
                        break;//これないとプロセス無限起動される
                    }
                    Thread.Sleep(1000);//念のため
                }
                ExeLog($"フォントファイルOK");
                PrivateFontCollection pfc = new PrivateFontCollection();
                pfc.AddFontFile("Font\\Koruri-Regular.ttf");
                /*//なぜかエラー出るからフォント必須に
                F9 = new Font(pfc.Families[0], 9F);
                F9_5 = new Font(pfc.Families[0], 9.5F);
                F10 = new Font(pfc.Families[0], 10F);
                F11 = new Font(pfc.Families[0], 11F);
                F12 = new Font(pfc.Families[0], 12F);
                F20 = new Font(pfc.Families[0], 20F);
                F22 = new Font(pfc.Families[0], 22F);
                ExeLog("F9  :" + F9);
                ExeLog("F9_5:" + F9_5);
                ExeLog("F10 :" + F10);
                ExeLog("F11 :" + F11);
                ExeLog("F12 :" + F12);
                ExeLog("F20 :" + F20);
                ExeLog("F22 :" + F22);
                if (F9 !=  F22)//おかしいときname="使用されたパラメーターが有効ではありません。"になるため　なぜかおかしくなくてもエラー出る
                {
                    ExeLog("フォントの読み込みに成功");
                    Font = F10;
                    USGS0.Font = F9;
                    USGS1.Font = F11;
                    USGS2.Font = F11;
                    USGS3.Font = F20;
                    USGS4.Font = F11;
                    USGS5.Font = F20;
                    USGS6.Font = F9;
                    ErrorText.Font = F12;
                    HistoryBack.Font = F10;
                    History11.Font = F9_5;
                    History12.Font = F10;
                    History13.Font = F22;
                    History21.Font = F9_5;
                    History22.Font = F10;
                    History23.Font = F22;
                    History31.Font = F9_5;
                    History32.Font = F10;
                    History33.Font = F22;
                    History41.Font = F9_5;
                    History42.Font = F10;
                    History43.Font = F22;
                    History51.Font = F9_5;
                    History52.Font = F10;
                    History53.Font = F22;
                    History61.Font = F9_5;
                    History62.Font = F10;
                    History63.Font = F22;
                }
                else*/
                {
                    InstalledFontCollection ifc = new InstalledFontCollection();
                    while (ifc.Families.Contains(pfc.Families[0]))
                    {
                        Process.Start("fontview.exe", "Font\\Koruri-Regular.ttf");
                        DialogResult Result = MessageBox.Show($"フォントがインストールされていません。Font\\Koruri-Regular.ttfをインストールしてください。", "WQV_FontCheck", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                        if (Result != DialogResult.Retry)
                        {
                            Application.Exit();
                            break;//これないとプロセス無限起動される
                        }
                        Thread.Sleep(1000);//念のため
                        ifc = new InstalledFontCollection();
                    }
                    ifc.Dispose();
                    ExeLog($"フォントOK");
                }
                pfc.Dispose();
            }
            catch
            {
                ExeLog($"フォント確認に失敗");
            }
            ErrorText.Text = "設定読み込み中…";
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            if (File.Exists("UserSetting.xml"))//AppDataに保存
            {
                if (!Directory.Exists(Config.FilePath.Replace("\\user.config", "")))//実質更新時
                    Directory.CreateDirectory(Config.FilePath.Replace("\\user.config", ""));
                File.Copy("UserSetting.xml", Config.FilePath, true);
                ExeLog($"設定ファイルをAppDataにコピー");
            }
            SettingReload();
            ErrorText.Text = "設定の読み込みが完了しました。";
            ExeLog($"設定読み込み完了");
            JsonTimer.Enabled = true;
        }
        private async void JsonTimer_Tick(object sender, EventArgs e)
        {
            JsonTimer.Interval = 30000;
            try
            {
                ErrorText.Text = "取得中…";
                ExeLog($"//////////取得開始//////////");
                WebClient WC = new WebClient
                {
                    Encoding = Encoding.UTF8
                };
                string json_ = await WC.DownloadStringTaskAsync(new Uri("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/4.5_week.geojson"));
                ExeLog($"取得完了");
                AccessedUSGS++;
                string LastCheckTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                double StartTime = Convert.ToDouble(DateTime.Now.ToString("yyyyMMddHHmmss.ffff"));
                USGSQuake json = JsonConvert.DeserializeObject<USGSQuake>(json_);
                DateTimeOffset Update_ = DateTimeOffset.FromUnixTimeMilliseconds(json.Metadata.Generated).ToLocalTime();
                string UpdateTime_ = $"{Update_:yyyy/MM/dd HH:mm:ss}";
                int SoundLevel = 0;//音声判別用 初報ほど、M大きいほど高い
                ExeLog($"各履歴処理開始");
                LatestURL = json.Features[0].Properties.Url;
                for (int i = Math.Min(Settings.Default.Update_MaxCount, json.Features.Count) - 1; i >= 0; i--)//送信の都合上古い順に
                    if (json.Features.Count > i)
                    {
                        bool New = false;//音声判別用
                        string ID = json.Features[i].Id;
                        long Updated = json.Features[i].Properties.Updated;
                        ExeLog($"処理[{i}]:{ID}");
                        DateTimeOffset Update = DateTimeOffset.FromUnixTimeMilliseconds(Updated).ToLocalTime();
                        string UpdateTime = $"{Update:yyyy/MM/dd HH:mm:ss}";
                        long LastUpdated = 0;
                        if (Histories.ContainsKey(ID))
                            LastUpdated = Histories[ID].Update;
                        ErrorText.Text = $"処理中…[{Math.Min(Settings.Default.Update_MaxCount, json.Features.Count) - i}/7]";
                        if (Updated != LastUpdated)//新規か更新
                        {
                            ExeLog($"[{i}] 更新時刻変化検知({LastUpdated}->{Updated})");
                            double? MMI = json.Features[i].Properties.Mmi;
                            string MMISt = $"({MMI})".Replace("()", "-");
                            string MaxInt = "-";
                            if (MMI < 1.5)
                                MaxInt = "I";
                            else if (MMI < 2.5)
                                MaxInt = "II";
                            else if (MMI < 3.5)
                                MaxInt = "III";
                            else if (MMI < 4.5)
                                MaxInt = "IV";
                            else if (MMI < 5.5)
                                MaxInt = "V";
                            else if (MMI < 6.5)
                                MaxInt = "VI";
                            else if (MMI < 7.5)
                                MaxInt = "VII";
                            else if (MMI < 8.5)
                                MaxInt = "VIII";
                            else if (MMI < 9.5)
                                MaxInt = "IX";
                            else if (MMI < 10.5)
                                MaxInt = "X";
                            else if (MMI < 11.5)
                                MaxInt = "XI";
                            else if (MMI >= 11.5)
                                MaxInt = "XII";
                            DateTimeOffset DataTimeOff = DateTimeOffset.FromUnixTimeMilliseconds(json.Features[i].Properties.Time).ToLocalTime();
                            string Time = Convert.ToString(DataTimeOff).Replace("+0", " UTC +0").Replace("+1", " UTC +1").Replace("-0", " UTC -0").Replace("+1", " UTC -1");
                            DateTime TimeJP_ = DataTimeOff.DateTime;
                            string TimeJP = TimeJP_.ToString("dd日HH時mm分ss秒");
                            string Mag = $"{json.Features[i].Properties.Mag}";
                            if (Mag.Length == 1)
                                Mag += ".0";
                            string MagType = json.Features[i].Properties.MagType;
                            double Lat = json.Features[i].Geometry.Coordinates[1];
                            double Lon = json.Features[i].Geometry.Coordinates[0];
                            double LatShort = Math.Round(json.Features[i].Geometry.Coordinates[1], 2, MidpointRounding.AwayFromZero);
                            double LonShort = Math.Round(json.Features[i].Geometry.Coordinates[0], 2, MidpointRounding.AwayFromZero);
                            string Alert = json.Features[i].Properties.Alert;
                            string AlertJP = "アラート:-";
                            if (Alert != null)
                                AlertJP = AlertJP.Replace("-", json.Features[i].Properties.Alert.Replace("green", "緑").Replace("yellow", "黄").Replace("orange", "オレンジ").Replace("red", "赤").Replace("pending", "保留中"));
                            string LatStDecimal = $"{Math.Round(Lat, 2, MidpointRounding.AwayFromZero)}°N";
                            if (Lat < 0)
                                LatStDecimal = $"{Math.Round(-Lat, 2, MidpointRounding.AwayFromZero)}°S";
                            string LonStDecimal = $"{Math.Round(Lon, 2, MidpointRounding.AwayFromZero)}°E";
                            if (Lon < 0)
                                LonStDecimal = $"{Math.Round(-Lon, 2, MidpointRounding.AwayFromZero)}°W";
                            TimeSpan LatTime = TimeSpan.FromHours(Lat);
                            TimeSpan LonTime = TimeSpan.FromHours(Lon);
                            string LatStShort = $"{(int)Lat}ﾟ{LatTime.Minutes}'N";
                            string LonStShort = $"{(int)Lon}ﾟ{LonTime.Minutes}'E";
                            if (Lat < 0)
                                LatStShort = $"{(int)-Lat}ﾟ{-LatTime.Minutes}'S";
                            if (Lon < 0)
                                LonStShort = $"{(int)-Lon}ﾟ{-LonTime.Minutes}'W";
                            string LatStLong = $"{(int)Lat}ﾟ{LatTime.Minutes}'{LatTime.Seconds}\"N";
                            string LonStLong = $"{(int)Lon}ﾟ{LonTime.Minutes}'{LonTime.Seconds}\"E";
                            if (Lat < 0)
                                LatStLong = $"{(int)-Lat} ﾟ {-LatTime.Minutes} '";
                            if (Lon < 0)
                                LonStLong = $"{(int)-Lon} ﾟ {-LonTime.Minutes} '";
                            string LatStLongJP = $"北緯{(int)Lat}度{LatTime.Minutes}分{LatTime.Seconds}秒";
                            string LonStLongJP = $"東経{(int)Lon}度{LonTime.Minutes}分{LonTime.Seconds}秒";
                            if (Lat < 0)
                                LatStLongJP = $"南緯{(int)-Lat}度{-LatTime.Minutes}分{-LatTime.Seconds}秒";
                            if (Lon < 0)
                                LonStLongJP = $"西経{(int)-Lon}度{-LonTime.Minutes}分{-LonTime.Seconds}秒";
                            if (Settings.Default.Text_LatLonDecimal)
                            {
                                LatStLongJP = $"北緯{Lat}度";
                                LonStLongJP = $"東経{Lon}度";
                                if (Lat < 0)
                                    LatStLongJP = $"南緯{-Lat}度";
                                if (Lon < 0)
                                    LonStLongJP = $"西経{-Lon}度";
                            }
                            string LatView = LatStShort;
                            string LongView = LonStShort;
                            if (Settings.Default.Text_LatLonDecimal)
                            {
                                LatView = LatStDecimal;
                                LongView = LonStDecimal;
                            }
                            string Depth = $"深さ:約{(int)Math.Round(json.Features[i].Geometry.Coordinates[2], MidpointRounding.AwayFromZero)}km";
                            if (json.Features[i].Geometry.Coordinates[2] == (int)json.Features[i].Geometry.Coordinates[2])
                                Depth = $"(深さ:{json.Features[i].Geometry.Coordinates[2]}km?)";//整数
                            string DepthLong = $"深さ:{json.Features[i].Geometry.Coordinates[2]}km";
                            if (json.Features[i].Geometry.Coordinates[2] == (int)json.Features[i].Geometry.Coordinates[2])
                                DepthLong = Depth;
                            string Shingen = HypoName[LL2FERCode.Code(Lat, Lon)];
                            string Shingen2 = $"({json.Features[i].Properties.Place})";
                            string LogText_ = $"USGS地震情報【{MagType}{Mag}】{Time}\n{Shingen}{Shingen2}\n{LatView},{LongView}　{Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMISt.Replace("-", "")}　{AlertJP.Replace("アラート:-", "")}\n{json.Features[i].Properties.Url}";
                            string BouyomiText = $"USGS地震情報。{TimeJP}発生、マグニチュード{Mag}、震源、{Shingen.Replace(" ", "、").Replace("/", "、")}、{LatStLongJP}、{LonStLongJP}、深さ{DepthLong.Replace("深さ:", "")}。{$"推定最大改正メルカリ震度階級{MMISt.Replace("(", "").Replace(")", "")}。".Replace("推定最大改正メルカリ震度階級-。", "")}{AlertJP.Replace("アラート:-", "")}";

                            History history = new History
                            {
                                URL = json.Features[i].Properties.Url,
                                Update = Updated,
                                TweetID = 0,//更新の場合は上書き前に変更するから0でおｋ

                                Display10 = $"USGS地震情報                                         {Time}",
                                Display11 = $"{Shingen}\n{Shingen2}\n{LatView},{LongView}\n{Depth}",
                                Display12 = $"{MagType}",
                                Display13 = $"{Mag}",//14は変わらない
                                Display15 = $"{MMISt.Replace("(", "").Replace(")", "")}",
                                Display21 = $"{Time} 発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {DepthLong}\n推定最大改正メルカリ震度階級:{MaxInt}{MMISt.Replace("-", "")}",
                                Display22 = $"{MagType}",
                                Display23 = $"{Mag}",

                                Time = json.Features[i].Properties.Time,
                                HypoJP = Shingen,
                                HypoEN = Shingen2,//()付く
                                Lat = Lat,
                                Lon = Lon,
                                Depth = json.Features[i].Geometry.Coordinates[2],
                                MagType = MagType,
                                Mag = Mag,
                                MMI = MMI,
                                Alert = Alert
                            };
                            bool NewUpdt = false;
                            if (!Histories.ContainsKey(ID))//Keyないと探したときエラーになるから別化
                                NewUpdt = true;
                            else
                            {
                                if (Settings.Default.Update_Time)
                                    if (Histories[ID].Time != history.Time)
                                    {
                                        NewUpdt = true;
                                        ExeLog($"Time:{Histories[ID].Time}->{history.Time}");
                                    }
                                if (Settings.Default.Update_HypoJP)
                                    if (Histories[ID].HypoJP != history.HypoJP)
                                    {
                                        NewUpdt = true;
                                        ExeLog($"HypoJP:{Histories[ID].HypoJP}->{history.HypoJP}");
                                    }
                                if (Settings.Default.Update_HypoEN)
                                    if (Histories[ID].HypoEN != history.HypoEN)
                                    {
                                        NewUpdt = true;
                                        ExeLog($"HypoEN:{Histories[ID].HypoEN}->{history.HypoEN}");
                                    }
                                if (Settings.Default.Update_LatLon)
                                    if (Histories[ID].Lat != history.Lat || Histories[ID].Lon != history.Lon)
                                    {
                                        NewUpdt = true;
                                        ExeLog($"Lat:{Histories[ID].Lat}->{history.Lat}, Lon:{Histories[ID].Lon}->{history.Lon}");
                                    }
                                if (Settings.Default.Update_Depth)
                                    if (Histories[ID].Depth != history.Depth)
                                    {
                                        NewUpdt = true;
                                        ExeLog($"Depth:{Histories[ID].Depth}->{history.Depth}");
                                    }
                                if (Settings.Default.Update_MagType)
                                    if (Histories[ID].MagType != history.MagType)
                                    {
                                        NewUpdt = true;
                                        ExeLog($"MagType:{Histories[ID].MagType}->{history.MagType}");
                                    }
                                if (Settings.Default.Update_Mag)
                                    if (Histories[ID].Mag != history.Mag)
                                    {
                                        NewUpdt = true;
                                        ExeLog($"Mag:{Histories[ID].Mag}->{history.Mag}");
                                    }
                                if (Settings.Default.Update_MMI)
                                    if (Histories[ID].MMI != history.MMI)
                                    {
                                        NewUpdt = true;
                                        ExeLog($"MMI:{Histories[ID].MMI}->{history.MMI}");
                                    }
                                if (Settings.Default.Update_Alert)
                                    if (Histories[ID].Alert != history.Alert)
                                    {
                                        NewUpdt = true;
                                        ExeLog($"Alert:{Histories[ID].Alert}->{history.Alert}");
                                    }
                                LogText_ = LogText_.Replace("USGS地震情報", "USGS地震情報(更新)");
                                BouyomiText = BouyomiText.Replace("USGS地震情報", "USGS地震情報、更新");
                            }
                            if (NewUpdt)//更新、初回検知
                            {
                                if (Histories.ContainsKey(ID))//更新
                                {

                                    ExeLog($"//////////{ID}更新検知//////////");
                                    history.TweetID = Histories[ID].TweetID;
                                    Histories[ID] = history;
                                }
                                else//new
                                {
                                    ExeLog($"//////////{ID}初回検知//////////");
                                    New = true;
                                    Histories.Add(ID, history);
                                }
                                LogSave("Log\\M4.5+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{Version}\n{LogText_}", ID);
                                if (Settings.Default.Socket_Enable)
                                    SendSocket(LogText_);
                                if (SoundLevel < 1 && Settings.Default.Sound_45_Enable)//SoundLevel上昇+M4.5以上有効
                                    if (New)//初報
                                        SoundLevel = 2;
                                    else if (Settings.Default.Sound_Updt_Enable)//更新+更新有効
                                        SoundLevel = 1;
                                if (json.Features[i].Properties.Mag >= 6.0)
                                {
                                    LogSave("Log\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{Version}\n{LogText_}", ID);
                                    if (SoundLevel < 3 && Settings.Default.Sound_60_Enable)
                                        if (New)
                                            SoundLevel = 4;
                                        else if (Settings.Default.Sound_Updt_Enable)
                                            SoundLevel = 3;
                                    if (json.Features[i].Properties.Mag >= 8.0)
                                    {
                                        LogSave("Log\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{Version}\n{LogText_}", ID);
                                        if (SoundLevel < 5 && Settings.Default.Sound_80_Enable)
                                            if (New)
                                                SoundLevel = 6;
                                            else if (Settings.Default.Sound_Updt_Enable)
                                                SoundLevel = 5;
                                    }
                                }
                                if (json.Features[i].Properties.Mag >= Settings.Default.Bouyomichan_LowerMagnitudeLimit || MMI >= Settings.Default.Bouyomichan_LowerMMILimit)
                                    if (Settings.Default.Bouyomichan_Enable)
                                        Bouyomichan(BouyomiText);
                                if (json.Features[i].Properties.Mag >= Settings.Default.Tweet_LowerMagnitudeLimit || MMI >= Settings.Default.Tweet_LowerMMILimit)
                                    if (Settings.Default.Tweet_Enable)
                                        await Task.Run(() => Tweet(LogText_, ID));
                            }
                            else
                                ExeLog($"[{i}] 内容更新なし");
                        }
                        else
                            ExeLog($"[{i}] 更新なし(更新:{Updated})");
                    }
                ErrorText.Text = "表示処理中…";
                for (int i = 0; i < 7; i++)
                    if (Histories.Count > i)//データ不足対処
                    {
                        string ID = json.Features[i].Id;
                        string Alert = json.Features[i].Properties.Alert;
                        if (i == 0)//最新
                        {
                            USGS0.Text = Histories[ID].Display10;
                            USGS1.Text = Histories[ID].Display11;
                            USGS2.Text = Histories[ID].Display12;
                            USGS3.Text = Histories[ID].Display13;
                            USGS4.Text = $"改正メルカリ\n　　震度階級:";
                            USGS5.Text = Histories[ID].Display15;
                            int LocX = (int)((Histories[ID].Lon + 180) * -5 - 50);//(-180,0,180) + 180 -> (0,180,360)
                            int LocY = (int)((90 - Histories[ID].Lat) * -5 + 300);//90 - (90,0,-90) -> (0,90,180)
                            int LocY_ = LocY;
                            if (LocY > 100)//はみ出しなくす
                                LocY_ = 100;
                            else if (LocY < -400)
                                LocY_ = -400;
                            MainImg.Location = new Point(LocX, LocY_);
                            Bitmap MainBitmap = new Bitmap(Resources.WorldMap);
                            Graphics graphics = Graphics.FromImage(MainBitmap);
                            graphics.DrawImage(Resources.Point, new Rectangle(-LocX + 185, -LocY + 285, 30, 30));//地図左上の画面座標の差
                            MainImg.Image = MainBitmap;
                            graphics.Dispose();
                            if (json.Features[i].Properties.Mag >= 6.0)
                            {
                                USGS0.ForeColor = Color.Yellow;
                                USGS1.ForeColor = Color.Yellow;
                                USGS2.ForeColor = Color.Yellow;
                                USGS3.ForeColor = Color.Yellow;
                                USGS4.ForeColor = Color.Yellow;
                                USGS5.ForeColor = Color.Yellow;
                                if (json.Features[i].Properties.Mag >= 8.0)
                                {
                                    USGS0.ForeColor = Color.Red;
                                    USGS1.ForeColor = Color.Red;
                                    USGS2.ForeColor = Color.Red;
                                    USGS3.ForeColor = Color.Red;
                                    USGS4.ForeColor = Color.Red;
                                    USGS5.ForeColor = Color.Red;
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
                            if (Alert == null)
                            {
                                USGS0.BackColor = Color.Black;
                                USGS0.ForeColor = Color.White;
                            }
                            else if (Alert == "green")
                            {
                                USGS0.BackColor = Color.Green;
                                USGS0.ForeColor = Color.White;
                            }
                            else if (Alert == "yellow")
                            {
                                USGS0.BackColor = Color.Yellow;
                                USGS0.ForeColor = Color.Black;
                            }
                            else if (Alert == "orange")
                            {
                                USGS0.BackColor = Color.Orange;
                                USGS0.ForeColor = Color.Black;
                            }
                            else if (Alert == "red")
                            {
                                USGS0.BackColor = Color.Red;
                                USGS0.ForeColor = Color.White;
                            }
                            else if (Alert == "pending")
                            {
                                USGS0.BackColor = Color.DimGray;
                                USGS0.ForeColor = Color.White;
                            }
                        }
                        else if (i == 1)//履歴
                        {
                            History11.Text = Histories[ID].Display21;
                            History12.Text = Histories[ID].Display22;
                            History13.Text = Histories[ID].Display23;
                            if (json.Features[i].Properties.Mag >= 6.0)
                            {
                                History11.ForeColor = Color.Yellow;
                                History12.ForeColor = Color.Yellow;
                                History13.ForeColor = Color.Yellow;
                                if (json.Features[i].Properties.Mag >= 8.0)
                                {
                                    History11.ForeColor = Color.Red;
                                    History12.ForeColor = Color.Red;
                                    History13.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                History11.ForeColor = Color.White;
                                History12.ForeColor = Color.White;
                                History13.ForeColor = Color.White;
                            }
                            if (Alert == null)
                                History10.BackColor = Color.FromArgb(45, 45, 90);
                            else if (Alert == "green")
                                History10.BackColor = Color.Green;
                            else if (Alert == "yellow")
                                History10.BackColor = Color.Yellow;
                            else if (Alert == "orange")
                                History10.BackColor = Color.Orange;
                            else if (Alert == "red")
                                History10.BackColor = Color.Red;
                            else if (Alert == "pending")
                                History10.BackColor = Color.DimGray;
                        }
                        else if (i == 2)
                        {
                            History21.Text = Histories[ID].Display21;
                            History22.Text = Histories[ID].Display22;
                            History23.Text = Histories[ID].Display23;
                            if (json.Features[i].Properties.Mag >= 6.0)
                            {
                                History21.ForeColor = Color.Yellow;
                                History22.ForeColor = Color.Yellow;
                                History23.ForeColor = Color.Yellow;
                                if (json.Features[i].Properties.Mag >= 8.0)
                                {
                                    History21.ForeColor = Color.Red;
                                    History22.ForeColor = Color.Red;
                                    History23.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                History21.ForeColor = Color.White;
                                History22.ForeColor = Color.White;
                                History23.ForeColor = Color.White;
                            }
                            if (Alert == null)
                                History20.BackColor = Color.FromArgb(45, 45, 90);
                            else if (Alert == "green")
                                History20.BackColor = Color.Green;
                            else if (Alert == "yellow")
                                History20.BackColor = Color.Yellow;
                            else if (Alert == "orange")
                                History20.BackColor = Color.Orange;
                            else if (Alert == "red")
                                History20.BackColor = Color.Red;
                            else if (Alert == "pending")
                                History20.BackColor = Color.DimGray;
                        }
                        else if (i == 3)
                        {
                            History31.Text = Histories[ID].Display21;
                            History32.Text = Histories[ID].Display22;
                            History33.Text = Histories[ID].Display23;
                            if (json.Features[i].Properties.Mag >= 6.0)
                            {
                                History31.ForeColor = Color.Yellow;
                                History32.ForeColor = Color.Yellow;
                                History33.ForeColor = Color.Yellow;
                                if (json.Features[i].Properties.Mag >= 8.0)
                                {
                                    History31.ForeColor = Color.Red;
                                    History32.ForeColor = Color.Red;
                                    History33.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                History31.ForeColor = Color.White;
                                History32.ForeColor = Color.White;
                                History33.ForeColor = Color.White;
                            }
                            if (Alert == null)
                                History30.BackColor = Color.FromArgb(45, 45, 90);
                            else if (Alert == "green")
                                History30.BackColor = Color.Green;
                            else if (Alert == "yellow")
                                History30.BackColor = Color.Yellow;
                            else if (Alert == "orange")
                                History30.BackColor = Color.Orange;
                            else if (Alert == "red")
                                History30.BackColor = Color.Red;
                            else if (Alert == "pending")
                                History30.BackColor = Color.DimGray;
                        }
                        else if (i == 4)
                        {
                            History41.Text = Histories[ID].Display21;
                            History42.Text = Histories[ID].Display22;
                            History43.Text = Histories[ID].Display23;
                            if (json.Features[i].Properties.Mag >= 6.0)
                            {
                                History41.ForeColor = Color.Yellow;
                                History42.ForeColor = Color.Yellow;
                                History43.ForeColor = Color.Yellow;
                                if (json.Features[i].Properties.Mag >= 8.0)
                                {
                                    History41.ForeColor = Color.Red;
                                    History42.ForeColor = Color.Red;
                                    History43.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                History41.ForeColor = Color.White;
                                History42.ForeColor = Color.White;
                                History43.ForeColor = Color.White;
                            }
                            if (Alert == null)
                                History40.BackColor = Color.FromArgb(45, 45, 90);
                            else if (Alert == "green")
                                History40.BackColor = Color.Green;
                            else if (Alert == "yellow")
                                History40.BackColor = Color.Yellow;
                            else if (Alert == "orange")
                                History40.BackColor = Color.Orange;
                            else if (Alert == "red")
                                History40.BackColor = Color.Red;
                            else if (Alert == "pending")
                                History40.BackColor = Color.DimGray;
                        }
                        else if (i == 5)
                        {
                            History51.Text = Histories[ID].Display21;
                            History52.Text = Histories[ID].Display22;
                            History53.Text = Histories[ID].Display23;
                            if (json.Features[i].Properties.Mag >= 6.0)
                            {
                                History51.ForeColor = Color.Yellow;
                                History52.ForeColor = Color.Yellow;
                                History53.ForeColor = Color.Yellow;
                                if (json.Features[i].Properties.Mag >= 8.0)
                                {
                                    History51.ForeColor = Color.Red;
                                    History52.ForeColor = Color.Red;
                                    History53.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                History51.ForeColor = Color.White;
                                History52.ForeColor = Color.White;
                                History53.ForeColor = Color.White;
                            }
                            if (Alert == null)
                                History50.BackColor = Color.FromArgb(45, 45, 90);
                            else if (Alert == "green")
                                History50.BackColor = Color.Green;
                            else if (Alert == "yellow")
                                History50.BackColor = Color.Yellow;
                            else if (Alert == "orange")
                                History50.BackColor = Color.Orange;
                            else if (Alert == "red")
                                History50.BackColor = Color.Red;
                            else if (Alert == "pending")
                                History50.BackColor = Color.DimGray;
                        }
                        else if (i == 6)
                        {
                            History61.Text = Histories[ID].Display21;
                            History62.Text = Histories[ID].Display22;
                            History63.Text = Histories[ID].Display23;
                            if (json.Features[i].Properties.Mag >= 6.0)
                            {
                                History61.ForeColor = Color.Yellow;
                                History62.ForeColor = Color.Yellow;
                                History63.ForeColor = Color.Yellow;
                                if (json.Features[i].Properties.Mag >= 8.0)
                                {
                                    History61.ForeColor = Color.Red;
                                    History62.ForeColor = Color.Red;
                                    History63.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                History61.ForeColor = Color.White;
                                History62.ForeColor = Color.White;
                                History63.ForeColor = Color.White;
                            }
                            if (Alert == null)
                                History60.BackColor = Color.FromArgb(45, 45, 90);
                            else if (Alert == "green")
                                History60.BackColor = Color.Green;
                            else if (Alert == "yellow")
                                History60.BackColor = Color.Yellow;
                            else if (Alert == "orange")
                                History60.BackColor = Color.Orange;
                            else if (Alert == "red")
                                History60.BackColor = Color.Red;
                            else if (Alert == "pending")
                                History60.BackColor = Color.DimGray;
                        }
                    }
                    else if (i == 0)//最新
                    {
                        USGS0.Text = "USGS地震情報";
                        USGS1.Text = "";
                        USGS2.Text = "";
                        USGS3.Text = "";
                        USGS4.Text = "";
                        USGS5.Text = "";
                        MainImg.Image = null;
                        USGS0.BackColor = Color.Black;
                    }
                    else if (i == 1)//履歴
                    {
                        History11.Text = "";
                        History12.Text = "";
                        History13.Text = "";
                        History10.BackColor = Color.FromArgb(45, 45, 90);
                    }
                    else if (i == 2)
                    {
                        History21.Text = "";
                        History22.Text = "";
                        History23.Text = "";
                        History20.BackColor = Color.FromArgb(45, 45, 90);
                    }
                    else if (i == 3)
                    {
                        History31.Text = "";
                        History32.Text = "";
                        History33.Text = "";
                        History30.BackColor = Color.FromArgb(45, 45, 90);
                    }
                    else if (i == 4)
                    {
                        History41.Text = "";
                        History42.Text = "";
                        History43.Text = "";
                        History40.BackColor = Color.FromArgb(45, 45, 90);
                    }
                    else if (i == 5)
                    {
                        History51.Text = "";
                        History52.Text = "";
                        History53.Text = "";
                        History50.BackColor = Color.FromArgb(45, 45, 90);
                    }
                    else if (i == 6)
                    {
                        History61.Text = "";
                        History62.Text = "";
                        History63.Text = "";
                        History60.BackColor = Color.FromArgb(45, 45, 90);
                    }
                USGS6.Text = $"{UpdateTime_}更新\n{LastCheckTime}取得\n地図データ:NationalEarth";
                USGS6.Location = new Point(400 - USGS6.Width, 500 - USGS6.Height);
                ExeLog($"ログ保持数:{Histories.Count}");
                if (SoundLevel == 1)
                    Sound("M45u.wav");
                else if (SoundLevel == 2)
                    Sound("M45.wav");
                else if (SoundLevel == 3)
                    Sound("M60u.wav");
                else if (SoundLevel == 4)
                    Sound("M60.wav");
                else if (SoundLevel == 5)
                    Sound("M80u.wav");
                else if (SoundLevel == 6)
                    Sound("M80.wav");
            }
            catch (WebException ex)
            {
                ErrorText.Text = $"ネットワークエラーが発生しました。内容:" + ex.Message;
            }
            catch (Exception ex)
            {
                ErrorText.Text = $"エラーが発生しました。エラーログの内容を報告してください。内容:" + ex.Message;
                LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main Version:{Version}\n{ex}");
            }
            if (!ErrorText.Text.Contains("エラー"))
                ErrorText.Text = "";
            NoFirst = true;
            ExeLog("処理終了");
            /*//フォント変更がうまくいかない
            if (ErrorText.Font != F12)
            {
                if (F12 == null)
                    try
                    {
                        Console.WriteLine("Font=null");
                        PrivateFontCollection pfc = new PrivateFontCollection();
                        pfc.AddFontFile("Font\\Koruri-Regular.ttf");
                        F9 = new Font(pfc.Families[0], 9F);
                        F9_5 = new Font(pfc.Families[0], 9.5F);
                        F10 = new Font(pfc.Families[0], 10F);
                        F11 = new Font(pfc.Families[0], 11F);
                        F12 = new Font(pfc.Families[0], 12F);
                        F20 = new Font(pfc.Families[0], 20F);
                        F22 = new Font(pfc.Families[0], 22F);
                        pfc.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                Console.WriteLine(ErrorText.Font);
                Console.WriteLine(F12);
                Console.WriteLine(F9);
                Font = F10;
                USGS0.Font = F9;
                USGS1.Font = F11;
                USGS2.Font = F11;
                USGS3.Font = F20;
                USGS4.Font = F11;
                USGS5.Font = F20;
                USGS6.Font = F9;
                ErrorText.Font = F12;
                HistoryBack.Font = F10;
                History11.Font = F9_5;
                History12.Font = F10;
                History13.Font = F22;
                History21.Font = F9_5;
                History22.Font = F10;
                History23.Font = F22;
                History31.Font = F9_5;
                History32.Font = F10;
                History33.Font = F22;
                History41.Font = F9_5;
                History42.Font = F10;
                History43.Font = F22;
                History51.Font = F9_5;
                History52.Font = F10;
                History53.Font = F22;
                History61.Font = F9_5;
                History62.Font = F10;
                History63.Font = F22;
                Console.WriteLine(ErrorText.Font);
            }*/
        }

        /// <summary>
        /// ログを保存します。
        /// </summary>
        /// <param name="SaveDirectory">保存するディレクトリ。</param>
        /// <param name="SaveText">保存するテキスト。</param>
        /// <param name="ID">地震ログ保存時用地震ID。</param>
        public static void LogSave(string SaveDirectory, string SaveText, string ID = "unknown")
        {
            DateTime NowTime = DateTime.Now;
            if (Directory.Exists("Log") == false)
                Directory.CreateDirectory("Log");
            if (!Directory.Exists(SaveDirectory))
                Directory.CreateDirectory(SaveDirectory);
            if (SaveDirectory == "Log")
                File.WriteAllText($"Log\\log.txt", SaveText);
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
                        throw new Exception("Tokenが正しくありません。");
                    }
                    Status status = new Status();
                    if (Histories[ID].TweetID != 0)
                        try
                        {
                            ExeLog($"ツイート(リプライ)中…(ID:{Histories[ID].TweetID})");
                            status = tokens.Statuses.UpdateAsync(new { status = Text, in_reply_to_status_id = Histories[ID].TweetID }).Result;
                        }
                        catch
                        {
                            ExeLog($"ツイート(リプライ)失敗、リトライ中…");
                            status = tokens.Statuses.UpdateAsync(new { status = Text }).Result;
                        }
                    else
                    {
                        ExeLog($"ツイート中…");
                        status = tokens.Statuses.UpdateAsync(new { status = Text }).Result;
                    }
                    Histories[ID].TweetID = status.Id;
                    ExeLog($"ツイート成功(ID:{status.Id})");
                }
                catch (Exception ex)
                {
                    ErrorText.Text = $"ツイートに失敗しました。わからない場合エラーログの内容を報告してください。内容:" + ex.Message;
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Tweet Version:{Version}\n{ex}");
                }
        }
        /// <summary>
        /// Socket通信で送信します。
        /// </summary>
        /// <param name="Text">送信する文。</param>
        public void SendSocket(string Text)
        {
            if (NoFirst)
                try
                {
                    ExeLog($"Socket送信中…({Settings.Default.Socket_Host}:{Settings.Default.Socket_Port})");
                    IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(Settings.Default.Socket_Host), Settings.Default.Socket_Port);
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        tcpClient.Connect(iPEndPoint);
                        using (NetworkStream networkStream = tcpClient.GetStream())
                        {
                            byte[] Bytes = new byte[4096];
                            Bytes = Encoding.UTF8.GetBytes(Text);
                            networkStream.Write(Bytes, 0, Bytes.Length);
                        }
                    }
                    ExeLog($"Socket送信成功");
                }
                catch (Exception ex)
                {
                    ErrorText.Text = $"Socket送信に失敗しました。わからない場合エラーログの内容を報告してください。内容:" + ex.Message;
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Socket Version:{Version}\n{ex}");
                }
        }
        /// <summary>
        /// 棒読みちゃんに読み上げ指令を送ります。
        /// </summary>
        /// <param name="Text">読み上げさせる文。</param>
        public void Bouyomichan(string Text)
        {
            if (NoFirst)
                try
                {
                    ExeLog($"棒読みちゃん送信中…");
                    byte[] Message = Encoding.UTF8.GetBytes(Text);
                    int Length = Message.Length;
                    byte Code = 0;
                    short Command = 0x0001;
                    short Speed = Settings.Default.Bouyomichan_Speed;
                    short Tone = Settings.Default.Bouyomichan_Tone;
                    short Volume = Settings.Default.Bouyomichan_Volume;
                    short Voice = Settings.Default.Bouyomichan_Voice;
                    using (TcpClient TcpClient = new TcpClient(Settings.Default.Bouyomichan_Host, Settings.Default.Bouyomichan_Port))
                    using (NetworkStream NetworkStream = TcpClient.GetStream())
                    using (BinaryWriter BinaryWriter = new BinaryWriter(NetworkStream))
                    {
                        BinaryWriter.Write(Command);
                        BinaryWriter.Write(Speed);
                        BinaryWriter.Write(Tone);
                        BinaryWriter.Write(Volume);
                        BinaryWriter.Write(Voice);
                        BinaryWriter.Write(Code);
                        BinaryWriter.Write(Length);
                        BinaryWriter.Write(Message);
                    }
                    ExeLog($"棒読みちゃん送信成功");
                }
                catch (Exception ex)
                {
                    ErrorText.Text = $"棒読みちゃんへの送信に失敗しました。わからない場合エラーログの内容を報告してください。内容:" + ex.Message;
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Bouyomichan Version:{Version}\n{ex}");
                }
        }
        /// <summary>
        /// 実行ログを保存・表示します。
        /// </summary>
        /// <param name="Text">保存するテキスト。</param>
        /// <remarks>タイムスタンプは自動で追加されます。</remarks>
        public static void ExeLog(string Text)
        {
            if (Settings.Default.Log_Enable)
                ExeLogs += $"{DateTime.Now:HH:mm:ss.ffff} {Text}\n";
            Console.WriteLine(Text);
        }
        /// <summary>
        /// 設定を読み込みます。
        /// </summary>
        /// <remarks>即時サイズ変更を行います。</remarks>
        public void SettingReload()
        {
            ExeLog($"設定読み込み開始");
            Settings.Default.Reload();
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            if (File.Exists(Config.FilePath))
                File.Copy(Config.FilePath, "UserSetting.xml", true);
            if (Settings.Default.Display_HideHistory)
                if (Settings.Default.Display_HideHistoryMap)
                    ClientSize = new Size(400, 100);
                else
                    ClientSize = new Size(400, 500);
            else
                ClientSize = new Size(800, 500);
            ExeLogAutoDelete.Interval = Settings.Default.Log_DeleteTime * 1000;
            ExeLog($"設定読み込み終了");
        }
        public static SoundPlayer Player = null;
        /// <summary>
        /// 音声を再生します。
        /// </summary>
        /// <param name="SoundFile">再生するSoundフォルダの中の音声ファイル。</param>
        public static void Sound(string SoundFile)
        {
            if (NoFirst)
                try
                {
                    ExeLog($"音声再生開始(Sound\\{SoundFile})");
                    if (Player != null)
                    {
                        Player.Stop();
                        Player.Dispose();
                        Player = null;
                    }
                    Player = new SoundPlayer($"Sound\\{SoundFile}");
                    Player.Play();
                    ExeLog($"音声再生成功");
                }
                catch (Exception ex)
                {
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Sound Version:{Version}\n{ex}");
                }
        }
        private void RCsetting_Click(object sender, EventArgs e)
        {
            ExeLog($"設定form表示");
            SettingsForm Settings = new SettingsForm();
            Settings.FormClosed += SettingForm_FormClosed;//閉じたとき呼び出し
            Settings.Show();
        }
        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExeLog($"設定form終了");
            SettingReload();
            ErrorText.Text = "設定を再読み込みしました。一部の設定は情報受信または再起動が必要です。";
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
        private void RCtsunami_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.tsunami.gov/");
        }
        private void RCinfopage_Click(object sender, EventArgs e)
        {
            Process.Start("https://Ichihai1415.github.io/programs/released/WQV");
        }
        private void RCMapEWSC_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.emsc-csem.org/#2w");
        }
        private void RCEarlyEst_Click(object sender, EventArgs e)
        {
            Process.Start("http://early-est.rm.ingv.it/warning.html");
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExeLog($"実行終了");
            LogSave("Log", ExeLogs);
        }
        private void RC1CacheClear_Click(object sender, EventArgs e)
        {
            DialogResult allow = MessageBox.Show("動作ログ、地震ログを消去してよろしいですか？消去した場合処理は起動時と同じようになります。(震源キャッシュは消去されません)", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (allow == DialogResult.Cancel)
                return;
            ExeLogs = "";
            Histories = new Dictionary<string, History>();
            NoFirst = false;
        }

        private void RC1ExeLogOpen_Click(object sender, EventArgs e)
        {
            LogSave("Log", ExeLogs);
            Process.Start("notepad.exe", "Log\\log.txt");
        }

        private void ExeLogAutoDelete_Tick(object sender, EventArgs e)//規定は3600000ms(1h)
        {
            ExeLogs = "";
        }

        private void RC1IntConvert_Click(object sender, EventArgs e)
        {
            IntConvert intConverter = new IntConvert();
            intConverter.Show();
        }
    }
}
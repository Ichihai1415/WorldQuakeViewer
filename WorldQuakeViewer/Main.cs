using LL2FERC;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldQuakeViewer.Properties;

namespace WorldQuakeViewer//TODO:設定Formの作り直し
{
    public partial class MainForm : Form//TODO:設定の分割(USGSとEMSC)
    {
        public static readonly string version = "1.1.0α7";//こことアセンブリを変える
        public static DateTime startTime = new DateTime();
        public static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
        public static int accesseCountEMSC = 0;
        public static int accesseCountUSGS = 0;
        public static string latestURLUSGS = "";
        public static string latestURLEMSC = "";
        public static bool noFirst = false;//最初はツイートとかしない
        public static bool waitEMSCDraw = true;//最初の描画を待機(USGS用)
        public static string exeLogs = "";
        public static History EMSCHist = new History();
        public static Dictionary<string, History> USGSHist = new Dictionary<string, History>();//EQID,Data
        public static string latestTextUSGS = "";
        public static string latestTextEMSC = "";
        public static Bitmap bitmap = new Bitmap(1600, 1000);
        public static Bitmap bitmap_USGS = new Bitmap(800, 1000);
        public static FontFamily font;
        public static SoundPlayer player = null;

        public MainForm()//TODO:settingにバージョン保存していろいろやりたい
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)//ExeLog($"");
        {
            ExeLog($"[Main]起動処理開始");
            startTime = DateTime.Now;
            ErrorText.Text = "リソース確認中…";
            await Task.Delay(1);//これがあると文字がちゃんと変わる
            if (!Directory.Exists("Font"))
            {
                Directory.CreateDirectory("Font");
                ExeLog($"[Main]Fontフォルダを作成しました");
            }
            if (!File.Exists("Font\\Koruri-Regular.ttf"))
            {
                File.WriteAllBytes("Font\\Koruri-Regular.ttf", Resources.Koruri_Regular);
                ExeLog($"[Main]フォントファイル(\"Font\\Koruri-Regular.ttf\")をコピーしました");
            }
            if (!File.Exists("Font\\LICENSE"))
            {
                File.WriteAllText("Font\\LICENSE", Resources.Koruri_LICENSE);
                ExeLog($"[Main]ライセンスファイル(\"Font\\LICENSE\")をコピーしました");
            }
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("Font\\Koruri-Regular.ttf");
            font = pfc.Families[0];
            ExeLog($"[Main]フォントOK");
            if (!Directory.Exists("Sound"))
            {
                File.WriteAllBytes("Sound.zip", Resources.Sound);
                ExeLog($"[Main]音声ファイル(\"Sound.zip\")をコピーしました");
                ZipFile.ExtractToDirectory("Sound.zip", ".");
                ExeLog($"[Main]音声ファイル(\"Sound.zip\")を解凍しました(\"Sound\\*\")");
                File.Delete("Sound.zip");
            }
            ErrorText.Text = "設定読み込み中…";
            await Task.Delay(1);
            if (File.Exists("UserSetting.xml"))//AppDataに保存
            {
                if (!Directory.Exists(config.FilePath.Replace("\\user.config", "")))//実質更新時
                    Directory.CreateDirectory(config.FilePath.Replace("\\user.config", ""));
                File.Copy("UserSetting.xml", config.FilePath, true);
                ExeLog($"[Main]設定ファイルをAppDataにコピー");
            }
            ExeLog($"[Main]音声OK");
            ImageCheck("map.png");
            ImageCheck("hypo.png");
            ExeLog($"[Main]画像OK");
            if (!File.Exists("AppDataPath.txt"))
                File.WriteAllText("AppDataPath.txt", config.FilePath);
            SettingReload();
            ErrorText.Text = "設定の読み込みが完了しました。";
            await Task.Delay(1);
            ExeLog($"[Main]設定読み込み完了");
            EMSCget.Enabled = true;
            USGSget.Enabled = true;
        }

        private async void EMSCget_Tick(object sender, EventArgs e)//TODO:取得頻度を2/1mだけでなく1/1mでもにする？
        {
            ExeLog($"[EMSC]取得開始");
            //次の0/30秒までの時間を計算
            DateTime now = DateTime.Now;
            DateTime next0Second = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0).AddMinutes(1);
            DateTime next30Second = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 30);
            if (now.Second >= 59)//早いと59秒になるため
                next0Second = next0Second.AddMinutes(1);
            if (now.Second >= 29)//早いと29秒になるため
                next30Second = next30Second.AddMinutes(1);
            EMSCget.Interval = (int)Math.Max(-1, Math.Min((next0Second - now).TotalMilliseconds, (next30Second - now).TotalMilliseconds));
            ExeLog($"[EMSC]次回実行まであと{EMSCget.Interval}ms");
            try
            {
                //https://www.emsc-csem.org/Earthquake/earthquake.php?id=
                //https://www.seismicportal.eu/fdsnws/event/1/query?limit=1&format=text&minmag=5.0
                //#EventID        |Time                    |Latitude|Longitude|Depth/km|Author|Catalog |Contributor|ContributorID|MagType|Magnitude|MagAuthor|EventLocationName
                //20230701_0000038|2023-07-01T03:29:25.534Z|-31.7703|-68.7812 |30.3    |NEIC  |EMSC-RTS|NEIC       |1522821      |mb     |5.3      |NEIC     |SAN JUAN, ARGENTINA
                // 0              | 1                      | 2      | 3       | 4      | 5    | 6      | 7         | 8           | 9     | 10      | 11      | 12
                //?               |                        |        |         |        |ソース|全部同? |ソース     |ID           |       |         |ソース   |
                WebClient wc = new WebClient();
                ErrorText.Text = "[EMSC]取得中…";
                await Task.Delay(1);
                string text = await wc.DownloadStringTaskAsync(new Uri("https://www.seismicportal.eu/fdsnws/event/1/query?limit=1&format=text&minmag=5.0"));
                wc.Dispose();
                ExeLog($"[EMSC]処理開始");
                accesseCountEMSC++;
                string[] texts = text.Split('\n')[1].Split('|');//TODO:処理を複数にするか？(処理自体は最新のだけでいい)
                string time_ = texts[1];
                DateTime time = DateTime.Parse(time_);
                long timeLong = time.Ticks;
                DateTimeOffset timeOff = time.ToLocalTime();
                string timeSt = timeOff.ToString("yyyy/MM/dd HH:mm:ss  UTCzzz");
                string timeJP = timeOff.DateTime.ToString("d日H時m分s秒");
                string lat_ = texts[2];
                double lat = double.Parse(lat_);
                string lon_ = texts[3];
                double lon = double.Parse(lon_);
                Lat2String(lat, out string latStLong, out string latStLongJP, out string latDisplay);
                Lon2String(lon, out string lonStLong, out string lonStLongJP, out string lonDisplay);
                string depth_ = texts[4];
                double depth = double.Parse(depth_);
                string depthSt = depth_ + "km";
                string source = texts[5];
                string id = texts[8];
                string url = "https://www.emsc-csem.org/Earthquake_information/earthquake.php?id=" + id;
                latestURLEMSC = url;
                string magType = texts[9];
                string mag_ = texts[10];
                double mag = double.Parse(mag_);
                string magSt = mag.ToString("0.0");
                int hypoCode = LL2FERCode.Code(lat, lon);
                string hypoJP = LL2FERCode.NameJP(hypoCode);
                string hypoEN = texts[12];
                string magTypeWithSpace = magType.Length == 3 ? magType : magType.Length == 2 ? "   " + magType : "      " + magType;

                string logText = $"EMSC地震情報【{magType}{magSt}】{timeSt}\n{hypoJP}({hypoEN})\n{latStLong},{lonStLong}　深さ:{depthSt}\n{url}";
                string bouyomiText = $"EMSC地震情報。{timeJP}発生、マグニチュード{magSt}、震源、{hypoJP.Replace(" ", "、").Replace("/", "、")}、{latStLongJP}、{lonStLongJP}、深さ{depthSt.Replace("km", "キロメートル")}。";

                History history = new History
                {
                    URL = url,
                    TweetID = 0,//更新の場合は上書き前に変更するから0でおｋ
                    ID = id,

                    Time = timeLong,
                    HypoJP = hypoJP,
                    HypoEN = hypoEN,//()つかない
                    Lat = lat,
                    Lon = lon,
                    Depth = depth,
                    MagType = magType,
                    Mag = mag
                };
                int soundLevel = 0;//音声判別用 初報ほど,M大きいほど高い
                bool isNew = false;
                bool isNewUpdt = false;
                int i = 0;
                if (EMSCHist.ID == id)//同じか更新
                {
                    if (Settings.Default.EMSC_Update_Time)
                        if (EMSCHist.Time != history.Time)
                        {
                            isNewUpdt = true;
                            ExeLog($"[EMSC]Time:{EMSCHist.Time}->{history.Time}");
                        }
                    if (Settings.Default.EMSC_Update_HypoJP)
                        if (EMSCHist.HypoJP != history.HypoJP)
                        {
                            isNewUpdt = true;
                            ExeLog($"[EMSC]HypoJP:{EMSCHist.HypoJP}->{history.HypoJP}");
                        }
                    if (Settings.Default.EMSC_Update_HypoEN)
                        if (EMSCHist.HypoEN != history.HypoEN)
                        {
                            isNewUpdt = true;
                            ExeLog($"[EMSC]HypoEN:{EMSCHist.HypoEN}->{history.HypoEN}");
                        }
                    if (Settings.Default.EMSC_Update_LatLon)
                        if (EMSCHist.Lat != history.Lat || EMSCHist.Lon != history.Lon)
                        {
                            isNewUpdt = true;
                            ExeLog($"[EMSC]Lat:{EMSCHist.Lat}->{history.Lat}, Lon:{EMSCHist.Lon}->{history.Lon}");
                        }
                    if (Settings.Default.EMSC_Update_Depth)
                        if (EMSCHist.Depth != history.Depth)
                        {
                            isNewUpdt = true;
                            ExeLog($"[EMSC]Depth:{EMSCHist.Depth}->{history.Depth}");
                        }
                    if (Settings.Default.EMSC_Update_MagType)
                        if (EMSCHist.MagType != history.MagType)
                        {
                            isNewUpdt = true;
                            ExeLog($"[EMSC]MagType:{EMSCHist.MagType}->{history.MagType}");
                        }
                    if (Settings.Default.EMSC_Update_Mag)
                        if (EMSCHist.Mag != history.Mag)
                        {
                            isNewUpdt = true;
                            ExeLog($"[EMSC]Mag:{EMSCHist.Mag}->{history.Mag}");
                        }
                    if (isNewUpdt)
                    {
                        logText = logText.Replace("EMSC地震情報", "EMSC地震情報(更新)");
                        bouyomiText = bouyomiText.Replace("EMSC地震情報", "EMSC地震情報、更新");
                        ExeLog($"[EMSC]{id}更新検知");
                    }
                }
                else
                {
                    isNew = true;
                    isNewUpdt = true;
                    ExeLog($"[EMSC]{id}初回");
                }

                if (isNewUpdt)
                {
                    EMSCHist = history;
                    LogSave("Log\\EMSC\\M4.5+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{version}\n{logText}", id);
                    SendSocket(logText);

                    WebHook(logText);

                    if (soundLevel < 1 && Settings.Default.Sound_45_Enable)//SoundLevel上昇+M4.5以上有効
                        soundLevel = isNew ? 2 : 1;
                    if (mag >= 6)
                    {
                        LogSave("Log\\EMSC\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{version}\n{logText}", id);

                        if (soundLevel < 3 && Settings.Default.Sound_60_Enable)
                            soundLevel = isNew ? 4 : 3;
                        if (mag >= 8)
                        {
                            LogSave("Log\\EMSC\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{version}\n{logText}", id);
                            if (soundLevel < 5 && Settings.Default.Sound_80_Enable)
                                soundLevel = isNew ? 6 : 5;
                        }
                    }
                    if (i == 0)
                        latestTextEMSC = logText;
                    if (mag >= Settings.Default.Bouyomichan_LowerMagnitudeLimit)
                        Bouyomichan(bouyomiText);
                    if (mag >= Settings.Default.Tweet_LowerMagnitudeLimit)
                        Tweet(logText, "EMSC", id);
                }
                else
                    ExeLog($"[EMSC][{i}] 内容更新なし");
                switch (soundLevel)
                {
                    case 1:
                        Sound("M45u.wav");
                        break;
                    case 2:
                        Sound("M45.wav");
                        break;
                    case 3:
                        Sound("M60u.wav");
                        break;
                    case 4:
                        Sound("M60.wav");
                        break;
                    case 5:
                        Sound("M80u.wav");
                        break;
                    case 6:
                        Sound("M80.wav");
                        break;
                }
                ErrorText.Text = "[EMSC]描画中…";
                await Task.Delay(1);
                ExeLog($"[EMSC]描画開始");
                bitmap = new Bitmap(1600, 1000);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(Resources.Back, 0, 0);

                int locX = lon > 0 ? (int)Math.Round((lon + 90d) * 10d, MidpointRounding.AwayFromZero) : (int)Math.Round((lon + 450d) * 10d, MidpointRounding.AwayFromZero);
                int locY = (int)Math.Round((90d - lat) * 10d, MidpointRounding.AwayFromZero);
                int locX_image = 400 - locX;
                int locY_image = Math.Min(200, Math.Max(-800, 600 - locY));
                g.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 90)), 0, 200, 800, 800);
                ImageCheck("map.png");
                g.DrawImage(Image.FromFile("Image\\map.png"), locX_image, locY_image, 5400, 1800);
                ColorMap[] colorChange = new ColorMap[]
                {
                    new ColorMap()
                };
                colorChange[0].OldColor = Color.Black;
                colorChange[0].NewColor = Color.Transparent;
                ImageAttributes ia = new ImageAttributes();
                ia.SetRemapTable(colorChange);
                ImageCheck("hypo.png");
                g.DrawImage(Image.FromFile("Image\\hypo.png"), new Rectangle(360, locY + locY_image - 40, 80, 80), 0, 0, 80, 80, GraphicsUnit.Pixel, ia);

                g.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 0, 30)), 480, 950, 320, 50);
                g.DrawString("地図データ:Natural Earth", new Font(font, 19), Brushes.White, 490, 956);

                Brush color = Mag2Brush(mag);
                g.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 30)), 0, 0, 800, 200);
                g.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 60)), 4, 40, 792, 156);
                g.DrawString($"EMSC地震情報(M5.0+)                 {timeSt}", new Font(font, 20), Brushes.White, 0, 0);
                g.DrawString($"{hypoJP}\n({hypoEN})\n{latDisplay}, {lonDisplay}   深さ:{depthSt}\nID:{id}  ソース:{source}", new Font(font, 20), color, 4, 42);
                g.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 30)), 796, 0, 4, 200);
                g.DrawString(magTypeWithSpace, new Font(font, 20), color, 590, 154);
                g.DrawString(magSt, new Font(font, 50), color, 670, 110);
                g.DrawRectangle(new Pen(Color.FromArgb(200, 200, 200)), 0, 0, 799, 199);
                g.DrawRectangle(new Pen(Color.FromArgb(200, 200, 200)), 0, 200, 799, 799);
                g.DrawImage(bitmap_USGS, 800, 0, 800, 1000);
                if (!noFirst && waitEMSCDraw)//初回
                    g.DrawImage(Resources.Back_USGS, 800, 0);
                ExeLog($"[EMSC]描画完了");

                g.Dispose();
                MainImage.Image = bitmap;
                wc.Dispose();
            }
            catch (WebException ex)
            {
                ErrorText.Text = $"[EMSC]ネットワークエラーが発生しました。内容:{ex.Message}";
            }
            catch (Exception ex)
            {
                LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main Version:{version}\n{ex}");
                ErrorText.Text = $"[EMSC]エラーが発生しました。エラーログの内容を報告してください。内容:{ex.Message}";
            }
            waitEMSCDraw = false;//初回時の例外時にこれができないとUSGSも動かないからここ
            if (!ErrorText.Text.Contains("エラー"))
                ErrorText.Text = "";
            ExeLog("[EMSC]処理終了");
            await Task.Delay(1);
        }

        private async void USGSget_Tick(object sender, EventArgs e)
        {
            ExeLog($"[USGS]取得開始");
            //次の15/45秒までの時間を計算
            DateTime now = DateTime.Now;
            DateTime next15Second = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 15);
            DateTime next45Second = next15Second.AddSeconds(30);
            if (now.Second >= 14)//早いと14秒になるため
                next15Second = next15Second.AddMinutes(1);
            if (now.Second >= 44)//早いと44秒になるため
                next45Second = next45Second.AddMinutes(1);
            USGSget.Interval = (int)Math.Max(10000, Math.Min((next15Second - now).TotalMilliseconds, (next45Second - now).TotalMilliseconds));
            ExeLog($"[USGS]次回実行まであと{USGSget.Interval}ms");
            try
            {
                ErrorText.Text = "[USGS]取得中…";
                await Task.Delay(1);
                WebClient wc = new WebClient();
                string json_ = await wc.DownloadStringTaskAsync(new Uri("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/4.5_week.geojson"));
                wc.Dispose();
                ExeLog($"[USGS]処理開始");
                accesseCountUSGS++;
                JObject json = JObject.Parse(json_);
                json_ = "";//早く処分(多分効果ほぼない) 
                int soundLevel = 0;//音声判別用 初報ほど,M大きいほど高い
                int datasCount = Math.Min(Settings.Default.USGS_Update_MaxCount, (int)json.SelectToken("metadata.count"));
                string[] ids = new string[6];
                for (int i = datasCount - 1; i >= 0; i--)//送信の都合上古い順に
                {
                    JToken features = json.SelectToken($"features[{i}]");
                    bool isNew = false;//音声判別用
                    string id = (string)features.SelectToken("id");
                    ExeLog($"[USGS]処理[{i}]:{id}");
                    if (i < 6)
                        ids[i] = id;
                    JToken properties = features.SelectToken("properties");
                    long update_ = (long)properties.SelectToken("updated");
                    DateTimeOffset update = DateTimeOffset.FromUnixTimeMilliseconds(update_).ToLocalTime();

                    string UpdateTime = $"{update:yyyy/MM/dd HH:mm:ss}";
                    long lastUpdated = USGSHist.ContainsKey(id) ? USGSHist[id].Update : 0;
                    ErrorText.Text = $"処理中…[{datasCount - i}/{datasCount}]";
                    await Task.Delay(1);//todo:たまに待つようにする
                    if (update_ != lastUpdated)//新規か更新
                    {
                        ExeLog($"[USGS][{i}] 更新時刻変化検知({lastUpdated}->{update_})");
                        double? mmi = (double?)properties.SelectToken("mmi");
                        string mmiSt = $"({mmi})".Replace("()", "-");//(1.2)/-
                        string maxInt = mmi < 1.5 ? "I" : mmi < 2.5 ? "II" : mmi < 3.5 ? "III" : mmi < 4.5 ? "IV" : mmi < 5.5 ? "V" : mmi < 6.5 ? "VI" : mmi < 7.5 ? "VII" : mmi < 8.5 ? "VIII" : mmi < 9.5 ? "IX" : mmi < 10.5 ? "X" : mmi < 11.5 ? "XI" : mmi >= 11.5 ? "XII" : "-";
                        long time_ = (long)properties.SelectToken("time");
                        DateTimeOffset timeOff = DateTimeOffset.FromUnixTimeMilliseconds(time_).ToLocalTime();
                        string timeSt = timeOff.ToString("yyyy/MM/dd HH:mm:ss  UTCzzz");
                        string timeJP = timeOff.DateTime.ToString("d日H時m分s秒");
                        double mag = (double)properties.SelectToken("mag");
                        string magSt = mag.ToString("0.0#");
                        string magType = (string)properties.SelectToken("magType");
                        double lat = (double)features.SelectToken("geometry.coordinates[1]");
                        double lon = (double)features.SelectToken("geometry.coordinates[0]");
                        Lat2String(lat, out string latStLong, out string latStLongJP, out string latDisplay);
                        Lon2String(lon, out string lonStLong, out string lonStLongJP, out string lonDisplay);
                        string alert = (string)properties.SelectToken("alert");
                        string alertJP = alert == null ? "アラート:-" : $"アラート:{alert.Replace("green", "緑").Replace("yellow", "黄").Replace("orange", "オレンジ").Replace("red", "赤").Replace("pending", "保留中")}";
                        double depth = (double)features.SelectToken("geometry.coordinates[2]");
                        //使うかも
                        //string depthSt = depth == (int)depth ? $"(深さ:{depth}km?)" : $"深さ:約{(int)Math.Round(depth, MidpointRounding.AwayFromZero)}km";
                        //string depthLong = depth == (int)depth ? depthSt : $"深さ:{depth}km";
                        string depthLong = depth == (int)depth ? $"(深さ:{depth}km?)" : $"深さ:{depth}km";
                        string hypoJP = LL2FERCode.NameJP(LL2FERCode.Code(lat, lon));
                        string hypoEN = $"({(string)properties.SelectToken("place")})";
                        string url = (string)properties.SelectToken("url");
                        latestURLUSGS = url;
                        string logText = $"USGS地震情報【{magType}{magSt}】{timeSt}\n{hypoJP}{hypoEN}\n{latStLong},{lonStLong}　{depthLong}\n推定最大改正メルカリ震度階級:{maxInt}{mmiSt.Replace("-", "")}　{alertJP.Replace("アラート:-", "")}\n{url}";
                        string bouyomiText = $"USGS地震情報。{timeJP}発生、マグニチュード{magSt}、震源、{hypoJP.Replace(" ", "、").Replace("/", "、")}、{latStLongJP}、{lonStLongJP}、深さ{depthLong.Replace("深さ:", "")}。{$"推定最大改正メルカリ震度階級{mmiSt.Replace("(", "").Replace(")", "")}。".Replace("推定最大改正メルカリ震度階級-。", "")}{alertJP.Replace("アラート:-", "")}";
                        string magTypeWithSpace = magType.Length == 3 ? magType : magType.Length == 2 ? "   " + magType : "      " + magType;
                        History history = new History
                        {
                            URL = url,
                            Update = update_,
                            TweetID = 0,//更新の場合は上書き前に変更するから0でおｋ

                            Display1 = $"{timeSt} 発生  ID:{id}\n{hypoJP}\n{latDisplay}, {lonDisplay}   {depthLong}\n推定最大改正メルカリ震度階級:{maxInt}{mmiSt.Replace("-", "")}",
                            Display2 = $"{magTypeWithSpace}",
                            Display3 = $"{magSt}",

                            Time = time_,
                            HypoJP = hypoJP,
                            HypoEN = hypoEN,//()付く
                            Lat = lat,
                            Lon = lon,
                            Depth = depth,
                            MagType = magType,
                            Mag = mag,
                            MMI = mmi,
                            Alert = alert
                        };
                        bool isNewUpdt = false;
                        if (!USGSHist.ContainsKey(id))//Keyないと探したときエラーになるから別化
                            isNewUpdt = true;
                        else
                        {
                            if (Settings.Default.USGS_Update_Time)
                                if (USGSHist[id].Time != history.Time)
                                {
                                    isNewUpdt = true;
                                    ExeLog($"[USGS]Time:{USGSHist[id].Time}->{history.Time}");
                                }
                            if (Settings.Default.USGS_Update_HypoJP)
                                if (USGSHist[id].HypoJP != history.HypoJP)
                                {
                                    isNewUpdt = true;
                                    ExeLog($"[USGS]HypoJP:{USGSHist[id].HypoJP}->{history.HypoJP}");
                                }
                            if (Settings.Default.USGS_Update_HypoEN)
                                if (USGSHist[id].HypoEN != history.HypoEN)
                                {
                                    isNewUpdt = true;
                                    ExeLog($"[USGS]HypoEN:{USGSHist[id].HypoEN}->{history.HypoEN}");
                                }
                            if (Settings.Default.USGS_Update_LatLon)
                                if (USGSHist[id].Lat != history.Lat || USGSHist[id].Lon != history.Lon)
                                {
                                    isNewUpdt = true;
                                    ExeLog($"[USGS]Lat:{USGSHist[id].Lat}->{history.Lat}, Lon:{USGSHist[id].Lon}->{history.Lon}");
                                }
                            if (Settings.Default.USGS_Update_Depth)
                                if (USGSHist[id].Depth != history.Depth)
                                {
                                    isNewUpdt = true;
                                    ExeLog($"[USGS]Depth:{USGSHist[id].Depth}->{history.Depth}");
                                }
                            if (Settings.Default.USGS_Update_MagType)
                                if (USGSHist[id].MagType != history.MagType)
                                {
                                    isNewUpdt = true;
                                    ExeLog($"[USGS]MagType:{USGSHist[id].MagType}->{history.MagType}");
                                }
                            if (Settings.Default.USGS_Update_Mag)
                                if (USGSHist[id].Mag != history.Mag)
                                {
                                    isNewUpdt = true;
                                    ExeLog($"[USGS]Mag:{USGSHist[id].Mag}->{history.Mag}");
                                }
                            if (Settings.Default.USGS_Update_MMI)
                                if (USGSHist[id].MMI != history.MMI)
                                {
                                    isNewUpdt = true;
                                    ExeLog($"[USGS]MMI:{USGSHist[id].MMI}->{history.MMI}");
                                }
                            if (Settings.Default.USGS_Update_Alert)
                                if (USGSHist[id].Alert != history.Alert)
                                {
                                    isNewUpdt = true;
                                    ExeLog($"[USGS]Alert:{USGSHist[id].Alert}->{history.Alert}");
                                }
                            logText = logText.Replace("USGS地震情報", "USGS地震情報(更新)");
                            bouyomiText = bouyomiText.Replace("USGS地震情報", "USGS地震情報、更新");
                        }
                        if (isNewUpdt)
                        {
                            if (USGSHist.ContainsKey(id))//更新
                            {

                                ExeLog($"[USGS]{id}更新検知");
                                history.TweetID = USGSHist[id].TweetID;
                                USGSHist[id] = history;
                            }
                            else//new
                            {
                                ExeLog($"[USGS]{id}初回");
                                isNew = true;
                                USGSHist.Add(id, history);
                            }
                            LogSave("Log\\USGS\\M4.5+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{version}\n{logText}", id);
                            SendSocket(logText);
                            if (soundLevel < 1 && Settings.Default.Sound_45_Enable)//SoundLevel上昇+M4.5以上有効
                                soundLevel = isNew ? 2 : 1;
                            if (mag >= 6)
                            {
                                LogSave("Log\\USGS\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{version}\n{logText}", id);

                                if (soundLevel < 3 && Settings.Default.Sound_60_Enable)
                                    soundLevel = isNew ? 4 : 3;
                                if (mag >= 8)
                                {
                                    LogSave("Log\\USGS\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{version}\n{logText}", id);
                                    if (soundLevel < 5 && Settings.Default.Sound_80_Enable)
                                        soundLevel = isNew ? 6 : 5;
                                }
                            }
                            if (i == 0)
                                latestTextUSGS = logText;
                            if (mag >= Settings.Default.Bouyomichan_LowerMagnitudeLimit || mmi >= Settings.Default.Bouyomichan_LowerMMILimit)
                                Bouyomichan(bouyomiText);
                            if (mag >= Settings.Default.Tweet_LowerMagnitudeLimit || mmi >= Settings.Default.Tweet_LowerMMILimit)
                                Tweet(logText, "USGS", id);
                            WebHook(logText);
                        }
                    }
                }
                switch (soundLevel)//ifより行増えたけどこっちのほうが速い(かも)
                {
                    case 1:
                        Sound("M45u.wav");
                        break;
                    case 2:
                        Sound("M45.wav");
                        break;
                    case 3:
                        Sound("M60u.wav");
                        break;
                    case 4:
                        Sound("M60.wav");
                        break;
                    case 5:
                        Sound("M80u.wav");
                        break;
                    case 6:
                        Sound("M80.wav");
                        break;
                }
                while (waitEMSCDraw)//初回のEMSCの描画を待機
                    await Task.Delay(50);//小さすぎるとデッドロックみたいに動かなくなる
                ErrorText.Text = "[USGS]描画中…";
                await Task.Delay(1);
                bitmap_USGS = new Bitmap(800, 1000);
                Graphics g = Graphics.FromImage(bitmap_USGS);
                g.DrawImage(Resources.Back_USGS, 0, 0);
                g.DrawString($"USGS地震情報(M4.5+)                                              Version:{version}", new Font(font, 20), Brushes.White, 2, 2);
                for (int i = 0; i < 6; i++)
                {
                    if (USGSHist.Count > i)//データ不足対処
                    {
                        History hist = USGSHist[ids[i]];
                        Brush color = Mag2Brush(hist.Mag);
                        g.FillRectangle(new SolidBrush(Alert2Color(hist.Alert)), 4, 40 + 160 * i, 792, 156);
                        g.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 90)), 8, 44 + 160 * i, 784, 148);
                        g.DrawString(hist.Display1, new Font(font, 19), color, 8, 44 + 160 * i);
                        g.DrawString(hist.Display2, new Font(font, 19), color, 570, 154 + 160 * i);
                        g.DrawString(hist.Display3, new Font(font, 50), color, 640, 110 + 160 * i);
                    }
                    else
                        g.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 90)), 4, 40 + 160 * i, 792, 156);
                }
                g = null;
                g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap_USGS, 800, 0, 800, 1000);
                MainImage.Image = bitmap;
                g.Dispose();
                ExeLog($"[USGS]ログ保持数:{USGSHist.Count}");
                wc.Dispose();
            }
            catch (WebException ex)
            {
                ErrorText.Text = $"[USGS]ネットワークエラーが発生しました。内容:{ex.Message}";
            }
            catch (Exception ex)
            {
                LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main Version:{version}\n{ex}");
                ErrorText.Text = $"[USGS]エラーが発生しました。エラーログの内容を報告してください。内容:{ex.Message}";
            }
            if (!ErrorText.Text.Contains("エラー"))
                ErrorText.Text = "";
            noFirst = true;
            ExeLog("[USGS]処理終了");
            await Task.Delay(1);
        }

        /// <summary>
        /// ログを保存します。
        /// </summary>
        /// <param name="directory">保存するディレクトリ。</param>
        /// <param name="text">保存するテキスト。</param>
        /// <param name="id">地震ログ保存時用地震ID。</param>
        public static void LogSave(string directory, string text, string id = "unknown")//同じ参照({xxx}\\{yyy}\\{zzz})が多いのでstringにそれぞれまとめる?
        {
            if (Settings.Default.Log_Enable)
            {
                try
                {
                    ExeLog($"[LogSave]ログ保存中…");
                    DateTime nowTime = DateTime.Now;
                    if (!Directory.Exists("Log"))
                        Directory.CreateDirectory("Log");
                    if (directory.StartsWith("Log\\EMSC"))
                        if (!Directory.Exists("Log\\EMSC"))
                            Directory.CreateDirectory("Log\\EMSC");
                    if (directory.StartsWith("Log\\USGS"))
                        if (!Directory.Exists("Log\\USGS"))
                            Directory.CreateDirectory("Log\\USGS");
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);
                    if (directory == "Log")
                        File.WriteAllText($"Log\\log.txt", text);
                    else if (directory == "Log\\ErrorLog")
                    {
                        if (File.Exists($"Log\\ErrorLog\\{nowTime:yyyyMM}.txt"))
                            text += "\n--------------------------------------------------\n" + File.ReadAllText($"Log\\ErrorLog\\{nowTime:yyyyMM}.txt");
                        File.WriteAllText($"Log\\ErrorLog\\{nowTime:yyyyMM}.txt", text);
                    }
                    else if (directory.StartsWith("Log\\USGS") || directory.StartsWith("Log\\EMSC"))
                    {
                        if (!Directory.Exists($"{directory}\\{nowTime:yyyyMM}"))
                            Directory.CreateDirectory($"{directory}\\{nowTime:yyyyMM}");
                        if (!Directory.Exists($"{directory}\\{nowTime:yyyyMM}\\{nowTime:dd}"))
                            Directory.CreateDirectory($"{directory}\\{nowTime:yyyyMM}\\{nowTime:dd}");
                        if (noFirst && File.Exists($"{directory}\\{nowTime:yyyyMM}\\{nowTime:dd}\\{nowTime:yyyyMMdd}_{id}.txt"))
                            text = File.ReadAllText($"{directory}\\{nowTime:yyyyMM}\\{nowTime:dd}\\{nowTime:yyyyMMdd}_{id}.txt") + "\n--------------------------------------------------\n" + text;
                        File.WriteAllText($"{directory}\\{nowTime:yyyyMM}\\{nowTime:dd}\\{nowTime:yyyyMMdd}_{id}.txt", text);
                    }
                    else
                    {
                        if (!Directory.Exists($"{directory}\\{nowTime:yyyyMM}"))
                            Directory.CreateDirectory($"{directory}\\{nowTime:yyyyMM}");
                        if (File.Exists($"{directory}\\{nowTime:yyyyMM}\\{nowTime:yyyyMMdd}.txt"))
                            text = File.ReadAllText($"{directory}\\{nowTime:yyyyMM}\\{nowTime:yyyyMMdd}.txt") + "\n--------------------------------------------------\n" + text;
                        File.WriteAllText($"{directory}\\{nowTime:yyyyMM}\\{nowTime:yyyyMMdd}.txt", text);
                    }
                    ExeLog($"[LogSave]ログ保存成功");
                }
                catch (Exception ex)
                {
                    ExeLog($"[LogSave]ログ保存でエラーが発生:{ex.Message}");
                }
            }
        }

        /// <summary>
        /// ツイートします。
        /// </summary>
        /// <remarks>ツイートできる遮断ができるまで廃止</remarks>
        /// <param name="text">ツイートするテキスト。</param>
        /// <param name="source">データ元</param>
        /// <param name="id">リプライ判別用地震ID。</param>
        public async void Tweet(string text, string source, string id)
        {

        }

        /// <summary>
        /// Socket通信で送信します。
        /// </summary>
        /// <param name="Text">送信する文。</param>
        public void SendSocket(string text)
        {
            if (noFirst && Settings.Default.Socket_Enable)
                try
                {
                    ExeLog($"[SendSocket]Socket送信中…({Settings.Default.Socket_Host}:{Settings.Default.Socket_Port})");
                    IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(Settings.Default.Socket_Host), Settings.Default.Socket_Port);
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        tcpClient.Connect(iPEndPoint);
                        using (NetworkStream networkStream = tcpClient.GetStream())
                        {
                            byte[] bytes = new byte[4096];
                            bytes = Encoding.UTF8.GetBytes(text);
                            networkStream.Write(bytes, 0, bytes.Length);
                        }
                    }
                    ExeLog($"[SendSocket]Socket送信成功");
                }
                catch (Exception ex)
                {
                    ErrorText.Text = $"Socket送信に失敗しました。わからない場合エラーログの内容を報告してください。内容:{ex.Message}";
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Socket Version:{version}\n{ex}");
                }
        }

        /// <summary>
        /// 棒読みちゃんに読み上げ指令を送ります。
        /// </summary>
        /// <param name="text">読み上げさせる文。</param>
        public void Bouyomichan(string text)
        {
            if (noFirst && Settings.Default.Bouyomichan_Enable)
                try
                {
                    ExeLog($"[Bouyomichan]棒読みちゃん送信中…");
                    byte[] message = Encoding.UTF8.GetBytes(text);
                    int length = message.Length;
                    byte code = 0;
                    short command = 0x0001;
                    short speed = Settings.Default.Bouyomichan_Speed;
                    short tone = Settings.Default.Bouyomichan_Tone;
                    short volume = Settings.Default.Bouyomichan_Volume;
                    short voice = Settings.Default.Bouyomichan_Voice;
                    using (TcpClient tcpClient = new TcpClient(Settings.Default.Bouyomichan_Host, Settings.Default.Bouyomichan_Port))
                    using (NetworkStream networkStream = tcpClient.GetStream())
                    using (BinaryWriter binaryWriter = new BinaryWriter(networkStream))
                    {
                        binaryWriter.Write(command);
                        binaryWriter.Write(speed);
                        binaryWriter.Write(tone);
                        binaryWriter.Write(volume);
                        binaryWriter.Write(voice);
                        binaryWriter.Write(code);
                        binaryWriter.Write(length);
                        binaryWriter.Write(message);
                    }
                    ExeLog($"[Bouyomichan]棒読みちゃん送信成功");
                }
                catch (Exception ex)
                {
                    ErrorText.Text = $"棒読みちゃんへの送信に失敗しました。わからない場合エラーログの内容を報告してください。内容:{ex.Message}";
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Bouyomichan Version:{version}\n{ex}");
                }
        }

        /// <summary>
        /// WebHookを送信します。
        /// </summary>
        /// <param name="text">送信するテキスト。</param>
        public async void WebHook(string text)
        {
            if (noFirst/* && Settings.Default.WebHook_Enable*/)
                try
                {
                    ExeLog($"[WebHook]WebHook送信中…");
                    HttpClient hc = new HttpClient();
                    Dictionary<string, string> strs = new Dictionary<string, string>()
                    {
                        { "content", text }
                    };
                    if (File.Exists("WebHookURL.txt"))//仮
                        Settings.Default.WebHook_URL = File.ReadAllText("WebHookURL.txt");
                    else
                        return;//ここまで仮
                    await hc.PostAsync(Settings.Default.WebHook_URL, new FormUrlEncodedContent(strs));
                    hc.Dispose();
                    ExeLog($"[WebHook]WebHook送信成功");
                }
                catch (Exception ex)
                {
                    ErrorText.Text = $"WebHookの送信に失敗しました。わからない場合エラーログの内容を報告してください。内容:{ex.Message}";
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,WebHook Version:{version}\n{ex}");
                }
        }

        /// <summary>
        /// 実行ログを保存・表示します。
        /// </summary>
        /// <param name="text">保存するテキスト。</param>
        /// <remarks>タイムスタンプは自動で追加されます。</remarks>
        public static void ExeLog(string text)
        {
            if (Settings.Default.Log_Enable)
                exeLogs += $"{DateTime.Now:HH:mm:ss.ffff} {text}\n";
            Console.WriteLine(text);
        }

        /// <summary>
        /// 設定を読み込みます。
        /// </summary>
        /// <remarks>即時サイズ変更を行います。</remarks>
        public void SettingReload()
        {
            ExeLog($"[SettingReload]設定読み込み開始");
            Settings.Default.Reload();
            if (File.Exists(config.FilePath))
                File.Copy(config.FilePath, "UserSetting.xml", true);
            if (Settings.Default.Display_HideHistory)
                if (Settings.Default.Display_HideHistoryMap)
                    ClientSize = new Size(400, 100);
                else
                    ClientSize = new Size(400, 500);
            else
                ClientSize = new Size(800, 500);
            ExeLogAutoDelete.Interval = Settings.Default.Log_DeleteTime * 1000;
            ExeLog($"[SettingReload]設定読み込み終了");
        }

        /// <summary>
        /// 音声を再生します。
        /// </summary>
        /// <param name="soundFile">再生するSoundフォルダの中の音声ファイル。</param>
        public static void Sound(string soundFile)
        {
            if (noFirst)
                try
                {
                    ExeLog($"[Sound]音声再生開始(Sound\\{soundFile})");
                    if (player != null)
                    {
                        player.Stop();
                        player.Dispose();
                        player = null;
                    }
                    if (!File.Exists($"Sound\\{soundFile}"))
                    {
                        ExeLog($"[Sound]音声ファイル(Sound\\{soundFile})が見つかりませんでした。");
                        return;
                    }
                    player = new SoundPlayer($"Sound\\{soundFile}");
                    player.Play();
                    ExeLog($"[Sound]音声再生成功");
                }
                catch (Exception ex)
                {
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Sound Version:{version}\n{ex}");
                }
        }

        private void RCsetting_Click(object sender, EventArgs e)
        {
            ExeLog($"[RC]設定表示");
            SettingsForm Settings = new SettingsForm();
            Settings.FormClosed += SettingForm_FormClosed;//閉じたとき呼び出し
            Settings.Show();
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExeLog($"[RC]設定終了");
            SettingReload();
            noFirst = false;//処理量増加時用
            ErrorText.Text = "設定を再読み込みしました。一部の設定は情報受信または再起動が必要です。";
        }

        private void RCusgsmap_Click(object sender, EventArgs e)
        {
            Process.Start("https://earthquake.usgs.gov/earthquakes/map/");
        }

        private void RCusgsthis_Click(object sender, EventArgs e)
        {
            Process.Start(latestURLUSGS);
        }

        private void RCgithub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Ichihai1415/WorldQuakeViewer");
        }

        private void RCXtwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/ProjectS31415_1");
        }

        private void RCNOAA_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.tsunami.gov/");
        }

        private void RCinfopage_Click(object sender, EventArgs e)
        {
            Process.Start("https://Ichihai1415.github.io/programs/released/WQV");
        }

        private void RCMapEWSC_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.emsc-csem.org");
        }

        private void RCEarlyEst_Click(object sender, EventArgs e)
        {
            Process.Start("http://early-est.rm.ingv.it/warning.html");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExeLog($"[Main]実行終了");
            LogSave("Log", exeLogs);
        }

        private void RC1CacheClear_Click(object sender, EventArgs e)
        {
            DialogResult allow = MessageBox.Show("動作ログ、地震ログを消去してよろしいですか？消去した場合処理は起動時と同じようになります。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (allow == DialogResult.Cancel)
                return;
            exeLogs = "";
            USGSHist = new Dictionary<string, History>();
            noFirst = false;
        }

        private void RC1ExeLogOpen_Click(object sender, EventArgs e)
        {
            if (Settings.Default.Log_Enable)
            {
                LogSave("Log", exeLogs);
                Process.Start("notepad.exe", "Log\\log.txt");
            }
            else
            {
                DialogResult dr = MessageBox.Show("動作ログの保存がオフになっています。有効にしますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    Settings.Default.Log_Enable = true;
                    Settings.Default.Save();
                    Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                    File.Copy(Config.FilePath, "UserSetting.xml", true);
                    ExeLog($"[RC]動作ログの保存をオンにしました");
                }
            }
        }

        private void ExeLogAutoDelete_Tick(object sender, EventArgs e)//規定は3600000ms(1h)
        {
            exeLogs = "";
        }

        private void RC1IntConvert_Click(object sender, EventArgs e)
        {
            IntConvert intConverter = new IntConvert();
            intConverter.Show();
        }

        public static Brush Mag2Brush(double mag)
        {
            if (mag < 6)
                return Brushes.White;
            else if (mag < 8)
                return Brushes.Yellow;
            else
                return Brushes.Red;
        }

        public static Color Alert2Color(string alert)
        {
            switch (alert)
            {
                case "green":
                    return Color.Green;
                case "yellow":
                    return Color.Yellow;
                case "orange":
                    return Color.Orange;
                case "red":
                    return Color.Red;
                case "pending":
                    return Color.DimGray;
                default:
                    return Color.FromArgb(45, 45, 90);
            }
        }

        //##とか00はフォーマットのやつ
        /// <summary>
        /// 緯度を様々なフォーマットに変換します。
        /// </summary>
        /// <remarks>指定ミスに注意してください。</remarks>
        /// <param name="lat">緯度</param>
        /// <param name="latStLong">(string) 設定により {###.##…}ﾟN または {###}ﾟ{##}'{##}\"N</param>
        /// <param name="latStLongJP">(string) 設定により 北緯{###.##…}度 または 北緯{##}度{##}分{##}秒 </param>
        /// <param name="latDisplay">(string) 設定により {###.00}ﾟN または {###}ﾟ{##}'{##}\"N </param>
        public static void Lat2String(double lat, out string latStLong, out string latStLongJP, out string latDisplay)//ここら辺は雑なので気が向いたら調整
        {
            double latShort = Math.Round(lat, 2, MidpointRounding.AwayFromZero);
            string latStDecimal = lat > 0 ? $"{latShort}ﾟN" : $"{-latShort}ﾟS";
            TimeSpan latTime = TimeSpan.FromHours(lat);
            string latStShort = lat > 0 ? $"{(int)lat}ﾟ{latTime.Minutes}'N" : $"{(int)-lat}ﾟ{-latTime.Minutes}'S";
            latStLong = Settings.Default.Text_LatLonDecimal ? lat > 0 ? $"{lat}ﾟN" : $"{-lat}ﾟS" : lat > 0 ? $"{(int)lat}ﾟ{latTime.Minutes}'{latTime.Seconds}\"N" : $"{(int)-lat}ﾟ{-latTime.Minutes}'{-latTime.Seconds}\"S";
            latStLongJP = Settings.Default.Text_LatLonDecimal ? lat > 0 ? $"北緯{lat}度" : $"南緯{-lat}度" : lat > 0 ? $"北緯{(int)lat}度{latTime.Minutes}分{latTime.Seconds}秒" : $"南緯{(int)-lat}度{-latTime.Minutes}分{-latTime.Seconds}秒";
            latDisplay = Settings.Default.Text_LatLonDecimal ? latStDecimal : latStShort;
        }

        /// <summary>
        /// 緯度を様々なフォーマットに変換します。
        /// </summary>
        /// <remarks>指定ミスに注意してください。</remarks>
        /// <param name="lat">緯度</param>
        /// <param name="latShort">(double) ###.00</param>
        /// <param name="latStDecimal">(string) {###.00}°N</param>
        /// <param name="latStShort">(string) {###}ﾟ{##}'N</param>
        /// <param name="latStLong">(string) 設定により {###.##…}ﾟN または {###}ﾟ{##}'{##}\"N</param>
        /// <param name="latStLongJP">(string) 設定により 北緯{###.##…}度 または 北緯{##}度{##}分{##}秒 </param>
        /// <param name="latDisplay">(string) 設定により<paramref name="latStDecimal"/>または<paramref name="latStShort"/></param>
        public static void Lat2String(double lat, out double latShort, out string latStDecimal, out string latStShort, out string latStLong, out string latStLongJP, out string latDisplay)
        {
            latShort = Math.Round(lat, 2, MidpointRounding.AwayFromZero);
            latStDecimal = lat > 0 ? $"{latShort}ﾟN" : $"{-latShort}ﾟS";
            TimeSpan latTime = TimeSpan.FromHours(lat);
            latStShort = lat > 0 ? $"{(int)lat}ﾟ{latTime.Minutes}'N" : $"{(int)-lat}ﾟ{-latTime.Minutes}'S";
            latStLong = Settings.Default.Text_LatLonDecimal ? lat > 0 ? $"{lat}ﾟN" : $"{-lat}ﾟS" : lat > 0 ? $"{(int)lat}ﾟ{latTime.Minutes}'{latTime.Seconds}\"N" : $"{(int)-lat}ﾟ{-latTime.Minutes}'{-latTime.Seconds}\"S";
            latStLongJP = Settings.Default.Text_LatLonDecimal ? lat > 0 ? $"北緯{lat}度" : $"南緯{-lat}度" : lat > 0 ? $"北緯{(int)lat}度{latTime.Minutes}分{latTime.Seconds}秒" : $"南緯{(int)-lat}度{-latTime.Minutes}分{-latTime.Seconds}秒";
            latDisplay = Settings.Default.Text_LatLonDecimal ? latStDecimal : latStShort;
        }

        /// <summary>
        /// 経度を様々なフォーマットに変換します。
        /// </summary>
        /// <remarks>指定ミスに注意してください。</remarks>
        /// <param name="lon">経度</param>
        /// <param name="lonStLong">(string) 設定により {###.##…}ﾟE または {###}ﾟ{##}'{##}\"E</param>
        /// <param name="lonStLongJP">(string) 設定により 東経{###.##…}度 または 東経{##}度{##}分{##}秒 </param>
        /// <param name="lonDisplay">(string) 設定により {###.00}ﾟE または {###}ﾟ{##}'{##}\"E</param>
        public static void Lon2String(double lon, out string lonStLong, out string lonStLongJP, out string lonDisplay)
        {
            double lonShort = Math.Round(lon, 2, MidpointRounding.AwayFromZero);
            string lonStDecimal = lon > 0 ? $"{lonShort}ﾟE" : $"{-lonShort}ﾟW";
            TimeSpan lonTime = TimeSpan.FromHours(lon);
            string lonStShort = lon > 0 ? $"{(int)lon}ﾟ{lonTime.Minutes}'E" : $"{(int)-lon}ﾟ{-lonTime.Minutes}'W";
            lonStLong = Settings.Default.Text_LatLonDecimal ? lon > 0 ? $"{lon}ﾟE" : $"{-lon}ﾟW" : lon > 0 ? $"{(int)lon}ﾟ{lonTime.Minutes}'{lonTime.Seconds}\"E" : $"{(int)-lon}ﾟ{-lonTime.Minutes}'{-lonTime.Seconds}\"W";
            lonStLongJP = Settings.Default.Text_LatLonDecimal ? lon > 0 ? $"東経{lon}度" : $"西経{-lon}度" : lon > 0 ? $"東経{(int)lon}度{lonTime.Minutes}分{lonTime.Seconds}秒" : $"西経{(int)-lon}度{-lonTime.Minutes}分{-lonTime.Seconds}秒";
            lonDisplay = Settings.Default.Text_LatLonDecimal ? lonStDecimal : lonStShort;
        }

        /// <summary>
        /// 経度を様々なフォーマットに変換します。
        /// </summary>
        /// <remarks>指定ミスに注意してください。</remarks>
        /// <param name="lon">経度</param>
        /// <param name="lonShort">(double) ###.00</param>
        /// <param name="lonStDecimal">(string) {###.00}ﾟE</param>
        /// <param name="lonStShort">(string) {###}ﾟ{##}'E</param>
        /// <param name="lonStLong">(string) 設定により {###.##…}ﾟE または {###}ﾟ{##}'{##}\"E</param>
        /// <param name="lonStLongJP">(string) 設定により 東経{###.##…}度 または 東経{##}度{##}分{##}秒 </param>
        /// <param name="lonDisplay">(string) 設定により<paramref name="lonStDecimal"/>または<paramref name="lonStShort"/></param>
        public static void Lon2String(double lon, out double lonShort, out string lonStDecimal, out string lonStShort, out string lonStLong, out string lonStLongJP, out string lonDisplay)
        {
            lonShort = Math.Round(lon, 2, MidpointRounding.AwayFromZero);
            lonStDecimal = lon > 0 ? $"{lonShort}ﾟE" : $"{-lonShort}ﾟW";
            TimeSpan lonTime = TimeSpan.FromHours(lon);
            lonStShort = lon > 0 ? $"{(int)lon}ﾟ{lonTime.Minutes}'E" : $"{(int)-lon}ﾟ{-lonTime.Minutes}'W";
            lonStLong = Settings.Default.Text_LatLonDecimal ? lon > 0 ? $"{lon}ﾟE" : $"{-lon}ﾟW" : lon > 0 ? $"{(int)lon}ﾟ{lonTime.Minutes}'{lonTime.Seconds}\"E" : $"{(int)-lon}ﾟ{-lonTime.Minutes}'{-lonTime.Seconds}\"W";
            lonStLongJP = Settings.Default.Text_LatLonDecimal ? lon > 0 ? $"東経{lon}度" : $"西経{-lon}度" : lon > 0 ? $"東経{(int)lon}度{lonTime.Minutes}分{lonTime.Seconds}秒" : $"西経{(int)-lon}度{-lonTime.Minutes}分{-lonTime.Seconds}秒";
            lonDisplay = Settings.Default.Text_LatLonDecimal ? lonStDecimal : lonStShort;
        }

        /// <summary>
        /// 画像ファイルがない場合リソースからコピーします。
        /// </summary>
        /// <param name="fileName">ファイル名。</param>
        /// <exception cref="Exception">画像指定が間違っている場合。</exception>
        public static void ImageCheck(string fileName)
        {
            if (!Directory.Exists("Image"))
            {
                Directory.CreateDirectory("Image");
                ExeLog($"[ImageCheck]Imageフォルダを作成しました");
            }
            if (!File.Exists($"Image\\{fileName}"))
            {
                Bitmap image;
                switch (fileName)
                {
                    case "map.png":
                        image = Resources.map;
                        break;
                    case "hypo.png":
                        image = Resources.hypo;
                        break;
                    default:
                        throw new Exception("画像のコピーに失敗しました。", new ArgumentException($"指定された画像({fileName})はResourcesにありません。"));
                }
                image.Save($"Image\\{fileName}", ImageFormat.Png);
                ExeLog($"[ImageCheck]画像(\"Image\\{fileName}\")をコピーしました");
            }
        }

        private void RC1MapGenerator_Click(object sender, EventArgs e)
        {
            //別ソフトに移行
        }

        private void RCTextCopyEMSC_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(latestTextEMSC);
        }

        private void RCTextCopyUSGS_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(latestTextUSGS);
        }

        private void RC1Reboot_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void RCSoftDiscord_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/7dBFWKjgGa");
        }

        private void RCThisEMSC_Click(object sender, EventArgs e)
        {
            Process.Start(latestURLEMSC);
        }
    }

    public class History
    {
        public string URL { get; set; }
        public long Update { get; set; }
        public string ID { get; set; }
        public long TweetID { get; set; }

        //表示用
        public string Display1 { get; set; }
        public string Display2 { get; set; }
        public string Display3 { get; set; }

        //更新検知用
        public long Time { get; set; }
        public string HypoJP { get; set; }
        public string HypoEN { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Depth { get; set; }
        public string MagType { get; set; }
        public double Mag { get; set; }
        public double? MMI { get; set; }
        public string Alert { get; set; }
    }
}

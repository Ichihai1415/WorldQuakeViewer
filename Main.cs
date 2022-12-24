using CoreTweet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public static readonly string Version = "1.0.2";//こことアセンブリを変える
        public static DateTime StartTime = new DateTime();
        public static int AccessedUSGS = 0;
        public static int AccessedFE = 0;
        public string LatestURL = "";
        public static bool NoFirst = false;//最初はツイートとかしない
        public Dictionary<string, History> Histories = new Dictionary<string, History>();//EQID,Data
        public Dictionary<Point, int> HypoIDs = new Dictionary<Point, int>();//Location,HypoID
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            StartTime = DateTime.Now;
            HistoryBack.Text = $"履歴                                                                    Version:{Version}";
            ErrorText.Text = "フォント読み込み中…";
            try
            {
                while (!File.Exists("Font\\Koruri-Regular.ttf"))
                {
                    if (!Directory.Exists("Font"))
                        Directory.CreateDirectory("Font");
                    Process.Start("https://koruri.github.io/");
                    Process.Start("explorer.exe", "Font");
                    DialogResult Result = MessageBox.Show($"フォントが見つかりません。ダウンロードサイトとFontフォルダを開きます。\"Koruri-Regular.ttf\"をFontフォルダにコピーしてください。", "WQV_FontCheck", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    if (Result != DialogResult.Retry)
                    {
                        Application.Exit();
                        break;//これないとプロセス無限起動される
                    }
                    Thread.Sleep(1000);//念のため
                }
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
                Console.WriteLine("F9  :" + F9);
                Console.WriteLine("F9_5:" + F9_5);
                Console.WriteLine("F10 :" + F10);
                Console.WriteLine("F11 :" + F11);
                Console.WriteLine("F12 :" + F12);
                Console.WriteLine("F20 :" + F20);
                Console.WriteLine("F22 :" + F22);
                if (F9 !=  F22)//おかしいときname="使用されたパラメーターが有効ではありません。"になるため　なぜかおかしくなくてもエラー出る
                {
                    Console.WriteLine("フォントの読み込みに成功");
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
                    bool FontOK = false;
                    while (FontOK == false)
                    {
                        InstalledFontCollection ifc = new InstalledFontCollection();
                        foreach (FontFamily f in ifc.Families)
                            if (f.Name == pfc.Families[0].Name)
                            {
                                FontOK = true;
                                break;
                            }
                        Console.WriteLine(pfc.Families[0]);
                        if (FontOK == false)
                        {
                            Process.Start("fontview.exe", "Font\\Koruri-Regular.ttf");
                            DialogResult Result = MessageBox.Show($"フォントがインストールされていません。Font\\Koruri-Regular.ttfをインストールしてください。", "WQV_FontCheck", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                            if (Result != DialogResult.Retry)
                            {
                                Application.Exit();
                                break;//これないとプロセス無限起動される
                            }
                            Thread.Sleep(1000);//念のため
                        }
                        else
                            FontOK = true;
                        ifc.Dispose();
                    }
                }
                pfc.Dispose();
            }
            catch
            {

            }
            ErrorText.Text = "設定読み込み中…";
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            if (File.Exists("UserSetting.xml"))//AppDataに保存
            {
                if (!Directory.Exists(Config.FilePath.Replace("\\user.config", "")))//実質更新時
                    Directory.CreateDirectory(Config.FilePath.Replace("\\user.config", ""));
                File.Copy("UserSetting.xml", Config.FilePath, true);
            }
            SettingReload();
            ErrorText.Text = "設定の読み込みが完了しました。";
            JsonTimer.Enabled = true;
        }
        private void JsonTimer_Tick(object sender, EventArgs e)//整理しろ
        {
            Console.WriteLine("///////////開始//////////");
            JsonTimer.Interval = 30000;
            try
            {
                ErrorText.Text = "取得中…";
                WebClient WC = new WebClient
                {
                    Encoding = Encoding.UTF8
                };//↓？　暫定対処したやつかも
                string USGSQuakeJson_ = "[" + WC.DownloadString("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/4.5_day.geojson") + "]";
                AccessedUSGS++;
                Console.WriteLine("取得:https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/4.5_day.geojson");
                string Latestchecktime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                double StartTime = Convert.ToDouble(DateTime.Now.ToString("yyyyMMddHHmmss.ffff"));
                List<USGSQuake> USGSQuakeJson = JsonConvert.DeserializeObject<List<USGSQuake>>(USGSQuakeJson_);
                Console.WriteLine("各履歴処理開始");
                DateTimeOffset Update_ = DateTimeOffset.FromUnixTimeMilliseconds(USGSQuakeJson[0].Metadata.Generated).ToLocalTime();
                string UpdateTime_ = $"{Update_:yyyy/MM/dd HH:mm:ss}";
                int SoundLevel = 0;//音声判別用 初報ほど、M大きいほど高い
                List<long> EQTimeList = new List<long>();
                for (int i = 0; i < 7; i++)//古いやつ削除用
                    EQTimeList.Add((long)USGSQuakeJson[0].Features[i].Properties.Time);
                for (int i = 6; i >= 0; i--)//古い順に
                {
                    bool New = false;//音声判別用
                    string ID = USGSQuakeJson[0].Features[i].Id;
                    DateTimeOffset Update = DateTimeOffset.FromUnixTimeMilliseconds((long)USGSQuakeJson[0].Features[i].Properties.Updated).ToLocalTime();
                    string UpdateTime = $"{Update:yyyy/MM/dd HH:mm:ss}";
                    string Updated = "null";
                    if (Histories.ContainsKey(ID))
                        Updated = Histories[ID].UpdateTime;
                    if ($"{USGSQuakeJson[0].Features[i].Properties.Updated}" != Updated)
                    {
                        Console.WriteLine($"[{i}] 更新時刻変化検知(s->{USGSQuakeJson[0].Features[i].Properties.Updated})");
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
                        string LatStDecimal = $"N{Math.Round(Lat, 2, MidpointRounding.AwayFromZero)}".Replace("N-", "S");
                        string LongStDecimal = $"E{Math.Round(Long, 2, MidpointRounding.AwayFromZero)}".Replace("E-", "W");
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
                            Console.WriteLine($"震源キャッシュが存在します({HypoPoint.X},{HypoPoint.Y}->{HypoIDs[HypoPoint]})");
                        }
                        else
                        {
                            Console.WriteLine($"震源キャッシュが存在しません。({HypoPoint.X},{HypoPoint.Y})ダウンロードします。");
                            try
                            {
                                string USGSFERegion_ = WC.DownloadString($"https://earthquake.usgs.gov/ws/geoserve/regions.json?latitude={LatShort}&longitude={LongShort}&type=fe");
                                AccessedFE++;
                                Console.WriteLine($"取得:$\"https://earthquake.usgs.gov/ws/geoserve/regions.json?latitude={LatShort}&longitude={LongShort}&type=fe\"");
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
                        string LogText_ = $"USGS地震情報【{MagType}{Mag}】{Time.Replace("※", "(")})\n{Shingen}{Shingen2}\n{LatView},{LongView}　{Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}　{Arart.Replace("アラート:-", "")}\n{USGSQuakeJson[0].Features[i].Properties.Url}";
                        string BouyomiText = $"USGS地震情報。マグニチュード{Mag}、震源、{Shingen.Replace(" ", "、").Replace("/", "、").Replace("震源:", "")}、{LatStLongJP}、{LongStLongJP}、深さ{DepthLong.Replace("深さ:", "")}。{$"推定最大改正メルカリ震度階級{MMI.Replace("(", "").Replace(")", "")}".Replace("推定最大改正メルカリ震度階級-", "")}。{Arart.Replace("アラート:-", "")}";
                        bool NewUpdt = false;
                        if (!Histories.ContainsKey(ID))//Keyないと探したときエラーになるから別化
                            NewUpdt = true;
                        else if (Histories[ID].Text != LogText_)
                            NewUpdt = true;
                        if (NewUpdt)//更新、初回検知
                        {
                            if (Histories.ContainsKey(ID))//更新
                            {
                                LogText_ = LogText_.Replace("USGS地震情報", "USGS地震情報(更新)");
                                BouyomiText = BouyomiText.Replace("USGS地震情報", "USGS地震情報、更新");
                                Console.WriteLine($"//////////{ID}更新検知//////////\n{Histories[ID].Text.Replace("\n", "")}->\n{LogText_.Replace("\n", "")}");
                                Histories[ID] = new History
                                {
                                    Text = LogText_,
                                    UpdateTime = Convert.ToString(USGSQuakeJson[0].Features[i].Properties.Updated),
                                    EQTime = (long)USGSQuakeJson[0].Features[i].Properties.Time,
                                    TweetID = Histories[ID].TweetID
                                };
                            }
                            else//new
                            {
                                Console.WriteLine($"//////////{ID}初回検知//////////\n{LogText_.Replace("\n", "")}");
                                New = true;
                                Histories.Add(ID, new History
                                {
                                    Text = LogText_,
                                    UpdateTime = Convert.ToString(USGSQuakeJson[0].Features[i].Properties.Updated),
                                    EQTime = (long)USGSQuakeJson[0].Features[i].Properties.Time,
                                    TweetID = 0
                                });
                            }
                            LogSave("Log\\M4.5+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{Version}\n{LogText_}", ID);
                            if (Settings.Default.Socket_Enable)
                                SendSocket(LogText_);
                            if (SoundLevel < 1 && Settings.Default.Sound_45_Enable)//SoundLevel上昇+M4.5以上有効
                                if (New)//初報
                                    SoundLevel = 2;
                                else if (Settings.Default.Sound_Updt_Enable)//更新+更新有効
                                    SoundLevel = 1;
                            if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                            {
                                LogSave("Log\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{Version}\n{LogText_}", ID);
                                if (SoundLevel < 3 && Settings.Default.Sound_60_Enable)
                                    if (New)
                                        SoundLevel = 4;
                                    else if (Settings.Default.Sound_Updt_Enable)
                                        SoundLevel = 3;
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
                                {
                                    LogSave("Log\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{Version}\n{LogText_}", ID);
                                    if (SoundLevel < 5 && Settings.Default.Sound_80_Enable)
                                        if (New)
                                            SoundLevel = 6;
                                        else if (Settings.Default.Sound_Updt_Enable)
                                            SoundLevel = 5;
                                }
                            }
                            if (i == 0)//最新
                            {
                                //x:+200が中心 左余白-250 y:+300が中心
                                int LocX = (int)(Long + 180) * -5 - 50;//(-180,0,180) + 180 -> (0,180,360)
                                int LocY = (int)(90 - Lat) * -5 + 300;//90 - (90,0,-90) -> (0,90,180)
                                int LocY_ = LocY;
                                if (LocY > 0)
                                    LocY_ = 0;
                                else if (LocY < -500)
                                    LocY_ = -500;
                                MainImg.Location = new Point(LocX, LocY);
                                Bitmap MainBitmap = new Bitmap(Resources.WorldMap);
                                Graphics graphics = Graphics.FromImage(MainBitmap);
                                graphics.DrawImage(Resources.Point, new Rectangle(LocX * -1 + 185, LocY * -1 + 285, 30, 30));
                                MainImg.Image = MainBitmap;
                                graphics.Dispose();
                                USGS0.Text = $"USGS地震情報                                     {Time}";
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
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
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
                            }
                            else if (i == 1)//履歴
                            {
                                History11.Text = $"{Time} 発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History12.Text = $"{MagType}";
                                History13.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History11.ForeColor = Color.Yellow;
                                    History12.ForeColor = Color.Yellow;
                                    History13.ForeColor = Color.Yellow;
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
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
                                History21.Text = $"{Time} 発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History22.Text = $"{MagType}";
                                History23.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History21.ForeColor = Color.Yellow;
                                    History22.ForeColor = Color.Yellow;
                                    History23.ForeColor = Color.Yellow;
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
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
                                History31.Text = $"{Time} 発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History32.Text = $"{MagType}";
                                History33.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History31.ForeColor = Color.Yellow;
                                    History32.ForeColor = Color.Yellow;
                                    History33.ForeColor = Color.Yellow;
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
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
                                History41.Text = $"{Time} 発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History42.Text = $"{MagType}";
                                History43.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History41.ForeColor = Color.Yellow;
                                    History42.ForeColor = Color.Yellow;
                                    History43.ForeColor = Color.Yellow;
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
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
                                History51.Text = $"{Time} 発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History52.Text = $"{MagType}";
                                History53.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History51.ForeColor = Color.Yellow;
                                    History52.ForeColor = Color.Yellow;
                                    History53.ForeColor = Color.Yellow;
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
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
                                History61.Text = $"{Time} 発生  ID:{ID}\n{Shingen}\n{LatView},{LongView} {Depth}\n推定最大改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}";
                                History62.Text = $"{MagType}";
                                History63.Text = $"{Mag}";
                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                                {
                                    History61.ForeColor = Color.Yellow;
                                    History62.ForeColor = Color.Yellow;
                                    History63.ForeColor = Color.Yellow;
                                    if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
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
                                if (Settings.Default.Bouyomichan_Enable)
                                    Bouyomichan(BouyomiText);
                            if (USGSQuakeJson[0].Features[i].Properties.Mag >= Settings.Default.Tweet_LowerMagnitudeLimit || USGSQuakeJson[0].Features[i].Properties.Mmi >= Settings.Default.Tweet_LowerMMILimit)
                                if (Settings.Default.Tweet_Enable)
                                    Task.Run(() => Tweet(LogText_, ID));
                        }
                        else
                            Console.WriteLine($"[{i}] 内容更新なし");
                    }
                    else
                        Console.WriteLine($"[{i}] 更新なし(更新:{Updated})");
                }

                USGS6.Text = $"{UpdateTime_}更新\n{Latestchecktime}取得\n地図データ:NationalEarth";
                USGS6.Location = new Point(400 - USGS6.Width, 500 - USGS6.Height);
                /*//旧処理
            if (Histories.Count > 7)//古いもの削除
            {
                Console.WriteLine($"{Histories.First().Key}を削除しました。");
                Histories.Remove(Histories.First().Key);
            }
                */
                //新処理
                Console.WriteLine($"ログ保持数:{Histories.Count} - ");
                for (int i = 0; i < Histories.Count; i++)
                {
                    Console.WriteLine(Histories.Values.ToArray()[i].Text.Replace("\n", ""));
                    if (!EQTimeList.Contains(Histories.Values.ToArray()[i].EQTime))
                    {
                        Console.WriteLine($"{Histories.Keys.ToArray()[i]}を削除しました。");
                        Histories.Remove(Histories.Keys.ToArray()[i]);
                    }
                }
                Console.WriteLine($"ログ保持数:{Histories.Count}");
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
                ErrorText.Text = $"ネットワークエラーが発生しました。\n内容:" + ex.Message;
            }
            catch (Exception ex)
            {
                ErrorText.Text = $"エラーが発生しました。\nエラーログの内容を報告してください。\n内容:" + ex.Message;
                LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main Version:{Version}\n{ex}");
            }
            ErrorText.Text = ErrorText.Text.Replace("取得中…", "");
            NoFirst = true;
            Console.WriteLine("処理終了");
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
        /// <param name="SaveDirectory">保存するディレクトリ。Log\\[M4.5+,M6.0+,M8.0+,ErrorLog...]</param>
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
                            status = tokens.Statuses.UpdateAsync(new { status = Text, in_reply_to_status_id = Histories[ID].TweetID }).Result;
                        }
                        catch
                        {
                            status = tokens.Statuses.UpdateAsync(new { status = Text }).Result;
                        }
                    else
                        status = tokens.Statuses.UpdateAsync(new { status = Text }).Result;

                    Histories[ID].TweetID = status.Id;
                }
                catch (Exception ex)
                {
                    ErrorText.Text = $"ツイートに失敗しました。\nわからない場合エラーログの内容を報告してください。\n内容:" + ex.Message;
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
                    IPEndPoint IPEndPoint = new IPEndPoint(IPAddress.Parse(Settings.Default.Socket_Host), Settings.Default.Socket_Port);
                    using (TcpClient TcpClient = new TcpClient())
                    {
                        TcpClient.Connect(IPEndPoint);
                        using (NetworkStream NetworkStream = TcpClient.GetStream())
                        {
                            byte[] Bytes = new byte[4096];
                            Bytes = Encoding.UTF8.GetBytes(Text);
                            NetworkStream.Write(Bytes, 0, Bytes.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorText.Text = $"Socket送信に失敗しました。\nわからない場合エラーログの内容を報告してください。\n内容:" + ex.Message;
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
                }
                catch (Exception ex)
                {
                    ErrorText.Text = $"棒読みちゃんへの送信に失敗しました。\nわからない場合エラーログの内容を報告してください。\n内容:" + ex.Message;
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Bouyomichan Version:{Version}\n{ex}");
                }
        }
        /// <summary>
        /// 設定を読み込みます。
        /// </summary>
        /// <remarks>即時サイズ変更を行います。</remarks>
        public void SettingReload()
        {
            Settings.Default.Reload();
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            if(File.Exists(Config.FilePath))
            File.Copy(Config.FilePath, "UserSetting.xml", true);
            if (Settings.Default.Display_HideHistory)
                if (Settings.Default.Display_HideHistoryMap)
                    Size = new Size(416, 139);//400,100
                else
                    Size = new Size(416, 539);//400,500
            else
                Size = new Size(816, 539);//800,500
        }
        public static SoundPlayer Player = null;
        /// <summary>
        /// 音声を再生します。
        /// </summary>
        /// <param name="SoundFile">再生するSoundフォルダの中の音声ファイル。</param>
        public static void Sound(string SoundFile)
        {
            if (NoFirst)
            {
                if (Player != null)
                {
                    Player.Stop();
                    Player.Dispose();
                    Player = null;
                }
                Player = new SoundPlayer($"Sound\\{SoundFile}");
                Player.Play();
            }
        }
        private void RCsetting_Click(object sender, EventArgs e)
        {
            SettingsForm Settings = new SettingsForm();
            Settings.FormClosed += Setting_FormClosing;//閉じたとき呼び出し
            Settings.Show();
        }
        private void Setting_FormClosing(object sender, FormClosedEventArgs e)
        {
            SettingReload();
            ErrorText.Text = "設定を再読み込みしました。\n一部の設定は情報受信または再起動が必要です。";
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
        private void MainForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Process.Start("notepad.exe", "README.md");
            }
            catch (Exception ex)
            {
                DialogResult Result = MessageBox.Show($"README.mdを開けませんでした。({ex.Message})\nブラウザで表示しますか?", "WQV_help", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (Result == DialogResult.Yes)
                    Process.Start("https://github.com/Ichihai1415/WorldQuakeViewer/blob/main/README.md");
            }
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
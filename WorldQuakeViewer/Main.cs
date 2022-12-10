using CoreTweet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using USGSFERegionsClass;
using USGSFERegionsClass2;
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

        }
        private void JsonTimer_Tick(object sender, EventArgs e)//整理しろ
        {
            bool IsDebug = false;
            Settings.Default.Reload();
            JsonTimer.Interval = 30000;
            try
            {
                ErrorText.Text = "取得中…";
                WebClient WC = new WebClient
                {
                    Encoding = Encoding.UTF8
                };//↓？　
                string USGSQuakeJson_ = "[" + WC.DownloadString("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/4.5_day.geojson") + "]";
                string Latestchecktime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                double StartTime = Convert.ToDouble(DateTime.Now.ToString("yyyyMMddHHmmss.ffff"));
                List<USGSQuake> USGSQuakeJson = JsonConvert.DeserializeObject<List<USGSQuake>>(USGSQuakeJson_);
                DateTimeOffset Update = DateTimeOffset.FromUnixTimeMilliseconds((long)USGSQuakeJson[0].Features[0].Properties.Updated).ToLocalTime();
                string UpdateTime = $"{Update:yyyy/MM/dd HH:mm:ss}";
                DateTimeOffset DataTimeNew = DateTimeOffset.FromUnixTimeMilliseconds((long)USGSQuakeJson[0].Features[0].Properties.Time).ToLocalTime();
                string TimeNew = $"{DataTimeNew:HHmm}";
                string TimeOld = $"{DataTimeOld:HHmm}";
                DataTimeOld = DataTimeNew;

                for (int i = 0; i > 7; i++)
                {
                    if ($"{USGSQuakeJson[0].Features[i].Properties.Updated}" != LatestUpdateTime)
                    {
                        LatestUpdateTime = $"{USGSQuakeJson[0].Features[i].Properties.Updated}";
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
                        LatestURL = USGSQuakeJson[0].Features[i].Properties.Url;
                        string MagType = USGSQuakeJson[0].Features[i].Properties.MagType;
                        double Lat = USGSQuakeJson[0].Features[i].Geometry.Coordinates[1];
                        double Long = USGSQuakeJson[0].Features[i].Geometry.Coordinates[0];
                        string Arart = "アラート:-";
                        if (USGSQuakeJson[0].Features[i].Properties.Alert != null)
                            Arart = Arart.Replace("-", USGSQuakeJson[0].Features[i].Properties.Alert.Replace("green", "緑").Replace("yellow", "黄").Replace("orange", "オレンジ").Replace("red", "赤").Replace("pending", "保留中"));
                        string LatStFull = $"N{Lat}".Replace("N-", "S");
                        string LongStFull = $"E{Long}".Replace("E-", "W");
                        TimeSpan LatMath = TimeSpan.FromHours(Lat);
                        TimeSpan LongMath = TimeSpan.FromHours(Long);
                        string LatStShort = $"{(int)Lat}ﾟ{LatMath.Minutes}'N";
                        string LongStShort = $"{(int)Long}ﾟ{LongMath.Minutes}'E";
                        if (Lat < 0)
                            LatStShort = $"{(int)Lat * -1}ﾟ{LatMath.Minutes * -1}'S";
                        if (Long < 0)
                            LongStShort = $"{(int)Long * -1}ﾟ{LongMath.Minutes * -1}'W";
                        string LatStLong = $"{(int)Lat}ﾟ{LatMath.Minutes}'{LatMath.Seconds}\"N";
                        string LongStLong = $"{(int)Long}ﾟ{LongMath.Minutes}'{LongMath.Seconds}\"E";
                        if (Lat < 0)
                            LatStLong = $"{(int)Lat * -1}ﾟ{LatMath.Minutes * -1}'{LatMath.Seconds * -1}\"S";
                        if (Long < 0)
                            LongStLong = $"{(int)Long * -1}ﾟ{LongMath.Minutes * -1}'{LongMath.Seconds * -1}\"W";
                        string LatStLongJP = $"北緯{(int)Lat}度{LatMath.Minutes}分{LatMath.Seconds}秒";
                        string LongStLongJP = $"東経{(int)Long}度{LongMath.Minutes}分{LongMath.Seconds}秒";
                        if (Lat < 0)
                            LatStLongJP = $"南緯{(int)Lat * -1}度{LatMath.Minutes * -1}分{LatMath.Seconds * -1}秒";
                        if (Long < 0)
                            LongStLongJP = $"西経{(int)Long * -1}度{LongMath.Minutes * -1}分{LongMath.Seconds * -1}秒";
                        string Depth = $"深さ:約{(int)Math.Round(USGSQuakeJson[0].Features[i].Geometry.Coordinates[2], MidpointRounding.AwayFromZero)}km";
                        if (USGSQuakeJson[0].Features[i].Geometry.Coordinates[2] == (int)USGSQuakeJson[0].Features[i].Geometry.Coordinates[2])
                            Depth = $"(深さ:{USGSQuakeJson[0].Features[i].Geometry.Coordinates[2]}km?)";
                        string DepthLong = $"深さ:{USGSQuakeJson[0].Features[i].Geometry.Coordinates[2]}km";
                        if (USGSQuakeJson[0].Features[i].Geometry.Coordinates[2] == (int)USGSQuakeJson[0].Features[i].Geometry.Coordinates[2])
                            DepthLong = Depth;
                        string USGSFERegion_ = "";
                        try
                        {
                            USGSFERegion_ = WC.DownloadString($"https://earthquake.usgs.gov/ws/geoserve/regions.json?latitude={Lat}&longitude={Long}&type=fe");
                        }
                        catch
                        {

                        }
                        string Shingen1 = "震源: - - - - - ";
                        string Shingen1_ = "null";
                        string Num1 = "null";
                        string Num2 = "null";
                        string JPNameNotFoundLogText = "";
                        try//code1
                        {
                            USGSFERegions USGSFERegion = JsonConvert.DeserializeObject<USGSFERegions>(USGSFERegion_);
                            Shingen1 = "震源:" + HypoName[(int)USGSFERegion.Fe.Features[i].Properties.Number];
                            Num1 = $"{USGSFERegion.Fe.Features[i].Properties.Number}";
                        }
                        catch//code1がnull
                        {
                            try//code2
                            {
                                USGSFERegions USGSFERegion = JsonConvert.DeserializeObject<USGSFERegions>(USGSFERegion_);
                                Shingen1 = "震源:" + HypoName[(int)USGSFERegion.Fe.Features[1].Properties.Number];
                                Shingen1_ = HypoName[(int)USGSFERegion.Fe.Features[1].Properties.Number];
                                Num2 = $"{USGSFERegion.Fe.Features[1].Properties.Number}";
                            }
                            catch//code2がnull　英語名表示　ログ出力
                            {
                                try
                                {
                                    USGSFERegions2 USGSFERegion2 = JsonConvert.DeserializeObject<USGSFERegions2>(USGSFERegion_);
                                    Shingen1 = "震源:" + USGSFERegion2.Fe.Features[i].Properties.Name;
                                    JPNameNotFoundLogText = $"{File.ReadAllText($"Log\\JPNameNotFound.txt")}\n";

                                    if (JPNameNotFoundLogText.Contains($"Number1={Num1},Number2={Num2},Name1={Shingen1.Replace("震源:", "").Replace(" - - - - - ", "null").Replace(Shingen1_, "null")},Name2={Shingen1_}") == false)
                                    {
                                        JPNameNotFoundLogText += $"Time={DateTime.Now:MM/dd HH:mm},Latitude={Lat},Longitude={Long},Number1={Num1},Number2={Num2},Name1={Shingen1.Replace("震源:", "").Replace(" - - - - - ", "null").Replace(Shingen1_, "null")},Name2={Shingen1_}";
                                        File.WriteAllText($"Log\\JPNameNotFound.txt", JPNameNotFoundLogText);
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }
                        string Shingen2 = $"({USGSQuakeJson[0].Features[i].Properties.Place})";
                        //x:+200が中心 左余白-250 y:+300が中心
                        int LocX = (int)(Long + 180) * -5 - 50;//(-180,0,180) + 180 -> (0,180,360)
                        int LocY = (int)(90 - Lat) * -5 + 300;//90 - (90,0,-90) -> (0,90,180)
                        MainImg.Location = new Point(LocX, LocY);
                        Bitmap MainBitmap = new Bitmap(Resources.WorldMap);
                        Graphics graphics = Graphics.FromImage(MainBitmap);
                        graphics.DrawImage(Resources.Point, new Rectangle(LocX * -1 + 185, LocY * -1 + 285, 30, 30));
                        MainImg.Image = MainBitmap;
                        graphics.Dispose();

                        string MMI = "-";
                        if (USGSQuakeJson[0].Features[i].Properties.Mmi != null)
                            MMI = $"({Convert.ToString(USGSQuakeJson[0].Features[i].Properties.Mmi)})";
                        USGS0.Text = $"USGS地震情報　　　　　{Time}";
                        USGS1.Text = $"{Shingen1}\n{Shingen2}\n{LatStShort} {LongStShort}\n{Depth}";
                        USGS2.Text = $"{MagType}";
                        USGS3.Text = $"{Mag}";
                        USGS4.Text = $"改正メルカリ\n　　震度階級:";
                        USGS5.Text = $"{MMI.Replace("(", "").Replace(")", "")}";
                        this.UpdateTime = UpdateTime;
                        string LogText_ = $"USGS地震情報【{MagType}{Mag}】{Time.Replace("※", "(")})\n{Shingen1}{Shingen2}\n{LatStLong},{LongStLong}　{Depth}\n改正メルカリ震度階級:{MaxInt}{MMI.Replace("-", "")}　{Arart.Replace("アラート:-", "")}\n{LatestURL}";
                        string BouyomiText = $"USGS地震情報。マグニチュード{Mag}、震源、{Shingen1.Replace(" ", "、").Replace("/", "、").Replace("震源:", "")}、{LatStLongJP}、{LongStLongJP}、深さ{DepthLong.Replace("深さ:", "")}。{$"推定最大改正メルカリ震度階級{MMI.Replace("(", "").Replace(")", "")}".Replace("改正メルカリ震度階級-", "")}。{Arart.Replace("アラート:-", "")}";

                        if (LatestText != LogText_)
                        {
                            LatestText = LogText_;
                            if (TimeOld == TimeNew)
                            {
                                LogText_ = LogText_.Replace("USGS地震情報", "USGS地震情報(更新)");
                                BouyomiText = BouyomiText.Replace("USGS地震情報", "USGS地震情報、更新");
                            }
                            LogSave("Log\\M4.5+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}");



                            if (USGSQuakeJson[0].Features[i].Properties.Mag >= 6.0)
                            {
                                USGS0.ForeColor = Color.Yellow;
                                USGS1.ForeColor = Color.Yellow;
                                USGS2.ForeColor = Color.Yellow;
                                USGS3.ForeColor = Color.Yellow;
                                USGS4.ForeColor = Color.Yellow;
                                USGS5.ForeColor = Color.Yellow;
                                LogSave("Log\\M6.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}");

                                if (USGSQuakeJson[0].Features[i].Properties.Mag >= 8.0)
                                {
                                    USGS0.ForeColor = Color.Red;
                                    USGS1.ForeColor = Color.Red;
                                    USGS2.ForeColor = Color.Red;
                                    USGS3.ForeColor = Color.Red;
                                    USGS4.ForeColor = Color.Red;
                                    USGS5.ForeColor = Color.Red;
                                    LogSave("Log\\M8.0+", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Version:{NowVersion}\n{LogText_}");
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
                            if (USGSQuakeJson[0].Features[i].Properties.Mag >= Settings.Default.Tweet_LowerMagnitudeLimit || USGSQuakeJson[0].Features[i].Properties.Mmi >= Settings.Default.Tweet_LowerMMILimit)
                                if (Settings.Default.Tweet_Valid && IsDebug == false)
                                    Tweet(LogText_);

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
                        }
                    }
                }



                ErrorText.Text = ErrorText.Text.Replace("取得中…", "");
            }
            catch (WebException ex)
            {
                ErrorText.Text = $"ネットワークエラーが発生しました。内容:" + ex.Message;
            }
            catch (Exception ex)
            {
                ErrorText.Text = $"エラーが発生しました。\nエラーログの内容を報告してください。\n内容:" + ex.Message;
                LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main Version:{NowVersion}\n{ex}");
            }
            finally
            {
                USGS6.Text = $"{UpdateTime}発表\n{DateTime.Now:yyyy/MM/dd HH:mm:ss}取得\n地図データ:NationalEarth";
                USGS6.Location = new Point(400 - USGS6.Width, 500 - USGS6.Height);
            }
        }
        public string NowVersion = "";
        public string LatestUpdateTime = "";
        public string UpdateTime = "----/--/-- --:--:--";
        public string LatestURL = "";
        public string LatestText = "";
        public DateTimeOffset DataTimeOld;
        public Dictionary<string, History> Histories = new Dictionary<string, History>();//ID,Data
        public Dictionary<Point, int> HypoIDs = new Dictionary<Point, int>();//Location,ID


        /// <summary>
        /// ログを保存します。
        /// </summary>
        /// <param name="SaveDirectory">保存するディレクトリ。Log\\[M4.5+,M6.0+,M8.0+,ErrorLog...]</param>
        /// <param name="SaveText">保存するテキスト。</param>
        public void LogSave(string SaveDirectory, string SaveText)
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
            else if (SaveDirectory == "Log\\Hypos")
            {
                if (!Directory.Exists($"{SaveDirectory}\\{NowTime:yyyyMM}"))
                    Directory.CreateDirectory($"{SaveDirectory}\\{NowTime:yyyyMM}");
                if (File.Exists($"{SaveDirectory}\\{NowTime:yyyyMM}\\{NowTime:yyyyMMdd}.txt"))
                    SaveText = File.ReadAllText($"{SaveDirectory}\\{NowTime:yyyyMM}\\{NowTime:yyyyMMdd}.txt") + "\n" + SaveText;
                File.WriteAllText($"{SaveDirectory}\\{NowTime:yyyyMM}\\{NowTime:yyyyMMdd}.txt", SaveText);
            }
            else if (SaveDirectory == "Log\\ErrorLog")
            {
                if (File.Exists($"Log\\ErrorLog\\{NowTime:yyyyMM}.txt"))
                    SaveText += "\n--------------------------------------------------\n" + File.ReadAllText($"Log\\ErrorLog\\{NowTime:yyyyMM}.txt");
                File.WriteAllText($"Log\\ErrorLog\\{NowTime:yyyyMM}.txt", SaveText);
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
        public void Tweet(string Text, string ID = null)
        {
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
        private void RCsetting_Click(object sender, EventArgs e)
        {
            SettingsForm Settings = new SettingsForm();
            Settings.Show();
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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WorldQuakeViewer.Properties;
using static WorldQuakeViewer.Util_Class;
using static WorldQuakeViewer.MainForm;

namespace WorldQuakeViewer
{
    /// <summary>
    /// 色々
    /// </summary>
    public class Util_Func
    {
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

        /// <summary>
        /// 描画用マグニチュード別色
        /// </summary>
        /// <param name="mag">マグニチュード</param>
        /// <returns>マグニチュード別の色</returns>
        public static Brush Mag2Brush(double mag)
        {
            if (mag < 6)
                return Brushes.White;
            else if (mag < 8)
                return Brushes.Yellow;
            else
                return Brushes.Red;
        }

        /// <summary>
        /// 描画用アラート別色
        /// </summary>
        /// <param name="alert">アラート</param>
        /// <returns>アラート別の色</returns>
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
        /// <param name="latStLong">(string) 設定により {###.##…}ﾟN または {###}ﾟ{##}'{##}"N</param>
        /// <param name="latStLongJP">(string) 設定により 北緯{###.##…}度 または 北緯{##}度{##}分{##}秒 </param>
        /// <param name="latDisplay">(string) 設定により {###.00}ﾟN または {###}ﾟ{##}'{##}"N </param>
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
        /// <param name="latStLong">(string) 設定により {###.##…}ﾟN または {###}ﾟ{##}'{##}"N</param>
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
        /// <param name="lonStLong">(string) 設定により {###.##…}ﾟE または {###}ﾟ{##}'{##}"E</param>
        /// <param name="lonStLongJP">(string) 設定により 東経{###.##…}度 または 東経{##}度{##}分{##}秒 </param>
        /// <param name="lonDisplay">(string) 設定により {###.00}ﾟE または {###}ﾟ{##}'{##}"E</param>
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
        /// <param name="lonStLong">(string) 設定により {###.##…}ﾟE または {###}ﾟ{##}'{##}"E</param>
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
        /// 棒読みちゃんに読み上げ指令を送ります。
        /// </summary>
        /// <param name="text">読み上げさせる文。</param>
        public static void Bouyomichan(string text)
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
                    //ErrorText.Text = $"棒読みちゃんへの送信に失敗しました。わからない場合エラーログの内容を報告してください。内容:{ex.Message}";
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Bouyomichan Version:{version}\n{ex}");
                }
        }

        /// <summary>
        /// Socket通信で送信します。
        /// </summary>
        /// <param name="text">送信する文。</param>
        public static async void SendSocket(string text)
        {
            if (noFirst && Settings.Default.Socket_Enable)
                try
                {
                    ExeLog($"[SendSocket]Socket送信中…({Settings.Default.Socket_Host}:{Settings.Default.Socket_Port})");
                    IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(Settings.Default.Socket_Host), Settings.Default.Socket_Port);
                    using (TcpClient tcpClient = new TcpClient(Settings.Default.Socket_Host, Settings.Default.Socket_Port))
                    using (NetworkStream networkStream = tcpClient.GetStream())
                    {
                        byte[] bytes = new byte[4096];
                        bytes = Encoding.UTF8.GetBytes(text);
                        await networkStream.WriteAsync(bytes, 0, bytes.Length);
                    }
                    ExeLog($"[SendSocket]Socket送信成功");
                }
                catch (Exception ex)
                {
                    //ErrorText.Text = $"Socket送信に失敗しました。わからない場合エラーログの内容を報告してください。内容:{ex.Message}";
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Socket Version:{version}\n{ex}");
                }
        }

        /// <summary>
        /// WebHookを送信します。
        /// </summary>
        /// <param name="text">送信するテキスト。</param>
        public static async void WebHook(string text)
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
                    //ErrorText.Text = $"WebHookの送信に失敗しました。わからない場合エラーログの内容を報告してください。内容:{ex.Message}";
                    LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,WebHook Version:{version}\n{ex}");
                }
        }

        /// <summary>
        /// ツイートします。
        /// </summary>
        /// <remarks><b>**ツイートできる手段ができるまで廃止**</b></remarks>
        /// <param name="text">ツイートするテキスト。</param>
        /// <param name="source">データ元</param>
        /// <param name="id">リプライ判別用地震ID。</param>
        public static async void Tweet(string text, string source, string id)
        {
            await Task.Delay(1);
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
    }
}

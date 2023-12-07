using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using WorldQuakeViewer.Properties;
using static System.Net.Mime.MediaTypeNames;
using static WorldQuakeViewer.Config;
using static WorldQuakeViewer.CtrlForm;
using static WorldQuakeViewer.MainForm;
using static WorldQuakeViewer.Util_Class;
using static WorldQuakeViewer.Util_Conv;

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
        /// ログを保存します。
        /// </summary>
        /// <param name="logKind">ログの種類</param>
        /// <param name="text">保存する文</param>
        /// <param name="id">(地震ログのみ)地震ID</param>
        public static void LogSave(LogKind logKind, string text, string id = "unknown")
        {
            try
            {
                string dir = "";
                string name = "";
                switch ((int)logKind)
                {
                    case 1:
                        dir = $"Log\\Execution\\{DateTime.Now:yyyyMM\\dd}";
                        name = $"{DateTime.Now:yyyyMMddHHmmss}.log";
                        break;
                    case 2:
                        dir = $"Log\\Error\\{DateTime.Now:yyyyMM\\dd}";
                        name = $"{DateTime.Now:yyyyMMddHHmmss.ffff}.log";
                        break;
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        dir = $"Log\\{logKind}\\{DateTime.Now:yyyyMM\\dd}";
                        name = $"{id}.txt";
                        if (File.Exists($"{dir}\\{name}"))
                            text = $"{File.ReadAllText($"{dir}\\{name}")}\n--------------------------------------------------\n{text}";
                        break;
                }
                ExeLog($"[LogSave]保存開始({dir}\\{name})");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                File.WriteAllText($"{dir}\\{name}", text);
                ExeLog($"[LogSave]保存成功");
            }
            catch (Exception ex)
            {
                ExeLog($"[LogSave]エラー:{ex.Message}");
                LogSave(LogKind.Error, ex.ToString());
            }
        }

        /// <summary>
        /// 更新を確認します。
        /// </summary>
        /// <param name="data_o">前のデータ</param>
        /// <param name="data_n">新しいデータ</param>
        /// <param name="dataAuthor">データ元</param>
        /// <returns>更新か</returns>
        public static bool UpdateCheck(Data data_o, Data data_n, DataAuthor dataAuthor)
        {
            bool update = false;
            Data_.Update_ config_data_update = config.Datas[(int)dataAuthor].Update;
            if (config_data_update.Time)
                if (data_n.Time != data_o.Time)
                    update = true;
            if (config_data_update.UpdtTime)
                if (data_n.UpdtTime != data_o.UpdtTime)
                    update = true;
            if (config_data_update.Hypo)
                if (data_n.Hypo != data_o.Hypo)
                    update = true;
            if (config_data_update.LatLon)
                if (data_n.Lat != data_o.Lat)
                    update = true;
            if (config_data_update.LatLon)
                if (data_n.Lon != data_o.Lon)
                    update = true;
            if (config_data_update.Depth)
                if (data_n.Depth != data_o.Depth)
                    update = true;
            if (config_data_update.MagType)
                if (data_n.MagType != data_o.MagType)
                    update = true;
            if (config_data_update.Mag)
                if (data_n.Mag != data_o.Mag)
                    update = true;
            if (config_data_update.MMI)
                if (data_n.MMI != data_o.MMI)
                    update = true;
            if (config_data_update.Alert)
                if (data_n.Alert != data_o.Alert)
                    update = true;
            if (config_data_update.Source)
                if (data_n.Source != data_o.Source)
                    update = true;
            return update;
        }

        /// <summary>
        /// 更新時処理
        /// </summary>
        /// <param name="dataAuthor">データ元</param>
        /// <param name="data">データ</param>
        /// <param name="isNew">新規か</param>
        public static void UpdatePros(DataAuthor dataAuthor, Data data, bool isNew = false)
        {
            int level = Mag2Level(data.Mag);
            Sound(level, dataAuthor);
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
        /// 音声を再生します。
        /// </summary>
        /// <param name="level">レベル</param>
        /// <param name="dataAuthor">データ元</param>
        public static void Sound(int level, DataAuthor dataAuthor)
        {
            if (noFirst)
                try
                {
                    bool end = false;
                    string path = "";
                    switch (level)
                    {
                        case 1:
                            end = !config.Datas[(int)dataAuthor].Sound.L1_Enable;
                            path = config.Datas[(int)dataAuthor].Sound.L1_Path;
                            break;
                        case 2:
                            end = !config.Datas[(int)dataAuthor].Sound.L2_Enable;
                            path = config.Datas[(int)dataAuthor].Sound.L2_Path;
                            break;
                        case 3:
                            end = !config.Datas[(int)dataAuthor].Sound.L3_Enable;
                            path = config.Datas[(int)dataAuthor].Sound.L3_Path;
                            break;
                        case 4:
                            end = !config.Datas[(int)dataAuthor].Sound.L4_Enable;
                            path = config.Datas[(int)dataAuthor].Sound.L4_Path;
                            break;
                        case 5:
                            end = !config.Datas[(int)dataAuthor].Sound.L5_Enable;
                            path = config.Datas[(int)dataAuthor].Sound.L5_Path;
                            break;
                        default:
                            throw new ArgumentException($"レベル({level})が不正です。");
                    }
                    if (dataAuthor == DataAuthor.Null)
                        throw new ArgumentException($"データ元({dataAuthor})が不正です。");
                    if (end)
                    {
                        ExeLog($"[Sound]再生対象外です。");
                        return;
                    }
                    if (!File.Exists(path))
                    {
                        ExeLog($"[Sound]音声ファイル({path})が見つかりませんでした。");
                        return;
                    }
                    ExeLog($"[Sound]音声再生開始({path})");
                    if (player != null)
                    {
                        player.Stop();
                        player.Dispose();
                        player = null;
                    }
                    player = new SoundPlayer(path);
                    player.Play();
                    ExeLog($"[Sound]音声再生成功");
                }
                catch (Exception ex)
                {
                    ExeLog($"[Sound]エラー:{ex.Message}");
                    LogSave(LogKind.Error, ex.ToString());
                }
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
                    ExeLog($"[Sound]エラー:{ex.Message}");
                    LogSave(LogKind.Error, ex.ToString());
                }
        }

        /// <summary>
        /// 棒読みちゃんに読み上げ指令を送ります。
        /// </summary>
        /// <param name="text">読み上げさせる文</param>
        /// <param name="mag">マグニチュード</param>
        /// <param name="dataAuthor">データ元</param>
        public static void Bouyomichan(string text, double mag, DataAuthor dataAuthor)
        {
            if (noFirst)
                if (mag > config.Datas[(int)dataAuthor].Bouyomi.LowerMagLimit)
                    try
                    {
                        var config_bouyomi = config.Datas[(int)dataAuthor].Bouyomi;
                        byte[] message = Encoding.UTF8.GetBytes(text);
                        using (TcpClient tcpClient = new TcpClient(config_bouyomi.Host,config_bouyomi.Port))
                        using (NetworkStream networkStream = tcpClient.GetStream())
                        using (BinaryWriter binaryWriter = new BinaryWriter(networkStream))
                        {
                            binaryWriter.Write((short)1);
                            binaryWriter.Write(config_bouyomi.Speed);
                            binaryWriter.Write(config_bouyomi.Tone);
                            binaryWriter.Write(config_bouyomi.Volume);
                            binaryWriter.Write(config_bouyomi.Voice);
                            binaryWriter.Write((byte)0);
                            binaryWriter.Write(message.Length);
                            binaryWriter.Write(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Main,Sound Version:{version}\n{ex}");
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

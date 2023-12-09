using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using WorldQuakeViewer.Properties;
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
            if (config.LogN.Normal_Enable)
                exeLogs += $"{DateTime.Now:HH:mm:ss.ffff} {text}\n";
            Console.WriteLine(text);
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
        /// <param name="data">データ</param>
        /// <param name="isNew">新規か</param>
        public static void UpdtPros(Data data, bool isNew = false)
        {
            if (noFirst)
                try
                {
                    DataAuthor dataAuthor = data.Author;
                    if (dataAuthor == DataAuthor.Null)
                        throw new ArgumentException($"データ元が不正です。", dataAuthor.ToString());
                    int level = Mag2Level(data.Mag);
                    Sound(level, dataAuthor);
                    if (config.Datas[(int)dataAuthor].Bouyomi.Enable)
                        if (data.Mag >= config.Datas[(int)dataAuthor].Bouyomi.LowerMagLimit)
                            Bouyomichan(Data2ProString(data, UpdatePros.Bouyomichan), dataAuthor);
                    if (config.Datas[(int)dataAuthor].Socket.Enable)
                        if (data.Mag >= config.Datas[(int)dataAuthor].Socket.LowerMagLimit)
                            Socket(Data2ProString(data, UpdatePros.Socket), dataAuthor);
                    if (config.Datas[(int)dataAuthor].Webhook.Enable)
                        if (data.Mag >= config.Datas[(int)dataAuthor].Webhook.LowerMagLimit)
                            Webhook(Data2ProString(data, UpdatePros.Webhook), dataAuthor);
                }
                catch (Exception ex)
                {
                    ExeLog($"[UpdatePros]エラー:{ex.Message}");
                    LogSave(LogKind.Error, ex.ToString());
                }
        }

        /// <summary>
        /// 音声を再生します。
        /// </summary>
        /// <param name="level">レベル</param>
        /// <param name="dataAuthor">データ元</param>
        public static void Sound(int level, DataAuthor dataAuthor)
        {
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
                        throw new ArgumentException($"レベルが不正です。", level.ToString());
                }
                if (end)
                {
                    ExeLog($"[Sound]再生対象外です。");
                    return;
                }
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException("ファイルが見つかりませんでした。", path);
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
        /// <remarks>事前に有効確認が必要です。</remarks>
        /// <param name="text">読み上げさせる文</param>
        /// <param name="mag">マグニチュード</param>
        /// <param name="dataAuthor">データ元</param>
        public static void Bouyomichan(string text, DataAuthor dataAuthor)
        {
            try
            {
                Data_.Bouyomi_ config_bouyomi = config.Datas[(int)dataAuthor].Bouyomi;
                byte[] message = Encoding.UTF8.GetBytes(text);
                ExeLog($"[Bouyomichan]棒読みちゃん送信中…({config_bouyomi.Host}:{config_bouyomi.Port})");
                using (TcpClient tcpClient = new TcpClient(config_bouyomi.Host, config_bouyomi.Port))
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
                ExeLog($"[Bouyomichan]棒読みちゃん送信成功");
            }
            catch (Exception ex)
            {
                ExeLog($"[Bouyomichan]エラー:{ex.Message}");
                LogSave(LogKind.Error, ex.ToString());
            }
        }

        /// <summary>
        /// Socket通信で送信します。
        /// </summary>
        /// <remarks>事前に有効確認が必要です。</remarks>
        /// <param name="text">送信する文</param>
        /// <param name="mag">マグニチュード</param>
        /// <param name="dataAuthor">データ元</param>
        public static async void Socket(string text, DataAuthor dataAuthor)
        {
            try
            {
                Data_.Socket_ config_socket = config.Datas[(int)dataAuthor].Socket;
                byte[] message = new byte[4096];
                message = Encoding.UTF8.GetBytes(text);
                ExeLog($"[Socket]Socket送信中…({config_socket.Host}:{config_socket.Port})");
                using (TcpClient tcpClient = new TcpClient(config_socket.Host, config_socket.Port))
                using (NetworkStream networkStream = tcpClient.GetStream())
                    await networkStream.WriteAsync(message, 0, message.Length);
                ExeLog($"[Socket]Socket送信成功");
            }
            catch (Exception ex)
            {
                ExeLog($"[Socket]エラー:{ex.Message}");
                LogSave(LogKind.Error, ex.ToString());
            }
        }

        /// <summary>
        /// Webhookを送信します。
        /// </summary>
        /// <remarks>事前に有効確認が必要です。</remarks>
        /// <param name="text">送信する文</param>
        /// <param name="mag">マグニチュード</param>
        /// <param name="dataAuthor">データ元</param>
        public static async void Webhook(string text, DataAuthor dataAuthor)
        {
            try
            {
                Data_.Webhook_ config_webhook = config.Datas[(int)dataAuthor].Webhook;
                Dictionary<string, string> strs = new Dictionary<string, string>()
                        {
                            { "content", text }
                        };
                ExeLog($"[Webhook]Webhook送信中…({config_webhook.URL})");
                await client.PostAsync(config_webhook.URL, new FormUrlEncodedContent(strs));
                ExeLog($"[Webhook]Webhook送信成功");
            }
            catch (Exception ex)
            {
                ExeLog($"[Webhook]エラー:{ex.Message}");
                LogSave(LogKind.Error, ex.ToString());
            }
        }

        /// <summary>
        /// 画像ファイルがない場合リソースからコピーします。
        /// </summary>
        /// <param name="fileName">ファイル名。</param>
        /// <exception cref="Exception">画像指定が間違っている場合。</exception>
        public static void ImageCheck(string fileName)
        {
            if (!File.Exists($"Image\\{fileName}"))
            {
                if (!Directory.Exists("Image"))
                {
                    Directory.CreateDirectory("Image");
                    ExeLog($"[ImageCheck]Imageフォルダを作成しました");
                }
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

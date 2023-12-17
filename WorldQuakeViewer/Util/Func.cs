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
        public static void ExeLog(string text, bool isError = false)
        {
            if ((isError && config.Other.LogN.Error_Enable) || (!isError && config.Other.LogN.Normal_Enable))
            {
                exeLogs += $"{DateTime.Now:HH:mm:ss.ffff} {text}\n";
                ExeLogView($"{DateTime.Now:HH:mm:ss.ffff} {text}\r\n");
            }
            Console.WriteLine(text);
        }

        /// <summary>
        /// ログを保存します。
        /// </summary>
        /// <param name="logKind">ログの種類</param>
        /// <param name="text">保存する文</param>
        /// <param name="id">(地震ログのみ)地震ID</param>
        public static void LogSave(LogKind logKind, string text, string id = "")
        {
            try
            {
                Console.WriteLine($"ログ保存中({logKind})...");
                string dir = "";
                string name = "";
                switch (logKind)
                {
                    case LogKind.Exe:
                        dir = $"Log\\Execution\\{DateTime.Now:yyyyMM\\dd}";
                        name = $"{DateTime.Now:yyyyMMddHHmmss}.log";
                        break;
                    case LogKind.Error:
                        dir = $"Log\\Error\\{DateTime.Now:yyyyMM}";
                        name = $"{DateTime.Now:yyyyMMdd}.log";
                        text = $"Time:{DateTime.Now} Version:{version}\n{text}";
                        if (File.Exists($"{dir}\\{name}"))
                            text = $"{File.ReadAllText($"{dir}\\{name}")}\n--------------------------------------------------\n{text}";
                        break;
                    case LogKind.Other:
                    case LogKind.USGS:
                    case LogKind.EMSC:
                    case LogKind.GFZ:
                    case LogKind.EarlyEst:
                        if (id == "")
                            throw new ArgumentException($"地震idが指定されていません。", nameof(id));
                        dir = $"Log\\{logKind}\\{DateTime.Now:yyyyMM\\dd}";
                        name = $"{id}.txt";
                        if (File.Exists($"{dir}\\{name}"))
                            text = $"{File.ReadAllText($"{dir}\\{name}")}\n--------------------------------------------------\n{text}";
                        break;
                    default:
                        throw new ArgumentException($"ログの種類({logKind})が不正です。", nameof(logKind));
                }
                ExeLog($"[LogSave]保存開始({dir}\\{name})");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                File.WriteAllText($"{dir}\\{name}", text);
                ExeLog($"[LogSave]保存成功");
            }
            catch (Exception ex)
            {
                ExeLog($"[LogSave]エラー:{ex.Message}", true);
                LogSave(LogKind.Error, ex.ToString());
            }
        }

        /// <summary>
        /// 異なるIDを統合します。USGSのGeoJSONのみ。
        /// </summary>
        /// <remarks>catchしません</remarks>
        /// <param name="oldID"></param>
        /// <param name="newID"></param>
        public static void USGSgeojsonIDCorrect(string oldID, string newID)
        {
            data_USGS[newID] = data_USGS[oldID];
            data_USGS.Remove(oldID);
            data_All[newID] = data_USGS[oldID];
            data_All.Remove(oldID);
            ExeLog($"[USGSgeojsonIDCorrect]IDを統合しました({oldID}=>{newID})", true);
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
            Console.WriteLine("更新確認中...");
            Data_.Update_ config_data_update = config.Datas[(int)dataAuthor].Update;
            if (config_data_update.Time)
                if (data_n.Time != data_o.Time)
                {
                    ExeLog($"{data_o.Time}->{data_n.Time}");
                    return true;
                }
            if (config_data_update.UpdtTime)
                if (data_n.UpdtTime != data_o.UpdtTime)
                {
                    ExeLog($"{data_o.UpdtTime}->{data_n.UpdtTime}");
                    return true;
                }
            if (config_data_update.Hypo)
                if (data_n.Hypo != data_o.Hypo)
                {
                    ExeLog($"{data_o.Hypo}->{data_n.Hypo}");
                    return true;
                }
            if (config_data_update.LatLon)
                if (data_n.Lat != data_o.Lat)
                {
                    ExeLog($"{data_o.Lat}->{data_n.Lat}");
                    return true;
                }
            if (config_data_update.LatLon)
                if (data_n.Lon != data_o.Lon)
                {
                    ExeLog($"{data_o.Lon}->{data_n.Lon}");
                    return true;
                }
            if (config_data_update.Depth)
                if (data_n.Depth != data_o.Depth)
                {
                    ExeLog($"{data_o.Depth}->{data_n.Depth}");
                    return true;
                }
            if (config_data_update.MagType)
                if (data_n.MagType != data_o.MagType)
                {
                    ExeLog($"{data_o.MagType}->{data_n.MagType}");
                    return true;
                }
            if (config_data_update.Mag)
                if (data_n.Mag != data_o.Mag)
                {
                    ExeLog($"{data_o.Mag}->{data_n.Mag}");
                    return true;
                }
            if (config_data_update.MMI)
                if (data_n.MMI != data_o.MMI)
                {
                    ExeLog($"{data_o.MMI}->{data_n.MMI}");
                    return true;
                }
            if (config_data_update.Alert)
                if (data_n.Alert != data_o.Alert)
                {
                    ExeLog($"{data_o.Alert}->{data_n.Alert}");
                    return true;
                }
            if (config_data_update.Source)
                if (data_n.Source != data_o.Source)
                {
                    ExeLog($"{data_o.Source}->{data_n.Source}");
                    return true;
                }
            Console.WriteLine("更新なし");
            return false;
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
                    Console.WriteLine("更新処理開始");
                    DataAuthor dataAuthor = data.Author;
                    if (dataAuthor == DataAuthor.Null)
                        throw new ArgumentException($"データ元({dataAuthor})が不正です。", nameof(dataAuthor));
                    int level = Mag2Level(data.Mag);
                    Sound(level, dataAuthor);
                    if (config.Datas[(int)dataAuthor].Bouyomi.Enable)
                        if (data.Mag >= config.Datas[(int)dataAuthor].Bouyomi.LowerMagLimit)
                            Bouyomichan(Data2String(data, FormatPros.Bouyomichan, isNew), dataAuthor);
                    if (config.Datas[(int)dataAuthor].Socket.Enable)
                        if (data.Mag >= config.Datas[(int)dataAuthor].Socket.LowerMagLimit)
                            Socket(Data2String(data, FormatPros.Socket, isNew), dataAuthor);
                    if (config.Datas[(int)dataAuthor].Webhook.Enable)
                        if (data.Mag >= config.Datas[(int)dataAuthor].Webhook.LowerMagLimit)
                            Webhook(Data2String(data, FormatPros.Webhook, isNew), dataAuthor);
                    LogE(data, isNew, level, dataAuthor);
                }
                catch (Exception ex)
                {
                    ExeLog($"[UpdatePros]エラー:{ex.Message}", true);
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
                Console.WriteLine("音声処理開始");
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
                        throw new ArgumentException($"レベル({level})が不正です。", nameof(level));
                }
                if (end)
                {
                    Console.WriteLine("再生対象外です。");
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
                ExeLog($"[Sound]エラー:{ex.Message}", true);
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
                Console.WriteLine("棒読みちゃん処理開始");
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
                ExeLog($"[Bouyomichan]エラー:{ex.Message}", true);
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
                Console.WriteLine("Socket処理開始");
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
                ExeLog($"[Socket]エラー:{ex.Message}", true);
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
                Console.WriteLine("Webhook処理開始");
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
                ExeLog($"[Webhook]エラー:{ex.Message}", true);
                LogSave(LogKind.Error, ex.ToString());
            }
        }

        /// <summary>
        /// 地震ログを保存します。
        /// </summary>
        /// <param name="data">データ</param>
        /// <param name="isNew">新規か</param>
        /// <param name="level">レベル</param>
        /// <param name="dataAuthor">データ元</param>
        public static void LogE(Data data, bool isNew, int level, DataAuthor dataAuthor)
        {
            try
            {
                Console.WriteLine("地震ログ処理開始");
                bool end = false;
                string text;
                switch (level)
                {
                    case 1:
                        end = !config.Datas[(int)dataAuthor].LogE.L1_Enable;
                        break;
                    case 2:
                        end = !config.Datas[(int)dataAuthor].LogE.L2_Enable;
                        break;
                    case 3:
                        end = !config.Datas[(int)dataAuthor].LogE.L3_Enable;
                        break;
                    case 4:
                        end = !config.Datas[(int)dataAuthor].LogE.L4_Enable;
                        break;
                    case 5:
                        end = !config.Datas[(int)dataAuthor].LogE.L5_Enable;
                        break;
                    default:
                        throw new ArgumentException($"レベル({level})が不正です。", nameof(level));
                }
                if (end)
                {
                    ExeLog($"[LogE]保存対象外です。");
                    return;
                }
                text = Data2String(data, FormatPros.LogE, isNew);
                LogSave((LogKind)(dataAuthor + 10), text, data.ID);
            }
            catch (Exception ex)
            {
                ExeLog($"[LogE]エラー:{ex.Message}", true);
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
                        throw new Exception("画像のコピーに失敗しました。", new ArgumentException($"指定された画像({fileName})はResourcesにありません。", nameof(fileName)));
                }
                image.Save($"Image\\{fileName}", ImageFormat.Png);
                ExeLog($"[ImageCheck]画像(\"Image\\{fileName}\")をコピーしました");
            }
        }
    }
}

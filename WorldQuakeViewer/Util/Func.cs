using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
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
        /// <param name="isError">エラーの場合。</param>
        /// <remarks>タイムスタンプは自動で追加されます。</remarks>
        public static void ExeLog(string text, bool isError = false)
        {
            if ((!isError && config.Other.LogN.Normal_Enable) || isError)
            {
                exeLogs.Append(DateTime.Now.ToString("HH:mm:ss.ffff ")).AppendLine(text);
                ExeLogView($"{DateTime.Now:HH:mm:ss.ffff} {text}\r\n");
            }
            Console.WriteLine(text);
        }

        /// <summary>
        /// エラーログを保存します。
        /// </summary>
        /// <param name="ex">保存する例外</param>
        public static void LogSave(Exception ex)
        {
            LogSave(LogKind.Error, ex.ToString());
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
                        dir = $"Log\\Execution\\{DateTime.Now:yyyyMM\\\\dd}";
                        name = $"{DateTime.Now:yyyyMMddHHmmss}.log";
                        break;
                    case LogKind.Error:
                        if (!config.Other.LogN.Error_AutoSave)
                            break;
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
                        switch (logKind)
                        {
                            case LogKind.Other:
                                dir = $"Log\\{logKind}\\{data_Other[id].Time:yyyyMM\\\\dd}";
                                break;
                            case LogKind.USGS:
                                dir = $"Log\\{logKind}\\{data_USGS[id].Time:yyyyMM\\\\dd}";
                                break;
                            case LogKind.EMSC:
                                dir = $"Log\\{logKind}\\{data_EMSC[id].Time:yyyyMM\\\\dd}";
                                break;
                            case LogKind.GFZ:
                                dir = $"Log\\{logKind}\\{data_GFZ[id].Time:yyyyMM\\\\dd}";
                                break;
                            case LogKind.EarlyEst:
                                dir = $"Log\\{logKind}\\{data_EarlyEst[id].Time:yyyyMM\\\\dd}";
                                break;
                        }
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
                LogSave(ex);
            }
        }

        /// <summary>
        /// 異なるIDを統合します。USGSのGeoJSONのみ。
        /// </summary>
        /// <remarks>catchしません</remarks>
        /// <param name="oldID"></param>
        /// <param name="newID"></param>
        public static void USGSgeojsonIDMerge(string oldID, string newID)
        {
            data_USGS[newID] = data_USGS[oldID];
            data_USGS.Remove(oldID);
            data_All[newID] = data_USGS[oldID];
            data_All.Remove(oldID);
            ExeLog($"[USGSgeojsonIDMerge]IDを統合しました({oldID}=>{newID})");
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
                    ExeLog($"Time:{data_o.Time:yyyy/MM/dd HH:mm:ss.ffff}->{data_n.Time:yyyy/MM/dd HH:mm:ss.ffff}");
                    return true;
                }
            if (config_data_update.UpdtTime)
                if (data_n.UpdtTime != data_o.UpdtTime)
                {
                    ExeLog($"UpdtTime:{data_o.UpdtTime:yyyy/MM/dd HH:mm:ss.ffff}->{data_n.UpdtTime:yyyy/MM/dd HH:mm:ss.ffff}");
                    return true;
                }
            if (config_data_update.Hypo)
                if (data_n.Hypo != data_o.Hypo)
                {
                    ExeLog($"Hypo:{data_o.Hypo}->{data_n.Hypo}");
                    return true;
                }
            if (config_data_update.LatLon)
                if (data_n.Lat != data_o.Lat)
                {
                    ExeLog($"Lat:{data_o.Lat}->{data_n.Lat}");
                    return true;
                }
            if (config_data_update.LatLon)
                if (data_n.Lon != data_o.Lon)
                {
                    ExeLog($"Lon:{data_o.Lon}->{data_n.Lon}");
                    return true;
                }
            if (config_data_update.Depth)
                if (data_n.Depth != data_o.Depth)
                {
                    ExeLog($"Depth:{data_o.Depth}->{data_n.Depth}");
                    return true;
                }
            if (config_data_update.MagType)
                if (data_n.MagType != data_o.MagType)
                {
                    ExeLog($"MagType:{data_o.MagType}->{data_n.MagType}");
                    return true;
                }
            if (config_data_update.Mag)
                if (data_n.Mag != data_o.Mag)
                {
                    ExeLog($"Mag:{data_o.Mag}->{data_n.Mag}");
                    return true;
                }
            if (config_data_update.MMI)
                if (data_n.MMI != data_o.MMI)
                {
                    ExeLog($"MMI:{data_o.MMI}->{data_n.MMI}");
                    return true;
                }
            if (config_data_update.Alert)
                if (data_n.Alert != data_o.Alert)
                {
                    ExeLog($"Alert:{data_o.Alert}->{data_n.Alert}");
                    return true;
                }
            if (config_data_update.Source)
                if (data_n.Source != data_o.Source)
                {
                    ExeLog($"Source:{data_o.Source}->{data_n.Source}");
                    return true;
                }
            Console.WriteLine("更新なし");
            return false;
        }

        /// <summary>
        /// 更新時処理(音声以外)
        /// </summary>
        /// <remarks>地震ログのみ起動直後も行います。</remarks>
        /// <param name="data">データ</param>
        /// <param name="isNew">新規か</param>
        public static void UpdtPros(Data data, bool isNew = false)
        {
            try
            {
                Console.WriteLine("更新処理開始");
                DataAuthor dataAuthor = data.Author;
                if (dataAuthor == DataAuthor.Null)
                    throw new ArgumentException($"データ元({dataAuthor})が不正です。", nameof(dataAuthor));
                int level = Mag2Level(data.Mag);
                if (noFirst)
                {
                    if (config.Datas[(int)dataAuthor].Bouyomi.Enable)
                        if (data.Mag >= config.Datas[(int)dataAuthor].Bouyomi.LowerMagLimit)
                            Bouyomichan(Data2String(data, FormatPros.Bouyomichan, isNew), dataAuthor);
                    if (config.Datas[(int)dataAuthor].Socket.Enable)
                        if (data.Mag >= config.Datas[(int)dataAuthor].Socket.LowerMagLimit)
                            Socket(Data2String(data, FormatPros.Socket, isNew), dataAuthor);
                    if (config.Datas[(int)dataAuthor].Webhook.Enable)
                        if (data.Mag >= config.Datas[(int)dataAuthor].Webhook.LowerMagLimit)
                            Webhook(Data2String(data, FormatPros.Webhook, isNew), dataAuthor);
                }
                else
                    ExeLog("[UpdatePros]初回または停止中のため地震ログ書き込みのみ");
                LogE(data, isNew, level, dataAuthor);
            }
            catch (Exception ex)
            {
                ExeLog($"[UpdatePros]エラー:{ex.Message}", true);
                LogSave(ex);
            }
        }

        /// <summary>
        /// 音声を再生します。レベルは事前に最大レベルを計算してください。
        /// </summary>
        /// <param name="level">レベル</param>
        /// <param name="dataAuthor">データ元</param>
        public static void Sound_Play(int level, DataAuthor dataAuthor)
        {
            if (noFirst)
                try
                {
                    Console.WriteLine($"音声処理開始({level})");
                    bool end = false;
                    string path = "";
                    switch (level)
                    {
                        case 0:
                            return;
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
                        throw new FileNotFoundException("ファイルが見つかりませんでした。", path);
                    ExeLog($"[Sound_Play][{dataAuthor}]音声再生開始({path})");
                    if (player != null)
                    {
                        player.Stop();
                        player.Dispose();
                        player = null;
                    }
                    player = new SoundPlayer(path);
                    player.Play();
                    ExeLog($"[Sound_Play][{dataAuthor}]音声再生成功");
                }
                catch (Exception ex)
                {
                    ExeLog($"[Sound_Play][{dataAuthor}]エラー:{ex.Message}", true);
                    LogSave(ex);
                }
        }

        /// <summary>
        /// 棒読みちゃんに読み上げ指令を送ります。
        /// </summary>
        /// <remarks>事前に有効確認が必要です。</remarks>
        /// <param name="text">読み上げさせる文</param>
        /// <param name="dataAuthor">データ元</param>
        public static void Bouyomichan(string text, DataAuthor dataAuthor)
        {
            try
            {
                Console.WriteLine("棒読みちゃん処理開始");
                Data_.Bouyomi_ config_bouyomi = config.Datas[(int)dataAuthor].Bouyomi;
                byte[] message = Encoding.UTF8.GetBytes(text);
                ExeLog($"[Bouyomichan][{dataAuthor}]棒読みちゃん送信中...");
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
                ExeLog($"[Bouyomichan][{dataAuthor}]棒読みちゃん送信成功");
            }
            catch (Exception ex)
            {
                ExeLog($"[Bouyomichan][{dataAuthor}]エラー:{ex.Message}", true);
                LogSave(ex);
            }
        }

        /// <summary>
        /// Socket通信で送信します。
        /// </summary>
        /// <remarks>事前に有効確認が必要です。</remarks>
        /// <param name="text">送信する文</param>
        /// <param name="dataAuthor">データ元</param>
        public static async void Socket(string text, DataAuthor dataAuthor)
        {
            try
            {
                Console.WriteLine("Socket処理開始");
                Data_.Socket_ config_socket = config.Datas[(int)dataAuthor].Socket;
                byte[] message = new byte[4096];
                message = Encoding.UTF8.GetBytes(text);
                ExeLog($"[Socket][{dataAuthor}]Socket送信中…");
                using (TcpClient tcpClient = new TcpClient(config_socket.Host, config_socket.Port))
                using (NetworkStream networkStream = tcpClient.GetStream())
                    await networkStream.WriteAsync(message, 0, message.Length);
                ExeLog($"[Socket][{dataAuthor}]Socket送信成功");
            }
            catch (Exception ex)
            {
                ExeLog($"[Socket][{dataAuthor}]エラー:{ex.Message}", true);
                LogSave(ex);
            }
        }

        /// <summary>
        /// Webhookを送信します。
        /// </summary>
        /// <remarks>事前に有効確認が必要です。</remarks>
        /// <param name="text">送信する文</param>
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
                ExeLog($"[Webhook][{dataAuthor}]Webhook送信中…");
                await client.PostAsync(config_webhook.URL, new FormUrlEncodedContent(strs));
                ExeLog($"[Webhook][{dataAuthor}]Webhook送信成功");
            }
            catch (Exception ex)
            {
                ExeLog($"[Webhook][{dataAuthor}]エラー:{ex.Message}", true);
                LogSave(ex);
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
                LogSave(ex);
            }
        }

        /// <summary>
        /// 画像ファイルがない場合リソースからコピーします。
        /// </summary>
        /// <remarks>Image\\からの相対パス。</remarks>
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

        /// <summary>
        /// データ表示Formを再描画します。データ元と表示データが異なる場合はしません。
        /// </summary>
        /// <param name="dataAuthor">データ元</param>
        public static void ReDraw(DataAuthor dataAuthor)
        {
            for (int i = 0; i < dataViews.Length - 1; i++)
                if (dataViews[i] != null)
                    if (dataViews[i].dataAuthorN == (int)dataAuthor || dataViews[i].dataAuthorN == 9)
                        dataViews[i].Draw();
        }

        /// <summary>
        /// メッセージボックスを表示し、応答を返します。タイトル文字は"確認"
        /// </summary>
        /// <param name="text">表示する文字</param>
        /// <param name="icon">表示するアイコン(既定はMessageBoxIcon.Information)</param>
        /// <returns>OKが押された場合true</returns>
        public static bool DialogOK(string text, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            return DialogOK(text, "確認", icon);
        }

        /// <summary>
        /// メッセージボックスを表示し、応答を返します。
        /// </summary>
        /// <param name="text">表示する文字</param>
        /// <param name="title">タイトル文字</param>
        /// <param name="icon">表示するアイコン(既定はMessageBoxIcon.Information)</param>
        /// <returns>OKが押された場合true</returns>
        public static bool DialogOK(string text, string title, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            DialogResult ok = MessageBox.Show(topMost, text, title, MessageBoxButtons.OKCancel, icon);
            return ok == DialogResult.OK;
        }
    }
}

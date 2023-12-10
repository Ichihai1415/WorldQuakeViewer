using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using static WorldQuakeViewer.CtrlForm;
using static WorldQuakeViewer.Util_Class;
using static WorldQuakeViewer.Util_Func;

namespace WorldQuakeViewer
{
    public static class DataPro
    {
        /// <summary>
        /// 取得します。
        /// </summary>
        /// <param name="dataAuthor">データ元</param>
        /// <exception cref="ArgumentException">データ元が不正な場合</exception>
        public static async void Get(DataAuthor dataAuthor)
        {
            try
            {
                ExeLog($"[Get]取得準備中...");
                Dictionary<string, Data> data_tmp = new Dictionary<string, Data>();
                switch (dataAuthor)
                {
                    case DataAuthor.Other:
                        data_tmp = data_Other;
                        break;
                    case DataAuthor.USGS:
                        data_tmp = data_USGS;
                        break;
                    case DataAuthor.EMSC:
                        data_tmp = data_EMSC;
                        break;
                    case DataAuthor.GFZ:
                        data_tmp = data_GFZ;
                        break;
                    case DataAuthor.EarlyEst:
                        data_tmp = data_EarlyEst;
                        break;
                    default:
                        throw new ArgumentException("データ元が不正です。", dataAuthor.ToString());
                }
                string URL = config.Datas[(int)dataAuthor].URL;
                ExeLog($"[Get]取得中...({dataAuthor},{URL})");
                string res = await client.GetStringAsync(URL);

                if (URL.Contains("text"))
                    Get_Text(URL, data_tmp, dataAuthor);
            }
            catch(WebException ex)
            {
                ExeLog($"[Get]エラー:{ex.Message}", true);
            }
            catch(HttpRequestException ex)
            {
                ExeLog($"[Get]エラー:{ex.Message}", true);
            }
            catch (Exception ex)
            {
                ExeLog($"[Get]エラー:{ex.Message}", true);
                LogSave(LogKind.Error, ex.ToString());
            }
        }

        /// <summary>
        /// テキスト形式のデータを処理します。
        /// </summary>
        /// <param name="res">レスポンス本文</param>
        /// <param name="data_tmp">データリスト(参照したものを渡す)</param>
        /// <param name="dataAuthor">データ元</param>
        public static void Get_Text(string res, Dictionary<string, Data> data_tmp,DataAuthor dataAuthor)
        {
            try
            {
                ExeLog($"[Get_Text]処理中...");
                Config.Data_ config_data = config.Datas[(int)dataAuthor];
                string[] datas = res.Split('\n').Skip(1).ToArray();
                foreach (string data_ in datas)
                {
                    if (data_ == "")
                        continue;
                    Console.WriteLine(data_);
                    Data data = (Data)data_.Split('|');
                    data.Author = dataAuthor;
                    if (DateTime.Now - data.Time > config_data.Update.MaxPeriod)
                    {
                        ExeLog($"[Get_Text]更新確認対象外です。");
                        continue;
                    }
                    if (data_tmp.ContainsKey(data.ID))
                    {
                        bool update = UpdateCheck(data_tmp[data.ID], data, dataAuthor);
                        if (update)
                        {
                            ExeLog($"[Get_Text]更新を検知");
                            data_tmp[data.ID] = data;
                            data_All[data.ID] = data;
                            UpdtPros(data);
                        }
                    }
                    else
                    {
                        ExeLog($"[Get_Text]新規を検知");
                        data_tmp[data.ID] = data;
                        data_All[data.ID] = data;
                        UpdtPros(data, true);
                    }
                }
                ExeLog($"[Get_Text]処理終了");
            }
            catch (Exception ex)
            {
                ExeLog($"[Get_Text]エラー:{ex.Message}", true);
                LogSave(LogKind.Error, ex.ToString());
            }
        }

        /// <summary>
        /// QuakeML形式のデータを処理します。
        /// </summary>
        /// <param name="res">レスポンス本文</param>
        /// <param name="data_tmp">データリスト(参照したものを渡す)</param>
        /// <param name="dataAuthor">データ元</param>
        public static void Get_QuakeML(string res, Dictionary<string, Data> data_tmp, DataAuthor dataAuthor)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
        public static void Get(DataAuthor dataAuthor)
        {
            ExeLog($"[Get]取得準備中...");
            if (dataAuthor == DataAuthor.Null)
                throw new ArgumentException("データ元が不正です。", dataAuthor.ToString());
            string URL = config.Datas[(int)dataAuthor].URL;
            if (URL.Contains("text"))
                Get_Text(URL, dataAuthor);
        }

        public static async void Get_Text(string URL, DataAuthor dataAuthor)
        {
            try
            {
                Dictionary<string, Data> data_tmp = new Dictionary<string, Data>();
                Config.Data_ config_data = config.Datas[(int)dataAuthor];
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
                ExeLog($"[Get_Text]取得中...({dataAuthor},{URL})");
                string res = await client.GetStringAsync(URL);
                ExeLog($"[Get_Text]処理中...");
                string[] datas = res.Split('\n').Skip(1).ToArray();
                foreach (string data_ in datas)
                {
                    if (data_ == "")
                        continue;
                    Console.WriteLine(data_);
                    Data_Text data_text = (Data_Text)data_.Split('|');
                    Data data = (Data)data_text;
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
    }
}

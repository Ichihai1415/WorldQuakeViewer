using System;
using System.Collections.Generic;
using System.Linq;
using static WorldQuakeViewer.CtrlForm;
using static WorldQuakeViewer.Util_Class;
using static WorldQuakeViewer.Util_Func;

namespace WorldQuakeViewer.Util
{
    public static class DataPro
    {

        public static async void Get(DataAuthor dataAuthor)
        {
            if ((int)dataAuthor == -1)
                throw new ArgumentException($"引数が不正です。({dataAuthor})");
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

                string res = await client.GetStringAsync(URL);
                string[] datas = res.Split('\n').Skip(1).ToArray();
                foreach (string data_ in datas)
                {
                    Data_Text data_text = (Data_Text)data_.Split('|');
                    Data data = (Data)data_text;

                    if (DateTime.Now - data.Time > config_data.Update.MaxPeriod)
                    {

                        continue;
                    }
                    if (data_tmp.ContainsKey(data.ID))
                    {
                        bool update = UpdateCheck(data_tmp[data.ID], data, dataAuthor);
                        if (update)
                        {
                            data_tmp[data.ID] = data;
                            data_All[data.ID] = data;
                            UpdtPros(data);
                        }
                    }
                    else
                    {
                        data_tmp[data.ID] = data;
                        data_All[data.ID] = data;
                        UpdtPros(data, true);
                    }
                }



            }
            catch (Exception ex)
            {

            }
        }
    }
}

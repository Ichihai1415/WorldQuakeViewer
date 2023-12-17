﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml;
using static WorldQuakeViewer.CtrlForm;
using static WorldQuakeViewer.Util_Class;
using static WorldQuakeViewer.Util_Conv;
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
                ExeLog($"[Get]取得準備中...({dataAuthor})");
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
                        throw new ArgumentException($"データ元({dataAuthor})が不正です。", nameof(dataAuthor));
                }
                string URL = config.Datas[(int)dataAuthor].URL;
                string URLbasic = URL.Split('?')[0];
                ExeLog($"[Get]取得中...({dataAuthor},{URL})");
                string res = await client.GetStringAsync(URL);
                switch (config.Datas[(int)dataAuthor].DataProType)
                {
                    case DataProType.Text:
                        Get_Text(res, data_tmp, dataAuthor);
                        break;
                    case DataProType.QuakeML:
                        Get_QuakeML(res, data_tmp, dataAuthor);
                        break;
                    case DataProType.GeoJSON:
                        break;
                    case DataProType.Auto:
                        if (res.StartsWith("#"))
                            Get_Text(res, data_tmp, dataAuthor);
                        else if (res.StartsWith("<"))
                            Get_QuakeML(res, data_tmp, dataAuthor);
                        else if (res.StartsWith("{"))
                            Get_GeoJSON(res, data_tmp, dataAuthor);
                        else
                            throw new Exception("データ処理の自動判断に失敗しました。");
                        break;
                }
                ReDraw();
            }
            catch (HttpRequestException ex)
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
        public static void Get_Text(string res, Dictionary<string, Data> data_tmp, DataAuthor dataAuthor)
        {

            ExeLog($"[Get_Text]処理中...");
            Config.Data_ config_data = config.Datas[(int)dataAuthor];
            string[] datas = res.Split('\n').Skip(1).ToArray();
            foreach (string data_ in datas.Reverse())
            {
                try
                {
                    if (data_ == "")
                        continue;
                    Console.WriteLine(data_);
                    Data data = Text2Data(data_.Split('|'), dataAuthor);
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
                catch (Exception ex)
                {
                    ExeLog($"[Get_Text]エラー:{ex.Message}", true);
                    LogSave(LogKind.Error, ex.ToString());
                }
            }
            ExeLog($"[Get_Text]処理終了");

        }

        /// <summary>
        /// QuakeML形式のデータを処理します。
        /// </summary>
        /// <param name="res">レスポンス本文</param>
        /// <param name="data_tmp">データリスト(参照したものを渡す)</param>
        /// <param name="dataAuthor">データ元</param>
        public static void Get_QuakeML(string res, Dictionary<string, Data> data_tmp, DataAuthor dataAuthor)
        {
            ExeLog($"[Get_QuakeML]処理中...");
            Config.Data_ config_data = config.Datas[(int)dataAuthor];
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(res);
            XmlNamespaceManager ns = new XmlNamespaceManager(xml.NameTable);
            ns.AddNamespace("qml", "http://quakeml.org/xmlns/bed/1.2");
            ns.AddNamespace("q", "http://quakeml.org/xmlns/quakeml/1.2");
            ns.AddNamespace("qrt", "http://quakeml.org/xmlns/quakeml-rt/1.2");
            ns.AddNamespace("ee", "http://net.alomax/earlyest/xmlns/ee");
            ns.AddNamespace("anss", "http://anss.org/xmlns/event/0.1");
            ns.AddNamespace("catalog", "http://anss.org/xmlns/catalog/0.1");
            foreach (XmlNode info in xml.SelectNodes("q:quakeml/qml:eventParameters/qml:event", ns).Cast<XmlNode>().Reverse())
            {
                try
                {
                    Data data = QuakeML2Data(info, ns, dataAuthor);
                    if (dataAuthor == DataAuthor.EMSC && config.Other.EMSCqmlIDConv)
                        if (data_tmp.ContainsKey(data.ID))
                        {
                            if (data_tmp[data.ID].ID2 == "")
                                data.ID2 = IDconvert(data.ID, IDauthor.UNID, IDauthor.EMSC);
                        }
                        else
                            data.ID2 = IDconvert(data.ID, IDauthor.UNID, IDauthor.EMSC);

                    if (DateTime.Now - data.Time > config_data.Update.MaxPeriod)
                    {
                        ExeLog($"[Get_QuakeML]更新確認対象外です。");
                        continue;
                    }
                    if (data_tmp.ContainsKey(data.ID))
                    {
                        bool update = UpdateCheck(data_tmp[data.ID], data, dataAuthor);
                        if (update)
                        {
                            ExeLog($"[Get_QuakeML]更新を検知");
                            data_tmp[data.ID] = data;
                            data_All[data.ID] = data;
                            UpdtPros(data);
                        }
                    }
                    else
                    {
                        ExeLog($"[Get_QuakeML]新規を検知");
                        data_tmp[data.ID] = data;
                        data_All[data.ID] = data;
                        UpdtPros(data, true);
                    }
                }
                catch (Exception ex)
                {
                    ExeLog($"[Get_QuakeML]エラー:{ex.Message}", true);
                    LogSave(LogKind.Error, ex.ToString());
                }
            }
            ExeLog($"[Get_QuakeML]処理終了");
        }

        /// <summary>
        /// GeoJSON形式のデータを処理します。
        /// </summary>
        /// <param name="res">レスポンス本文</param>
        /// <param name="data_tmp">データリスト(参照したものを渡す)</param>
        /// <param name="dataAuthor">データ元</param>
        public static void Get_GeoJSON(string res, Dictionary<string, Data> data_tmp, DataAuthor dataAuthor)
        {
            ExeLog($"[Get_GeoJSON]処理中...");
            Config.Data_ config_data = config.Datas[(int)dataAuthor];
            JObject json = JObject.Parse(res);
            foreach (JToken info in json.SelectToken("features").Reverse())
            {
                try
                {
                    if (dataAuthor == DataAuthor.USGS)
                    {
                        string id_n = (string)info.SelectToken("id");//情報でのid
                        foreach (string id in ((string)info.SelectToken("properties.ids")).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (id == id_n)//同じならそのまま
                                continue;
                            if (data_tmp.ContainsKey(id))//すでにある(統合が必要)
                                USGSgeojsonIDCorrect(id, id_n);
                        }
                    }
                    Data data = GeoJSON2Data(info, dataAuthor);
                    if (DateTime.Now - data.Time > config_data.Update.MaxPeriod)
                    {
                        ExeLog($"[Get_GeoJSON]更新確認対象外です。");
                        continue;
                    }
                    if (data_tmp.ContainsKey(data.ID))
                    {
                        bool update = UpdateCheck(data_tmp[data.ID], data, dataAuthor);
                        if (update)
                        {
                            ExeLog($"[Get_GeoJSON]更新を検知");
                            data_tmp[data.ID] = data;
                            data_All[data.ID] = data;
                            UpdtPros(data);
                        }
                    }
                    else
                    {
                        ExeLog($"[Get_GeoJSON]新規を検知");
                        data_tmp[data.ID] = data;
                        data_All[data.ID] = data;
                        UpdtPros(data, true);
                    }
                }
                catch (Exception ex)
                {
                    ExeLog($"[Get_GeoJSON]エラー:{ex.Message}", true);
                    LogSave(LogKind.Error, ex.ToString());
                }
            }
            ExeLog($"[Get_GeoJSON]処理終了");
        }
    }
}

using System;
using System.Collections.Generic;

namespace WorldQuakeViewer
{
    /// <summary>
    /// 色々(クラス類)
    /// </summary>
    public class Util_Class
    {
        /// <summary>
        /// データ元判別用(USGS/EMSC/EarlyEst)
        /// </summary>
        public enum DataAuthor
        {
            Null = 0,
            USGS = 1,
            EMSC = 2,
            EarlyEst = 3,
            GFZ = 4
        };

        /// <summary>
        /// 表示データ元判別用
        /// </summary>
        public enum ViewData
        {
            Null = 0,
            USGS_Latest = 11,
            USGS_History = 12,
            USGS_LatestHistory = 13,
            EMSC_Latest = 21,
            EMSC_History = 22,
            EMSC_LatestHistory = 23,
            EarlyEst_Latest = 31,
            EarlyEst_History = 32,
            EarlyEst_LatestHistory = 33,
            GFZ_Latest = 41,
            GFZ_History = 42,
            GFZ_LatestHistory = 43,
            All_Latest = 91,
            All_History = 92,
            All_LatestHistory = 93
        };

        /// <summary>
        /// 履歴保存用クラス
        /// </summary>
        public class History
        {
            /// <summary>
            /// データ元(USGS/EMSC/EarlyEst)
            /// </summary>
            public DataAuthor Author { get; set; }
            /// <summary>
            /// 地震ID(データ元間で互換性なし)
            /// </summary>
            public string ID { get; set; }
            /// <summary>
            /// 更新時刻
            /// </summary>
            public DateTimeOffset Update { get; set; }
            /// <summary>
            /// 詳細ページのURL
            /// </summary>
            public string URL { get; set; }

            /// <summary>
            /// 発生時刻
            /// </summary>
            public DateTimeOffset Time { get; set; }
            /// <summary>
            /// 日本語震源名
            /// </summary>
            public string HypoJP { get; set; }
            /// <summary>
            /// 英語震源名
            /// </summary>
            public string HypoEN { get; set; }
            /// <summary>
            /// 緯度
            /// </summary>
            public double Lat { get; set; }
            /// <summary>
            /// 経度
            /// </summary>
            public double Lon { get; set; }
            /// <summary>
            /// 深さ
            /// </summary>
            public double Depth { get; set; }
            /// <summary>
            /// マグニチュードのリスト[magType, mag]
            /// </summary>
            public Dictionary<string, double> Mags { get; set; }

            /// <summary>
            /// [USGS用]MMI
            /// </summary>
            public double? MMI { get; set; }
            /// <summary>
            /// [USGS用]アラート
            /// </summary>
            public string Alert { get; set; }
            /// <summary>
            /// [EMSC用]データのソース
            /// </summary>
            public string Source { get; set; }
        }

        /// <summary>
        /// 過去のクラス
        /// </summary>
        public class History_
        {
            public string URL { get; set; }
            public long Update { get; set; }
            public string ID { get; set; }
            public long TweetID { get; set; }

            //表示用
            public string Display1 { get; set; }
            public string Display2 { get; set; }
            public string Display3 { get; set; }

            //更新検知用
            public long Time { get; set; }
            public string HypoJP { get; set; }
            public string HypoEN { get; set; }
            public double Lat { get; set; }
            public double Lon { get; set; }
            public double Depth { get; set; }
            public string MagType { get; set; }
            public double Mag { get; set; }
            public double? MMI { get; set; }
            public string Alert { get; set; }
        }
    }
}
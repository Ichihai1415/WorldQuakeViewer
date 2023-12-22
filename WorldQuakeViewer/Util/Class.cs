using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WorldQuakeViewer
{
    /// <summary>
    /// 色々(クラス類)
    /// </summary>
    public class Util_Class
    {
        /// <summary>
        /// プログラムのバージョン
        /// </summary>
        public static readonly string version = "1.2.0";

        /// <summary>
        /// ダイアログ等を最前面に表示する用
        /// </summary>
        public static Form topMost = new Form { TopMost = true };

        /// <summary>
        /// 文字描画用フォント
        /// </summary>
        public static FontFamily font;

        /// <summary>
        /// 震央マーク用色置換
        /// </summary>
        public static ImageAttributes ia = new ImageAttributes();

        /// <summary>
        /// データ元
        /// </summary>
        public enum DataAuthor
        {
            /// <summary>
            /// 仮用
            /// </summary>
            Null = -1,
            /// <summary>
            /// 他(ユーザー指定)
            /// </summary>
            Other = 0,
            /// <summary>
            /// USGS
            /// </summary>
            USGS = 1,
            /// <summary>
            /// EMSC
            /// </summary>
            EMSC = 2,
            /// <summary>
            /// GFZ
            /// </summary>
            GFZ = 3,
            /// <summary>
            /// Early-est
            /// </summary>
            EarlyEst = 4
        };

        /// <summary>
        /// データ元の個数(null除く)
        /// </summary>
        public static readonly int DataAuthorCount = Enum.GetValues(typeof(DataAuthor)).Length - 1;

        /// <summary>
        /// データ元別既定のURL
        /// </summary>
        public static Dictionary<DataAuthor, string> DataDefURL = new Dictionary<DataAuthor, string>
        {
            { DataAuthor.Null, "" },
            { DataAuthor.Other, "" },
            { DataAuthor.USGS, "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/4.5_week.geojson" },
            { DataAuthor.EMSC, "https://www.seismicportal.eu/fdsnws/event/1/query?format=text&minmag=5.0&limit=10" },
            { DataAuthor.GFZ, "https://geofon.gfz-potsdam.de/fdsnws/event/1/query?format=text&minmag=5.0&limit=10&end=2100-01-01" },
            { DataAuthor.EarlyEst, "http://early-est.rm.ingv.it/monitor.xml" },
        };

        /// <summary>
        /// 表示データ元判別用
        /// </summary>
        public enum ViewData
        {
            /// <summary>
            /// 仮用
            /// </summary>
            Null = -1,
            /// <summary>
            /// 他(ユーザー指定)の最新とマップ
            /// </summary>
            Other_Latest = 01,
            /// <summary>
            /// 他(ユーザー指定)の履歴
            /// </summary>
            Other_History = 02,
            /// <summary>
            /// 他(ユーザー指定)の最新とマップと履歴
            /// </summary>
            Other_LatestHistory = 03,
            /// <summary>
            /// USGSのの最新とマップ
            /// </summary>
            USGS_Latest = 11,
            /// <summary>
            /// USGSの履歴
            /// </summary>
            USGS_History = 12,
            /// <summary>
            /// USGSの最新とマップと履歴
            /// </summary>
            USGS_LatestHistory = 13,
            /// <summary>
            /// EMSCの最新とマップ
            /// </summary>
            EMSC_Latest = 21,
            /// <summary>
            /// EMSCの履歴
            /// </summary>
            EMSC_History = 22,
            /// <summary>
            /// EMSCの最新とマップと履歴
            /// </summary>
            EMSC_LatestHistory = 23,
            /// <summary>
            /// GFZの最新とマップ
            /// </summary>
            GFZ_Latest = 31,
            /// <summary>
            /// GFZの履歴
            /// </summary>
            GFZ_History = 32,
            /// <summary>
            /// GFZの最新とマップと履歴
            /// </summary>
            GFZ_LatestHistory = 33,
            /// <summary>
            /// Early-estの最新とマップ
            /// </summary>
            EarlyEst_Latest = 41,
            /// <summary>
            /// Early-estの履歴
            /// </summary>
            EarlyEst_History = 42,
            /// <summary>
            /// Early-estの最新とマップと履歴
            /// </summary>
            EarlyEst_LatestHistory = 43,
            /// <summary>
            /// すべての最新とマップ
            /// </summary>
            All_Latest = 91,
            /// <summary>
            /// すべての履歴
            /// </summary>
            All_History = 92,
            /// <summary>
            /// すべての最新とマップと履歴
            /// </summary>
            All_LatestHistory = 93,
            /// <summary>
            /// すべての最新1つずつ
            /// </summary>
            All_LatestMulti = 94
        };

        /// <summary>
        /// ログの種類
        /// </summary>
        /// <remarks>地震ログはDataAuthor+10となるように</remarks>
        public enum LogKind
        {
            /// <summary>
            /// 実行ログ
            /// </summary>
            Exe = 1,
            /// <summary>
            /// エラーログ
            /// </summary>
            Error = 2,
            /// <summary>
            /// 地震ログ(他(ユーザー指定))
            /// </summary>
            Other = 10,
            /// <summary>
            /// 地震ログ(USGS)
            /// </summary>
            USGS = 11,
            /// <summary>
            /// 地震ログ(EMSC)
            /// </summary>
            EMSC = 12,
            /// <summary>
            /// 地震ログ(GFZ)
            /// </summary>
            GFZ = 13,
            /// <summary>
            /// 地震ログ(Early-est)
            /// </summary>
            EarlyEst = 14
        }

        /// <summary>
        /// フォーマット置換処理名
        /// </summary>
        public enum FormatPros
        {
            /// <summary>
            /// データ表示
            /// </summary>
            View = 0,
            /// <summary>
            /// 棒読みちゃん送信
            /// </summary>
            Bouyomichan = 2,
            /// <summary>
            /// Socket送信
            /// </summary>
            Socket = 3,
            /// <summary>
            /// Webhook送信
            /// </summary>
            Webhook = 4,
            /// <summary>
            /// 地震ログ保存
            /// </summary>
            LogE = 5
        }

        /// <summary>
        /// データの種類
        /// </summary>
        public enum DataProType
        {
            /// <summary>
            /// 自動判別
            /// </summary>
            Auto = 0,
            /// <summary>
            /// テキスト形式
            /// </summary>
            Text = 1,
            /// <summary>
            /// QuakeML形式
            /// </summary>
            QuakeML = 2,
            /// <summary>
            /// GeoJSON形式
            /// </summary>
            GeoJSON = 3
        }

        /// <summary>
        /// ID元(seismicportalのEventID用)
        /// </summary>
        public enum IDauthor
        {
            /// <summary>
            /// UNID
            /// </summary>
            UNID = 0,
            /// <summary>
            /// EMSC
            /// </summary>
            EMSC = 1,
            /// <summary>
            /// INGV
            /// </summary>
            INGV = 2,
            /// <summary>
            /// USGS
            /// </summary>
            USGS = 3,
            /// <summary>
            /// ISC
            /// </summary>
            ISC = 4
        }

        /// <summary>
        /// フォーマット指定の置換用
        /// </summary>
        public class FormatReplaces
        {
            /// <summary>
            /// 地震D
            /// </summary>
            public string ID { get; set; } = "";

            /// <summary>
            /// 発生日時(UTC・年)
            /// </summary>
            public string TimeUTC_Year { get; set; } = "";

            /// <summary>
            /// 発生日時(UTC・月)
            /// </summary>
            public string TimeUTC_Month { get; set; } = "";

            /// <summary>
            /// 発生日時(UTC・日)
            /// </summary>
            public string TimeUTC_Day { get; set; } = "";

            /// <summary>
            /// 発生日時(UTC・時)
            /// </summary>
            public string TimeUTC_Hour { get; set; } = "";

            /// <summary>
            /// 発生日時(UTC・分)
            /// </summary>
            public string TimeUTC_Minute { get; set; } = "";

            /// <summary>
            /// 発生日時(UTC・秒)
            /// </summary>
            public string TimeUTC_Second { get; set; } = "";

            /// <summary>
            /// 発生日時(ユーザー・年)
            /// </summary>
            public string TimeUser_Year { get; set; } = "";

            /// <summary>
            /// 発生日時(ユーザー・月)
            /// </summary>
            public string TimeUser_Month { get; set; } = "";

            /// <summary>
            /// 発生日時(ユーザー・日)
            /// </summary>
            public string TimeUser_Day { get; set; } = "";

            /// <summary>
            /// 発生日時(ユーザー・時)
            /// </summary>
            public string TimeUser_Hour { get; set; } = "";

            /// <summary>
            /// 発生日時(ユーザー・分)
            /// </summary>
            public string TimeUser_Minute { get; set; } = "";

            /// <summary>
            /// 発生日時(ユーザー・秒)
            /// </summary>
            public string TimeUser_Second { get; set; } = "";

            /// <summary>
            /// UTCとユーザータイムゾーンの差
            /// </summary>
            public string TimeUser_Off { get; set; } = "";

            /// <summary>
            /// 震源名(日本語)
            /// </summary>
            public string HypoJP { get; set; } = "";

            /// <summary>
            /// 震源名(英語)
            /// </summary>
            public string HypoEN { get; set; } = "";

            /// <summary>
            /// 緯度(十進数)
            /// </summary>
            public string Lat10 { get; set; } = "";

            /// <summary>
            /// NまたはS
            /// </summary>
            public string LatNS { get; set; } = "";

            /// <summary>
            /// 北緯または南緯
            /// </summary>
            public string LatNSJP { get; set; } = "";

            /// <summary>
            /// 緯度(六十進数・度)
            /// </summary>
            public string Lat60d { get; set; } = "";

            /// <summary>
            /// 緯度(六十進数・分)
            /// </summary>
            public string Lat60m { get; set; } = "";

            /// <summary>
            /// 緯度(六十進数・秒)
            /// </summary>
            public string Lat60s { get; set; } = "";

            /// <summary>
            /// 経度(十進数)
            /// </summary>
            public string Lon10 { get; set; } = "";

            /// <summary>
            /// EまたはW
            /// </summary>
            public string LonEW { get; set; } = "";

            /// <summary>
            /// 東経または西経
            /// </summary>
            public string LonEWJP { get; set; } = "";

            /// <summary>
            /// 経度(六十進数・度)
            /// </summary>
            public string Lon60d { get; set; } = "";

            /// <summary>
            /// 経度(六十進数・分)
            /// </summary>
            public string Lon60m { get; set; } = "";

            /// <summary>
            /// 経度(六十進数・秒)
            /// </summary>
            public string Lon60s { get; set; } = "";

            /// <summary>
            /// 深さ
            /// </summary>
            public string Depth { get; set; } = "";

            /// <summary>
            /// マグニチュードの種類
            /// </summary>
            public string MagType { get; set; } = "";

            /// <summary>
            /// マグニチュード
            /// </summary>
            public string Mag { get; set; } = "";

            /// <summary>
            /// [USGSのみ]改正メルカリ震度階級
            /// </summary>
            public string MMI { get; set; } = "";

            /// <summary>
            /// [USGSのみ]改正メルカリ震度階級(アラビア数字)
            /// </summary>
            public string MMIAra { get; set; } = "";

            /// <summary>
            /// [USGSのみ]アラート(日本語)
            /// </summary>
            public string AlertJP { get; set; } = "";

            /// <summary>
            /// [USGSのみ]アラート(英語)
            /// </summary>
            public string AlertEN { get; set; } = "";

            /// <summary>
            /// [一部]データ元
            /// </summary>
            public string Source { get; set; } = "";

            /// <summary>
            /// 更新時に「更新」
            /// </summary>
            public string UpdateJP { get; set; } = "";

            /// <summary>
            /// 更新時に「update」
            /// </summary>
            public string UpdateEN { get; set; } = "";
        };

        /// <summary>
        /// 履歴保存用クラス
        /// </summary>
        /// <remarks>既定はstring:"",double:-999,double?:null,DateTimeOffset:MinValue,DataAuthor:Null</remarks>
        public class Data
        {
            /// <summary>
            /// データ元(USGS/EMSC/EarlyEst)
            /// </summary>
            public DataAuthor Author { get; set; } = DataAuthor.Null;

            /// <summary>
            /// 地震ID(データ元間で互換性なし)
            /// </summary>
            public string ID { get; set; } = "";

            /// <summary>
            /// 地震ID(データ元間で互換性なし)(webに飛べるID)
            /// </summary>
            public string ID2 { get; set; } = "";

            /// <summary>
            /// 発生時刻
            /// </summary>
            public DateTimeOffset Time { get; set; } = DateTimeOffset.MinValue;

            /// <summary>
            /// 更新時刻
            /// </summary>
            public DateTimeOffset UpdtTime { get; set; } = DateTimeOffset.MinValue;

            /// <summary>
            /// 震源名
            /// </summary>
            /// <remarks>基本的に震源名更新用</remarks>
            public string Hypo { get; set; } = "";

            /// <summary>
            /// 緯度
            /// </summary>
            public double Lat { get; set; } = -999;

            /// <summary>
            /// 経度
            /// </summary>
            public double Lon { get; set; } = -999;

            /// <summary>
            /// 深さ
            /// </summary>
            public double Depth { get; set; } = -999;

            /// <summary>
            /// マグニチュードの種類
            /// </summary>
            public string MagType { get; set; } = "";

            /// <summary>
            /// マグニチュード
            /// </summary>
            public double Mag { get; set; } = -999;

            /// <summary>
            /// [USGSのみ]MMI
            /// </summary>
            public double? MMI { get; set; } = null;

            /// <summary>
            /// [USGSのみ]アラート
            /// </summary>
            public string Alert { get; set; } = "";

            /// <summary>
            /// [一部のみ]データのソース
            /// </summary>
            public string Source { get; set; } = "";
        }
    }
}
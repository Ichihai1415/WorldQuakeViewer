using System;
using System.Drawing;
using static LL2FERC.LL2FERC;
using static WorldQuakeViewer.CtrlForm;
using static WorldQuakeViewer.Util_Class;

namespace WorldQuakeViewer
{
    /// <summary>
    /// 色々
    /// </summary>
    public class Util_Conv
    {
        /// <summary>
        /// マグニチュードからレベルに変換します。
        /// </summary>
        /// <param name="mag">マグニチュード</param>
        /// <returns>レベル(<M4.5<M6.0<M7.0<M8.0<)</returns>
        public static int Mag2Level(double mag)
        {
            if (mag < 4.5)
                return 1;
            else if (mag < 6.0)
                return 2;
            else if (mag < 7.0)
                return 3;
            else if (mag < 8.0)
                return 4;
            else
                return 5;
        }

        /// <summary>
        /// データから各処理の文字列に変換します。
        /// </summary>
        /// <param name="data">データ</param>
        /// <param name="updatePros">更新処理の名前</param>
        /// <returns>各処理の文字列</returns>
        public static string Data2ProString(Data data, UpdatePros updatePros)
        {
            string format;
            switch (updatePros)
            {
                case UpdatePros.Bouyomichan:
                    format = config.Datas[(int)data.Author].Bouyomi.Format;
                    break;
                case UpdatePros.Socket:
                    format = config.Datas[(int)data.Author].Socket.Format;
                    break;
                case UpdatePros.Webhook:
                    format = config.Datas[(int)data.Author].Webhook.Format;
                    break;
                default:
                    format = "";
                    break;
            }//.Replace("{}",)
            DateTimeOffset timeUser = data.Time.ToLocalTime();
            Lat2String(data.Lat, out string lat10, out string latNS, out string latNSJP, out string lat60d, out string lat60m, out string lat60s);
            Lon2String(data.Lon, out string lon10, out string lonEW, out string lonEWJP, out string lon60d, out string lon60m, out string lon60s);
            FormatReplaces f = new FormatReplaces
            {
                ID = data.ID,
                TimeUTC_Year = data.Time.Year.ToString(),
                TimeUTC_Month = data.Time.Month.ToString(),
                TimeUTC_Day = data.Time.Day.ToString(),
                TimeUTC_Hour = data.Time.Hour.ToString(),
                TimeUTC_Minute = data.Time.Minute.ToString(),
                TimeUTC_Second = data.Time.Second.ToString(),
                TimeUser_Year = timeUser.Year.ToString(),
                TimeUser_Month = timeUser.Month.ToString(),
                TimeUser_Day = timeUser.Day.ToString(),
                TimeUser_Hour = timeUser.Hour.ToString(),
                TimeUser_Minute = timeUser.Minute.ToString(),
                TimeUser_Second = timeUser.Second.ToString(),
                TimeUser_Off = timeUser.Offset.ToString(),
                HypoJP = NameJP(data.Lat, data.Lon),
                HypoEN = NameEN(data.Lat, data.Lon),
                Lat10 = lat10,
                LatNS = latNS,
                LatNSJP = latNSJP,
                Lat60d = lat60d,
                Lat60m = lat60m,
                Lat60s = lat60s,
                Lon10 = lon10,
                LonEW = lonEW,
                LonEWJP = lonEWJP,
                Lon60d = lon60d,
                Lon60m = lon60m,
                Lon60s = lon60s,
                Depth = data.Depth.ToString(),
                MagType = data.MagType,
                Mag = data.Mag.ToString(),
                MMI = data.MMI.ToString(),
                MMIAra = MMI2Ara(data.MMI),
                AlertJP = Alert2JP(data.Alert),
                AlertEN = data.Alert,
                Source = data.Source
            };
            //.Replace("[]",f.)
            return format
                .Replace("[ID]", f.ID)
                .Replace("[TimeUTC_Year]", f.TimeUTC_Year).Replace("[TimeUTC_Month]", f.TimeUTC_Month).Replace("[TimeUTC_Day]", f.TimeUTC_Day)
                .Replace("[TimeUTC_Hour]", f.TimeUTC_Hour).Replace("[TimeUTC_Minute]", f.TimeUTC_Minute).Replace("[TimeUTC_Second]", f.TimeUTC_Second)
                .Replace("[TimeUser_Year]", f.TimeUser_Year).Replace("[TimeUser_Month]", f.TimeUser_Month).Replace("[TimeUser_Day]", f.TimeUser_Day)
                .Replace("[TimeUser_Hour]", f.TimeUser_Hour).Replace("[TimeUser_Minute]", f.TimeUser_Minute).Replace("[TimeUser_Second]", f.TimeUser_Second)
                .Replace("[TimeUser_Off]", f.TimeUser_Off)
                .Replace("[HypoJP]", f.HypoJP).Replace("[HypoEN]", f.HypoEN)
                .Replace("[Lat10]", f.Lat10).Replace("[LatNS]", f.LatNS).Replace("[LatNSJP]", f.LatNSJP)
                .Replace("[Lat60d]", f.Lat60d).Replace("[Lat60m]", f.Lat60m).Replace("[Lat60s]", f.Lat60s)
                .Replace("[Lon10]", f.Lon10).Replace("[LonEW]", f.LonEW).Replace("[LonEWJP]", f.LonEWJP)
                .Replace("[Lon60d]", f.Lon60d).Replace("[Lon60m]", f.Lon60m).Replace("[Lon60s]", f.Lon60s)
                .Replace("[Depth]", f.Depth)
                .Replace("[MagType]", f.MagType).Replace("[Mag]", f.Mag)
                .Replace("[MMI]", f.MMI).Replace("[MMIAra]", f.MMIAra)
                .Replace("[AlertJP]", f.AlertJP).Replace("[AlertEN]", f.AlertEN)
                .Replace("[Source]", f.Source);
        }

        /// <summary>
        /// 緯度を各stringに変換します。
        /// </summary>
        /// <param name="lat">緯度</param>
        /// <param name="lat10">緯度(十進数)</param>
        /// <param name="latNS">NまたはS</param>
        /// <param name="latNSJP">北緯または南緯</param>
        /// <param name="lat60d">緯度(六十進数・度)</param>
        /// <param name="lat60m">緯度(六十進数・分)</param>
        /// <param name="lat60s">緯度(六十進数・秒)</param>
        public static void Lat2String(double lat, out string lat10, out string latNS, out string latNSJP, out string lat60d, out string lat60m, out string lat60s)
        {
            lat10 = lat.ToString();
            latNS = lat >= 0 ? "N" : "S";
            latNSJP = lat >= 0 ? "北緯" : "南緯";
            lat = Math.Abs(lat);
            double deg = Math.Floor(lat);
            double min = Math.Floor((lat - deg) * 60);
            double sec = Math.Floor((lat - deg - min / 60) * 3600);
            lat60d = deg.ToString();
            lat60m = min.ToString();
            lat60s = sec.ToString();
        }

        /// <summary>
        /// 経度を各stringに変換します。
        /// </summary>
        /// <param name="lon">経度</param>
        /// <param name="lon10">経度(十進数)</param>
        /// <param name="lonEW">NまたはS</param>
        /// <param name="lonEWJP">東経または西経</param>
        /// <param name="lon60d">経度(六十進数・度)</param>
        /// <param name="lon60m">経度(六十進数・分)</param>
        /// <param name="lon60s">経度(六十進数・秒)</param>
        public static void Lon2String(double lon, out string lon10, out string lonEW, out string lonEWJP, out string lon60d, out string lon60m, out string lon60s)
        {
            lon10 = lon.ToString();
            lonEW = lon >= 0 ? "N" : "S";
            lonEWJP = lon >= 0 ? "北緯" : "南緯";
            lon = Math.Abs(lon);
            double deg = Math.Floor(lon);
            double min = Math.Floor((lon - deg) * 60);
            double sec = Math.Floor((lon - deg - min / 60) * 3600);
            lon60d = deg.ToString();
            lon60m = min.ToString();
            lon60s = sec.ToString();
        }

        /// <summary>
        /// MMIのアラビア数字を求めます。
        /// </summary>
        /// <param name="mmi">改正メルカリ震度階級</param>
        /// <returns>MMIのアラビア数字</returns>
        public static string MMI2Ara(double? mmi)
        {
            return mmi < 1.5 ? "I" : mmi < 2.5 ? "II" : mmi < 3.5 ? "III" : mmi < 4.5 ? "IV" : mmi < 5.5 ? "V" : mmi < 6.5 ? "VI" : mmi < 7.5 ? "VII" : mmi < 8.5 ? "VIII" : mmi < 9.5 ? "IX" : mmi < 10.5 ? "X" : mmi < 11.5 ? "XI" : mmi >= 11.5 ? "XII" : "-";
        }

        /// <summary>
        /// 英語のアラートを日本語に変換します。
        /// </summary>
        /// <param name="alert">アラート(英語)</param>
        /// <returns>アラート(日本語)</returns>
        public static string Alert2JP(string alert)
        {
            switch (alert)
            {
                case "green":
                    return "緑";
                case "yellow":
                    return "黄";
                case "orange":
                    return "橙";
                case "red":
                    return "赤";
                case "pending":
                    return "保留中";
                default:
                    return "-";
            }
        }

        /// <summary>
        /// 描画用マグニチュード別色
        /// </summary>
        /// <param name="mag">マグニチュード</param>
        /// <returns>マグニチュード別の色</returns>
        public static Brush Mag2Brush(double mag)
        {
            if (mag < 6)
                return Brushes.White;
            else if (mag < 8)
                return Brushes.Yellow;
            else
                return Brushes.Red;
        }

        /// <summary>
        /// 描画用アラート別色
        /// </summary>
        /// <param name="alert">アラート</param>
        /// <returns>アラート別の色</returns>
        public static Color Alert2Color(string alert)
        {
            switch (alert)
            {
                case "green":
                    return Color.Green;
                case "yellow":
                    return Color.Yellow;
                case "orange":
                    return Color.Orange;
                case "red":
                    return Color.Red;
                case "pending":
                    return Color.DimGray;
                default:
                    return Color.FromArgb(45, 45, 90);
            }
        }
    }
}

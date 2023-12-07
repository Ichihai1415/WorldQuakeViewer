using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WorldQuakeViewer.Properties;
using static WorldQuakeViewer.Config;
using static WorldQuakeViewer.CtrlForm;
using static WorldQuakeViewer.MainForm;
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

        //##とか00はフォーマットのやつ
        /// <summary>
        /// 緯度を様々なフォーマットに変換します。
        /// </summary>
        /// <remarks>指定ミスに注意してください。</remarks>
        /// <param name="lat">緯度</param>
        /// <param name="latStLong">(string) 設定により {###.##…}ﾟN または {###}ﾟ{##}'{##}"N</param>
        /// <param name="latStLongJP">(string) 設定により 北緯{###.##…}度 または 北緯{##}度{##}分{##}秒 </param>
        /// <param name="latDisplay">(string) 設定により {###.00}ﾟN または {###}ﾟ{##}'{##}"N </param>
        public static void Lat2String(double lat, out string latStLong, out string latStLongJP, out string latDisplay)//ここら辺は雑なので気が向いたら調整
        {
            double latShort = Math.Round(lat, 2, MidpointRounding.AwayFromZero);
            string latStDecimal = lat > 0 ? $"{latShort}ﾟN" : $"{-latShort}ﾟS";
            TimeSpan latTime = TimeSpan.FromHours(lat);
            string latStShort = lat > 0 ? $"{(int)lat}ﾟ{latTime.Minutes}'N" : $"{(int)-lat}ﾟ{-latTime.Minutes}'S";
            latStLong = Settings.Default.Text_LatLonDecimal ? lat > 0 ? $"{lat}ﾟN" : $"{-lat}ﾟS" : lat > 0 ? $"{(int)lat}ﾟ{latTime.Minutes}'{latTime.Seconds}\"N" : $"{(int)-lat}ﾟ{-latTime.Minutes}'{-latTime.Seconds}\"S";
            latStLongJP = Settings.Default.Text_LatLonDecimal ? lat > 0 ? $"北緯{lat}度" : $"南緯{-lat}度" : lat > 0 ? $"北緯{(int)lat}度{latTime.Minutes}分{latTime.Seconds}秒" : $"南緯{(int)-lat}度{-latTime.Minutes}分{-latTime.Seconds}秒";
            latDisplay = Settings.Default.Text_LatLonDecimal ? latStDecimal : latStShort;
        }

        /// <summary>
        /// 緯度を様々なフォーマットに変換します。
        /// </summary>
        /// <remarks>指定ミスに注意してください。</remarks>
        /// <param name="lat">緯度</param>
        /// <param name="latShort">(double) ###.00</param>
        /// <param name="latStDecimal">(string) {###.00}°N</param>
        /// <param name="latStShort">(string) {###}ﾟ{##}'N</param>
        /// <param name="latStLong">(string) 設定により {###.##…}ﾟN または {###}ﾟ{##}'{##}"N</param>
        /// <param name="latStLongJP">(string) 設定により 北緯{###.##…}度 または 北緯{##}度{##}分{##}秒 </param>
        /// <param name="latDisplay">(string) 設定により<paramref name="latStDecimal"/>または<paramref name="latStShort"/></param>
        public static void Lat2String(double lat, out double latShort, out string latStDecimal, out string latStShort, out string latStLong, out string latStLongJP, out string latDisplay)
        {
            latShort = Math.Round(lat, 2, MidpointRounding.AwayFromZero);
            latStDecimal = lat > 0 ? $"{latShort}ﾟN" : $"{-latShort}ﾟS";
            TimeSpan latTime = TimeSpan.FromHours(lat);
            latStShort = lat > 0 ? $"{(int)lat}ﾟ{latTime.Minutes}'N" : $"{(int)-lat}ﾟ{-latTime.Minutes}'S";
            latStLong = Settings.Default.Text_LatLonDecimal ? lat > 0 ? $"{lat}ﾟN" : $"{-lat}ﾟS" : lat > 0 ? $"{(int)lat}ﾟ{latTime.Minutes}'{latTime.Seconds}\"N" : $"{(int)-lat}ﾟ{-latTime.Minutes}'{-latTime.Seconds}\"S";
            latStLongJP = Settings.Default.Text_LatLonDecimal ? lat > 0 ? $"北緯{lat}度" : $"南緯{-lat}度" : lat > 0 ? $"北緯{(int)lat}度{latTime.Minutes}分{latTime.Seconds}秒" : $"南緯{(int)-lat}度{-latTime.Minutes}分{-latTime.Seconds}秒";
            latDisplay = Settings.Default.Text_LatLonDecimal ? latStDecimal : latStShort;
        }

        /// <summary>
        /// 経度を様々なフォーマットに変換します。
        /// </summary>
        /// <remarks>指定ミスに注意してください。</remarks>
        /// <param name="lon">経度</param>
        /// <param name="lonStLong">(string) 設定により {###.##…}ﾟE または {###}ﾟ{##}'{##}"E</param>
        /// <param name="lonStLongJP">(string) 設定により 東経{###.##…}度 または 東経{##}度{##}分{##}秒 </param>
        /// <param name="lonDisplay">(string) 設定により {###.00}ﾟE または {###}ﾟ{##}'{##}"E</param>
        public static void Lon2String(double lon, out string lonStLong, out string lonStLongJP, out string lonDisplay)
        {
            double lonShort = Math.Round(lon, 2, MidpointRounding.AwayFromZero);
            string lonStDecimal = lon > 0 ? $"{lonShort}ﾟE" : $"{-lonShort}ﾟW";
            TimeSpan lonTime = TimeSpan.FromHours(lon);
            string lonStShort = lon > 0 ? $"{(int)lon}ﾟ{lonTime.Minutes}'E" : $"{(int)-lon}ﾟ{-lonTime.Minutes}'W";
            lonStLong = Settings.Default.Text_LatLonDecimal ? lon > 0 ? $"{lon}ﾟE" : $"{-lon}ﾟW" : lon > 0 ? $"{(int)lon}ﾟ{lonTime.Minutes}'{lonTime.Seconds}\"E" : $"{(int)-lon}ﾟ{-lonTime.Minutes}'{-lonTime.Seconds}\"W";
            lonStLongJP = Settings.Default.Text_LatLonDecimal ? lon > 0 ? $"東経{lon}度" : $"西経{-lon}度" : lon > 0 ? $"東経{(int)lon}度{lonTime.Minutes}分{lonTime.Seconds}秒" : $"西経{(int)-lon}度{-lonTime.Minutes}分{-lonTime.Seconds}秒";
            lonDisplay = Settings.Default.Text_LatLonDecimal ? lonStDecimal : lonStShort;
        }

        /// <summary>
        /// 経度を様々なフォーマットに変換します。
        /// </summary>
        /// <remarks>指定ミスに注意してください。</remarks>
        /// <param name="lon">経度</param>
        /// <param name="lonShort">(double) ###.00</param>
        /// <param name="lonStDecimal">(string) {###.00}ﾟE</param>
        /// <param name="lonStShort">(string) {###}ﾟ{##}'E</param>
        /// <param name="lonStLong">(string) 設定により {###.##…}ﾟE または {###}ﾟ{##}'{##}"E</param>
        /// <param name="lonStLongJP">(string) 設定により 東経{###.##…}度 または 東経{##}度{##}分{##}秒 </param>
        /// <param name="lonDisplay">(string) 設定により<paramref name="lonStDecimal"/>または<paramref name="lonStShort"/></param>
        public static void Lon2String(double lon, out double lonShort, out string lonStDecimal, out string lonStShort, out string lonStLong, out string lonStLongJP, out string lonDisplay)
        {
            lonShort = Math.Round(lon, 2, MidpointRounding.AwayFromZero);
            lonStDecimal = lon > 0 ? $"{lonShort}ﾟE" : $"{-lonShort}ﾟW";
            TimeSpan lonTime = TimeSpan.FromHours(lon);
            lonStShort = lon > 0 ? $"{(int)lon}ﾟ{lonTime.Minutes}'E" : $"{(int)-lon}ﾟ{-lonTime.Minutes}'W";
            lonStLong = Settings.Default.Text_LatLonDecimal ? lon > 0 ? $"{lon}ﾟE" : $"{-lon}ﾟW" : lon > 0 ? $"{(int)lon}ﾟ{lonTime.Minutes}'{lonTime.Seconds}\"E" : $"{(int)-lon}ﾟ{-lonTime.Minutes}'{-lonTime.Seconds}\"W";
            lonStLongJP = Settings.Default.Text_LatLonDecimal ? lon > 0 ? $"東経{lon}度" : $"西経{-lon}度" : lon > 0 ? $"東経{(int)lon}度{lonTime.Minutes}分{lonTime.Seconds}秒" : $"西経{(int)-lon}度{-lonTime.Minutes}分{-lonTime.Seconds}秒";
            lonDisplay = Settings.Default.Text_LatLonDecimal ? lonStDecimal : lonStShort;
        }
    }
}

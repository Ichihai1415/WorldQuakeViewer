using System;
using System.Collections.Generic;
using System.Drawing;
using static WorldQuakeViewer.Util_Class;

namespace WorldQuakeViewer
{
    /// <summary>
    /// 設定保存用クラス
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 設定バージョン
        /// </summary>
        /// <remarks>getonly</remarks>
        public string Version { get; } = MainForm.version;

        /// <summary>
        /// 処理するデータ元ごとのデータ処理
        /// </summary>
        public Dictionary<DataAuthor, Data> Datas { get; set; }

        /// <summary>
        /// 画面ごとの表示処理
        /// </summary>
        public List<View> Views { get; set; }

        /// <summary>
        /// ログ出力関連
        /// </summary>
        public class Log
        {
            /// <summary>
            /// 通常動作ログ出力を有効か
            /// </summary>
            public bool Normal_Enable { get; set; } = false;

            /// <summary>
            /// エラーログ出力を有効か
            /// </summary>
            public bool Error_Enable { get; set; } = true;

            /// <summary>
            /// 動作ログ自動消去の間隔 0で無効
            /// </summary>
            public TimeSpan AutoDelate { get; set; } = TimeSpan.FromHours(24);

            /// <summary>
            /// 動作ログ消去時に自動保存するか
            /// </summary>
            public bool Normal_AutoSave { get; set; } = false;

            /// <summary>
            /// M4.5未満の情報を有効か
            /// </summary>
            public bool EQ_L1_Enable { get; set; } = false;

            /// <summary>
            /// M4.5以上M6.0未満の情報を有効か
            /// </summary>
            public bool EQ_L2_Enable { get; set; } = false;

            /// <summary>
            /// M6.0以上M7.0未満の情報を有効か
            /// </summary>
            public bool EQ_L3_Enable { get; set; } = false;

            /// <summary>
            /// M7.0以上M8.0未満の情報を有効か
            /// </summary>
            public bool EQ_L4_Enable { get; set; } = false;

            /// <summary>
            /// M8.0以上の情報を有効か
            /// </summary>
            public bool EQ_L5_Enable { get; set; } = false;

            /// <summary>
            /// 情報保存の文のフォーマット
            /// </summary>
            public string EQ_Format { get; set; } = "フォーマットを入力してください";
        }

        //以下上記配列のクラス
        /// <summary>
        /// データ処理
        /// </summary>
        public class Data
        {
            /// <summary>
            /// 取得時間(毎分x秒)
            /// </summary>
            public int[] GetTimes { get; set; }

            /// <summary>
            /// 更新検知対象
            /// </summary>
            public class Update
            {
                /// <summary>
                /// 更新確認対象期間
                /// </summary>
                public TimeSpan MaxPeriod { get; set; } = TimeSpan.FromDays(7);

                /// <summary>
                /// 発生時刻
                /// </summary>
                public bool Time { get; set; } = false;

                /// <summary>
                /// 更新時刻
                /// </summary>
                public bool UpdtTime { get; set; } = false;

                /// <summary>
                /// 震源名
                /// </summary>
                public bool Hypo { get; set; } = true;

                /// <summary>
                /// 緯度経度
                /// </summary>
                public bool LatLon { get; set; } = false;

                /// <summary>
                /// 深さ
                /// </summary>
                public bool Depth { get; set; } = false;

                /// <summary>
                /// マグニチュードの種類
                /// </summary>
                public bool MagType { get; set; } = true;

                /// <summary>
                /// マグニチュード
                /// </summary>
                public bool Mag { get; set; } = true;

                /// <summary>
                /// (USGSのみ)改正メルカリ震度階級(ShakeMap)
                /// </summary>
                public bool MMI { get; set; } = true;

                /// <summary>
                /// (USGSのみ)アラート(PAGER)
                /// </summary>
                public bool Alert { get; set; } = true;
            }

            /// <summary>
            /// 棒読みちゃん送信
            /// </summary>
            public class Bouyomi
            {
                /// <summary>
                /// 有効か
                /// </summary>
                public bool Enable { get; set; } = false;

                /// <summary>
                /// 送信する最小マグニチュード
                /// </summary>
                public double LowerMagLimit { get; set; } = 0;

                /// <summary>
                /// ホスト名
                /// </summary>
                public string Host { get; set; } = "172.0.0.1";

                /// <summary>
                /// ポート
                /// </summary>
                public int Port { get; set; } = 50001;

                /// <summary>
                /// 声質
                /// </summary>
                public short Voice { get; set; } = 0;

                /// <summary>
                /// 速さ
                /// </summary>
                public short Speed { get; set; } = -1;

                /// <summary>
                /// 音程
                /// </summary>
                public short Tone { get; set; } = -1;

                /// <summary>
                /// 音量
                /// </summary>
                public short Volume { get; set; } = -1;

                /// <summary>
                /// 送信する文のフォーマット
                /// </summary>
                public string Format { get; set; } = "フォーマットを入力してください";
            }

            /// <summary>
            /// 音声再生
            /// </summary>
            public class Sound
            {
                /// <summary>
                /// M4.5未満を有効か
                /// </summary>
                public bool L1_Enable { get; set; } = true;

                /// <summary>
                /// M4.5以上M6.0未満を有効か
                /// </summary>
                public bool L2_Enable { get; set; } = true;

                /// <summary>
                /// M6.0以上M7.0未満を有効か
                /// </summary>
                public bool L3_Enable { get; set; } = true;

                /// <summary>
                /// M7.0以上M8.0未満を有効か
                /// </summary>
                public bool L4_Enable { get; set; } = true;

                /// <summary>
                /// M8.0以上を有効か
                /// </summary>
                public bool L5_Enable { get; set; } = true;

                /// <summary>
                /// M4.5未満の音声ファイルのパス
                /// </summary>
                public string L1_Path { get; set; } = "sound\\L1.wav";

                /// <summary>
                /// M4.5以上M6.0未満の音声ファイルのパス
                /// </summary>
                public string L2_Path { get; set; } = "sound\\L2.wav";

                /// <summary>
                /// M6.0以上M7.0未満の音声ファイルのパス
                /// </summary>
                public string L3_Path { get; set; } = "sound\\L3.wav";

                /// <summary>
                /// M7.0以上M8.0未満の音声ファイルのパス
                /// </summary>
                public string L4_Path { get; set; } = "sound\\L4.wav";

                /// <summary>
                /// M8.0以上の音声ファイルのパス
                /// </summary>
                public string L5_Path { get; set; } = "sound\\L5.wav";

            }

            /// <summary>
            /// socket送信
            /// </summary>
            public class Socket
            {
                /// <summary>
                /// 有効か
                /// </summary>
                public bool Enable { get; set; } = false;

                /// <summary>
                /// 送信する最小マグニチュード
                /// </summary>
                public double LowerMagLimit { get; set; } = 0;

                /// <summary>
                /// ホスト名
                /// </summary>
                public string Host { get; set; } = "172.0.0.1";

                /// <summary>
                /// ポート
                /// </summary>
                public int Port { get; set; } = 31401;

                /// <summary>
                /// 送信する文のフォーマット
                /// </summary>
                public string Format { get; set; } = "フォーマットを入力してください";
            }

            /// <summary>
            /// webhook送信
            /// </summary>
            public class Webhook
            {
                /// <summary>
                /// 有効か
                /// </summary>
                public bool Enable { get; set; } = false;

                /// <summary>
                /// 送信する最小マグニチュード
                /// </summary>
                public double LowerMagLimit { get; set; } = 0;

                /// <summary>
                /// 送信するURL
                /// </summary>
                public string URL { get; set; } = "https://example.com/webhook/";

                /// <summary>
                /// 送信する文のフォーマット
                /// </summary>
                public string Format { get; set; } = "フォーマットを入力してください";
            }
        }

        /// <summary>
        /// 表示処理
        /// </summary>
        public class View
        {
            /// <summary>
            /// 表示するデータ
            /// </summary>
            public ViewData Data { get; set; } = ViewData.Null;

            /// <summary>
            /// 表示する最小マグニチュード
            /// </summary>
            public double LowerMagLimit { get; set; } = 0;

            /// <summary>
            /// マップの範囲(°)
            /// </summary>
            /// <remarks>180/(マップ高さ/画面マップ部分高さ)</remarks>
            public int MapRange { get; set; } = 80;

            /// <summary>
            /// 震源が極に近いときマップ範囲外を表示させないようずらすか
            /// </summary>
            public bool HypoShift { get; set; } = true;

            /// <summary>
            /// 緯度経度を十進数で処理するか
            /// </summary>
            public bool LatLonDecimal { get; set; } = true;

            /// <summary>
            /// 描画色
            /// </summary>
            /// <remarks>マップはWorldQuakeViewer.MapGenerator</remarks>
            public class Colors
            {
                /// <summary>
                /// 最新の後ろ部分(****地震情報…のところ)のテキスト色
                /// </summary>
                public Color Back1_Text { get; set; } = Color.FromArgb(255, 255, 255, 255);

                /// <summary>
                /// 最新の後ろ部分(****地震情報…のところ)の背景色
                /// </summary>
                public Color Back1_Back { get; set; } = Color.FromArgb(255, 0, 0, 30);

                /// <summary>
                /// 最新の前部分([日本語震源名]\n[緯度経度] [深さ]\n…のところ)のテキスト色
                /// </summary>
                public Color Fore1_Text { get; set; } = Color.FromArgb(255, 255, 255, 255);

                /// <summary>
                /// 最新の前部分([日本語震源名]\n[緯度経度] [深さ]\n…のところ)の背景色
                /// </summary>
                public Color Fore1_Back { get; set; } = Color.FromArgb(255, 30, 30, 60);

                /// <summary>
                /// 履歴の後ろ部分(****地震情報…のところ)のテキスト色
                /// </summary>
                public Color Back2_Text { get; set; } = Color.FromArgb(255, 255, 255, 255);

                /// <summary>
                /// 履歴の後ろ部分(****地震情報…のところ)の背景色
                /// </summary>
                public Color Back2_Back { get; set; } = Color.FromArgb(255, 0, 0, 30);

                /// <summary>
                /// 履歴の前部分([日本語震源名]\n[緯度経度] [深さ]\n…のところ)のテキスト色
                /// </summary>
                public Color Fore2_Text { get; set; } = Color.FromArgb(255, 255, 255, 255);

                /// <summary>
                /// 履歴の前部分([日本語震源名]\n[緯度経度] [深さ]\n…のところ)の背景色
                /// </summary>
                public Color Fore2_Back { get; set; } = Color.FromArgb(255, 45, 45, 90);

                /// <summary>
                /// 地図データ:Natural Earthのテキスト色
                /// </summary>
                public Color MapData_Text { get; set; } = Color.FromArgb(255, 255, 255, 255);

                /// <summary>
                /// 地図データ:Natural Earthの背景色
                /// </summary>
                public Color MapData_Back { get; set; } = Color.FromArgb(128, 0, 0, 30);

                /// <summary>
                /// 境界の線の色
                /// </summary>
                public Color Border { get; set; } = Color.FromArgb(255, 200, 200, 200);
            }
        }
    }
}

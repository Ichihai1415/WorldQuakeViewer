using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
        public string Version { get; } = version;

        /// <summary>
        /// 処理するデータ元ごとのデータ処理
        /// </summary>
        public Data_[] Datas { get; set; } = new int[DataAuthorCount].Select((n, i) => new Data_
        {
            Name = ((DataAuthor)i).ToString(),
            URL = DataDefURL[(DataAuthor)Enum.ToObject(typeof(DataAuthor), i)]//enum追加時も変えなくてもいいように
        }).ToArray();

        /// <summary>
        /// 画面ごとの表示処理
        /// </summary>
        public View_[] Views { get; set; } = new View_[] { new View_() };

        /// <summary>
        /// ログ出力関連(地震除く)
        /// </summary>
        public LogN_ LogN { get; set; } = new LogN_();

        /// <summary>
        /// ログ出力関連(地震除く)
        /// </summary>
        public class LogN_
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
            /// Config_DisplayからConfigに変換します。
            /// </summary>
            /// <param name="from">変換元</param>
            public static explicit operator LogN_(Config_Display.LogN_ from) => new LogN_
            {
                Normal_Enable=from.Normal_Enable,
                Error_Enable=from.Error_Enable,
                AutoDelate=from.AutoDelate,
                Normal_AutoSave=from.Normal_AutoSave
            };
        }

        /// <summary>
        /// データ処理
        /// </summary>
        public class Data_
        {
            /// <summary>
            /// 取得元
            /// </summary>
            /// <remarks>自動で設定されます</remarks>
            public string Name { get; set; }

            /// <summary>
            /// 取得するURL
            /// </summary>
            /// <remarks>自動で設定されます</remarks>
            public string URL { get; set; }

            /// <summary>
            /// 取得時間(毎分x秒) -1で無効
            /// </summary>
            public int[] GetTimes { get; set; } = new int[2] { -1, -1 };

            /// <summary>
            /// 更新検知対象
            /// </summary>
            public Update_ Update { get; set; } = new Update_();

            /// <summary>
            /// 棒読みちゃん送信
            /// </summary>
            public Bouyomi_ Bouyomi { get; set; } = new Bouyomi_();

            /// <summary>
            /// 音声再生
            /// </summary>
            public Sound_ Sound { get; set; } = new Sound_();

            /// <summary>
            /// socket送信
            /// </summary>
            public Socket_ Socket { get; set; } = new Socket_();

            /// <summary>
            /// webhook送信
            /// </summary
            public Webhook_ Webhook { get; set; } = new Webhook_();

            /// <summary>
            /// ログ出力関連(地震)
            /// </summary>
            public LogE_ LogE { get; set; } = new LogE_();

            /// <summary>
            /// 更新検知対象
            /// </summary>
            public class Update_
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

                /// <summary>
                /// Config_DisplayからConfigに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Update_(Config_Display.Data_.Update_ from) => new Update_
                {
                    MaxPeriod=from.MaxPeriod,
                    Time=from.Time,
                    UpdtTime=from.UpdtTime,
                    Hypo=from.Hypo,
                    LatLon=from.LatLon,
                    Depth=from.Depth,
                    MagType=from.MagType,
                    Mag=from.Mag,
                    MMI=from.MMI,
                    Alert=from.Alert
                };
            }

            /// <summary>
            /// 棒読みちゃん送信
            /// </summary>
            public class Bouyomi_
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

                /// <summary>
                /// Config_DisplayからConfigに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Bouyomi_(Config_Display.Data_.Bouyomi_ from) => new Bouyomi_
                {
                    Enable = from.Enable,
                    LowerMagLimit = from.LowerMagLimit,
                    Host = from.Host,
                    Port = from.Port,
                    Voice = from.Voice,
                    Speed = from.Speed,
                    Tone = from.Tone,
                    Volume = from.Volume,
                    Format = from.Format
                };
            }

            /// <summary>
            /// 音声再生
            /// </summary>
            public class Sound_
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
                public string L1_Path { get; set; } = "Sound\\L1.wav";

                /// <summary>
                /// M4.5以上M6.0未満の音声ファイルのパス
                /// </summary>
                public string L2_Path { get; set; } = "Sound\\L2.wav";

                /// <summary>
                /// M6.0以上M7.0未満の音声ファイルのパス
                /// </summary>
                public string L3_Path { get; set; } = "Sound\\L3.wav";

                /// <summary>
                /// M7.0以上M8.0未満の音声ファイルのパス
                /// </summary>
                public string L4_Path { get; set; } = "Sound\\L4.wav";

                /// <summary>
                /// M8.0以上の音声ファイルのパス
                /// </summary>
                public string L5_Path { get; set; } = "Sound\\L5.wav";

                /// <summary>
                /// Config_DisplayからConfigに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Sound_(Config_Display.Data_.Sound_ from) => new Sound_
                {
                    L1_Enable = from.L1_Enable,
                    L2_Enable = from.L2_Enable,
                    L3_Enable = from.L3_Enable,
                    L4_Enable = from.L4_Enable,
                    L5_Enable = from.L5_Enable,
                    L1_Path = from.L1_Path,
                    L2_Path = from.L2_Path,
                    L3_Path = from.L3_Path,
                    L4_Path = from.L4_Path,
                    L5_Path = from.L5_Path
                };
            }

            /// <summary>
            /// socket送信
            /// </summary>
            public class Socket_
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

                /// <summary>
                /// Config_DisplayからConfigに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Socket_(Config_Display.Data_.Socket_ from) => new Socket_
                {
                    Enable = from.Enable,
                    LowerMagLimit = from.LowerMagLimit,
                    Host = from.Host,
                    Port = from.Port,
                    Format = from.Format
                };
            }

            /// <summary>
            /// webhook送信
            /// </summary>
            public class Webhook_
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

                /// <summary>
                /// Config_DisplayからConfigに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Webhook_(Config_Display.Data_.Webhook_ from) => new Webhook_
                {
                    Enable= from.Enable,
                    LowerMagLimit = from.LowerMagLimit,
                    URL = from.URL,
                    Format = from.Format
                };
            }

            /// <summary>
            /// ログ出力関連(地震)
            /// </summary>
            public class LogE_
            {
                /// <summary>
                /// M4.5未満を有効か
                /// </summary>
                public bool L1_Enable { get; set; } = false;

                /// <summary>
                /// M4.5以上M6.0未満を有効か
                /// </summary>
                public bool L2_Enable { get; set; } = false;

                /// <summary>
                /// M6.0以上M7.0未満を有効か
                /// </summary>
                public bool L3_Enable { get; set; } = false;

                /// <summary>
                /// M7.0以上M8.0未満を有効か
                /// </summary>
                public bool L4_Enable { get; set; } = false;

                /// <summary>
                /// M8.0以上を有効か
                /// </summary>
                public bool L5_Enable { get; set; } = false;

                /// <summary>
                /// 保存する文のフォーマット
                /// </summary>
                /// <remarks>情報の間にソフト情報等が入ります</remarks>
                public string Format { get; set; } = "フォーマットを入力してください";

                /// <summary>
                /// Config_DisplayからConfigに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator LogE_(Config_Display.Data_.LogE_ from) => new LogE_
                {
                    L1_Enable= from.L1_Enable,
                    L2_Enable= from.L2_Enable,
                    L3_Enable= from.L3_Enable,
                    L4_Enable= from.L4_Enable,
                    L5_Enable= from.L5_Enable,
                    Format = from.Format
                };
            }

            /// <summary>
            /// Config_DisplayからConfigに変換します。
            /// </summary>
            /// <param name="from">変換元</param>
            public static explicit operator Data_(Config_Display.Data_ from) => new Data_
            {
                Name = from.Name,
                URL = from.URL,
                GetTimes = from.GetTimes,
                Update = (Update_)from.Update,
                Bouyomi = (Bouyomi_)from.Bouyomi,
                Sound = (Sound_)from.Sound,
                Socket = (Socket_)from.Socket,
                Webhook = (Webhook_)from.Webhook,
                LogE = (LogE_)from.LogE
            };
        }

        /// <summary>
        /// 表示処理
        /// </summary>
        public class View_
        {
            /// <summary>
            /// 表示するデータ
            /// </summary>
            public ViewData Data { get; set; } = ViewData.Null;

            /// <summary>
            /// タイトル1のテキスト
            /// </summary>
            public string Title1Text { get; set; } = "設定してください";

            /// <summary>
            /// (最新、履歴のみ)タイトル2のテキスト
            /// </summary>
            public string Title2Text { get; set; } = "設定してください";

            /// <summary>
            /// 表示するテキスト
            /// </summary>
            public string DisplayText { get; set; } = "設定してください";

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
            /// 緯度経度を十進数で表示するか
            /// </summary>
            public bool LatLonDecimal { get; set; } = true;

            /// <summary>
            /// 描画色
            /// </summary>
            /// <remarks>マップはWorldQuakeViewer.MapGenerator</remarks>
            public Colors_ Colors { get; set; } = new Colors_();

            /// <summary>
            /// 描画色
            /// </summary>
            /// <remarks>マップはWorldQuakeViewer.MapGenerator</remarks>
            public class Colors_
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
                /// 最新の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)のテキスト色
                /// </summary>
                public Color Fore1_Text { get; set; } = Color.FromArgb(255, 255, 255, 255);

                /// <summary>
                /// 最新の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)の背景色
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
                /// 履歴の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)のテキスト色
                /// </summary>
                public Color Fore2_Text { get; set; } = Color.FromArgb(255, 255, 255, 255);

                /// <summary>
                /// 履歴の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)の背景色
                /// </summary>
                public Color Fore2_Back { get; set; } = Color.FromArgb(255, 45, 45, 90);

                /// <summary>
                /// 「地図データ:Natural Earth」のテキスト色
                /// </summary>
                public Color MapData_Text { get; set; } = Color.FromArgb(255, 255, 255, 255);

                /// <summary>
                /// 「地図データ:Natural Earth」の背景色
                /// </summary>
                public Color MapData_Back { get; set; } = Color.FromArgb(128, 0, 0, 30);

                /// <summary>
                /// 境界の線の色
                /// </summary>
                public Color Border { get; set; } = Color.FromArgb(255, 200, 200, 200);

                /// <summary>
                /// Config_DisplayからConfigに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Colors_(Config_Display.View_.Colors_ from) => new Colors_
                {
                    Back1_Text = from.Back1_Text,
                    Back1_Back = from.Back1_Back,
                    Fore1_Text = from.Fore1_Text,
                    Fore1_Back = from.Fore1_Back,
                    Back2_Text = from.Back2_Text,
                    Back2_Back = from.Back2_Back,
                    Fore2_Text = from.Fore2_Text,
                    Fore2_Back = from.Fore2_Back,
                    MapData_Text = from.MapData_Text,
                    MapData_Back = from.MapData_Back,
                    Border = from.Border
                };
            }

            /// <summary>
            /// Config_DisplayからConfigに変換します。
            /// </summary>
            /// <param name="from">変換元</param>
            public static explicit operator View_(Config_Display.View_ from) => new View_
            {
                Data = from.Data,
                Title1Text = from.Title1Text,
                Title2Text = from.Title2Text,
                DisplayText = from.DisplayText,
                LowerMagLimit = from.LowerMagLimit,
                MapRange = from.MapRange,
                HypoShift = from.HypoShift,
                LatLonDecimal = from.LatLonDecimal,
                Colors = (Colors_)from.Colors
            };
        }

        /// <summary>
        /// Config_DisplayからConfigに変換します。
        /// </summary>
        /// <param name="from">変換元</param>
        public static explicit operator Config(Config_Display from) => new Config
        {
            Datas = from.Datas.Select(n => (Data_)n).ToArray(),
            Views = from.Views.Select(n => (View_)n).ToArray(),
            LogN = (LogN_)from.LogN
        };
    }

    /// <summary>
    /// 設定表示用クラス
    /// </summary>
    public class Config_Display//Categoryは配列だとできない？
    {
        /// <summary>
        /// 処理するデータ元ごとのデータ処理
        /// </summary>
        [Description("処理するデータ元ごとのデータ処理")]
        public Data_[] Datas { get; set; }

        /// <summary>
        /// 画面ごとの表示処理
        /// </summary>
        [Description("画面ごとの表示処理")]
        public View_[] Views { get; set; }

        /// <summary>
        /// ログ出力関連(地震除く)
        /// </summary>
        [Description("ログ出力関連(地震除く)")]
        public LogN_ LogN { get; set; }

        /// <summary>
        /// ログ出力関連(地震除く)
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("ログ出力関連")]
        [Description("ログ出力関連(地震除く)")]
        public class LogN_
        {
            /// <summary>
            /// 通常動作ログ出力を有効か
            /// </summary>
            [Category("ログ出力関連")]
            [Description("通常動作ログ出力を有効か")]
            public bool Normal_Enable { get; set; }

            /// <summary>
            /// エラーログ出力を有効か
            /// </summary>
            [Category("ログ出力関連")]
            [Description("エラーログ出力を有効か")]
            public bool Error_Enable { get; set; }

            /// <summary>
            /// 動作ログ自動消去の間隔 0で無効
            /// </summary>
            [Category("ログ出力関連")]
            [Description("動作ログ自動消去の間隔 0で無効")]
            public TimeSpan AutoDelate { get; set; }

            /// <summary>
            /// 動作ログ消去時に自動保存するか
            /// </summary>
            [Category("ログ出力関連")]
            [Description("動作ログ消去時に自動保存するか")]
            public bool Normal_AutoSave { get; set; }

            /// <summary>
            /// ConfigからConfig_Displayに変換します。
            /// </summary>
            /// <param name="from">変換元</param>
            public static explicit operator LogN_(Config.LogN_ from) => new LogN_
            {
                Normal_Enable = from.Normal_Enable,
                Error_Enable = from.Error_Enable,
                AutoDelate = from.AutoDelate,
                Normal_AutoSave = from.Normal_AutoSave
            };
        }

        /// <summary>
        /// データ処理
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("データ処理")]
        public class Data_
        {
            /// <summary>
            /// 取得元
            /// </summary>
            [ReadOnly(true)]
            [Description("取得元")]
            public string Name { get; set; }

            /// <summary>
            /// 取得するURL
            /// </summary>
            [Description("取得するURL")]
            public string URL { get; set; }

            /// <summary>
            /// 取得時間(毎分x秒) -1で無効
            /// </summary>
            [Description("取得時間(毎分x秒)\n-1で無効")]
            public int[] GetTimes { get; set; }

            /// <summary>
            /// 更新検知対象
            /// </summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("更新検知対象")]
            public Update_ Update { get; set; }

            /// <summary>
            /// 棒読みちゃん送信
            /// </summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("棒読みちゃん送信")]
            public Bouyomi_ Bouyomi { get; set; }

            /// <summary>
            /// 音声再生
            /// </summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("音声再生")]
            public Sound_ Sound { get; set; }

            /// <summary>
            /// socket送信
            /// </summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("socket送信")]
            public Socket_ Socket { get; set; }

            /// <summary>
            /// webhook送信
            /// </summary
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("webhook送信")]
            public Webhook_ Webhook { get; set; }

            /// <summary>
            /// ログ出力関連(地震)
            /// </summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("ログ出力関連(地震)")]
            public LogE_ LogE { get; set; }

            /// <summary>
            /// 更新検知対象
            /// </summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("更新検知対象")]
            public class Update_
            {
                /// <summary>
                /// 更新確認対象期間
                /// </summary>
                [Description("更新確認対象期間")]
                public TimeSpan MaxPeriod { get; set; }

                /// <summary>
                /// 発生時刻
                /// </summary>
                [Description("発生時刻")]
                public bool Time { get; set; }

                /// <summary>
                /// 更新時刻
                /// </summary>
                [Description("更新時刻")]
                public bool UpdtTime { get; set; }

                /// <summary>
                /// 震源名
                /// </summary>
                [Description("震源名")]
                public bool Hypo { get; set; }

                /// <summary>
                /// 緯度経度
                /// </summary>
                [Description("緯度経度")]
                public bool LatLon { get; set; }

                /// <summary>
                /// 深さ
                /// </summary>
                [Description("深さ")]
                public bool Depth { get; set; }

                /// <summary>
                /// マグニチュードの種類
                /// </summary>
                [Description("マグニチュードの種類")]
                public bool MagType { get; set; }

                /// <summary>
                /// マグニチュード
                /// </summary>
                [Description("マグニチュード")]
                public bool Mag { get; set; }

                /// <summary>
                /// (USGSのみ)改正メルカリ震度階級(ShakeMap)
                /// </summary>
                [Description("(USGSのみ)改正メルカリ震度階級(ShakeMap)")]
                public bool MMI { get; set; }

                /// <summary>
                /// (USGSのみ)アラート(PAGER)
                /// </summary>
                [Description("(USGSのみ)アラート(PAGER)")]
                public bool Alert { get; set; }

                /// <summary>
                /// ConfigからConfig_Displayに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Update_(Config.Data_.Update_ from) => new Update_
                {
                    MaxPeriod = from.MaxPeriod,
                    Time = from.Time,
                    UpdtTime = from.UpdtTime,
                    Hypo = from.Hypo,
                    LatLon = from.LatLon,
                    Depth = from.Depth,
                    MagType = from.MagType,
                    Mag = from.Mag,
                    MMI = from.MMI,
                    Alert = from.Alert
                };
            }

            /// <summary>
            /// 棒読みちゃん送信
            /// </summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("棒読みちゃん送信")]
            public class Bouyomi_
            {
                /// <summary>
                /// 有効か
                /// </summary>
                [Description("有効か")]
                public bool Enable { get; set; }

                /// <summary>
                /// 送信する最小マグニチュード
                /// </summary>
                [Description("送信する最小マグニチュード")]
                public double LowerMagLimit { get; set; }

                /// <summary>
                /// ホスト名
                /// </summary>
                [Description("ホスト名")]
                public string Host { get; set; }

                /// <summary>
                /// ポート
                /// </summary>
                [Description("ポート")]
                public int Port { get; set; }

                /// <summary>
                /// 声質
                /// </summary>
                [Description("声質")]
                public short Voice { get; set; }

                /// <summary>
                /// 速さ
                /// </summary>
                [Description("速さ")]
                public short Speed { get; set; }

                /// <summary>
                /// 音程
                /// </summary>
                [Description("音程")]
                public short Tone { get; set; }

                /// <summary>
                /// 音量
                /// </summary>
                [Description("音量")]
                public short Volume { get; set; }

                /// <summary>
                /// 送信する文のフォーマット
                /// </summary>
                [Description("送信する文のフォーマット")]
                public string Format { get; set; }

                /// <summary>
                /// ConfigからConfig_Displayに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Bouyomi_(Config.Data_.Bouyomi_ from) => new Bouyomi_
                {
                    Enable = from.Enable,
                    LowerMagLimit = from.LowerMagLimit,
                    Host = from.Host,
                    Port = from.Port,
                    Voice = from.Voice,
                    Speed = from.Speed,
                    Tone = from.Tone,
                    Volume = from.Volume,
                    Format = from.Format
                };
            }

            /// <summary>
            /// 音声再生
            /// </summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("音声再生")]
            public class Sound_
            {
                /// <summary>
                /// M4.5未満を有効か
                /// </summary>
                [Description("M4.5未満を有効か")]
                public bool L1_Enable { get; set; }

                /// <summary>
                /// M4.5以上M6.0未満を有効か
                /// </summary>
                [Description("M4.5以上M6.0未満を有効か")]
                public bool L2_Enable { get; set; }

                /// <summary>
                /// M6.0以上M7.0未満を有効か
                /// </summary>
                [Description("M6.0以上M7.0未満を有効か")]
                public bool L3_Enable { get; set; }

                /// <summary>
                /// M7.0以上M8.0未満を有効か
                /// </summary>
                [Description("M7.0以上M8.0未満を有効か")]
                public bool L4_Enable { get; set; }

                /// <summary>
                /// M8.0以上を有効か
                /// </summary>
                [Description("M8.0以上を有効か")]
                public bool L5_Enable { get; set; }

                /// <summary>
                /// M4.5未満の音声ファイルのパス
                /// </summary>
                [Description("M4.5未満の音声ファイルのパス")]
                public string L1_Path { get; set; }

                /// <summary>
                /// M4.5以上M6.0未満の音声ファイルのパス
                /// </summary>
                [Description("M4.5以上M6.0未満の音声ファイルのパス")]
                public string L2_Path { get; set; }

                /// <summary>
                /// M6.0以上M7.0未満の音声ファイルのパス
                /// </summary>
                [Description("M6.0以上M7.0未満の音声ファイルのパス")]
                public string L3_Path { get; set; }

                /// <summary>
                /// M7.0以上M8.0未満の音声ファイルのパス
                /// </summary>
                [Description("M7.0以上M8.0未満の音声ファイルのパス")]
                public string L4_Path { get; set; }

                /// <summary>
                /// M8.0以上の音声ファイルのパス
                /// </summary>
                [Description("M8.0以上の音声ファイルのパス")]
                public string L5_Path { get; set; }

                /// <summary>
                /// ConfigからConfig_Displayに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Sound_(Config.Data_.Sound_ from) => new Sound_
                {
                    L1_Enable = from.L1_Enable,
                    L2_Enable = from.L2_Enable,
                    L3_Enable = from.L3_Enable,
                    L4_Enable = from.L4_Enable,
                    L5_Enable = from.L5_Enable,
                    L1_Path = from.L1_Path,
                    L2_Path = from.L2_Path,
                    L3_Path = from.L3_Path,
                    L4_Path = from.L4_Path,
                    L5_Path = from.L5_Path
                };
            }

            /// <summary>
            /// socket送信
            /// </summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("socket送信")]
            public class Socket_
            {
                /// <summary>
                /// 有効か
                /// </summary>
                [Description("有効か")]
                public bool Enable { get; set; }

                /// <summary>
                /// 送信する最小マグニチュード
                /// </summary>
                [Description("送信する最小マグニチュード")]
                public double LowerMagLimit { get; set; }

                /// <summary>
                /// ホスト名
                /// </summary>
                [Description("ホスト名")]
                public string Host { get; set; }

                /// <summary>
                /// ポート
                /// </summary>
                [Description("ポート")]
                public int Port { get; set; }

                /// <summary>
                /// 送信する文のフォーマット
                /// </summary>
                [Description("送信する文のフォーマット")]
                public string Format { get; set; }

                /// <summary>
                /// ConfigからConfig_Displayに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Socket_(Config.Data_.Socket_ from) => new Socket_
                {
                    Enable = from.Enable,
                    LowerMagLimit = from.LowerMagLimit,
                    Host = from.Host,
                    Port = from.Port,
                    Format = from.Format
                };
            }

            /// <summary>
            /// webhook送信
            /// </summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("webhook送信")]
            public class Webhook_
            {
                /// <summary>
                /// 有効か
                /// </summary>
                [Description("有効か")]
                public bool Enable { get; set; }

                /// <summary>
                /// 送信する最小マグニチュード
                /// </summary>
                [Description("送信する最小マグニチュード")]
                public double LowerMagLimit { get; set; }

                /// <summary>
                /// 送信するURL
                /// </summary>
                [Description("送信するURL")]
                public string URL { get; set; }

                /// <summary>
                /// 送信する文のフォーマット
                /// </summary>
                [Description("送信する文のフォーマット")]
                public string Format { get; set; }

                /// <summary>
                /// ConfigからConfig_Displayに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Webhook_(Config.Data_.Webhook_ from) => new Webhook_
                {
                    Enable = from.Enable,
                    LowerMagLimit = from.LowerMagLimit,
                    URL = from.URL,
                    Format = from.Format
                };
            }

            /// <summary>
            /// ログ出力関連(地震)
            /// </summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("ログ出力関連(地震)")]
            public class LogE_
            {
                /// <summary>
                /// M4.5未満を有効か
                /// </summary>
                [Description("M4.5未満を有効か")]
                public bool L1_Enable { get; set; }

                /// <summary>
                /// M4.5以上M6.0未満を有効か
                /// </summary>
                [Description("M4.5以上M6.0未満を有効か")]
                public bool L2_Enable { get; set; }

                /// <summary>
                /// M6.0以上M7.0未満を有効か
                /// </summary>
                [Description("M6.0以上M7.0未満を有効か")]
                public bool L3_Enable { get; set; }

                /// <summary>
                /// M7.0以上M8.0未満を有効か
                /// </summary>
                [Description("M7.0以上M8.0未満を有効か")]
                public bool L4_Enable { get; set; }

                /// <summary>
                /// M8.0以上を有効か
                /// </summary>
                [Description("M8.0以上を有効か")]
                public bool L5_Enable { get; set; }

                /// <summary>
                /// 保存する文のフォーマット
                /// </summary>
                /// <remarks>情報の間にソフト情報等が入ります</remarks>
                [Description("保存する文のフォーマット")]
                public string Format { get; set; }

                /// <summary>
                /// ConfigからConfig_Displayに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator LogE_(Config.Data_.LogE_ from) => new LogE_
                {
                    L1_Enable = from.L1_Enable,
                    L2_Enable = from.L2_Enable,
                    L3_Enable = from.L3_Enable,
                    L4_Enable = from.L4_Enable,
                    L5_Enable = from.L5_Enable,
                    Format = from.Format
                };
            }

            /// <summary>
            /// ConfigからConfig_Displayに変換します。
            /// </summary>
            /// <param name="from">変換元</param>
            public static explicit operator Data_(Config.Data_ from) => new Data_
            {
                Name = from.Name,
                URL = from.URL,
                GetTimes = from.GetTimes,
                Update = (Update_)from.Update,
                Bouyomi = (Bouyomi_)from.Bouyomi,
                Sound = (Sound_)from.Sound,
                Socket = (Socket_)from.Socket,
                Webhook = (Webhook_)from.Webhook,
                LogE = (LogE_)from.LogE
            };
        }

        /// <summary>
        /// 表示処理
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("表示処理")]
        public class View_
        {
            /// <summary>
            /// 表示するデータ
            /// </summary>
            [Description("表示するデータ")]
            public ViewData Data { get; set; }

            /// <summary>
            /// タイトル1のテキスト
            /// </summary>
            [Description("タイトル1のテキスト")]
            public string Title1Text { get; set; }

            /// <summary>
            /// (最新、履歴のみ)タイトル2のテキスト
            /// </summary>
            [Description("(最新、履歴のみ)タイトル2のテキスト")]
            public string Title2Text { get; set; }

            /// <summary>
            /// 表示するテキスト
            /// </summary>
            [Description("表示するテキスト")]
            public string DisplayText { get; set; }

            /// <summary>
            /// 表示する最小マグニチュード
            /// </summary>
            [Description("表示する最小マグニチュード")]
            public double LowerMagLimit { get; set; }

            /// <summary>
            /// マップの範囲(°)
            /// </summary>
            /// <remarks>180/(マップ高さ/画面マップ部分高さ)</remarks>
            [Description("マップの範囲(°)")]
            public int MapRange { get; set; }

            /// <summary>
            /// 震源が極に近いときマップ範囲外を表示させないようずらすか
            /// </summary>
            [Description("震源が極に近いときマップ範囲外を表示させないようずらすか")]
            public bool HypoShift { get; set; }

            /// <summary>
            /// 緯度経度を十進数で表示するか
            /// </summary>
            [Description("緯度経度を十進数で表示するか")]
            public bool LatLonDecimal { get; set; }

            /// <summary>
            /// 描画色
            /// </summary>
            /// <remarks>マップはWorldQuakeViewer.MapGenerator</remarks>
            [Description("描画色\nマップはWorldQuakeViewer.MapGenerator.exeで")]
            public Colors_ Colors { get; set; }

            /// <summary>
            /// 描画色
            /// </summary>
            /// <remarks>マップはWorldQuakeViewer.MapGenerator</remarks>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Description("描画色\nマップはWorldQuakeViewer.MapGenerator.exeで")]
            public class Colors_
            {
                /// <summary>
                /// 最新の後ろ部分(****地震情報…のところ)のテキスト色
                /// </summary>
                [Description("最新の後ろ部分(****地震情報…のところ)のテキスト色")]
                public Color Back1_Text { get; set; }

                /// <summary>
                /// 最新の後ろ部分(****地震情報…のところ)の背景色
                /// </summary>
                [Description("最新の後ろ部分(****地震情報…のところ)の背景色")]
                public Color Back1_Back { get; set; }

                /// <summary>
                /// 最新の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)のテキスト色
                /// </summary>
                [Description("最新の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)のテキスト色")]
                public Color Fore1_Text { get; set; }

                /// <summary>
                /// 最新の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)の背景色
                /// </summary>
                [Description("最新の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)の背景色")]
                public Color Fore1_Back { get; set; }

                /// <summary>
                /// 履歴の後ろ部分(****地震情報…のところ)のテキスト色
                /// </summary>
                [Description("履歴の後ろ部分(****地震情報…のところ)のテキスト色")]
                public Color Back2_Text { get; set; }

                /// <summary>
                /// 履歴の後ろ部分(****地震情報…のところ)の背景色
                /// </summary>
                [Description("履歴の後ろ部分(****地震情報…のところ)の背景色")]
                public Color Back2_Back { get; set; }

                /// <summary>
                /// 履歴の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)のテキスト色
                /// </summary>
                [Description("履歴の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)のテキスト色")]
                public Color Fore2_Text { get; set; }

                /// <summary>
                /// 履歴の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)の背景色
                /// </summary>
                [Description("履歴の前部分([震源名]\n[緯度経度] [深さ]\n…のところ)の背景色")]
                public Color Fore2_Back { get; set; }

                /// <summary>
                /// 「地図データ:Natural Earth」のテキスト色
                /// </summary>
                [Description("「地図データ:Natural Earth」のテキスト色")]
                public Color MapData_Text { get; set; }

                /// <summary>
                /// 「地図データ:Natural Earth」の背景色
                /// </summary>
                [Description("「地図データ:Natural Earth」の背景色")]
                public Color MapData_Back { get; set; }

                /// <summary>
                /// 境界の線の色
                /// </summary>
                [Description("境界の線の色")]
                public Color Border { get; set; }

                /// <summary>
                /// ConfigからConfig_Displayに変換します。
                /// </summary>
                /// <param name="from">変換元</param>
                public static explicit operator Colors_(Config.View_.Colors_ from) => new Colors_
                {
                    Back1_Text = from.Back1_Text,
                    Back1_Back = from.Back1_Back,
                    Fore1_Text = from.Fore1_Text,
                    Fore1_Back = from.Fore1_Back,
                    Back2_Text = from.Back2_Text,
                    Back2_Back = from.Back2_Back,
                    Fore2_Text = from.Fore2_Text,
                    Fore2_Back = from.Fore2_Back,
                    MapData_Text = from.MapData_Text,
                    MapData_Back = from.MapData_Back,
                    Border = from.Border
                };
            }

            /// <summary>
            /// ConfigからConfig_Displayに変換します。
            /// </summary>
            /// <param name="from">変換元</param>
            public static explicit operator View_(Config.View_ from) => new View_
            {
                Data = from.Data,
                Title1Text = from.Title1Text,
                Title2Text = from.Title2Text,
                DisplayText = from.DisplayText,
                LowerMagLimit = from.LowerMagLimit,
                MapRange = from.MapRange,
                HypoShift = from.HypoShift,
                LatLonDecimal = from.LatLonDecimal,
                Colors = (Colors_)from.Colors
            };
        }

        /// <summary>
        /// ConfigからConfig_Displayに変換します。
        /// </summary>
        /// <param name="from">変換元</param>
        public static explicit operator Config_Display(Config from) => new Config_Display
        {
            Datas = from.Datas.Select(n => (Data_)n).ToArray(),
            Views = from.Views.Select(n => (View_)n).ToArray(),
            LogN = (LogN_)from.LogN
        };
    }
}
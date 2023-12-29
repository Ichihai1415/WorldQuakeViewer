using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldQuakeViewer.Properties;
using static WorldQuakeViewer.DataPro;
using static WorldQuakeViewer.Util_Class;
using static WorldQuakeViewer.Util_Conv;
using static WorldQuakeViewer.Util_Func;

namespace WorldQuakeViewer
{
    /// <summary>
    /// コントロール画面
    /// </summary>
    public partial class CtrlForm : Form
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
        /// staticでアクセスできるようにしたログ表示テキストボックス
        /// </summary>
        public static TextBox logTextBox;

        /// <summary>
        /// 設定
        /// </summary>
        public static Config config = new Config();

        /// <summary>
        /// 表示する設定
        /// </summary>
        public static Config_Display config_display = new Config_Display();

        /// <summary>
        /// 過去情報表示用設定
        /// </summary>
        public static PastConfig pastConfig = new PastConfig();

        /// <summary>
        /// 過去情報表示用の表示する設定
        /// </summary>
        public static PastConfig_Display pastConfig_display = new PastConfig_Display();

        /// <summary>
        /// その他のデータのリスト
        /// </summary>
        public static Dictionary<string, Data> data_Other = new Dictionary<string, Data>();

        /// <summary>
        /// USGSのデータのリスト
        /// </summary>
        public static Dictionary<string, Data> data_USGS = new Dictionary<string, Data>();

        /// <summary>
        /// EMSCのデータのリスト
        /// </summary>
        public static Dictionary<string, Data> data_EMSC = new Dictionary<string, Data>();

        /// <summary>
        /// GFZのデータのリスト
        /// </summary>
        public static Dictionary<string, Data> data_GFZ = new Dictionary<string, Data>();

        /// <summary>
        /// Early-estのデータのリスト
        /// </summary>
        public static Dictionary<string, Data> data_EarlyEst = new Dictionary<string, Data>();

        /// <summary>
        /// すべてのデータのリスト
        /// </summary>
        public static Dictionary<string, Data> data_All = new Dictionary<string, Data>();

        /// <summary>
        /// 過去情報のデータのリスト
        /// </summary>
        public static Dictionary<string, Data> data_Past = new Dictionary<string, Data>();

        /// <summary>
        /// 取得用
        /// </summary>
        public static HttpClient client = new HttpClient();

        /// <summary>
        /// 音声再生用
        /// </summary>
        public static SoundPlayer player = null;

        /// <summary>
        /// 実行ログの高速追加用
        /// </summary>
        public static StringBuilder exeLogs = new StringBuilder();

        /// <summary>
        /// 更新処理の無効
        /// </summary>
        public static bool noFirst = false;

        /// <summary>
        /// 表示画面の配列
        /// </summary>
        public static DataView[] dataViews = new DataView[] { null, null, null, null, null, null, null, null, null, null };

        /// <summary>
        /// 過去情報表示画面
        /// </summary>
        public static DataView pastDataView = null;

        public CtrlForm()
        {
            InitializeComponent();
            logTextBox = LogTextBox;
            IntConv_ComBox1.SelectedIndex = 0;
            IntConv_ComBox2.SelectedIndex = 1;
            IntConv_ComBox3.SelectedIndex = 2;
            ConfigMerge_PathBox.Text = Path.GetFullPath("WorldQuakeViewer.exe").Replace("WorldQuakeViewer.exe", "Setting\\merge-tmp.txt");
            Past_PathBox.Text = Path.GetFullPath("WorldQuakeViewer.exe").Replace("WorldQuakeViewer.exe", "Setting\\past-tmp.txt");
        }

        private async void CtrlForm_Load(object sender, EventArgs e)
        {
            ExeLog($"[CtrlForm_Load]起動しました。");
            InfoText0.Text = "<起動処理中...>WorldQuakeViewer";
            try
            {
                ExeLog($"[CtrlForm_Load]ソフト更新確認中...");
                string latestVersion = (await client.GetStringAsync("https://raw.githubusercontent.com/Ichihai1415/WorldQuakeViewer/main/_version")).Replace("\n", "");//なんか改行ある
                if (latestVersion != version)
                {
                    ExeLog($"[CtrlForm_Load]ソフト更新を確認({version}->{latestVersion})");
                    if (DialogOK($"更新があります(v{version}->v{latestVersion})。更新してもよろしいですか？\n失敗する場合は公開ページから手動で更新してください。"))
                    {
                        ExeLog($"[CtrlForm_Load]WorldQuakeViewer v{latestVersion}のダウンロード中...");
                        using (WebClient wc = new WebClient())
                            wc.DownloadFile($"https://github.com/Ichihai1415/WorldQuakeViewer/releases/download/v{latestVersion}/WorldQuakeViewer.v{latestVersion}.zip", "tmp.zip");
                        ExeLog($"[CtrlForm_Load]ダウンロード完了");
                        if (!File.Exists("WorldQuakeViewer.Updater.exe"))
                        {
                            ExeLog($"[CtrlForm_Load]アップデータのダウンロード中...");
                            using (WebClient wc = new WebClient())
                                wc.DownloadFile("https://github.com/Ichihai1415/WorldQuakeViewer.Updater/releases/download/v1.0.1/WorldQuakeViewer.Updater.exe", "WorldQuakeViewer.Updater.exe");
                            ExeLog($"[CtrlForm_Load]ダウンロード完了");
                        }
                        Process.Start("WorldQuakeViewer.Updater.exe");
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                ExeLog($"[CtrlForm_Load]エラー:{ex.Message}", true);
                LogSave(ex);
            }
            if (File.Exists("Setting\\config.json"))
                try
                {
                    config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Setting\\config.json"));
                    ExeLog($"[CtrlForm_Load]設定読み込み完了");
                    if (config.Version != version)//更新時必要な処置等あれば
                    {
                        ExeLog($"[CtrlForm_Load]更新を検知({config.Version}->{version})");
                        int[] nowVer = version.Split('.').Select(n => int.Parse(n.Replace("α", "-"))).ToArray();
                        int[] setVer = config.Version.Split('.').Select(n => int.Parse(n.Replace("α", "-"))).ToArray();
                        if (setVer[1] <= 1 && setVer[2] <= 1)//x.1.1以下の場合
                            Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    ExeLog($"[CtrlForm_Load]エラー:{ex.Message}", true);
                    LogSave(ex);
                    if (DialogOK($"設定の読み込みに失敗しました。OKを押すとバックアップしてリセットされます。({ex.Message})", "エラー", MessageBoxIcon.Error))
                    {
                        File.Copy("Setting\\config.json", $"Setting\\config-backup-{DateTime.Now:yyyyMMddHHmmss}.json", true);
                        File.WriteAllText("Setting\\config.json", JsonConvert.SerializeObject(config, Formatting.Indented));
                    }
                    else
                        Application.Exit();
                }
            else
            {
                MessageBox.Show(topMost, $"WorldQuakeViewer v{version}へようこそ！OKを押すと開きます。README.mdを確認してください。", "welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TopMost = true;//いったん非アクティブになると後ろ行くから一時的に前に
                TopMost = false;
                Directory.CreateDirectory("Setting");
                File.WriteAllText("Setting\\config.json", JsonConvert.SerializeObject(config, Formatting.Indented));
                ExeLog($"[CtrlForm_Load]設定保存完了");

                DialogResult yes = MessageBox.Show(topMost, "v1.2.0より前のバージョンを使用したことがありますか？(更新時に必要な処理を行います)", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (yes == DialogResult.Yes)
                {
                    Configuration config_old = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);//1.2.0未満の設定を消さないとなんかエラーが出る
                    if (File.Exists(config_old.FilePath))
                        File.Delete(config_old.FilePath);
                    if (Directory.Exists("Sound"))
                        Directory.Delete("Sound", true);
                    ExeLog("更新用処理(~v1.1.1 => v1.2.0~)を行いました。");
                }
            }
            ConfigReload();
            LogClearTimer.Enabled = true;
            if (!config.Other.LogN.Normal_Enable)
                logTextBox.Text = "<動作ログを表示する場合、設定のその他のNormal_EnableをTrueにしてください>\n\r";
            pastConfig_display = (PastConfig_Display)pastConfig;
            ProG_Past.SelectedObject = pastConfig_display;

            if (!Directory.Exists("Font"))
            {
                Directory.CreateDirectory("Font");
                ExeLog($"[CtrlForm_Load]Fontフォルダを作成しました");
            }
            if (!File.Exists("Font\\Koruri-Regular.ttf"))
            {
                File.WriteAllBytes("Font\\Koruri-Regular.ttf", Resources.Koruri_Regular);
                ExeLog($"[CtrlForm_Load]フォントファイル(\"Font\\Koruri-Regular.ttf\")をコピーしました");
            }
            if (!File.Exists("Font\\LICENSE"))
            {
                File.WriteAllText("Font\\LICENSE", Resources.Koruri_LICENSE);
                ExeLog($"[CtrlForm_Load]ライセンスファイル(\"Font\\LICENSE\")をコピーしました");
            }
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("Font\\Koruri-Regular.ttf");
            font = pfc.Families[0];
            ExeLog($"[CtrlForm_Load]フォント確認完了");

            if (!Directory.Exists("Sound"))
            {
                File.WriteAllBytes("Sound.zip", Resources.Sound);
                ZipFile.ExtractToDirectory("Sound.zip", "Sound");
                ExeLog($"[CtrlForm_Load]音声ファイルを展開しました(\"Sound\\*\")");
                File.Delete("Sound.zip");
            }
            //初期化開始
            ColorMap[] colorChange = new ColorMap[] { new ColorMap() };
            colorChange[0].OldColor = Color.Black;
            colorChange[0].NewColor = Color.Transparent;
            ia.SetRemapTable(colorChange);

            int c = config_display.Views.Count();
            if (c == 1)
                ProG_view_Delete.Enabled = false;
            if (c == 9)
                ProG_view_Add.Enabled = false;
            ProG_view_Copy.Enabled = c > ProG_view_CopyNum.Value;
            //初期化完了
            ExeLog($"[CtrlForm_Load]初回取得中...");
            InfoText0.Text = "<初回取得中...>WorldQuakeViewer";
            for (int i = 0; i < config.Datas.Count(); i++)
                foreach (int time in config.Datas[i].GetTimes)//2個じゃない可能性もなくはないため
                    if (0 <= time && time < 60)
                    {
                        await Get((DataAuthor)i);
                        continue;
                    }
            for (int i = 1; i < config.Views.Count(); i++)
                Open(i);//起動したとき表示されない時がある

            GetTimer.Interval = 10000 - DateTime.Now.Millisecond;
            GetTimer.Enabled = true;
            InfoText0.Text = $"WorldQuakeViewer v{version}";
            ExeLog($"[CtrlForm_Load]起動処理完了 約10秒後に通常取得を開始します。");
            noFirst = true;
            ConfigNoFirstCheck.Checked = false;
        }

        /// <summary>
        /// 設定を反映させます。
        /// </summary>
        public void ConfigReload()
        {
            config_display = (Config_Display)config;
            ProG_pro.SelectedObject = config_display.Datas;
            ProG_view.SelectedObject = config_display.Views;
            ProG_other.SelectedObject = config_display.Other;
            LogClearTimer.Interval = (int)config.Other.LogN.Normal_AutoDelete.TotalMilliseconds;
            ExeLog("[ConfigReload]設定を反映しました。");
        }

        private async void GetTimer_Tick(object sender, EventArgs e)
        {
            while (DateTime.Now.Millisecond > 800)
                await Task.Delay(10);
            GetTimer.Interval = 1000 - DateTime.Now.Millisecond;
            Console.WriteLine(DateTime.Now.ToString("ss.ffff"));
            try
            {
                for (int i = 0; i < DataAuthorCount; i++)
                    if (config.Datas[i].GetTimes[0] == DateTime.Now.Second)
                        await Get((DataAuthor)i);
                    else if (config.Datas[i].GetTimes[1] == DateTime.Now.Second)
                        await Get((DataAuthor)i);
            }
            catch (Exception ex)//設定がおかしいとき
            {
                ExeLog($"[GetTimer_Tick]エラー:{ex.Message}", true);
                LogSave(ex);
            }
        }

        /// <summary>
        /// 実行ログをテキストボックスに表示します。
        /// </summary>
        public static void ExeLogView(string text)
        {
            logTextBox.AppendText(text);
        }

        private void ConfigWebLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Ichihai1415/WorldQuakeViewer/wiki/config-info");
        }

        private void Config_Save_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < config_display.Views.Count(); i++)
            {
                if (config_display.Views[i].Data == ViewData.Null)
                {
                    MessageBox.Show($"表示[{i}]のDataが指定されていません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            config = (Config)config_display;
            File.WriteAllText("Setting\\config.json", JsonConvert.SerializeObject(config, Formatting.Indented));
            for (int i = 1; i < config.Views.Count(); i++)
                if (dataViews[i] != null)
                    ReDraw((DataAuthor)dataViews[i].dataAuthorN);
            ExeLog("[Config_Save_Click]設定を保存しました。");
            UpdtProEnableCtrl();
        }

        private void Config_Reset_Click(object sender, EventArgs e)
        {
            if (DialogOK("設定をリセットしてもよろしいですか？"))
            {
                config = new Config();
                config_display = (Config_Display)config;
                ProG_pro.SelectedObject = config_display.Datas;
                ProG_view.SelectedObject = config_display.Views;
                ProG_other.SelectedObject = config_display.Other;
                File.WriteAllText("Setting\\config.json", JsonConvert.SerializeObject(config, Formatting.Indented));
            }
        }

        private void ProG_view_Add_Click(object sender, EventArgs e)
        {
            int c = config_display.Views.Count();
            List<Config_Display.View_> tmp = config_display.Views.ToList();
            tmp.Add((Config_Display.View_)new Config.View_());
            config_display.Views = tmp.ToArray();
            ProG_view.SelectedObject = config_display.Views;
            c++;
            if (c == 10)
                ProG_view_Add.Enabled = false;
            if (c != 2)
                ProG_view_Delete.Enabled = true;
            ProG_view_Copy.Enabled = c > ProG_view_CopyNum.Value;
        }

        private void ProG_view_Delete_Click(object sender, EventArgs e)
        {
            int c = config_display.Views.Count();
            List<Config_Display.View_> tmp = config_display.Views.ToList();
            tmp.RemoveAt(c - 1);
            config_display.Views = tmp.ToArray();
            ProG_view.SelectedObject = config_display.Views;
            c--;
            if (c != 9)
                ProG_view_Add.Enabled = true;
            if (c == 1)
                ProG_view_Delete.Enabled = false;
            ProG_view_Copy.Enabled = c > ProG_view_CopyNum.Value;
        }

        private void ProG_view_Copy_Click(object sender, EventArgs e)
        {
            config_display.Views[(int)ProG_view_CopyNum.Value] = config_display.Views[0];
            ProG_view.SelectedObject = config_display.Views;
        }

        private void ProG_view_CopyNum_ValueChanged(object sender, EventArgs e)
        {
            ProG_view_Copy.Enabled = config_display.Views.Count() > ProG_view_CopyNum.Value;
        }

        private void CtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                if (!DialogOK("ソフトを終了してもよろしいですか？"))
                {
                    e.Cancel = true;
                    return;
                }
            if (config.Other.LogN.Normal_AutoSave)
                LogSave(LogKind.Exe, exeLogs.ToString());
        }

        private void LogClearTimer_Tick(object sender, EventArgs e)
        {
            if (config.Other.LogN.Normal_AutoSave)
                LogSave(LogKind.Exe, exeLogs.ToString());
            exeLogs = new StringBuilder();
            ExeLog("[LogClearTimer_Tick]動作ログをクリアしました。");
            logTextBox.Text = "";
        }

        private void ProG_view_Open_Click(object sender, EventArgs e)
        {
            Open((int)ProG_view_OpenNum.Value);
        }

        private void ProG_view_OpenAll_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < config.Views.Count(); i++)
                Open(i);
        }

        /// <summary>
        /// データ表示Formを開きます。
        /// </summary>
        /// <param name="num">表示インデックス</param>
        private void Open(int num)
        {
            if (config.Views.Count() > num)
            {
                if (dataViews[num] == null)
                {
                    ExeLog($"[Open]画面[{num}]を構成中...");
                    dataViews[num] = new DataView(num, config.Views[num].Data);
                    dataViews[num].Show();
                    ExeLog($"[Open]画面[{num}]を表示しました。");
                }
                else if (dataViews[num].showing)
                {
                    ExeLog($"[Open]画面[{num}]はすでに表示されています。再表示します。");
                    dataViews[num].askClose = false;
                    dataViews[num].Close();
                    Open(num);
                }
                else
                {
                    ExeLog($"[Open]画面[{num}]を構成中...");
                    dataViews[num] = new DataView(num, config.Views[num].Data);
                    dataViews[num].Show();
                    ExeLog($"[Open]画面[{num}]を表示しました。");
                }
            }
            else
                ExeLog($"[Open]画面[{num}]は設定されていません。");
        }

        private void InfoPageLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Ichihai1415/WorldQuakeViewer/wiki");
        }

        private void IntConv_Conv1_Click(object sender, EventArgs e)//2=>1
        {
            try
            {
                double afterValue = IntConvert((double)IntConv_NumBox2.Value, IntConv_ComBox2.SelectedIndex, IntConv_ComBox1.SelectedIndex);
                if (afterValue == double.NaN)
                    return;
                IntConv_NumBox1.Value = (decimal)afterValue;
            }
            catch (Exception ex)
            {
                ExeLog($"[IntConv_Conv1_Click]エラー:{ex.Message}", true);
                MessageBox.Show(topMost, "変換に失敗しました。値を確認してください。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IntConv_Conv2_Click(object sender, EventArgs e)//1=>2
        {
            try
            {
                double afterValue = IntConvert((double)IntConv_NumBox1.Value, IntConv_ComBox1.SelectedIndex, IntConv_ComBox2.SelectedIndex);
                if (afterValue == double.NaN)
                    return;
                IntConv_NumBox2.Value = (decimal)afterValue;
            }
            catch (Exception ex)
            {
                ExeLog($"[IntConv_Conv2_Click]エラー:{ex.Message}", true);
                MessageBox.Show(topMost, "変換に失敗しました。値を確認してください。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IntConv_Conv3_Click(object sender, EventArgs e)//3=>2
        {
            try
            {
                double afterValue = IntConvert((double)IntConv_NumBox3.Value, IntConv_ComBox3.SelectedIndex, IntConv_ComBox2.SelectedIndex);
                if (afterValue == double.NaN)
                    return;
                IntConv_NumBox2.Value = (decimal)afterValue;
            }
            catch (Exception ex)
            {
                ExeLog($"[IntConv_Conv3_Click]エラー:{ex.Message}", true);
                MessageBox.Show(topMost, "変換に失敗しました。値を確認してください。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IntConv_Conv4_Click(object sender, EventArgs e)//2=>3
        {
            try
            {
                double afterValue = IntConvert((double)IntConv_NumBox2.Value, IntConv_ComBox2.SelectedIndex, IntConv_ComBox3.SelectedIndex);
                if (afterValue == double.NaN)
                    return;
                IntConv_NumBox3.Value = (decimal)afterValue;
            }
            catch (Exception ex)
            {
                ExeLog($"[IntConv_Conv4_Click]エラー:{ex.Message}", true);
                MessageBox.Show(topMost, "変換に失敗しました。値を確認してください。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IntConv_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://qiita.com/Ichihai1415/items/2e14fc2356ec8e140291");
        }

        private void ConfigMerge_Select1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ConfigMerge_Select3.DataSource = null;
            ConfigMerge_Select3.Items.Clear();
            ConfigMerge_Select2.Value = 0;
            ConfigMerge_Select2.Enabled = true;
            switch (ConfigMerge_Select1.SelectedIndex)
            {
                case 0://処理
                    ConfigMerge_Select3.DataSource = Enum.GetValues(typeof(ConfigMerge_Select3_Data));
                    break;
                case 1://表示
                    ConfigMerge_Select3.DataSource = Enum.GetValues(typeof(ConfigMerge_Select3_View));
                    break;
                case 2://その他
                    ConfigMerge_Select3.DataSource = Enum.GetValues(typeof(ConfigMerge_Select3_Other));
                    ConfigMerge_Select2.Enabled = false;
                    break;
            }
        }

        private void ConfigMerge_Read_Click(object sender, EventArgs e)
        {
            try
            {
                string askText = "選択したものは設定したものとは異なるようです。続行してもよろしいですか？";
                int i = (int)ConfigMerge_Select2.Value;
                if (i == -1)
                {
                    if (ConfigMerge_Select1.SelectedIndex == 0)
                    {
                        if (DialogOK("選択した項目について、すべてのデータ元に反映させます。よろしいですか？"))
                            ConfigMerge_Read_Click_Auto(sender, e);
                    }
                    else
                        MessageBox.Show("-1はDataのみで有効です。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ExeLog("[ConfigMerge_Read_Click]読み込み開始");
                string jsonText_ = File.ReadAllText(ConfigMerge_PathBox.Text);
                string head_ = jsonText_.Split('\n')[0];
                string[] head = head_.Split(',');

                string version = head.Where(x => x.StartsWith("version")).Count() == 0 ? "null" : head.Where(x => x.StartsWith("version")).First().Split(':')[1];
                string type = head.Where(x => x.StartsWith("type")).Count() == 0 ? "null" : head.Where(x => x.StartsWith("type")).First().Split(':')[1];
                ExeLog($"[ConfigMerge_Read_Click]version:{version},type:{type}");

                if (CtrlForm.version != version)
                    if (!DialogOK($"このバージョンは設定したバージョンとは異なるようです。続行してもよろしいですか？\n現在:{CtrlForm.version} 設定:{version}"))
                    {
                        ExeLog("[ConfigMerge_Read_Click]取り消されました。");
                        return;
                    }
                string jsonText = jsonText_.Split('\n')[1];
                switch (ConfigMerge_Select1.SelectedIndex)
                {
                    case 0:
                        switch ((ConfigMerge_Select3_Data)ConfigMerge_Select3.SelectedIndex)
                        {
                            case ConfigMerge_Select3_Data.Update:
                                if ($"config.Datas[{i}].Update" != type)
                                    if (!DialogOK($"{askText}\n選択:config.Datas[{i}].Update 設定:{type}"))
                                    {
                                        ExeLog("[ConfigMerge_Read_Click]取り消されました。");
                                        return;
                                    }
                                config.Datas[i].Update = JsonConvert.DeserializeObject<Config.Data_.Update_>(jsonText);
                                break;
                            case ConfigMerge_Select3_Data.Sound:
                                if ($"config.Datas[{i}].Sound" != type)
                                    if (!DialogOK($"{askText}\n選択:config.Datas[{i}].Sound 設定:{type}"))
                                    {
                                        ExeLog("[ConfigMerge_Read_Click]取り消されました。");
                                        return;
                                    }
                                config.Datas[i].Sound = JsonConvert.DeserializeObject<Config.Data_.Sound_>(jsonText);
                                break;
                            case ConfigMerge_Select3_Data.Bouyomi:
                                if ($"config.Datas[{i}].Bouyomi" != type)
                                    if (!DialogOK($"{askText}\n選択:config.Datas[{i}].Bouyomi 設定:{type}"))
                                    {
                                        ExeLog("[ConfigMerge_Read_Click]取り消されました。");
                                        return;
                                    }
                                config.Datas[i].Bouyomi = JsonConvert.DeserializeObject<Config.Data_.Bouyomi_>(jsonText);
                                break;
                            case ConfigMerge_Select3_Data.Socket:
                                if ($"config.Datas[{i}].Socket" != type)
                                    if (!DialogOK($"{askText}\n選択:config.Datas[{i}].Socket 設定:{type}"))
                                    {
                                        ExeLog("[ConfigMerge_Read_Click]取り消されました。");
                                        return;
                                    }
                                config.Datas[i].Socket = JsonConvert.DeserializeObject<Config.Data_.Socket_>(jsonText);
                                break;
                            case ConfigMerge_Select3_Data.Webhook:
                                if ($"config.Datas[{i}].Webhook" != type)
                                    if (!DialogOK($"{askText}\n選択:config.Datas[{i}].Webhook 設定:{type}"))
                                    {
                                        ExeLog("[ConfigMerge_Read_Click]取り消されました。");
                                        return;
                                    }
                                config.Datas[i].Webhook = JsonConvert.DeserializeObject<Config.Data_.Webhook_>(jsonText);
                                break;
                            case ConfigMerge_Select3_Data.LogE:
                                if ($"config.Datas[{i}].LogE" != type)
                                    if (!DialogOK($"{askText}\n選択:config.Datas[{i}].LogE 設定:{type}"))
                                    {
                                        ExeLog("[ConfigMerge_Read_Click]取り消されました。");
                                        return;
                                    }
                                config.Datas[i].LogE = JsonConvert.DeserializeObject<Config.Data_.LogE_>(jsonText);
                                break;
                            default:
                                throw new Exception($"ConfigMerge_Select3.SelectedIndex({ConfigMerge_Select3.SelectedIndex})がConfigMerge_Select3_Dataとして不正です。");
                        }
                        break;
                    case 1:
                        switch ((ConfigMerge_Select3_View)ConfigMerge_Select3.SelectedIndex)
                        {
                            case ConfigMerge_Select3_View.All:
                                if ($"config.Views[{i}]" != type.Replace($"[{i}]", ""))
                                    if (!DialogOK($"{askText}\n選択:config.Views[{i}] 設定:{type}"))
                                    {
                                        ExeLog("[ConfigMerge_Read_Click]取り消されました。");
                                        return;
                                    }
                                config.Views[i] = JsonConvert.DeserializeObject<Config.View_>(jsonText);
                                break;
                            case ConfigMerge_Select3_View.Color:
                                if ($"config.Views[{i}].Colors" != type.Replace($"[{i}]", ""))
                                    if (!DialogOK($"{askText}\n選択:config.Views[{i}].Colors 設定:{type}"))
                                    {
                                        ExeLog("[ConfigMerge_Read_Click]取り消されました。");
                                        return;
                                    }
                                config.Views[i].Colors = JsonConvert.DeserializeObject<Config.View_.Colors_>(jsonText);
                                break;
                            default:
                                throw new Exception($"ConfigMerge_Select3.SelectedIndex({ConfigMerge_Select3.SelectedIndex})がConfigMerge_Select3_Viewとして不正です。");
                        }
                        break;
                    case 2:
                        switch ((ConfigMerge_Select3_Other)ConfigMerge_Select3.SelectedIndex)
                        {
                            case ConfigMerge_Select3_Other.All:
                                if ($"config.Other" != type)
                                    if (!DialogOK($"{askText}\n選択:config.Other 設定:{type}"))
                                    {
                                        ExeLog("[ConfigMerge_Read_Click]取り消されました。");
                                        return;
                                    }
                                config.Other = JsonConvert.DeserializeObject<Config.Other_>(jsonText);
                                break;
                            case ConfigMerge_Select3_Other.LogN:
                                if ($"config.Other.LogN" != type)
                                    if (!DialogOK($"{askText}\n選択:config.Other.LogN 設定:{type}"))
                                    {
                                        ExeLog("[ConfigMerge_Read_Click]取り消されました。");
                                        return;
                                    }
                                config.Other.LogN = JsonConvert.DeserializeObject<Config.Other_.LogN_>(jsonText);
                                break;
                            default:
                                throw new Exception($"ConfigMerge_Select3.SelectedIndex({ConfigMerge_Select3.SelectedIndex})がConfigMerge_Select3_Otherとして不正です。");
                        }
                        break;
                    default:
                        throw new Exception($"ConfigMerge_Select1.SelectedIndex({ConfigMerge_Select1.SelectedIndex})が不正です。");
                }
                ExeLog("[ConfigMerge_Read_Click]読み込み完了");
                File.WriteAllText("Setting\\config.json", JsonConvert.SerializeObject(config, Formatting.Indented));
                ConfigReload();
                UpdtProEnableCtrl();
            }
            catch (Exception ex)
            {
                ExeLog($"[ConfigMerge_Read_Click]エラー:{ex.Message}", true);
                LogSave(ex);
                MessageBox.Show(topMost, "読み込みに失敗しました。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ConfigMerge_Read_ClickをDataの数ぶん実行します。ConfigMerge_Select2は自動で変わります。
        /// </summary>
        /// <param name="sender">ConfigMerge_Read_Clickを呼び出したときのもの</param>
        /// <param name="e">ConfigMerge_Read_Clickを呼び出したときのもの</param>
        private void ConfigMerge_Read_Click_Auto(object sender, EventArgs e)
        {
            for (int j = 0; j < DataAuthorCount; j++)
            {
                ConfigMerge_Select2.Value = j;
                ConfigMerge_Read_Click(sender, e);
            }
            ConfigMerge_Select2.Value = -1;
        }

        private void ConfigMerge_Write_Click(object sender, EventArgs e)
        {
            try
            {
                ExeLog("[ConfigMerge_Write_Click]書き込み開始");
                int i = (int)ConfigMerge_Select2.Value;
                string jsonText;
                if (i == -1)
                {
                    MessageBox.Show("-1は読み込みのみで有効です。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                switch (ConfigMerge_Select1.SelectedIndex)
                {
                    case 0:
                        switch ((ConfigMerge_Select3_Data)ConfigMerge_Select3.SelectedIndex)
                        {
                            case ConfigMerge_Select3_Data.Update:
                                jsonText = $"version:{version},type:config.Datas[{i}].Update\n{JsonConvert.SerializeObject(config.Datas[i].Update)}";
                                break;
                            case ConfigMerge_Select3_Data.Sound:
                                jsonText = $"version:{version},type:config.Datas[{i}].Sound\n{JsonConvert.SerializeObject(config.Datas[i].Sound)}";
                                break;
                            case ConfigMerge_Select3_Data.Bouyomi:
                                jsonText = $"version:{version},type:config.Datas[{i}].Bouyomi\n{JsonConvert.SerializeObject(config.Datas[i].Bouyomi)}";
                                break;
                            case ConfigMerge_Select3_Data.Socket:
                                jsonText = $"version:{version},type:config.Datas[{i}].Socket\n{JsonConvert.SerializeObject(config.Datas[i].Socket)}";
                                break;
                            case ConfigMerge_Select3_Data.Webhook:
                                jsonText = $"version:{version},type:config.Datas[{i}].Webhook\n{JsonConvert.SerializeObject(config.Datas[i].Webhook)}";
                                break;
                            case ConfigMerge_Select3_Data.LogE:
                                jsonText = $"version:{version},type:config.Datas[{i}].LogE\n{JsonConvert.SerializeObject(config.Datas[i].LogE)}";
                                break;
                            default:
                                throw new Exception($"ConfigMerge_Select3.SelectedIndex({ConfigMerge_Select3.SelectedIndex})がConfigMerge_Select3_Dataとして不正です。");
                        }
                        break;
                    case 1:
                        switch ((ConfigMerge_Select3_View)ConfigMerge_Select3.SelectedIndex)
                        {
                            case ConfigMerge_Select3_View.All:
                                jsonText = $"version:{version},type:config.Views[{i}]\n{JsonConvert.SerializeObject(config.Views[i])}";
                                break;
                            case ConfigMerge_Select3_View.Color:
                                jsonText = $"version:{version},type:config.Views[{i}].Colors\n{JsonConvert.SerializeObject(config.Views[i].Colors)}";
                                break;
                            default:
                                throw new Exception($"ConfigMerge_Select3.SelectedIndex({ConfigMerge_Select3.SelectedIndex})がConfigMerge_Select3_Viewとして不正です。");
                        }
                        break;
                    case 2:
                        switch ((ConfigMerge_Select3_Other)ConfigMerge_Select3.SelectedIndex)
                        {
                            case ConfigMerge_Select3_Other.All:
                                jsonText = $"version:{version},type:config.Other\n{JsonConvert.SerializeObject(config.Other)}";
                                break;
                            case ConfigMerge_Select3_Other.LogN:
                                jsonText = $"version:{version},type:config.Other.LogN\n{JsonConvert.SerializeObject(config.Other.LogN)}";
                                break;
                            default:
                                throw new Exception($"ConfigMerge_Select3.SelectedIndex({ConfigMerge_Select3.SelectedIndex})がConfigMerge_Select3_Otherとして不正です。");
                        }
                        break;
                    default:
                        throw new Exception($"ConfigMerge_Select1.SelectedIndex({ConfigMerge_Select1.SelectedIndex})が不正です。");
                }
                if (File.Exists(ConfigMerge_PathBox.Text))
                    if (!DialogOK("既にファイルが存在します。上書きしてもよろしいですか？", MessageBoxIcon.Warning))
                    {
                        ExeLog("[ConfigMerge_Write_Click]取り消されました。");
                        return;
                    }
                File.WriteAllText(ConfigMerge_PathBox.Text, jsonText);
                ExeLog("[ConfigMerge_Write_Click]書き込み完了");
            }
            catch (Exception ex)
            {
                ExeLog($"[ConfigMerge_Write_Click]エラー:{ex.Message}", true);
                LogSave(ex);
                MessageBox.Show(topMost, "書き込みに失敗しました。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigMerge_CurrentDir_Click(object sender, EventArgs e)
        {
            ConfigMerge_PathBox.Text = Path.GetFullPath("WorldQuakeViewer.exe").Replace("WorldQuakeViewer.exe", "");
        }

        private void ConfigNoFirstCheck_CheckedChanged(object sender, EventArgs e)
        {
            noFirst = !ConfigNoFirstCheck.Checked;
            ExeLog($"更新処理を{(noFirst ? "再開" : "停止")}しました。");
        }

        private void ProG_pro_ClearHist_Click(object sender, EventArgs e)
        {
            data_Other = new Dictionary<string, Data>();
            data_USGS = new Dictionary<string, Data>();
            data_EMSC = new Dictionary<string, Data>();
            data_GFZ = new Dictionary<string, Data>();
            data_EarlyEst = new Dictionary<string, Data>();
            data_All = new Dictionary<string, Data>();
            ExeLog("[ProG_pro_ClearHist_Click]履歴をクリアしました。");
            UpdtProEnableCtrl();
        }

        /// <summary>
        /// 更新処理を無効化し1分後に有効化します。
        /// </summary>
        public void UpdtProEnableCtrl()
        {
            ConfigNoFirstCheck.Checked = true;
            UpdtProEnabler.Enabled = false;
            UpdtProEnabler.Enabled = true;
        }

        private void UpdtProEnabler_Tick(object sender, EventArgs e)
        {
            ConfigNoFirstCheck.Checked = false;
        }

        private void MapGenOpen_Click(object sender, EventArgs e)
        {
            new MapGen().Show();
        }

        private async void Past_Open_Click(object sender, EventArgs e)
        {
            ExeLog("[Past_Open_Click]表示準備中...");
            pastConfig = (PastConfig)pastConfig_display;
            await Get_Past();
            if (pastDataView != null)
            {
                pastDataView.askClose = false;
                if (pastDataView.showing)
                    pastDataView.Close();
                pastDataView.Dispose();
                pastDataView = null;
            }
            pastDataView = new DataView(data_Past);
            pastDataView.Show();
            ExeLog("[Past_Open_Click]表示しました。");
        }

        private void Past_CurrentDir_Click(object sender, EventArgs e)
        {
            Past_PathBox.Text = Path.GetFullPath("WorldQuakeViewer.exe").Replace("WorldQuakeViewer.exe", "");
        }

        private void Past_Read_Click(object sender, EventArgs e)
        {
            try
            {
                ExeLog("[Past_Read_Click]読み込み開始");
                pastConfig = JsonConvert.DeserializeObject<PastConfig>(File.ReadAllText(Past_PathBox.Text));
                pastConfig_display = (PastConfig_Display)pastConfig;
                ProG_Past.SelectedObject = pastConfig_display;
                ExeLog("[Past_Read_Click]読み込み完了");
            }
            catch (Exception ex)
            {
                ExeLog($"[Past_Read_Click]エラー:{ex.Message}", true);
                LogSave(ex);
                MessageBox.Show(topMost, "読み込みに失敗しました。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Past_Write_Click(object sender, EventArgs e)
        {
            try
            {
                ExeLog("[Past_Write_Click]書き込み開始");
                pastConfig = (PastConfig)pastConfig_display;
                if (File.Exists(Past_PathBox.Text))
                    if (!DialogOK("既にファイルが存在します。上書きしてもよろしいですか？", MessageBoxIcon.Warning))
                    {
                        ExeLog("[Past_Write_Click]取り消されました。");
                        return;
                    }
                File.WriteAllText(Past_PathBox.Text, JsonConvert.SerializeObject(pastConfig));
                ExeLog("[Past_Write_Click]書き込み完了");
            }
            catch (Exception ex)
            {
                ExeLog($"[Past_Write_Click]エラー:{ex.Message}", true);
                LogSave(ex);
                MessageBox.Show(topMost, "書き込みに失敗しました。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
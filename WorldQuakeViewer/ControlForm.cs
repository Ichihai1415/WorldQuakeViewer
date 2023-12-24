using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldQuakeViewer.Properties;
using static WorldQuakeViewer.DataPro;
using static WorldQuakeViewer.Util_Class;
using static WorldQuakeViewer.Util_Conv;
using static WorldQuakeViewer.Util_Func;

namespace WorldQuakeViewer
{
    public partial class CtrlForm : Form
    {
        public static TextBox logTextBox;//staticでアクセスできるよう
        public static Config config = new Config();
        public static Config_Display config_display = new Config_Display();
        public static Dictionary<string, Data> data_Other = new Dictionary<string, Data>();
        public static Dictionary<string, Data> data_USGS = new Dictionary<string, Data>();
        public static Dictionary<string, Data> data_EMSC = new Dictionary<string, Data>();
        public static Dictionary<string, Data> data_GFZ = new Dictionary<string, Data>();
        public static Dictionary<string, Data> data_EarlyEst = new Dictionary<string, Data>();
        public static Dictionary<string, Data> data_All = new Dictionary<string, Data>();
        public static HttpClient client = new HttpClient();
        public static SoundPlayer player = null;
        public static string exeLogs = "";
        public static bool noFirst = false;
        public static int playLevel = 0;

        public static DataView[] dataViews = new DataView[] { null, null, null, null, null, null, null, null, null, null };

        public CtrlForm()
        {
            InitializeComponent();
            logTextBox = LogTextBox;
            InfoText0.Text = $"WorldQuakeViewer v{version}";
        }

        private async void CtrlForm_Load(object sender, EventArgs e)
        {
            ExeLog($"[CtrlForm_Load]起動しました。");
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
                            throw new Exception("バージョンが間違っています。製作者に報告してください。");
                    }
                }
                catch (Exception ex)
                {
                    ExeLog($"[CtrlForm_Load]エラー:{ex.Message}", true);
                    LogSave(LogKind.Error, ex.ToString());
                    if (MessageBox.Show($"設定の読み込みに失敗しました。OKを押すとバックアップしてリセットされます。({ex.Message})", "エラー", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
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
            }
            ConfigReload();
            LogClearTimer.Enabled = true;
            if (!config.Other.LogN.Normal_Enable)
                logTextBox.Text = "<動作ログを表示する場合、設定のその他のNormal_EnableをTrueにしてください>\n\r";

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

            ColorMap[] colorChange = new ColorMap[] { new ColorMap() };
            colorChange[0].OldColor = Color.Black;
            colorChange[0].NewColor = Color.Transparent;
            ia.SetRemapTable(colorChange);

            IntConv_ComBox1.SelectedIndex = 0;
            IntConv_ComBox2.SelectedIndex = 1;
            IntConv_ComBox3.SelectedIndex = 2;

            int c = config_display.Views.Count();
            if (c == 1)
                ProG_view_Delete.Enabled = false;
            if (c == 9)
                ProG_view_Add.Enabled = false;
            ProG_view_Copy.Enabled = c > ProG_view_CopyNum.Value;

            ExeLog($"[CtrlForm_Load]初回取得中...");
            for (int i = 0; i < config.Datas.Count(); i++)
                foreach (int time in config.Datas[i].GetTimes)//2個じゃない可能性もなくはないため
                    if (0 <= time && time < 60)
                    {
                        await Get((DataAuthor)i);
                        continue;
                    }
            for (int i = 1; i < config.Views.Count(); i++)
                Open(i);

            GetTimer.Interval = 10000 - DateTime.Now.Millisecond;
            GetTimer.Enabled = true;
            ExeLog($"[CtrlForm_Load]起動処理完了 約10秒後に通常取得を開始します。");
            noFirst = true;
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
                    if (config.Datas[i].GetTimes[0] == DateTime.Now.Second || config.Datas[i].GetTimes[1] == DateTime.Now.Second)
                        await Get((DataAuthor)i);
            }
            catch (Exception ex)//設定がおかしいとき
            {
                ExeLog($"[GetTimer_Tick]エラー:{ex.Message}", true);
                LogSave(LogKind.Error, ex.ToString());
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
            Process.Start("https://ichihai1415.github.io/programs/wqv/config-info.html");
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
        }

        private void Config_Reset_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show(topMost, "設定をリセットしてもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ans == DialogResult.Yes)
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
            if (config.Other.LogN.Normal_AutoSave)
                LogSave(LogKind.Exe, exeLogs);
        }

        private void LogClearTimer_Tick(object sender, EventArgs e)
        {
            if (config.Other.LogN.Normal_AutoSave)
                LogSave(LogKind.Exe, exeLogs);
            exeLogs = "";
            ExeLog("[LogClearTimer_Tick]動作ログをクリアしました。");
            logTextBox.Text = exeLogs;
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
                    ExeLog($"[Open]画面[{num}]はすでに表示されています。");
                    DialogResult res = MessageBox.Show(topMost, $"画面[{num}]はすでに表示されています。再試行を押すと閉じる要求を送信します。(確認画面が表示されるのでOKを押してください。)", "確認", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
                    switch (res)
                    {
                        case DialogResult.Retry:
                            dataViews[num].Close();
                            break;
                        case DialogResult.Ignore:
                            dataViews[num].Show();
                            ExeLog($"[Open]画面[{num}]を表示しました。強制的に開いたため一部の動作がおかしくなる可能性があります。");
                            break;
                    }
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
            Process.Start("https://ichihai1415.github.io/programs/wqv/");
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

        private void ConfigMarge_Select1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ConfigMarge_Select3.DataSource = null;
            ConfigMarge_Select3.Items.Clear();
            ConfigMarge_Select2.Value = 0;
            ConfigMarge_Select2.Enabled = true;
            switch (ConfigMarge_Select1.SelectedIndex)
            {
                case 0://処理
                    ConfigMarge_Select3.DataSource = Enum.GetValues(typeof(ConfigMarge_Select3_Data));
                    break;
                case 1://表示
                    ConfigMarge_Select3.DataSource = Enum.GetValues(typeof(ConfigMarge_Select3_View));
                    break;
                case 2://その他
                    ConfigMarge_Select3.DataSource = Enum.GetValues(typeof(ConfigMarge_Select3_Other));
                    ConfigMarge_Select2.Enabled = false;
                    break;
            }
        }

        private void ConfigMarge_Read_Click(object sender, EventArgs e)
        {

        }

        private void ConfigMarge_Write_Click(object sender, EventArgs e)
        {

        }
    }
}

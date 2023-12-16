using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WorldQuakeViewer.DataPro;
using static WorldQuakeViewer.Util_Class;
using static WorldQuakeViewer.Util_Func;

namespace WorldQuakeViewer
{
    public partial class CtrlForm : Form
    {
        public static TextBox logTextBox;
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
        public static Form topMost = new Form { TopMost = true };
        public static string exeLogs = "";
        public static bool noFirst = false;

        public CtrlForm()
        {
            InitializeComponent();
            logTextBox = LogTextBox;
        }

        private void CtrlForm_Load(object sender, EventArgs e)
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
                MessageBox.Show(topMost, $"WorldQuakeViewer v{version}へようこそ！OKを押すと開きます。README.mdを確認してください。", "WQV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TopMost = true;//いったん非アクティブになると後ろ行くから一時的に前に
                TopMost = false;
                Directory.CreateDirectory("Setting");
                File.WriteAllText("Setting\\config.json", JsonConvert.SerializeObject(config, Formatting.Indented));
                ExeLog($"[CtrlForm_Load]設定保存完了");
            }
            ConfigReload();
            LogClearTimer.Enabled = true;
            if (!config.Other.LogN.Normal_Enable)
                logTextBox.Text = "<動作ログを表示する場合、設定のその他のNormal_EnableをTrueにしてください>";
            ExeLog($"[CtrlForm_Load]起動処理完了");
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
            int c = config_display.Views.Count();
            if (c == 1)
                ProG_view_Delete.Enabled = false;
            if (c == 9)
                ProG_view_Add.Enabled = false;
            ProG_view_Copy.Enabled = c > ProG_view_CopyNum.Value;
            GetTimer.Interval = 2000 - DateTime.Now.Millisecond;
            GetTimer.Enabled = true;
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
                        Get((DataAuthor)i);
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
            config = (Config)config_display;
            File.WriteAllText("Setting\\config.json", JsonConvert.SerializeObject(config, Formatting.Indented));
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
    }
}

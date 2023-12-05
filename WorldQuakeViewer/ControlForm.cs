using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WorldQuakeViewer.Util_Class;

namespace WorldQuakeViewer
{
    public partial class CtrlForm : Form
    {
        public static Config config = new Config();
        public static Config_Display config_display = new Config_Display();

        public static Form topMost = new Form { TopMost = true };

        public CtrlForm()
        {
            InitializeComponent();
        }

        private void CtrlForm_Load(object sender, EventArgs e)
        {
            if (File.Exists("Setting\\config.json"))
                try
                {
                    config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Setting\\config.json"));
                    if (config.Version != version)//更新時必要な処置等あればここに
                    {
                        int[] nowVer = version.Split('.').Select(n => int.Parse(n.Replace("α", "-"))).ToArray();
                        int[] setVer = config.Version.Split('.').Select(n => int.Parse(n.Replace("α", "-"))).ToArray();
                        if (setVer[1] <= 1 && setVer[2] <= 1)//x.1.2未満の場合
                            throw new Exception("バージョンが間違っています。製作者に報告してください。");
                    }
                    config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Setting\\config.json"));
                }
                catch (Exception ex)
                {
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
            }

            config_display = (Config_Display)config;
            ProG_pro.SelectedObject = config_display.Datas;
            ProG_view.SelectedObject = config_display.Views;
            ProG_other.SelectedObject = config_display.LogN;
            if (config_display.Views.Count() == 1)
                ProG_view_Delete.Enabled = false;
            if (config_display.Views.Count() == 9)
                ProG_view_Add.Enabled = false;


            File.WriteAllText("Setting\\config.json", JsonConvert.SerializeObject(config, Formatting.Indented));


            GetTimer.Interval = 2000 - DateTime.Now.Millisecond;
            GetTimer.Enabled=true;
        }

        private async void GetTimer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine($"{DateTime.Now:ss.ffff}->");
            while (DateTime.Now.Millisecond > 800)
                await Task.Delay(10);
            GetTimer.Interval = 1000 - DateTime.Now.Millisecond;
            //Console.WriteLine($"{DateTime.Now:ss.ffff} n:{GetTimer.Interval}");
            //Console.WriteLine(config.Views.Count());



        }

        private void ConfigWebLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ichihai1415.github.io/programs/wqv/config-info.html");
        }

        private void Config_Save_Click(object sender, EventArgs e)
        {

        }

        private void Config_Reset_Click(object sender, EventArgs e)
        {

        }

        private void ProG_view_Add_Click(object sender, EventArgs e)
        {
            int n = config_display.Views.Count();
            List<Config_Display.View_> tmp = config_display.Views.ToList();
                tmp.Add((Config_Display.View_)new Config.View_());
            config_display.Views = tmp.ToArray();
            ProG_view.SelectedObject = config_display.Views;
            ProG_view.Refresh();
            Console.WriteLine(config_display.Views.Count());
            if (n == 9)//ここ時点で配列は+1されている//10
                ProG_view_Add.Enabled = false;
            if (n != 1)//2
                ProG_view_Delete.Enabled = true;
        }

        private void ProG_view_Delete_Click(object sender, EventArgs e)
        {
            int n = config_display.Views.Count();
            List<Config_Display.View_> tmp = config_display.Views.ToList();
            tmp.RemoveAt(n - 1);
            config_display.Views = tmp.ToArray();
            ProG_view.SelectedObject = config_display.Views;
            if (n != 10)//ここ時点で配列は-1されている//9
                ProG_view_Add.Enabled = true;
            if (n == 2)//1
                ProG_view_Delete.Enabled = false;
        }

        private void ProG_view_Copy_Click(object sender, EventArgs e)
        {

        }
    }
}

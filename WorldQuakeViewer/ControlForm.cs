using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static WorldQuakeViewer.Util_Class;

namespace WorldQuakeViewer
{
    public partial class CtrlForm : Form
    {
        public static Config config = new Config();

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
                MessageBox.Show(new Form { TopMost = true }, $"WorldQuakeViewer v{version}へようこそ！OKを押すと開きます。README.mdを確認してください。", "WQV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TopMost = true;//いったん非アクティブになると後ろ行くから一時的に前に
                TopMost = false;
                Directory.CreateDirectory("Setting");
                File.WriteAllText("Setting\\config.json", JsonConvert.SerializeObject(config, Formatting.Indented));
            }

            Config_Display config_display = (Config_Display)config;




            PropertyGrid_pro.SelectedObject = config_display.Datas;
            PropertyGrid_view.SelectedObject = config_display.Views;
            PropertyGrid_other.SelectedObject = config_display.LogN;





        }

        private void GetTimer_Tick(object sender, EventArgs e)
        {
            GetTimer.Interval = 1000 - DateTime.Now.Millisecond;
        }
    }
}

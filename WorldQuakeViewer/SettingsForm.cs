using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldQuakeViewer.Properties;

namespace WorldQuakeViewer
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingSave_Click(object sender, EventArgs e)
        {




            Settings.Default.Save();
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            File.Copy(Config.FilePath, "UserSetting.xml", true);
            MessageBox.Show("設定を保存しました。設定ウィンドウを閉じると設定が再読み込みされます。", "WQV_setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SettingReset_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("リセットしてもよろしいですか？\nリセットすると設定画面を開き直します。", "WQV_setting", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Result == DialogResult.Yes)
            {
                Settings.Default.Reset();
                SettingsForm Setting = new SettingsForm();
                Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                if (File.Exists("UserSetting.xml"))
                    File.Delete("UserSetting.xml");
                if (File.Exists(Config.FilePath))
                    File.Delete(Config.FilePath);
                Setting.Show();
                Close();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void SettingsForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            try
            {
                Process.Start("notepad.exe", "UserSetting.readme.md");
            }
            catch
            {

            }
        }

        private void Tab_Sound_Test_M45_Click(object sender, EventArgs e)
        {

        }

        private void Tab_Sound_Test_M60_Click(object sender, EventArgs e)
        {

        }

        private void Tab_Sound_Test_M80_Click(object sender, EventArgs e)
        {

        }

        private void Tab_Sound_Test_M45u_Click(object sender, EventArgs e)
        {

        }

        private void Tab_Sound_Test_M60u_Click(object sender, EventArgs e)
        {

        }

        private void Tab_Sound_Test_M80u_Click(object sender, EventArgs e)
        {

        }

        private void Tab_Yomi_Test_Click(object sender, EventArgs e)
        {

        }
    }
}

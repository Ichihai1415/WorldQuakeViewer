using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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

        }

        private void SettingReset_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("リセットしてもよろしいですか？\nリセットすると設定画面を開き直します。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Result == DialogResult.Yes)
            {
                Settings.Default.Reset();
                SettingsForm Setting = new SettingsForm();
                Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                if (File.Exists("setting.xml"))
                    File.Delete("setting.xml");
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

        }
    }
}

using CoreTweet;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Version.Text = "WorldQuakeViewer v" + Settings.Default.Version;
            Tab_View_HideHist.Checked = Settings.Default.Display_HideHistory;
            Tab_View_HideMap.Checked = Settings.Default.Display_HideHistoryMap;
            Tab_View_LatLonDecimal.Checked = Settings.Default.Text_LatLonDecimal;
            Tab_Sound_M45.Checked = Settings.Default.Sound_45_Enable;
            Tab_Sound_M60.Checked = Settings.Default.Sound_60_Enable;
            Tab_Sound_M80.Checked = Settings.Default.Sound_80_Enable;
            Tab_Sound_Updt.Checked = Settings.Default.Sound_Updt_Enable;
            Tab_Yomi_Enable.Checked = Settings.Default.Bouyomichan_Enable;
            Tab_Yomi_Host.Text = Settings.Default.Bouyomichan_Host;
            Tab_Yomi_Port.Value = Settings.Default.Bouyomichan_Port;
            Tab_Yomi_LowerMag.Value = (decimal)Settings.Default.Bouyomichan_LowerMagnitudeLimit;
            Tab_Yomi_LowerMMI.Value = (decimal)Settings.Default.Bouyomichan_LowerMMILimit;
            Tab_Yomi_LowerAnd.Checked = Settings.Default.Bouyomichan_Lower_And;
            Tab_Yomi_Voice.Value = Settings.Default.Bouyomichan_Voice;
            Tab_Yomi_Speed.Value = Settings.Default.Bouyomichan_Speed;
            Tab_Yomi_Tone.Value = Settings.Default.Bouyomichan_Tone;
            Tab_Yomi_Volume.Value = Settings.Default.Bouyomichan_Volume;
            Tab_Tweet_Enable.Checked = Settings.Default.Tweet_Enable;
            Tab_Tweet_LowerMag.Value = (decimal)Settings.Default.Tweet_LowerMagnitudeLimit;
            Tab_Tweet_LowerMMI.Value = (decimal)Settings.Default.Tweet_LowerMMILimit;
            Tab_Tweet_LowerAnd.Checked = Settings.Default.Tweet_Lower_And;
            Tab_Tweet_ConKey.Text = Settings.Default.Tweet_ConsumerKey;
            Tab_Tweet_ConSec.Text = Settings.Default.Tweet_ConsumerSecret;
            Tab_Tweet_AccTok.Text = Settings.Default.Tweet_AccessToken;
            Tab_Tweet_AccSec.Text = Settings.Default.Tweet_AccessSecret;
            Tab_Socket_Enable.Checked = Settings.Default.Socket_Enable;
            Tab_Socket_Host.Text = Settings.Default.Socket_Host;
            Tab_Socket_Port.Value = Settings.Default.Socket_Port;
            Tab_Socket_TextFormat.Text = Settings.Default.Socket_Text;
        }
        private void SettingSave_Click(object sender, EventArgs e)
        {
            Settings.Default.Display_HideHistory = Tab_View_HideHist.Checked;
            Settings.Default.Display_HideHistoryMap = Tab_View_HideMap.Checked;
            Settings.Default.Text_LatLonDecimal = Tab_View_LatLonDecimal.Checked;
            Settings.Default.Sound_45_Enable = Tab_Sound_M45.Checked;
            Settings.Default.Sound_60_Enable = Tab_Sound_M60.Checked;
            Settings.Default.Sound_80_Enable = Tab_Sound_M80.Checked;
            Settings.Default.Sound_Updt_Enable = Tab_Sound_Updt.Checked;
            Settings.Default.Bouyomichan_Enable = Tab_Yomi_Enable.Checked;
            Settings.Default.Bouyomichan_Host = Tab_Yomi_Host.Text;
            Settings.Default.Bouyomichan_Port = (int)Tab_Yomi_Port.Value;
            Settings.Default.Bouyomichan_LowerMagnitudeLimit = (double)Tab_Yomi_LowerMag.Value;
            Settings.Default.Bouyomichan_LowerMMILimit = (double)Tab_Yomi_LowerMMI.Value;
            Settings.Default.Bouyomichan_Lower_And = Tab_Yomi_LowerAnd.Checked;
            Settings.Default.Bouyomichan_Voice = (int)Tab_Yomi_Voice.Value;
            Settings.Default.Bouyomichan_Speed = (int)Tab_Yomi_Speed.Value;
            Settings.Default.Bouyomichan_Tone = (int)Tab_Yomi_Tone.Value;
            Settings.Default.Bouyomichan_Volume = (int)Tab_Yomi_Volume.Value;
            Settings.Default.Tweet_Enable = Tab_Tweet_Enable.Checked;
            Settings.Default.Tweet_LowerMagnitudeLimit = (double)Tab_Tweet_LowerMag.Value;
            Settings.Default.Tweet_LowerMMILimit = (double)Tab_Tweet_LowerMMI.Value;
            Settings.Default.Tweet_Lower_And = Tab_Tweet_LowerAnd.Checked;
            Settings.Default.Tweet_ConsumerKey = Tab_Tweet_ConKey.Text;
            Settings.Default.Tweet_ConsumerSecret = Tab_Tweet_ConSec.Text;
            Settings.Default.Tweet_AccessToken = Tab_Tweet_AccTok.Text;
            Settings.Default.Tweet_AccessSecret = Tab_Tweet_AccSec.Text;
            Settings.Default.Socket_Enable = Tab_Socket_Enable.Checked;
            Settings.Default.Socket_Host = Tab_Socket_Host.Text;
            Settings.Default.Socket_Port = (int)Tab_Socket_Port.Value;
            Settings.Default.Socket_Text = Tab_Socket_TextFormat.Text;
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

        private void SettingsForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            try
            {
                Process.Start("notepad.exe", "UserSetting.readme.md");
            }
            catch (Exception ex)
            {
                DialogResult Result = MessageBox.Show($"UserSetting.readme.mdを開けませんでした。({ex.Message})\nブラウザで表示しますか?", "WQV_help", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (Result == DialogResult.Yes)
                {
                    Process.Start("https://github.com/Ichihai1415/WorldQuakeViewer/blob/main/UserSetting.readme.md");
                }
            }
        }

        private void Tab_Sound_Test_M45_Click(object sender, EventArgs e)
        {
            MainForm.Sound("M45.wav");
        }

        private void Tab_Sound_Test_M60_Click(object sender, EventArgs e)
        {
            MainForm.Sound("M60.wav");
        }

        private void Tab_Sound_Test_M80_Click(object sender, EventArgs e)
        {
            MainForm.Sound("M80.wav");
        }

        private void Tab_Sound_Test_M45u_Click(object sender, EventArgs e)
        {
            MainForm.Sound("M45u.wav");
        }

        private void Tab_Sound_Test_M60u_Click(object sender, EventArgs e)
        {
            MainForm.Sound("M60u.wav");
        }

        private void Tab_Sound_Test_M80u_Click(object sender, EventArgs e)
        {
            MainForm.Sound("M80u.wav");
        }

        private void Tab_Yomi_Test_Click(object sender, EventArgs e)
        {
            Tab_Yomi_Test.Enabled = false;
            try
            {
                byte[] Message = Encoding.UTF8.GetBytes("WorldQuakeViewer 棒読みちゃん送信テスト");
                int Length = Message.Length;
                using (TcpClient TcpClient = new TcpClient(Settings.Default.Bouyomichan_Host, Settings.Default.Bouyomichan_Port))
                using (NetworkStream NetworkStream = TcpClient.GetStream())
                using (BinaryWriter BinaryWriter = new BinaryWriter(NetworkStream))
                {
                    BinaryWriter.Write(0);
                    BinaryWriter.Write(Settings.Default.Bouyomichan_Speed);
                    BinaryWriter.Write(Settings.Default.Bouyomichan_Tone);
                    BinaryWriter.Write(Settings.Default.Bouyomichan_Volume);
                    BinaryWriter.Write(Settings.Default.Bouyomichan_Voice);
                    BinaryWriter.Write(0);
                    BinaryWriter.Write(Message.Length);
                    BinaryWriter.Write(Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"読み上げ指令の送信に失敗しました。({ex.Message})", "WQV_setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainForm.LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Setting,Bouyomichan Version:{Settings.Default.Version}\n{ex}");
            }
            Tab_Yomi_Test.Enabled = true;
        }

        private void Tab_Tweet_Test_Click(object sender, EventArgs e)
        {
            Tab_Tweet_Test.Enabled = false;
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                Tokens tokens = Tokens.Create(Tab_Tweet_ConKey.Text, Tab_Tweet_ConSec.Text, Tab_Tweet_AccTok.Text, Tab_Tweet_AccSec.Text);
                tokens.Statuses.UpdateAsync(new { status = "WorldQuakeViewer ツイート送信テスト" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ツイートの送信に失敗しました。({ex.Message})", "WQV_setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainForm.LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Setting,Tweet Version:{Settings.Default.Version}\n{ex}");
            }
            Tab_Tweet_Test.Enabled = true;
        }
        private void Tab_Socket_Test_Click(object sender, EventArgs e)
        {
            Tab_Socket_Test.Enabled = false;
            try
            {
                IPEndPoint IPEndPoint = new IPEndPoint(IPAddress.Parse(Settings.Default.Socket_Host), Settings.Default.Socket_Port);
                using (TcpClient TcpClient = new TcpClient())
                {
                    TcpClient.Connect(IPEndPoint);
                    using (NetworkStream NetworkStream = TcpClient.GetStream())
                    {
                        byte[] Bytes = new byte[4096];
                        Bytes = Encoding.UTF8.GetBytes("WorldQuakeViewer Socket送信テスト");
                        NetworkStream.Write(Bytes, 0, Bytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Socket送信に失敗しました。({ex.Message})", "WQV_setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainForm.LogSave("Log\\Error", $"Time:{DateTime.Now:yyyy/MM/dd HH:mm:ss} Location:Setting,Socket Version:{Settings.Default.Version}\n{ex}");
            }
            Tab_Socket_Test.Enabled = true;
        }

    }
}

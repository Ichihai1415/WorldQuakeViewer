using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using WorldQuakeViewer.Properties;

namespace WorldQuakeViewer
{
    public partial class UpdateDialog : Form
    {
        public UpdateDialog()
        {
            InitializeComponent();
        }
        private void Dialog_Load(object sender, EventArgs e)
        {
            Main.Text = $"新しいバージョンがリリースされています。\n現在バージョン:v{Settings.Default.NowVersion}　最新バージョン:v{Settings.Default.NewVersion}\n更新する場合、下のボタンを押してください。";
            if(Convert.ToDouble(Settings.Default.NowVersion) > Convert.ToDouble(Settings.Default.NewVersion))
            {
                Main.Text = $"このバージョンはリリースされていません。\n現在バージョン:v{Settings.Default.NowVersion} 公開最新バージョン:v{Settings.Default.NewVersion}";
                DLStart.Size = new Size(0, 0);
                Text = "WorldQuakeViewer：アップデート通知(開発中画面)";
            }
        }
        private void DLStart_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Main.Text = $"エラーが発生しました。\n手動ダウンロードをお試しください。\n\"Log/ErrorLog/Updater {DateTime.Now:yyyy/MM/dd}.txt\"の\n内容を製作者に報告してください。";
                try
                {
                    string ErrorText = File.ReadAllText($"Log\\ErrorLog\\Updater {DateTime.Now:yyyyMMdd}.txt") + "\n--------------------------------------------------\n" + ex;
                    File.WriteAllText($"Log\\ErrorLog\\Updater {DateTime.Now:yyyy/MM/dd}.txt", ErrorText);
                }
                catch
                {
                    File.WriteAllText($"Log\\ErrorLog\\Updater {DateTime.Now:yyyyMMdd}.txt", $"{ex}");
                }
                Process.Start("notepad.exe", $"Log\\ErrorLog\\Updater {DateTime.Now:yyyyMMdd}.txt");
            }
        }
    }
}

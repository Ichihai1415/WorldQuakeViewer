using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldQuakeViewer.Properties;

namespace WorldQuakeViewer
{
    public partial class Dialog : Form
    {
        public Dialog()
        {
            InitializeComponent();
        }
        private void Dialog_Load(object sender, EventArgs e)
        {
            Main.Text = $"新しいバージョンがリリースされています。\n現在バージョン:v{Settings.Default.NowVersion}　最新バージョン:v{Settings.Default.NewVersion}\n更新する場合、下のボタンを押してください。";
        }
        private void DLStart_Click(object sender, EventArgs e)
        {
            try
            {
                DLStart.Size = new Size(0, 0);
                WebClient WC = new WebClient();
                Main.Text = $"ダウンロードバージョン:v{Settings.Default.NewVersion}\nダウンロード中…";
                WC.DownloadFile($"https://github.com/Project-S-31415/WorldQuakeViewer/releases/download/WorldQuakeViewer{Settings.Default.NewVersion}/WorldQuakeViewer.v{Settings.Default.NewVersion}.zip", $"Updates\\_temp.zip");
                Main.Text += "\nダウンロード終了\n展開中…:";
                ZipFile.ExtractToDirectory("Updates\\_temp.zip", $"Updates\\v{Settings.Default.NewVersion}");
                Main.Text += "\n展開終了";
                File.Delete("Updates\\_temp.zip");
                Main.Text = $"DL・解凍が完了しました。\n\"v{Settings.Default.NewVersion}\"の中を\n現在の実行フォルダに上書きしてください。\n「終了」を押すと終了します";
                string Directory = Path.GetFullPath("WorldQuakeViewerUpdater.exe").Replace("\\WorldQuakeViewerUpdater.exe", "");
                Process.Start("explorer.exe", Directory);
                Process.Start("explorer.exe", $"{Directory}\\Updates\\v{Settings.Default.NewVersion}");
            }
            catch (IOException ex)
            {
                Main.Text = $"エラーが発生しました。\n既にファイルがある可能性があります。";
                File.WriteAllText($"Log\\ErrorLog\\UpdaterError {DateTime.Now:yyyy-MM-dd}.txt", $"{ex}");
                Process.Start("notepad.exe", $"Log\\ErrorLog\\UpdaterError {DateTime.Now:yyyy-MM-dd}.txt");
                string Directory = Path.GetFullPath("WorldQuakeViewerUpdater.exe").Replace("\\WorldQuakeViewerUpdater.exe", "");
                Process.Start("explorer.exe", $"{Directory}\\Updates\\v{Settings.Default.NewVersion}");
            }
        }


    }
}

using System;
using System.Windows.Forms;
using WorldQuakeViewer.Properties;

namespace WorldQuakeViewer
{
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
        }
        private void Message_Load(object sender, EventArgs e)
        {
            MessageVersion.Text = $"v{Settings.Default.NowVersion}";
            LatestMessageVersion = MessageVersion.Text;
            string[] Messages = Settings.Default.Message.Split('*');
            MainText.Text = Messages[Convert.ToInt32(Convert.ToDouble(MessageVersion.Text.Remove(0, 1)) * 10)].Replace(MessageVersion.Text, "メッセージバージョン:");
        }
        private void View_Tick(object sender, EventArgs e)
        {
            if (LatestMessageVersion != MessageVersion.Text)
            {
                LatestMessageVersion = MessageVersion.Text;
                string[] Messages = Settings.Default.Message.Split('*');
                MainText.Text = Messages[Convert.ToInt32(Convert.ToDouble(MessageVersion.Text.Remove(0,1)) * 10)].Replace(MessageVersion.Text, "メッセージバージョン:");
            }
        }
        public string LatestMessageVersion = "";
    }
}

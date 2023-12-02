using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using static WorldQuakeViewer.Util_Class;

namespace WorldQuakeViewer
{
    public partial class CtrlForm : Form
    {
        public CtrlForm()
        {
            InitializeComponent();
        }

        private void CtrlForm_Load(object sender, EventArgs e)
        {
            Config config = new Config();
            string st = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText("config.json", st);
        }
    }
}

using System;
using System.Windows.Forms;

namespace WorldQuakeViewer
{
    public partial class DataView : Form
    {
        readonly ViewData dataSource = ViewData.Null;

        public DataView(ViewData ds)
        {
            dataSource = ds;
            InitializeComponent();
            Text = $"WorldQuakeViewer - {dataSource}";
        }

        private void DataView_Load(object sender, EventArgs e)
        {

        }

        public void Draw()
        {

        }

        private void DataView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ok = MessageBox.Show("閉じてもいいですか？メイン画面から再表示できます。", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ok == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}

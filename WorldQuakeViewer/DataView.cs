using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorldQuakeViewer
{
    public partial class DataView : Form
    {
        readonly ViewData vd = ViewData.Null;

        public DataView(ViewData viewData)
        {
            InitializeComponent();

            vd = viewData;
            Text = $"WorldQuakeViewer - {vd}";
            switch((int)vd%10)
            {
                case 1:
                    ClientSize = new Size(400, 100);
                    break;
                case 2:
                    ClientSize = new Size(400, 500);
                    break;
                case 3:
                    ClientSize = new Size(800, 400);
                    break;
            }










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

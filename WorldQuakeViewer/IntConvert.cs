using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WorldQuakeViewer
{
    public partial class IntConvert : Form
    {
        public IntConvert()
        {
            InitializeComponent();
        }

        private void ExampleSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://qiita.com/Ichihai1415/items/2e14fc2356ec8e140291");
        }

        private void MMItoPGV_Click(object sender, EventArgs e)
        {
            try
            {
                double MMI = (double)MMIv.Value;
                if (MMI < 4.4)
                    PGVv.Value = (decimal)Math.Pow(10, (MMI - 3.5) / 1.5);
                else
                    PGVv.Value = (decimal)Math.Pow(10, (MMI - 2.5) / 3.155);
            }
            catch (Exception ex)
            {
                MessageBox.Show("変換に失敗しました。値を確認してください。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PGVtoJI_Click(object sender, EventArgs e)
        {
            try
            {
                double PGV = (double)PGVv.Value;
                if (PGV < 7)
                    JIv.Value = (decimal)(2.165 + 2.262 * Math.Log10(PGV));
                else
                    JIv.Value = (decimal)(2.002 + 2.603 * Math.Log10(PGV) - 0.213 * Math.Pow(Math.Log10(PGV), 2));
            }
            catch (Exception ex)
            {
                MessageBox.Show("変換に失敗しました。値を確認してください。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PGVtoMMI_Click(object sender, EventArgs e)
        {
            try
            {
                double PGV = (double)PGVv.Value;
                if (PGV < 4)
                    MMIv.Value = (decimal)(3.5 + 1.5 * Math.Log10(PGV));
                else
                    MMIv.Value = (decimal)(2.5 + 3.155 * Math.Log10(PGV));
            }
            catch (Exception ex)
            {
                MessageBox.Show("変換に失敗しました。値を確認してください。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void JItoPGV_Click(object sender, EventArgs e)
        {
            try
            {
                double JI = (double)JIv.Value;
                if (JI < 4)
                    PGVv.Value = (decimal)Math.Pow(10, (JI - 2.165) / 2.262);
                else//Microsoft math solverで計算 .0しないとintになって計算がずれる(int/int=intになる)
                    PGVv.Value = (decimal)Math.Pow(10, -2.0 * Math.Sqrt(-250.0 * JI / 213.0 + 8481313.0 / 725904.0) + 47.0 / 426.0 + 6);
            }
            catch (Exception ex)
            {
                MessageBox.Show("変換に失敗しました。値を確認してください。内容:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

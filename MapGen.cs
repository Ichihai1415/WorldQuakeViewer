using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldQuakeViewer.Properties;
using static WorldQuakeViewer.CtrlForm;
using static WorldQuakeViewer.Util_Func;

namespace WorldQuakeViewer
{
    public partial class MapGen : Form
    {
        public MapGen()
        {
            InitializeComponent();
        }

        private void MagGen_Load(object sender, EventArgs e)
        {
            try
            {
                List<ColorSettingList> colorSettings = new List<ColorSettingList>();
                if (!File.Exists("Setting\\map-color.csv"))
                    File.WriteAllText("Setting\\map-color.csv", Resources.map_color);
                Thread.Sleep(10);//↑の書き込みが間に合ってなくておかしいときがある?
                string[] color_ = File.ReadAllLines("Setting\\map-color.csv");
                foreach (string color__ in color_)
                {
                    string[] color = color__.Split(',');
                    if (color.Length != 5 || color[0] == "Name")
                        continue;
                    ColorSettingList colorSettingList = new ColorSettingList
                    {
                        Name = NameConvert[color[0]],
                        Alpha = int.Parse(color[1]),
                        Red = int.Parse(color[2]),
                        Green = int.Parse(color[3]),
                        Blue = int.Parse(color[4])
                    };
                    colorSettings.Add(colorSettingList);
                }
                ColorSettingListBindingSource.DataSource = colorSettings;
            }
            catch (Exception ex)
            {
                ExeLog($"[MagGen_Load]エラー:{ex.Message}", true);
                LogSave(ex);
                if (DialogOK($"色設定の読み込みに失敗しました。OKを押すとバックアップしてリセットされます。({ex.Message})", "エラー", MessageBoxIcon.Error))
                {
                    File.Copy("Setting\\map-color.csv", $"Setting\\map-color-backup-{DateTime.Now:yyyyMMddHHmmss}.csv", true);
                    File.WriteAllText("Setting\\map-color.csv", Resources.map_color);
                }
                else
                    Close();
            }
        }

        public Dictionary<string, string> NameConvert = new Dictionary<string, string>
        {
            { "ocean", "海" },
            { "land", "陸" },
            { "land-line", "海岸線" },
            { "plate-convergent", "プレート(収束/沈み込み)" },
            { "plate-transform", "プレート(すれ違い)" },
            { "plate-divergent", "プレート(拡散/拡大)" },
            { "graticules-normal", "緯経線(30度ごと)" },
            { "graticules-lat", "緯線(90度ごと)" },
            { "graticules-lon1", "経線(90度ごと)" },
            { "graticules-lon2", "経線(180度ごと)" }
        };

        public Dictionary<string, string> NameConvertReverse = new Dictionary<string, string>
        {
            { "海", "ocean" },
            { "陸", "land" },
            { "海岸線", "land-line" },
            { "プレート(収束/沈み込み)", "plate-convergent" },
            { "プレート(すれ違い)", "plate-transform" },
            { "プレート(拡散/拡大)", "plate-divergent" },
            { "緯経線(30度ごと)", "graticules-normal" },
            { "緯線(90度ごと)", "graticules-lat" },
            { "経線(90度ごと)", "graticules-lon1" },
            { "経線(180度ごと)", "graticules-lon2" }
        };

        private void ColorSetting_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
            MessageBox.Show("エラーが発生しました。値を確認してください。\n" + e.Exception.Message, "WQV - map", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ColorSetting_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int.TryParse(e.FormattedValue.ToString(), out int value);
            if (value < 0 || value > 255)
            {
                MessageBox.Show("値は0から255の間である必要があります。", "WQV - map", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void LinkNaturalEarth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.naturalearthdata.com/");
        }

        private void LinkPlate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/fraxen/tectonicplates");
        }

        Bitmap Map;

        private async void Draw_Click(object sender, EventArgs e)//todo:asyncをどうにかする
        {
            try
            {
                Map = new Bitmap(5400, 1800);
                Text2.Text = "csv保存中…";
                await Task.Delay(1);//これがあると文字がちゃんと変わる
                string csv = "Name,Alpha,Red,Green,Blue\n";
                int[,] colors = new int[10, 4];
                int i = 0;
                foreach (DataGridViewRow row in ColorSetting.Rows)
                {
                    string colors_ = "";
                    for (int j = 0; j < 4; j++)
                    {
                        colors[i, j] = (int)row.Cells[j + 1].Value;
                        colors_ += "," + colors[i, j];
                    }
                    csv += NameConvertReverse[(string)row.Cells[0].Value] + colors_ + "\n";
                    i++;
                }
                File.WriteAllText("Setting\\map-color.csv", csv);

                Color col_ocn = Color.FromArgb(colors[0, 0], colors[0, 1], colors[0, 2], colors[0, 3]);
                Color col_lnd = Color.FromArgb(colors[1, 0], colors[1, 1], colors[1, 2], colors[1, 3]);
                Color col_l_l = Color.FromArgb(colors[2, 0], colors[2, 1], colors[2, 2], colors[2, 3]);
                Color col_p_c = Color.FromArgb(colors[3, 0], colors[3, 1], colors[3, 2], colors[3, 3]);
                Color col_p_t = Color.FromArgb(colors[4, 0], colors[4, 1], colors[4, 2], colors[4, 3]);
                Color col_p_d = Color.FromArgb(colors[5, 0], colors[5, 1], colors[5, 2], colors[5, 3]);
                Color col_g_n = Color.FromArgb(colors[6, 0], colors[6, 1], colors[6, 2], colors[6, 3]);
                Color col_gla = Color.FromArgb(colors[7, 0], colors[7, 1], colors[7, 2], colors[7, 3]);
                Color col_glo = Color.FromArgb(colors[8, 0], colors[8, 1], colors[8, 2], colors[8, 3]);
                Color col_gln = Color.FromArgb(colors[9, 0], colors[9, 1], colors[9, 2], colors[9, 3]);
                /*既定
                ocean,255,30,30,60
                land,255,100,100,150
                land-line,50,255,255,255
                plate-convergent,255,150,0,0
                plate-transform,255,0,150,0
                plate-divergent,255,0,0,150
                graticules-normal,100,255,255,255
                graticules-lat,200,255,0,0
                graticules-lon1,200,0,0,255
                graticules-lon2,200,0,0,255
                */

                if (!File.Exists("Resources\\ne_50m_land.json"))
                {
                    Text2.Text = "データダウンロード中…";
                    await Task.Delay(1);
                    string json_ = await client.GetStringAsync("https://raw.githubusercontent.com/Ichihai1415/WorldQuakeViewer/main/Resources/ne_50m_land.json");
                    Directory.CreateDirectory("Resources");
                    File.WriteAllText("Resources\\ne_50m_land.json", json_);
                    json_ = "";
                }
                Text2.Text = "地図描画中…";
                await Task.Delay(1);
                JObject json = JObject.Parse(File.ReadAllText("Resources\\ne_50m_land.json"));
                Bitmap baseMap = new Bitmap(3600, 1800);
                Graphics g = Graphics.FromImage(baseMap);
                g.Clear(col_ocn);
                using (GraphicsPath maps = new GraphicsPath())
                {
                    maps.StartFigure();
                    foreach (JToken json_1 in json.SelectToken("geometries"))
                    {
                        if ((string)json_1.SelectToken("type") == "Polygon")
                        {
                            List<Point> points = new List<Point>();
                            foreach (JToken json_2 in json_1.SelectToken("coordinates[0]"))
                                points.Add(new Point((int)(10d * ((double)json_2.SelectToken("[0]") + 180d)), (int)(10d * (90d - (double)json_2.SelectToken("[1]")))));
                            maps.AddPolygon(points.ToArray());
                        }
                        else
                        {
                            foreach (JToken json_2 in json_1.SelectToken("coordinates"))
                            {
                                List<Point> points = new List<Point>();
                                foreach (JToken json_3 in json_2.SelectToken("[0]"))
                                    points.Add(new Point((int)(10d * ((double)json_3.SelectToken("[0]") + 180d)), (int)(10d * (90d - (double)json_3.SelectToken("[1]")))));
                                maps.AddPolygon(points.ToArray());
                            }
                        }
                    }
                    g.FillPath(new SolidBrush(col_lnd), maps);
                    g.DrawPath(new Pen(col_l_l, 2), maps);
                }
                if (!File.Exists("Resources\\PB2002_steps.json"))
                {
                    Text2.Text = "データダウンロード中…";
                    await Task.Delay(1);
                    string json_ = await client.GetStringAsync("https://raw.githubusercontent.com/Ichihai1415/WorldQuakeViewer/main/Resources/PB2002_steps.json");
                    Directory.CreateDirectory("Resources");
                    File.WriteAllText("Resources\\PB2002_steps.json", json_);
                    json_ = "";
                }
                Text2.Text = "プレート境界描画中…";
                await Task.Delay(1);
                json = JObject.Parse(File.ReadAllText("Resources\\PB2002_steps.json"));
                foreach (JToken json_1 in json.SelectToken("features"))
                {
                    List<Point> points = new List<Point>();
                    foreach (JToken json_2 in json_1.SelectToken("geometry.coordinates"))
                        points.Add(new Point((int)(10d * ((double)json_2.SelectToken("[0]") + 180d)), (int)(10d * (90d - (double)json_2.SelectToken("[1]")))));
                    string type = (string)json_1.SelectToken("properties.STEPCLASS");
                    switch (type)
                    {
                        case "SUB"://収束境界
                            g.DrawLines(new Pen(col_p_c, 2), points.ToArray());//一つずつやらないとおかしくなる?
                            break;
                        case "OSR"://海洋拡大境界
                            g.DrawLines(new Pen(col_p_d, 2), points.ToArray());
                            break;
                        case "OTF"://海洋トランスフォーム断層
                            g.DrawLines(new Pen(col_p_t, 2), points.ToArray());
                            break;
                        case "OCB"://海洋収束境界
                            g.DrawLines(new Pen(col_p_c, 2), points.ToArray());
                            break;
                        case "CRB"://大陸拡大境界
                            g.DrawLines(new Pen(col_p_d, 2), points.ToArray());
                            break;
                        case "CTF"://大陸トランスフォーム断層
                            g.DrawLines(new Pen(col_p_t, 2), points.ToArray());
                            break;
                        case "CCB"://大陸収束境界
                            g.DrawLines(new Pen(col_p_c, 2), points.ToArray());
                            break;
                    }
                }

                Text2.Text = "緯経線描画中…";
                await Task.Delay(1);
                Pen border = new Pen(col_g_n, 4);
                Pen border_lon1 = new Pen(col_glo, 4);
                Pen border_lon2 = new Pen(col_gln, 8);
                Pen border_lat2 = new Pen(col_gla, 8);
                for (int x = 0; x <= 3600; x += 300)
                {
                    if (x == 0 || x == 1800 || x == 3600)
                        g.DrawLine(border_lon2, x, 0, x, 1800);
                    else if (x == 900 || x == 2700)
                        g.DrawLine(border_lon1, x, 0, x, 1800);
                    else
                        g.DrawLine(border, x, 0, x, 1800);
                }
                for (int y = 0; y <= 1800; y += 300)
                {
                    if (y == 900)
                        g.DrawLine(border_lat2, 0, y, 3600, y);
                    else
                        g.DrawLine(border, 0, y, 3600, y);
                }
                g.Dispose();

                Text2.Text = "画像準備中…";
                await Task.Delay(1);
                Graphics copyG = Graphics.FromImage(Map);
                copyG.DrawImage(baseMap, -900, 0);
                copyG.DrawImage(baseMap, 2700, 0);
                copyG.Dispose();
                Img.Image = Map;
                Text2.Text = "";
                Save.Enabled = true;
            }
            catch (Exception ex)
            {
                ExeLog($"[Draw_Click]エラー:{ex.Message}", true);
                LogSave(ex);
                MessageBox.Show("画像の描画に失敗しました。" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Map.Save($"Image\\map.png", ImageFormat.Png);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if (DialogOK("リセットしてもよろしいですか？\nリセットするとこの画面を開き直します"))
            {
                File.WriteAllText("Setting\\map-color.csv", Resources.map_color);
                new MapGen().Show();
                Close();
            }
        }
    }

    public class ColorSettingList
    {
        public string Name { get; set; }
        public int Alpha { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
    }
}

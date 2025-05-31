using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace MT
{
    public partial class Form2 : Form
    {
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        //private PictureBox pictureBoxxx;
        private Random random = new Random();

        private System.Windows.Forms.Timer timer;
        private int speed = 5;

        private static int TilesCount = 2;

        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private List<bool> pictureBoxesСlicked = new List<bool>();
        private List<Button> button_all = new List<Button>();
        public Form2()
        {
            InitializeComponent();

            List<List<int>> sp = new List<List<int>> { };
            List<List<int>> spp = new List<List<int>> { };
            while (sp.Count < 10)
            {
                int r1 = random.Next(0, TilesCount);
                int r2 = random.Next(0, 8);
                if (!spp.Contains(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80, r2 * (-100) - 200 }))
                {
                    sp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80, r2 * (-100) - 200 });
                    spp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80, r2 * (-100) - 200 });
                    spp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80 + 80, r2 * (-100) - 200 });
                    spp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80 - 80, r2 * (-100) - 200 });
                    spp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80, r2 * (-100) - 200 + 100 });
                    spp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80, r2 * (-100) - 200 - 100 });
                }
            }


            pictureBox1 = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(sp[0][0], sp[0][1]),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black,
            };
            pictureBox2 = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(sp[1][0], sp[1][1]),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black,
            };
            pictureBox3 = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(sp[2][0], sp[2][1]),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black,
            };
            pictureBox4 = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(sp[3][0], sp[3][1]),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black,
            };
            pictureBox5 = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(sp[4][0], sp[4][1]),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black,
            };
            pictureBox6 = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(sp[5][0], sp[5][1]),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black,
            };
            pictureBox7 = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(sp[6][0], sp[6][1]),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black,
            };
            pictureBox8 = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(sp[7][0], sp[7][1]),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black,
            };
            pictureBox9 = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(sp[8][0], sp[8][1]),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black,
                Visible = false
            };
            pictureBox10 = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(sp[9][0], sp[9][1]),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black,
                Visible = false
            };
            //pictureBoxxx = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(400, 400),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //    Visible = false
            //};
            this.Controls.Add(pictureBox1);
            this.Controls.Add(pictureBox2);
            this.Controls.Add(pictureBox3);
            this.Controls.Add(pictureBox4);
            this.Controls.Add(pictureBox5);
            this.Controls.Add(pictureBox6);
            this.Controls.Add(pictureBox7);
            this.Controls.Add(pictureBox8);
            this.Controls.Add(pictureBox9);
            this.Controls.Add(pictureBox10);
            pictureBoxes.Add(pictureBox1);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox4);
            pictureBoxes.Add(pictureBox5);
            pictureBoxes.Add(pictureBox6);
            pictureBoxes.Add(pictureBox7);
            pictureBoxes.Add(pictureBox8);
            pictureBoxes.Add(pictureBox9);
            pictureBoxes.Add(pictureBox10);
            button_all.Add(button1);
            button_all.Add(button2);
            button_all.Add(button3);
            button_all.Add(button4);
            button_all.Add(button5);
            button_all.Add(button6);
            button_all.Add(button7);
            button_all.Add(button8);
            for (int i = 0; i < pictureBoxesСlicked.Count; i++)
            {
                pictureBoxesСlicked[i] = false;
            }

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1; // Интервал в миллисекундах (20 раз в секунду)
            timer.Tick += Timer_Tick1;

            this.KeyDown += new KeyEventHandler(Key_Down);
            this.KeyPreview = true;
        }


        private void Timer_Tick1(object sender, EventArgs e)
        {
            // Увеличиваем позицию Y (движение вниз)
            //pictureBox1.Top += speed;
            List<List<int>> sp = new List<List<int>> { };
            List<List<int>> spp = new List<List<int>> { };
            while (sp.Count < pictureBoxes.Count)
            {
                int r1 = random.Next(0, TilesCount);
                int r2 = random.Next(0, 8);
                if (!spp.Contains(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80, r2 * (-100) - 200 }))
                {
                    sp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80, r2 * (-100) - 200 });
                    spp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80, r2 * (-100) - 200 });
                    spp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80 + 80, r2 * (-100) - 200 });
                    spp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80 - 80, r2 * (-100) - 200 });
                    spp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80, r2 * (-100) - 200 + 100 });
                    spp.Add(new List<int> { 80 * (int)((8 - TilesCount) / 2) + r1 * 80, r2 * (-100) - 200 - 100 });
                }
            }
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].Location = new Point(pictureBoxes[i].Location.X, pictureBoxes[i].Location.Y + speed);
            }
            // Остановка при достижении нижней границы формы

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                if (pictureBoxes[i].Location.Y >= 800)
                {
                    pictureBoxes[i].Visible = true;
                    pictureBoxes[i].Location = new Point(sp[i][0], sp[i][1]);
                }
            }
        }

        private void Click(PictureBox P)
        {
            P.Visible = false;
            //pictureBoxesСlicked[P.Location.X / 80] = true;
        }



        private void Key_Down(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("111");
            int X = 0;
            if (e.KeyCode == Keys.A)
            {
                X = 0;
                Console.Beep(5000, 25);
            }
            else if (e.KeyCode == Keys.S)
            {
                X = 1;
                Console.Beep(3500, 25);
            }
            else if (e.KeyCode == Keys.D)
            {
                X = 2;
                Console.Beep(3000, 25);
            }
            else if (e.KeyCode == Keys.F)
            {
                X = 3;
                Console.Beep(2500, 25);
            }
            else if (e.KeyCode == Keys.G)
            {
                X = 4;
                Console.Beep(2000, 25);
            }
            else if (e.KeyCode == Keys.H)
            {
                X = 5;
                Console.Beep(1500, 25);
            }
            else if (e.KeyCode == Keys.J)
            {
                X = 6;
                Console.Beep(1000, 25);
            }
            else if (e.KeyCode == Keys.K)
            {
                X = 7;
                Console.Beep(500, 25);
            }
            X *= 80;
            int Lose = 0;
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                if (pictureBoxes[i].Location.X == X)
                {
                    //MessageBox.Show("222");
                    if (pictureBoxes[i].Location.Y >= 500 && pictureBoxes[i].Location.Y < 800)
                    {
                        //MessageBox.Show("333");
                        pictureBoxes[i].Visible = false;
                        //Click(pictureBoxes[i]);
                        break;
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
            //pictureBox1.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer.Stop();
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].Visible = false;
            }
            for (int i = 0; i < button_all.Count; i++)
            {
                button_all[i].Visible = false;
            }
            label1.Visible = true;
            label2.Visible = true;
            button9.Visible = true;
            this.KeyPreview = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using Model;
//using Form1;

namespace MT
{
    public partial class Form2 : Form
    {
        //private PictureBox pictureBox1;
        //private PictureBox pictureBox2;
        //private PictureBox pictureBox3;
        //private PictureBox pictureBox4;
        //private PictureBox pictureBox5;
        //private PictureBox pictureBox6;
        //private PictureBox pictureBox7;
        //private PictureBox pictureBox8;
        //private PictureBox pictureBox9;
        //private PictureBox pictureBox10;
        //private PictureBox pictureBoxxx;
        private Random random = new Random();

        private System.Windows.Forms.Timer timer;
        private int speed = 100;

        private static int LinesCount = 3;
        //private static int LinesCount = Form.CountTracks;
        private static int TilesCount = (LinesCount * 2 + 4) + (1 + (int)(LinesCount / 5)) + (1 + (int)(LinesCount / 3.5)) + (1);
        //private static int TilesCount = 20;

        private static int invisiblematrix0 = 16 + 5;

        private List<Tile> Tiles = new List<Tile>();
        //private List<bool> pictureBoxesСlicked = new List<bool>();
        private List<Button> button_all = new List<Button>();
        private int[,] matrix = new int[invisiblematrix0 + 2, LinesCount + 2];
        private int TotalScore = 0;

        private JSON_SerializerList serializerJ = new JSON_SerializerList();


        public Form2(int f)
        {
            InitializeComponent();
            LinesCount = f;
            
            matrix = new int[invisiblematrix0 + 2, LinesCount + 2];
            //serializerJ.Serialize("top", f);
            //MessageBox.Show(LinesCount.ToString());
            label3.Text = TotalScore.ToString();
            List<List<int>> sp = new List<List<int>> { };


            TileWork Work = new TileWork(matrix, LinesCount, this);
            matrix = Work.Rmatrix;
            sp = Work.Rsp;
            Tiles = Work.RTiles;
            //int co = 0;

            //while (co < TilesCount - 1)
            //{
            //    int r1 = random.Next(1 + (5), invisiblematrix0 + 1);
            //    int r2 = random.Next(1, LinesCount + 1);
            //    if (matrix[r1, r2] == 0 && matrix[r1, r2] == 0 && matrix[r1, r2] == 0)
            //    {
            //        matrix[r1, r2] = 1;
            //        matrix[r1 - 1, r2] = 2;
            //        matrix[r1 + 1, r2] = 2;
            //        matrix[r1, r2 - 1] = 2;
            //        matrix[r1, r2 + 1] = 2;
            //        co += 1;
            //        //MessageBox.Show(co.ToString());
            //        sp.Add(new List<int> { 80 * (int)((8 - LinesCount) / 2) + (r2 - 1) * 80, (invisiblematrix0 - r1 + 1) * (-100) - 200 });
            //    }
            //}

            //int i = 0;
            //for (int j = 0; j < LinesCount * 2 + 4; i++, j++)
            //{
            //    Tiles.Add(new TileBase(sp[i][0], sp[i][1]));
            //    this.Controls.Add(Tiles[i].Box);
            //}
            //for (int j = 0; j < 1 + (int)(LinesCount / 5); j++, i++)
            //{
            //    Tiles.Add(new Tile2(sp[i][0], sp[i][1]));
            //    this.Controls.Add(Tiles[i].Box);
            //}
            //for (int j = 0; j < 1 + (int)(LinesCount / 3.5); j++, i++)
            //{
            //    Tiles.Add(new TileTrap(sp[i][0], sp[i][1]));
            //    this.Controls.Add(Tiles[i].Box);
            //}

            //if (true)
            //{
            //    while (true)
            //    {
            //        int r1 = 1;
            //        int r2 = random.Next(1, LinesCount + 1);
            //        if (matrix[r1 + 4, r2] != 2)
            //        {
            //            matrix[r1 - 1, r2] = 2;
            //            matrix[r1, r2] = 1;
            //            matrix[r1 + 1, r2] = 1;
            //            matrix[r1 + 2, r2] = 1;
            //            matrix[r1 + 3, r2] = 1;
            //            matrix[r1 + 4, r2] = 1;
            //            matrix[r1 + 5, r2] = 2;
            //            for (int ii = 1; ii <= 5; ii++)
            //            {
            //                for (int j = 0; j < matrix.GetLength(1); j++)
            //                {
            //                    if (matrix[ii, j] == 0)
            //                    {
            //                        matrix[ii, j] = 2;
            //                    }
            //                }
            //            }
            //            TileLong Lt = new TileLong((80 * (int)((8 - LinesCount) / 2) + (r2 - 1) * 80), (invisiblematrix0 - r1 + 1) * (-100) - 200, 5);
            //            Tiles.Add(Lt);
            //            this.Controls.Add(Lt.Box);
            //            break;
            //        }
            //    }
            //}


            button_all.Add(button1);
            button_all.Add(button2);
            button_all.Add(button3);
            button_all.Add(button4);
            button_all.Add(button5);
            button_all.Add(button6);
            button_all.Add(button7);
            button_all.Add(button8);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10; // Интервал в миллисекундах (20 раз в секунду)
            timer.Tick += Timer_Tick1;
            speed = 1;

            label1.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label3.Location = new Point((int)((this.Size.Width - label3.Size.Width) / 2) - (int)(label3.Size.Width), 50);
            label3.SendToBack();


            timer.Start();
            this.KeyDown += new KeyEventHandler(Key_Down);
            this.KeyUp += new KeyEventHandler(Key_Up);
            this.KeyPreview = true;
            this.FormClosing += Form_Closing;
        }

        private int flag = 0;
        private int timerflag = -10;


        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            serializerJ.Serialize(TotalScore);
        }
        private void Timer_Tick1(object sender, EventArgs e)
        {
            label3.Text = TotalScore.ToString();
            //label3.Text = $"{timer.Interval}\n{speed}";
            flag += 1;
            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].Box.Location = new Point(Tiles[i].Box.Location.X, Tiles[i].Box.Location.Y + speed);
            }

            //if (pictureBoxes[0].Location.Y % 100 == 0)
            //    MessageBox.Show(pictureBoxes[0].Location.Y.ToString());
            // Остановка при достижении нижней границы формы
            if (flag >= 100 / speed)
            {
                timerflag += 1;
                if (timerflag >= 21)
                {
                    timerflag = 0;
                    //timer.Interval = Math.Max(1, timer.Interval - 1);
                    speed = Math.Min(10, speed + 1);
                }

                flag = 0;

                TileWork workk = new TileWork(LinesCount, this, matrix, Tiles);
                matrix = workk.Rmatrix;
                Tiles = workk.RTiles;

            }
        }

        private int LongTileDown = 0;
        private bool LongTileD = false;

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (LongTileD) return;
            TileWork Work = new TileWork(e);
            //MessageBox.Show("111");
            int X = Work.X;
            //int X = 0;
            //if (e.KeyCode == Keys.A)
            //{
            //    X = 0;
            //    Console.Beep(5000, 25);
            //}
            //else if (e.KeyCode == Keys.S)
            //{
            //    X = 1;
            //    Console.Beep(3500, 25);
            //}
            //else if (e.KeyCode == Keys.D)
            //{
            //    X = 2;
            //    Console.Beep(3000, 25);
            //}
            //else if (e.KeyCode == Keys.F)
            //{
            //    X = 3;
            //    Console.Beep(2500, 25);
            //}
            //else if (e.KeyCode == Keys.G)
            //{
            //    X = 4;
            //    Console.Beep(2000, 25);
            //}
            //else if (e.KeyCode == Keys.H)
            //{
            //    X = 5;
            //    Console.Beep(1500, 25);
            //}
            //else if (e.KeyCode == Keys.J)
            //{
            //    X = 6;
            //    Console.Beep(1000, 25);
            //}
            //else if (e.KeyCode == Keys.K)
            //{
            //    X = 7;
            //    Console.Beep(500, 25);
            //}
            //X *= 80;


            TileWork Workk = new TileWork(Tiles, LinesCount, this, X, 0);
            LongTileDown = Workk.RLongTileDown;
            LongTileD = Workk.RLongTileD;
            TotalScore += Workk.RTotalScore;
            //int Lose = 0;
            //for (int i = 0; i < Tiles.Count(); i++)
            //{
            //    if (Tiles[i].Box.Location.X == X && (Tiles[i].Clicked == false))
            //    {
            //        //MessageBox.Show("222");
            //        if (Tiles[i].Box.Location.Y >= 500 && Tiles[i].Box.Location.Y < 700 && !(Tiles[i] is TileLong))
            //        {
            //            //MessageBox.Show("333");
            //            if (Tiles[i] is TileBase)
            //            {
            //                TotalScore += 1 * LinesCount; 
            //                Tiles[i].Click();
            //                Lose++;
            //            }
            //            else if (Tiles[i] is Tile2)
            //            {
            //                TotalScore += 1 * LinesCount;
            //                Tiles[i].Click();
            //                Lose++;
            //            }
            //            else if (Tiles[i] is TileTrap)
            //            {
            //                GameOver(2);
            //            }
            //        }
            //        else if (Tiles[i].Box.Location.Y >= 100 && Tiles[i].Box.Location.Y < 700 && (Tiles[i] is TileLong))
            //        {
            //            LongTileD = true;
            //            LongTileDown = Tiles[i].Box.Location.Y;
            //            Lose++;
            //            break;
            //        }
            //    }
            //}
            //if (Lose == 0)
            //{
            //    GameOver(3);
            //}
            //label3.Text = TotalScore.ToString();
        }

        public void WriteLabel3(int a)
        {
            label3.Text = a.ToString();
        }
        private void Key_Up(object sender, KeyEventArgs e)
        {
            if (LongTileD == true) LongTileD = false;
            if (LongTileD) return;
            TileWork Work = new TileWork(e);
            //MessageBox.Show("111");
            int X = Work.X;
            //MessageBox.Show("111");
            //int X = 0;
            //if (e.KeyCode == Keys.A)
            //{
            //    X = 0;
            //}
            //else if (e.KeyCode == Keys.S)
            //{
            //    X = 1;
            //}
            //else if (e.KeyCode == Keys.D)
            //{
            //    X = 2;
            //}
            //else if (e.KeyCode == Keys.F)
            //{
            //    X = 3;
            //}
            //else if (e.KeyCode == Keys.G)
            //{
            //    X = 4;
            //}
            //else if (e.KeyCode == Keys.H)
            //{
            //    X = 5;
            //}
            //else if (e.KeyCode == Keys.J)
            //{
            //    X = 6;
            //}
            //else if (e.KeyCode == Keys.K)
            //{
            //    X = 7;
            //}
            //X *= 80;

            TileWork Workk = new TileWork(Tiles, LinesCount, this, X, 1);
            LongTileDown = Workk.RLongTileDown;
            LongTileD = Workk.RLongTileD;
            TotalScore += Workk.RTotalScore;
            //int Lose = 0;
            //for (int i = 0; i < Tiles.Count; i++)
            //{
            //    if (Tiles[i].Box.Location.X == X)
            //    {
            //        if (Tiles[i].Box.Location.Y >= 100 && Tiles[i].Box.Location.Y < 800 && (Tiles[i] is TileLong))
            //        {
            //            LongTileDown = Tiles[i].Box.Location.Y - LongTileDown;
            //            if (LongTileDown >= 300)
            //            {
            //                TotalScore += 3 * LinesCount;
            //                label3.Text = TotalScore.ToString();
            //                Tiles[i].Click();
            //            }
            //            else if (LongTileDown >= 100 && LongTileDown < 300)
            //            {
            //                TotalScore += 2 * LinesCount;
            //                label3.Text = TotalScore.ToString();
            //                Tiles[i].Click();
            //            }
            //            else
            //            {
            //                TotalScore += 1 * LinesCount;
            //                label3.Text = TotalScore.ToString();
            //                Tiles[i].Click();
            //            }
            //        }
            //    }
            //}
        }

        public void GameOver(int f)
        {
            timer.Stop();
            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].Box.Visible = false;
            }
            for (int i = 0; i < button_all.Count; i++)
            {
                button_all[i].Visible = false;
            }
            label3.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label2.Text = label3.Text;
            button9.Visible = true;
            this.KeyPreview = false;
            if (f == 1)
            {
                label1.Text = "Missing tile";
            }
            else if (f == 2)
            {
                label1.Text = "The trap tile";
            }
            else
            {
                label1.Text = "Incorrect click";
            }
            label4.Visible = true;
            label4.Location = new Point((int)((this.Size.Width - label4.Size.Width)/2), 150);
            label1.Location = new Point((int)((this.Size.Width - label1.Size.Width)/2), 250);
            label2.Location = new Point((int)((this.Size.Width - label2.Size.Width)/2), 350);
            button9.Location = new Point((int)((this.Size.Width - button9.Size.Width)/2), 550);
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
            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].Box.Visible = false;
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
            //serializerJ.Serialize("top", TotalScore);

            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}

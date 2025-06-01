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

        private static int LinesCount = 2;
        //private static int LinesCount = Form.CountTracks;
        private static int TilesCount = (LinesCount * 2 + 4) + (1 + (int)(LinesCount / 5)) + (1 + (int)(LinesCount / 3.5)) + (1);
        //private static int TilesCount = 20;

        private static int invisiblematrix0 = 16 + 5;

        private List<Tile> Tiles = new List<Tile>();
        private List<bool> pictureBoxesСlicked = new List<bool>();
        private List<Button> button_all = new List<Button>();
        private int[,] matrix = new int[invisiblematrix0 + 2, LinesCount + 2];
        private int TotalScore = 0;

        private JSON_SerializerList serializerJ = new JSON_SerializerList();


        public Form2(Form1 f)
        {
            InitializeComponent();
            //LinesCount = f.CountTracks;
            label3.Text = TotalScore.ToString();
            List<List<int>> sp = new List<List<int>> { };
            int co = 0;

            while (co < TilesCount - 1)
            {
                int r1 = random.Next(1 + (5), invisiblematrix0 + 1);
                int r2 = random.Next(1, LinesCount + 1);
                if (matrix[r1, r2] == 0 && matrix[r1, r2] == 0 && matrix[r1, r2] == 0)
                {
                    matrix[r1, r2] = 1;
                    matrix[r1 - 1, r2] = 2;
                    matrix[r1 + 1, r2] = 2;
                    matrix[r1, r2 - 1] = 2;
                    matrix[r1, r2 + 1] = 2;
                    co += 1;
                    //MessageBox.Show(co.ToString());
                    sp.Add(new List<int> { 80 * (int)((8 - LinesCount) / 2) + (r2 - 1) * 80, (invisiblematrix0 - r1 + 1) * (-100) - 200 });
                }
            }
            //Tiles.Add(new TileLong(sp[i][0], sp[i][1], 5));
            //this.Controls.Add(Tiles[i].Box);

            //for (int ii = 0; ii < spTiles.Count; ii++)
            //{
            //    spTiles[ii].Box.Visible = true;
            //    spTiles[ii].Box.Location = new Point(sp[ii][0], sp[ii][1]);
            //}

            //while (co < TilesCount)
            //{
            //    if (TilesCount - co > 1)
            //    {
            //        int r1 = random.Next(1 + (5), invisiblematrix0 + 1);
            //        int r2 = random.Next(1, LinesCount + 1);
            //        if (matrix[r1, r2] == 0 && matrix[r1, r2] == 0 && matrix[r1, r2] == 0)
            //        {
            //            matrix[r1, r2] = 1;
            //            matrix[r1 - 1, r2] = 2;
            //            matrix[r1 + 1, r2] = 2;
            //            matrix[r1, r2 - 1] = 2;
            //            matrix[r1, r2 + 1] = 2;
            //            co += 1;
            //            //MessageBox.Show(co.ToString());
            //            sp.Add(new List<int> { 80 * (int)((8 - LinesCount) / 2) + (r2 - 1) * 80, (invisiblematrix0 - r1 + 1) * (-100) - 200 });
            //        }
            //    }
            //    else if (co == TilesCount - 1)
            //    {
            //        int r1 = 1;
            //        int r2 = random.Next(1, LinesCount + 1);
            //        if (matrix[r1, r2 + 4] != 2)
            //        {
            //            matrix[r1 - 1, r2] = 2;
            //            matrix[r1, r2] = 1;
            //            matrix[r1, r2 + 1] = 1;
            //            matrix[r1, r2 + 2] = 1;
            //            matrix[r1, r2 + 3] = 1;
            //            matrix[r1, r2 + 4] = 1;
            //            matrix[r1, r2 + 5] = 2;
            //            for (int ii = 0; ii < 5; ii++)
            //            {
            //                for (int j = 0; j < matrix.GetLength(1); j++)
            //                {
            //                    if (matrix[ii, j] == 0)
            //                    {
            //                        matrix[ii, j] = 2;
            //                    }
            //                }
            //            }
            //            co++;
            //            sp.Add(new List<int> { 80 * (int)((8 - LinesCount) / 2) + (r2 - 1) * 80, (invisiblematrix0 - r1 + 1) * (-100) - 200 });
            //        }
            //    }
            //}
            int i = 0;
            for (int j = 0; j < LinesCount * 2 + 4; i++, j++)
            {
                Tiles.Add(new TileBase(sp[i][0], sp[i][1]));
                this.Controls.Add(Tiles[i].Box);
            }
            for (int j = 0; j < 1 + (int)(LinesCount / 5); j++, i++)
            {
                Tiles.Add(new Tile2(sp[i][0], sp[i][1]));
                this.Controls.Add(Tiles[i].Box);
            }
            for (int j = 0; j < 1 + (int)(LinesCount / 3.5); j++, i++)
            {
                Tiles.Add(new TileTrap(sp[i][0], sp[i][1]));
                this.Controls.Add(Tiles[i].Box);
            }

            if (true)
            {
                while (true)
                {
                    int r1 = 1;
                    int r2 = random.Next(1, LinesCount + 1);
                    if (matrix[r1 + 4, r2] != 2)
                    {
                        matrix[r1 - 1, r2] = 2;
                        matrix[r1, r2] = 1;
                        matrix[r1 + 1, r2] = 1;
                        matrix[r1 + 2, r2] = 1;
                        matrix[r1 + 3, r2] = 1;
                        matrix[r1 + 4, r2] = 1;
                        matrix[r1 + 5, r2] = 2;
                        for (int ii = 1; ii <= 5; ii++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                if (matrix[ii, j] == 0)
                                {
                                    matrix[ii, j] = 2;
                                }
                            }
                        }
                        TileLong Lt = new TileLong((80 * (int)((8 - LinesCount) / 2) + (r2 - 1) * 80), (invisiblematrix0 - r1 + 1) * (-100) - 200, 5);
                        Tiles.Add(Lt);
                        this.Controls.Add(Lt.Box);
                        break;
                    }
                }
            }

            //pictureBox1 = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(sp[0][0], sp[0][1]),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //};
            //pictureBox2 = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(sp[1][0], sp[1][1]),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //};
            //pictureBox3 = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(sp[2][0], sp[2][1]),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //};
            //pictureBox4 = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(sp[3][0], sp[3][1]),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //};
            //pictureBox5 = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(sp[4][0], sp[4][1]),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //};
            //pictureBox6 = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(sp[5][0], sp[5][1]),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //};
            //pictureBox7 = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(sp[6][0], sp[6][1]),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //};
            //pictureBox8 = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(sp[7][0], sp[7][1]),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //};
            //pictureBox9 = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(sp[8][0], sp[8][1]),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //    Visible = false
            //};
            //pictureBox10 = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(sp[9][0], sp[9][1]),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //    Visible = false
            //};
            //pictureBoxxx = new PictureBox
            //{
            //    Size = new Size(80, 100),
            //    Location = new Point(400, 400),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    SizeMode = PictureBoxSizeMode.Zoom,
            //    BackColor = Color.Black,
            //    Visible = false
            //};

            //this.Controls.Add(pictureBox1);
            //this.Controls.Add(pictureBox2);
            //this.Controls.Add(pictureBox3);
            //this.Controls.Add(pictureBox4);
            //this.Controls.Add(pictureBox5);
            //this.Controls.Add(pictureBox6);
            //this.Controls.Add(pictureBox7);
            //this.Controls.Add(pictureBox8);
            //this.Controls.Add(pictureBox9);
            //this.Controls.Add(pictureBox10);
            //pictureBoxes.Add(pictureBox1);
            //pictureBoxes.Add(pictureBox2);
            //pictureBoxes.Add(pictureBox3);
            //pictureBoxes.Add(pictureBox4);
            //pictureBoxes.Add(pictureBox5);
            //pictureBoxes.Add(pictureBox6);
            //pictureBoxes.Add(pictureBox7);
            //pictureBoxes.Add(pictureBox8);
            //pictureBoxes.Add(pictureBox9);
            //pictureBoxes.Add(pictureBox10);
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

            this.KeyDown += new KeyEventHandler(Key_Down);
            this.KeyUp += new KeyEventHandler(Key_Up);
            this.KeyPreview = true;
        }

        private int flag = 0;
        private int timerflag = 0;


        private void FormClosing(object sender, FormClosedEventArgs e)
        {
            serializerJ.Serialize("top", TotalScore);
        }
        private void Timer_Tick1(object sender, EventArgs e)
        {
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
                if (timerflag >= 20)
                {
                    timerflag = 0;
                    //timer.Interval = Math.Max(1, timer.Interval - 1);
                    speed = Math.Min(10, speed + 1);
                }
                //timerflag += 1;
                //if (timerflag % 3 == 0)
                //{
                //    timerflag = 0;
                //    timer.Interval = Math.Max(timer.Interval - 5, 1);
                //}
                //if (timerflag % 2 == 0)
                //{
                //    speed = Math.Min(10, speed + 1);
                //}
                //MessageBox.Show(pictureBoxes[0].Location.Y.ToString());
                //label1.Text = pictureBoxes[0].Location.Y.ToString();
                //label2.Text = flag.ToString();
                flag = 0;
                int co = 0;
                int l = 0;
                List<Tile> spTiles = new List<Tile>();
                Tile Lt = null;
                for (int ii = 0; ii < Tiles.Count; ii++)
                {
                    if (Tiles[ii].Box.Location.Y >= 700 && !(Tiles[ii] is TileLong))
                    {
                        if (!Tiles[ii].Clicked && !(Tiles[ii] is TileTrap))
                        {
                            GameOver();
                        }
                        if (Tiles[ii] is TileTrap)
                        {
                            TotalScore += 2 * LinesCount;
                            label3.Text = TotalScore.ToString();
                        }
                        spTiles.Add(Tiles[ii]);
                        co += 1;
                    }
                    if (Tiles[ii] is TileLong && Tiles[ii].Box.Location.Y >= 700)
                    {
                        if (!Tiles[ii].Clicked)
                        {
                            GameOver();
                        }
                        Lt = (TileLong)Tiles[ii];
                    }
                }

                for (int ii = matrix.GetLength(0) - 1; ii >= 0; ii--)
                {
                    if (ii == 0)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrix[ii, j] = 0;
                        }
                    }
                    if (ii >= 1)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrix[ii, j] = matrix[ii - 1, j];
                        }
                    }
                }
                var sp = new List<List<int>> { };

                int coco = 0;
                while (coco < co)
                {
                    int r1 = random.Next(1 + (5), invisiblematrix0 + 1);
                    int r2 = random.Next(1, LinesCount + 1);
                    if (matrix[r1, r2] == 0 && matrix[r1, r2] == 0 && matrix[r1, r2] == 0)
                    {
                        matrix[r1, r2] = 1;
                        matrix[r1 - 1, r2] = 2;
                        matrix[r1 + 1, r2] = 2;
                        matrix[r1, r2 - 1] = 2;
                        matrix[r1, r2 + 1] = 2;
                        coco += 1;
                        //MessageBox.Show(co.ToString());
                        sp.Add(new List<int> { 80 * (int)((8 - LinesCount) / 2) + (r2 - 1) * 80, (invisiblematrix0 - r1 + 1) * (-100) - 200 });
                    }
                }
                if (Lt != null)
                {
                    while (true)
                    {
                        int r1 = 1;
                        int r2 = random.Next(1, LinesCount + 1);
                        if (matrix[r1 + 4, r2] != 2)
                        {
                            matrix[r1 - 1, r2] = 2;
                            matrix[r1, r2] = 1;
                            matrix[r1 + 1, r2] = 1;
                            matrix[r1 + 2, r2] = 1;
                            matrix[r1 + 3, r2] = 1;
                            matrix[r1 + 4, r2] = 1;
                            matrix[r1 + 5, r2] = 2;
                            for (int ii = 1; ii <= 5; ii++)
                            {
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    if (matrix[ii, j] == 0)
                                    {
                                        matrix[ii, j] = 2;
                                    }
                                }
                            }
                            Lt.Box.Visible = true;
                            Lt.Box.Location = new Point(80 * (int)((8 - LinesCount) / 2) + (r2 - 1) * 80, (invisiblematrix0 - r1 + 1) * (-100) - 200);
                            break;
                        }
                    }
                }

                for (int ii = 0; ii < spTiles.Count; ii++)
                {
                    spTiles[ii].Box.Visible = true;
                    spTiles[ii].NotClicked();
                    spTiles[ii].Box.Location = new Point(sp[ii][0], sp[ii][1]);
                }
            }
            //int i = 0;
            //for (int j = 0; j < LinesCount * 2 + 4; i++, j++)
            //{
            //    Tiles.Add(new Tile(sp[i][0], sp[i][1]));
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
            //Tiles.Add(new TileLong(sp[i][0], sp[i][1], 5));
            //this.Controls.Add(Tiles[i].Box);
            ////MessageBox.Show("1");
            //for (int i = 0, k = 0; i < Tiles.Count; i++)
            //{
            //    if (Tiles[i].Box.Location.Y == 800)
            //    {
            //        Tiles[i].Box.Visible = true;
            //        Tiles[i].Box.Location = new Point(sp[k][0], sp[k][1]);
            //        k++;
            //    }
            //}
        }

        private void Click(PictureBox P)
        {
            P.Visible = false;
            //pictureBoxesСlicked[P.Location.X / 80] = true;
        }


        private int LongTileDown = 0;
        private bool LongTileD = false;

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (LongTileD) return;
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
            for (int i = 0; i < Tiles.Count; i++)
            {
                if (Tiles[i].Box.Location.X == X && (Tiles[i].Clicked == false))
                {
                    //MessageBox.Show("222");
                    if (Tiles[i].Box.Location.Y >= 500 && Tiles[i].Box.Location.Y < 700 && !(Tiles[i] is TileLong))
                    {
                        //MessageBox.Show("333");
                        if (Tiles[i] is TileBase)
                        {
                            TotalScore += 1 * LinesCount; 
                            Tiles[i].Click();
                            Lose++;
                        }
                        else if (Tiles[i] is Tile2)
                        {
                            TotalScore += 1 * LinesCount;
                            Tiles[i].Click();
                            Lose++;
                        }
                        else if (Tiles[i] is TileTrap)
                        {
                            GameOver();
                        }
                    }
                    else if (Tiles[i].Box.Location.Y >= 100 && Tiles[i].Box.Location.Y < 700 && (Tiles[i] is TileLong))
                    {
                        LongTileD = true;
                        LongTileDown = Tiles[i].Box.Location.Y;
                        Lose++;
                        break;
                    }
                }
            }
            if (Lose == 0)
            {
                GameOver();
            }
            label3.Text = TotalScore.ToString();
        }
        private void Key_Up(object sender, KeyEventArgs e)
        {
            if (LongTileD == true) LongTileD = true;
            //MessageBox.Show("111");
            int X = 0;
            if (e.KeyCode == Keys.A)
            {
                X = 0;
            }
            else if (e.KeyCode == Keys.S)
            {
                X = 1;
            }
            else if (e.KeyCode == Keys.D)
            {
                X = 2;
            }
            else if (e.KeyCode == Keys.F)
            {
                X = 3;
            }
            else if (e.KeyCode == Keys.G)
            {
                X = 4;
            }
            else if (e.KeyCode == Keys.H)
            {
                X = 5;
            }
            else if (e.KeyCode == Keys.J)
            {
                X = 6;
            }
            else if (e.KeyCode == Keys.K)
            {
                X = 7;
            }
            X *= 80;
            int Lose = 0;
            for (int i = 0; i < Tiles.Count; i++)
            {
                if (Tiles[i].Box.Location.X == X)
                {
                    if (Tiles[i].Box.Location.Y >= 100 && Tiles[i].Box.Location.Y < 800 && (Tiles[i] is TileLong))
                    {
                        LongTileDown = Tiles[i].Box.Location.Y - LongTileDown;
                        if (LongTileDown >= 300)
                        {
                            TotalScore += 3 * LinesCount;
                            label3.Text = TotalScore.ToString();
                            Tiles[i].Click();
                        }
                        else if (LongTileDown >= 100 && LongTileDown < 300)
                        {
                            TotalScore += 2 * LinesCount;
                            label3.Text = TotalScore.ToString();
                            Tiles[i].Click();
                        }
                        else
                        {
                            TotalScore += 1 * LinesCount;
                            label3.Text = TotalScore.ToString();
                            Tiles[i].Click();
                        }
                    }
                }
            }
        }

        private void GameOver()
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

            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}

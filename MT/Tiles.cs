using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT
{
    public interface MusTile
    {
        bool Clicked { get; }
        void Click() { }
        void NotClicked() { }
    }
    public abstract class Tile : MusTile
    {
        protected PictureBox _Box;
        protected bool _Сlicked = false;
        public bool Clicked => _Сlicked;
        public Tile(int x, int y)
        {
            _Box = new PictureBox
            {
                Size = new Size(80, 100),
                Location = new Point(x, y),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black,
            };
        }
        //public abstract void Click<T>(T tile) where T : class;
        public PictureBox Box { get { return _Box; } }
        public virtual void Click() { }
        public virtual void NotClicked() 
        {
            _Сlicked = false;
        }
        //public void Move(int x, int y)
        //{
        //    Box.Visible = true;
        //    Box.Location = new Point(x, y);
        //}
    }
    public class TileBase : Tile
    {
        public TileBase(int x, int y) : base(x, y)
        {

        }
        public override void Click()
        {
            _Box.Visible = false;
            _Сlicked = true;
        }
        public void Move(int x, int y)
        {
            Box.Visible = true;
            Box.Location = new Point(x, y);
        }
    }
    public class Tile2 : Tile
    {
        public Tile2(int x, int y) : base(x, y)
        {
            _Box.BackColor = Color.Pink;
            string appFolder = Application.StartupPath;
            //string FilePath = Path.Combine(appFolder, "Star.jpg");
            //string FilePath = Path.Combine(appFolder, "Black.jpg");
            //_Box.Image = Image.FromFile(FilePath);
        }
        private int ClickCount = 2;
        public override void Click()
        {
            ClickCount -= 1;
            _Box.Visible = true;
            if (ClickCount == 0)
            {
                _Сlicked = true;
                _Box.Visible = false;
            }
        }
        public override void NotClicked()
        {
            _Сlicked = false;
            ClickCount = 2;
        }
    }
    public class TileTrap : Tile
    {
        public TileTrap(int x, int y) : base(x, y)
        {
            _Сlicked = true;
            _Box.BackColor = Color.Green;
        }
        public override void Click()
        {
            _Сlicked = false;
        }
    }

    public class TileLong : Tile
    {
        public TileLong(int x, int y, int l) : base(x, y)
        {
            _Box.BackColor = Color.Blue;
            _Box.Size = new Size(_Box.Size.Width, _Box.Size.Height * l);
        }
        public override void Click()
        {
            _Сlicked = true;
            _Box.Visible = false;
        }
    }
    public partial class TileWork
    {
        private int TotalScore = 0;
        public int RTotalScore => TotalScore;
        private Random random = new Random();
    }
    public partial class TileWork
    {
        private int _X;
        public int X => _X;
        public TileWork(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                _X = 0;
                Console.Beep(5000, 25);
            }
            else if (e.KeyCode == Keys.S)
            {
                _X = 1;
                Console.Beep(3500, 25);
            }
            else if (e.KeyCode == Keys.D)
            {
                _X = 2;
                Console.Beep(3000, 25);
            }
            else if (e.KeyCode == Keys.F)
            {
                _X = 3;
                Console.Beep(2500, 25);
            }
            else if (e.KeyCode == Keys.G)
            {
                _X = 4;
                Console.Beep(2000, 25);
            }
            else if (e.KeyCode == Keys.H)
            {
                _X = 5;
                Console.Beep(1500, 25);
            }
            else if (e.KeyCode == Keys.J)
            {
                _X = 6;
                Console.Beep(1000, 25);
            }
            else if (e.KeyCode == Keys.K)
            {
                _X = 7;
                Console.Beep(500, 25);
            }
            _X *= 80;
        }
    }
    public partial class TileWork
    {
        private bool LongTileD = false;
        private int LongTileDown = 0;
        public int RLongTileDown => LongTileDown;
        public bool RLongTileD => LongTileD;

        private void TileClick<T>(T tile) where T : class
        {
            if (typeof(T) == typeof(TileBase))
            {

            }
        }
        public TileWork(List<Tile> Tiles, int LinesCount, Form2 form, int X, int a)
        {
            if (a == 0)
            {
                int Lose = 0;
                for (int i = 0; i < Tiles.Count(); i++)
                {
                    //MessageBox.Show(_X.ToString());
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
                                form.GameOver(2);
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
                    form.GameOver(3);
                }
                //form.WriteLabel3(TotalScore);
            }
            else
            {
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
                                Tiles[i].Click();
                            }
                            else if (LongTileDown >= 100 && LongTileDown < 300)
                            {
                                TotalScore += 2 * LinesCount;
                                Tiles[i].Click();
                            }
                            else
                            {
                                TotalScore += 1 * LinesCount;
                                Tiles[i].Click();
                            }
                        }
                    }
                }
            }
        }
    }
    public partial class TileWork
    {
        private List<List<int>> sp = new List<List<int>> { };
        private List<Tile> Tiles = new List<Tile>();
        private int[,] matrix = new int[0,0];
        public List<List<int>> Rsp => sp;
        public List<Tile> RTiles => Tiles;
        public int[,] Rmatrix => matrix;

        public TileWork(int[,] mmatrix, int LinesCount, Form2 form)
        {
            matrix = mmatrix;
            int co = 0;
            int TilesCount = (LinesCount * 2 + 4) + (1 + (int)(LinesCount / 5)) + (1 + (int)(LinesCount / 3.5)) + (1);
            int invisiblematrix0 = matrix.GetLength(0) - 2;
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
            

            int i = 0;
            for (int j = 0; j < LinesCount * 2 + 4; i++, j++)
            {
                Tiles.Add(new TileBase(sp[i][0], sp[i][1]));
                form.Controls.Add(Tiles[i].Box);
            }
            for (int j = 0; j < 1 + (int)(LinesCount / 5); j++, i++)
            {
                Tiles.Add(new Tile2(sp[i][0], sp[i][1]));
                form.Controls.Add(Tiles[i].Box);
            }
            for (int j = 0; j < 1 + (int)(LinesCount / 3.5); j++, i++)
            {
                Tiles.Add(new TileTrap(sp[i][0], sp[i][1]));
                form.Controls.Add(Tiles[i].Box);
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
                        form.Controls.Add(Lt.Box);
                        break;
                    }
                }
            }
        }
    }
    public partial class TileWork
    {
        public TileWork(int LinesCount, Form2 form, int[,] mmatrix, List<Tile> Tilee)
        {
            matrix = mmatrix;
            Tiles = Tilee;
            int invisiblematrix0 = matrix.GetLength(0) - 2;
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
                        form.GameOver(1);
                    }
                    if (Tiles[ii] is TileTrap)
                    {
                        TotalScore += 2 * LinesCount;
                        //label3.Text = TotalScore.ToString();
                    }
                    spTiles.Add(Tiles[ii]);
                    co += 1;
                }
                if (Tiles[ii] is TileLong && Tiles[ii].Box.Location.Y >= 700)
                {
                    if (!Tiles[ii].Clicked)
                    {
                        form.GameOver(1);
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
                        Lt.NotClicked();
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
    }
}

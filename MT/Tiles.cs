using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT
{
    public class Tile
    {
        protected PictureBox _Box;
        protected bool _Сlicked = false;
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
        public PictureBox Box { get { return _Box; } }
        public void Click()
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
        }
        private int ClickCount = 2;
        public void Click()
        {
            ClickCount--;
            if (ClickCount == 0)
            {
                _Сlicked = true;
            }
        }
    }
    public class TileTrap : Tile
    {
        public TileTrap(int x, int y) : base(x, y)
        {
            _Сlicked = true;
            _Box.BackColor = Color.Green;
        }
        public void Click()
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
        public void Click()
        {
            _Сlicked = true;
        }
    }
}

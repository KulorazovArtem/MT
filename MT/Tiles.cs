﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Xml.Linq;

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
        public abstract void Move<T>(T til) where T : Tile;
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
        public override void Move<T>(T til){}
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
        public override void Move<T>(T til) { }
    }
    public class TileTrap : Tile
    {
        public TileTrap(int x, int y) : base(x, y)
        {
            _Сlicked = true;
            _Box.BackColor = Color.Red;
        }
        public override void Click()
        {
            _Сlicked = false;
        }
        public override void Move<T>(T til) { }
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
        public override void Move<T>(T til) { }
    }
    
}

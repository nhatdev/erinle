using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FallingRocks
{
    public class Rock : Image
    {
        public Image Image { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private readonly int _fallingSpeed;

        public Rock(int fallingSpeed, BitmapImage bitmap)
        {
            this._fallingSpeed = fallingSpeed;
            Source = bitmap;
            Width = 50;
            Height = 50;
        }

        public void Fall()
        {
            Y += _fallingSpeed;

            if (Y >= GameWindow.WindowHeight)
            {
                Y = 0;
            }
        }
    }
}
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FallingRocks
{
    public class Rock : Image
    {
        public const int RockWidth = 50;
        public const int RockHeight = 50;

        public Image Image { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private int _fallingSpeed;

        public Rock(BitmapImage bitmap)
        {
            this._fallingSpeed = 5;
            Source = bitmap;
            Width = RockWidth;
            Height = RockHeight;

        }

        public void Fall(Random random)
        {
            Y += _fallingSpeed;

            if (Y >= GameWindow.WindowHeight)
            {
                Y = -50;
                X = random.Next(GameWindow.WindowWidth - RockWidth);
                _fallingSpeed = random.Next(4, 8);
            }
        }
    }
}
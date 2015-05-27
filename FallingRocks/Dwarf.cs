using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FallingRocks
{
    public class Dwarf : Image
    {
        public int X { get; set; }

        public Dwarf(BitmapImage bitmap)
        {
            Source = bitmap;
            Width = 50;
            Height = 50;
        }

        public void MoveLeft()
        {
            X += 10;
        }

        public void MoveRight()
        {
            X -= 10;
        }

    }
}
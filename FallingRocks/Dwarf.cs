using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FallingRocks
{
    public class Dwarf : Image
    {
        public const int DwarfWidth = 50;
        public const int DwarfHeight = 50;

        public int X { get; set; }

        public Dwarf(BitmapImage bitmap)
        {
            Source = bitmap;
            Width = DwarfWidth;
            Height = DwarfHeight;
        }

        public void MoveLeft()
        {
            X -= 10;
            if (X < 0)
            {
                X = 0;
            }
        }

        public void MoveRight()
        {
            X += 10;
            if (X > GameWindow.WindowWidth - DwarfWidth)
            {
                X = GameWindow.WindowWidth - DwarfWidth;
            }
        }

    }
}
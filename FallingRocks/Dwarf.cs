using System.Windows.Controls;

namespace FallingRocks
{
    public class Dwarf
    {
        public int X { get; set; }

        public Dwarf()
        {
            this.X = 170;
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
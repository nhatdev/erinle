using System.Windows.Controls;

namespace FallingRocks
{
    public class Rock
    {
        public int X { get; set; }
        public int Y { get; set; }

        private readonly int _fallingSpeed;

        public Rock(int fallingSpeed)
        {
            this._fallingSpeed = fallingSpeed;
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
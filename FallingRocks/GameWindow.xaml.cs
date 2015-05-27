using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FallingRocks
{

    public partial class GameWindow : Window
    {
        public const int WindowHeight = 500;
        public const int WindowWidth = 400;

        private const int FallingSpeed = 5;

        private DrawThread _drawThread;

        private Dwarf _dwarf;
        private Rock _rock;

        private BitmapImage _rockBitmap;

        public GameWindow()
        {
            InitializeComponent();
            InitializeGame();
            StartGame();
        }

        private void InitializeGame()
        {
            _drawThread = new DrawThread(this);

            BitmapImage dwarfBitmap = new BitmapImage(new Uri(@"rock.png", UriKind.RelativeOrAbsolute));
            _dwarf = new Dwarf(dwarfBitmap);

            _rockBitmap = new BitmapImage(new Uri(@"rock.png", UriKind.RelativeOrAbsolute));
            _rock = new Rock(FallingSpeed, _rockBitmap);

            RockCanvas.Children.Add(_dwarf);
            RockCanvas.Children.Add(_rock);
            Canvas.SetTop(_dwarf, 420);
        }

        private void StartGame()
        {
            _drawThread.Start();
        }

        public void Draw()
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                _rock.Fall();
                Canvas.SetTop(_rock, _rock.Y);

                CheckGameOver();
            }));
        }

        private void GameWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                _dwarf.MoveLeft();
            }
            else if (e.Key == Key.Right)
            {
                _dwarf.MoveRight();
            }
            Canvas.SetRight(_dwarf, _dwarf.X);
        }

        private void CheckGameOver()
        {
            if (_rock.Y >= 450)
            {
                int dwarfLeft = _dwarf.X;
                int dwarfRight = _dwarf.X + 70;

                int rockLeft = _rock.X;
                int rockRight = _rock.X + 50;

                if ((dwarfLeft >= rockLeft && dwarfLeft <= rockRight) || (dwarfRight >= rockLeft && dwarfRight <= rockRight))
                {
                    _drawThread.Stop();
                    GameOverText.Visibility = Visibility.Visible;
                }
            }
        }

    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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

        private BitmapImage rockImage;

        public GameWindow()
        {
            InitializeComponent();
            InitializeGame();
            StartGame();
        }

        private void InitializeGame()
        {
            _drawThread = new DrawThread(this);
            _dwarf = new Dwarf();
            _rock = new Rock(FallingSpeed);
            InitRockImage();
        }

        private void InitRockImage()
        {
            rockImage = new BitmapImage();
            rockImage.BeginInit();
            rockImage.UriSource = new Uri(@"/rock.png", UriKind.RelativeOrAbsolute);
            rockImage.EndInit();
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
                Canvas.SetTop(Rock, _rock.Y);
                CheckGameOver();
                Test();
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
            Canvas.SetRight(Dwarf, _dwarf.X);
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

        private void Test()
        {
            int dwarfLeft = _dwarf.X;
            int dwarfRight = _dwarf.X + 70;

            int rockLeft = _rock.X;
            int rockRight = _rock.X + 50;

            DwarfPositionTest.Text = "Dwarf: " + dwarfLeft + " / " + dwarfRight;
            RockPositionTest.Text = "Rock: Y " + rockLeft + " / " + rockRight;
        }
    }
}

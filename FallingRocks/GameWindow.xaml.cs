using System;
using System.Collections.Generic;
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

        private DrawThread _drawThread;

        private Dwarf _dwarf;
        private List<Rock> _rocks;

        private BitmapImage _rockBitmap;

        private Random _random = new Random();

        public Scores Scores;

        public GameWindow()
        {
           // CurrentScores.Text = Scores.GetCurrentScores();
            InitializeComponent();
            InitializeGame();
            StartGame();

        }

        private void InitializeGame()
        {
            _drawThread = new DrawThread(this);
            InitializeDwarf();
            InitializeRocks();
        }

        private void InitializeDwarf()
        {
            BitmapImage dwarfBitmap = new BitmapImage(new Uri(@"Mushroom.jpg", UriKind.RelativeOrAbsolute));
            _dwarf = new Dwarf(dwarfBitmap);
            _dwarf.X = WindowWidth / 2;
            RockCanvas.Children.Add(_dwarf);
            Canvas.SetTop(_dwarf, 415);
            Canvas.SetLeft(_dwarf, _dwarf.X);
        }

        private void InitializeRocks()
        {
            _rockBitmap = new BitmapImage(new Uri(@"rock.png", UriKind.RelativeOrAbsolute));
            _rocks = new List<Rock>();
            for (int i = 0; i < 3; i++)
            {
                Rock rock = new Rock(_rockBitmap);
                rock.X = i * 165;
                _rocks.Add(rock);
                RockCanvas.Children.Add(rock);
            }
        }

        private void StartGame()
        {
            _drawThread.Start();
        }

        public void Draw()
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                foreach (var rock in _rocks)
                {
                    rock.Fall(_random);

                    Canvas.SetLeft(rock, rock.X);
                    Canvas.SetTop(rock, rock.Y);

                    if (CheckGameOver(rock))
                    {
                        break;
                    }
                }

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
            Canvas.SetLeft(_dwarf, _dwarf.X);
        }

        private bool CheckGameOver(Rock rock)
        {
            bool isOver = false;

            if (rock.Y >= WindowHeight - Dwarf.DwarfHeight)
            {
                int dwarfLeft = _dwarf.X;
                int dwarfRight = _dwarf.X + Dwarf.DwarfWidth;

                int rockLeft = rock.X;
                int rockRight = rock.X + Rock.RockWidth;

                if ((dwarfLeft >= rockLeft && dwarfLeft <= rockRight) || (dwarfRight >= rockLeft && dwarfRight <= rockRight))
                {
                    Sound.PlayScream();
                    _drawThread.Stop();
                    GameOverText.Visibility = Visibility.Visible;
                    isOver = true;
                }
            }
            return isOver;
        }

    }
}

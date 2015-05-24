using System;
using System.Windows;

namespace FallingRocks
{

    public partial class GameWindow : Window
    {
        private readonly DrawThread _drawThread;
        private int _counter;

        public GameWindow()
        {
            InitializeComponent();
            _drawThread = new DrawThread(this);
            StartGame();
        }

        private void StartGame()
        {
            _drawThread.Start();
        }

        public void Draw()
        {
            Counter.Dispatcher.BeginInvoke(new Action(() =>
            {
                Counter.Text = _counter.ToString();
                _counter++;
            }));
        }
    }
}

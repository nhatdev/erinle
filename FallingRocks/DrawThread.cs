using System;
using System.Threading;

namespace FallingRocks
{
    class DrawThread
    {
        private const int FramesPerSecond = 25;
        private const int SkipTicks = 1000 / FramesPerSecond;

        private Thread _drawThread;
        private readonly GameWindow _gameWindow;

        private bool _gameIsRunning;

        public DrawThread(GameWindow gameWindow)
        {
            this._gameWindow = gameWindow;
        }

        private void Draw()
        {
            long nextTick = GetNowInMilliseconds();
            long sleepTime = 0;

            while (_gameIsRunning)
            {
                _gameWindow.Draw();

                nextTick += SkipTicks;
                sleepTime = nextTick - GetNowInMilliseconds();
                if (sleepTime >= 0)
                {
                    Thread.Sleep((int)sleepTime);
                }
            }
        }

        public void Start()
        {
            if (!this._gameIsRunning)
            {
                this._gameIsRunning = true;
                _drawThread = new Thread(Draw);
                _drawThread.Start();
            }
        }

        public void Stop()
        {
            this._gameIsRunning = false;
        }

        public bool IsRunning()
        {
            return this._gameIsRunning;
        }

        private long GetNowInMilliseconds()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }
    }

}

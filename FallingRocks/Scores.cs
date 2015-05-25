using System;
using System.Collections.Generic;
using System.IO;

namespace FallingRocks
{
    public class Scores
    {
        private int _currentScores = 0;
        private string _highScores = "";

        public string GetCurrentScores()
        {
            return "Scores:" + _currentScores;
        }

        public int AddScores(int rocks)
        {
            _currentScores = _currentScores + rocks;

            return _currentScores;
        }

        public string GetHighScores()
        {
            if (_highScores == "")
            {
                var scores = new List<int>();
                var lines = new List<string>();
                foreach (string line in File.ReadAllLines("highScores.txt"))
                {
                    var score = line.Split(' ')[1];
                    var scoreInt = Convert.ToInt32(score);
                    scores.Add(scoreInt);
                    lines.Add(line);
                }

                scores.Sort();
                scores.Reverse();

                var limit = 10;

                if (scores.Count < 10)
                {
                    limit = scores.Count;
                }

                for (int i = 0; i < limit; i++)
                {
                    var index = scores[i].ToString();
                    foreach (var line in lines)
                    {
                        if (line.IndexOf(index) != -1)
                        {
                            _highScores += Environment.NewLine + line;
                        }
                    }
                }
            }

            return _highScores;
        }

        public void AddToHighScores(string name)
        {
            string record = Environment.NewLine + name + ": " + _currentScores;

            File.AppendAllText("highScores.txt", record);
        }
    }
}

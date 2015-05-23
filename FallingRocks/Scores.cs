using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FallingRocks
{
    class Scores
    {
        private int currentScores = 0;

        public void getCurrentScores()
        {

        }

        public void getHighScores()
        {
            try
            {
                using (StreamReader reader = new StreamReader("highScores.txt"))
                {
                    String line = reader.ReadToEnd();
                    
                }
            }
            catch (Exception e)
            {
                //TODO boom
            }
        }

        public int addScores(int stones)
        {
            int scores = stones + currentScores;

            return scores;
        }

        private void addToHighScores()
        {
            string path = "highScores.txt";

            try
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                }
            }
            catch (Exception e)
            {
                //TODO boom
            }
        }
    }
}

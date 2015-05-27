using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;

namespace FallingRocks
{
    public class Sound
    {
        public static void PlayBackgroundMusic()
        {
            var soundPlayer = new SoundPlayer(@"c:\background.wav");
            soundPlayer.Play();
        }

        public static void PlayScream()
        {
            var player = new System.Windows.Media.MediaPlayer();
            player.Open(new Uri(@"c:\crash.wav"));

            player.Play();
        }
    }
}

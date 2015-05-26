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
        public void PlayBackgroundMusic()
        {
//            var soundPlayer = new SoundPlayer(@"c:\background.wav");
//            soundPlayer.Play();
        }

        public void PlayScream()
        {
            var soundPlayer = new SoundPlayer(@"c:\background.wav");
            soundPlayer.Play();

            var player = new System.Windows.Media.MediaPlayer();
            player.Open(new Uri(@"c:\crash.wav"));

            player.Play();
        }
    }
}

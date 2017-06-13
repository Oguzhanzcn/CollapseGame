using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Collapsee
{
    class Ses
    {
        public static bool sescaliyorMu;//ses kontrol degıskenı
        static SoundPlayer player = new SoundPlayer();//soundplayerdan nesne yaratıldı
        public static void sescal()
        {
            sescaliyorMu = true;
            string sesyolu = @"C:\Users\oğuzhan\Desktop\OKUL DOSYALARI\Collapsee\Collapsee\bin\Debug\Müzik\Collapse_music.wav";
            player.SoundLocation = sesyolu;
            player.PlayLooping();//sarkı bittiginde tekrar baslatır
        }
        public static void seskapat()
        {
            sescaliyorMu = false;
            player.Stop();
        }
    }
}

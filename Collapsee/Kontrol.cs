using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collapsee
{
    class Kontrol
    {
        public static void anakontrol(int x, int y, Color b_renk)//4 koseyıde kontrol eder
        {
            if (sagindaTasVarmi(x + Blok.btnboyut, y) && tasRenkKontrolu(b_renk, x + Blok.btnboyut, y)) solihmalkontrol(x + Blok.btnboyut, y, b_renk);
            if (solundaTasVarmi(x - Blok.btnboyut, y) && tasRenkKontrolu(b_renk, x - Blok.btnboyut, y)) sagihmalkontrol(x - Blok.btnboyut, y, b_renk);
            if (altindaTasVarmi(x, y + Blok.btnboyut) && tasRenkKontrolu(b_renk, x, y + Blok.btnboyut)) ustihmalkontrol(x, y + Blok.btnboyut, b_renk);
            if (ustundeTasVarmi(x, y - Blok.btnboyut) && tasRenkKontrolu(b_renk, x, y - Blok.btnboyut)) altihmalkontrol(x, y - Blok.btnboyut, b_renk);
        }
        private static void solihmalkontrol(int x, int y, Color b_renk)
        {
            if (!Form1.tiklananlar.Contains(x.ToString() + y.ToString()))
            {
                Form1.tiklananlar.Add(x.ToString() + y.ToString());
                if (sagindaTasVarmi(x + Blok.btnboyut, y) && tasRenkKontrolu(b_renk, x + Blok.btnboyut, y)) solihmalkontrol(x + Blok.btnboyut, y, b_renk);
                if (altindaTasVarmi(x, y + Blok.btnboyut) && tasRenkKontrolu(b_renk, x, y + Blok.btnboyut)) ustihmalkontrol(x, y + Blok.btnboyut, b_renk);
                if (ustundeTasVarmi(x, y - Blok.btnboyut) && tasRenkKontrolu(b_renk, x, y - Blok.btnboyut)) altihmalkontrol(x, y - Blok.btnboyut, b_renk);
            }
        }
        private static void sagihmalkontrol(int x, int y, Color b_renk)
        {
            if (!Form1.tiklananlar.Contains(x.ToString() + y.ToString()))
            {
                Form1.tiklananlar.Add(x.ToString() + y.ToString());
                if (solundaTasVarmi(x - Blok.btnboyut, y) && tasRenkKontrolu(b_renk, x - Blok.btnboyut, y)) sagihmalkontrol(x - Blok.btnboyut, y, b_renk);
                if (altindaTasVarmi(x, y + Blok.btnboyut) && tasRenkKontrolu(b_renk, x, y + Blok.btnboyut)) ustihmalkontrol(x, y + Blok.btnboyut, b_renk);
                if (ustundeTasVarmi(x, y - Blok.btnboyut) && tasRenkKontrolu(b_renk, x, y - Blok.btnboyut)) altihmalkontrol(x, y - Blok.btnboyut, b_renk);
            }
        }
        private static void ustihmalkontrol(int x, int y, Color b_renk)
        {
            if (!Form1.tiklananlar.Contains(x.ToString() + y.ToString()))
            {
                Form1.tiklananlar.Add(x.ToString() + y.ToString());
                if (sagindaTasVarmi(x + Blok.btnboyut, y) && tasRenkKontrolu(b_renk, x + Blok.btnboyut, y)) solihmalkontrol(x + Blok.btnboyut, y, b_renk);
                if (solundaTasVarmi(x - Blok.btnboyut, y) && tasRenkKontrolu(b_renk, x - Blok.btnboyut, y)) sagihmalkontrol(x - Blok.btnboyut, y, b_renk);
                if (altindaTasVarmi(x, y + Blok.btnboyut) && tasRenkKontrolu(b_renk, x, y + Blok.btnboyut)) ustihmalkontrol(x, y + Blok.btnboyut, b_renk);
            }
        }
        private static void altihmalkontrol(int x, int y, Color b_renk)
        {
            if (!Form1.tiklananlar.Contains(x.ToString() + y.ToString()))
            {
                Form1.tiklananlar.Add(x.ToString() + y.ToString());
                if (sagindaTasVarmi(x + Blok.btnboyut, y) && tasRenkKontrolu(b_renk, x + Blok.btnboyut, y)) solihmalkontrol(x + Blok.btnboyut, y, b_renk);
                if (solundaTasVarmi(x - Blok.btnboyut, y) && tasRenkKontrolu(b_renk, x - Blok.btnboyut, y)) sagihmalkontrol(x - Blok.btnboyut, y, b_renk);
                if (ustundeTasVarmi(x, y - Blok.btnboyut) && tasRenkKontrolu(b_renk, x, y - Blok.btnboyut)) altihmalkontrol(x, y - Blok.btnboyut, b_renk);
            }
        }
        private static bool sagindaTasVarmi(int x, int y)
        {
            if (x <= Form1.x * Blok.btnboyut)
                for (int i = 0; i < Form1.x; i++)
                    for (int j = 0; j < Form1.y; j++)
                        if (Form1.btnlar[i, j] != null && Form1.btnlar[i, j].Location.X == x && Form1.btnlar[i, j].Location.Y == y)
                            return true;
            return false;
        }
        private static bool solundaTasVarmi(int x, int y)
        {
            if (x >= 0)
                for (int i = 0; i < Form1.x; i++)
                    for (int j = 0; j < Form1.y; j++)
                        if (Form1.btnlar[i, j] != null && Form1.btnlar[i, j].Location.X == x && Form1.btnlar[i, j].Location.Y == y)
                            return true;
            return false;
        }
        private static bool ustundeTasVarmi(int x, int y)
        {
            if (y >= 0)
                for (int i = 0; i < Form1.x; i++)
                    for (int j = 0; j < Form1.y; j++)
                        if (Form1.btnlar[i, j] != null && Form1.btnlar[i, j].Location.X == x && Form1.btnlar[i, j].Location.Y == y)
                            return true;
            return false;
        }
        private static bool altindaTasVarmi(int x, int y)
        {
            if (y <= Form1.y * Blok.btnboyut)
                for (int i = 0; i < Form1.x; i++)
                    for (int j = 0; j < Form1.y; j++)
                        if (Form1.btnlar[i, j] != null && Form1.btnlar[i, j].Location.X == x && Form1.btnlar[i, j].Location.Y == y)
                            return true;
            return false;
        }
        private static bool tasRenkKontrolu(Color brenk, int x, int y)
        {
            for (int i = 0; i < Form1.x; i++)
                for (int j = 0; j < Form1.y; j++)
                    if (Form1.btnlar[i, j] != null && Form1.btnlar[i, j].Location.X == x && Form1.btnlar[i, j].Location.Y == y)
                        if (Form1.btnlar[i, j].BackColor == brenk)
                            return true;
                        else
                            return false;
            return false;
        }
        public static bool oyunbittimi()
        {
            if (Form1.sayac < 0) return true;
            for (byte j = 0; j < Form1.y; j++)
                if (Form1.btnlar[14, j] != null && Form1.btnlar[14, j].Visible)
                    return true;
            return false;
        }
        public static bool taslarTemizlendiMi()
        {
            if (Form1.btnlar[0, 0] != null && !Form1.btnlar[0, 0].Visible) return true;
            return false;
        }
    }
}

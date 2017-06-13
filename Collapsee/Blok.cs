using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collapsee
{
    class Blok
    {
        public static byte btnboyut = 25;
        public static Button blokOlustur(byte renk, int sayac)
        {
            Button btn = new Button();
            if (sayac == 0) btn.BackColor = Color.Gray;
            else if (renk == 0) btn.BackColor = Color.Red;
            else if (renk == 1) btn.BackColor = Color.Blue;
            else btn.BackColor = Color.Green;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Enabled = false;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.Click += new EventHandler(btn_Click);//butona tıklama ozellıgı ekler
            return btn;//olusulan nesne fonk. tarafından dondurulur
        }
        private static void btn_Click(object sender, EventArgs e)
        {
            Form1.tiklananlar.Clear();
            Form1.tiklananlar.Add((sender as Button).Location.X.ToString() + (sender as Button).Location.Y.ToString());
            Kontrol.anakontrol((sender as Button).Location.X, (sender as Button).Location.Y, (sender as Button).BackColor);
            if (Form1.tiklananlar.Count > 2)
            {
                Duzenle.taslariYokEt();
                Duzenle.taslariAsagiIndir();
                Duzenle.taslariSolaKaydir();
                if (Form1.tiklananlar.Count >= 20) Form1.puan += Form1.tiklananlar.Count * Form1.tiklananlar.Count * 100;
                else if (Form1.tiklananlar.Count >= 10) Form1.puan += Form1.tiklananlar.Count * Form1.tiklananlar.Count * 10;
                else Form1.puan += Form1.tiklananlar.Count * 10;
                if (Kontrol.taslarTemizlendiMi()) Form1.puan += 10000;
            }
            else Form1.puan -= Form1.tiklananlar.Count * 5;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;//color sınıfı ıcın
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//buton sınıfı eklemek ıcın

namespace Collapsee
{
    class Duzenle
    {
        public static void taslariYokEt()
        {
           for (byte i = 0; i < Form1.x; i++)
             for (byte j = 0; j < Form1.y; j++)
                    if (Form1.btnlar[i, j] != null && Form1.tiklananlar.Contains(Form1.btnlar[i, j].Location.X.ToString() + Form1.btnlar[i, j].Location.Y.ToString()))
                        {
                            Form1.btnlar[i, j].Visible = false;//tıklanan butonları gorunmez yapar
                            Form1.btnlar[i, j].BackColor = Color.Pink;//tıklanan butonların rengını degıstırır
                        }
        }
        public static void taslariAsagiIndir()
        {
            for (byte k = 0; k < Form1.x; k++)
                for (byte j = 0; j < Form1.y; j++)
                    for (byte i = Form1.x - 1; i > 1; i--)
                        if (Form1.btnlar[i - 1, j] != null && !Form1.btnlar[i - 1, j].Visible)
                        {
                            Button temp = Form1.btnlar[i, j];
                            Form1.btnlar[i, j] = Form1.btnlar[i - 1, j];
                            Form1.btnlar[i - 1, j] = temp;//yer degıstırme ıslemı
                        }
        }
        public static void taslariSolaKaydir()
        {
            for (byte k = Form1.x - 1; k > 0; k--)
                for (byte j = 0; j <= Form1.y - 2; j++)
                    if (sutunBosmu(j) != 127)
                        for (sbyte i = Form1.x - 1; i >= 0; i--)
                        {
                            Button temp = Form1.btnlar[i, j];
                            Form1.btnlar[i, j] = Form1.btnlar[i, j + 1];
                            Form1.btnlar[i, j + 1] = temp;
                        }
        }
        public static byte sutunBosmu(byte indis)//bos olan sutunun ındısını dondur
        {
            for (byte i = 0; i < Form1.x; i++)
                if (Form1.btnlar[i, indis] != null && Form1.btnlar[i, indis].Visible)
                    return 127;
            return indis;
        }
        public static void renkSifirla()
        {
            for (byte i = 0; i < Form1.x; i++)
            {
                Form1.gecicirenk[Form1.x, i] = Form1.btnlar2[i].BackColor;
                Form1.btnlar2[i].BackColor = Color.Black;
                for (byte j = 0; j < Form1.y; j++)
                    if (Form1.btnlar[i, j] != null && Form1.btnlar[i, j].Visible)
                    {
                        Form1.gecicirenk[i, j] = Form1.btnlar[i, j].BackColor;
                        Form1.btnlar[i, j].BackColor = Color.Black;
                    }
            }
        }
        public static void tekrarRenkAta()
        {
            for (byte i = 0; i < Form1.x; i++)
            {
                if (Form1.btnlar2[i] != null && Form1.btnlar2[i].BackColor == Color.Black)
                    Form1.btnlar2[i].BackColor = Form1.gecicirenk[Form1.x, i];
                for (byte j = 0; j < Form1.y; j++)
                    if (Form1.btnlar[i, j] != null && Form1.btnlar[i, j].BackColor == Color.Black)
                        Form1.btnlar[i, j].BackColor = Form1.gecicirenk[i, j];
            }
        }
    }
}

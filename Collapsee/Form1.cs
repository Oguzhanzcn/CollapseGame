using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collapsee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        public const byte x = 15;
        public const byte y = 17;
        public static Color[,] gecicirenk = new Color[x + 1, y];// renkleri tutar
        public static Button[,] btnlar = new Button[x, y]; //Butonları tutar
        public static Button[] btnlar2 = new Button[x];//yeni gelen butonları tutar
        public static List<string> tiklananlar = new List<string>();//hangi butonun tıklanıldıgını listeye alır
        public static int puan = 0;
        public static int yuksekpuan;
        public static int sayac = 25;
        byte i = 0, renk, s2 = 0;
        int interval = 0;//zorluk seviyesi icin

        private void timer1_Tick(object sender, EventArgs e)//butonlar olusturulur
        {
            renk = Convert.ToByte(rnd.Next(3));
            if (i == x) btntasi();//alt satırı dolunca uste tasır
            btnlar2[i] = Blok.blokOlustur(renk, sayac);
            groupBox2.Controls.Add(btnlar2[i]);
            btnlar2[i].SetBounds(i * Blok.btnboyut + 2, 8, Blok.btnboyut, Blok.btnboyut);
            i++;
        }

        private void timer2_Tick(object sender, EventArgs e)//tasları duzenler
        {
            for (byte k = 1; k < x; k++)
                for (byte j = 0; j < y; j++)
                    if (btnlar[k, j] != null)
                    {
                        btnlar[k, j].Enabled = true;
                        groupBox1.Controls.Add(btnlar[k, j]);
                        btnlar[k, j].SetBounds(j * Blok.btnboyut + 2, 340 - k * Blok.btnboyut - 7, Blok.btnboyut, Blok.btnboyut);
                    }
            bilgilendirme();//skor ve kalan satırı gosterır
        }

        private void btntasi()
        {
            s2++;//ilk uc satırı kontrol degıskenı
            if (s2 == 3) timer1.Interval = interval;//3 satırdan sonra hızını duzenler
            if (s2 > 3) sayac--;//3 satırdan sonra 25 satırı azaltır
            for (i = 0; i < x; i++) btnlar[0, i] = btnlar2[i];//ılk alt satırı uste atar
            for (i = x - 1; i > 0; i--)//her alt satırı bır uste tasır
                for (byte j = 0; j < y; j++)
                    btnlar[i, j] = btnlar[i - 1, j];
            if (Kontrol.oyunbittimi())
            {
                Ses.seskapat();
                groupBox1.Enabled = false;
                timer1.Enabled = false;
                timer2.Enabled = false;
                if (puan > yuksekpuan)
                {
                    DosyalamaIslemleri.dosyayaYaz(puan, interval);
                    MessageBox.Show("Tebrikler! Yeni rekorun sahibi oldun");
                    yuksekpuan = DosyalamaIslemleri.dosyadanOku(interval);
                    textBox1.Text = yuksekpuan.ToString();
                }
                else MessageBox.Show("Oyun Bitti");
            }
        }

        private void button1_Click(object sender, EventArgs e)//durdurma-devam etme butonu
        {
            if (sayac > 0 && interval > 99 && !Kontrol.oyunbittimi())
                if (timer1.Enabled)
                {
                    Duzenle.renkSifirla();
                    Ses.seskapat();
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    groupBox1.Enabled = false;
                    button1.BackgroundImage = Properties.Resources.play_button;
                }
                else
                { 
                    Duzenle.tekrarRenkAta();
                    Ses.sescal();
                    timer1.Enabled = true;
                    timer2.Enabled = true;
                    groupBox1.Enabled = true;
                    button1.BackgroundImage = Properties.Resources.pause_button;
                }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)//Kolay butonu
        {
            interval = 400;
            yenioyun();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)//orta butonu
        {
            interval = 200;
            yenioyun();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)//zor butonu
        {
            interval = 100;
            yenioyun();
        }

        private void button2_Click(object sender, EventArgs e)//try agaın butonu
        {
            if (interval > 99) yenioyun();
            else MessageBox.Show("Zorluk Seçin");
        }

        private void button3_Click(object sender, EventArgs e)//ses ac kapa butonu
        {
            if(timer1.Enabled)
                if (Ses.sescaliyorMu)
                {
                    Ses.seskapat();
                    button3.BackgroundImage = Properties.Resources.sesac;
                }
                else
                {
                    Ses.sescal();
                    button3.BackgroundImage = Properties.Resources.seskis;
                }          
        }

        private void bilgilendirme()
        {
            label2.Text = sayac.ToString();
            textBox1.Text = yuksekpuan.ToString();
            textBox2.Text = puan.ToString();
        }

        private void yenioyun()
        {

            Ses.sescal();
            groupBox1.Enabled = true;
            yuksekpuan = DosyalamaIslemleri.dosyadanOku(interval);
            groupBox1.Controls.Clear();
            groupBox2.Controls.Clear();
            timer1.Interval = 1;
            for (byte j = 0; j < x; j++) btnlar2[j] = null;//buton dizileri temizlenir
            for (byte k = 0; k < x; k++)
                for (byte j = 0; j < x; j++)
                    btnlar[k, j] = null;
            sayac = 25;
            s2 = 0;
            i = 0;
            puan = 0;
            timer1.Enabled = true;
            timer2.Enabled = true;
        }
    }
}

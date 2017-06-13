using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collapsee
{
    class DosyalamaIslemleri
    {
        private static string dosya_yolu;
        public static void dosyayaYaz(int yuksekskor, int zorluk)
        {
            dosyaYolBelirle(zorluk);
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Write);//Filestreamden Nesne yaratıldı
            StreamWriter sw = new StreamWriter(fs);//Streamwriter Nesne yaratıldı
            sw.WriteLine(yuksekskor);//dosyaya yazma işlemi
            sw.Close();
            fs.Close();
        }

        public static int dosyadanOku(int zorluk)
        {
            dosyaYolBelirle(zorluk);
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);//okumak için Filestreamden Nesne yaratıldı
            StreamReader sr = new StreamReader(fs);//Streamreader Nesne yaratıldı
            int a = Convert.ToInt32(sr.ReadLine());
            fs.Close();
            sr.Close();
            return a;
        }
        private static void dosyaYolBelirle(int zorluk)//yazılacak ve okunacak yerı belırler
        {
            if (zorluk == 100) dosya_yolu = @"Skor\skorzor.txt";
            else if (zorluk == 200) dosya_yolu = @"Skor\skororta.txt";
            else dosya_yolu = @"Skor\skorkolay.txt";
        }
    }
}

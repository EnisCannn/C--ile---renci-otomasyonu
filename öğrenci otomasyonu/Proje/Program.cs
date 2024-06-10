namespace DosyaIslemeri
{
    class Program
    {
        static void Main(string[] args)
        {
            DosyayiYoksaOlustur();

            Console.WriteLine("Öğrenci Otomasyon Sistemi");
            int secim;

            do
            {

                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");
                Console.WriteLine("1-)Kayıt ekle");
                Console.WriteLine("2-)Kayıt günceller");
                Console.WriteLine("3-)Kayıtları göster");
                Console.WriteLine("4-)Kayıt sil");
                Console.WriteLine("5-)Cikis");
                secim = int.Parse(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        KayitEkle();
                        break;
                    case 2:
                        KayitGuncelle();
                        break;
                    case 3:
                        KayitlariGoster();
                        break;
                    case 4:
                        KayitSil();
                        break;
                    case 5:
                        Console.WriteLine("Program sonlandı.");
                        break;

                    default:
                        Console.WriteLine("Lütfen 1-5 arasında bir değer giriniz");
                        break;
                }
                
            } while (secim != 5);
            Console.ReadLine();
        }
        static void DosyayiYoksaOlustur()
        {
            if (!File.Exists("C:\\Users\\enisa\\OneDrive\\Masaüstü\\CSharpDosyaIslemleri\\ogrenciBilgileri.txt"))
            {
                File.Create("C:\\Users\\enisa\\OneDrive\\Masaüstü\\CSharpDosyaIslemleri\\ogrenciBilgileri.txt");
            }

        }
        static void KayitEkle()
        {
            int id;
            string isim;
            int yas;
            double not;
            Console.WriteLine("Lutfen ogrencinin idsini giriniz");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Lutfen ogrencinin ismini giriniz.");
            isim = Console.ReadLine();
            Console.WriteLine("Lutfen ogrencinin yasini giriniz");
            yas = int.Parse(Console.ReadLine());
            Console.WriteLine("Lutfen ogrencinin notunu giriniz");
            not = double.Parse(Console.ReadLine());

            File.AppendAllText("C:\\Users\\enisa\\OneDrive\\Masaüstü\\CSharpDosyaIslemleri\\ogrenciBilgileri.txt", id +" "+isim+ " " + yas + " " + not + Environment.NewLine);
             
        }
        static void KayitGuncelle()
        {
            string[] ogrenciler = File.ReadAllLines("C:\\Users\\enisa\\OneDrive\\Masaüstü\\CSharpDosyaIslemleri\\ogrenciBilgileri.txt");

            int degistirilecekid;
            Console.WriteLine("Lütfen güncellemek istediğiniz öğrencinin id sini giriniz.");
            degistirilecekid = int.Parse(Console.ReadLine());
            degistirilecekid--;

            int id;
            string isim;
            int yas;
            double not;
            string[] parcaliveri = ogrenciler[degistirilecekid].Split(' ');
            // = Convert.ToInt32(parcaliveri[0]);
            id = int.Parse(parcaliveri[0]);
            isim = parcaliveri[1];
            yas = int.Parse(parcaliveri[2]);
            not = double.Parse(parcaliveri[3]);

            int secim;

            
                Console.WriteLine("Güncellemek istediğiniz veriyi seçiniz");
                Console.WriteLine("1-)İsim değiştir");
                Console.WriteLine("2-)Yaş değiştir");
                Console.WriteLine("3-)Not değiştir");
                Console.WriteLine("4-)Güncelleme iptal");
                secim = int.Parse(Console.ReadLine());

            do
            {
                switch (secim)
                {
                    case 1:
                        Console.WriteLine("1-)Yeni ismi giriniz");
                        isim = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("2-)Yeni yaşı giriniz");
                        yas = int.Parse(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("3-)Yeni notu giriniz");
                        not = double.Parse(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("4-)Güncelleme iptal edildi");
                        break;
                    default:
                        Console.WriteLine("Lütfen 1-4 arasında değer seçininz.");
                        break;
                }

            }while (secim<1 || secim>4);

            string yenieklenecekveri = id.ToString()+" "+isim+" "+yas.ToString()+" "+not.ToString();
            ogrenciler[id-1] = yenieklenecekveri;

            File.WriteAllLines("C:\\Users\\enisa\\OneDrive\\Masaüstü\\CSharpDosyaIslemleri\\ogrenciBilgileri.txt", ogrenciler);





        }
        static void KayitlariGoster()
        {
            string[] ogrenciler = File.ReadAllLines("C:\\Users\\enisa\\OneDrive\\Masaüstü\\CSharpDosyaIslemleri\\ogrenciBilgileri.txt");

            int[] idler = new int[ogrenciler.Length];
            string[] isimler = new string[ogrenciler.Length];
            int[] yaslar = new int[ogrenciler.Length];
            double[] notlar = new double[ogrenciler.Length];
            string[] parcaliveri;


            int i = 0;
            foreach (var ogrenci in ogrenciler)
            {
                parcaliveri = ogrenci.Split(' ');
                idler[i] = int.Parse(parcaliveri[0]);
                isimler[i] = parcaliveri[1];
                yaslar[i] = int.Parse(parcaliveri[2]);
                notlar[i] = double.Parse(parcaliveri[3]);
                i++;
            }
            for (i = 0; i < idler.Length; i++)
            {
                Console.WriteLine(isimler[i] + " " + yaslar[i] + " " + notlar[i]);
            }
        }
        static void KayitSil()
        {
            string[] ogrenciler = File.ReadAllLines("C:\\Users\\enisa\\OneDrive\\Masaüstü\\CSharpDosyaIslemleri\\ogrenciBilgileri.txt");
            int silinecekid;
            Console.WriteLine("Lütfen güncellemek istediğiniz öğrencinin id sini giriniz.");
            silinecekid = int.Parse(Console.ReadLine());
            

            
           
            int[] idler = new int[ogrenciler.Length];
            string[] isimler = new string[ogrenciler.Length];
            int[] yaslar = new int[ogrenciler.Length];
            double[] notlar = new double[ogrenciler.Length];
            string[] parcaliveri;

            int i = 0;
            foreach (var ogrenci in ogrenciler)
            {
                parcaliveri = ogrenci.Split(' ');
                idler[i] = int.Parse(parcaliveri[0]);
                isimler[i] = parcaliveri[1];
                yaslar[i] = int.Parse(parcaliveri[2]);
                notlar[i] = double.Parse(parcaliveri[3]);
                i++;
            }
            int silineceksatirindeksi = 0;
            while (true)
            {
                if (idler[silineceksatirindeksi] == silinecekid)
                {
                    break;
                }
                silineceksatirindeksi++;
            }

            string[] yenisdosyayagecirilecekKayitlar = new string[ogrenciler.Length-1];
            int sayac = 0;
           for(i = 0; i < ogrenciler.Length; i++)
            {
                if (i != silineceksatirindeksi)
                {
                    yenisdosyayagecirilecekKayitlar[sayac] = ogrenciler[i];
                    sayac++;
                }
            }
            File.WriteAllLines("C:\\Users\\enisa\\OneDrive\\Masaüstü\\CSharpDosyaIslemleri\\ogrenciBilgileri.txt", yenisdosyayagecirilecekKayitlar);
            

        }
    }
}
using System;

namespace Roman_Numerals_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            {
            baslangic:
                /* 
                   I=1 V =5 X=10 L=50 C=100 D=500 M=1000
                   AYNI HARF 3 DEN FAZLA TEKRAR EDEMEZ -
                   EN BÜYÜK SAYI MERKEZE ALINIR.
                   EN BÜYÜK SAYININ SOLUNDAKİLER ÇIKARTILIR.
                   EN BÜYÜK SAYININ SAĞINDAKİLER TOPLANIR.
                */

                Console.Clear();
                string girdi;
                Console.WriteLine("Lütfen Roma rakamı ifadenizi giriniz : ");
                girdi = Console.ReadLine();
                if (romenmi(girdi))
                {
                    if (romenolmakuralı(girdi))
                    {
                        if (merkezbulma(girdi) == 0)
                        {
                            short sonuc = 0;
                            for (int i = 0; i < girdi.Length; i++)
                            {
                                sonuc += degerbulma(girdi[i]);
                            }
                            Console.WriteLine("GİRİLEN ROMA RAKAMININ NÜMERİK KARŞILI : " + sonuc);
                            Console.WriteLine("Tekrar Denemek için R ye basın.");
                            var yeniden = Console.ReadKey();
                            if (yeniden.Key == ConsoleKey.R)
                            {
                                goto baslangic;
                            }
                        }

                        else if (merkezbulma(girdi) == girdi.Length - 1)
                        {
                            short sonuc = degerbulma(girdi[girdi.Length - 1]);
                            for (int i = 0; i < girdi.Length - 1; i++)
                            {
                                sonuc -= degerbulma(girdi[i]);

                            }
                            Console.WriteLine("GİRİLEN ROMA RAKAMININ NÜMERİK KARŞILI : " + sonuc);
                            Console.WriteLine("Tekrar Denemek için R ye basın.");
                            var yeniden = Console.ReadKey();
                            if (yeniden.Key == ConsoleKey.R)
                            {
                                goto baslangic;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("LÜTFEN ROMA SAYILARI KURALLARINI İYİCE ÖĞREN :)");
                        /*
                        Console.WriteLine("ROMA SAYI OLMA KURALLARI:");
                        Console.WriteLine("YANYANA 3 DEN FAZLA AYNI KARAKTER KULLANILAMAZ.");
                        Console.WriteLine("EN BÜYÜK SAYI YA EN SONDA YA EN BAŞTA OLUR.");
                        Console.WriteLine("SAYILARIN YANINDA KENDİNDEN DAHA BÜYÜK SAYILAR OLAMAZ");
                        */
                        Console.WriteLine("Tekrar Denemek için R ye basın.");
                        var yeniden = Console.ReadKey();
                        if (yeniden.Key == ConsoleKey.R)
                        {
                            goto baslangic;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen Romen Rakamları Giriniz.");
                    Console.WriteLine("Tekrar Denemek için R ye basın.");
                    var yeniden = Console.ReadKey();
                    if (yeniden.Key == ConsoleKey.R)
                    {
                        goto baslangic;
                    }
                }
            }
             static bool romenmi(string yazi)
            {
                bool romen = false;
                if (bosmu(yazi) & karakterlerromenmi(yazi) & karaktersayısı(yazi))
                {
                    romen = true;
                }

                return romen;
            } // ilk öncelik roma rakamı mı olduğunu araştırmak.
             static bool bosmu(string yazi)
            {
                bool bosmu = true;

                if (yazi == "")
                {
                    bosmu = false;
                }

                return bosmu;
            }
             static bool karakterlerromenmi(string yazi)
            {
                bool romenmi = false;
                int kacromenvar = 0;
                char karakterler = 'a';

                for (int i = 0; i < yazi.Length; i++)
                {
                    karakterler = yazi[i];
                    if (karakterler == 'I' || karakterler == 'V' || karakterler == 'X' || karakterler == 'L' || karakterler == 'C' || karakterler == 'D' || karakterler == 'M')
                    {
                        kacromenvar++;
                    }
                }
                if (kacromenvar == yazi.Length)
                {
                    romenmi = true;
                }

                return romenmi;
            }
             static bool karaktersayısı(string yazi)
            {
                bool karaktersayısı = true;

                if (yazi.Length > 15)
                {
                    karaktersayısı = false;
                }

                return karaktersayısı;
            }
             static bool romenolmakuralı(string yazi)
            {
                bool romenkurallari = false;

                if (merkezbulma(yazi) == 0 || merkezbulma(yazi) == yazi.Length - 1)
                {
                    if (yanyanakuralinauyuyormu(yazi) && yanındakendindenbuyukolma(yazi))
                    {
                        romenkurallari = true;
                    }
                }

                return romenkurallari;

            } //ikinci olarak roma sayısı mı olduğunu araştırmak.
             static bool yanyanakuralinauyuyormu(string yazi)
            {
                bool yanyanakullanim = true;
                if (yazi.Length > 3)
                {
                    for (int i = 0; i < yazi.Length - 3; i++)
                    {
                        if (yazi[i] == yazi[i + 1] && yazi[i] == yazi[i + 2] && yazi[i] == yazi[i + 3])
                        {
                            yanyanakullanim = false;
                            break;
                        }
                    }
                }
                return yanyanakullanim;
            }
             static sbyte merkezbulma(string yazi)
            {
                sbyte merkez = 0;
                sbyte merkezm = -1;
                sbyte merkezd = -1;
                sbyte merkezc = -1;
                sbyte merkezl = -1;
                sbyte merkezx = -1;
                sbyte merkezv = -1;
                sbyte merkezi = -1;
                for (int i = 0; i < yazi.Length; i++)
                {
                    switch (yazi[i])
                    {
                        case 'M':
                            merkezm = Convert.ToSByte(i);
                            break;

                        case 'D':
                            merkezd = Convert.ToSByte(i);
                            break;
                        case 'C':
                            merkezc = Convert.ToSByte(i);
                            break;
                        case 'L':
                            merkezl = Convert.ToSByte(i);
                            break;
                        case 'X':
                            merkezx = Convert.ToSByte(i);
                            break;

                        case 'V':
                            merkezv = Convert.ToSByte(i);
                            break;
                        case 'I':
                            merkezi = Convert.ToSByte(i);
                            break;
                        default:
                            break;
                    }

                }

                if (merkezm >= merkez)
                {
                    merkez = merkezm;
                }
                else if (merkezd >= merkez)
                {
                    merkez = merkezd;
                }
                else if (merkezc >= merkez)
                {
                    merkez = merkezc;
                }
                else if (merkezl >= merkez)
                {
                    merkez = merkezl;
                }
                else if (merkezx >= merkez)
                {
                    merkez = merkezx;
                }
                else if (merkezv >= merkez)
                {
                    merkez = merkezv;
                }
                else if (merkezi >= merkez)
                {
                    merkez = merkezi;
                }

                return merkez;
            }
             static bool yanındakendindenbuyukolma(string yazi)
            {
                bool yanındakiler = true;
                if (merkezbulma(yazi) == 0)
                {
                    for (int i = 1; i < yazi.Length; i++)
                    {
                        if (!(degerbulma(yazi[i - 1]) >= degerbulma(yazi[i])))
                        {
                            yanındakiler = false;
                            break;
                        }

                    }
                }
                if (merkezbulma(yazi) == yazi.Length - 1)
                {
                    for (int i = yazi.Length - 2; i >= 0; i--)
                    {
                        if (!(degerbulma(yazi[i + 1]) >= degerbulma(yazi[i])))
                        {
                            yanındakiler = false;
                            break;
                        }
                    }
                }

                return yanındakiler;
            }
             static short degerbulma(char harf)
            {
                short degeri = 0;
                if (harf == 'M')
                {
                    degeri = 1000;
                }
                if (harf == 'D')
                {
                    degeri = 500;
                }
                if (harf == 'C')
                {
                    degeri = 100;
                }
                if (harf == 'L')
                {
                    degeri = 50;
                }
                if (harf == 'X')
                {
                    degeri = 10;
                }
                if (harf == 'V')
                {
                    degeri = 5;
                }
                if (harf == 'I')
                {
                    degeri = 1;
                }

                return degeri;
            }

        }
    }
}
  

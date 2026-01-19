using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoBeasts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte šířku pole:");
            int sirka = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Zadejte výšku pole:");
            int vyska = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            BeastInLabyrint hra = new BeastInLabyrint(sirka, vyska);

            hra.SimulujHru(20);

            Console.WriteLine("Simulace dokončena. Stiskněte Enter pro ukončení.");
            Console.ReadLine();
        }
    }

    class Prisera
    {
        public int Radek { get; set; }
        public int Sloupec { get; set; }
        public int Smer { get; set; } // 0:>, 1:v, 2:<, 3:^

        public bool BylaOtocka { get; set; } = false;

        public Prisera(int r, int s, int smer)
        {
            Radek = r;
            Sloupec = s;
            Smer = smer;
        }
    }

    class BeastInLabyrint
    {
        private readonly char[] ZnamenkaPrisery = { '>', 'v', '<', '^' };
        private readonly int[,] Posuny = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        public int Sirka { get; }
        public int Vyska { get; }
        public char[,] Labyrint { get; set; }
        public List<Prisera> SeznamPriser { get; set; }

        public BeastInLabyrint(int sirka, int vyska)
        {
            Sirka = sirka;
            Vyska = vyska;
            Labyrint = new char[vyska, sirka];
            SeznamPriser = new List<Prisera>();

            PrecteniLabyrintu();
            NajdiPrisery();
        }

        public void NajdiPrisery()
        {
            for (int i = 0; i < Vyska; i++)
            {
                for (int j = 0; j < Sirka; j++)
                {
                    int indexSmeru = Array.IndexOf(ZnamenkaPrisery, Labyrint[i, j]);
                    if (indexSmeru >= 0)
                    {
                        SeznamPriser.Add(new Prisera(i, j, indexSmeru));
                    }
                }
            }
        }

        public void PrecteniLabyrintu()
        {
            Console.WriteLine("Vložte mapu bludiště");
            for (int i = 0; i < Vyska; i++)
            {
                string radek = Console.ReadLine();
                if (radek.Length < Sirka) radek = radek.PadRight(Sirka, ' ');

                for (int j = 0; j < Sirka; j++)
                {
                    Labyrint[i, j] = radek[j];
                }
            }
        }

        public void Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Vyska; i++)
            {
                for (int j = 0; j < Sirka; j++)
                {
                    sb.Append(Labyrint[i, j]);
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        public void SimulujHru(int pocetTahu)
        {
            Console.Clear();
            Console.WriteLine("Počáteční stav:");
            Print();
            Console.WriteLine("\nStiskněte Enter pro start...");
            Console.ReadLine();

            for (int krok = 1; krok <= pocetTahu; krok++)
            {
                foreach (var prisera in SeznamPriser)
                {
                    UdelejTahPriserou(prisera);
                }

                Console.Clear();
                Console.WriteLine($"{krok}. krok:");
                Print();
                Console.WriteLine();
                Console.WriteLine("Stiskněte Enter pro další krok...");
                Console.ReadLine();
            }
        }

        private void UdelejTahPriserou(Prisera p)
        {
            int rRovne = p.Radek + Posuny[p.Smer, 0];
            int sRovne = p.Sloupec + Posuny[p.Smer, 1];
            bool volnoRovne = JeVolno(rRovne, sRovne);

            if (p.BylaOtocka)
            {
                p.BylaOtocka = false;
                if (volnoRovne)
                {
                    Labyrint[p.Radek, p.Sloupec] = '.';
                    p.Radek = rRovne;
                    p.Sloupec = sRovne;
                    Labyrint[p.Radek, p.Sloupec] = ZnamenkaPrisery[p.Smer];
                    return;
                }
            }

            int smerVpravo = (p.Smer + 1) % 4;
            int rVpravo = p.Radek + Posuny[smerVpravo, 0];
            int sVpravo = p.Sloupec + Posuny[smerVpravo, 1];
            bool volnoVpravo = JeVolno(rVpravo, sVpravo);

            if (volnoVpravo)
            {
                p.Smer = smerVpravo;
                Labyrint[p.Radek, p.Sloupec] = ZnamenkaPrisery[p.Smer];
                p.BylaOtocka = true;
                return;
            }
            else if (volnoRovne)
            {
                Labyrint[p.Radek, p.Sloupec] = '.';
                p.Radek = rRovne;
                p.Sloupec = sRovne;
                Labyrint[p.Radek, p.Sloupec] = ZnamenkaPrisery[p.Smer];
                return;
            }
            else
            {
                p.Smer = (p.Smer + 3) % 4;
                Labyrint[p.Radek, p.Sloupec] = ZnamenkaPrisery[p.Smer];
            }
        }

        private bool JeVolno(int r, int s)
        {
            if (r < 0 || r >= Vyska || s < 0 || s >= Sirka) return false;
            return Labyrint[r, s] == '.';
        }
    }

}

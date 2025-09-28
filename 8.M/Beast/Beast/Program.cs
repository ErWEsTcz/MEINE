using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("zadejte šírku pole");
            int sirka = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("zadejte výšku pole");
            int vyska = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            BeastInLabyrint kekw = new BeastInLabyrint(sirka, vyska);

            kekw.ProjetiHrou(20);

            Console.ReadLine();
        }

    }

   
    class BeastInLabyrint
    {
        public BeastInLabyrint(int sirka, int vyska)
        {
            Sirka = sirka;
            Vyska = vyska;
            Labyrint = new char[vyska, sirka];
            PozicePrisery = new int[2];
            ZnamenkaPrisery = new char[4] { '>' , 'v', '<', '^' };
            SmeryPrisery = new int[4, 2] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
            PrecteniLabyrintu();
        }
        int Sirka { get; }
        int Vyska { get; }
        char[,] Labyrint { get; set; }
        int[] PozicePrisery { get; set; }
        char[] ZnamenkaPrisery { get; set; }
        int[,] SmeryPrisery {  get; set; }
        int AktualniSmer {  get; set; }
        public void NajdiPriseru()
        {
            for (int i = 0; i < Vyska; i++)
            {
                for (int j = 0; j < Sirka; j++)
                {
                    if (Labyrint[i,j] != 'X' & Labyrint[i,j] != '.')
                    {
                        PozicePrisery[0] = i;
                        PozicePrisery[1] = j;
                        char Znamenko = Labyrint[i, j];
                        for (int z = 0; z < 4; z++)
                        {
                            if(Znamenko == ZnamenkaPrisery[z])
                            {
                                AktualniSmer = z;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void PrecteniLabyrintu()
        {
            Console.WriteLine("vložte pole");
            for (int i = 0; i < Vyska; i++)
            {
                string radek = Console.ReadLine();

                for (int j = 0; j < Sirka; j++)
                {
                    Labyrint[i, j] = radek[j];
                }
            }
            return;
        }

        public void Print()
        {
            for (int i = 0; i < Vyska; i++)
            {
                StringBuilder radek = new StringBuilder();
                for (int j = 0; j < Sirka; j++)
                {
                    radek.Append(Labyrint[i, j]);
                }
                Console.WriteLine(radek.ToString());
            }
        }

        public void ProjetiHrou(int pocetTahu)
        {
            NajdiPriseru();
            for (int i = 1; i < pocetTahu+1; i++)
            {
                if (Labyrint[PozicePrisery[0] + SmeryPrisery[AktualniSmer, 1], PozicePrisery[1] + (-1 * SmeryPrisery[AktualniSmer, 0])] == '.')
                {
                    AktualniSmer = (AktualniSmer + 1) % 4;
                    Labyrint[PozicePrisery[0], PozicePrisery[1]] = ZnamenkaPrisery[AktualniSmer];
                    Console.Clear();
                    Console.WriteLine(i + ". krok");
                    Print();
                    Console.ReadLine();
                    i++;
                    if (i > pocetTahu)
                        break;
                    Labyrint[PozicePrisery[0], PozicePrisery[1]] = '.';
                    PozicePrisery[0] = PozicePrisery[0] + SmeryPrisery[AktualniSmer, 0];
                    PozicePrisery[1] = PozicePrisery[1] + SmeryPrisery[AktualniSmer, 1];
                    Labyrint[PozicePrisery[0], PozicePrisery[1]] = ZnamenkaPrisery[AktualniSmer];

                }
                else if (Labyrint[PozicePrisery[0] + SmeryPrisery[AktualniSmer, 0], PozicePrisery[1] + SmeryPrisery[AktualniSmer, 1]] == 'X')
                {
                    AktualniSmer = (AktualniSmer + 3) % 4;
                    Labyrint[PozicePrisery[0], PozicePrisery[1]] = ZnamenkaPrisery[AktualniSmer];
                }
                else
                {
                    Labyrint[PozicePrisery[0], PozicePrisery[1]] = '.';
                    PozicePrisery[0] = PozicePrisery[0] + SmeryPrisery[AktualniSmer, 0];
                    PozicePrisery[1] = PozicePrisery[1] + SmeryPrisery[AktualniSmer, 1];
                    Labyrint[PozicePrisery[0], PozicePrisery[1]] = ZnamenkaPrisery[AktualniSmer];
                }
                Console.Clear();
                Console.WriteLine(i + ". krok");
                Print();
                Console.ReadLine();
            }
        }
    }
}


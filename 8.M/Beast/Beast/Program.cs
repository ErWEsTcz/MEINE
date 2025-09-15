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
            BeastInLabyrint kekw = new BeastInLabyrint(10, 6);

            kekw.Print();

            kekw.NajdiPriseru();

            Console.ReadLine();
        }

    }

   
    class BeastInLabyrint
    {
        public BeastInLabyrint(int sirka, int vyska)
        {
            Sirka = sirka;
            Vyska = vyska;
            Labyrint = new char[sirka,vyska];
            PozicePrisery = new int[2];
            PrecteniLabyrintu();
        }
        int Sirka { get; }
        int Vyska { get; }
        char[,] Labyrint { get; set; }
        int[] PozicePrisery { get; set; }
        char SmerPrisery { get; set; }

        public void NajdiPriseru()
        {
            for (int i = 0; i < Vyska; i++)
            {
                for (int j = 0; j < Sirka; j++)
                {
                    if (Labyrint[i,j] != 'X' & Labyrint[j,i] != '.')
                    {
                        PozicePrisery[0] = j;
                        PozicePrisery[1] = i;
                        SmerPrisery = Labyrint[i,j];
                        Console.WriteLine(PozicePrisery[0]);
                        Console.WriteLine(PozicePrisery[1]);
                        Console.WriteLine(SmerPrisery);
                        return;
                    }
                }
            }
        }

        public void PrecteniLabyrintu()
        {
            for (int i = 0; i < Vyska; i++)
            {
                string radek = Console.ReadLine();

                for (int j = 0; j < Sirka; j++)
                {
                    Labyrint[j, i] = radek[j];
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
                    radek.Append(Labyrint[j, i]);
                }
                Console.WriteLine(radek.ToString());
            }
        }
    }
}


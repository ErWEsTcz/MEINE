using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace PiskvorkyKontrolaVyhry
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Vítejte ve hře Propadávající piškvorky");
            Console.WriteLine("jakou chcete mít šířku vašeho pole?");
            string odpoved = Console.ReadLine();
            int sirkaPole = ZkouskaSaskovstvi(odpoved);
            Console.WriteLine("jakou chcete mít výšku vašeho pole?");
            odpoved = Console.ReadLine();
            int vyskaPole = ZkouskaSaskovstvi(odpoved);
            Console.WriteLine("Jaký chcete aby byl počet žetonů na výhru?");
            odpoved = Console.ReadLine();
            int pocetNaVyhru = ZkouskaSaskovstvi(odpoved);
            Console.WriteLine("Pro kolik hráčů chcete aby hra byla?");
            odpoved = Console.ReadLine();
            int pocetHracu = ZkouskaSaskovstvi(odpoved);

            Hra hra1 = new Hra(sirkaPole, vyskaPole, pocetNaVyhru, pocetHracu);
            hra1.Play();
            /*
            hra1.Test();
            */
            Console.ReadLine();

        }

        static int ZkouskaSaskovstvi(string odpoved)
        {
            int spravnaOdpoved = 0;
            bool legalniOdpoved = false;
            while (legalniOdpoved == false)
            {
                if (int.TryParse(odpoved, out spravnaOdpoved) != true)
                {
                    Console.WriteLine("číselně prosím");
                }
                else
                {
                    legalniOdpoved = true;
                }
            }
            return spravnaOdpoved;
        }

    }

    class Hra
    {

        int pocetNaVyhru;
        Hrac[] hraci;
        int pocetHracu;
        int sirkaPole;
        int vyskaPole;
        int[,] hraciPole;

        public Hra(int sirkaPole, int vyskaPole, int pocetNaVyhru, int pocetHracu)
        {
            this.pocetNaVyhru = pocetNaVyhru;
            hraciPole = new int[vyskaPole, sirkaPole];
            hraci = new Hrac[pocetHracu];
            this.pocetHracu = pocetHracu;
            this.sirkaPole = sirkaPole;
            this.vyskaPole = vyskaPole;

        }

        public void Play()
        {
            for (int i = 0; i < hraci.Length; i++)
            {
                hraci[i] = new Hrac();
                hraci[i].Symbol = i + 1;
                hraci[i].Hraje = true;
                Console.WriteLine("Zadej jméno hráče číslo " + (i + 1) + ": ");
                hraci[i].Jmeno = Console.ReadLine();
                Console.Clear();
            }

            int[] posledniZeton = { 0, 0 };

            while(true)
            {
                for (int i = 0; i < pocetHracu; i++)
                {
                    if (hraci[i].Hraje == false)
                    {
                        continue;
                    }
                    for (int y = 0; y < vyskaPole; y++)
                    {
                        for (int j = 0; j < sirkaPole; j++)
                        {
                            Console.Write(hraciPole[y, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Hraje hráč jménem " + hraci[i].Jmeno);
                    Console.WriteLine("Chceš se vzdát? (ano/ne)");
                    string odpoved = Console.ReadLine();
                    if (odpoved == "ano")
                    {
                        Console.Clear();
                        Console.WriteLine("Hráč " + hraci[i].Jmeno + " končí");
                        hraci[i].Hraje = false;
                        int pocetHrajicichHracu = 0;
                        string potencionalniVyherce = "nikdo";
                        for (int j = 0; j < pocetHracu; j++)
                        {
                            if (hraci[j].Hraje == true)
                            {
                                pocetHrajicichHracu++;
                                potencionalniVyherce = hraci[j].Jmeno;
                            }
                        }
                        if(pocetHrajicichHracu <= 1)
                        {
                            Console.WriteLine(potencionalniVyherce + " vyhrává");
                            return;
                        }
                        continue;
                    }

                    bool legalniTah = false;
                    int zahranySloupec = 1;
                    string potencionalniZahranySloupec;

                    while (legalniTah != true)
                    {
                        Console.WriteLine("Do jakého sloupce (1 až " + Convert.ToString(sirkaPole) + ") chceš vhodit zeton?");
                        potencionalniZahranySloupec = Console.ReadLine();
                        if (int.TryParse(potencionalniZahranySloupec, out zahranySloupec) == false || (0 < zahranySloupec && zahranySloupec < sirkaPole + 1) == false)
                        {
                            Console.WriteLine("nelegální tah");
                        }
                        else
                        {
                            legalniTah = true;
                        }
                    }

                    legalniTah = false;
                    
                    while (legalniTah != true)
                    {
                        if (hraciPole[0, zahranySloupec -1] == 0)
                        {
                            legalniTah = true;
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Sloupec je plný, vyber jiný");
                            zahranySloupec = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    for (int j = 0; j < vyskaPole; j++)
                    {
                        if (hraciPole[j, zahranySloupec - 1] != 0)
                        {
                            hraciPole[j - 1, zahranySloupec - 1] = hraci[i].Symbol;
                            posledniZeton[0] = j - 1;
                            posledniZeton[1] = zahranySloupec - 1;
                            break;
                        }
                        if (j == vyskaPole - 1 && hraciPole[j, zahranySloupec - 1] == 0)
                        {
                            hraciPole[j, zahranySloupec - 1] = hraci[i].Symbol;
                            posledniZeton[0] = j;
                            posledniZeton[1] = zahranySloupec - 1;
                            break;
                        }
                    }

                    if (CheckVyhry(hraciPole, pocetNaVyhru, posledniZeton))
                    {
                        for (int y = 0; y < vyskaPole; y++)
                        {
                            for (int j = 0; j < sirkaPole; j++)
                            {
                                Console.Write(hraciPole[y, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("vyhrává hráč jménem " + hraci[i].Jmeno + " se symbolem: " + Convert.ToString(hraci[i].Symbol));
                        return;
                    }

                    if (PlnePole(hraciPole))
                    {
                        for (int y = 0; y < vyskaPole; y++)
                        {
                            for (int j = 0; j < sirkaPole; j++)
                            {
                                Console.Write(hraciPole[y, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Remíza");
                        Console.WriteLine("Pole je zaplněné");
                        return;
                    }
                }
            }
        }

        bool PlnePole(int[,] hraciPole)
        {
            for (int i = 0; i < hraciPole.GetLength(1); i++)
            {
                if (hraciPole[0, i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        /*
        public void Test()
        {
            int[,] board = new int[10, 10]
            {
    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
    { 0, 1, 2, 1, 1, 1, 2, 1, 0, 0 },
    { 0, 0, 0, 1, 0, 1, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            };
            int[] pog = { 6, 4 };
            if (CheckVyhry(board, 5, pog))
            {
                Console.WriteLine("vyhra");
            }
            else
            {
                Console.WriteLine("prohra");
            }
            Console.ReadLine();
        }
        */
        public bool CheckVyhry(int[,] hraciPole, int pocetNaVyhru, int[] posledniZeton)
        {
            int radek = posledniZeton[0];
            int sloupec = posledniZeton[1];
            int hledanySymbol = 0;
            for (int i = 0; i < pocetHracu; i++)
            {
                if (hraciPole[radek,sloupec] == hraci[i].Symbol)
                {
                    hledanySymbol = hraci[i].Symbol;
                }
            }
            if (hledanySymbol == 0)
            {
                return false;
            }

            return CheckRadku() || CheckSloupce() || CheckDiagonaly();

            bool CheckRadku()
            {
                int pocet = 1;

                for (int i = 1; sloupec + i < sirkaPole; i++)
                {
                    if (hraciPole[radek,sloupec + i] == hledanySymbol)
                    {
                        pocet ++;
                        if (pocet == pocetNaVyhru)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                for (int i = 1; sloupec - i >= 0; i++)
                {
                    if (hraciPole[radek, sloupec - i] == hledanySymbol)
                    {
                        pocet ++;
                        if (pocet == pocetNaVyhru)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                return false;
            }

            bool CheckSloupce()
            {
                int pocet = 1;

                for (int i = 1; radek + i < vyskaPole; i++)
                {
                    if (hraciPole[radek + i, sloupec] == hledanySymbol)
                    {
                        pocet++;
                        if (pocet == pocetNaVyhru)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                return false;
            }
            
            bool CheckDiagonaly()
            {
                int pocet = 1;

                for (int i = 1; radek + i < vyskaPole && sloupec + i < sirkaPole; i++)
                {
                     if (hraciPole[radek + i, sloupec + i] == hledanySymbol)
                    {
                        pocet++;
                        if (pocet == pocetNaVyhru)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                for (int i = 1; radek - i >= 0 && sloupec - i >= 0; i++)
                {
                    if (hraciPole[radek - i, sloupec - i] == hledanySymbol)
                    {
                        pocet++;
                        if (pocet == pocetNaVyhru)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }



                pocet = 1;

                for (int i = 1; radek - i >= 0 && sloupec + i < sirkaPole ; i++)
                {
                    if (hraciPole[radek - i, sloupec + i] == hledanySymbol)
                    {
                        pocet++;
                        if(pocet == pocetNaVyhru)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                for (int i = 1; radek + i < vyskaPole && sloupec - i >= 0; i++)
                {
                    if (hraciPole[radek + i, sloupec - i] == hledanySymbol)
                    {
                        pocet++;
                        if(pocet == pocetNaVyhru)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                return false;
            }
            
        }

        class Hrac
        {
            public string Jmeno { get; set; }
            public int Symbol { get; set; }

            public bool Hraje {  get; set; }
        }
    }
}

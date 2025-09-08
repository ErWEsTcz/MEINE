using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Connect4_CheckVyhry
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Hra hra1 = new Hra(5, 10, 10, 2);
            hra1.Play();

        }

        static void CheckVyhry(int[,] hraciPole, int PocetNaVyhru, int[] PosledniZeton)
        {

            bool CheckRow()
            {
                for (int i = PosledniZeton[0] - PocetNaVyhru + 1; i < PocetNaVyhru + PosledniZeton[0] - 1; i++)
                {
                    
                }

                return true;
            }


            return;
        }
    }

    class Hra
    {
        //konstruktor
        public Hra(int pocetVyhernichZetonu, int sirkaPole, int vyskaPole, int pocetHracu)
        {
            this.pocetVyhernichZetonu = pocetVyhernichZetonu;
            hraciPole = new int[sirkaPole, vyskaPole];
            hraci = new Hrac[pocetHracu];
        }

        int pocetVyhernichZetonu; // datová položka
        int[,] hraciPole;

        Hrac[] hraci;
        public Hrac Play()
        {
            for (int i = 0; i < hraci.Length; i++)
            {
                hraci[i] = new Hrac();
                hraci[i].Symbol = i + 1;
                Console.WriteLine("Zadej jméno hráče číslo", i+1, ": ");
                hraci[i].Jmeno = Console.ReadLine();
                Console.WriteLine(hraci[i].Jmeno);
                Console.WriteLine(hraci[i].Symbol);
            }

            Hrac hrac = new Hrac();
            Position startPosition = new Position();
            Console.WriteLine("Na řadě je hráč", hrac.Jmeno);
            startPosition.Row = 0;
            startPosition.Column = 0;


            // Tah
            // Check
            //střídání hračů
            return hrac;
        }
        public bool Check(int[,] board, int[] soucasnaPozice, int hrac, int pocetKamenuNaVyhru)
        {
            int radek = soucasnaPozice[0];
            int sloupec = soucasnaPozice[1];
            return CheckColumn(board, radek, sloupec, hrac, pocetKamenuNaVyhru) || CheckRow(board, radek, sloupec, hrac, pocetKamenuNaVyhru) || CheckDiag(board, radek, sloupec, hrac, pocetKamenuNaVyhru);
        }

        bool CheckColumn(int[,] gameField, int radek, int sloupec, int currentPlayer, int reqForWin)
        {
            int pocet = 0;
            int pocetRadku = gameField.GetLength(0);

            for (int i = radek; i < pocetRadku; i++)
            {
                if (gameField[i, sloupec] == currentPlayer)
                {
                    pocet++;
                    if (pocet >= reqForWin)
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

        bool CheckRow(int[,] gameField, int radek, int sloupec, int currentPlayer, int reqForWin)
        {
            int pocet = 1;
            int pocetSloupcu = gameField.GetLength(1);

            for (int i = sloupec + 1; i < pocetSloupcu; i++)
            {
                if (gameField[radek, i] == currentPlayer)
                {
                    pocet++;
                    if (pocet >= reqForWin)
                    {
                        return true;
                    }
                }
                else
                {
                    break;
                }
            }


            for (int i = sloupec - 1; i >= 0; i--)
            {
                if (gameField[radek, i] == currentPlayer)
                {
                    pocet++;
                    if (pocet >= reqForWin)
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

        bool CheckDiag(int[,] gameField, int radek, int sloupec, int currentPlayer, int reqForWin)
        {
            int pocet = 1;
            int pocetRadku = gameField.GetLength(0);
            int pocetSloupcu = gameField.GetLength(1);

            for (int i = 1; radek + i < pocetRadku && sloupec + i < pocetSloupcu; i++)
            {
                if (gameField[radek + i, sloupec + i] == currentPlayer)
                {
                    pocet++;
                    if (pocet >= reqForWin)
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
                if (gameField[radek - i, sloupec - i] == currentPlayer)
                {
                    pocet++;
                    if (pocet >= reqForWin)
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


            for (int i = 1; radek - i >= 0 && sloupec + i < pocetSloupcu; i++)
            {
                if (gameField[radek - i, sloupec + i] == currentPlayer)
                {
                    pocet++;
                    if (pocet >= reqForWin)
                    {
                        return true;
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; radek + i < pocetRadku && sloupec - i >= 0; i++)
            {
                if (gameField[radek + i, sloupec - i] == currentPlayer)
                {
                    pocet++;
                    if (pocet >= reqForWin)
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
    }
    struct Position
    {
        public int Row;
        public int Column;
    }
}

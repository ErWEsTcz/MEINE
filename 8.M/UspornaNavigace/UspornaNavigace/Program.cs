int[,] maticeSousednosti = null;
int[,] maticePlacenosti = null;
int startovniMesto = 0;
int koncoveMesto = 0;


try
{
    using (StreamReader sr = new StreamReader("vstup1.txt"))
    {
        int[] radek = null;
        try
        {
            radek = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        }
        catch
        {
            Console.WriteLine("Neplatný vstup.");
            return;
        }
        int M = radek[0];
        int S = radek[1];
        if (M <= 0 || radek.Length != 2 || S < 0)
        {
            Console.WriteLine("Neplatný vstup.");
            return;
        }
        maticeSousednosti = new int[M, M];
        maticePlacenosti = new int[M, M];
        for (int i = 0; i < S; i++)
        {
            try
            {
                radek = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            }
            catch
            {
                Console.WriteLine("Neplatný vstup.");
                return;
            }
            if (radek.Length != 4)
            {
                Console.WriteLine("Neplatný vstup.");
                return;
            }
            if (radek[0] >= M || radek[0] < 0 || radek[1] >= M || radek[1] < 0)
            {
                Console.WriteLine("Neplatný vstup.");
                return;
            }
            if (radek[2] < 0 || (radek[3] != 0 && radek[3] != 1))
            {
                Console.WriteLine("Neplatný vstup.");
                return;
            }
            maticeSousednosti[radek[0], radek[1]] = radek[2];
            maticeSousednosti[radek[1], radek[0]] = radek[2];
            maticePlacenosti[radek[0], radek[1]] = radek[3];
            maticePlacenosti[radek[1], radek[0]] = radek[3];
        }
        radek = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        startovniMesto = radek[0];
        koncoveMesto = radek[1];
    }
}
catch
{
    Console.WriteLine("Chyba ve vstupu.");
}

var vysledek = UspornaNavigace.NajdiNekratsiCestu(maticeSousednosti, maticePlacenosti, startovniMesto, koncoveMesto);

Console.WriteLine(string.Join(" -> ", vysledek.cesta));
Console.WriteLine(vysledek.vzdalenost);



/*

for (int i = 0; i < maticeSousednosti.GetLength(0); i++)
{
    for (int j = 0; j < maticeSousednosti.GetLength(0); j++)
    {
        Console.Write(maticeSousednosti[i,j].ToString());
    }
    Console.WriteLine();
}

Console.WriteLine();

for (int i = 0; i < maticeSousednosti.GetLength(0); i++)
{
    for (int j = 0; j < maticeSousednosti.GetLength(0); j++)
    {
        Console.Write(maticePlacenosti[i, j].ToString());
    }
    Console.WriteLine();
}

Console.ReadLine();

*/

public class UspornaNavigace
{
    public static (int vzdalenost, List<int> cesta) NajdiNekratsiCestu (int[,] maticeSousednosti, int[,] maticePlacenosti, int startovniMesto, int koncoveMesto)
    {
        int M = maticeSousednosti.GetLength(0);
        int[] vzdalenosti = new int[M];
        int[] vzdalenostiPlacene = new int[M];
        int[] predchozi = new int[M];
        int[] predchoziPlacene = new int[M];
        PriorityQueue<int,int> prioritniFronta = new PriorityQueue<int,int> ();

        for (int i = 0; i < M; i++)
        {
            vzdalenosti[i] = int.MaxValue;
            vzdalenostiPlacene[i] = int.MaxValue;
            predchozi[i] = -1;
            predchoziPlacene[i] = -1;
        }

        vzdalenosti[startovniMesto] = 0;
        vzdalenostiPlacene[startovniMesto] = 0;
        prioritniFronta.Enqueue(startovniMesto, 0);

        while (prioritniFronta.Count > 0)
        {
            int aktualniMesto = prioritniFronta.Dequeue();

            for (int soused = 0; soused < M; soused++)
            {
                int vzdalenostSouseda = maticeSousednosti[aktualniMesto, soused];

                if (vzdalenostSouseda > 0) // existuje cesta
                {
                    if (maticePlacenosti[aktualniMesto,soused] == 1) // pokud je cesta placena -> mohu pridat jen k neplaceny vzdalenosti
                    {
                        if (vzdalenosti[aktualniMesto] != int.MaxValue)
                        {
                            int novaVzdalenost = vzdalenosti[aktualniMesto] + vzdalenostSouseda;

                            if (novaVzdalenost < vzdalenostiPlacene[soused]) // našli jsme lepší vzdálenost?
                            {
                                vzdalenostiPlacene[soused] = novaVzdalenost;
                                predchoziPlacene[soused] = aktualniMesto;

                                prioritniFronta.Enqueue(soused, novaVzdalenost);
                            }
                        }
                    }
                    else // pokud je cesta neplacena -> 2 moznosti bud pridam k placeny nebo k neplaceny vzdalenosti
                    {
                        if (vzdalenosti[aktualniMesto] != int.MaxValue)
                        {
                            int novaVzdalenostNeplacena = vzdalenosti[aktualniMesto] + vzdalenostSouseda;

                            if (novaVzdalenostNeplacena < vzdalenosti[soused])
                            {
                                vzdalenosti[soused] = novaVzdalenostNeplacena;
                                predchozi[soused] = aktualniMesto;

                                prioritniFronta.Enqueue(soused, novaVzdalenostNeplacena);
                            }
                        }

                        if (vzdalenostiPlacene[aktualniMesto] != int.MaxValue)
                        {
                            int novaVzdalenostPlacena = vzdalenostiPlacene[aktualniMesto] + vzdalenostSouseda;

                            if (novaVzdalenostPlacena < vzdalenostiPlacene[soused])
                            {
                                vzdalenostiPlacene[soused] = novaVzdalenostPlacena;
                                predchoziPlacene[soused] = aktualniMesto;

                                prioritniFronta.Enqueue(soused, novaVzdalenostPlacena);
                            }
                        }
                    }
                }
            }
        }

        // nej vzdálenost

        int vzdalenost = -1;
        bool placenost = true;

        if (vzdalenosti[koncoveMesto] != int.MaxValue)
        {
            if (vzdalenostiPlacene[koncoveMesto] != int.MaxValue)
            {
                if (vzdalenosti[koncoveMesto] <= vzdalenostiPlacene[koncoveMesto])
                {
                    vzdalenost = vzdalenosti[koncoveMesto];
                    placenost = false;
                }
                else
                {
                    vzdalenost = vzdalenostiPlacene[koncoveMesto];
                    placenost = true;
                }
            }
            else
            {
                vzdalenost = vzdalenosti[koncoveMesto];
                placenost = false;
            }
        }
        else if (vzdalenostiPlacene[koncoveMesto - 1] != int.MaxValue)
        {
            vzdalenost = vzdalenostiPlacene[koncoveMesto];
            placenost = true;
        }

        // rekonstrukce cesty

        List<int> cesta = new List<int>();
        int[] aktualniPredchozi;

        if (placenost)
        {
            aktualniPredchozi = predchoziPlacene;
        }
        else
        {
            aktualniPredchozi = predchozi;
        }

        /*

        Console.WriteLine(string.Join(", ",predchozi));
        Console.WriteLine(string.Join(", ", predchoziPlacene));

        */

        int aktualniPozice = koncoveMesto;
        cesta.Add(aktualniPozice);

        while (aktualniPozice != startovniMesto)
        {
            if (maticePlacenosti[aktualniPozice, aktualniPredchozi[aktualniPozice]] == 1)
            {
                aktualniPozice = aktualniPredchozi[aktualniPozice];
                aktualniPredchozi = predchozi;
            }
            else
            {
                aktualniPozice = aktualniPredchozi[aktualniPozice];
            }
            cesta.Add(aktualniPozice);

        }

        cesta.Reverse();

        return (vzdalenost, cesta);
    }
}


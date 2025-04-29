using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postfix_Vyrazy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VyhodnocovaniVyrazu vyhodnocovaniVyrazu = new VyhodnocovaniVyrazu();
            vyhodnocovaniVyrazu.Main();
        }
    }

    class VyhodnocovaniVyrazu
    {
        public void Main()
        {
            Console.WriteLine("Chcete vyhodnotit prefix nebo postfix?");
            string fix = Console.ReadLine();
            Console.WriteLine("Zadejte výraz");
            string[] vyraz = Console.ReadLine().Split(' ');
            //Console.WriteLine(vyraz[1]);
            if (fix == "prefix")
            {
                Array.Reverse(vyraz);
                Postfix(vyraz, fix);
            }

            else if (fix == "postfix")
            {
                Postfix(vyraz, fix);
            }

            Console.ReadLine();

        }

        static void Postfix(string[] vyraz, string fix)
        {
            Stack<float> ZasobnikCisel = new Stack<float>();

            for (int i = 0; i < vyraz.Length; i++)
            {
                try
                {
                    ZasobnikCisel.Push(float.Parse(vyraz[i], NumberStyles.Float, CultureInfo.InvariantCulture));
                }
                catch
                {
                    if (ZasobnikCisel.Count < 2)
                    {
                        Console.WriteLine("Chybný vstup");
                        return;
                    }
                    switch (Convert.ToChar(vyraz[i]))
                    {
                        case '+':
                            ZasobnikCisel.Push(ZasobnikCisel.Pop()+ZasobnikCisel.Pop());
                            break;
                        case '-':
                            if (fix == "prefix")
                            {
                                float mensenec = ZasobnikCisel.Pop();
                                float mensitel = ZasobnikCisel.Pop();
                                ZasobnikCisel.Push(mensenec - mensitel);
                                break;
                            }
                            else
                            {
                                float mensitel = ZasobnikCisel.Pop();
                                float mensenec = ZasobnikCisel.Pop();
                                ZasobnikCisel.Push(mensenec - mensitel);
                                break;
                            }
                        case '*':
                            ZasobnikCisel.Push(ZasobnikCisel.Pop()*ZasobnikCisel.Pop());
                            break;
                        case '/':
                            try
                            {
                                if (fix == "prefix")
                                {
                                    float delenec = ZasobnikCisel.Pop();
                                    float delitel = ZasobnikCisel.Pop();
                                    ZasobnikCisel.Push(delenec / delitel);
                                    if (delitel == 0)
                                    {
                                        Console.WriteLine("Neděl nulou nulo!");
                                        return;
                                    }
                                    break;
                                }
                                else
                                {
                                    float delitel = ZasobnikCisel.Pop();
                                    float delenec = ZasobnikCisel.Pop();
                                    ZasobnikCisel.Push(delenec / delitel);
                                    if (delitel == 0)
                                    {
                                        Console.WriteLine("Neděl nulou nulo!");
                                        return;
                                    }
                                    break;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Neděl nulou nulo!");
                                break;
                            }
                    }
                }
            }

            if (ZasobnikCisel.Count > 1)
            {
                Console.WriteLine("Chybný vstup");
                return;
            }

            Console.WriteLine(ZasobnikCisel.Pop());
            return;
        }

    }
}

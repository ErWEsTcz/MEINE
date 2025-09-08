using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PostfixStrom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PostfixStrom<string> postfixStrom = new PostfixStrom<string>();
            string[] vstup = Console.ReadLine().Split(' ');
            postfixStrom.Create(vstup);
            postfixStrom.ShowPrefix();
            postfixStrom.ShowPostfix();
            postfixStrom.ShowInfix();
            postfixStrom.Vyhodnoceni(vstup);
            Console.ReadLine();
        }
    }

    class Node<T>
    {
        public string Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }
    }


    class PostfixStrom<T>
    {
        public Node<T> Root { get; set; }

        public void Create(string[] postfix)
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();

            for (int i = 0; i < postfix.Length; i++)
            {
                Node<T> node = new Node<T>();
                node.Value = postfix[i];

                if (!float.TryParse(postfix[i], NumberStyles.Float, CultureInfo.InvariantCulture, out float result))
                {
                    try
                    {
                        node.Right = stack.Pop();
                        node.Left = stack.Pop();
                    }
                    catch
                    {
                        Console.WriteLine("Špatně zadaný výraz");
                    }
                }

                stack.Push(node);
            }
            Root = stack.Pop();
        }

        public string ShowInfix()
        {
            // vrací string, abychom použít Console.WriteLine() 
            string output = "";

            void _show(Node<T> node)
            {
                if (node == null)
                    return;

                if (node != Root)
                {
                    if (!float.TryParse(node.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out float x))
                    {
                        output += "( ";
                    }
                }

                _show(node.Left);

                output += node.Value + " ";

                _show(node.Right);

                if (node != Root)
                {
                    if (!float.TryParse(node.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out float y))
                    {
                        output += ") ";
                    }
                }

            }

            if (Root == null)
                return "Strom je prázdný";
            _show(Root);
            Console.WriteLine(output);
            return output;
        }

        public string ShowPostfix()
        {
            string output = "";

            void _show(Node<T> node)
            {
                if (node == null)
                    return;

                _show(node.Left);

                _show(node.Right);

                output += node.Value + " ";
            }

            if (Root == null)
                return "Strom je prázdný";
            _show(Root);
            Console.WriteLine(output);
            return output;
        }

        public string ShowPrefix()
        {
            string output = "";

            void _show(Node<T> node)
            {
                if (node == null)
                    return;

                output += node.Value + " ";

                _show(node.Left);

                _show(node.Right);
            }

            if (Root == null)
                return "Strom je prázdný";
            _show(Root);
            Console.WriteLine(output);
            return output;
        }

        public void Vyhodnoceni(string[] vyraz)
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
                            ZasobnikCisel.Push(ZasobnikCisel.Pop() + ZasobnikCisel.Pop());
                            break;
                        case '-':
                            float mensitel = ZasobnikCisel.Pop();
                            float mensenec = ZasobnikCisel.Pop();
                            ZasobnikCisel.Push(mensenec - mensitel);
                            break;
                            
                        case '*':
                            ZasobnikCisel.Push(ZasobnikCisel.Pop() * ZasobnikCisel.Pop());
                            break;
                        case '/':
                            try
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

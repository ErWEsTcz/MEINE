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
            postfixStrom.Create(Console.ReadLine().Split(' '));
            postfixStrom.ShowPrefix();
            postfixStrom.ShowPostfix();
            postfixStrom.ShowInfix();
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

    }
}

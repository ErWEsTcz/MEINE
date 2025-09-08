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
            postfixStrom.Show();
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
                    node.Right = stack.Pop();
                    node.Left = stack.Pop();
                }

                stack.Push(node);
            }
            Root = stack.Pop();
        }

        public string Show()
        {
            // vrací string, abychom použít Console.WriteLine()
            string output = "";

            void _show(Node<T> node)
            {
                if (node == null)
                    return;
                // pokračování
                _show(node.Left);

                // výpis
                output += node.Value + " ";

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<string> node1 = new Node<string>(1, "Čau");
            Node<string> node2 = new Node<string>(2, "Zdravím");
            Node<string> node3 = new Node<string>(3, "Ahoj");
            Node<string> node4 = new Node<string>(4, "kekw");
            Node<string> node5 = new Node<string>(5, "cscs");

            node1.RightSon = node2;
            node2.RightSon = node3;
            node3.RightSon = node4;
            node4.RightSon = node5;

            BST<string> tree = new BST<string>();
            tree.Root = node1;

            Console.WriteLine(tree.Show());

            Console.WriteLine(tree.Find(4));

            Console.ReadLine();
        }
    }

    class Node<T> // generický typ T
    {
        public int Key { get; set; }

        public T Value { get; set; } // Value má obecný typ T

        public Node<T> LeftSon { get; set; }

        public Node<T> RightSon { get; set; }

        //konstruktor
        public Node(int key, T value) 
        {
            Key = key;
            Value = value;
        }
    }

    class BST<T>
    {
        public Node<T> Root { get; set; }

        public string Show()
        {
            //vrací string, abychom mohli použít cw

            string output = "";

            void _show(Node<T> node)
            {
                if (node == null)
                    return;

                _show(node.LeftSon);

                //výpis
                output += node.Key.ToString() + " ";

                _show(node.RightSon);
            }

            if (Root == null)
                return "Strom je prázdný";

            _show(Root);

            return output;
        }

        public T Find(int key)
        {
            Node<T> _find(Node<T> node, int key2)
            {
                if(node== null)
                    return null;

                if (node.Key == key)
                    return (node);

                if(key < node.Key)
                    return _find(node.LeftSon, key);
                else
                    return _find(node.RightSon, key);
            }

            Node<T> output = _find(Root, key);
            if (output == null)
                return default(T);

            return output.Value;

        }

        public T FindMin(int key)
        {
            Node<T> _findmin(Node<T> node, int key2)
            {

            }
        }
    }
}

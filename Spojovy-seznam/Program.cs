using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Spojovy_seznam
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        class Node
        {
            public Node(int value) // konstruktor třídy Node
            {
                Value = value;
            }

            public int Value { get; }

            public Node Next { get; set; }
        }

        class LinkedList
        {
            public Node Head { get; set; }

            public void Add(int value) // přidat objekt do seznamu
            {
                if (Head == null) // když je seznam prázdný
                {
                    Head = new Node(value);
                }
                else
                {
                    Node newNode = new Node(value);
                    newNode.Next = Head;
                    Head = newNode;
                }
            }


            public bool Find(int value)
            {
                Node node = Head;

                while (node != null) // dokud nedojedeme na konec seznamu
                {
                    if (node.Value == value)
                    {
                        return true;
                    }
                    node = node.Next;
                }
                return false;
            }

            public void FindMinimum()
            {
                Node node = Head;

                if (Head == null)
                {
                    Console.WriteLine("List je prázdný xD");
                    return;
                }

                int Minimum = Head.Next.Value;

                while (node != null) // dokud nedojedeme na konec seznamu
                {
                    if (Minimum > node.Value)
                    {
                        Minimum = node.Value;
                    }
                    node = node.Next;
                }
                Console.WriteLine(Minimum);
            }
        }
    }
}

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
            LinkedList idk = new LinkedList();
            idk.Add(6);
            idk.Add(2);
            idk.Add(8);
            idk.Add(4);
            idk.Add(10);

            idk.PrintLinkedList();
            idk.SortLinkedList();
            Console.WriteLine();
            idk.PrintLinkedList();
            Console.ReadLine();
        }

        class Node
        {
            public Node(int value) // konstruktor třídy Node
            {
                Value = value;
            }

            public int Value { get; }

            public Node Prev { get; set; }
            public Node Next { get; set; }
        }

        class LinkedList
        {
            public Node Head { get; set; }
            public Node Tail { get; set; }

            public void Add(int value) // přidat objekt do seznamu // O(1)
            {
                if (Head == null) // když je seznam prázdný
                {
                    Head = new Node(value);
                    Tail = Head;
                }
                else
                {
                    Node newNode = new Node(value);
                    newNode.Next = Head;
                    Head.Prev = newNode;
                    Head = newNode;
                }
            }


            public bool Find(int value) // O(n)
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

            public void FindMinimum() // O(n)
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

            public void PrintLinkedList() // O(n)
            {
                Node node = Head;

                while (node != null) // dokud nedojedeme na konec seznamu
                {
                    Console.WriteLine(node.Value);
                    node = node.Next;
                }
            }

            public void Remove(Node node)
            {
                if (node != Head)
                    node.Prev.Next = node.Next;
                else
                    Head = node.Next;

                if (node != Tail)
                    node.Next.Prev = node.Prev;
                else
                    Tail = node.Prev;
            }

            public void Insert(Node node, Node prevNode)
            {
                node.Prev = prevNode;
                node.Next = prevNode.Next;

                if (prevNode != Tail)
                    prevNode.Next.Prev = node;
                else
                    Tail = node;

                prevNode.Next = node;
            }

            public void SortLinkedList() // O(n^2)
            {
                if (Head == null | Head.Next == null)
                {
                    return;
                }

                while (true)
                {
                    bool sorted = true;
                    Node node = Head;

                    while (node.Next != null) // dokud nedojedeme na konec seznamu
                    {
                        if (node.Value > node.Next.Value)
                        {
                            Remove(node);
                            Insert(node, node.Next);
                            sorted = false;
                        } else
                        {
                            node = node.Next;
                        }
                    }

                    if (sorted)
                    {
                        return;
                    }
                }
            }

            public void DestructivePenetration(LinkedList list2)
            {

            }
        }
    }
}

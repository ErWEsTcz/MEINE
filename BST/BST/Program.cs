using System;
using System.Collections.Generic;
using System.IO;
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
            BST<Student> tree = new BST<Student>();

            // čteme data z CSV souboru se studenty (soubor je uložen ve složce projektu bin/Debug u exe souboru)
            // CSV je formát, kdy ukládáme jednotlivé hodnoty oddělené čárkou
            // v tomto případě: Id,Jméno,Příjmení,Věk,Třída
            using (StreamReader streamReader = new StreamReader("studenti_shuffled.csv"))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    string[] studentData = line.Split(',');

                    Student student = new Student(
                        Convert.ToInt32(studentData[0]),    // Id
                        studentData[1],                     // Jméno
                        studentData[2],                     // Příjmení
                        Convert.ToInt16(studentData[3]),    // Věk
                        studentData[4]);                    // Třída

                    // vložíme studenta do stromu, jako klíč slouží jeho Id
                    tree.Insert(student.Id, student);
                    line = streamReader.ReadLine();
                }
            }

            Console.WriteLine(tree.Find(20));

            Console.WriteLine(tree.FindMin());

            Student Tichota = new Student(420,"Jan","Tichon",18,"7.M");

            tree.Insert(Tichota.Id, Tichota);



            Console.WriteLine(tree.Show());

            //Console.WriteLine(tree.Find(4));

            //Console.WriteLine(tree.FindMin());

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

        public T FindMin()
        {
            Node<T> _findmin(Node<T> node)
            {
                if (node == null)
                    return null;
                if (node.LeftSon == null)
                    return node;
                else
                    return _findmin(node.LeftSon);
            }

            Node<T> output = _findmin(Root);
            if (output == null) 
                return default(T);

            return output.Value;
        }

        public void Insert(int newKey, T newValue)
        {
            Node<T> node = new Node<T>(newKey, newValue);


            void _insert(Node<T> porovnavac, Node<T> node2)
            {
                if (porovnavac == null)
                {
                    Root = node2;
                    return;
                }

                if (node2.Key < porovnavac.Key)
                {
                    if (porovnavac.LeftSon == null)
                    {
                        porovnavac.LeftSon = node2;
                        return;
                    }

                    _insert(porovnavac.LeftSon, node2);
                }

                if (node2.Key > porovnavac.Key)
                {
                    if (porovnavac.RightSon == null)
                    {
                        porovnavac.RightSon = node2;
                        return;
                    }

                    _insert(porovnavac.RightSon, node2);
                }

                return;
            }

            _insert(Root, node);
            return;

        }
    }
    class Student
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public string ClassName { get; }

        public Student(int id, string firstName, string lastName, int age, string className)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            ClassName = className;
        }

        // aby se nám při Console.WriteLine(student) nevypsala jen nějaká adresa v paměti,
        // upravíme výpis objektu typu student na něco čitelného
        public override string ToString()
        {
            return string.Format("{0} {1} (ID: {2}) ze třídy {3}", FirstName, LastName, Id, ClassName);
        }
    }
}

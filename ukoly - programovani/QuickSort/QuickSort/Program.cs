using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 5, 3, 8, 4, 2, 7, 1, 6 };
            
            List<int> setrizeno = QuickSort(list);

            Console.WriteLine(string.Join(", ", setrizeno));
            
            Console.ReadLine();
        }
        
        static List<int> QuickSort(List<int> posloupnost)
        {
            if (posloupnost.Count <= 0)
                return posloupnost;

            int p = posloupnost[0];
            List<int> mensi = new List<int>();
            List<int> vetsi = new List<int>();
            List<int> stejny = new List<int>();

            for (int i = 0; i < posloupnost.Count; i++)
            {
                if (posloupnost[i] < p)
                    mensi.Add(posloupnost[i]);
                if (posloupnost[i] > p)
                    vetsi.Add(posloupnost[i]);
                if (posloupnost[i] == p)
                    stejny.Add(posloupnost[i]);
            }

            mensi = QuickSort(mensi);
            vetsi = QuickSort(vetsi);

            List<int> setrizenaPosloupnost = new List<int>();

            setrizenaPosloupnost.AddRange(mensi);
            setrizenaPosloupnost.AddRange(stejny);
            setrizenaPosloupnost.AddRange(vetsi);


            return setrizenaPosloupnost;
        }
    }
}

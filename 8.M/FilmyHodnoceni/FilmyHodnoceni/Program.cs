using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmyHodnoceni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Film film = new Film("kekw", "Sasek", "Klaun", 1905);
            film.PridaniHodnoceni(5);
            film.PridaniHodnoceni(2);
            Console.WriteLine(film.Hodnoceni);
            Console.WriteLine(film.VypisVsechHodnoceni());
            Console.ReadLine();
        }
    }

    class Film
    {
        public Film(string nazev, string jmenoRezisera, string prijmeniRezisera, int rokVzniku)
        {
            Nazev = nazev;
            JmenoRezisera = jmenoRezisera;
            PrijmeniRezisera = prijmeniRezisera;
            RokVzniku = rokVzniku;
            VsechnaHodnoceni = new List<int>();
        }

        string Nazev { get; }
        string JmenoRezisera { get; }
        string PrijmeniRezisera { get; }
        int RokVzniku { get; }

        public double Hodnoceni { get; private set; }

        List<int> VsechnaHodnoceni { get; set; }


        public void PrumerneHodnoceni()
        {
            double soucet = 0;
            foreach (int i in VsechnaHodnoceni) { soucet += i; }
            Hodnoceni = soucet/VsechnaHodnoceni.Count();
        }

        public void PridaniHodnoceni(int hodnoceni)
        {
            VsechnaHodnoceni.Add(hodnoceni);
            PrumerneHodnoceni();
        }

        public string VypisVsechHodnoceni()
        {
            string vsechnaHodnoceni = String.Join(", ", VsechnaHodnoceni);
            return vsechnaHodnoceni;
        }

        public override string ToString()
        {
            return ( Nazev,  RokVzniku, PrijmeniRezisera, { 1.písmeno jména režiséra}):  Hodnoceni, "⭐");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MatematickeFunkce
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    struct Interval
    {
        public int Bottom {  get; set; }
        public int Top { get; set; }
        private string BottomBracket { get; set; }
        public string TopBracket { get; set; }

        public Interval(int bottom, int top, string bottomBracket, string topBracket)
        {
            Bottom = bottom;
            Top = top;
            BottomBracket = bottomBracket;
            TopBracket = topBracket;
        }

        public override string ToString()
        {
            return $"{BottomBracket} {Bottom}, {Top} {TopBracket}";
        }

    }

    abstract class MathFunction
    {
        string Name { get; }
        string Description { get; }
        Interval Domain { get; }
        Interval Range { get; }

        protected MathFunction(string name, string description, Interval domain, Interval range)
        {
            Name = name ;
            Description = description ;
            Domain = domain ;
            Range = range ;
        }

        public abstract double CalculationForX(double x);



        class Linear : MathFunction
        {
            int a { get ; set; }
            int b { get ; set; }

            public Linear(string name, string description, Interval domain, Interval range, int a, int b) : base(name, description, domain, range)
            {
                this.a = a ;
                this.b = b ;
            }

            public override double CalculationForX(double x)
            {
                return (a*x +b);
            }

        }

        class AbsoluteLinear : MathFunction
        {

        }

        class FractionalLinear : MathFunction
        {

        }

        class Quadratic : MathFunction
        {

        }
    }
}

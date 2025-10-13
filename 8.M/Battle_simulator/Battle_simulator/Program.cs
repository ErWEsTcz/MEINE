using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character[] army1 = new Character[10];
            Character[] army2 = new Character[10];

            Random generator = new Random();

            for (int i = 0; i < 10;)
            {
                int typ = generator.Next(2);

                switch (typ)
                {
                    case 0:
                        army1[i] = new Wizard("saseksholi");
                        break;
                    case 1:
                        army1[i] = new Warrior("saseksmecem");
                        break;
                    case 2:
                        army1[i] = new Archer("sasekslukem");
                        break;
                }
            }

            for (int i = 0; i < 10;)
            {
                int typ = generator.Next(2);

                switch (typ)
                {
                    case 0:
                        army2[i] = new Wizard("saseksholi");
                        break;
                    case 1:
                        army2[i] = new Warrior("saseksmecem");
                        break;
                    case 2:
                        army2[i] = new Archer("sasekslukem");
                        break;
                }
            }



        }
    }


    abstract class Character
    {
        public Character(string name)
        {
            Name = name;
        }

        protected string Name { get; }
        protected int Health { get; set; }
        protected int Power {  get; set; }

        public virtual void Attack(Character target)
        {
            target.TakeDamage(Power);
            if (!target.IsAlive())
                Power++;
            if (target.GetType() == typeof(Wizard))
                Health = Health - (Power / 2);
        }

        protected void TakeDamage(int amount)
        {
            Health = Health - amount;
        }

        protected bool IsAlive()
        {
            if (Health > 0)
                return true;
            else
                return false;
        }
    }

    class Wizard : Character
    {
        public Wizard(string name) : base(name)
        {
            Health = 35;
            Power = 25;
        }

        public override void Attack(Character target)
        {
            base.Attack(target);
            Console.WriteLine("Wizard");
        }
    }

    class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {
            Health = 100;
            Power = 5;
        }

        public override void Attack(Character target)
        {
            base.Attack(target);
            Console.WriteLine("Warrior");
        }

    }

    class Archer : Character
    {
        public Archer(string name) : base(name)
        {
            Health = 50;
            Power = 15;
        }

        public override void Attack(Character target)
        {
            base.Attack(target);
            Console.WriteLine("Archer");
        }

    }
}

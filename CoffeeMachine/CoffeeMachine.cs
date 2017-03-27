using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoffeeMachine
{
    public class Card
    {
        public int PIN { get; private set; }

        public Card(string PIN)
        {
            this.PIN = Convert.ToInt32(File.ReadAllText(PIN));
        }
    }
    
    enum CoffeeClass
    {
        Cappucino,
        Moccacino,
        Americano,
    }

    class CoffeeMachine
    {
        public Interface machineinterface { get; private set; }

        private Cup TakeCup()
        {
            return new Cup();
        }

        private Water TakeWater()
        {
            return new Water();
        }

        private Water BoilWater(Water w)
        {
            w.Boil();
            return w;
        }

        private void Fill(Cup c, Water w)
        {
            c.Fill(w);
        }

        private void AddCoffee(Cup c, int type )
        {
            switch (type)
            {
                case 0:
                    c.AddCoffee(new Cappucino());
                    return;
                case 1:
                    c.AddCoffee(new Cappucino());
                    return;
                case 2:
                    c.AddCoffee(new Cappucino());
                    return;
            }
        }

        private void AddSugar(Cup c, Sugar s)
        {
            c.AddSugar(s);
        }

        public bool TakeCard(string CardInfo)
        {
            int pin;
            int tries = 0;
            Card c = new Card(CardInfo);
            while (true)
            {
                Console.SetCursorPosition(machineinterface.cash.Y, machineinterface.cash.X);
                if (int.TryParse(Console.ReadLine(), out int n))
                    pin = n;
                else
                    pin = 0;
                Console.SetCursorPosition(machineinterface.cash.Y, machineinterface.cash.X);
                Console.Write("          ");
                Console.SetCursorPosition(machineinterface.cash.Y, machineinterface.cash.X);
                if (CheckCard(c, pin))
                {
                    Console.Write("Correct");
                    Console.ReadKey();
                    Console.SetCursorPosition(machineinterface.cash.Y, machineinterface.cash.X);
                    Console.Write("       ");
                    return true;
                }
                else
                {
                    if (tries > 1) return false;
                    tries++;
                }
            }
        }

        private bool CheckCard(Card c,int PIN)
        {
            return c.PIN==PIN ? true : false;
        }

        public double TakeCash(double finalcost)
        {
            Console.SetCursorPosition(machineinterface.cash.Y, machineinterface.cash.X);
            double cash;
            double cost=0;
            while (true)
            {
                cash = Convert.ToDouble(Console.ReadLine());
                Console.SetCursorPosition(machineinterface.cash.Y, machineinterface.cash.X);
                Console.Write("       ");
                Console.SetCursorPosition(machineinterface.cash.Y, machineinterface.cash.X);
                switch (cash)
                {
                    case 1:
                    case 5:
                    case 10:
                    case 50:
                    case 100:
                    case 500:
                    case 1000:
                    case 5000:
                        cost += cash;
                        Console.SetCursorPosition(machineinterface.change.Y, machineinterface.change.X);
                        Console.Write($"{cost-finalcost}   ");
                        Console.SetCursorPosition(machineinterface.cash.Y, machineinterface.cash.X);
                        break;
                    default:
                        break;
                }
                if (cost >= finalcost)
                {
                    Console.SetCursorPosition(machineinterface.cash.Y, machineinterface.cash.X);
                    Console.Write("        ");
                    return cost - finalcost;
                }
            }
        }

        private void GiveOrder(Cup cup)
        {
            Console.SetCursorPosition(machineinterface.ordershow.Y, machineinterface.ordershow.X);
            StringBuilder s = new StringBuilder();
            s.Append($"Your {cup.coffee.Info}");
            if (cup.sugar != null)
                s.Append(" with sugar");
            s.Append(" is ready");
            Console.WriteLine(s);
        }

        public void MakeOrder(int coffeecounter, bool addsugar)
        {
            Cup c = new Cup();
            Water w = BoilWater(new Water());
            Fill(c, w);
            AddCoffee(c, coffeecounter);
            if (addsugar) AddSugar(c, new Sugar());
            GiveOrder(c);
        }

        public CoffeeMachine(string folder)
        {
            machineinterface = new Interface();
            machineinterface.CreateMachine(folder);
        }
    }

    public class Cup
    {
        public void Fill(Water w)
        {
            water = w;
        }

        public void AddCoffee(Coffee c)
        {
            coffee = c;
        }

        public void AddSugar(Sugar s)
        {
            sugar = s;
        }
        public Water water;
        public Coffee coffee { get; private set; }
        public Sugar sugar { get; private set; }
    }

    public class Water
    {
        public void Boil() { }
    }

    public class Sugar
    {
        public int Cost = 5;
    }

    public abstract class Coffee
    {
        public string Info { get; protected set; }
        public double Cost { get; protected set; }
    }

    public class Cappucino:Coffee
    {
        public Cappucino()
        {
            Info = "cappucino";
            Cost = 25;
        }
    }

    public class Americano:Coffee
    {
        public Americano()
        {
            Info = "americano";
            Cost = 30;
        }
    }

    public class Moccacino:Coffee
    {
        public Moccacino()
        {
            Info = "moccacino";
            Cost = 27.5;
        }
    }
}

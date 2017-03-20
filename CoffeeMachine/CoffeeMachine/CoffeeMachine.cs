using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoffeeMachine
{
    class CoffeeMachine
    {
        
        public Cup CreateCup()
        {
            return new Cup();
        }

        public static void Go()
        {
            CoffeeMachine coffeemachine = new CoffeeMachine();

            foreach (string s in Program.Interface.machine)
            {
                Console.WriteLine(s);
            }

            int count = 0;
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                Program.Interface.ChangeOrder();
                switch (count)
                {
                    case 0:
                        Console.Write("espresso - 30   ");
                        break;
                    case 1:
                        Console.Write("americano - 40  ");
                        break;
                    case 2:
                        Console.Write("capuccino - 42.5");
                        break;
                    case 3:
                        Console.Write("tea - 15        ");
                        break;
                }

                key = Console.ReadKey();
                if (key.Key.Equals(ConsoleKey.LeftArrow)) count--;
                if (key.Key.Equals(ConsoleKey.RightArrow)) count++;
                if (count > 3) count = 0;
                if (count < 0) count = 3;

            }
            while (!key.Key.Equals(ConsoleKey.Enter));


            Program.Interface.ChangeOrder();
            Liquid l;
            switch (count)
            {
                case 0:
                    l = new Espresso();
                    
                    break;
                case 1:
                    l = new Americano();
                    
                    break;
                case 2:
                    l = new Capuccino();
                    
                    break;
                case 3:
                    l = new Tea();
                    
                    break;
                default:
                    l = new Espresso();
                    break;
            }


            Program.Interface.ChangeOrderText();
            Console.Write("        Do you want sugar?        ");
            count = 0;
            do
            {
                Program.Interface.ChangeOrder();
                switch (count)
                {
                    case 0:
                        Console.Write("Yes - +5");
                        break;
                    case 1:
                        Console.Write("No      ");
                        break;
                }
                key = Console.ReadKey();
                if (key.Key.Equals(ConsoleKey.LeftArrow)) count--;
                if (key.Key.Equals(ConsoleKey.RightArrow)) count++;
                if (count < 0) count = 1;
                if (count > 1) count = 0;
            }
            while (!key.Key.Equals(ConsoleKey.Enter));

            switch (count)
            {
                case 0:
                    l.HasSugar = true;
                    l.price += 5;
                    break;
                case 1:
                    l.HasSugar = false;
                    break;
            }
            Console.SetCursorPosition(10, 10);
            Console.Write($"Your order costs {l.price}");
            Program.Interface.SetMoney();
            string s1="";
            while (!int.TryParse(s1, out int n))
            {
                s1 = Console.ReadLine();
                Program.Interface.SetMoney();
            }
            if (Program.Interface.CalculateChange(l, double.Parse(s1)))
            {
                Program.Interface.ChangeOrder();
                Program.Interface.ChangeOrderText();
                Console.Write("     Take your order, please     ");

                Program.Interface.ChangeFinalText();
                coffeemachine.CreateCup().Fill(l);
                Program.Interface.ReturnOrder();
                Console.SetCursorPosition(0, 19);
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(0, 19);
                Console.ReadKey();
            }

        }
    }
    

    abstract class Liquid
    {
        public bool HasSugar;
        public string info;
        public double price;
    }

    class Espresso: Liquid
    { 
        public Espresso()
        {
            info = "espresso";
            price = 30;
        }
    }

    class Americano : Liquid
    {
        public Americano()
        {
            info = "americano";
            price = 40;
        }
    }

    class Capuccino : Liquid
    {
        public Capuccino()
        {
            info = "capuccino";
            price = 42.5;
        }
    }

    class Tea : Liquid
    {
        public Tea()
        {
            info = "tea";
            price = 15;
        }
    }

    class Cup
    {
        public void Fill(Liquid l)
        {
            if (l.HasSugar)
                Console.Write($"Your {l.info} with sugar");
            else Console.WriteLine($"Your {l.info} without sugar");
        }
    }
}

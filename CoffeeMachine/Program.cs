using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CoffeeMachine
{
    class Program
    { 


       //Explanation: PIN code is in the "Code.txt" file



        static void Main(string[] args)
        {
            CoffeeMachine Coffeemachine = new CoffeeMachine("Machine.txt");
            foreach (string s in Coffeemachine.machineinterface.machine) Console.WriteLine(s);
            Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
            Coffee coffee = new Cappucino();
            Console.Write(coffee.Info);
            Console.SetCursorPosition(Coffeemachine.machineinterface.cost.Y, Coffeemachine.machineinterface.cost.X);
            Console.Write(coffee.Cost);
            Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
            int counter=0;
            int coffeecounter;
            bool addsugar;
            double finalcost = 0;
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        counter--;
                        break;
                    case ConsoleKey.RightArrow:
                        counter++;
                        break;
                    case ConsoleKey.Enter:
                        finalcost += coffee.Cost;
                        break;
                    default:
                        break;
                }
                if (counter > 2) counter = 0;
                if (counter < 0) counter = 2;
                if (finalcost > 0) break;
                switch (counter)
                {
                    case 0:
                        coffee = new Cappucino();
                        Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
                        Console.Write("         ");
                        Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
                        Console.Write($"{coffee.Info}  ");
                        Console.SetCursorPosition(Coffeemachine.machineinterface.cost.Y, Coffeemachine.machineinterface.cost.X);
                        Console.Write("        ");
                        Console.SetCursorPosition(Coffeemachine.machineinterface.cost.Y, Coffeemachine.machineinterface.cost.X);
                        Console.Write($"{coffee.Cost.ToString()}");                        
                        break;
                    case 1:
                        coffee = new Moccacino();
                        Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
                        Console.Write("         ");
                        Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
                        Console.Write($"{coffee.Info}  ");
                        Console.SetCursorPosition(Coffeemachine.machineinterface.cost.Y, Coffeemachine.machineinterface.cost.X);
                        Console.Write("        ");
                        Console.SetCursorPosition(Coffeemachine.machineinterface.cost.Y, Coffeemachine.machineinterface.cost.X);
                        Console.Write($"{coffee.Cost.ToString()}");                        
                        break;
                    case 2:
                        coffee = new Americano();
                        Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
                        Console.Write("         ");
                        Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
                        Console.Write($"{coffee.Info}  ");
                        Console.SetCursorPosition(Coffeemachine.machineinterface.cost.Y, Coffeemachine.machineinterface.cost.X);
                        Console.Write("        ");
                        Console.SetCursorPosition(Coffeemachine.machineinterface.cost.Y, Coffeemachine.machineinterface.cost.X);
                        Console.Write($"{coffee.Cost.ToString()}");                        
                        break;
                    default:
                        break;
                }
                
            }

            coffeecounter = counter;
            Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X-2);
            Console.Write("Do you want sugar?");
            Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);            
            Console.Write($"No       ");
            Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);

            counter = 0;

            while (true)
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        counter--;
                        break;
                    case ConsoleKey.RightArrow:
                        counter++;
                        break;
                    case ConsoleKey.Enter:
                        break;
                    default:
                        break;
                }
                if (counter > 1) counter = 0;
                if (counter < 0) counter = 1;
                if (key.Key == ConsoleKey.Enter) break;
                switch (counter)
                {
                    case 0:
                        Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
                        Console.Write($"No       ");
                        finalcost -= 5;
                        Console.SetCursorPosition(Coffeemachine.machineinterface.cost.Y, Coffeemachine.machineinterface.cost.X);
                        Console.Write(finalcost);                        
                        break;
                    case 1:
                        Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
                        Console.Write($"Yes      ");
                        finalcost += 5;
                        Console.SetCursorPosition(Coffeemachine.machineinterface.cost.Y, Coffeemachine.machineinterface.cost.X);
                        Console.Write(finalcost);                        
                        break;
                    default:
                        break;
                }
                
            }

            if (counter == 0) addsugar = false;
            else addsugar = true;

            Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
            Console.Write($"         ");
            Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X - 2);
            Console.Write("                  ");
            Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X - 2);
            Console.Write("How do you want to pay?");

            Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
            Console.Write($"With card");

            counter = 0;

            while (true)
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        counter--;
                        break;
                    case ConsoleKey.RightArrow:
                        counter++;
                        break;
                    case ConsoleKey.Enter:
                        break;
                    default:
                        break;
                }
                if (counter > 1) counter = 0;
                if (counter < 0) counter = 1;
                if (key.Key == ConsoleKey.Enter) break;
                switch (counter)
                {
                    case 0:
                        Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
                        Console.Write($"With card");
                        break;
                    case 1:
                        Console.SetCursorPosition(Coffeemachine.machineinterface.order.Y, Coffeemachine.machineinterface.order.X);
                        Console.Write($"With cash");
                        break;
                    default:
                        break;
                }
            }



            if (counter == 0)
            {
                if (Coffeemachine.TakeCard("Card.txt"))
                {
                    Coffeemachine.MakeOrder(coffeecounter, addsugar);
                }
            }
            else
            {
                Coffeemachine.TakeCash(finalcost);
                Coffeemachine.MakeOrder(coffeecounter, addsugar);
            }
            
        }
    }
}

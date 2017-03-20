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
        public class Interface
        {
            public static string[] machine = File.ReadAllLines("Machine.txt");

            public static void ChangeOrder()
            {
                Console.SetCursorPosition(4, 6);
                Console.Write("                   ");
                Console.SetCursorPosition(4, 6);
            }

            public static void SetMoney()
            {
                
                Console.SetCursorPosition(12, 12);
                Console.Write("           ");
                Console.SetCursorPosition(12, 12);
            }

            public static bool CalculateChange(Liquid l, double c)
            {
                Console.SetCursorPosition(10, 10);
                Console.Write("                         ");
                Console.SetCursorPosition(10, 10);

                if (c >= l.price)
                {
                    Console.Write("Take your exchange");
                    SetMoney();
                    Console.Write((c - l.price).ToString());
                    return true;
                }
                else { Console.Write("Insufficient funds"); }
                return false;
            }

            public static void ReturnOrder()
            {
                Console.SetCursorPosition(36, 12);
                Console.Write(" |________| ");
                Console.SetCursorPosition(36, 13);
                Console.Write(" |        | ");
                Console.SetCursorPosition(36, 14);
                Console.Write("  \\      /   ");
                Console.SetCursorPosition(36, 15);
                Console.Write("   \\____/   ");
                Console.SetCursorPosition(36, 16);
                Console.Write("___/____\\___");
            }

            public static void ChangeOrderText()
            {
                Console.SetCursorPosition(1, 4);
                Console.Write("                                  ");
                Console.SetCursorPosition(1, 3);
                Console.Write("                                  ");
                Console.SetCursorPosition(1, 4);
            }

            public static void ChangeFinalText()
            {
                Console.SetCursorPosition(1, 16);
                Console.Write("                              ");
                Console.SetCursorPosition(2, 16);
            }
        }



        static void Main(string[] args)
        {
            
            CoffeeMachine.Go();
        }
    }
}

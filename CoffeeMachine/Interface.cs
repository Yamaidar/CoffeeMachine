using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoffeeMachine
{
    class Interface
    {
        public string[] machine { get; private set; }

        public Cash cash;
        public Order order;
        public Cost cost;
        public OrderShow ordershow;
        public Change change;

        public abstract class Coordinates
        {
            public int X { get; protected set; }
            public int Y { get; protected set; }
        }

        public class Cash:Coordinates
        {
            public Cash(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class Order:Coordinates
        {
            public Order(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class Cost:Coordinates
        {
            public Cost(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class OrderShow : Coordinates
        {
            public OrderShow(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class Change : Coordinates
        {
            public Change(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public void CreateMachine(string folder)
        {
            machine = File.ReadAllLines(folder);
            for(int i=0; i<machine.GetLength(0); i++)
            {
                for (int j = 0; j < machine[i].Length; j++)
                {
                    switch (machine[i][j])
                    {
                        case '#':
                            order = new Order(i, j);
                            break;
                        case '$':
                            cost = new Cost(i, j);
                            break;
                        case '%':
                            cash = new Cash(i, j);
                            break;
                        case '?':
                            ordershow = new OrderShow(i, j);
                            break;
                        case '&':
                            change = new Change(i, j);                            
                            break;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deser
{
    public class Car
    {
        public string model;
        public int price;
        public int oil;
        public Car()
        {
        }
        public Car(string M, int P, int O)
        {
            model = M;
            price = P;
            oil = O;
        }
        public void Drive()
        {
            Console.WriteLine("Driving...");
            oil -= 10;
        }
        public int Bag()
        {
            return oil;
        }
    }
}

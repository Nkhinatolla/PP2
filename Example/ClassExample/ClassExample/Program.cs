using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Toyota", 2000000, 1000);
            car1.Drive();
            Console.WriteLine(car1.Bag());
            Console.WriteLine(car1.model + " " + car1.price);
            Car car2 = new Car("Hundai", 1000000, 500);
            car2.Drive();
            Console.WriteLine(car2.Bag());
            List<Car> cars = new List<Car> { car1, car2};
            Ser(cars);
        }
        static void Ser(List<Car> cars)
        {
            FileStream fs = new FileStream("Car.txt", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(List<Car>));
            xs.Serialize(fs, cars);
            fs.Close();
        }
    }
}

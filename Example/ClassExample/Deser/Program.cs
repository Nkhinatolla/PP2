using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Deser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> l = Deser();
            l[1].Drive();
            Console.WriteLine(l[1].model + l[1].price + l[1].oil);
        }
        static List<Car> Deser()
        {
            FileStream fs = new FileStream(@"C:\Users\Nurbergen\source\repos\Example\ClassExample\ClassExample\bin\Debug\Car.txt", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Car>));
            return xs.Deserialize(fs) as List<Car>;
        }
    }
}

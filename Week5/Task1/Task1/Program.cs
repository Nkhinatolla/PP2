using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace Task1
{
    [Serializable]
    public class ComplexNumber
    {
        public double a, b;
        public ComplexNumber()
        {

        }
        public ComplexNumber(double _re, double _im)
        {
            a = _re;
            b = _im;
        }
        public static ComplexNumber operator +(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.a + num2.a, num1.b + num2.b);
        }
        public static ComplexNumber operator -(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.a - num2.a, num1.b - num2.b);
        }
        public static ComplexNumber operator *(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber((num1.a * num2.a) - (num1.b * num2.b), (num1.b * num2.a) + (num2.b * num1.a));
        }
        public static ComplexNumber operator /(ComplexNumber num1, ComplexNumber num2)
        {
            double D = (num2.a * num2.a + (num2.b * num2.b));
            return new ComplexNumber((num1.a * num2.a + num1.b * num2.b) / D, -(num1.a * num2.b - num1.b * num2.a) / D);
        }
        public void info()
        {
            Console.Write(a.ToString());
            if (b == 0)
                return;
            if (b < 0)
                Console.Write('-');
            else
                Console.Write('+');
            Console.WriteLine(Math.Abs(b).ToString() + 'i');
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber A = new ComplexNumber(5, 4);
            ComplexNumber B = new ComplexNumber(8, 3);
            ComplexNumber C = (A * B);
            C.info();
            //Ser(C);
            ComplexNumber D = Deser();
            D.info();
        }
        static void Ser(ComplexNumber c) 
        {
            FileStream fs = new FileStream("ComplexNumber", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(ComplexNumber));
            xs.Serialize(fs, c);
            fs.Close();
        }
        static ComplexNumber Deser()
        {
            FileStream fs = new FileStream("ComplexNumber", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(ComplexNumber));
            return xs.Deserialize(fs) as ComplexNumber;

        }
    }
}

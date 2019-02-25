using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class ComplexNumber
    {
        double a, b;
        //double i;
       public ComplexNumber(double _re, double _im)
        {
            a = _re;
            b = _im;
        //    i = Math.Sqrt(-1);
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
            ComplexNumber A = new ComplexNumber(3, 4);
            ComplexNumber B = new ComplexNumber(8, -2);
            ComplexNumber C = (A / B);
            C.info();
        }
    }
}

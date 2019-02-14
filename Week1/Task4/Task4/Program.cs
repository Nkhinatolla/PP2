using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); // Считываем высоту треугольника
            string[,] d = new string[n, n]; // 2d стринговый массив 
            for (int i = 0; i < n; ++i) 
                for (int j = 0; j <= i; ++j)
                    d[i, j] = "[*]"; // Записываем в i, j 

            for (int i = 0; i < n; ++i, Console.WriteLine()) // как в С++
                for (int j = 0; j <= i; ++j)
                    Console.Write(d[i, j]); // выводим данные
        }
    }
}

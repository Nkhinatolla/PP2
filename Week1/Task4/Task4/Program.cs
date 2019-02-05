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
            int n = Convert.ToInt32(Console.ReadLine());
            string[,] d = new string[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j <= i; ++j)
                    d[i, j] = "[*]";
            for (int i = 0; i < n; ++i, Console.WriteLine())
                for (int j = 0; j <= i; ++j)
                    Console.Write(d[i, j]);
        }
    }
}

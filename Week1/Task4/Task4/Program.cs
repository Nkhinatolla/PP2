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
            for (int i = 1; i <= n; ++i, Console.WriteLine()) // Skills from C++, nothing else
                for (int j = 1; j <= i; ++j)
                    Console.Write("[*]");
        }
    }
}

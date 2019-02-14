using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        private static void dublicate(string[] s, int n) // Method dublicate with 2 parameters
        {
            string[] ss = new string[n * 2]; // String array
            for (int i = 0, j = 0; i < n; ++i) 
            {   
                ss[j++] = s[i]; // Doubling
                ss[j++] = s[i];
            }
            for (int i = 0; i < 2 * n; ++i)
                Console.Write(ss[i] + " ");
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); // reading first line and converting to int
            string[] reading = Console.ReadLine().Split(); // reading second line an array of string by split
            dublicate(reading, n); // Method thats dubplicate each of element
        }
    }
}

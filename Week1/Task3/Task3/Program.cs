﻿using System;
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
            for (int i = 0; i < n; ++i)   // Same as c++
                Console.Write(s[i] + " " + s[i] + " "); // Output
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); // reading first line and converting to int
            string[] reading = Console.ReadLine().Split(); // reading second line an array of string by split
            dublicate(reading, n); // Method thats dubplicate each of element
        }
    }
}

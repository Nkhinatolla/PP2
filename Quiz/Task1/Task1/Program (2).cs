using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Threads
{
    class Program
    {
        static List<ConsoleColor> l = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green };
        static Timer timer = new Timer(1000);
        static Timer timer2 = new Timer();
        static void Main(string[] args)
        {
            timer.Elapsed += Timer_Elapsed1;
            timer.Start();
            timer2.Elapsed += Timer2_Elapsed;
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            while (true) {
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        timer2.Start();
                        break;
                    default:
                        break;
                }
            }
        }
        private static void Timer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.SetCursorPosition(0, 1);
            timer.Enabled = false;
            Console.Write("Input word with length>8:");
            string s = Console.ReadLine();
            Console.WriteLine(s);
            timer.Enabled = true;
            Environment.Exit(0);
        }

        private static void Timer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(DateTime.Now);
        }


    }
}

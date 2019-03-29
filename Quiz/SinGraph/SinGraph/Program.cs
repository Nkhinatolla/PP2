using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SinGraph
{
    class Program
    {
        static int x = 0, degree = 0;
        static void Main(string[] args)
        {
            Timer timer = new Timer(100);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            while(true)
            {

            }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            degree = (degree + 10) % 360;
            double Y = Math.Sin((Math.PI / 180) * degree);
            Console.SetCursorPosition(x++, Convert.ToInt32(Y * 10 + 10));
            Console.Write("0");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1
{
    class Program
    {

        static void Main(string[] args)
        {
            Thread[] threadArray = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                threadArray[i] = new Thread(DoIt);
                threadArray[i].Name = "Marvel" + i;
            }
            for (int i = 0; i < 3; i++)
            {
                threadArray[i].Start();
            }

        }
        static void DoIt()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task2
{
    public class MyThread
    {
        public Thread threadField;
        public MyThread(string name)
        {
            threadField = new Thread(doIt);
            threadField.Name = name;

        }
        public void startThread()
        {
            this.threadField.Start();

        }
        void doIt()
        {
            for (int i = 1; i <= 4; i++)
            {

                Console.WriteLine(this.threadField.Name + " output " + i.ToString());
                Thread.Sleep(0);
            }
            Console.WriteLine(this.threadField.Name + " completed ");
        }
    }
}
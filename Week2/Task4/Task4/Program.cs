using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Nurbergen\source\repos\Week2\Task4\Task4\Example.txt";
            string path1 = @"C:\Users\Nurbergen\source\repos\Week2\Task4";
            DirectoryInfo dirInfo = new DirectoryInfo(path1);
            FileInfo fi = new FileInfo(path);
            if (fi.Exists && dirInfo.Exists)
            {
                fi.CopyTo(path1 + @"\Copied.txt", true);
                fi.Delete();
            }
            else Console.WriteLine("path or path1 not found:(");

        }
    }
}

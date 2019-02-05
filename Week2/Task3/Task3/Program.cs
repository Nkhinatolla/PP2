using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task3
{
    class Program
    {
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        static void Go(DirectoryInfo root, string level)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null; 
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                log.Add(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            if (files != null)
            {
                subDirs = root.GetDirectories();
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    Console.WriteLine(level + dirInfo.Name);
                    Go(dirInfo, level + "   ");
                }
                foreach (FileInfo fi in files)
                    Console.WriteLine(level + fi.Name);
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\Nurbergen\source\repos\Week1\Task1");
            Go(dirInfo, "");
            if (log.Count > 0)
            {
                Console.WriteLine("Files with restricted access:");
                foreach (string s in log)
                    Console.WriteLine(s);
            }
        }
    }
}

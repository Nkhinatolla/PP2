using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Student student2 = new Student("Nurbergen", 13, 2018);
            student.access();
            student2.access();
        }
    }
}

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
            Student student = new Student(); // Инициализируем данные с помощью конструктора: 0
            Student student2 = new Student("Nurbergen", "18BD12345", 2018); // 3 параметрами
            student.access(); // Метод возвращает данные
            student2.access(); 
        }
    }
}

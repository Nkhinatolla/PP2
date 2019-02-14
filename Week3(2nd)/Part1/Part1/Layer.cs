using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Part1
{
    class Layer
    {
        public FileSystemInfo[] Content { get; set; } // Папки и файлы
        public int SelectedIndex { get; set; } // Выделенный контент
        public int FileIndex { get; set; } // индекс начало файлов
        public int Left { get; set; } // Левый отрезок
        public int Right { get; set; } // Правый отрезок
        public void Draw() {  // Метод Draw: будет рисовать
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            for (int i = Left; i < Math.Min(Content.Length, Right + 1); ++i) { //  будем показывать только 21 контент
                Console.BackgroundColor = (i == SelectedIndex) ? ConsoleColor.Red : ConsoleColor.Black; // при выделении будем красить задний фон на Red
                if (i >= FileIndex) Console.ForegroundColor = ConsoleColor.Yellow; // файлы желтого цвета
                Console.WriteLine((i + 1) + ". " + Content[i].Name);
            }
        }

    }
}

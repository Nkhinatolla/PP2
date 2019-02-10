using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Example1
{
    enum FSIMode
    {
        DirectoryInfo = 1, // Справочник
        File = 2
    }
    class Layer
    {
        public DirectoryInfo[] DirectoryContent
        {
            get;
            set;
        }
        public FileInfo[] FileContent
        {
            get;
            set;
        }
        public int SelectedIndex
        {
            get;
            set;
        }
        void SelectedColor(int i)
        {
            if (i == SelectedIndex)
                Console.BackgroundColor = ConsoleColor.Red;
            else
                Console.BackgroundColor = ConsoleColor.Black;
        }
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < DirectoryContent.Length; ++i)
            {
                SelectedColor(i);
                Console.WriteLine((i + 1) + ". " + DirectoryContent[i].Name);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < FileContent.Length; ++i)
            {
                SelectedColor(i + DirectoryContent.Length);
                Console.WriteLine((i + DirectoryContent.Length + 1) + ". " + FileContent[i].Name);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Nurbergen\source\repos");
            Layer l = new Layer
            {
                DirectoryContent = dir.GetDirectories(),
                FileContent = dir.GetFiles(),
                SelectedIndex = 0
            };
            l.Draw();
            Stack<Layer> history = new Stack<Layer>();
            history.Push(l);
            bool esc = false;
            FSIMode curMode = FSIMode.DirectoryInfo;
            while (!esc)
            {
                if (curMode == FSIMode.DirectoryInfo)
                    history.Peek().Draw();
                ConsoleKeyInfo consolekeyInfo = Console.ReadKey(); // spravo4nik
                switch (consolekeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (history.Peek().SelectedIndex > 0)
                            history.Peek().SelectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (history.Peek().DirectoryContent.Length + history.Peek().FileContent.Length - 1 > history.Peek().SelectedIndex)
                            history.Peek().SelectedIndex++;
                        break;
                    case ConsoleKey.Enter:
                        if (history.Peek().DirectoryContent.Length + history.Peek().FileContent.Length == 0)
                            break;
                        int index = history.Peek().SelectedIndex;
                        if (index < history.Peek().DirectoryContent.Length)
                        {
                            DirectoryInfo d = history.Peek().DirectoryContent[index];
                            history.Push(new Layer
                            {
                                DirectoryContent = d.GetDirectories(),
                                FileContent = d.GetFiles(),
                                SelectedIndex = 0
                            });
                        }
                        else
                        {
                            curMode = FSIMode.File;
                            using (FileStream fs = new FileStream(history.Peek().FileContent[index - history.Peek().DirectoryContent.Length].FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());

                                }
                            }

                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (curMode == FSIMode.DirectoryInfo)
                        {
                            if (history.Count > 1)
                                history.Pop();
                        }
                        else
                        {
                            curMode = FSIMode.DirectoryInfo;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Escape:
                        esc = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

/*static void Main(string[] args)
            {
                FSIMode f = FSIMode.DirectoryInfo;
                f = FSIMode.File;
                switch (f)
                {
                    case FSIMode.DirectoryInfo:
                        Console.WriteLine("Dir");
                        break;
                    case FSIMode.File:
                        Console.WriteLine("File");
                        break;
                    default:
                        Console.WriteLine("Not Defined");
                        break;
                }
                //if (f == FSIMode.File)
                //    Console.WriteLine("File!");
                //else
                //    Console.WriteLine("dir");
                //Console.ForegroundColor = ConsoleColor.
            }
            */

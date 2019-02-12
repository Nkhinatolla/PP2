﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace Part1 { 
    enum FSIMode { // Есть две состояния: папки и файлы. Нумеруем для удобства 
        DirectoryInfo = 1,
        FileInfo = 2
    }
    class Program {
        static bool pathExists(string path, FSIMode mode) // Проверка пути
        {
            if ((mode == FSIMode.DirectoryInfo && new DirectoryInfo(path).Exists) || (mode == FSIMode.FileInfo && new FileInfo(path).Exists))
                return true;
            else
                return false;
        }
        static FileSystemInfo[] Combine(DirectoryInfo[] di, FileInfo[] fi) { // Объединяет папки и файлы
            FileSystemInfo[] fsi = new FileSystemInfo[di.Length + fi.Length];
            for (int i = 0; i < di.Length; ++i) // Берем все папки и добавляем их в fsi. И только потом добавляем файлы
                fsi[i] = di[i];
            for (int i = 0; i < fi.Length; ++i)
                fsi[i + di.Length] = fi[i];  
            return fsi; // Возвращаем заMerganiy fsi
        }
        static void Main(string[] args) { 
            DirectoryInfo startPath = new DirectoryInfo(@"C:\Test"); // Объявляем начальные значения
            if (!startPath.Exists) { // Проверяем путь
                Console.WriteLine("Directory not exist");
                return;
            }
            Layer startLayer = new Layer { // Создаем класс Layer -> (контенты, выделенный контент и отрезок для вывода)
                Content = Combine(startPath.GetDirectories(), startPath.GetFiles()),
                SelectedIndex = 0,
                Left = 0,
                Right = 20, // Максимально 25 строк можно показывать
                FileIndex = startPath.GetDirectories().Length // индекс начало файла
            };
            Stack<Layer> history = new Stack<Layer>(); // Стек для хранение Layer-ов 
            history.Push(startLayer);
            bool esc = false;
            FSIMode LayerMode = FSIMode.DirectoryInfo; // LayerMode - текущий состояние Layer-а
            FSIMode SelectedMode = FSIMode.DirectoryInfo; // SelectedMode - остояние выделенного контента для удобства
            while (!esc) { 
                Layer l = history.Peek(); // для удобства возьмем текущий Слой(Layer)
                if (LayerMode == FSIMode.DirectoryInfo) { // Чтобы перерисовать Слой, текущие состояние должно быть папкой
                    if (l.Content.Length > 0)
                        SelectedMode = (l.Content[l.SelectedIndex].GetType() == typeof(DirectoryInfo)) ? FSIMode.DirectoryInfo : FSIMode.FileInfo; // Обновляем состояние SelectedMode-а
                    l.Draw(); // В классе Layer есть метод l.Draw();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Open: Enter | Delete: Del | Rename: F4 | Back: Backspace | Exit: Esc"); // Справка
                    Console.ForegroundColor = ConsoleColor.White;
                }
                ConsoleKeyInfo consolekeyInfo = Console.ReadKey();
                switch (consolekeyInfo.Key) { // Используем switch для клавы
                    case ConsoleKey.UpArrow: // Стрелка вверх
                        if (l.SelectedIndex > 0) { // Чтобы не выйти за рамки
                            l.SelectedIndex--;
                            if (l.SelectedIndex < l.Left) { // Ставим границы отрезка
                                l.Left--; l.Right--;
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow: // Стрелка вниз
                        if (l.SelectedIndex < l.Content.Length - 1) { 
                            l.SelectedIndex++;
                            if (l.SelectedIndex > l.Right) { // Ставим границы отрезка
                                l.Left++; l.Right++;
                            }
                        }
                        break;
                    case ConsoleKey.Enter: // При нажатии Ентера, есть два вида действия.
                        if (l.Content.Length == 0) // Если текущяя папка пусто, нету смысла нажимать на ЭНТЕР!
                            break;
                        if (LayerMode == FSIMode.FileInfo)
                            break;
                        if (SelectedMode == FSIMode.DirectoryInfo) { // Первое действие - когда выделенный контент это папка, добавим новый Слой в стек 
                            DirectoryInfo dir = l.Content[l.SelectedIndex] as DirectoryInfo;
                            history.Push(new Layer {
                                Content = Combine(dir.GetDirectories(), dir.GetFiles()),
                                SelectedIndex = 0,
                                Left = 0,
                                Right = 20,
                                FileIndex = dir.GetDirectories().Length // индекс начало файла
                            });

                        }
                        else { 
                            LayerMode = FSIMode.FileInfo; // Меняем состояние на файл
                            using (FileStream fs = new FileStream(l.Content[l.SelectedIndex].FullName, FileMode.Open, FileAccess.Read)) { // будем читать содержимое файла
                                using (StreamReader sr = new StreamReader(fs)) { 
                                    Console.BackgroundColor = ConsoleColor.White; // Белый фон, черный шрифт
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Escape: // Выход из программы
                        esc = true;
                        break;
                    case ConsoleKey.Backspace:
                        if (LayerMode == FSIMode.DirectoryInfo) { // Перед выходом нужно определить из чего выходим
                            if (history.Count() > 1) // Граница чтобы не вылетить
                                history.Pop(); // Удаление Слоя из стека
                        }
                        else
                            LayerMode = FSIMode.DirectoryInfo; // Меняем обратно на папку
                        break;
                    case ConsoleKey.Delete:
                        if (LayerMode == FSIMode.FileInfo || l.Content.Length == 0) // Ничего не делаем если находимся в файле или папка пуста
                            break;
                        if (SelectedMode == FSIMode.FileInfo) // Перед удалением определим тип контента
                            (l.Content[l.SelectedIndex] as FileInfo).Delete();
                        else  
                            (l.Content[l.SelectedIndex] as DirectoryInfo).Delete(true); // Если папка не пуста, true - поможет удалить
                            history.Pop(); // удаляем текущий Слой и перезаписоваем.
                        if (history.Count == 0) { // Если это первый Слой, берем Слой startPath, и из него записоваем
                            history.Push( new Layer {
                                    Content = Combine(startPath.GetDirectories(), startPath.GetFiles()),
                                    SelectedIndex = Math.Min(l.SelectedIndex, l.Content.Length - 2),
                                    Left = l.Left,
                                    Right = l.Right,
                                    FileIndex = startPath.GetDirectories().Length
                            });
                        }
                        else {
                            DirectoryInfo dir = history.Peek().Content[l.SelectedIndex] as DirectoryInfo; // Или преведущий Слой
                            history.Push(new Layer {
                                Content = Combine(dir.GetDirectories(), dir.GetFiles()),
                                SelectedIndex = Math.Min(l.SelectedIndex, l.Content.Length - 2),
                                Left = l.Left,
                                Right = l.Right,
                                FileIndex = dir.GetDirectories().Length
                            });
                        }
                        break;
                    case ConsoleKey.F4: // Rename
                        if (LayerMode == FSIMode.FileInfo || l.Content.Length == 0) // Ничего не делаем если находимся в файле или папка пуста
                            break;
                        string fullname = l.Content[l.SelectedIndex].FullName; // полный путь
                        string name = l.Content[l.SelectedIndex].Name; // имя файла
                        string path = fullname.Remove(fullname.Length - name.Length); // путь без имя
                        Console.WriteLine("Please enter the new name, to rename {0}:", name); // новое имя
                        string newname = Console.ReadLine(); 
                        while (newname.Length == 0 || pathExists(path + newname, SelectedMode)) { // проверка наличия пути
                            Console.WriteLine("This directory was created, Enter the new one");
                            newname = Console.ReadLine();
                        }
                        if (SelectedMode == FSIMode.DirectoryInfo) // Через Move заменяем
                            new DirectoryInfo(fullname).MoveTo(path + newname);
                        else
                            new FileInfo(fullname).MoveTo(path + newname);
                        DirectoryInfo di = new DirectoryInfo(path + newname);
                        l.Content[l.SelectedIndex] = di as FileSystemInfo; // Замена директорий
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

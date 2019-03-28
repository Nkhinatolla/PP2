using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Snake
{
    public class GameState
    {
        public static Worm w = new Worm('O');
        public static Wall b = new Wall('#');
        public static Food f = new Food('@', new object[]{w, b});
        public int point = 0;
        public int level = 1;
        private int speed = 150;
        private int[] levels = { 10, 50, 150, 500, 1000, 10000};
        public string username;
        Timer timer = new Timer();
        //Timer timer2 = new Timer();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameState));

        public GameState()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetWindowSize(70, 41);
            Console.SetBufferSize(70, 41);
            Console.SetCursorPosition(25, 20);
            Console.Write("Input username:");
            username = Console.ReadLine();
            Console.Clear();
            Console.CursorVisible = false;
        }

        public void Save()
        {
            using (FileStream fileStream = new FileStream("game.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, this);
            }
        }

        public void Reset()
        {
            Console.Clear();
            timer.Elapsed -= Timer_Elapsed;
        }

        public GameState Load()
        {
            GameState res = null;
            using (FileStream fileStream = new FileStream("game.xml", FileMode.Open, FileAccess.Read))
            {
                res = xmlSerializer.Deserialize(fileStream) as GameState;
            }

            return res;
        }
        public void Run()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Console.ForegroundColor = ConsoleColor.Red;
            f.Draw();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Gray;
            b.Draw();
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private void comment()
        {
            Console.SetCursorPosition(50, 0);
            Console.Write("Username: " + username);
            Console.SetCursorPosition(50, 1);
            Console.Write("Point: " + point);
            Console.SetCursorPosition(50, 2);
            Console.Write("Level: " + level);
            Console.SetCursorPosition(50, 3);
            Console.Write("Speed: " + speed);
        }
            
        private void ChangeTime(object sender, ElapsedEventArgs e)
        {
            Console.SetCursorPosition(42, 2);
            Console.WriteLine(DateTime.Now.Second);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            w.Clear();
            w.Move();
            w.Draw();
            CheckWall();
            CheckBody();
            CheckFood();
            timer.Interval = speed;
            comment();
        }
        void CheckBody()
        {
                for (int i = 1; i < w.body.Count(); ++i)
                {
                    if (w.body[0].X == w.body[i].X && w.body[0].Y == w.body[i].Y)
                    {
                        GameOver();
                    }
                }
        }



        void CheckFood()
        {
            if (w.CheckCollision(f.body[0]))
            {
                point += level * 10;
                w.Eat(f.body[0]);
                if (point >= levels[level])
                {
                    speed -= 20;
                    level++;
                    b.LoadLevel(level);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    b.Draw();
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                f.Generate(new object[] { w, b });
                Console.ForegroundColor = ConsoleColor.Red;
                f.Draw();
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
        void CheckWall()
        {
            foreach (Point i in b.body)
            {
                if (w.CheckCollision(i))
                {
                    GameOver();
                }
            }
        }
        void GameOver()
        {
            b.Clear();
            f.Clear();
            Console.Clear();
            Console.SetCursorPosition(30, 20);
            Console.Write("GAME OVER");
            timer.Close();
        }
        public void PressedKey(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (w.Dy != 1)
                    {
                        w.Dx = 0;
                        w.Dy = -1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (w.Dy != -1)
                    {
                        w.Dx = 0;
                        w.Dy = 1;
                    } 
                    break;
                case ConsoleKey.LeftArrow:
                    if (w.Dx != 1)
                    {
                        w.Dx = -1;
                        w.Dy = 0;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (w.Dx != -1)
                    {
                        w.Dx = 1;
                        w.Dy = 0;
                    }
                    break;
                case ConsoleKey.Spacebar:
                    timer.Enabled = !timer.Enabled;
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
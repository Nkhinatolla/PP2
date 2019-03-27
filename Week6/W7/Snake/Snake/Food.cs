using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food : GameObject
    {
        public Food() : base()
        {
            
        }
        public Food(char sign, object[] map) : base(sign)
        {
            Generate(map);
        }
        public void Generate(object[] o)
        {
            Random random = new Random(DateTime.Now.Second);
            body.Clear();
            int x = random.Next(1, 39);
            int y = random.Next(1, 39);
            bool check = false;
            Worm w = o[0] as Worm;
            Wall b = o[1] as Wall;
            while (!check)
            {
                check = true;
                foreach (Point i in w.body)
                {
                    if (i.X == x && i.Y == y)
                    {
                        check = false;
                        break;
                    }
                }
                foreach (Point i in b.body)
                {
                    if (i.X == x && i.Y == y)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                    break;
                x = random.Next(1, 39);
                y = random.Next(1, 39);
            }
            body.Add(new Point
            {
                X = x,
                Y = y
            });
        }
    }
}
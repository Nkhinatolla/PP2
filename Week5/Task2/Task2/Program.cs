using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace Task2
{
    [Serializable]
    public class Mark
    {
        public int point { get; set; }
        public string letter;
        public string toMark()
        {
            if (point > 94)
                return letter = "A";
            if (point > 89)
                return letter = "A-";
            if (point > 84)
                return letter = "B+";
            if (point > 79)
                return letter = "B";
            if (point > 74)
                return letter = "B-";
            if (point > 69)
                return letter = "C+";
            if (point > 64)
                return letter = "C";
            if (point > 59)
                return letter = "C-";
            if (point > 54)
                return letter = "D";
            return letter = "F";
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Mark> list = new List<Mark>();

            string[] t = File.ReadAllText(@"input.txt").Split();
            for (int i = 0; i < t.Length; ++i)
            {
                Mark ex = new Mark { point = Convert.ToInt32(t[i])};
                list.Insert(i, ex);
            }
            foreach (Mark value in list)
                 Console.Write(value.toMark() + " ");
            Console.WriteLine();
            Deser();
            Ser(list);
        }
        static void Ser(List<Mark> c)
        {
            FileStream fs = new FileStream("Mark.txt", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            xs.Serialize(fs, c);
            fs.Close();
        }
        static void Deser()
        {
            FileStream fs = new FileStream("Mark.txt", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            List<Mark> t = xs.Deserialize(fs) as List<Mark>;
            foreach (Mark i in t)
                Console.Write(i.toMark() + " ");
            fs.Close();
        }

    }
}

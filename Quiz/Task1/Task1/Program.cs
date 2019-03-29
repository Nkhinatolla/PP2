using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task1
{
    public class Employee
    {
        private string name;
        private string id;
        private int salary;
        public string N
        {
            get {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string I
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int S {
            get
            {
                return salary += 50000;
            }
            set
            {
                salary = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee x = new Employee { N = "Alex", I = "18BD", S = 10000};
            Ser(x);
            Deser(x);
        }
        static void Ser(Employee c)
        {
            FileStream fs = new FileStream("Employee.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Employee));
            xs.Serialize(fs, c);
            fs.Close();
        }
        static Employee Deser(Employee c)
        {
            FileStream fs = new FileStream("Employee.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Employee));
            Employee x = xs.Deserialize(fs) as Employee;
            fs.Close();
            return x;
        }
    }
}

using System;

public class Student
{
    public string name;
    public int id;
    public int year;
    public Student(string name, int id, int year)
    {
        this.name = name;
        this.id = id;
        this.year = year;
    }
    public Student()
    {
        string[] reading = Console.ReadLine().Split();
        while (reading.Length != 3) {
            Console.WriteLine("Wrong Input, please input correctly: name id year");
            reading = Console.ReadLine().Split();
        }
        this.name = reading[0];
        this.id = Convert.ToInt32(reading[1]);
        this.year = Convert.ToInt32(reading[2]);
    }
    public void access()
    {
        Console.WriteLine(name + " " + id + " " + year);
    }

}

using System;

public class Student
{
    private string name; // приватная перемена name
    private string id;
    private int year;
    public Student(string name, string id, int year) // Конструктор с 3 параметрами
    {
        this.name = name; // чтобы между 2-мя переменами не было конфликта 
        this.id = id;
        this.year = year;
    }
    public Student() // Конструктор с 0 параметрами
    {
        string[] reading = Console.ReadLine().Split(); // Читаем и делим по пробелам
        while (reading.Length != 3) { // Будем считывать пока не будет 3 ввода
            Console.WriteLine("Wrong Input, please input correctly: name id year"); 
            reading = Console.ReadLine().Split(); // Обновляем вводные данные
        }
        // reading = {Carl, 18BD, 2018}
        this.name = reading[0]; // Carl
        this.id = reading[1]; // 18BD
        this.year = Convert.ToInt32(reading[2]); // 2018
    }
    public void access() // Метод который возвращает данные Студента
    {
        Console.WriteLine(name + " " + id + " " + (year + 1)); 
    }

}

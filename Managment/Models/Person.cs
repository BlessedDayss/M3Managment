namespace Managment.Models;

public abstract class Person(string name, string surname, int age)
{
    internal string Name = name;
    internal string Surname = surname;
    internal int Age = age;

    public abstract string GetInfo();
}
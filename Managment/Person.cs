namespace Managment;

public abstract class Person
{
    public string name;
    public string surname;
    public int age;

    public Person(string name, string surname, int age)
    {
        this.name = name;
        this.surname = surname;
        this.age = age;
    }

    public abstract string GetInfo();
}
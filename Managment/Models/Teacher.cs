namespace Managment.Models;

public class Teacher : Person
{
    public string Subject { get; }
    public Teacher(string name, string surname, int age, string subject) : base(name, surname, age)
    {
        Subject = subject;
    }
    
    public override string GetInfo()
    {
        return $"{Name}, {Surname}, Age: {Age}, Subject: {Subject}";
    }
    public string GetInfoStudent()
    {
        return $"{Name} {Surname}, Subject: {Subject}";
    }
}
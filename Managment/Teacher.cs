namespace Managment;

public class Teacher : Person
{


    public string Subject;

    public Teacher(string name, string surname, int age, string subject) : base(name, surname, age)

    {
        Subject = subject;
    }
    
    public override string GetInfo()
    {
        return $"{name}, {surname}, Age: {age}, Subject: {Subject}";
    }

    public virtual string GetInfoStudent()
    {
        return $"{name} {surname}, Subject: {Subject}";
    }
}
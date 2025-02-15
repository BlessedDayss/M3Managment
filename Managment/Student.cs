namespace Managment;

public class Student : Person
{
    public int Grade;
    public Teacher Teacher;
    
    public Student(string name, string surname, int age, int grade, Teacher teacher) : base(name, surname, age)

    {
        Grade = grade;
        Teacher = teacher;
    }
    
    public override string GetInfo()
    {
        return $"{name}, {surname}, Age: {age}, Grade: {Grade}, Teacher: {Teacher.GetInfoStudent()}";
    }
}
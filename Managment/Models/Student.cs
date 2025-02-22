namespace Managment.Models;

public class Student : Person
{
    public  int _grade;
    public int _gpa;
    public  Teacher _teacher;

    public Student(string name, string surname, int age, int grade, int gpa, Teacher teacher) : base(name, surname, age)
    {
        _grade = grade;
        _gpa = gpa;
        _teacher = teacher;
        // Teacher = teacher;
    }
    
    public override string GetInfo()
    {
        return $"{Name} {Surname}, Age: {Age}, Grade: {_grade}, GPA: {_gpa}, Teacher: {_teacher.GetInfoStudent()}";
    }
}
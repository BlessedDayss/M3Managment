namespace Managment.Models;

public class UndergraduateStudent : Student
{
    private string _undergraduate;
    
    public UndergraduateStudent(string name, string surname, int age, int grade, int gpa, Teacher teacher, string undergraduate) : base(name,
        surname, age, grade, gpa, teacher)
    {
        _undergraduate = undergraduate;
    }
}
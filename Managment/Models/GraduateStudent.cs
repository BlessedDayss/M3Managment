using System.Globalization;

namespace Managment.Models;


public class GraduateStudent : Student
{
        private string _graduate;

        public GraduateStudent(string name, string surname, int age, int grade, int gpa, Teacher teacher,
            string graduate) : base(name,
            surname, age, grade, gpa, teacher)
        {
            _graduate = graduate;
        }
}
using Spectre.Console;
using Managment.Models;
using Spectre.Console;

namespace Managment;

public class SchoolManager<T> : IManageable<T> where T : Person 
{

    public List<Teacher> teachers = new List<Teacher>();
    
    public List<Student> students = new List<Student>();
    
    public SchoolManager()
    {
        teachers.Add(new Teacher("Emily", "Johnson", 34, "Mathematics"));
        teachers.Add(new Teacher("Michael", "Brown", 41, "Physics"));
        teachers.Add(new Teacher("Sophia", "Davis", 39, "Literature"));
        teachers.Add(new Teacher("James", "Wilson", 47, "History"));
        teachers.Add(new Teacher("Olivia", "Martinez", 36, "Biology"));
        teachers.Add(new Teacher("William", "Anderson", 43, "Chemistry"));
        teachers.Add(new Teacher("Ava", "Taylor", 32, "Art"));
        teachers.Add(new Teacher("Benjamin", "Thomas", 50, "Geography"));
        teachers.Add(new Teacher("Mia", "Clark", 37, "Music"));
        teachers.Add(new Teacher("Daniel", "Lewis", 44, "Physical Education"));
        
        students.Add(new Student("Liam", "Smith", 15, 9, 3, teachers[0]));
        students.Add(new Student("Emma", "Johnson", 16, 10, 4, teachers[1]));
        students.Add(new Student("Noah", "Williams", 15, 9, 3, teachers[2]));
        students.Add(new Student("Olivia", "Jones", 16, 10, 4, teachers[3]));
        students.Add(new Student("William", "Brown", 15, 9, 3, teachers[4]));
        students.Add(new Student("Ava", "Davis", 16, 10, 4, teachers[5]));
        students.Add(new Student("James", "Miller", 15, 9, 3, teachers[6]));
        students.Add(new Student("Isabella", "Wilson", 16, 10, 4, teachers[7]));
        students.Add(new Student("Benjamin", "Moore", 15, 9, 3, teachers[8]));
        students.Add(new Student("Sophia", "Taylor", 16, 10, 4, teachers[9]));
    }
    
    

    public void ShowTeachersTable()
    
    {
        var table = new Table();
        table.Border = TableBorder.SimpleHeavy;
        
        table.AddColumn(new TableColumn("Name"));
        table.AddColumn(new TableColumn("Surname"));
        table.AddColumn(new TableColumn("Age"));
        table.AddColumn(new TableColumn("Subject"));

        foreach (var teacher in teachers)
        {
            table.AddRow(teacher.Name, teacher.Surname, teacher.Age.ToString(), teacher.Subject);
        }
        AnsiConsole.Write(table);
    }

    public void ShowStudentsTable(string studentName)
    {
        var table1 = new Table();
        table1.Border = TableBorder.SimpleHeavy;

        table1.AddColumn(new TableColumn("Name"));
        table1.AddColumn(new TableColumn("Surname"));
        table1.AddColumn(new TableColumn("Age"));
        table1.AddColumn(new TableColumn("Grade"));
        table1.AddColumn(new TableColumn("GPA"));
        table1.AddColumn(new TableColumn("Teacher"));

        foreach (var student in students)
        {
            table1.AddRow(student.Name, student.Surname, student.Age.ToString(), student._grade.ToString(),
                student._gpa.ToString(), student._teacher.GetInfoStudent());
        }

        AnsiConsole.Write(table1);
    }
    
    

    public void SearchNameStudent(string name)
    {
        var student = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (student != null)
        {
            var table = new Table()
                .AddColumn("Name")
                .AddColumn("Surname")
                .AddColumn("Age")
                .AddColumn("Grade")
                .AddColumn("GPA");

            table.AddRow(student.Name, student.Surname, student.Age.ToString(), student._grade.ToString(), student._gpa.ToString());
            AnsiConsole.Write(table);
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Student not found.[/]");
        }
    }
    public void SearchLastNameStudent(string surname)
    {
        var student = students.FirstOrDefault(l => l.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));

        if (student != null)
        {
            var table = new Table()
                .AddColumn("Surname")
                .AddColumn("Name")
                .AddColumn("Age")
                .AddColumn("Grade")
                .AddColumn("GPA");

            table.AddRow(student.Surname, student.Name, student.Age.ToString(), student._grade.ToString(),
                student._gpa.ToString());
            AnsiConsole.Write(table);
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Student with this last name not found in the system.[/]");
        }
    }


    public void Add(T item)
    {
        if (item is Student student)
        {
            students.Add(student);
        }else if (item is Teacher teacher)
        {
            teachers.Add(teacher);
        }
        else
        {
            throw new ArgumentException($"Invalid type: {item.GetType()}");
        }
        Console.WriteLine($"Added {item.GetType()}");
    }

    public void Remove(T item)
    {
        throw new NotImplementedException();
    }

    public T? Find(string name)
    {
        throw new NotImplementedException();
    }
}
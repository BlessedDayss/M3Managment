using Managment.Models;
using Spectre.Console;

namespace Managment;

internal abstract class Program
{
    private static void Main()
    {

        var manager = new SchoolManager<Person>();

        while (true)
        {
            Console.Clear();
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[blue]Welcome to M3 School Management App:[/]")
                .AddChoices("📚 Show Teachers", "🎓 Show Students", "🔎 Find Student", "➕  Add", "➖  Delete",
                    "❌  Exit"));
            {
                Console.Clear();
                switch (choice)
                {
                    case "📚 Show Teachers":
                    {
                        manager.ShowTeachersTable();
                        while (true)
                        {
                            var choice2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                .AddChoices("Return", "Exit"));
                            if (choice2 == "Return")
                            {
                                break;
                            }

                            if (choice2 == "Exit")
                            {
                                Environment.Exit(0);
                            }
                        }

                        break;
                    }
                    case "🎓 Show Students":
                    {
                        manager.ShowStudentsTable(studentName: "");
                        while (true)
                        {
                            var choice2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                // .Title("Do you want to go back to the main menu?")
                                .AddChoices("Return", "Search", "Exit"));
                            if (choice2 == "Return")
                            {
                                break;
                            }

                            switch (choice2)
                            {
                                case "Search":
                                {
                                    var searchQuery = AnsiConsole.Ask<string>("Enter student name:");
                                    manager.SearchNameStudent(name: searchQuery);
                                    break;
                                }
                                case "Exit":
                                    Environment.Exit(0);
                                    break;
                            }
                        }

                        break;
                    }
                    case "🔎 Find Student":
                    {
                        while (true)
                        {
                            var searchLastQuery = AnsiConsole.Ask<string>("Find student by last name: ");
                            manager.SearchLastNameStudent(surname: searchLastQuery);

                            var lastNameSearch = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                .AddChoices("Search again", "Return", "Exit"));

                            if (lastNameSearch == "Return")
                            {
                                break;
                            }

                            if (lastNameSearch == "Exit")
                            {
                                Environment.Exit(0);
                            }
                        }

                        break;
                    }
                    case "➕  Add":
                    {
                        while (true)
                        {
                            var addUser = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                .AddChoices("Add Teacher", "Add Student", "Return", "Exit"));
                            if (addUser == "Add Teacher")
                            {
                                var teacherName = AnsiConsole.Ask<string>("Enter teacher name:");
                                var teacherSurname = AnsiConsole.Ask<string>("Enter teacher surname:");
                                var teacherAge = AnsiConsole.Ask<int>("Enter teacher age:");

                                var subjects = new List<string>
                                {
                                    "Mathematics",
                                    "Physics",
                                    "Literature",
                                    "History",
                                    "Biology",
                                    "Chemistry",
                                    "Art",
                                    "Geography",
                                    "Music",
                                    "Physical Education"
                                };
                                var teacherSubject = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                    .Title("Select subject: ")
                                    .AddChoices(subjects));
                                var teacher = new Teacher(teacherName, teacherSurname, teacherAge, teacherSubject);
                                manager.Add(teacher);
                            }
                            else if (addUser == "Add Student")
                            {
                                var studentName = AnsiConsole.Ask<string>("Enter student name: ");
                                var studentSurname = AnsiConsole.Ask<string>("Enter studnet surname: ");
                                var studentAge = AnsiConsole.Ask<int>("Enter student age: ");
                                var studentGrade = AnsiConsole.Ask<int>("Enter studnet Grade: ");
                                var studentGpa = AnsiConsole.Ask<int>("Enter student GPA: ");

                                var teacherOptions =
                                    manager.teachers.Select(t => $"{t.Name} {t.Surname} ({t.Subject})");

                                // получаем строку выбранного учителя из списка
                                var selectedTeacherString = AnsiConsole.Prompt(
                                    new SelectionPrompt<string>()
                                        .Title("Select a teacher for the student:")
                                        .AddChoices(teacherOptions)
                                );

                                var selectedTeacher = manager.teachers.First(t =>
                                    $"{t.Name} {t.Surname} ({t.Subject})" == selectedTeacherString);

                                var student = new Student(studentName, studentSurname, studentAge, studentGrade,
                                    studentGpa, selectedTeacher);
                                manager.Add(student);
                            }

                            if (addUser == "Return")
                            {
                                break;
                            }
                        }

                        break;
                    }
                    case "➖  Delete":

                    {
                        while (true)
                        {
                            var removeUser = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                .AddChoices("Remove Teacher", "Remove Student", "Return"));
                            if (removeUser == "Remove Teacher")
                            {
                                var teacherChoice = manager.teachers
                                    .Select(t =>
                                        $"{t.Name} {t.Surname} {t.Subject}")
                                    .ToList();

                                if (!teacherChoice.Any())
                                {
                                    AnsiConsole.MarkupLine("[red]List empty. Please add a teacher[/]");
                                }
                                else
                                {

                                    var removeTeacher = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                        .Title("Select teacher to remove:")
                                        .AddChoices(manager.teachers.Select(t =>
                                            $"{t.Name} {t.Surname} ({t.Subject})")));

                                    var selectedTeacher = manager.teachers.First(t =>
                                        $"{t.Name} {t.Surname} ({t.Subject})" == removeTeacher);
                                    manager.Remove(selectedTeacher);
                                }
                            }

                            if (removeUser == "Remove Student")
                            {

                                var studentChoice = manager.students
                                    .Select(s => $"{s.Name} {s.Surname}")
                                    .ToList();

                                if (!studentChoice.Any())
                                {
                                    AnsiConsole.MarkupLine("[red]List empty. Please add a student.[/]");
                                }
                                else
                                {
                                    var removeStudent = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                        .Title("Select student to remove: ")
                                        .AddChoices(manager.students.Select(s => $"{s.Name} {s.Surname}")));

                                    var selectedStudent =
                                        manager.students.First(s => $"{s.Name} {s.Surname}" == removeStudent);
                                    manager.Remove(selectedStudent);
                                }
                            }
                            
                            if (removeUser == "Return")
                            {
                                break;
                            }
                        }
                    }break;
                    case "❌  Exit":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
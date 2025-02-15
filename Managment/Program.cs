using Managment.Models;
using Spectre.Console;

namespace Managment;

internal abstract class Program
{
    private static void Main()
    {

        SchoolManager<Person> manager = new SchoolManager<Person>();

        while (true)
                
        {   
            Console.Clear();
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[blue]Welcome to M3 School Management App:[/]")
                .AddChoices("📚 Show Teachers", "🎓 Show Students", "🔎 Find Student", "➕  Add", "➖  Delete",
                    "❌  Exit"));
            
            {
                Console.Clear();
                if (choice == "📚 Show Teachers")
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
                        else if (choice2 == "Exit")
                        {
                            Environment.Exit(0);
                        }
                    }
                }

                else if (choice == "🎓 Show Students")
                {
                    manager.ShowStudentsTable();
                    while (true)
                    {
                        var choice2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            // .Title("Do you want to go back to the main menu?")
                            .AddChoices("Return", "Exit"));
                        if (choice2 == "Return")
                        {
                            break;
                        }
                        else if (choice2 == "Exit")
                        {
                            Environment.Exit(0);
                        }
                    }

                }
                else if (choice == "🔎 Find Student")
                {
                    // Console.WriteLine("Enter the student name");
                    // var studentName = Console.ReadLine();
                    // var student = manager.Find(studentName);
                    // if (student != null)
                    // {
                    //     showStudentInfo(student);
                    // }
                    // else
                    // {
                    //     Console.WriteLine("Student not found");
                    // }
                    // Console.ReadLine();
                }
                else if (choice == "➕  Add")
                {
                    var newStudent = new Student("John", "Doe", 32, 5, 4, new Teacher("John", "S", 2, "Nat"));
                    manager.Add(newStudent);

                }
                else if (choice == "➖  Delete")
                {

                }
                else if (choice == "❌  Exit")
                {
                    Environment.Exit(0);
                }
                
            }

        }
    }


}

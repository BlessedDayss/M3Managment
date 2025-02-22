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
                            else if (choice2 == "Exit")
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
                    case "➖  Delete":
                        break;
                    case "❌  Exit":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
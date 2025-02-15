using Managment;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[blue]Welcome to M3 School Managment App:[/]")
                .AddChoices("📚 Show Teachers", "🎓 Show Students", "🔎 Find Student", "❌  Exit"));
            
            
        while (true)
        {
            if (choice == "📚 Show Teachers" )
            {
                
            }
            else if (choice == "🎓 Show Students")
            {
                
            }
            else if (choice == "🔎 Find Student")
            {

            }
            else if (choice == "❌  Exit")
            {
                break;
            }
        }
    }
}
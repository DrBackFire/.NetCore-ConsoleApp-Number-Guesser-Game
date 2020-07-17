using System;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace number_guesser
{
    class Program
    {
        static void Main(string[] args)
        {

            GetAppInfo();

            // Init Form to get user input
            Form form = new Form();

            Console.WriteLine("To play the game you must first provid the following info...");

            // Saving the user's name in a var
            string name = form.UserName();

            // Saving user's age in a var
            var age = form.Age();

            GreetUser(name, age);

            // Init Game
            NumberGame game = new NumberGame();

            // Set time of start
            DateTime start = DateTime.Now;

            Console.WriteLine($"You started the game on the {start}");

            // Start the game
            game.Game();

            // Set time of finish
            DateTime finish = DateTime.Now;

            // Thank user
            Console.WriteLine("THANK YOU for playing, hope you enjoyed the game.");

            // providing finish time
            Console.WriteLine($"You finished the game on the {finish}");
        }

        // Get Date
        static DateTime Now { get; }


        // Get and display app info
        static void GetAppInfo()
        {
            // Set app vars
            string appName = "Number Guesser Game";
            string appVersion = "1.0.0";
            string appAuthor = "Abdulrahman Ebrahim";

            // Change text color
            Console.ForegroundColor = ConsoleColor.Green;

            // Write out app info
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);

            // Reset text color
            Console.ResetColor();
        }

        static void GreetUser(string name, int age)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Hi {name}, you are {age} years old!");

            Console.ResetColor();
        }
    }
}

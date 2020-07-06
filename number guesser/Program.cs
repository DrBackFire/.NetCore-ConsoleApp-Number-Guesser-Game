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

    class Form
    {

        public virtual void Lables(string lable)
        {
            Console.WriteLine("Enter Your " + lable);
        }

        public string UserName()
        {
            Lables("Full Name:");
            string Name = Console.ReadLine();

            // Checking User Input
            while (string.IsNullOrEmpty(Name))
            {

                Alerts(ConsoleColor.Red, "Please Enter Your Name");

                // Reset text color
                Console.ResetColor();

                Console.WriteLine("Name can't be empty! Input your name once more");
                Lables("Full Name:");
                Name = Console.ReadLine();

            }

            return Name;
        }

        public int Age()
        {
            // Asking for user input
            Console.WriteLine("Enter the year you where born at");

            int year;

            // Getting user input
            string stringYear = Console.ReadLine();

            // Validating user input
            while (!int.TryParse(stringYear, out year))
            {
                Alerts(ConsoleColor.Red, "Please Enter a Number");

                // Reset text color
                Console.ResetColor();

                Console.WriteLine("Enter the year you where born at");

                stringYear = Console.ReadLine();

                bool parseYear = int.TryParse(stringYear, out year);

                if (parseYear)
                {
                    continue;
                }

            }

            int userYear = Convert.ToInt32(stringYear);

            var age = 2020 - userYear;

            return age;
        }

        // Setting alerts for errors
        public void Alerts(ConsoleColor color, string messege)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(messege);
        }

    }

    class NumberGame : Form // Inheriting methods from Form
    {

        // Overriding inherted method
        public override void Lables(string lable)
        {
            Console.WriteLine(lable);
        }

        public void Game()
        {

            while (true)
            {
                // Create a new Random object
                Random random = new Random();

                Console.WriteLine("Choose a number between 1 and 10");

                // Init correct number
                int correctNumber = random.Next(1, 10);

                // Init guess var
                int guess = 0;

                Lables("Enter Your Number:");


                while (guess != correctNumber)
                {
                    // Asking user for an input
                    var Userinput = Console.ReadLine();

                    // Validate user input
                    if (!int.TryParse(Userinput, out guess))
                    {
                        // Alerting User
                        Alerts(ConsoleColor.Red, "Enter a number!");

                        // Reset text color
                        Console.ResetColor();

                        // Keep Going
                        continue;
                    }

                    // Converting User input to a number
                    guess = Convert.ToInt32(Userinput);

                    // Validate answer
                    if (guess != correctNumber)
                    {
                        Alerts(ConsoleColor.DarkGreen, "Wrong! Try again");

                        // Reset text color
                        Console.ResetColor();

                        Lables("Enter Your Number:");
                    }
                    else
                    {
                        Alerts(ConsoleColor.Blue, "Correct!");

                        Console.ResetColor();

                        // Ask to play again
                        Lables("Play Again? [Y or N]");

                        // Get answer
                        string answer = Console.ReadLine().ToUpper();

                        if (answer == "Y")
                        {
                            continue;
                        }
                        else if (answer == "N")
                        {
                            return;
                        }
                        else
                        {
                            return;
                        }


                    }
                }




            }
        }







    }

    // Where This File Ends...
}

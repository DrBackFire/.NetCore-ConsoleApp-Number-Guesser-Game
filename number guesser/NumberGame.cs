using System;
using System.Collections.Generic;
using System.Text;

namespace number_guesser
{
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
}

using System;
using System.Collections.Generic;
using System.Text;

namespace number_guesser
{
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

}

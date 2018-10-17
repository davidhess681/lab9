using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_Lists_
{
    class Program
    {
        // declare these variables here to use them in multiple methods
        static string userQuestion;
        static int userInt;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our C# class!");

            // create and populate lists with data
            List<string> names = new List<string>();
            PopulateNamesList(names);
            List<int> numbers = new List<int>();
            PopulateNumbersList(numbers);
            List<string> seasons = new List<string>();
            PopulateSeasonsList(seasons);
            List<string> colors = new List<string>();
            PopulateColorsList(colors);

            do
            {
                Console.WriteLine("\nWould you like to add a student or learn about an existing student?");
                Console.Write("(enter add or learn): ");
                
                if (AddOrLearn())
                {
                    // run this code if AddOrLearn() returns true

                    // prompt user for name of new student and their favorite season, color, and number
                    Console.WriteLine("\nWhat is the name of the student you want to add?\n");
                    string newStudent = ValidateUserInput();
                    Console.WriteLine("\nWhat is their favorite season?\n");
                    string newSeason = ValidateUserInput();
                    Console.WriteLine("\nWhat is their favorite color?\n");
                    string newColor = ValidateUserInput();
                    Console.WriteLine("\nWhat is their favorite number?\n");
                    int newNumber = ValidateUserInt();

                    // add new student to the list of students
                    names.Add(newStudent);

                    // sort the student list alphabetically
                    names.Sort();

                    // get the index of the newly added student
                    int index = names.IndexOf(newStudent);

                    // add the inputted season, color, and number at the new student's index
                    seasons.Insert(index, newSeason);
                    colors.Insert(index, newColor);
                    numbers.Insert(index, newNumber);

                    Console.WriteLine("\n{0} was added to the list of students as student #{4}. \n{0}'s favorite season is {1}, favorite color is {2}, and favorite number is {3}", newStudent, newSeason, newColor, newNumber, (index + 1));
                }
                else
                {
                    // run this code if AddOrLearn() returns false

                    // prompt user for the student they're looking for
                    Console.WriteLine("\nWhich student would you like to know about?");
                    Console.Write("(enter their first name or student #): ");

                    // store said student's index as a variable
                    int currentName = GetStudentNameIndex(names);

                    // prompt user for the data they're looking for
                    Console.WriteLine("\nWhich of {0}'s favorites would you like to learn about?", names[currentName]);
                    Console.Write("(enter season, color, or number): ");

                    // store said data type as a string
                    string currentFavorite = GetStudentFavorite();
                    
                    // print data based on the data type the user asked for
                    if (currentFavorite == "season")
                    {
                        Console.WriteLine("\n{0}'s favorite {1} is {2}.", names[currentName], currentFavorite, seasons[currentName]);
                    }
                    else if (currentFavorite == "color")
                    {
                        Console.WriteLine("\n{0}'s favorite {1} is {2}.", names[currentName], currentFavorite, colors[currentName]);
                    }
                    else if (currentFavorite == "number")
                    {
                        Console.WriteLine("\n{0}'s favorite {1} is {2}.", names[currentName], currentFavorite, numbers[currentName]);
                    }
                }
                Console.Write("\nWould you like to continue? (y/n): ");
            }
            while (PlayAgain());
        }

        static bool AddOrLearn()
        {
            // return true if user inputs add; false if learn
            userQuestion = Console.ReadLine();
            if (userQuestion == "add")
            {
                return true;
            }
            else if (userQuestion == "learn")
            {
                return false;
            }
            else
            {
                // use recursion to give user another try
                Console.Write("Invalid. Try again: ");
                return AddOrLearn();
            }

        }
        static string ValidateUserInput()
        {
            // check user input to make sure it isn't blank, else repeat
            userQuestion = Console.ReadLine();
            if (userQuestion == "")
            {
                Console.Write("Field cannot be blank. Try again: ");
                return ValidateUserInput();
            }
            else
            {
                return userQuestion;
            }
        }
        static int ValidateUserInt()
        {
            try
            {
                // parse user input to an int, then return int
                userInt = int.Parse(Console.ReadLine());
                return userInt;
            }
            catch (FormatException)
            {
                // if user input is not an int, repeat using recursion
                Console.Write("Not a number. Try again: ");
                return ValidateUserInt();
            }
        }

        static int GetStudentNameIndex(List<string> names)
        {
            // set user's input to a variable
            string userInput = Console.ReadLine();

            // check if user inputted the index or the name
            if (int.TryParse(userInput, out int result))
            {
                // match user input to their intended index
                int studentNum = result - 1;

                // check if index exists in the list
                if (studentNum >= 0 && studentNum < names.Count)
                {
                    return studentNum;
                }
                else
                {
                    // if not, repeat with recursion
                    // I love recursion
                    Console.Write("That student doesn't exist. Try again: ");
                    return GetStudentNameIndex(names);
                }
            }
            else {
                try
                {
                    // search list of names for the user's input, then return its index
                    return names.IndexOf(userInput);
                }
                catch
                {
                    // if user's input is not a name in the list, repeat with recursion
                    Console.Write("That student doesn't exist. Try again: ");
                    return GetStudentNameIndex(names);
                }
            }
        }
        static string GetStudentFavorite()
        {
            userQuestion = Console.ReadLine();

            // check if user input matches one of the data types
            if (userQuestion == "season" || userQuestion == "color" || userQuestion == "number")
            {
                // return the user's input
                return userQuestion;
            }
            else
            {
                // else repeat with recursion
                Console.Write("That data does not exist. Try again: ");
                return GetStudentFavorite();
            }
        }
        
        static void PopulateNamesList(List<string> names)
        {
            // add the following names to the new list "names"
            names.Add("Andrea");
            names.Add("Anthony");
            names.Add("Brian");
            names.Add("Camille");
            names.Add("Clayton");
            names.Add("Damacious");
            names.Add("David");
            names.Add("Evan");
            names.Add("Heather");
            names.Add("Jacky");
            names.Add("Johnathan");
            names.Add("Katie");
            names.Add("Levi");
            names.Add("Mauricio");
            names.Add("Nicholas");
            names.Add("Rudy");
            names.Add("SeanO");
            names.Add("Steve");
            names.Add("Ty");
        }
        static void PopulateNumbersList(List<int> numbers)
        {
            // add the following numbers to the new list "numbers"
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.Add(40);
            numbers.Add(50);
            numbers.Add(60);
            numbers.Add(70);
            numbers.Add(80);
            numbers.Add(90);
            numbers.Add(15);
            numbers.Add(25);
            numbers.Add(35);
            numbers.Add(45);
            numbers.Add(55);
            numbers.Add(65);
            numbers.Add(75);
            numbers.Add(85);
            numbers.Add(95);
            numbers.Add(0);
        }
        static void PopulateSeasonsList(List<string> seasons)
        {
            // add the following seasons to the new list "seasons"
            seasons.Add("Winter");
            seasons.Add("Spring");
            seasons.Add("Summer");
            seasons.Add("Fall");
            seasons.Add("Winter");
            seasons.Add("Spring");
            seasons.Add("Summer");
            seasons.Add("Fall");
            seasons.Add("Winter");
            seasons.Add("Spring");
            seasons.Add("Summer");
            seasons.Add("Fall");
            seasons.Add("Winter");
            seasons.Add("Spring");
            seasons.Add("Summer");
            seasons.Add("Fall");
            seasons.Add("Winter");
            seasons.Add("Spring");
            seasons.Add("Summer");

        }
        static void PopulateColorsList(List<string> colors)
        {
            // add the following colors to the new list "colors"
            colors.Add("Red");
            colors.Add("Orange");
            colors.Add("Yellow");
            colors.Add("Green");
            colors.Add("Blue");
            colors.Add("Indigo");
            colors.Add("Purple");
            colors.Add("Red");
            colors.Add("Orange");
            colors.Add("Yellow");
            colors.Add("Green");
            colors.Add("Blue");
            colors.Add("Indigo");
            colors.Add("Purple");
            colors.Add("Red");
            colors.Add("Orange");
            colors.Add("Yellow");
            colors.Add("Green");
            colors.Add("Blue");
        }

        static bool PlayAgain()
        {
            // repeat the program if user types "y", close if "n"
            switch (Console.ReadLine())
            {
                case "y":
                    {
                        return true;
                    }
                case "n":
                    {
                        return false;
                    }
                default:
                    {
                        Console.Write("Invalid. Try again: ");
                        return PlayAgain();
                    }
            }
        }
    }
}

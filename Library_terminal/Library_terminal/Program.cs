using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_terminal
{
    class Program
    {
        //public static string title;
        //public static int indexNumber, collectionLength;
        //create a library include author, title and  status (checked in/out)
        public static List<List<string>> bookLibrary = new List<List<string>> {
        new List<string> { "Fight Club", "Chuch Palahniuk", "Checked-In" },
        new List<string> { "Rant: The Oral Biography of Buster Casey", "Chuch Palahniuk","Checked-In" },
        new List<string> { "American Psycho", "Bret Easton Ellis", "Checked-In" },
        new List<string> { "Fear and Loathing in Las Vegas", "Hunter S. Thompson", "Checked-In" },
        new List<string> { "Howl's Moving Castle", "Diana Wynne Jones", "Checked-In" },
        new List<string> { "Castle in the Air", "Diana Wynne Jones", "Checked-In" },
        new List<string> { "House of Many Ways", "Diana Wynne Jones", "Checked-In" },
        new List<string> { "Dead Until Dark", "Charlaine Harris", "Checked-In" },
        new List<string> { "Dead and Gone", "Charlaine Harris", "Checked-In" },
        new List<string> { "The Grapes of Wrath", "John Steinbeck", "Checked-In" },
        new List<string> { "Club Dead", "Charlaine Harris", "Checked-In" },
        new List<string> { "From Dead to Worse", "Charlaine Harris", "Checked-In" }};




        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Miniture Library!");


            Pathway();
            ReRun();
        }

        static void Pathway()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("What would you like to do? Press \'1\' to Sort, \'2\' to Search, \'3\' to check out or return: and \'4\' to leave: ");
                    int choosePath = int.Parse(Console.ReadLine());
                    if (choosePath == 1)
                    {
                        ChooseDisplay();
                    }
                    if (choosePath == 2)
                    {
                        SearchFunction();
                    }
                    if (choosePath == 3)
                    {
                        CheckInOut();
                    }
                    if (choosePath == 4)
                    {
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                    }              
                 }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Number out of range");

                }
                catch (FormatException)
                {
                    Console.WriteLine("Input not correct, please try again");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("You are out of range.");
                }
            }
        }

        static void ChooseDisplay()
        {
            while (true)
            {

                //Sort the list alphabetically by author or title depending on what the user chooses 
                //display the library book list

                Console.WriteLine("Would you like to sort by Author or by Title?");
                string choice = Console.ReadLine().ToLower();
                if (choice == "author")
                {

                }

                if (choice == "title")
                {

                }

            }
        }

        static void SearchFunction()
        {
            //create a search function and return that book 

        }

        static void CheckInOut()
        {
            //give the option to check out the book or notify that the book is already checked out 

            //give the option to return the book 
        }
        static void ReRun()
            {

            //rerun loop 
            Console.WriteLine("Back to main menu? y/n: ");
                string goAgain = Console.ReadLine().ToLower();
                if (goAgain == "yes" || goAgain == "y")
                {
                    Console.Clear();
                Pathway();
                    
              
                if (goAgain == "no" || goAgain == "n")
                {
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);

                }
            }
        }
    }
}

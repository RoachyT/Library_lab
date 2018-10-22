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
        new List<string> { "Fight Club", "Chuck Palahniuk", "In" },
        new List<string> { "Rant: The Oral Biography of Buster Casey", "Chuck Palahniuk","Out" },
        new List<string> { "American Psycho", "Bret Easton Ellis", "In" },
        new List<string> { "Fear and Loathing in Las Vegas", "Hunter S. Thompson", "In" },
        new List<string> { "Howl's Moving Castle", "Diana Wynne Jones", "In" },
        new List<string> { "Castle in the Air", "Diana Wynne Jones", "Out" },
        new List<string> { "House of Many Ways", "Diana Wynne Jones", "In" },
        new List<string> { "Dead Until Dark", "Charlaine Harris", "In" },
        new List<string> { "Dead and Gone", "Charlaine Harris", "In" },
        new List<string> { "The Grapes of Wrath", "John Steinbeck", "Out" },
        new List<string> { "Club Dead", "Charlaine Harris", "In" },
        new List<string> { "From Dead to Worse", "Charlaine Harris", "In" }};


        static void Main(string[] args)
        {
            List<string> title = new List<string>();
            List<string> author = new List<string>();
            List<string> checkedInOut = new List<string>();

            for (int x = 0; x < bookLibrary.Count; x++)
            {
                title.Add(bookLibrary[x][0]);
                author.Add(bookLibrary[x][1]);
                checkedInOut.Add(bookLibrary[x][2]);

            }

            
            Console.WriteLine("Welcome to the Miniture Library (Friend, we don\'t have a lot of books)");

           Pathway(author,title,ref bookLibrary);
            ReRun(author,title,ref bookLibrary);
        }

        static void Pathway(List<String> author, List<String> title, ref List<List<string>> bookLibrary)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("What would you like to do?\nPress: \n\'1\' to Sort\n\'2\' to Search" +
                        "\n\'3\' to Check Out\n\'4\' to Return Book\n\'5\' to Leave: ");
                    int choosePath = int.Parse(Console.ReadLine());
                    if (choosePath == 1)
                    {
                        ChooseDisplay( author, title,ref bookLibrary);
                    }
                    if (choosePath == 2)
                    {
                        SearchFunction(ref bookLibrary);
                    }
                    if (choosePath == 3)
                    {
                        CheckOut();
                    }
                    if (choosePath == 4)
                    {
                        CheckIn();
                    }
                    if (choosePath == 5)
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

        static void ChooseDisplay(List<String>author, List<String> title, ref List<List<string>> bookLibrary)
        {
            while (true)
            {

                //Sort the list alphabetically by author or title depending on what the user chooses 
                //display the library book list

                Console.WriteLine("Would you like to sort by Author or by Title?");
                string choice = Console.ReadLine().ToLower();
                if (choice == "author")
                {
                    bookLibrary = bookLibrary.OrderBy(a => a[1]).ToList();
                    PrintMe(bookLibrary);
                    Console.WriteLine();
                }

                if (choice == "title")
                {
                    bookLibrary = bookLibrary.OrderBy(a => a[0]).ToList();
                    PrintMe(bookLibrary);
                }
                Console.WriteLine();
                break;
            }
        }

        static void SearchFunction(ref List<List<string>>bookLibrary)
        {
            //create a search function and return that book

            Console.WriteLine("What would you like to search by Title or Author ");
            string choosePath =Console.ReadLine().ToLower();
            if (choosePath == "author")
            {

                Console.WriteLine("Search(case sensitive): ");
                string searchKeyword = Console.ReadLine();
                bookLibrary = bookLibrary.Where(a => a[1].Contains(searchKeyword)).ToList();
                PrintMe(bookLibrary);
                Console.WriteLine();
              
            }
           else if (choosePath == "title") 
            {
                Console.WriteLine("Search(case sensitive): ");
                string searchKeyword = Console.ReadLine();
                bookLibrary = bookLibrary.Where(a => a[0].Contains(searchKeyword)).ToList();
                PrintMe(bookLibrary);
                Console.WriteLine();
            }        
        }


        static void CheckOut()
        {
            //give the option to check out the book or notify that the book is already checked out 
            Console.WriteLine("Would you like to check out a book? y/n");
            string decision = Console.ReadLine().ToLower();

            while (true)
            {
                bool bookWasCheckedIn = false;
                if (decision == "yes" || decision == "y")
                {
                    PrintMe(bookLibrary);

                    Console.WriteLine("Type the title of the book(case sensitive) ");
                    string checking = Console.ReadLine();
                    foreach (var book in bookLibrary)
                    {
                        if (checking == book[0] && book[2] == "In")
                        {
                                Console.WriteLine("You have checked out the book\n\n");
                                book[2] = "Out";
                            bookWasCheckedIn = true;
                                break;
                        }
                    }
                   if (!bookWasCheckedIn)
                    {
                        Console.WriteLine("Sorry that book is unavailable\n");
                        
                    }
                    break;
                }
                else if (decision == "no" || decision == "n")
                {
                    break;
                }
            }
        }
        static void CheckIn()
        {
            //give the option to return the book 
            Console.WriteLine("Would you like to check in a book? y/n");
            string decision = Console.ReadLine().ToLower();

            while (true)
            {
                bool bookWasCheckedOut = false;
                if (decision == "yes" || decision == "y")
                {
                    PrintMe(bookLibrary);

                    Console.WriteLine("Type the title of the book(case sensitive) ");
                    string checking = Console.ReadLine();
                    foreach (var book in bookLibrary)
                    {
                        if (checking == book[0] && book[2] == "Out")
                        {
                            Console.WriteLine("You have checked in the book\n\n");
                            book[2] = "In";
                            bookWasCheckedOut = true;
                            break;
                        }
                    }
                    if (!bookWasCheckedOut)
                    {
                        Console.WriteLine("Sorry that book is unavailable\n");
                    }
                    break;
                }
                else if (decision == "no" || decision == "n")
                {
                    break;
                }
            }
        }

        static void PrintMe(List<List<string>> booklibrary)
        {
            Console.WriteLine("{0,-45}{1,-20}{2,-10}", "Title", "Author", "Status:Checked");
            Console.WriteLine();
            //path List<List<string>> bookLibrary
            foreach (var book in bookLibrary)
            { 
                    Console.WriteLine("{0,-45}{1,-20}{2,-10}", book[0], book[1], book[2]);       
            }
        }
        static void ReRun(List<String> author, List<String> title, ref List<List<string>> bookLibrary)
            {
            //rerun loop 
            Console.WriteLine("Back to main menu? y/n: ");
                string goAgain = Console.ReadLine().ToLower();
                if (goAgain == "yes" || goAgain == "y")
                {
                    Console.Clear();
                Pathway(author, title, ref bookLibrary);
                    
              
                if (goAgain == "no" || goAgain == "n")
                {
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                }
            }
        }
    }
}

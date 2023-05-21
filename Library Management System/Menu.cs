using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class Menu
    {
        Library lib = new Library();

        public void RunLibrary() 
        {
            bool isRunning = true;
            while (isRunning)
            {
                DisplayMenu();

                string choice = Console.ReadLine();

                switch (choice) 
                {
                    case "1":
                        Console.WriteLine("What is the title of your book: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Who is the author of " + title + ": ");
                        string author = Console.ReadLine();
                        Console.WriteLine("In which year was " + title + " published? ");
                        string yearstr = Console.ReadLine();
                        int year = 0;
                        if (yearstr != null) 
                        {
                            int.TryParse(yearstr, out year);
                        }
                        Console.WriteLine("Please provide correct ISBN: ");
                        string isbn = Console.ReadLine();
                        try
                        {
                            lib.AddBook(title, author, year, isbn);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;
                    case "2":
                        lib.DisplayAllBooks();
                        break;
                    case "3":
                        Console.WriteLine("Provide us with data of your search. If you dont know for example title than leave it empty.");
                        Console.WriteLine("What is the title of book you are searching for: ");
                        title = Console.ReadLine();
                        Console.WriteLine("Who is the atuthor of that book: ");
                        author = Console.ReadLine();
                        Console.WriteLine("In witch year was this book published: ");
                        yearstr = Console.ReadLine();
                        year = 0;
                        if (yearstr != null)
                        {
                            int.TryParse(yearstr,out year);
                        }
                        lib.Search(title, author, year);
                        break;
                    case "4":
                        Console.WriteLine("Please provide us with correct ISBN: ");
                        isbn = Console.ReadLine();
                        lib.Return(isbn);
                        break;
                    case "5":
                        Console.WriteLine("Please provide us with correct ISBN: ");
                        isbn = Console.ReadLine();
                        lib.Borrow(isbn);
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    case "7":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                        
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        }
        public void DisplayMenu() 
        {
            Console.WriteLine();
            Console.WriteLine("===== Library Management System =====");
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Display all books");
            Console.WriteLine("3. Search for a book");
            Console.WriteLine("4. Return book");
            Console.WriteLine("5. Borrow book");
            Console.WriteLine("6. Clear view");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
        }
    }
}

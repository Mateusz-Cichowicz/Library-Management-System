using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class Library
    {
        private List<Book> books = new List<Book> {
                new Book("To Kill a Mockingbird", "Harper Lee", 1960, "1"),
                new Book("1984", "George Orwell", 1949, "2"),
                new Book("Pride and Prejudice", "Jane Austen", 1813, "3"),
                new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "4"),
                new Book("The Hobbit", "J.R.R. Tolkien", 1937, "5"),
                new Book("Moby-Dick", "Herman Melville", 1851, "6"),
                new Book("To the Lighthouse", "Virginia Woolf", 1927, "7"),
                new Book("The Catcher in the Rye", "J.D. Salinger", 1951, "8"),
                new Book("Brave New World", "Aldous Huxley", 1932, "9"),
                new Book("One Hundred Years of Solitude", "Gabriel Garcia Marquez", 1967, "10"),
                new Book("The Lord of the Rings", "J.R.R. Tolkien", 1954, "11"),
                new Book("Anna Karenina", "Leo Tolstoy", 1877, "12"),
                new Book("The Odyssey", "Homer", -800, "13"),
                new Book("Jane Eyre", "Charlotte Bronte", 1847, "14"),
                new Book("The Chronicles of Narnia", "C.S. Lewis", 1950, "15"),
                new Book("Frankenstein", "Mary Shelley", 1818, "16"),
                new Book("The Picture of Dorian Gray", "Oscar Wilde", 1890, "17"),
                new Book("Don Quixote", "Miguel de Cervantes", 1605, "18"),
                new Book("The Alchemist", "Paulo Coelho", 1988, "19"),
                new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 1997, "20")};
        private List<Book> avaibleBooks;
        private List<Book> borrowedBooks = new List<Book>();

        public Library() 
        {
            avaibleBooks = new List<Book>(books);
        }
        public void AddBook(string title, string author, int publicationYear, string isbn)
        {
            if (string.IsNullOrWhiteSpace(title)) 
            {
                throw new ArgumentException("Title cannot be empty or wbitespace.");
            }
            if (string.IsNullOrWhiteSpace(author)) 
            {
                throw new ArgumentException("Author cannot be empty or wbitespace.");
            }
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("ISBN cannot be empty or wbitespace.");
            }

            Book book = books.FirstOrDefault(b => b.ISBN.Equals(isbn));
            if(book != null)
            {
                throw new ArgumentException("This ISBN is already used");
            }

            if (publicationYear <= DateTime.Now.Year && publicationYear != 0)
            {
                books.Add(new Book(title, author, publicationYear, isbn));
                avaibleBooks = books;
            }
            else 
            { 
                throw new ArgumentException("You provided wrong publication year."); 
            }
        }
        public void DisplayAllBooks() 
        {
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(i+1 + ".  Title: " + books[i].Title + " Author: " + books[i].Author + 
                    " Publication year: " + books[i].PublicationYear + " ISBN: " + books[i].ISBN);
            }
        }
        public void Search(string title, string author, int publicationYear)
        {
            var query = books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(b => b.Title.ToLower().Contains(title.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                query = query.Where(b => b.Author.ToLower().Contains(author.ToLower()));
            }
            if (publicationYear != 0)
            {
                query = query.Where(b => b.PublicationYear == publicationYear);
            }

            DisplayList(query.ToList());
        }

        private void DisplayList(List<Book> searchResults) 
        {
            Console.WriteLine();
            if (searchResults.Count > 0)
            {
                Console.WriteLine("You found these books: ");
                for (int i = 0; i < searchResults.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". Title: " + searchResults[i].Title + " Author: " + searchResults[i].Author +
                        " Publication year: " + searchResults[i].PublicationYear + " ISBN: " + searchResults[i].ISBN);
                }
            }
            else 
            {
                Console.WriteLine("We do not have that book in our collection.");
            }
        }

        public void Borrow(string isbn) 
        {
            Book book = avaibleBooks.FirstOrDefault(b => b.ISBN.Equals(isbn));
            if(book == null) 
            {
                Console.WriteLine("This book is not avabile to borrow right now.");
            }
            else
            {
                avaibleBooks.Remove(book);
                borrowedBooks.Add(book);
                Console.WriteLine("Here you go this is book you borrowed: " + ". Title: " + book.Title + " Author: " + book.Author +
                    " Publication year: " + book.PublicationYear + " ISBN: " + book.ISBN);
            }

        }
        public void Return(string isbn)
        {
            Book book = borrowedBooks.FirstOrDefault(b => b.ISBN.Equals(isbn));
            if (book == null)
            {
                Console.WriteLine("You can't return this book right now. Consider adding it to our collection.");
            }
            else
            {
                borrowedBooks.Remove(book);
                avaibleBooks.Add(book);
                Console.WriteLine("Thank you for returning this book to us: " + ". Title: " + book.Title + " Author: " + book.Author +
                    " Publication year: " + book.PublicationYear + " ISBN: " + book.ISBN);
            }

        }

    }
}

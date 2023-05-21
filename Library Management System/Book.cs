using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class Book
    {
        public string Title { get; }
        public string Author { get; }
        public int PublicationYear { get; }
        public string ISBN { get; }

        public Book(string title, string author, int publicationYear, string isbn) 
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            ISBN = isbn;
        }
    }
}

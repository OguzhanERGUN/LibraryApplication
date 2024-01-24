using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Class
{
    public class Book
    {
        public string bookName { get; set; }
        public string bookWriter { get; set; }
        public int bookIsbn { get; set; }
        public int bookAmount { get; set; }
        public int booksBorrowed { get; set; }
        public Dictionary<int, Book> borrowedBook;


        public Book()
        {
            borrowedBook = new Dictionary<int, Book>();
        }

    }
}

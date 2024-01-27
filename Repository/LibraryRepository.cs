using LibraryApplication.Class;
using LibraryApplication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Repository
{
	public abstract class LibraryRepository : ILibrary
	{
		protected List<Book> booksdb;
		protected int bookcountdb;

        public LibraryRepository()
        {
            booksdb = new List<Book>();
        }

        public bool AddBook(Book newbook)
		{
			if (newbook == null) return false;
			Book book = booksdb.FirstOrDefault(x => x.bookIsbn == newbook.bookIsbn);
			if (book == null)
			{
				booksdb.Add(newbook);
				return true; 
			}
			return false;
		}

		public bool BorrowBook(string bookname)
		{
			Book bookfounded = booksdb.FirstOrDefault(x => x.bookName.ToLower() == bookname.ToLower());
			if (bookfounded == null || bookfounded.bookAmount == 0) return false;

			bookfounded.booksBorrowed++;
			bookfounded.bookAmount--;
			return true;
		}

		public List<Book> GetBooks()
		{
			return booksdb;
		}

		public List<Book> GetBooksWithWriterName(string writername) 
		{
			List<Book> books = booksdb.FindAll(x => x.bookWriter.ToLower() == writername.ToLower());
			return books;
		}

		public void PrintBooks()
		{
			Console.Out.Flush();
			Console.Clear();
			foreach (Book item in booksdb)
			{
				Console.WriteLine(
					"Kitap Başlığı: " + item.bookName + "\n" +
					"Kitabın Yazarı: " + item.bookWriter + "\n" +
					"Kitabın ISBN Kodu: " + item.bookIsbn + "\n" +
					"Kütüphanedeki adet sayısı: " + item.bookAmount + "\n" +
					"Ödünç verilmiş kitap sayısı: " + item.booksBorrowed + "\n" + "-----------------------");
			}
			Console.ReadKey();
		}

		public bool ReturnBook(Book book)
		{
			if (book == null) return false;
			Book bookfounded = booksdb.FirstOrDefault(x => x == book);
			if (bookfounded.booksBorrowed > 0)
			{
				bookfounded.bookAmount++;
				bookfounded.booksBorrowed--;
				return true;
			}

			//Ther is no borrowed for this book
			return false;
		}

		public Book SearchBookWithName(string bookname)
		{
			Book bookfounded = booksdb.FirstOrDefault(x => x.bookName.ToLower() == bookname.ToLower());
			if (bookfounded == null) return null;
			else return bookfounded;

		}

		public Book SearchBookWithWriter(string bookwriter)
		{
			Book bookfounded = booksdb.FirstOrDefault(x => x.bookWriter.ToLower() == bookwriter.ToLower());
			if (bookfounded == null) return null;
			else return bookfounded;
		}

		public Book SearchBookWithIsbn(int ısbncode)
		{
			Book bookfounded = booksdb.FirstOrDefault(x => x.bookIsbn == ısbncode);
			if (bookfounded == null) return null;
			else return bookfounded;
		}

	}
}

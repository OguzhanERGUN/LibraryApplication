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

		public bool AddBook(Book newbook)
		{
			if (booksdb == null) return false;
			booksdb.Add(newbook);
			return true;
		}

		public bool BorrowBook(Book book)
		{
			if (booksdb == null) return false;
			Book bookfounded = booksdb.FirstOrDefault(x => x == book);
			bookfounded.booksBorrowed++;
			return true;
		}

		public List<Book> GetBooks()
		{
			return booksdb;
		}

		public void PrintBooks()
		{
			throw new NotImplementedException();
		}

		public bool ReturnBook(Book book)
		{
			if (booksdb == null) return false;
			Book bookfounded = booksdb.FirstOrDefault(x => x == book);
			if (bookfounded.booksBorrowed > 0)
			{
				bookfounded.booksBorrowed--;
				return true;
			}

			//Ther is no borrowed for this book
			return false;
		}

		public Book SearchBookWithName(string bookname)
		{
			throw new NotImplementedException();
		}

		public Book SearchBookWithWriter(string bookwriter)
		{
			throw new NotImplementedException();
		}
	}
}

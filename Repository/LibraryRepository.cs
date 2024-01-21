using LibraryApplication.Class;
using LibraryApplication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Repository
{
	public class LibraryRepository : ILibrary
	{

		public bool AddBook(Book newbook)
		{
			throw new NotImplementedException();
		}

		public bool BorrowBook(Book book)
		{
			throw new NotImplementedException();
		}

		public List<Book> GetBooks()
		{
			throw new NotImplementedException();
		}

		public bool ReturnBook(Book book)
		{
			throw new NotImplementedException();
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

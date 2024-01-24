using LibraryApplication.Class;
using LibraryApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Interface
{
	public interface ILibrary
	{
		//Add book to library, if can add successfully it returns true
		bool AddBook(Book newbook);

		//Get all books in library
		List<Book> GetBooks();

		//Get books that writen by a spesific writer in library
		List<Book> GetBooksWithWriterName(string writername);

		//Search book in library with book name if the library does not containt book it returns null
		Book SearchBookWithName(string bookname);

		//Search book in library with book writer name if the library does not contains book it returns null
		Book SearchBookWithWriter(string bookwriter);

		//Borrow a book from the library, returns true when borrowed  successfully
		bool BorrowBook(string bookname);

		//Return a book to library, returns true when successfully retorned
		bool ReturnBook(Book book);

		//Prints all books
		void PrintBooks();
	}
}

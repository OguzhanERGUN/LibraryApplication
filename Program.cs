using LibraryApplication.Class;
using LibraryApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication
{
	public class Program
	{

		static void Main(string[] args)
		{
			PrintWelcomeMessage();
			Library library = new Library();
			Book book = new Book();
			book.bookName = "Yüzüklerin efendisi";
			book.bookWriter = "Ahmet Yılmaz";
			book.bookIsbn = 4343;
			book.booksBorrowed = 3;
			book.bookAmount = 30;
			Book book1 = new Book();
			book1.bookName = "Alacakaranlık";
			book1.bookWriter = "Mert Yılmaz";
			book1.bookIsbn = 6596;
			book1.booksBorrowed = 12;
			book1.bookAmount = 50;
			library.PrintBooks();
			library.AddBook(book);
			library.PrintBooks();
			library.AddBook(book1);
			library.PrintBooks();


			bool isQuit = false;
			//while (!isQuit)
			//{
			//	isQuit = true;
			//}
		}

		private static void PrintWelcomeMessage()
		{
			Console.WriteLine(
			"-----Oğuzhan Ergün Library Application----- \n Press any button...");
			Console.ReadKey();
		}
	}
}

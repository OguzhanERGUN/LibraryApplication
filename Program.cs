using LibraryApplication.Class;
using LibraryApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication
{
	public class Program: LibraryRepository
	{

		static void Main(string[] args)
		{
			PrintWelcomeMessage();

			bool isQuit = false;
			List<Book> books = new List<Book>{
				new Book { bookName = "Empati" ,bookAmount=11,bookIsbn=12345,booksBorrowed=2,bookWriter="Oğuzhan Ergün"},
				new Book { bookName = "Olasılıksız" ,bookAmount=19,bookIsbn=54876,booksBorrowed=4,bookWriter="Ömer bal"}
			};

			while (!isQuit)
			{
				Console.ReadKey();
				Console.WriteLine(books[0].bookName +" "+ books[0].bookAmount + " " + books[0].bookIsbn + " " + books[0].booksBorrowed + " " + books[0].bookWriter + "\n");
				Console.ReadKey();
				Console.WriteLine(books[1].bookName + " " + books[1].bookAmount + " " + books[1].bookIsbn + " " + books[1].booksBorrowed + " " + books[1].bookWriter + "\n");
				Console.ReadKey();
				isQuit = true;
			}
		}

		private static void PrintWelcomeMessage()
		{
			Console.WriteLine(
			"-----Oğuzhan Ergün Library Application----- \n Press any button...");
			Console.ReadKey();
		}
	}
}

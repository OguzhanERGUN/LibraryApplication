using LibraryApplication.Class;
using LibraryApplication.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication
{
	public class Program
	{

		static void Main(string[] args)
		{
			bool isQuit = false;
			PrintWelcomeMessage();
			Library library = new Library();
			Book book = new Book();
			book.bookName = "asdsad";
			book.bookWriter = "erqasd";
			book.bookIsbn = 123213;
			book.bookAmount = 24;
			book.booksBorrowed = 3;
			Console.WriteLine(library.AddBook(book));
			Book book1 = new Book();
			book1.bookName = "asdsadasdasd";
			book1.bookWriter = "erqassadasdd";
			book1.bookIsbn = 1233;
			book1.bookAmount = 64;
			book1.booksBorrowed = 33;
			Console.WriteLine(library.AddBook(book1));

			while (!isQuit)
			{
				string process = GetProcessValue();
				switch (process)
				{
					case "0":
						isQuit = true;
						break;
					case "1":
						library.PrintBooks();
						break;
					case "2":
						Book newbook = new Book();
						Console.WriteLine("Eklenecek kitabın adını giriniz");
						newbook.bookName = Console.ReadLine();
						Console.WriteLine("Eklenecek kitabın yazarını giriniz");
						newbook.bookWriter = Console.ReadLine();
						Console.WriteLine("Eklenecek kitabın ISBN kodunu giriniz");
						if (int.TryParse(Console.ReadLine(), out int Isbn))
						{
							newbook.bookIsbn = Isbn;
						}
						else
						{
							Console.WriteLine("\nBir hata meydana geldi, ISBN değerinin sadece sayılarıdan oluştuğundan emin olun");
							Console.ReadKey();
							break;
						}
						Console.WriteLine("Eklenecek kitabın Adedi giriniz");
						if (int.TryParse(Console.ReadLine(), out int amount))
						{
							newbook.bookAmount = amount;
						}
						else
						{
							Console.WriteLine("\nBir hata meydana geldi, adet değerinin sadece sayılarıdan oluştuğundan emin olun");
							Console.ReadKey();
							break;
						}
						newbook.booksBorrowed = 0;

						bool issucceed = library.AddBook(newbook);
						if (issucceed) Console.WriteLine("Kitap kütüphaneye başarıyla kaydedildi");
						else Console.WriteLine("Kitabı eklerken hata meydana geldi, lütfen girilen bilgileri kontrol ediniz ve \n" +
							"girilen ISBN kodunun doğru olduğundan emin olun (Daha önce kullanılmış kodu tekrar kullanamazsınız)");
						Console.ReadKey();
						break;
					case "3":
						Console.Clear();
						Console.WriteLine("Lütfen ödünç almak istediğiniz kitabın adını giriniz");
						string borrowbook = Console.ReadLine();
						if (library.BorrowBook(borrowbook))
						{
							Console.WriteLine("Kitap başarıyla ödünç alındı");
							Console.ReadKey();
						}
						else
						{
							Console.WriteLine("Kitap kütüphanede mevcut değil");
							Console.ReadKey();
						}
						break;
					case "4":
						Console.Clear();
						Console.WriteLine("İade edilecek kitabın adını giriniz.");
						string returnbook = Console.ReadLine();
						Book bookreturn = library.SearchBookWithName(returnbook);
						if (bookreturn.booksBorrowed > 0)
						{
							bookreturn.booksBorrowed--;
							bookreturn.bookAmount++;
							Console.WriteLine("Kitap başarıyla iade edildi.");
							Console.ReadKey();
						}
						else
						{
							Console.WriteLine("Bu kitabın ödünç alınmış bir kopyası bulunmuyor");
							Console.ReadKey();
						}
						break;
					default:
						PrintErrorMessage();
						break;
				}
			}
		}

		private static void PrintWelcomeMessage()
		{
			Console.WriteLine(
			"-----Oğuzhan Ergün Library Application----- \n Press any button...");
			Console.ReadKey();
			Console.Clear();
		}
		public static string GetProcessValue()
		{
			Console.Clear();
			Console.WriteLine(
				"\nYapmak istediğiniz işlem numarasını giriniz \n" +
				"Kitapları listelemek için -> '1'\n" +
				"Kütüphaneye kitap eklemek için -> '2'\n" +
				"Kütüphaneden kitap ödünç almak için -> '3'\n" +
				"Aldığınız kitabı iade etmek için -> '4'\n" +
				"Kitap ismi ile arama yapmak için -> '5'\n" +
				"Kitap yazarı ile arama yapmak için -> '6'\n" +
				"Çıkış yapmak için -> '0'\n");
			string process = Console.ReadLine();
			Console.Clear();
			return process;
		}
		private static void PrintErrorMessage()
		{
			Console.WriteLine("Hatalı karakter girişi yaptınız, lütfen belirtilen komutları takip edin");
			Console.ReadKey();
			Console.Clear();
		}
	}
}

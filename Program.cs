using LibraryApplication.Class;
using LibraryApplication.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
			//Veri tabanı mevcut solution altındaki bin/Debug/Db/ogrenciler.json uzantısında bulunuyor
			Database database = GetDatabaseValues(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Db", "ogrenciler.json"));
			bool isQuit = false;
			PrintWelcomeMessage();
			Library library = database.library;
			List<BookBorrowed> booksBorrowed = database.booksBorrowed;

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
							BookBorrowed bookBorrowed = new BookBorrowed();
							if (booksBorrowed.Count == 0)
							{
								bookBorrowed.bookId = 1;
							}
							else
							{
								bookBorrowed.bookId = booksBorrowed[booksBorrowed.Count - 1].bookId + 1;
							}
							bookBorrowed.bookIsbn = library.SearchBookWithName(borrowbook).bookIsbn;
							bookBorrowed.bookBorrowedDate = DateTime.Today;
							booksBorrowed.Add(bookBorrowed);
							Console.WriteLine("Kitap başarıyla ödünç alındı, kitabı " + bookBorrowed.bookId + " koduyla teslim edebilirsiniz");
						}
						else
						{
							Console.WriteLine("Kitap kütüphanede mevcut değil");
						}
						Console.ReadKey();
						break;
					case "4":
						Console.Clear();
						Console.WriteLine("İade edilecek kitabın iade kodunu giriniz.");
						string returnbook = Console.ReadLine();
						BookBorrowed bookborrowed = booksBorrowed.FirstOrDefault(x => x.bookId == int.Parse(returnbook));
						if (bookborrowed == null)
						{
							Console.WriteLine("Bu koda ait ödünç alımış bir kitap bulunamadı, doğru karakter girişi yaptığınızdan emin olun");
							Console.ReadKey();
							break;
						}
						Book bookreturn = library.SearchBookWithIsbn(bookborrowed.bookIsbn);
						if (bookreturn.booksBorrowed > 0)
						{
							bookreturn.booksBorrowed--;
							bookreturn.bookAmount++;
							booksBorrowed.Remove(bookborrowed);
							Console.WriteLine("Kitap başarıyla iade edildi.");
						}
						Console.ReadKey();
						break;
					case "5":
						Console.Clear();
						Console.WriteLine("Kitabın adını giriniz.");
						string bookname = Console.ReadLine();
						Book searchedbook = library.SearchBookWithName(bookname);
						if (searchedbook == null)
						{
							Console.WriteLine("Bu kitap kütüphanede bulunmuyor.");
						}
						else
						{
							Console.WriteLine(
								"Kitap Başlığı: " + searchedbook.bookName + "\n" +
								"Kitabın Yazarı: " + searchedbook.bookWriter + "\n" +
								"Kitabın ISBN Kodu: " + searchedbook.bookIsbn + "\n" +
								"Kütüphanedeki adet sayısı: " + searchedbook.bookAmount + "\n" +
								"Ödünç verilmiş kitap sayısı: " + searchedbook.booksBorrowed + "\n"
								+ "-----------------------");
						}
						Console.ReadKey();
						break;
					case "6":
						Console.Clear();
						Console.WriteLine("Yazarın adını giriniz");
						string writername = Console.ReadLine();
						List<Book> booksbywriter = library.GetBooksWithWriterName(writername);
						if (booksbywriter.Count == 0)
						{
							Console.WriteLine("Kütüphanede bu yazara ait kitap bulunmuyor");
						}
						else
						{
							foreach (var item in booksbywriter)
							{
								Console.WriteLine(
								"Kitap Başlığı: " + item.bookName + "\n" +
								"Kitabın Yazarı: " + item.bookWriter + "\n" +
								"Kitabın ISBN Kodu: " + item.bookIsbn + "\n" +
								"Kütüphanedeki adet sayısı: " + item.bookAmount + "\n" +
								"Ödünç verilmiş kitap sayısı: " + item.booksBorrowed + "\n" +
								"-----------------------");
							}
						}
						Console.ReadKey();
						break;
					case "7":
						Console.Clear();
						if (booksBorrowed.Count == 0)
						{
							Console.WriteLine("Kütüphaneden ödünç alınmış bir kitap bulunmuyor");
							Console.ReadLine();
							break;
						}
						foreach (BookBorrowed item in booksBorrowed)
						{
							searchedbook = library.SearchBookWithIsbn(item.bookIsbn);
							Console.WriteLine(
								"Kitap Başlığı: " + searchedbook.bookName + "\n" +
								"Kitabın Yazarı: " + searchedbook.bookWriter + "\n" +
								"Kitabın ISBN Kodu: " + searchedbook.bookIsbn + "\n" +
								"Kitabın ödünç alındığı tarih: " + item.bookBorrowedDate.ToString("dd/MM/yyyy") + "\n" +
								"Kitabın teslim edilmesi için son gün : " + item.bookBorrowedDate.Date.AddDays(3).ToString("dd/MM/yyyy") + "\n" +
								"Kitabın teslim kodu : " + item.bookId + "\n" +
								"-----------------------");
						}
						Console.ReadKey();
						break;
					default:
						PrintErrorMessage();
						break;
				}
			}

			database.library = library;
			database.booksBorrowed = booksBorrowed;
			UpdateDatabase(database);
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
				"Ödünç alınan kitapları görüntülemek için -> '7'\n" +
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
		private static void UpdateDatabase(Database database)
		{
			string jsonData = JsonConvert.SerializeObject(database,Formatting.Indented);
			File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Db", "ogrenciler.json"), jsonData);
		}
		private static Database GetDatabaseValues(string path)
		{
			if (File.Exists(path))
			{
				string json = File.ReadAllText(path);
				return JsonConvert.DeserializeObject<Database>(json);
			}
			else return new Database();
		}

	}
}

using LibraryApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryApplication.Program;

namespace LibraryApplication.Class
{
	public class Database
	{
        public Library library { get; set; }
		public List<BookBorrowed> booksBorrowed { get; set; }
	}
}

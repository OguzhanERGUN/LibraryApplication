using LibraryApplication.Interface;
using LibraryApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Class
{
	public class Library : LibraryRepository
	{
        public List<Book> Books { get { return booksdb; }}
        public int booksCount { get { return bookcountdb; } }
	}
}

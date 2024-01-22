using LibraryApplication.Class;
using LibraryApplication.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Repository
{
	public abstract class DatabaseRepository : IDatabase
	{
		public void UpdateDatabase()
		{
			throw new NotImplementedException();
		}
	}
}

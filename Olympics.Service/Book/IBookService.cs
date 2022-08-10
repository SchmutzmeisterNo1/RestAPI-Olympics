using Olympics.Models;
using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public interface IBookService
	{
		Book GetBook(int id);
		void CreateBook(CreateBookViewModel model, User user);
		void EditBook(Book book, User user);
		void DeleteBook(int id);
	}
}

using Microsoft.EntityFrameworkCore;
using Olympics.Models;
using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public class BookService : BaseService, IBookService
	{
		public BookService(DataContext context): base(context) { }

		public Book GetBook(int id)
		{
			return _context.Books
				.Where(x => x.Id == id)
				.Include(x => x.Pages)
				.FirstOrDefault();
		}

		public void CreateBook(CreateBookViewModel model, User user)
		{
			Book book = new Book()
			{
				CreationUserId = user.Id,
				CreationDate = DateTime.Now,
				LastUpdatedUserId = user.Id,
				LastUpdatedDate = DateTime.Now,
				Headline = model.Headline,
				ShelveId = model.ShelveId
			};

			base.Insert<Book>(book);
			base.SaveChanges();
		}

		public void EditBook(Book book, User user)
		{
			var model = _context.Books.Where(x => x.Id == book.Id).FirstOrDefault();
			model.LastUpdatedUserId = user.Id;
			model.LastUpdatedDate = DateTime.Now;
			model.Headline = model.Headline;

			base.SaveChanges();
		}

		public void DeleteBook(int id)
		{
			var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();
			_context.Books.Remove(book);
			base.SaveChanges();
		}
	}
}

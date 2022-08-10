using Olympics.Models;
using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public class PageService : BaseService, IPageService
	{
		public PageService(DataContext context): base(context) { }

		public void CreatePage(CreatePageViewModel model, User user)
		{
			Page page = new Page()
			{
				CreationUserId = user.Id,
				CreationDate = DateTime.Now,
				LastUpdatedUserId = user.Id,
				LastUpdatedDate = DateTime.Now,
				Value = model.Value,
				BookId = model.BookId
			};

			base.Insert<Page>(page);
			base.SaveChanges();
		}

		public void DeletePage(int id)
		{
			var page = _context.Pages.Where(x => x.Id == id).FirstOrDefault();
			_context.Pages.Remove(page);
			base.SaveChanges();
		}

		public void EditPage(Page page, User user)
		{
			var model = GetPage(page.Id);
			model.Value = page.Value;
			model.LastUpdatedUserId = user.Id;
			model.LastUpdatedDate = DateTime.Now;

			base.SaveChanges();
		}

		public Page GetPage(int id)
		{
			return _context.Pages.Where(x => x.Id == id).FirstOrDefault();
		}
	}
}

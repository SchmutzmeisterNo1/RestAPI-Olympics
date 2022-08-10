using Microsoft.EntityFrameworkCore;
using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public class ShelveService : BaseService, IShelveService
	{
		public ShelveService(DataContext context): base(context) { }

		public IEnumerable<Shelve> GetShelves()
		{
			return _context.Shelves.ToList();
		}

		public Shelve GetShelve(int id)
		{
			return _context.Shelves
				.Where(x => x.Id == id)
				.Include(x => x.Books)
				.FirstOrDefault();
		}

		public void CreateShelve(Shelve shelve, User user) 
		{
			Shelve model = new Shelve
			{
				CreationUserId = user.Id,
				CreationDate = DateTime.Now,
				LastUpdatedUserId = user.Id,
				LastUpdatedDate = DateTime.Now,
				Headline = shelve.Headline,
				Description = shelve.Description,
			};

			base.Insert<Shelve>(model);
			base.SaveChanges();
		}

		public void EditShelve(Shelve shelve, User user)
		{
			var model = _context.Shelves.Where(x => x.Id == shelve.Id).FirstOrDefault();
			model.LastUpdatedUserId = user.Id;
			model.LastUpdatedDate = DateTime.Now;
			model.Headline = shelve.Headline;
			model.Description = shelve.Description;
			base.SaveChanges();
		}

		public void DeleteShelve(int id)
		{
			var model = _context.Shelves.Where(x => x.Id == id).FirstOrDefault();
			_context.Shelves.Remove(model);
			base.SaveChanges();
		}
	}
}

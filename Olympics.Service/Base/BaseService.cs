using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public class BaseService
	{
		protected readonly DataContext _context;

		public BaseService(DataContext context)
		{
			_context = context;
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Insert<T>(T entity) where T : class
		{
			_context.Set<T>().Add(entity);
		}
	}
}

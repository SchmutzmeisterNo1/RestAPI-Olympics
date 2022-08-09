using Microsoft.EntityFrameworkCore;
using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public class UserService : BaseService, IUserService
	{
		public UserService(DataContext context): base(context) { }

		public User GetById(int id)
		{
			return _context.Users
				.Where(x => x.Id == id)
				.Include(x => x.Role)
				.ThenInclude(x => x.Privileges)
				.ThenInclude(x => x.Privilege)
				.FirstOrDefault();
		}

		public IEnumerable<User> GetAll()
		{
			return _context.Users
				.Include(x => x.Role)
				.ToList();
		}

		public void Edit(User editUser)
		{
			var user = _context.Users.Where(x => x.Id == editUser.Id).FirstOrDefault();
			user.Firstname = editUser.Firstname;
			user.Lastname = editUser.Lastname;
			base.SaveChanges();
		}

		public void Delete(int id)
		{
			var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
			_context.Users.Remove(user);
			base.SaveChanges();
		}
	}
}

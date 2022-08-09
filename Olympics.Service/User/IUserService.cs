using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public interface IUserService
	{
		User GetById(int id);
		IEnumerable<User> GetAll();
		void Edit(User editUser);
		void Delete(int id);
	}
}

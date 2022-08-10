using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public interface IShelveService
	{
		IEnumerable<Shelve> GetShelves();
		Shelve GetShelve(int id);
		void CreateShelve(Shelve shelve, User user);
		void EditShelve(Shelve shelve, User user);
		void DeleteShelve(int id);
	}
}

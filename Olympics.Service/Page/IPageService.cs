
using Olympics.Models;
using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public interface IPageService
	{
		Page GetPage(int id);
		void EditPage(Page page, User user);
		void DeletePage(int id);
		void CreatePage(CreatePageViewModel model, User user);
	}
}

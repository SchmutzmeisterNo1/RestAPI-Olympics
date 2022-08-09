using Olympics.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public interface IAuthService
	{
		AuthenticateResponse Login(string email, string password);
		void Register(RegisterViewModel model);
		bool CheckEmail(string email);
	}
}

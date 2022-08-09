using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Models.Models
{
	public class AuthenticateResponse
	{
		public string Token { get; set; }

		public User User { get; set; }
	}
}

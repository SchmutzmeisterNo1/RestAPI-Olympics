using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public interface IJwtService
	{
		string GenerateToken(User user);
		int? ValidateToken(string token);
	}
}

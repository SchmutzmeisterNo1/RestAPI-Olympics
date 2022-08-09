using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Models.Entity
{
	public class User
	{
		public int Id { get; set; }

		public string Firstname { get; set; }

		public string Lastname { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public int RoleId { get; set; }

		[ForeignKey("RoleId")]
		public virtual Role Role { get; set; }

		public string Fullname()
		{
			return Firstname + " " + Lastname;
		}
	}
}

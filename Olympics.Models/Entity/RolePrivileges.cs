using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Models.Entity
{
	public class RolePrivilege
	{
		public int Id { get; set; }

		public int RoleId { get; set; }

		[ForeignKey("RoleId")]
		public virtual Role Role { get; set; }

		public int PrivilegeId { get; set; }

		[ForeignKey("PrivilegeId")]
		public virtual Privilege Privilege { get; set; }
	}
}

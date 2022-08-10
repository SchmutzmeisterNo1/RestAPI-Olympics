using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Models
{
	public class UpdateRoleViewModel
	{
		public int UserId { get; set; }
		public RoleTypeEnum RoleType { get; set; }
	}
}

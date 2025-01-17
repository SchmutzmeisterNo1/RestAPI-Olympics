﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Models.Entity
{
	public enum RoleTypeEnum
	{
		User = 1,
		Moderator = 2,
		Administrator = 3
	}

	public class Role
	{
		public int Id { get; set; }

		public RoleTypeEnum RoleType { get; set; }

		public virtual IEnumerable<RolePrivilege> Privileges { get; set; }
	}
}

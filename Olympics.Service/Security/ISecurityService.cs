using Olympics.Models;
using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public interface ISecurityService
	{
		bool IsInRole(User user, RoleTypeEnum roleType);
		bool IsInAnyRole(User user, IEnumerable<RoleTypeEnum> roleTypes);
		bool HasPrivilege(User user, string privilege);
		IEnumerable<Role> GetRoles();
		Role GetRole(int id);
		IEnumerable<Privilege> GetPrivileges();
		Privilege GetPrivilege(int id);
		void UpdateRole(UpdateRoleViewModel model);
	}
}

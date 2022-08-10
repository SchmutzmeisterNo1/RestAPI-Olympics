using Microsoft.EntityFrameworkCore;
using Olympics.Models;
using Olympics.Models.Entity;
using Olympics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public class SecurityService : BaseService, ISecurityService
	{
		private readonly IUserService _userService;

		public SecurityService(DataContext context, IUserService userService): base (context) 
		{
			_userService = userService;
		}

		public bool IsInRole(User user, RoleTypeEnum roleType)
		{
			return user.Role.RoleType == roleType;
		}

		public bool IsInAnyRole(User user, IEnumerable<RoleTypeEnum> roleTypes)
		{
			return roleTypes.Any(x => x == user.Role.RoleType);
		}

		public bool HasPrivilege(User user, string privilege)
		{
			return user.Role.Privileges.Any(x => x.Privilege.Name == privilege);
		}

		public IEnumerable<Role> GetRoles()
		{
			return _context.Roles.ToList();
		}

		public Role GetRole(int id)
		{
			return _context.Roles
				.Where(x => x.Id == id)
				.Include(x => x.Privileges)
				.ThenInclude(x => x.Privilege)
				.FirstOrDefault();
		}

		public IEnumerable<Privilege> GetPrivileges()
		{
			return _context.Privileges.ToList();
		}

		public Privilege GetPrivilege(int id)
		{
			return _context.Privileges
				.Where(x => x.Id == id)
				.Include(x => x.Roles)
				.ThenInclude(x => x.Role)
				.FirstOrDefault();
		}

		public void UpdateRole(UpdateRoleViewModel model)
		{
			var user = _userService.GetById(model.UserId);
			user.Role.RoleType = model.RoleType;
			base.SaveChanges();
		}
	}
}

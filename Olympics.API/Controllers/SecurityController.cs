using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olympics.API.Helper;
using Olympics.API.Resources;
using Olympics.Models.Entity;
using Olympics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class SecurityController : BaseController
	{
		private readonly ISecurityService _securityService;
		private readonly IUserService _userService;

		public SecurityController(ISecurityService securityService, IUserService userService)
		{
			_securityService = securityService;
			_userService = userService;
		}

		[HttpGet]
		[Route("getRoles")]
		public IEnumerable<Role> GetRoles()
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInRole(user, RoleTypeEnum.Administrator))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Role.View"))
				throw new OlympException(Strings.Exception_Privileges);

			return _securityService.GetRoles();
		}

		[HttpGet]
		[Route("getRole/{id}")]
		public Role GetRole(int id)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInRole(user, RoleTypeEnum.Administrator))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Role.View"))
				throw new OlympException(Strings.Exception_Privileges);

			return _securityService.GetRole(id);
		}

		[HttpGet]
		[Route("getPrivileges")]
		public IEnumerable<Privilege> GetPrivileges()
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInRole(user, RoleTypeEnum.Administrator))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Privilege.View"))
				throw new OlympException(Strings.Exception_Privileges);

			return _securityService.GetPrivileges();
		}

		[HttpGet]
		[Route("getPrivilege/{id}")]
		public Privilege GetPrivilege(int id)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInRole(user, RoleTypeEnum.Administrator))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Privilege.View"))
				throw new OlympException(Strings.Exception_Privileges);

			return _securityService.GetPrivilege(id);
		}

		[HttpPost]
		[Route("updateRolePrivileges")]
		public IActionResult UpdateRolePrivileges()
		{
			return Ok();
		}
	}
}

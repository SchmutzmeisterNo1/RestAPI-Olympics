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
	[Authorize]
	[ApiController]
	public class UserController : BaseController
	{
		private readonly IUserService _userService;
		private readonly ISecurityService _securityService;

		public UserController(IUserService userService, ISecurityService securityService)
		{
			_userService = userService;
			_securityService = securityService;
		}

		[HttpGet]
		[Route("all")]
		public IEnumerable<User> GetAll()
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInRole(user, RoleTypeEnum.Administrator))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "User.View"))
				throw new OlympException(Strings.Exception_Privileges);

			var persons = _userService.GetAll();

			if (persons == null)
				throw new OlympException(Strings.Exception_NoPersonsFound);

			return persons;
		}

		[HttpGet]
		[Route("getById/{id}")]
		public User GetById(int id)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInRole(user, RoleTypeEnum.Administrator))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "User.View"))
				throw new OlympException(Strings.Exception_Privileges);

			var userById = _userService.GetById(id);

			if (userById == null)
				throw new OlympException(Strings.Exception_NoPersonsFound);
			 
			return userById;
		}

		[HttpPost]
		[Route("edit")]
		public IActionResult Edit(User model)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (user.Id != model.Id) { 
				if (!_securityService.IsInRole(user, RoleTypeEnum.Administrator))
					throw new OlympException(Strings.Exception_Rights);
				if (!_securityService.HasPrivilege(user, "User.Edit"))
					throw new OlympException(Strings.Exception_Privileges);
			}

			_userService.Edit(model);

			return Ok();
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public IActionResult Delete(int id)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInRole(user, RoleTypeEnum.Administrator))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "User.Delete"))
				throw new OlympException(Strings.Exception_Privileges);

			_userService.Delete(id);

			return Ok();
		}
	}
}

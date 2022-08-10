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
	public class ShelveController : BaseController
	{
		private readonly ISecurityService _securityService;
		private readonly IShelveService _shelveService;

		public ShelveController(ISecurityService securityService, IShelveService shelveService)
		{
			_securityService = securityService;
			_shelveService = shelveService;
		}

		[HttpGet]
		[Route("getShelves")]
		public IEnumerable<Shelve> GetShelves()
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.HasPrivilege(user, "Shelve.View"))
				throw new OlympException(Strings.Exception_Privileges);

			return _shelveService.GetShelves();
		}

		[HttpGet]
		[Route("getShelve/{id}")]
		public Shelve GetShelve(int id)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.HasPrivilege(user, "Shelve.View"))
				throw new OlympException(Strings.Exception_Privileges);

			return _shelveService.GetShelve(id);
		}

		[HttpPost]
		[Route("createShelve")]
		public IActionResult CreateShelve(Shelve shelve)
		{
			var user = CurrentUser;
			List<RoleTypeEnum> roleTypes = new List<RoleTypeEnum>();
			roleTypes.Add(RoleTypeEnum.Administrator);
			roleTypes.Add(RoleTypeEnum.Moderator);

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInAnyRole(user, roleTypes))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Shelve.Create"))
				throw new OlympException(Strings.Exception_Privileges);

			_shelveService.CreateShelve(shelve, user);

			return Ok();
		}

		[HttpPost]
		[Route("editShelve")]
		public IActionResult EditShelve(Shelve shelve)
		{
			var user = CurrentUser;
			List<RoleTypeEnum> roleTypes = new List<RoleTypeEnum>();
			roleTypes.Add(RoleTypeEnum.Administrator);
			roleTypes.Add(RoleTypeEnum.Moderator);
			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInAnyRole(user, roleTypes))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Shelve.Edit"))
				throw new OlympException(Strings.Exception_Privileges);

			_shelveService.EditShelve(shelve, user);

			return Ok();
		}

		[HttpDelete]
		[Route("deleteShelve/{id}")]
		public IActionResult DeleteShelve(int id)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInRole(user, RoleTypeEnum.Administrator))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Shelve.Delete"))
				throw new OlympException(Strings.Exception_Privileges);

			_shelveService.DeleteShelve(id);

			return Ok();
		}
	}
}

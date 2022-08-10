using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olympics.API.Helper;
using Olympics.API.Resources;
using Olympics.Models;
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
	public class PageController : BaseController
	{
		private readonly ISecurityService _securityService;
		private readonly IPageService _pageService;

		public PageController(ISecurityService securityService, IPageService pageService)
		{
			_securityService = securityService;
			_pageService = pageService;
		}

		[HttpGet]
		[Route("getPage")]
		public Page GetPage(int id)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.HasPrivilege(user, "Page.View"))
				throw new OlympException(Strings.Exception_Privileges);

			return _pageService.GetPage(id);
		}

		[HttpPost]
		[Route("createPage")]
		public IActionResult CreatePage(CreatePageViewModel model)
		{
			var user = CurrentUser;
			List<RoleTypeEnum> roleTypes = new List<RoleTypeEnum>();
			roleTypes.Add(RoleTypeEnum.Administrator);
			roleTypes.Add(RoleTypeEnum.Moderator);

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInAnyRole(user, roleTypes))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Page.Create"))
				throw new OlympException(Strings.Exception_Privileges);

			_pageService.CreatePage(model, user);

			return Ok();
		}

		[HttpPost]
		[Route("editBook")]
		public IActionResult EditPage(Page page)
		{
			var user = CurrentUser;
			List<RoleTypeEnum> roleTypes = new List<RoleTypeEnum>();
			roleTypes.Add(RoleTypeEnum.Administrator);
			roleTypes.Add(RoleTypeEnum.Moderator);

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInAnyRole(user, roleTypes))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Page.Edit"))
				throw new OlympException(Strings.Exception_Privileges);

			_pageService.EditPage(page, user);

			return Ok();
		}

		[HttpDelete]
		[Route("deleteBook/{id}")]
		public IActionResult DeletePage(int id)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInRole(user, RoleTypeEnum.Administrator))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Page.Delete"))
				throw new OlympException(Strings.Exception_Privileges);

			_pageService.DeletePage(id);

			return Ok();
		}
	}
}

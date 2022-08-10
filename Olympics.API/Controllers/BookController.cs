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
	public class BookController : BaseController
	{
		private readonly ISecurityService _securityService;
		private readonly IBookService _bookService;

		public BookController(ISecurityService securityService, IBookService bookService)
		{
			_securityService = securityService;
			_bookService = bookService;
		}

		[HttpGet]
		[Route("getBook")]
		public Book GetBook(int id)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.HasPrivilege(user, "Book.View"))
				throw new OlympException(Strings.Exception_Privileges);

			return _bookService.GetBook(id);
		}

		[HttpPost]
		[Route("createBook")]
		public IActionResult CreateBook(CreateBookViewModel model)
		{
			var user = CurrentUser;
			List<RoleTypeEnum> roleTypes = new List<RoleTypeEnum>();
			roleTypes.Add(RoleTypeEnum.Administrator);
			roleTypes.Add(RoleTypeEnum.Moderator);

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInAnyRole(user, roleTypes))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Book.Create"))
				throw new OlympException(Strings.Exception_Privileges);

			_bookService.CreateBook(model, user);

			return Ok();
		}

		[HttpPost]
		[Route("editBook")]
		public IActionResult EditBook(Book book)
		{
			var user = CurrentUser;
			List<RoleTypeEnum> roleTypes = new List<RoleTypeEnum>();
			roleTypes.Add(RoleTypeEnum.Administrator);
			roleTypes.Add(RoleTypeEnum.Moderator);

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInAnyRole(user, roleTypes))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Book.Edit"))
				throw new OlympException(Strings.Exception_Privileges);

			_bookService.EditBook(book, user);

			return Ok();
		}

		[HttpDelete]
		[Route("deleteBook/{id}")]
		public IActionResult DeleteBook(int id)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.IsInRole(user, RoleTypeEnum.Administrator))
				throw new OlympException(Strings.Exception_Rights);
			if (!_securityService.HasPrivilege(user, "Book.Delete"))
				throw new OlympException(Strings.Exception_Privileges);

			_bookService.DeleteBook(id);

			return Ok();
		}
	}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olympics.API.Helper;
using Olympics.Models.Models;
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
	public class AuthController : BaseController
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService, IUserService userService)
		{
			_authService = authService;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("register")]
		public IActionResult Register(RegisterViewModel model)
		{
			if (model.Password != model.RePassword)
				throw new OlympException("Passwords do not match");

			if (_authService.CheckEmail(model.Email))
				throw new OlympException("Email already exists");

			_authService.Register(model);

			return Ok();
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("login")]
		public AuthenticateResponse Login(LoginViewModel model)
		{
			var data = _authService.Login(model.Email, model.Password);

			if (data == null)
				throw new OlympException("User inputs incorrect");

			return data;
		}
	}
}

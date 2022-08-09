using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olympics.API.Helper;
using Olympics.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.API.Controllers
{
	[AllowAnonymous]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class ErrorController : ControllerBase
	{
		[Route("error")]
		public ErrorResponse Error()
		{
			var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
			var exception = context.Error;
			var code = 500;

			if (exception is OlympException) code = 401;

			Response.StatusCode = code;

			return new ErrorResponse(exception);
		}
	}
}

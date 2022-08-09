using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olympics.Models.Entity;
using Olympics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.API.Controllers
{
	public class BaseController : ControllerBase
	{
		protected User CurrentUser
		{
            get
            {
                if (HttpContext != null && HttpContext.Items["User"] != null)
                {
                    var user = HttpContext.Items["User"] as User;
                    var dbContext = (DataContext)HttpContext.RequestServices.GetService(typeof(DataContext));
                    dbContext.User = user;
                    return HttpContext.Items["User"] as User;
                };
                return null;
            }
        }
    }
}

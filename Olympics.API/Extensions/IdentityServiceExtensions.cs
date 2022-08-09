using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Olympics.Models.Entity;
using Olympics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.API.Extensions
{
	public static class IdentityServiceExtensions
	{
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetSection("AppSettings").GetSection("Secret").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context => {
                            var userService = context.HttpContext.RequestServices.GetService<IUserService>();
                            ClaimsPrincipal userPrincipal = context.Principal;
                            var userId = context.Principal.Claims.FirstOrDefault(x => x.Type == "Id").Value;
                            var dataContext = context.HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
                            var user = userService.GetById(Convert.ToInt32(userId));
                            dataContext.User = user;
                            context.HttpContext.Items["User"] = user;
                        }
                    };
                });
            return services;
        }

    }
}

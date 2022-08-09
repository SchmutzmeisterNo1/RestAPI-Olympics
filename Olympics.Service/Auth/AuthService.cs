using Microsoft.EntityFrameworkCore;
using Olympics.Models.Entity;
using Olympics.Models.Models;
using Olympics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public class AuthService : BaseService, IAuthService
	{
        private readonly IJwtService _jwtService;

		public AuthService(DataContext context, IJwtService jwtService): base(context) 
        {
            _jwtService = jwtService;
        }

		public AuthenticateResponse Login(string email, string password)
		{
            var f_password = SHA256(password);
            var user = _context.Users.Where(x => x.Email == email && x.Password == f_password).FirstOrDefault();

            if (user == null)
                return null;

            var token = _jwtService.GenerateToken(user);

            if (token == null)
                return null;

            _context.User = user;

            return new AuthenticateResponse()
            {
                Token = token,
                User = user
            };
		}

        public void Register(RegisterViewModel model)
		{
            User user = new User()
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                Password = SHA256(model.Password),
                RoleId = (int)RoleTypeEnum.User
            };

            base.Insert<User>(user);
            base.SaveChanges();
		}

        public bool CheckEmail(string email)
		{
            return _context.Users.Any(x => x.Email == email);
		}

        private string SHA256(string value)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(value));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Models.Models
{
	public class RegisterViewModel
	{
		public string Firstname { get; set; }

		public string Lastname { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string RePassword { get; set; }
	}
}

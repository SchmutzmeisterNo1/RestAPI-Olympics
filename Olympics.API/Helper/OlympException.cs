using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.API.Helper
{
	public class OlympException : Exception
	{
		public string Detail { get; set; }

		public OlympException(string message): base(message) { }

		public OlympException(string message, Exception inner): base(message, inner) { }

		public OlympException(string message, string detail): base(message)
		{
			Detail = detail;
		}
	}
}

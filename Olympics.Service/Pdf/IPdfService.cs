using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public interface IPdfService
	{
		byte[] ConvertHtmlToPdf(string html);
	}
}

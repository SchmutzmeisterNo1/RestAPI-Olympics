using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public class PdfService : BaseService, IPdfService
	{
		public PdfService(DataContext context): base(context) { }

		public byte[] ConvertHtmlToPdf(string html)
		{
			var htmlToPdf = new HtmlToPDFCore.HtmlToPDF();
			return htmlToPdf.ReturnPDF(html);
		}
	}
}

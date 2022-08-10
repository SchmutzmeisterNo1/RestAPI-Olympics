using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olympics.API.Helper;
using Olympics.API.Resources;
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
	public class PdfController : BaseController
	{
		private readonly ISecurityService _securityService;
		private readonly IPdfService _pdfService;
		private readonly IPageService _pageService;

		public PdfController(ISecurityService securityService, IPdfService pdfService, IPageService pageService)
		{
			_securityService = securityService;
			_pdfService = pdfService;
			_pageService = pageService;
		}

		[HttpGet]
		[Route("pageAsPdf/{id}")]
		public IActionResult PageAsPdf(int id)
		{
			var user = CurrentUser;

			if (user == null)
				throw new OlympException(Strings.Exception_NoUser);
			if (!_securityService.HasPrivilege(user, "Pdf.Download"))
				throw new OlympException(Strings.Exception_Privileges);

			var page = _pageService.GetPage(id);
			var bytes = _pdfService.ConvertHtmlToPdf(page.Value);

			return File(bytes, "application/pdf", page.Book.Headline + ".pdf");
		}
	}
}

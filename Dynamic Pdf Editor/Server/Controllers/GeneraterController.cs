using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Dynamic_Pdf_Editor.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GeneraterController : ControllerBase
	{
		[HttpPost]
		public Dynamic_Pdf_Editor.Shared.Document GeneratePdf(Dynamic_Pdf_Editor.Shared.Document document)
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			BaseFont STF_Helvetica_Turkish = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "CP1254", BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, iTextSharp.text.Font.NORMAL);

			using (MemoryStream ms = new MemoryStream())
			{
				using (PdfReader reader = new PdfReader(document.Data))
				{
					using (PdfStamper stamper = new PdfStamper(reader, ms))
					{
						PdfContentByte cb = stamper.GetOverContent(document.PageNumber);
						BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
						cb.BeginText();
						cb.SetFontAndSize(bf, 12);
						cb.SetTextMatrix(0, 0);
						ColumnText.ShowTextAligned(cb, PdfContentByte.ALIGN_LEFT, new Phrase(document.TextValue, fontNormal), document.XCoordinate, document.YCoordinate, 0);
						cb.EndText();
					}
				}
				document.Data = ms.ToArray();
			}

			return document;
		}

		public IActionResult Index()
		{
			return Ok("Burda");
		}
	}
}

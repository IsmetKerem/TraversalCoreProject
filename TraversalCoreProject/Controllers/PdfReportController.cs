using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;


namespace TraversalCoreProject.Controllers;

public class PdfReportController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult StaticPdfReport()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
        var stream = new FileStream(path, FileMode.Create);
        Document document = new Document(PageSize.A4);
        PdfWriter.GetInstance(document,stream);
        
        document.Open();
        Paragraph paragraph = new Paragraph("Traversal Rezervasyon PDF Raporu");
        document.Add(paragraph);
        document.Close();
        return File("/pdfreports/dosya1.pdf","application/pdf","dosya1.pdf");


    }

    public IActionResult StaticCustomerReport()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya2.pdf");
        var stream = new FileStream(path, FileMode.Create);
        Document document = new Document(PageSize.A4);
        PdfWriter.GetInstance(document,stream);
        
        document.Open();
        PdfPTable pdfPTable = new PdfPTable(3);
        pdfPTable.AddCell("Misafir Adı");
        pdfPTable.AddCell("Misafir SoyAdı");
        pdfPTable.AddCell("Misafir TC");
        
        pdfPTable.AddCell("İsmet Kerem");
        pdfPTable.AddCell("Eren");
        pdfPTable.AddCell("111111111111");
        
        pdfPTable.AddCell("Kerem");
        pdfPTable.AddCell("Yıldırım");
        pdfPTable.AddCell("1113456711111");
        
        pdfPTable.AddCell("Mahmut");
        pdfPTable.AddCell("Tuncer");
        pdfPTable.AddCell("987111111111");

        document.Add(pdfPTable);
        document.Close();
        return File("/pdfreports/dosya2.pdf","application/pdf","dosya2.pdf");
    }
}
using PdfCreater.Models;
using EO.Pdf;
using System.Net;
using System.Drawing;

namespace PdfCreater.Services
{
    public static class PdfService
    {
        
        public static void CreatepdfContentPdf(PdfContent pdfContent)
        {
            var companyName = pdfContent.CompanyName;

            var additionalData = new
            {
                createDate = DateTime.Now.ToString("dd MMMM yyyy dddd"),
                companyName = companyName
            };
            var filePath = Path.Combine("Content", "Templates","PdfTemplate.html");
            var pdftemplate = FormatTemplate(filePath , pdfContent);
            pdftemplate = TemplateReplace(pdftemplate,additionalData);

            //PdfDocument doc = new ();
            //HtmlToPdf.ConvertUrl(pdftemplate, doc);
            //HtmlToPdf.ConvertUrl(pdftemplate, doc);

            //doc.Save(filePath);

            CreatePdfFromHtml(pdftemplate, "");
        }

        public static string FormatTemplate(string templatepath, object obj)
        {
            var template = System.IO.File.ReadAllText(templatepath);
            return TemplateReplace(template, obj);


        }

        public static string TemplateReplace(this string input, object obj)
        {
            var result = input;

            foreach (var prop in obj.GetType().GetProperties())
            {
                var value = prop.GetValue(obj, null);

                result = result.Replace("{" + prop.Name + "}", value?.ToString() ?? "");
            }

            return result;
        }

        public static HtmlToPdfResult CreatePdfFromHtml(string html, string id = "")
        {
            if (string.IsNullOrEmpty(id)) id = Guid.NewGuid().ToString();

            var root = Path.Combine("App_Data", "Pdfs");

            if (!Directory.Exists(root)) Directory.CreateDirectory(root);

            //var link = "google.com";
            //var url = new Uri(link);
            //var client = new WebClient();
            //var html1 = client.DownloadString(url);

            return HtmlToPdf.ConvertHtml(html, Path.Combine(root, id + ".pdf"));
        }

    }
}

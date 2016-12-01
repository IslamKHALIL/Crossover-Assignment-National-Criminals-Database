using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using IronPdf;
using NationalCriminalsDB.Service.ViewModels;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace NationalCriminalsDB.Service.Helpers
{
    public interface IPDFCreator
    {
        FileInfo CreatePdf(IResultsViewModel model);
    }

    internal class PDFCreator : IPDFCreator
    {
        #region Templates
        static class HTMLTemplates
        {
            public static readonly string PageHtml = "<p>*FullName*</p><table><tbody><tr><td colspan=\"2\" width=\"779\"><p><strong>Personal details:</strong></p></td></tr><tr><td width=\"390\"><img src=\"*Photo*\" alt=\"\" /></td><td width=\"390\"><table><tbody><tr><td width=\"144\"><p><strong>Full name:</strong></p></td><td width=\"226\"><p>*FullName*</p></td></tr><tr><td width=\"144\"><p><strong>Address:</strong></p></td><td width=\"226\"><p>*Address*</p></td></tr><tr><td width=\"144\"><p><strong>Nationality:</strong></p></td><td width=\"226\"><p>*Nationality*</p></td></tr><tr><td width=\"144\"><p><strong>Date of birth:</strong></p></td><td width=\"226\"><p>*DateOfBirth*</p></td></tr><tr><td width=\"144\"><p><strong>Age:</strong></p></td><td width=\"226\"><p>*Age*</p></td></tr><tr><td width=\"144\"><p><strong>Height:</strong></p></td><td width=\"226\"><p>*Height*</p></td></tr><tr><td width=\"144\"><p><strong>Weight:</strong></p></td><td width=\"226\"><p>*Weight*</p></td></tr><tr><td width=\"144\"><p><strong>Sex:</strong></p></td><td width=\"226\"><p>*Sex*</p></td></tr></tbody></table></td></tr><tr><td colspan=\"2\" width=\"779\"><p><strong>Criminal history:</strong></p></td></tr><tr><td colspan=\"2\" width=\"779\">*Crimes*</td></tr></tbody></table>";

            public static readonly string CrimeHtml = "<p>&nbsp;</p><table><tbody><tr><td width=\"142\"><p><strong>Time:</strong></p></td><td width=\"757\"><p>*Time*</p></td></tr><tr><td width=\"142\"><p><strong>Location:</strong></p></td><td width=\"757\"><p>*Location*</p></td></tr><tr><td width=\"142\"><p><strong>Type:</strong></p></td><td width=\"757\"><p>*Type*</p></td></tr><tr><td width=\"142\"><p><strong>Victim:</strong></p></td><td width=\"757\"><p>*Victim*</p></td></tr><tr><td width=\"142\"><p><strong>Accomplices:</strong></p></td><td width=\"757\"><p>*Accomplices*</p></td></tr><tr><td width=\"142\"><p><strong>Description:</strong></p></td><td width=\"757\"><p>*Description*</p></td></tr></tbody></table>";
        }
        #endregion

        private string ModelToHTML(IResultsViewModel model)
        {
            string crimesHTML = "None";
            if (model.CriminalHistory != null && model.CriminalHistory.Count() > 0)
            {
                var builder = new StringBuilder();
                foreach (var crime in model.CriminalHistory)
                {
                    builder.Append(HTMLTemplates.CrimeHtml);
                    var prop = crime.GetType().GetProperties();
                    foreach (var property in prop)
                        builder.Replace($"*{property.Name}*", property.GetValue(crime).ToString());
                }
                crimesHTML = builder.ToString();
            }
            var pageBuilder = new StringBuilder();
            pageBuilder.Append(HTMLTemplates.PageHtml);
            var modelProp = model.GetType().GetProperties();
            foreach (var property in modelProp.Where(p => p.Name != "CriminalHistory"))
                pageBuilder.Replace($"*{property.Name}*", property.GetValue(model).ToString());

            pageBuilder.Replace("*Crimes*", crimesHTML);
            var page = pageBuilder.ToString();
            return page;
        }

        public FileInfo CreatePdf(IResultsViewModel model)
        {
            if (model == null || (string.IsNullOrEmpty(model.FullName) && string.IsNullOrEmpty(model.Photo) && model.Height <= 0))
                return null;

            string file = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, $@"App_Data\{model.FullName ?? "unkown"}.pdf");
            string page = ModelToHTML(model);
            if (!string.IsNullOrEmpty(page))
            {
                var htmlToPdf = new HtmlToPdf(new PdfPrintOptions() { PaperSize = PdfPrintOptions.PdfPaperSize.A4 });
                PdfResource pdf = htmlToPdf.RenderHtmlAsPdf(page);
                if (File.Exists(file))
                {
                    for (int i = 1; ; ++i)
                    {
                        var s = file.Insert(file.Length - 4, $" ({i.ToString()})");
                        if (File.Exists(s))
                            continue;
                        else
                        {
                            file = s;
                            break;
                        }
                    }
                }
                pdf.SaveAs(file);
            }
            var fileinfo = new FileInfo(file);
            return fileinfo.Exists ? fileinfo : null;
        }
    }
}

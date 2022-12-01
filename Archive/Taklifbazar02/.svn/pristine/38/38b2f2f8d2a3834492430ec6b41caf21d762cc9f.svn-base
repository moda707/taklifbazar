using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Converter;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace PDFConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string txtName in Directory.GetFiles(@"D:\Files", "*.*"))
            {
                   
                if (txtName.Substring(txtName.LastIndexOf(".")) == ".jpeg" ||
                    txtName.Substring(txtName.LastIndexOf(".")) == ".jpg" ||
                    txtName.Substring(txtName.LastIndexOf(".")) == ".bmp" ||
                    txtName.Substring(txtName.LastIndexOf(".")) == ".tif" ||
                    txtName.Substring(txtName.LastIndexOf(".")) == ".tiff" ||
                    txtName.Substring(txtName.LastIndexOf(".")) == ".png")
                {

                    PdfDocument doc = new PdfDocument();
                    doc.Pages.Add(new PdfPage());
                    XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
                    XImage img = XImage.FromFile(txtName);
                    xgr.DrawImage(img, 0, 0);
                    doc.Save(txtName.Substring(0, txtName.LastIndexOf(".")) + ".pdf");
                    doc.Close();
                }
                else
                {
                    var service = new ConverterServices();
                    service.convert(txtName, txtName + ".pdf");
                }
            }
          
        }
    }
}

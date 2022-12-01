using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDFConvertor.DocumentConverter
{
    public class DocumentConverterFactory : IDocumentConverterFactory
    {
        public IConverter getConverter(ConversionType convType)
        {
            IConverter converter = null;
            switch (convType)
            {
                case ConversionType.Doc2Pdf:
                    converter = new ConvDoc2PdfWithMsOffice();
                    break;
                case ConversionType.Pdf2Img:
                case ConversionType.Img2Img:
                default:
                    break;

            }

            return converter;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDFConvertor.DocumentConverter
{
    public interface IConverter
    {
        short convert(String sourcePath, String targetPath, ContentType sourceType);
              
    }

    public interface IDocumentConverterFactory
    {
         IConverter getConverter(ConversionType convType);
    }
}

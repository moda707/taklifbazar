using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDFConvertor.DocumentConverter;

namespace Converter
{
    public class ConverterServices
    {
        public short convert(string inputFile, string outputFile)
        {
            short conversionResult = -1;

            ContentType fileExtn = ContentType.UNKNOWN;
            conversionResult = Util.getFileExtension(inputFile, out fileExtn);
            if (conversionResult == 0)
            {
                IDocumentConverterFactory factory = new DocumentConverterFactory();
                
                
                
                
                IConverter converter = factory.getConverter(ConversionType.Doc2Pdf);
                if (converter != null)
                    conversionResult = converter.convert(inputFile, outputFile, fileExtn);
            }
            return conversionResult;

        }

    }
}

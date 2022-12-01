
using System;
using System.Diagnostics;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Visio = Microsoft.Office.Interop.Visio;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

namespace PDFConvertor.DocumentConverter
{
    public class ConvDoc2PdfWithMsOffice : IConverter
    {


        /// <summary>
        /// Convert MSOffice file to PDF by calling required method
        /// </summary>
        /// <param name="sourcePath">MSOffice file path</param>
        /// <param name="targetPath">Target PDF path</param>
        /// <param name="sourceType">MSOffice file type</param>
        /// <returns>error code : 0(sucess)/ -1 or errorcode (unknown error or failure)</returns>
        public short convert(String sourcePath, String targetPath, ContentType sourceType)
        {
            Console.WriteLine("Class: " + GetType() + " Method: " + MethodBase.GetCurrentMethod().Name + " Started ");
            short convDoc2PdfWithMsOfficeResult = 0;
            if (sourceType == ContentType.DOC || sourceType == ContentType.DOCX || sourceType == ContentType.TXT || sourceType == ContentType.RTF || sourceType == ContentType.XML)
            {
                convDoc2PdfWithMsOfficeResult = word2Pdf((Object)sourcePath, (Object)targetPath);

            }
            else if (sourceType == ContentType.XLS || sourceType == ContentType.XLSX || sourceType == ContentType.CSV)
            {
                convDoc2PdfWithMsOfficeResult = excel2Pdf(sourcePath, targetPath);

            }
            else if (sourceType == ContentType.PPT || sourceType == ContentType.PPTX)
            {
                convDoc2PdfWithMsOfficeResult = powerPoint2Pdf((Object)sourcePath, (Object)targetPath);
            }
            else if (sourceType == ContentType.VSD || sourceType == ContentType.VDX)
            {
                convDoc2PdfWithMsOfficeResult = visio2Pdf(sourcePath, targetPath);
            }
            else convDoc2PdfWithMsOfficeResult = -1;
            Console.WriteLine("Class: " + GetType() + " Method: " + MethodBase.GetCurrentMethod().Name + " Ended ");



            return convDoc2PdfWithMsOfficeResult;
        }

        /// <summary>
        /// Convert Word file to PDF by calling required method
        /// </summary>
        /// <param name="originalDocPath">file path</param>
        /// <param name="pdfPath">Target PDF path</param>
        /// <returns>error code : 0(sucess)/ -1 or errorcode (unknown error or failure)</returns>
        public short word2Pdf(object originalDocPath, object pdfPath)
        {
            Console.WriteLine("Class: " + GetType() + " Method: " + MethodBase.GetCurrentMethod().Name + " Started ");

            short convertWord2PdfResult = -1;

            Microsoft.Office.Interop.Word.Application msWordDoc = null;
            Microsoft.Office.Interop.Word.Document doc = null;
            // C# doesn't have optional arguments so we'll need a dummy value 
            object oMissing = System.Reflection.Missing.Value;

            try
            {
                //start MS word application
                msWordDoc = new Microsoft.Office.Interop.Word.Application
                {
                    Visible = false,
                    ScreenUpdating = false
                };


                //Open Document
                doc = msWordDoc.Documents.Open(ref originalDocPath, ref oMissing,
                                               ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                               ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                               ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                if (doc != null)
                {
                    doc.Activate();

                    // save Document as PDF
                    object fileFormat = WdSaveFormat.wdFormatPDF;
                    doc.SaveAs(ref pdfPath,
                               ref fileFormat, ref oMissing, ref oMissing,
                               ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                               ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                               ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    convertWord2PdfResult = 0;
                }
                else
                {
                    Console.WriteLine("Error occured for conversion of office Word to PDF");
                    convertWord2PdfResult = 504;
                }
            }
            catch (Exception exWord2Pdf)
            {
                Console.WriteLine("Error occured for conversion of office Word to PDF, Exception: ", exWord2Pdf);
                convertWord2PdfResult = 504;
            }
            finally
            {
                // Close and release the Document object.
                if (doc != null)
                {
                    object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
                    doc.Close(ref saveChanges, ref oMissing, ref oMissing);
                    Util.releaseObject(doc);
                }

                // Quit Word and release the ApplicationClass object.
                ((_Application)msWordDoc).Quit(ref oMissing, ref oMissing, ref oMissing);
                Util.releaseObject(msWordDoc);
                msWordDoc = null;
            }
            Console.WriteLine("Class: " + GetType() + " Method: " + MethodBase.GetCurrentMethod().Name + " Ended ");
            return convertWord2PdfResult;
        }

        /// <summary>
        ///  Convert  excel file to PDF by calling required method
        /// </summary>
        /// <param name="originalXlsPath">file path</param>
        /// <param name="pdfPath">Target PDF path</param>
        /// <returns>error code : 0(sucess)/ -1 or errorcode (unknown error or failure)</returns>
        public short excel2Pdf(string originalXlsPath, string pdfPath)
        {
            Console.WriteLine("Class: " + GetType() + " Method: " + MethodBase.GetCurrentMethod().Name + " Started ");

            short convertExcel2PdfResult = -1;

            // Create COM Objects
            Microsoft.Office.Interop.Excel.Application excelApplication = null;
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = null;
            object unknownType = Type.Missing;
            // Create new instance of Excel
            try
            {
                //open excel application
                excelApplication = new Microsoft.Office.Interop.Excel.Application
                    {
                        ScreenUpdating = false,
                        DisplayAlerts = false
                    };

                //open excel sheet
                if (excelApplication != null)
                    excelWorkbook = excelApplication.Workbooks.Open(originalXlsPath, unknownType, unknownType,
                                                                    unknownType, unknownType, unknownType,
                                                                    unknownType, unknownType, unknownType,
                                                                    unknownType, unknownType, unknownType,
                                                                    unknownType, unknownType, unknownType);
                if (excelWorkbook != null)
                {


                    // Call Excel's native export function (valid in Office 2007 and Office 2010, AFAIK)
                    excelWorkbook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF,
                                                      pdfPath,
                                                      unknownType, unknownType, unknownType, unknownType, unknownType,
                                                      unknownType, unknownType);

                    convertExcel2PdfResult = 0;

                }
                else
                {
                    Console.WriteLine("Error occured for conversion of office excel to PDF ");
                    convertExcel2PdfResult = 504;
                }

            }
            catch (Exception exExcel2Pdf)
            {
                Console.WriteLine("Error occured for conversion of office excel to PDF, Exception: ", exExcel2Pdf);
                convertExcel2PdfResult = 504;
            }
            finally
            {
                // Close the workbook, quit the Excel, and clean up regardless of the results...

                if (excelWorkbook != null)
                    excelWorkbook.Close(unknownType, unknownType, unknownType);
                if (excelApplication != null) excelApplication.Quit();

                Util.releaseObject(excelWorkbook);
                Util.releaseObject(excelApplication);
            }
            Console.WriteLine("Class: " + GetType() + " Method: " + MethodBase.GetCurrentMethod().Name + " Ended ");
            return convertExcel2PdfResult;
        }

        /// <summary>
        ///  Convert  powerPoint file to PDF by calling required method
        /// </summary>
        /// <param name="originalPptPath">file path</param>
        /// <param name="pdfPath">Target PDF path</param>
        /// <returns>error code : 0(sucess)/ -1 or errorcode (unknown error or failure)</returns>
        public short powerPoint2Pdf(object originalPptPath, object pdfPath)
        {
            Console.WriteLine("Class: " + GetType() + " Method: " + MethodBase.GetCurrentMethod().Name + " Started ");

            short convertPowerPoint2PdfResult = -1;

            PowerPoint.Application pptApplication = null;
            PowerPoint.Presentation pptPresentation = null;


            object unknownType = Type.Missing;

            try
            {
                //start power point 
                pptApplication = new PowerPoint.Application();

                //open powerpoint document
                pptPresentation = pptApplication.Presentations.Open((string)originalPptPath,
                                                                    Microsoft.Office.Core.MsoTriState.msoTrue,
                                                                    Microsoft.Office.Core.MsoTriState.msoTrue,
                                                                    Microsoft.Office.Core.MsoTriState.msoFalse);


                //export PDF from PPT
                if (pptPresentation != null)
                {
                    pptPresentation.ExportAsFixedFormat((string)pdfPath,
                                                         PowerPoint.PpFixedFormatType.ppFixedFormatTypePDF,
                                                         PowerPoint.PpFixedFormatIntent.ppFixedFormatIntentPrint,
                                                         MsoTriState.msoFalse,
                                                         PowerPoint.PpPrintHandoutOrder.ppPrintHandoutVerticalFirst,
                                                         PowerPoint.PpPrintOutputType.ppPrintOutputSlides,
                                                         MsoTriState.msoFalse, null,
                                                         PowerPoint.PpPrintRangeType.ppPrintAll, string.Empty,
                                                         true, true, true, true, false, unknownType);
                    convertPowerPoint2PdfResult = 0;
                }
                else
                {
                    Console.WriteLine("Error occured for conversion of office PowerPoint to PDF");
                    convertPowerPoint2PdfResult = 504;
                }
            }
            catch (Exception exPowerPoint2Pdf)
            {
                Console.WriteLine("Error occured for conversion of office PowerPoint to PDF, Exception: ", exPowerPoint2Pdf);
                convertPowerPoint2PdfResult = 504;
            }
            finally
            {
                // Close and release the Document object.
                if (pptPresentation != null)
                {
                    pptPresentation.Close();
                    Util.releaseObject(pptPresentation);
                    pptPresentation = null;
                }

                // Quit Word and release the ApplicationClass object.
                pptApplication.Quit();
                Util.releaseObject(pptApplication);
                pptApplication = null;
            }
            Console.WriteLine("Class: " + GetType() + " Method: " + MethodBase.GetCurrentMethod().Name + " Ended ");
            return convertPowerPoint2PdfResult;
        }

        /// <summary>
        ///   Convert   visio file to PDF by calling required method
        /// </summary>
        /// <param name="originalVsdPath">file path</param>
        /// <param name="pdfPath">Target PDF path</param>
        /// <returns>error code : 0(sucess)/ -1 or errorcode (unknown error or failure)</returns>
        public short visio2Pdf(string originalVsdPath, string pdfPath)
        {
            return - 1;
        }


    }
}
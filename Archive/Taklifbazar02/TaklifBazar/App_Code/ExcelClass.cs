using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NetOffice;
using Excel = NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;

    

/// <summary>
/// Summary description for ExcelClass
/// </summary>
public class ExcelClass
{
    Excel.Application ExcelApplication = new Excel.Application();
    public Excel.Workbook ExcelWrk { get; set; }
    
	public ExcelClass()
	{
        
	}

    public ExcelClass(string FileName)
    {
        ExcelWrk = ExcelApplication.Workbooks.Open(FileName);
    }

    public ExcelProperties GetProperties()
    {
        ExcelProperties myEP = new ExcelProperties();

        myEP.Sheet_C = ExcelWrk.Worksheets.Count;
        myEP.Chart_C = 0;
        myEP.Cell_C = 0;

        foreach (Excel.Worksheet WS in ExcelWrk.Worksheets)
        {            
            myEP.Chart_C += WS.ListObjects.Count;

            myEP.Cell_C += WS.UsedRange.Cells.Count;
        }
        

        return myEP;
    }

    public Excel.Workbook MakePreview()
    {
        Random RND = new Random(0);
        Excel.Workbook PrevDoc = ExcelWrk;
        PrevDoc.Activate();
        
        foreach (Excel.Worksheet WS in PrevDoc.Worksheets)
        {
            foreach (var a in WS.UsedRange)
            {
                if (RND.NextDouble() < 0.4)
                    a.Value = "****";
            }
        }

        
        return PrevDoc;
    }

    public void Convert2Pdf(Excel.Workbook WD, string Path, string Name)
    {        
        WD.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF,System.Web.HttpContext.Current.Server.MapPath(Path + Name + ".pdf"));
    }

    public void Dispose()
    {
        ExcelWrk.Close();
        ExcelWrk.Dispose();
        ExcelApplication.Dispose();
    }
}
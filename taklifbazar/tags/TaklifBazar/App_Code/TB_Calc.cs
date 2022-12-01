using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TB_Calc
/// </summary>
public class TB_Calc
{
	public TB_Calc()
	{
		
	}

    public static int TB_Rate4SettlementRequest(Int32 TotalAmount, int RequestedPercent, int RequestedDate)
    {
        return 1;
    }

    public static string SettlementDate4SettlementRequest(DateTime NowDate, int RequestDate)
    {
        string D = "";
        DateTime DD = NowDate.AddDays(RequestDate);
        D = DateConversion.DateTimeToPersianDay(DD) + " " + DateConversion.DateTimeToPersian(DD);
        
        return D;
    }

    public static Int32 SettlementAmount4SettlementRequest(Int32 TotalAmount, int RequestPercent)
    {
        return (Int32)(TotalAmount * RequestPercent / 100.0);
    }
}
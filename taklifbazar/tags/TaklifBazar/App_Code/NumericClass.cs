using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NumericClass
/// </summary>
public class NumericClass
{
	public NumericClass()
	{
		
	}

    public static string int2Currency(int Number)
    {
        if (Number != 0)
            return Number.ToString("#,#.");//, CultureInfo.CreateSpecificCulture("fa-IR"));
        else
            return "0";
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupportShowClass
/// </summary>
public class SupportShowClass
{
    public List<tb_SupportRequest> AllTR;
    public List<tb_SupportRequest> tmpAllTR;//For Extra search in Admin panel
    public List<tb_SupportRequest> ToShowTR;
    public int tCount;
    public int PageCount;
    public int PageNumb;

	public SupportShowClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
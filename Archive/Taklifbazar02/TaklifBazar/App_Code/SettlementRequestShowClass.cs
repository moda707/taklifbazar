using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SettlementRequestShowClass
/// </summary>
public class SettlementRequestShowClass
{
    public List<tb_SettlementRequest> AllTR;
    public List<tb_SettlementRequest> tmpAllTR;
    public List<tb_SettlementRequest> ToShowTR;
    public int tCount;
    public int PageCount;
    public int PageNumb;

	public SettlementRequestShowClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
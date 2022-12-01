using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FieldProp
/// </summary>
public class FieldProp
{
    public string Code;
    public string Name;
    public int Used;

	public FieldProp(string myCode, string myName, int myUsed)
	{
        Code = myCode;
        Name = myName;
        Used = myUsed;
	}

    public FieldProp(string myCode)
    {
        Code = myCode;
    }
}
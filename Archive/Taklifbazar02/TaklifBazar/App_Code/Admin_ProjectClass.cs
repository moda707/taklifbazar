using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using vtocSqlInterface;

/// <summary>
/// Summary description for Admin_ProjectClass
/// </summary>
public class Admin_ProjectClass
{
    public int RN;
    public string Paper_Code;
    public string Pre_Paper_Code;
    public string Upload_Date;
    public string TitleName;
    public int Download_C;
    public Int32 Price;
    public int Paper_Rate;

    public string Owner_Code;
    public string Owner_Name;

	public Admin_ProjectClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static List<Admin_ProjectClass> SearchByTag(string[] T, Project_List_OrderBy OrderBy, List_OrderType OrderType)
    {

        List<Admin_ProjectClass> S = new List<Admin_ProjectClass>();
        sqlInterface mySql1;
        string sqlCmd1;

        try
        {
            mySql1 = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
            string tmpTags = "";
            List<SqlParameter> parameters=new List<SqlParameter>();
            var i = 0;
            if (T!=null)
            {
                tmpTags = " WHERE (";
                foreach (string k in T)
                {
                    var p =new SqlParameter( "@k" + i, SqlDbType.NVarChar);
                    p.Value = k;
                    parameters.Add(p);
                    tmpTags += "(T.TF_Name LIKE '%' + @k" + i + " + '%' OR T.TE_Name LIKE '%' + @k" + i + " + '%' OR T.P_Desc Like '%' + @k" + i + " + '%' OR T.Abstract LIKE '%' + @k" + i + " + '%') OR";
                    i++;

                }
                tmpTags = tmpTags.Substring(0, tmpTags.Length - 2);
                tmpTags += ")";
            }
            string _OrderBy = " ORDER BY ";

            switch (OrderBy)
            {
                case Project_List_OrderBy.Rate:
                    _OrderBy += "T.Paper_Rate ";
                    break;
                case Project_List_OrderBy.Download:
                    _OrderBy += "T.Download_C ";
                    break;
                case Project_List_OrderBy.News:
                    _OrderBy += "T.Upload_Date ";
                    break;
                case Project_List_OrderBy.Price:
                    _OrderBy += "T.Price ";
                    break;
                case Project_List_OrderBy.Owner:
                    _OrderBy += "Name ";
                    break;
            }

            _OrderBy += OrderType.ToString();

            sqlCmd1 = "SELECT T.Paper_Code, T.Data3 Pre_Paper_Code, T.TF_Name, T.TE_Name, T.Paper_Rate, T.Download_C, T.Price, F.User_Code, (F.FFName + ' ' + F.FLName) Name, T.Upload_Date  FROM [dbo].[PaperList] T LEFT JOIN [dbo].[Users]  F ON F.User_Code=T.Owner_Code " + tmpTags + _OrderBy;

            DataTable DT = mySql1.SqlExecuteReader(sqlCmd1,parameters.ToArray());
            i = 1;
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Admin_ProjectClass newHW = new Admin_ProjectClass();
                    newHW.RN = i; i++;
                    newHW.Paper_Code = r[0].ToString();
                    newHW.Pre_Paper_Code = r[1].ToString();
                    string Title = r[2].ToString();
                    if (Title.Trim() == "") Title = r[3].ToString();
                    newHW.TitleName = Title;
                    newHW.Paper_Rate = Convert.ToInt32(r[4].ToString());
                    newHW.Download_C = Convert.ToInt32(r[5].ToString());
                    newHW.Price = Convert.ToInt32(r[6].ToString());
                    newHW.Owner_Code = r[7].ToString();
                    newHW.Owner_Name = r[8].ToString();
                    newHW.Upload_Date = r[9].ToString();

                    S.Add(newHW);
                }

            }

            return S;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}

public enum Project_List_OrderBy
{
    News = 0,
    Rate = 1,
    Owner = 2,
    Download = 3,
    Price = 4

}

public enum List_OrderType
{
    Asc = 0,
    Desc = 1
}
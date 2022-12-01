using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using vtocSqlInterface;

/// <summary>
/// Summary description for FilesDetail
/// </summary>
public class FilesDetail
{
    public string File_Code;
    public string Paper_Code;
    public File_Type FT;
    public Int32 FileSize;
    public string F_Desc;

    public int Page_C;
    public int Par_C;
    public int Line_C;
    public Int32 Word_C;
    public Int32 Char_C;
    public string Key_Words;

    public string OrgAddress;
    public string EncAddress;
    public string PrevAddress;

    private sqlInterface mySql;
    private string sqlCmd;

    //Database FileList: 0:[File_Code],1:[Paper_Code],2:[File_Type],3:[File_Size],4:[F_Desc],5:[Page_C],6:[Par_C],7:[Line_C],8:[Word_C],9:[Char_C],10:[Key_Words],11:[OrgAddress],12:[EncAddress],13:[PrevAddress],14:[Data1],15:[Data2],16:[Data3],17:[Data4]
	public FilesDetail()
	{
		
	}

    public bool File_Add()
    {
        try
        {
            mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

            sqlCmd = string.Format(@"INSERT dbo.FileList VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13},0,0,'','')",
                                                            "@File_Code", "@Paper_Code", "@FT", "@FileSize", "@F_Desc", "@Page_C", "@Par_C", "@Line_C", "@Word_C", "@Char_C", "@Key_Words", "@OrgAddress", "@EncAddress", "@PrevAddress");

            List<SqlParameter> parameters = new List<SqlParameter>();
            var p = new SqlParameter("@File_Code", SqlDbType.NVarChar);
            p.Value = File_Code;
            parameters.Add(p);

            p = new SqlParameter("@Char_C", SqlDbType.Int);
            p.Value = Char_C;
            parameters.Add(p);

            p = new SqlParameter("@Key_Words", SqlDbType.NVarChar);
            p.Value = Key_Words;
            parameters.Add(p);

            p = new SqlParameter("@EncAddress", SqlDbType.NVarChar);
            p.Value = EncAddress;
            parameters.Add(p);

            p = new SqlParameter("@PrevAddress", SqlDbType.NVarChar);
            p.Value = PrevAddress;
            parameters.Add(p);

            p = new SqlParameter("@OrgAddress", SqlDbType.NVarChar);
            p.Value = OrgAddress;
            parameters.Add(p);
            
            p = new SqlParameter("@Word_C", SqlDbType.Int);
            p.Value = Word_C;
            parameters.Add(p);

            p = new SqlParameter("@Line_C", SqlDbType.Int);
            p.Value = Line_C;
            parameters.Add(p);

            p = new SqlParameter("@Par_C", SqlDbType.Int);
            p.Value = Par_C;
            parameters.Add(p);


            p = new SqlParameter("@Page_C", SqlDbType.Int);
            p.Value = Page_C;
            parameters.Add(p);

            p = new SqlParameter("@Paper_Code", SqlDbType.NVarChar);
            p.Value = Paper_Code;
            parameters.Add(p);

            p = new SqlParameter("@FT",SqlDbType.Int);
            p.Value = (int)FT;
            parameters.Add(p);

            p = new SqlParameter("@FileSize", SqlDbType.Int);
            p.Value = FileSize;
            parameters.Add(p);

            p = new SqlParameter("@F_Desc", SqlDbType.NVarChar);
            p.Value = F_Desc;
            parameters.Add(p);


            if (mySql.SqlExecuteNonQuery(sqlCmd,parameters.ToArray()))
            {
                return true;
            }
            else
                return false;
        }
        catch (Exception e)
        {
            return false;
        }

        
    }

    public File_Type GetExtension(string t)
    {
        t = t.Trim().ToLower();
        if (t[0] == '.') t = t.Substring(1);

        switch (t)
        {
            case "doc":
            case "docx":
                return File_Type.Word;
                
            case "xls":
            case "xlsx":
                return File_Type.Excel;
                
            case "ppt":
            case "pptx":
                return File_Type.PowerPoint;
                
            case "pdf":
                return File_Type.PDF;
                
            default:
                return File_Type.Unknown;

        }
    }
}



public enum File_Type
{
    Word,
    Excel,
    PowerPoint,
    PDF,
    Unknown
}
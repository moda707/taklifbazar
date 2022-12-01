using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class UProjects : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            LoginClass LC = (LoginClass)Session["LC"];
            string Owner_Code = LC.User_Code;
            
            List<Homework> LHW = Homework.SearchByOwner(Owner_Code);
            int t = 5;
            int PageNumb = 1;
            int PageCount = LHW.Count / t + 1;
            int tCount = LHW.Count;
            LHW = LHW.Take(t).ToList();

            string C = "";
            if (LHW.Count > 0)
            {
                C = "<table class=\"table table-striped\"><thead><tr><th>#</th><th>عنوان</th><th>توضیحات</th><th>قیمت</th><th>فروش</th><th></th><th></th></tr></thead><tbody>";
                foreach (Homework a in LHW)
                {
                    string Description = a.P_Desc;
                    if (Description.Length > 50)
                        Description = Description.Substring(0, 50) + "...";

                    C += "<tr><td>" + a.RN + "</td><td>" + a.TF_Name + "</td><td>" + Description + "</td><td>" + NumericClass.int2Currency(Convert.ToInt32(a.Price)) +"</td><td>" + a.Download_C + "</td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:HWDet('" + Encryption.Encrypt(a.Paper_Code, SharedDataInfo.SecurityKey) + "');\">جزئیات</button></td><td><button type=\"button\" class=\"btn btn-link\"  onclick=\"javascript:HWRM('" + Encryption.Encrypt(a.Paper_Code, SharedDataInfo.SecurityKey) + "');\" >حذف</button></td></tr>";
                }
                C += "</tbody></table>";
            }
            else
            {
                C = "موردی یافت نشد.";
            }
            TblCnt.InnerHtml = C;

            string PG = "<ul class=\"pagination\">";


            PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";

            for (var i = 1; i <= PageCount; i++)
            {
                if (i == 1)
                {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                }
                else
                {
                    PG += "<li><a href=\"javascript:UP_Search('" + i + "');\">" + i + "</a></li>";
                }
            }

            if (PageCount == 1)
            {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            }
            else
            {
                PG += "<li><a href=\"javascript:UP_Search('2');\">«</a></li>";
            }


            PaginationPanel.InnerHtml = PG;
        }
    }
        
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            LoginClass LC = (LoginClass)Session["LC"];
            
            Homework HW = new Homework();

            HW.Paper_Code = DateTime.Now.Ticks.ToString();
            HW.Paper_Code = HW.Paper_Code.Substring(HW.Paper_Code.Length - 10, 10);
            HW.Owner_Code = LC.User_Code;
            
            HW.Uploade_Date = DateTime.Now.Ticks.ToString();
            HW.TF_Name = txtFTitle.Value;
            HW.TE_Name = txtETitle.Value;
            HW.P_Desc = txtPDesc.Value;

            
            List<FieldProp> FP = (List<FieldProp>)Session["FPL"];
            if (FP != null)
            {
                HW.Fields = FP[0].Code;
                for (int i = 1; i < FP.Count; i++)
                {
                    HW.Fields += "!" + FP[i].Code;
                }
            }        
            switch (slcSellType.Items[slcSellType.SelectedIndex].Value)
            {
                case "0":
                    HW.ST = Sell_Type.Normal;
                    HW.FeesPercent = 80;
                    break;
                case "1":
                    HW.ST = Sell_Type.Special;
                    HW.FeesPercent = 65;
                    break;
            }
            HW.Price = Convert.ToInt32(txtPrice.Value);


            HW.T_Word_C = 0;
            string[] tmp1 = HW.TF_Name.Split(' ');
            foreach (var a in tmp1)
            {
                if (a != " ") HW.T_Word_C++;
            }

                        
            string tmp2 = HW.TF_Name.Replace(" ", "");
            HW.T_Char_C = tmp2.Length;

            HW.Status = P_Status.Submitted;
            HW.LastModifiedDate = HW.Uploade_Date;
            HW.Download_C = 0;

            //Add HomeWork (without Files)
            if (HW.HW_Add())
            {
                //FileUploader 1
                #region FU1
                if (FileUploader_1.HasFile)
                {
                    try
                    {
                        //Save Main File
                        FilesDetail FD = new FilesDetail();
                        FD.File_Code = DateTime.Now.Ticks.ToString();

                        FileInfo FI = new FileInfo(FileUploader_1.PostedFile.FileName.Substring(1));
                        FileUploader_1.SaveAs(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                        FI = new FileInfo(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));

                        FD.FT = FD.GetExtension(FI.Extension);
                        FD.Paper_Code = HW.Paper_Code;
                        FD.FileSize = Convert.ToInt32(FI.Length / 1024);
                        FD.F_Desc = FDesc_1.Value;

                        FD.OrgAddress = "Datas/OrgFile/" + FD.File_Code + FI.Extension;
                        FD.EncAddress = "";
                        string tmp = DateTime.Now.Ticks.ToString();
                        tmp = tmp.Substring(tmp.Length - 10, 10);

                        //switch (FD.FT)
                        //{
                        //    case File_Type.Word:
                        //        WordClass WC = new WordClass(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                        //        WordProperties WP = WC.GetProperties();
                        //        FD.Page_C = WP.Page_C;
                        //        FD.Par_C = WP.Paragrapgh_C;
                        //        FD.Line_C = WP.Line_C;
                        //        FD.Word_C = WP.Word_C;
                        //        FD.Key_Words = WP.Key_Words;

                        //        //Preview
                        //        WC.Convert2Pdf(WC.MakePreview(), "Datas/PrevFile/", tmp);

                        //        WC.Dispose();

                        //        break;
                        //    case File_Type.Excel:
                        //        ExcelClass EC = new ExcelClass(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                        //        ExcelProperties EP = EC.GetProperties();
                        //        FD.Page_C = EP.Sheet_C;
                        //        FD.Par_C = EP.Chart_C;
                        //        FD.Word_C = EP.Cell_C;

                        //        //Preview
                        //        EC.Convert2Pdf(EC.MakePreview(), "Datas/PrevFile/", tmp);

                        //        EC.Dispose();

                        //        break;
                        //    case File_Type.PowerPoint:

                        //        break;
                        //}


                        FD.PrevAddress = "Datas/PrevFile/" + tmp + ".pdf";



                        FD.File_Add();
                    }
                    catch (Exception e21)
                    {
                        //Log
                    }
                }
                #endregion
                
                //FileUploader 2
                #region FU2
                if (FileUploader_2.HasFile)
                {
                    try
                    {
                        //Save Main File
                        FilesDetail FD = new FilesDetail();
                        FD.File_Code = DateTime.Now.Ticks.ToString();

                        FileInfo FI = new FileInfo(FileUploader_2.PostedFile.FileName.Substring(1));
                        FileUploader_2.SaveAs(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                        FI = new FileInfo(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));

                        FD.FT = FD.GetExtension(FI.Extension);
                        FD.Paper_Code = HW.Paper_Code;
                        FD.FileSize = Convert.ToInt32(FI.Length / 1024);
                        FD.F_Desc = FDesc_1.Value;

                        FD.OrgAddress = "Datas/OrgFile/" + FD.File_Code + "." + FI.Extension;
                        FD.EncAddress = "";
                        string tmp = DateTime.Now.Ticks.ToString();
                        tmp = tmp.Substring(tmp.Length - 10, 10);

                        //switch (FD.FT)
                        //{
                        //    case File_Type.Word:
                        //        WordClass WC = new WordClass(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                        //        WordProperties WP = WC.GetProperties();
                        //        FD.Page_C = WP.Page_C;
                        //        FD.Par_C = WP.Paragrapgh_C;
                        //        FD.Line_C = WP.Line_C;
                        //        FD.Word_C = WP.Word_C;
                        //        FD.Key_Words = WP.Key_Words;                                

                        //        //Preview
                        //        WC.Convert2Pdf(WC.MakePreview(), "Datas/PrevFile/", tmp);

                        //        WC.Dispose();

                        //        break;
                        //    case File_Type.Excel:
                        //        ExcelClass EC = new ExcelClass(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                        //        ExcelProperties EP = EC.GetProperties();
                        //        FD.Page_C = EP.Sheet_C;
                        //        FD.Par_C = EP.Chart_C;
                        //        FD.Word_C = EP.Cell_C;
                                
                        //        //Preview
                        //        EC.Convert2Pdf(EC.MakePreview(), "Datas/PrevFile/", tmp);

                        //        EC.Dispose();

                        //        break;
                        //    case File_Type.PowerPoint:

                        //        break;
                        //}

                        
                        FD.PrevAddress = "Datas/PrevFile/" + tmp + ".pdf";

                        

                        FD.File_Add();
                    }
                    catch (Exception e21)
                    {
                        //Log
                    }
                }
                #endregion

                //FileUploader 3
                #region FU3
                if (FileUploader_3.HasFile)
                {
                    try
                    {
                        //Save Main File
                        FilesDetail FD = new FilesDetail();
                        FD.File_Code = DateTime.Now.Ticks.ToString();

                        FileInfo FI = new FileInfo(FileUploader_3.PostedFile.FileName.Substring(1));
                        FileUploader_3.SaveAs(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                        FI = new FileInfo(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));

                        FD.FT = FD.GetExtension(FI.Extension);
                        FD.Paper_Code = HW.Paper_Code;
                        FD.FileSize = Convert.ToInt32(FI.Length / 1024);
                        FD.F_Desc = FDesc_3.Value;

                        FD.OrgAddress = "Datas/OrgFile/" + FD.File_Code + "." + FI.Extension;
                        FD.EncAddress = "";
                        string tmp = DateTime.Now.Ticks.ToString();
                        tmp = tmp.Substring(tmp.Length - 10, 10);

                        switch (FD.FT)
                        {
                            case File_Type.Word:
                                WordClass WC = new WordClass(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                                WordProperties WP = WC.GetProperties();
                                FD.Page_C = WP.Page_C;
                                FD.Par_C = WP.Paragrapgh_C;
                                FD.Line_C = WP.Line_C;
                                FD.Word_C = WP.Word_C;
                                FD.Key_Words = WP.Key_Words;

                                //Preview
                                WC.Convert2Pdf(WC.MakePreview(), "Datas/PrevFile/", tmp);

                                WC.Dispose();

                                break;
                            case File_Type.Excel:
                                ExcelClass EC = new ExcelClass(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                                ExcelProperties EP = EC.GetProperties();
                                FD.Page_C = EP.Sheet_C;
                                FD.Par_C = EP.Chart_C;
                                FD.Word_C = EP.Cell_C;

                                //Preview
                                EC.Convert2Pdf(EC.MakePreview(), "Datas/PrevFile/", tmp);

                                EC.Dispose();

                                break;
                            case File_Type.PowerPoint:

                                break;
                        }


                        FD.PrevAddress = "Datas/PrevFile/" + tmp + ".pdf";



                        FD.File_Add();
                    }
                    catch (Exception e21)
                    {
                        //Log
                    }
                }
                #endregion

                //FileUploader 4
                #region FU4
                if (FileUploader_4.HasFile)
                {
                    try
                    {
                        //Save Main File
                        FilesDetail FD = new FilesDetail();
                        FD.File_Code = DateTime.Now.Ticks.ToString();

                        FileInfo FI = new FileInfo(FileUploader_4.PostedFile.FileName.Substring(1));
                        FileUploader_4.SaveAs(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                        FI = new FileInfo(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));

                        FD.FT = FD.GetExtension(FI.Extension);
                        FD.Paper_Code = HW.Paper_Code;
                        FD.FileSize = Convert.ToInt32(FI.Length / 1024);
                        FD.F_Desc = FDesc_4.Value;

                        FD.OrgAddress = "Datas/OrgFile/" + FD.File_Code + "." + FI.Extension;
                        FD.EncAddress = "";
                        string tmp = DateTime.Now.Ticks.ToString();
                        tmp = tmp.Substring(tmp.Length - 10, 10);

                        switch (FD.FT)
                        {
                            case File_Type.Word:
                                WordClass WC = new WordClass(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                                WordProperties WP = WC.GetProperties();
                                FD.Page_C = WP.Page_C;
                                FD.Par_C = WP.Paragrapgh_C;
                                FD.Line_C = WP.Line_C;
                                FD.Word_C = WP.Word_C;
                                FD.Key_Words = WP.Key_Words;

                                //Preview
                                WC.Convert2Pdf(WC.MakePreview(), "Datas/PrevFile/", tmp);

                                WC.Dispose();

                                break;
                            case File_Type.Excel:
                                ExcelClass EC = new ExcelClass(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                                ExcelProperties EP = EC.GetProperties();
                                FD.Page_C = EP.Sheet_C;
                                FD.Par_C = EP.Chart_C;
                                FD.Word_C = EP.Cell_C;

                                //Preview
                                EC.Convert2Pdf(EC.MakePreview(), "Datas/PrevFile/", tmp);

                                EC.Dispose();

                                break;
                            case File_Type.PowerPoint:

                                break;
                        }


                        FD.PrevAddress = "Datas/PrevFile/" + tmp + ".pdf";



                        FD.File_Add();
                    }
                    catch (Exception e21)
                    {
                        //Log
                    }
                }
                #endregion

                //FileUploader 5
                #region FU5
                if (FileUploader_5.HasFile)
                {
                    try
                    {
                        //Save Main File
                        FilesDetail FD = new FilesDetail();
                        FD.File_Code = DateTime.Now.Ticks.ToString();

                        FileInfo FI = new FileInfo(FileUploader_5.PostedFile.FileName.Substring(1));
                        FileUploader_5.SaveAs(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                        FI = new FileInfo(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));

                        FD.FT = FD.GetExtension(FI.Extension);
                        FD.Paper_Code = HW.Paper_Code;
                        FD.FileSize = Convert.ToInt32(FI.Length / 1024);
                        FD.F_Desc = FDesc_2.Value;

                        FD.OrgAddress = "Datas/OrgFile/" + FD.File_Code + "." + FI.Extension;
                        FD.EncAddress = "";
                        string tmp = DateTime.Now.Ticks.ToString();
                        tmp = tmp.Substring(tmp.Length - 10, 10);

                        switch (FD.FT)
                        {
                            case File_Type.Word:
                                WordClass WC = new WordClass(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                                WordProperties WP = WC.GetProperties();
                                FD.Page_C = WP.Page_C;
                                FD.Par_C = WP.Paragrapgh_C;
                                FD.Line_C = WP.Line_C;
                                FD.Word_C = WP.Word_C;
                                FD.Key_Words = WP.Key_Words;

                                //Preview
                                WC.Convert2Pdf(WC.MakePreview(), "Datas/PrevFile/", tmp);

                                WC.Dispose();

                                break;
                            case File_Type.Excel:
                                ExcelClass EC = new ExcelClass(Server.MapPath("Datas/OrgFile/" + FD.File_Code + FI.Extension));
                                ExcelProperties EP = EC.GetProperties();
                                FD.Page_C = EP.Sheet_C;
                                FD.Par_C = EP.Chart_C;
                                FD.Word_C = EP.Cell_C;

                                //Preview
                                EC.Convert2Pdf(EC.MakePreview(), "Datas/PrevFile/", tmp);

                                EC.Dispose();

                                break;
                            case File_Type.PowerPoint:

                                break;
                        }


                        FD.PrevAddress = "Datas/PrevFile/" + tmp + ".pdf";



                        FD.File_Add();
                    }
                    catch (Exception e21)
                    {
                        //Log
                    }
                }
                #endregion

            }

        }
        catch (Exception e1)
        {

        }
    }
}
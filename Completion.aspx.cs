using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Completion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TradePack TP = (TradePack)Session["TRPack"];
        if (TP != null)
        {
            tb_Trades TRD = TP.Trades;
            tb_Transactions TRN = TP.Transactions;
            Homework HW = TP.HW;
            LoginClass LC = TP.LC;
            tb_FinancialAcc FA_Buyer;
            tb_FinancialAcc FA_TB = new tb_FinancialAcc("0");
            tb_FinancialAcc FA_Seller = new tb_FinancialAcc(HW.Owner_Code);

            Int32 Amount;

            //Trade
            TRD.Trade_Code = TRD.Trade_Add();

                                    
            //Transactions
            string nn = HW.TF_Name;
            if (nn.Trim() == "") nn = HW.TE_Name;
            if (nn.Length > 20) nn = nn.Substring(0, 20) + " ...";
            nn = "-" + nn;

            tb_Transactions tmpT = new tb_Transactions();
            if (LC.User_Code != "")
            {
                //Local Seller Account to TB Account
                tmpT.User_Code = LC.User_Code;
                tmpT.InOut = InOut_Type.Out;
                tmpT.Trade_Code = TRD.Trade_Code;
                tmpT.Amount = TRD.Price_Final;
                tmpT.CurAcc_Type = CurrentAccount_Type.Local;
                tmpT.BN_Source = "0";
                tmpT.Trans_Type = Transaction_Type.Buy;
                tmpT.Trans_Subject = "خرید تکلیف تحت عنوان " + nn;

                FA_Buyer = new tb_FinancialAcc(LC.User_Code);
                Amount = Convert.ToInt32(FA_Buyer.Amount);
                FA_Buyer.Amount = (Amount - Convert.ToInt32(TRD.Price_Final)).ToString();
                tmpT.AccBalance = FA_Buyer.Amount;

                FA_Buyer.LastTransaction = tmpT.Transaction_Add();

                FA_Buyer.Update();


                //TB Account FROM Local Seller Account
                tmpT = new tb_Transactions();
                tmpT.User_Code = "0";
                tmpT.InOut = InOut_Type.In;
                tmpT.Trade_Code = TRD.Trade_Code;
                tmpT.Amount = TRD.Price_Final;
                tmpT.CurAcc_Type = CurrentAccount_Type.Local;
                tmpT.BN_Source = LC.User_Code;
                tmpT.Trans_Type = Transaction_Type.Buy;
                tmpT.Trans_Subject = "خرید تکلیف تحت عنوان " + nn;
                
                
                Amount = Convert.ToInt32(FA_TB.Amount);
                FA_TB.Amount = (Amount + Convert.ToInt32(TRD.Price_Final)).ToString();

                tmpT.AccBalance = FA_TB.Amount;

                FA_TB.LastTransaction = tmpT.Transaction_Add();
                FA_TB.Update();

            }
            else
            {
                tmpT = new tb_Transactions();
                tmpT.User_Code = "0";
                tmpT.InOut = InOut_Type.In;
                tmpT.Trade_Code = TRD.Trade_Code;
                tmpT.Amount = TRD.Price_Final;
                tmpT.CurAcc_Type = CurrentAccount_Type.Bank;
                tmpT.BN_Source = "G";
                tmpT.BN_Portal = TRN.BN_Portal;
                tmpT.Trans_Type = Transaction_Type.Buy;
                tmpT.Trans_Subject = "خرید تکلیف تحت عنوان " + nn;

                FA_TB = new tb_FinancialAcc("0");
                Amount = Convert.ToInt32(FA_TB.Amount);
                FA_TB.Amount = (Amount + Convert.ToInt32(TRD.Price_Final)).ToString();

                tmpT.AccBalance = FA_TB.Amount;

                FA_TB.LastTransaction = tmpT.Transaction_Add();
                FA_TB.Update();
            }

            tmpT = new tb_Transactions();
            tmpT.User_Code = HW.Owner_Code;
            tmpT.InOut = InOut_Type.In;
            tmpT.Trade_Code = TRD.Trade_Code;
            Amount = (Int32)(Convert.ToInt32(TRD.Price_Final)*Convert.ToInt32(TRD.TB_Rate)/100.0);
            tmpT.Amount = Amount.ToString();
            tmpT.CurAcc_Type = CurrentAccount_Type.Local;
            tmpT.Trans_Type = Transaction_Type.Sell;
            tmpT.Trans_Subject = "فروش تکلیف با عنوان " + nn;
            tmpT.BN_Source = "0";

            FA_Seller.Amount = (Amount + Convert.ToInt32(FA_Seller.Amount)).ToString();
            tmpT.AccBalance = FA_Seller.Amount;
                        
            FA_Seller.LastTransaction = tmpT.Transaction_Add();
            FA_Seller.Update();


            tmpT = new tb_Transactions();
            tmpT.User_Code = "0";
            tmpT.InOut = InOut_Type.Out;
            tmpT.Trade_Code = TRD.Trade_Code;
            Amount = (Int32)(Convert.ToInt32(TRD.Price_Final) * Convert.ToInt32(TRD.TB_Rate) / 100.0);
            tmpT.Amount = Amount.ToString();
            tmpT.CurAcc_Type = CurrentAccount_Type.Local;
            tmpT.Trans_Type = Transaction_Type.Sell;
            tmpT.Trans_Subject = "فروش تکلیف با عنوان " + nn;
            tmpT.BN_Source = HW.Owner_Code;
            FA_Seller.Amount = (Amount + Convert.ToInt32(FA_Seller.Amount)).ToString();
            tmpT.AccBalance = FA_Seller.Amount;
                        
            FA_Seller.LastTransaction = tmpT.Transaction_Add();
            FA_Seller.Update();


            
            

            //Paper_List:Download_C
            TP.HW.Download_C++;
            TP.HW.LastModifiedDate = DateTime.Now.Ticks.ToString();
            TP.HW.HW_Update();


            //Go to the Download Page
            string DT = DateTime.Now.Ticks.ToString();
            string Path = TP.HW.Paper_Code + "!" + DT;

            Session.Remove("TRPack");

            Response.Redirect("DownloadHW.aspx?=" + Encryption.Encrypt(Path,SharedDataInfo.SecurityKey));
        }
        
    }
}
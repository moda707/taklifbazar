using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Factor : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!String.IsNullOrEmpty(Session["HW2Buy"].ToString()))
                {
                    txtDiscount.InnerHtml = "0";
                    Homework HW = (Homework)Session["HW2Buy"];
                    txtTitle.InnerHtml = HW.TF_Name; //TEName
                    txtPrice.InnerHtml = NumericClass.int2Currency(HW.Price);
                    txtTotalCost.InnerHtml = NumericClass.int2Currency((HW.Price - Convert.ToInt32(txtDiscount.InnerHtml)));
                    txtDiscount.InnerHtml = NumericClass.int2Currency(0);
                }
            }
            catch (Exception e2)
            {
                Response.Redirect("Default.aspx");
            }
        }        
    }
    protected void btnPay_Click(object sender, EventArgs e)
    {
        Homework HW = (Homework)Session["HW2Buy"];
        LoginClass LC = new LoginClass();
        try{
            LC = (LoginClass)Session["LC"];
        }catch(Exception e2){

        }
                
        TradePack TP = new TradePack();
        TP.HW = HW;
        TP.LC = LC;

        tb_Trades TRD = new tb_Trades();
        TRD.Paper_Code = HW.Paper_Code;
        if (LC != null)
            TRD.Buyer_Code = LC.User_Code;
        else
            TRD.Buyer_Code = "G";

       
        TRD.Price_Prim = txtPrice.InnerHtml.Replace(",","");
        TRD.Discount = txtDiscount.InnerHtml.Replace(",", "");
        TRD.Price_Final = txtTotalCost.InnerHtml.Replace(",", "");
        TRD.TB_Rate = HW.FeesPercent.ToString();

        TP.Trades = TRD;

        tb_Transactions TRN = new tb_Transactions();
        TRN.User_Code = LC.User_Code;
        TRN.Trans_Type = Transaction_Type.Buy;
        TRN.Trans_Subject = "";
        TRN.Amount = txtTotalCost.InnerHtml.Replace(",", "");
        TRN.InOut = InOut_Type.Out;//
        TRN.CurAcc_Type = CurrentAccount_Type.Bank;//
        TRN.User_IP = LC.IP;//
        TRN.BN_Portal = (Bank_Name)Convert.ToInt16(optBankName.Items[optBankName.SelectedIndex].Value);

        TP.Transactions = TRN;

        Session["TRPack"] = TP;


        //BankPage

        Response.Redirect("Completion.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }


}
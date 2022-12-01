using System;
using System.Web;

/// <summary>
/// Summary description for URLRewriter
/// </summary>
public class URLRewriter : IHttpModule
{

    #region IHttpModule Members

    /// <summary>
    /// Dispose method for the class
    /// If you have any unmanaged resources to be disposed
    /// free them or release them in this method
    /// </summary>
    public void Dispose()
    {
        //not implementing this method
        //for this example
    }

    /// <summary>
    /// Initialization of the http application instance
    /// </summary>
    /// <param name="context"></param>
    public void Init(HttpApplication context)
    {
        context.BeginRequest += new EventHandler(context_BeginRequest);
    }
    /// <summary>
    /// Event handler of instance begin request
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void context_BeginRequest(object sender, EventArgs e)
    {
        //Create an instance of the application that has raised the event
        HttpApplication httpApplication = sender as HttpApplication;
        
        //Safety check for the variable httpApplication if it is not null
        if (httpApplication != null)
        {
            //get the request path - request path is    something you get in
            //the url
            string requestPath = httpApplication.Context.Request.Path;
            //variable for translation path
            string translationPath = "";


            
            //if the request path is /urlrewritetestingapp/laptops/dell/
            //it means the site is for DLL
            //else if "/urlrewritetestingapp/laptops/hp/"
            //it means the site is for HP
            //else it is the default path
            if (!requestPath.Contains("css/") && !requestPath.Contains("js/") && !requestPath.Contains("logo") && !requestPath.Contains("fonts") && !requestPath.Contains("images"))
            {
                if (requestPath == "/TaklifBazar/Home")
                {
                    translationPath = "/TaklifBazar/Default.aspx";
                }
                else if (requestPath.Contains("Register"))
                {
                    requestPath = requestPath.Replace(".aspx", "");
                    if (requestPath.Length > 21)
                    {
                        string QueryString = requestPath.Substring(22);
                        QueryString = Encryption.Decrypt(QueryString, SharedDataInfo.SecurityKey);

                        translationPath = "/TaklifBazar/Register.aspx?" + QueryString;
                    }
                    else
                    {
                        translationPath = "/TaklifBazar/Register.aspx?State=Form";
                    }
                }
                else if (requestPath.Contains("/TaklifBazar/View/"))
                {
                    string QueryString = requestPath.Replace("/TaklifBazar/View/", "");
                    QueryString = Encryption.Decrypt(QueryString, SharedDataInfo.SecurityKey);

                    translationPath = "/TaklifBazar/ProjView.aspx?" + QueryString;
                }
                else if (requestPath == "/TaklifBazar/Signin")
                {
                    translationPath = "/TaklifBazar/Singin.aspx";
                }
                else if (requestPath == "/TaklifBazar/Factor")
                {
                    translationPath = "/TaklifBazar/Factor.aspx";
                }
                else if (requestPath == "/TaklifBazar/Payment")
                {
                    translationPath = "/TaklifBazar/Payment.aspx";
                }
                else if (requestPath == "/TaklifBazar/Portal")
                {
                    translationPath = "/TaklifBazar/UserPortal.aspx";
                }
                else if (requestPath == "/TaklifBazar/Projects")
                {
                    translationPath = "/TaklifBazar/UProjects.aspx";
                }
                else if (requestPath == "/TaklifBazar/Setting")
                {
                    translationPath = "/TaklifBazar/USetting.aspx";
                }
                else if (requestPath == "/TaklifBazar/Account")
                {
                    translationPath = "/TaklifBazar/UAccount.aspx";
                }
                else if (requestPath == "/TaklifBazar/Buy")
                {
                    translationPath = "/TaklifBazar/UBuy.aspx";
                }
                else if (requestPath == "/TaklifBazar/Support")
                {
                    translationPath = "/TaklifBazar/USupport.aspx";
                }
                else
                {
                    translationPath = requestPath;
                }

                //switch (requestPath.ToLower())
                //{
                //    case "/Home.tb/":
                //        translationPath = "/Register.aspx?State=Form";
                //        break;
                //    case "/urlrewritetestingapp/laptops/hp/":
                //        translationPath = "/urlrewritetestingapp/Register.aspx?State=MobileVerified";
                //        break;
                //    default:
                //        translationPath = "/default.aspx";
                //        break;
                //}

                //use server transfer to transfer the request to the actual translated path
                httpApplication.Context.Server.Transfer(translationPath);
            }
        }
    }

    #endregion
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MLM
{
    public static class LogicLayer
    {

        public static string GetMasterPage(string Username){
            return "~/Member/Master/MasterPage.master";  }
       
        public static string GetLoginURL(){
            string URL = "https://phdssinfo.co.in/";// "~/Login/Pages/Default.aspx";
            return URL;}

        public static string GetConfirmationURL(string Status, string form){
            string confirmurl = "~/Member/Pages/Confirmation.aspx?s=" + Status + "&f=" + form;
            return confirmurl;}

        public static string GetAccessDeniedURL(){
            string URL = "../../Member/AccessDenied/Default.aspx";
            return URL;}

       

    }
}

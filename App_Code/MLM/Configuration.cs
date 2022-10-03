using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Configuration
/// </summary>

namespace MLM
{
    public static class Configuration
    {

        ///* Company Setup Start */
        //public static string CompanyLogo = "../../Member/Images/Logo1.png";
        //public static string CompanyName = "United Thelogical Research University";
        //public static string CompanyEmailId = "info@phdssinfo.co.in";
        //public static string CompanyPhoneNo = "";
        //public static string CompanyAddress = "P.O Box 3444, Makaunga, Hahake, Tongatapu, Kingdom of Tonga";
        //public static string CompanyWebsiteURL = "www.phdssinfo.co.in";
        //public static string SMSCompanyName = "United Thelogical Research University";
        ///* Company Setup End */


        ///*Joining*/
        //public static string JoiningSMSEnable = "YES";//YES/NO
        //public static string SponsorCode = "Sponsor Code";
        //public static string SponsorName = "Sponsor Name";
        //public static string EPinId = "EPin Id";
        //public static string EPinCode = "EPin Code";
        //public static string EpinFor = "SPONSOR";// Sponsor or branch
        //public static int MaxSponsor = 0;//0 for no limit

        public static string TopupEnable = "NO";//YES/NO
        public static int Cutoff = 0;//4,2,0(0 for no cutoff)
    }
}
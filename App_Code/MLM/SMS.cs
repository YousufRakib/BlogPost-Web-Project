using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;

namespace MLM
{
    public class SMS
    {
        public SMS()
        {
        }

        public void SendSMS(string mobileno, string message)
        {
            //string CreatURL = "http://144.76.180.44/WebSMS/SMSAPI.jsp?username=provincial&password=provincial&sendername=PROVIN&mobileno=" + mobileno + "&message=" + message + "";
            //string CreatURL = "http://reseller.dove-sms.com/SMSAPI.jsp?username=khushahal&password=1093738072&sendername=KHUSHL&mobileno=" + mobileno + "&message=" + message + "";
           // string CreatURL = "http://sms.flexonlive.com/sendsms.jsp?user=alliance&password=alliance&mobiles=" + mobileno + "&sms=" + message + "&senderid=INFOR";
              string CreatURL = "http://smartsms.3squaretechnologies.com/submitsms.jsp?user=3SQRTEC&key=eb6ee0eef5XX&mobile=" + mobileno + "&message=" + message + "&senderid=DALERT&accusage=1";
           
		   try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(CreatURL);
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();
            }
            catch (Exception)
            {

            }
        }

         
    }
}

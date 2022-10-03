using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for smssend
/// </summary>
public class smssend
{
	public smssend()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void Sms(string api)
    {
       
        StringBuilder b = new StringBuilder(api);
        string createurl = string.Empty;
      
        createurl = b.ToString();

        try
        {
            // creating web request to send sms 
            HttpWebRequest _createRequest = (HttpWebRequest)WebRequest.Create(createurl);
            // getting response of sms
            HttpWebResponse myResp = (HttpWebResponse)_createRequest.GetResponse();
            System.IO.StreamReader _responseStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = _responseStreamReader.ReadToEnd();
            _responseStreamReader.Close();
            myResp.Close();
        }
        catch (Exception ex)
        {

        }
    }
}
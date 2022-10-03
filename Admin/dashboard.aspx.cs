using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        try { 
            //MailMessage mail = new MailMessage();
            //mail.To.Add(txtto.Text);
            //mail.From = new MailAddress("mushrif35-1429@diu.edu.bd");
            //mail.Subject = txtsub.Text;
            //mail.Body = txtmsg.Text;
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential("mushrif35-1429@diu.edu.bd", "161-35-1429");
            //smtp.EnableSsl = true;

            //smtp.Send(mail);
            //lblmsg.Text = "Mail Send .......";
        }  
        catch (Exception ex)  
        {

            //lblmsg.Text = ex.Message;
        }  
    }
}
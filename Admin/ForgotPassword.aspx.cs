using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public static string validatePassword(string password)
    {

        string validationMsg = "Success";
        HashSet<char> specialCharacters = new HashSet<char>() { '%', '$', '#','!','&','@','^','*','?','_','~',
            '`', '(', ')','-','+','=','{','}','[',']','/',
            '|', ':', ';','>','<','.',' '};
        if (password == null && password == string.Empty)
        {
            validationMsg = "Password field can't be empty";
        }
        if (!password.Any(char.IsLower)) { validationMsg = "Password must contain at least a lower case character."; }
        if (!password.Any(char.IsUpper)) { validationMsg = "Password must contain at least a upper case character."; }
        if (!password.Any(char.IsDigit)) { validationMsg = "Password must contain at least one number."; }
        if (!password.Any(specialCharacters.Contains)) { validationMsg = "Password must contain at least one special Character."; }

        if (password.Length < 8) { validationMsg = "Password must be at least 8 characters long."; }


        return validationMsg;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblSuccess.Text = "";
        lblmsg.Text = "";
           SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        if (txtEmail.Text == "")
        {
            lblmsg.Text = "UserName field  is required!";
            txtEmail.Focus();
            return;
        }
        if (txtEmail.Text != "")
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Registration where Email='" + txtEmail.Text + "'", con);
            DataSet dt = new DataSet();
            da.Fill(dt);
            if (dt.Tables[0].Rows.Count == 0)
            {
                lblmsg.Text = "Email is not Found.";
                txtEmail.Focus();
                return;
            }
            if (txtpass.Text.Trim() == "")
            {
                lblmsg.Text = "Password is required.";
                txtpass.Focus();
                return;
            }
            if (txtConfirmpass.Text.Trim() == "")
            {
                lblmsg.Text = "Confirm Password is required.";
                txtConfirmpass.Focus();
                return;
            }
            if (txtpass.Text != txtConfirmpass.Text)
            {
                lblmsg.Text = "Password doesn't match.";
                return;
            }

            string vMsg = validatePassword(txtpass.Text);
            if (vMsg != "Success")
            {
                lblmsg.Text = vMsg;
                return;

            }
            if (txtSecurityAns.Text == "")
            {
                lblmsg.Text = "Security question answer Required.";
                return;
            }
            SqlDataAdapter das = new SqlDataAdapter("select * from Registration where Email='" + txtEmail.Text + "'", con);
            DataTable dt1 = new DataTable();
            das.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                string SecurityAns = dt1.Rows[0]["SecurityAns"].ToString();
                if (SecurityAns != txtSecurityAns.Text.Trim().ToLower())
                {
                    lblmsg.Text = "Security question answer does not match.";
                    return;
                }
                else
                {
                 
                    string query = @"update Registration set  Password='" + txtpass.Text + "'"
                               
                         + " where Email='" + txtEmail.Text + "'";
                    // string query = "Insert into Registration(Name,Email,Phone,Country,State,Profession,Username,Password,updatedate,createdate)values('" + txtName.Text + "','" + txtEmail.Text.Trim() + "','" + txtphn.Text + "','" + ddlCountry.SelectedValue.Trim() + "','" + ddlState.SelectedValue.Trim() + "','" + ddlProfession.SelectedValue.Trim() + "','" + txtUserName.Text.Trim() + "','" + txtPassword.Text + "',getdate(),getdate())";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblSuccess.Text = "Password Updated";
                    hypLogin.Visible = true;
                    string subject = "Inferme-Password Updated";
                    string body = "Hi " + dt1.Rows[0]["Name"].ToString()+ ",Your Password has been updated";
                    MailMessage mail = new MailMessage();
                    mail.To.Add(txtEmail.Text);
                    mail.From = new MailAddress("abc@gmail.com");//sender email here
                    mail.Subject = subject;
                    mail.Body = body;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("abc@gmail.com", "pass123");//sender email and password here
                    smtp.EnableSsl = true;

                    smtp.Send(mail);

                }
            }
        }
    }
}
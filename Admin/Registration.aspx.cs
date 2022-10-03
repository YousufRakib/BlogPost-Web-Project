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

public partial class Admin_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CountryDropDownListBind();
        }

    }
    private void CountryDropDownListBind()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        string com = "Select * from Countries";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
   
        

        adpt.Fill(dt);
        ddlCountry.DataSource = dt;
        ddlCountry.DataBind();
     
        ddlCountry.DataTextField = "CountryName";
        ddlCountry.DataValueField = "CountryID";
        ddlCountry.DataBind();
        ddlCountry.Items.Insert(0, new ListItem("---Select---", "0"));



    }
    bool IsValidEmail(string strIn)
    {
        // Return true if strIn is in valid e-mail format.
        return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
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
    private int Validation()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        if (txtName.Text == "")
        {
            lblError.Text = "Name field  is required!";
            txtName.Focus();
            return 0;
        }
        if (txtEmail.Text == "")
        {
            lblError.Text = "Email field  is required!";
            txtEmail.Focus();
            return 0;
        }
        if (txtEmail.Text != "")
        {
            bool validEmail = IsValidEmail(txtEmail.Text);
            if (!validEmail)
            {
                lblError.Text = "Invaild Email";
                txtEmail.Focus();
                return 0;
            }
            else
            {
               
                SqlDataAdapter da = new SqlDataAdapter("select * from Registration where Email='" + txtEmail.Text + "'", con);
                DataSet dt = new DataSet();
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    lblError.Text = "Email is Already Used.";
                    txtEmail.Focus();
                    return 0;
                }

            }
        }

        if (ddlCountry.SelectedIndex == 0)
        {
            lblError.Text = "Country field is required.";
            ddlCountry.Focus();
            return 0;
        }

        if (ddlProfession.SelectedIndex == 0)
        {
            lblError.Text = "Profession field is required.";
            ddlProfession.Focus();
            return 0;
        }
       

        if (txtphn.Text == "")
        {
            lblError.Text = "Phone field  is required!";
            txtphn.Focus();
            return 0;
        }
        if (txtphn.Text != "")
        {
            if (txtphn.Text.Length < 8)
            {
                lblError.Text = "Mobile No. is invalid";
                txtphn.Focus();
                return 0;
            }
            SqlDataAdapter da = new SqlDataAdapter("select * from Registration where Phone='" + txtphn.Text + "'", con);
            DataSet dt = new DataSet();
            da.Fill(dt);
            if (dt.Tables[0].Rows.Count > 0)
            {
                lblError.Text = "Mobile No. is Already Used.";
                txtphn.Focus();
                return 0;
            }
        
        }
        if (txtUserName.Text == "")
        {
            lblError.Text = "UserName field  is required!";
            txtUserName.Focus();
            return 0;
        }
        if (txtUserName.Text != "")
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Registration where Username='" + txtUserName.Text + "'", con);
            DataSet dt = new DataSet();
            da.Fill(dt);
            if (dt.Tables[0].Rows.Count > 0)
            {
                lblError.Text = "Username is Already Used.";
                txtEmail.Focus();
                return 0;
            }

        }

        if (txtPassword.Text.Trim() == "")
        {
            lblError.Text = "Password is required.";
            txtPassword.Focus();
            return 0;
        }
        if (txtConfirmPassword.Text.Trim() == "")
        {
            lblError.Text = "Confirm Password is required.";
            txtConfirmPassword.Focus();
            return 0;
        }
        if (txtPassword.Text != txtConfirmPassword.Text)
        {
            lblError.Text = "Password doesn't match.";
            return 0;
        }

        string vMsg = validatePassword(txtPassword.Text);
        if (vMsg != "Success")
        {
            lblError.Text = vMsg;
            return 0;

        }
        if (txtSecurityAns.Text=="")
        {
            lblError.Text = "Security question answer Required.";
            return 0;
        }
        return 1;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Validation() == 0)
        {
            return;

        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        try
        {
            string query = "Insert into Registration(name,email,Phone,Country,State,Profession,Username,Password,updatedate,createdate,SecurityAns)values('" + txtName.Text + "','" + txtEmail.Text.Trim() + "','" + txtphn.Text + "','" + ddlCountry.SelectedValue.Trim() + "','" + ddlState.SelectedValue.Trim() + "','" + ddlProfession.SelectedValue.Trim() + "','" + txtUserName.Text.Trim() + "','" + txtPassword.Text + "',getdate(),getdate(),'"+txtSecurityAns.Text.Trim().ToLower()+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            string subject = "Inferme Registration";
            string body = "Hi " + txtName.Text + ",Your Registration has been completed successfully.";
            MailMessage mail = new MailMessage();
            mail.To.Add(txtEmail.Text);
            mail.From = new MailAddress("abc@gmail.com");//sender email here
            mail.Subject = subject;
            mail.Body = body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("abc@gmail.com", "pas123");//sender email and password here
            smtp.EnableSsl = true;

            smtp.Send(mail);
         //   lblError.Text = "Mail Send .......";
            pnlSuccess.Visible = true;
            lblError.Text = "";
         
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }


    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlState.Items.Clear();
        if (ddlCountry.SelectedValue == "102")
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            string com = "Select * from State where CountryId=" + ddlCountry.SelectedValue + "";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlState.DataSource = dt;
            ddlState.DataBind();
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateId";
            ddlState.DataBind();

        }


    }

    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
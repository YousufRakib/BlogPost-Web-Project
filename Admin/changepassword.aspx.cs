using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Admin_changepassword : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"].ToString() != null)
            {
                hdnUserID.Value = Session["UserID"].ToString();
             
            }

        }
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
        if (txtOldpass.Text == "")
        {
            lblmsg.Text = "old Password is required";
            return;
        }

        if (txtpass.Text == "")
        {
            lblmsg.Text = "Password is required";
            return;
        }
        if (txtcnfrim.Text == "")
        {
            lblmsg.Text = "Confirm is required";
            return;
        }
        string vMsg = validatePassword(txtpass.Text);
        if (vMsg != "Success")
        {
            lblmsg.Text = vMsg;
            return ;

        }
        if (txtOldpass.Text != "")
        {

            SqlDataAdapter da = new SqlDataAdapter("select * from Registration where UserID = '" + hdnUserID.Value + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string oldPass = dt.Rows[0]["Password"].ToString();

                if (txtOldpass.Text != oldPass)
                {
                    lblmsg.Text = "Old Password isn't match";
                    return;
                }
                else
                {
                    if (txtpass.Text.Trim() == txtcnfrim.Text.Trim())
                    {
                        string query = "update Registration set  Password='" + txtpass.Text + "' where UserID='" + hdnUserID.Value + "' ";
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "swal('Good job!', 'Password changed!', 'success').then(function(){location.href = 'dashboard.aspx'});", true);
                    }
                    else
                    {
                        lblmsg.Text = "Confirm Password doesn't match";
                        return;
                    }
                }
            }

        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class SuperAdminMaster : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        SqlDataAdapter da = new SqlDataAdapter("select * from SuperAdmin where Username='" + txtusername.Text + "' and Password='" + txtpass.Text + "' ", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Session["AdminID"] = dt.Rows[0]["UserID"].ToString();
            Session["loginby"] = dt.Rows[0]["Name"].ToString();
            string query = "update Registration set  lastlogin=getdate() where UserID='" + Session["AdminID"].ToString() +"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Username or Password is invalid";

        }
    }

    protected void lnkRegistration_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }
}
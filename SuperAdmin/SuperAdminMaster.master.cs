using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] != null)
        {
            lblName.Text = Session["loginby"].ToString();
            ProfileDetails();
        }
        else
        {
            Response.Redirect("login.aspx");
        }
      
    }

    public   void  ProfileDetails()
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select * from Registration where UserID = '" + Session["AdminID"].ToString() + "'", con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string imgPath = dt.Rows[0]["ImagePath"].ToString();
            if (imgPath != null && imgPath != "")
            {
                string file = imgPath.Substring(imgPath.LastIndexOf("//"));
                string file_name = file.Remove(0, 2);
                img.ImageUrl = "~/upload/User/" + Session["AdminID"].ToString() + "/" + file_name + "";
            }
            else
            {
                img.ImageUrl = "~/upload/AdminLTELogo.png";
              //  img.Visible =;
                //  lblMsg.Text = "Image N/A";
            }
        }
    }
    protected void logut_ServerClick(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("login.aspx");
    }

   
}

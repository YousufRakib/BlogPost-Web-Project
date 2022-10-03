using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdmin_AllUserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"].ToString() == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }
        BlogListdata(0);
    }
    public void BlogListdata(int pageNo)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        string com = "Select * from Registration  order by createdate desc";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();



        adpt.Fill(dt);
        grdUserList.PageIndex = pageNo;
        grdUserList.DataSource = dt;
        grdUserList.DataKeyNames = new string[] { "UserID" };
        grdUserList.DataBind();


    }
    protected void grdUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BlogListdata(e.NewPageIndex);
    }

    protected void grdUserList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
         
            int nUserId = Convert.ToInt32(grdUserList.DataKeys[e.Row.RowIndex].Values[0].ToString());
            hdnUserID.Value = nUserId.ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        
       
           
            HyperLink hyName = (HyperLink)e.Row.FindControl("hyName");

            hyName.NavigateUrl = "Profile.aspx?uId=" + hdnUserID.Value;

            HyperLink hypReadMore = (HyperLink)e.Row.FindControl("hypReadMore");
            hypReadMore.NavigateUrl = "BloggList.aspx?uId=" + hdnUserID.Value;
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    lblcategory.Text = dt.Rows[0]["CategoryName"].ToString();
            //}

            SqlDataAdapter das = new SqlDataAdapter("select * from Registration where UserID = '" + hdnUserID.Value + "'", con);
            DataTable dt1 = new DataTable();
            Image img = (Image)e.Row.FindControl("img");
            das.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                string imgPath = dt1.Rows[0]["ImagePath"].ToString();
                if (imgPath != null && imgPath != "")
                {

                    string file = imgPath.Substring(imgPath.LastIndexOf("//"));
                    string file_name = file.Remove(0, 2);
                    img.ImageUrl = "~/upload/User/" + hdnUserID.Value + "/" + file_name + "";
                }
                else
                {
                    img.ImageUrl = "~/upload/AdminLTELogo.png";
                }
            }

        }
    }
}
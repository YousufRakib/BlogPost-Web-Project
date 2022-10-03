using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PublicUser_blistDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Get("bId") != null )
        {
            hdnbId.Value = Request.QueryString.Get("bId");
            BlogListdata(0);
        }
           
    }
    public void BlogListdata(int pageNo)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        string com = "Select * from Blogg where status='1' and BloggId='"+hdnbId.Value+"' order by createdate desc";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();



        adpt.Fill(dt);
        grdBloggList.PageIndex = pageNo;
        grdBloggList.DataSource = dt;
        grdBloggList.DataKeyNames = new string[] { "BloggId", "category", "ShortDescription", "createUserId" };
        grdBloggList.DataBind();


    }


    protected void grdBloggList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BlogListdata(e.NewPageIndex);

    }
    protected void grdBloggList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int nBlogId = Convert.ToInt32(grdBloggList.DataKeys[e.Row.RowIndex].Values[0].ToString());
            int nCatagoryId = Convert.ToInt32(grdBloggList.DataKeys[e.Row.RowIndex].Values[1].ToString());
            int nUserId = Convert.ToInt32(grdBloggList.DataKeys[e.Row.RowIndex].Values[3].ToString());
            hdnUserID.Value = nUserId.ToString();
            string nShortDescription = grdBloggList.DataKeys[e.Row.RowIndex].Values[2].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Category where CategroyId = '" + nCatagoryId + "'", con);
            DataTable dt = new DataTable();
            Label lblcategory = (Label)e.Row.FindControl("lblcategory");
            Label lblShortDescription = (Label)e.Row.FindControl("lblShortDescription");
          
            if (nShortDescription.Length > 100)
            {
                lblShortDescription.Text = nShortDescription.Substring(0, 100) + "...";
            }
            else
            {
                lblShortDescription.Text = nShortDescription;
            }
            HyperLink hyTitle = (HyperLink)e.Row.FindControl("hyTitle");

            hyTitle.NavigateUrl = "blistDetails.aspx?bId=" + nBlogId ;

          
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblcategory.Text = dt.Rows[0]["CategoryName"].ToString();
            }

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
            }



            SqlDataAdapter dass = new SqlDataAdapter("select * from Blogg where BloggId='"+hdnbId.Value+ "' ", con);
            DataTable dt2 = new DataTable();
           
            Image imgBlogg = (Image)e.Row.FindControl("imgBlogg");

            dass.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                string imgPath = dt2.Rows[0]["BloggImage"].ToString();
                if (imgPath != null && imgPath != "")
                {

                    string file = imgPath.Substring(imgPath.LastIndexOf("//"));
                    string file_name = file.Remove(0, 2);
                    imgBlogg.ImageUrl = "~/upload/Blogg/" + hdnUserID.Value + "/" + file_name + "";
                }
            }



        }
    }
}
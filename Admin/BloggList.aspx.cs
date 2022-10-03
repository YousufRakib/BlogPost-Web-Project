using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BloggList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"].ToString() != null)
            {
                hdnUserID.Value = Session["UserID"].ToString();
                BlogListdata(0);
            }

        }
       
    }
    public void BlogListdata(int pageNo)
    {
      
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        string com = "Select * from Blogg where createUserId='"+ hdnUserID.Value + "' order by createdate desc";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();



        adpt.Fill(dt);
        grdBloggList.PageIndex = pageNo;
        grdBloggList.DataSource = dt;
        grdBloggList.DataKeyNames = new string[] { "BloggId", "category", "ShortDescription" };
        grdBloggList.DataBind();


    }

    protected void grdBloggList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int nBlogId = Convert.ToInt32(grdBloggList.DataKeys[e.Row.RowIndex].Values[0].ToString());
            int nCatagoryId = Convert.ToInt32(grdBloggList.DataKeys[e.Row.RowIndex].Values[1].ToString());
            string nShortDescription = grdBloggList.DataKeys[e.Row.RowIndex].Values[2].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Category where CategroyId = '" + nCatagoryId  + "'", con);
            DataTable dt = new DataTable();
            Label lblcategory = (Label)e.Row.FindControl("lblcategory");
            Label lblShortDescription = (Label)e.Row.FindControl("lblShortDescription");
            LinkButton lnkBloggDelete = (LinkButton)e.Row.FindControl("lnkBloggDelete");
            lnkBloggDelete.CommandArgument = nBlogId.ToString();
            lnkBloggDelete.Attributes.Add("onClick", "return DisplayDeleteConfirm();");
            if (nShortDescription.Length > 100)
            {
                lblShortDescription.Text = nShortDescription.Substring(0, 100) +"...";
            }
            else
            {
                lblShortDescription.Text = nShortDescription;
            }
            HyperLink hyTitle = (HyperLink)e.Row.FindControl("hyTitle");
           
            hyTitle.NavigateUrl = "updateBlogg.aspx?bId=" + nBlogId+"&uId="+hdnUserID.Value;

            HyperLink hypReadMore = (HyperLink)e.Row.FindControl("hypReadMore");
            hypReadMore.NavigateUrl = "updateBlogg.aspx?bId=" + nBlogId + "&uId=" + hdnUserID.Value;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblcategory.Text =  dt.Rows[0]["CategoryName"].ToString();
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

        }
    }

    protected void lnkBloggDelete_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        int nBlogId = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());
        String query = "DELETE FROM Blogg WHERE BloggId ='" + nBlogId + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        con.Open();
        int res = cmd.ExecuteNonQuery();
        if (res > 0)
        {
          
            // Label.Text = "Updated successfully";
        }
        else
        {
           // Label.Text = "Not Updated";
        }
        con.Close();
        BlogListdata(0);
    }

    protected void grdBloggList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BlogListdata(e.NewPageIndex);
      
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (txtStartDate.Text == "")
        {
            lblError.Text = "Start Date Required!";
            return;
        }
        if (txtEndDate.Text == "")
        {
            lblError.Text = "End Date Required!";
            return;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        string com = "Select * from Blogg where createUserId='" + hdnUserID.Value + "' and  (CAST(createdate as DATE) between '" + txtStartDate.Text + "' and '" + txtEndDate.Text + "')";
        //string com = "Select * from Blogg where createUserId='" + hdnUserID.Value + "' and  (createdate >= CONVERT(DATETIME, '"+txtStartDate.Text+ "', 102 )and  createdate < CONVERT(DATETIME, '" + txtEndDate.Text + "', 102 ))  order by createdate desc";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();



        adpt.Fill(dt);
      //  grdBloggList.PageIndex = pageNo;
        grdBloggList.DataSource = dt;
        grdBloggList.DataKeyNames = new string[] { "BloggId", "category", "ShortDescription" };
        grdBloggList.DataBind();
    }
}
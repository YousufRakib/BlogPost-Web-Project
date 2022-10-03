using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminupdateBlogg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminID"].ToString() != null)
            {
                if (Request.QueryString.Get("bId") != null && Request.QueryString.Get("uId") != null)
                {

                    hdnUserID.Value = Request.QueryString.Get("uId");
                    hdnbId.Value = Request.QueryString.Get("bId");
                    CatagoryDropDownListBind();
                    deatil();
                }


            }

        }

    }

    public void deatil()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select * from Blogg where createUserId = '" + hdnUserID.Value + "' and BloggId='" + hdnbId.Value + "'", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtTitle.Text = dt.Rows[0]["BloggTitle"].ToString();
            txtShortDescription.Text = dt.Rows[0]["ShortDescription"].ToString();
            txtEditor.Text = dt.Rows[0]["Description"].ToString();
            CatagoryDropDownListBind();
            string category = dt.Rows[0]["category"].ToString();
            ddlCatagory.SelectedValue = category.Trim();
            lblCatagory.Text = ddlCatagory.SelectedItem.Text;
            SubCatagoryLoad();
            string SubCatagory = dt.Rows[0]["SubCatagoryId"].ToString();
            ddlSubCatagory.SelectedValue = SubCatagory.Trim();
            lblSubCatagory.Text = ddlSubCatagory.SelectedItem.Text;
            ddlStatus.SelectedValue = dt.Rows[0]["Status"].ToString().Trim();
            string imgPath = dt.Rows[0]["BloggImage"].ToString();
            if (imgPath != null && imgPath != "")
            {
                string file = imgPath.Substring(imgPath.LastIndexOf("//"));
                string file_name = file.Remove(0, 2);
                img.ImageUrl = "~/upload/Blogg/" + hdnUserID.Value + "/" + file_name + "";
            }
            else
            {
                img.Visible = false;
                //  lblMsg.Text = "Image N/A";
            }

        }

    }
    private void CatagoryDropDownListBind()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        string com = "Select * from Category";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();



        adpt.Fill(dt);
        ddlCatagory.DataSource = dt;
        ddlCatagory.DataBind();

        ddlCatagory.DataTextField = "CategoryName";
        ddlCatagory.DataValueField = "CategroyId";
        ddlCatagory.DataBind();
        ddlCatagory.Items.Insert(0, new ListItem("---Select---", "0"));



    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (txtTitle.Text == "")
        {
            lblError.Text = "Title field is required";
            txtTitle.Focus();
            return;
        }
        if (ddlCatagory.SelectedIndex == -1)
        {
            lblError.Text = "Catagory field is required";
            ddlCatagory.Focus();
            return;
        }
        if (ddlStatus.SelectedIndex == -1)
        {
            lblError.Text = "Status field is required";
            ddlStatus.Focus();
            return;
        }
        if (txtShortDescription.Text == "")
        {
            lblError.Text = "Short Description field is required";
            txtTitle.Focus();
            return;
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        try
        {

            //string query = "Insert into Blogg(BloggTitle,  ShortDescription, Description, category,Status ,createdate, createby,createUserId)values('" + txtTitle.Text + "','" + txtShortDescription.Text + "','" + txtEditor.Text + "','" + ddlCatagory.SelectedValue.Trim() + "','" + ddlStatus.SelectedValue.Trim() + "',getdate(),'" + Session["loginby"].ToString() + "','" + hdnUserID.Value + "')";
          

            if (file_upload.HasFile)
            {
                if (FileUpload() == 0)
                {
                    return;
                }
                //else
                //{
                //    lblMsg.Text = "Data Saved Successfully";
                //}
            }
            else
            {
                string query = @"update Blogg set  BloggTitle='" + txtTitle.Text + "',"
                       //+ "ShortDescription = '" + txtShortDescription.Text + "',"
                       //+ "Description = '" + txtEditor.Text + "',"
                       //+ "category = '" + ddlCatagory.SelectedValue.Trim() + "',"
                       //  + "SubCatagoryId = '" + ddlSubCatagory.SelectedValue.Trim() + "',"
                       + "Status = '" + ddlStatus.SelectedValue.Trim() + "',"
                        + "UpdateDatebyAdmin = getDate()"+","
                          + "UpdateAdminId = '" + Session["AdminID"].ToString() + "'"
              + " where BloggId='" + hdnbId.Value + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            lblMsg.Text = "Data Saved Successfully";
            ClientScript.RegisterStartupScript(GetType(), "hwa", "swal('Good job!', 'Blogg Updated!', 'success').then(function(){location.href = 'BloggList.aspx'});", true);
            lblError.Text = "";

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }


    }
    private int FileUpload()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);


        HttpFileCollection fileCollection = Request.Files;
        string DestinationPath = null;

        DestinationPath = Server.MapPath("~/upload//Blogg//") + hdnUserID.Value + "//";
        //DestinationPath = Server.MapPath("~/upload//PaymentDetail//") + Session["orderid"].ToString() + "//";
        if (!System.IO.Directory.Exists(DestinationPath))
        {
            System.IO.Directory.CreateDirectory(DestinationPath);
        }

        for (int i = 0; i < fileCollection.Count; i++)
        {

            HttpPostedFile uploadfile = fileCollection[i];
            string fileTitle = "";
            string fileName = "";
            string fileExt = Path.GetExtension(uploadfile.FileName);
            if (uploadfile.ContentLength > 0)
            {

                var image = new Bitmap(uploadfile.InputStream);


                if (image.Width > 1200)
                {
                    lblError.Text = "Image Width cant be more than 1200px";
                    return 0;
                }
                if (image.Height > 800)
                {
                    lblError.Text = "Image Height cant be more than 800px";
                    return 0;
                }
                int iFileSize = uploadfile.ContentLength;
                //if ((iFileSize / (1024 * 2014)) > 2)  // 2MB approx (actually less though)
                //{
                //    lblError.Text = "File size maximum allowed 2MB";

                //    return;
                //}

                if (uploadfile.FileName.Contains(".jpg") || uploadfile.FileName.Contains(".jpeg") || uploadfile.FileName.Contains(".png") || uploadfile.FileName.Contains(".PNG") || uploadfile.FileName.Contains(".gif") || uploadfile.FileName.Contains(".GIF"))
                {



                    fileName = uploadfile.FileName.Replace(fileExt, "") + "_" + DateTime.Now.Ticks.ToString() + fileExt;
                    fileTitle = uploadfile.FileName.Replace(fileExt, "");
                    string outputFileName = Path.Combine(DestinationPath, fileName);
                    System.Drawing.Bitmap bmpImage = new System.Drawing.Bitmap(uploadfile.InputStream);
                    System.Drawing.Imaging.ImageFormat format = bmpImage.RawFormat;
                    int newWidth = 1000;
                    int newHeight = 800;
                    System.Drawing.Bitmap bmpOut = null;
                    bmpOut = new System.Drawing.Bitmap(newWidth, newHeight);
                    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmpOut);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.FillRectangle(System.Drawing.Brushes.White, 0, 0, newWidth, newHeight);
                    g.DrawImage(bmpImage, 0, 0, newWidth, newHeight);
                    bmpImage.Dispose();
                    bmpOut.Save(outputFileName, format);
                    bmpOut.Dispose();


                }
                else
                {
                    lblError.Text = "Only Image can upload";
                    return 0;
                }
                uploadfile.SaveAs(DestinationPath + fileName);
                string fullPath = DestinationPath + fileName;
                string query1 = @"update Blogg set  BloggTitle='" + txtTitle.Text + "',"
                      + "ShortDescription = '" + txtShortDescription.Text + "',"
                      + "Description = '" + txtEditor.Text + "',"
                      + "category = '" + ddlCatagory.SelectedValue.Trim() + "',"

                      + "Status = '" + ddlStatus.SelectedValue.Trim() + "'"
             + " where BloggId='" + hdnbId.Value + "'";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();



                string query = "update Blogg set  BloggImage='" + fullPath + "' where createUserId='" + hdnUserID.Value + "'";
                //string query = "Insert into Blogg(BloggTitle,  ShortDescription, Description, category,Status ,createdate, createby,BloggImage,createUserId)values('" + txtTitle.Text + "','" + txtShortDescription.Text + "','" + txtEditor.Text + "','" + ddlCatagory.SelectedValue.Trim() + "','" + ddlStatus.SelectedValue.Trim() + "',getdate(),'" + Session["loginby"].ToString() + "','" + fullPath + "','" + hdnUserID.Value + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMsg.Text = "Data Saved Successfully";
                lblError.Text = "";




            }
            else
            {
                lblError.Text = "Image required";
                return 0;
            }

        }

        return 1;



    }

    protected void ddlCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubCatagory.Items.Clear();
      
    }

    private void SubCatagoryLoad()
    {
        if (ddlCatagory.SelectedIndex != 0)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            string com = "Select * from SubCatagory where CatagoryId='" + ddlCatagory.SelectedValue + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();



            adpt.Fill(dt);
            ddlSubCatagory.DataSource = dt;
            ddlSubCatagory.DataBind();

            ddlSubCatagory.DataTextField = "SubCatagoryName";
            ddlSubCatagory.DataValueField = "SubCatagoryId";
            ddlSubCatagory.DataBind();
            ddlSubCatagory.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
}
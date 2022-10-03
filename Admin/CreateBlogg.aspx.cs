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

public partial class Admin_CreateBlogg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"].ToString() != null)
            {
                hdnUserID.Value = Session["UserID"].ToString();
                CatagoryDropDownListBind();
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
                string query = "Insert into Blogg(BloggTitle,  ShortDescription, Description, category,Status ,createdate, createby,createUserId)values('" + txtTitle.Text + "','" + txtShortDescription.Text + "','" + txtEditor.Text + "','" + ddlCatagory.SelectedValue.Trim() + "','" + ddlStatus.SelectedValue.Trim() + "',getdate(),'" + Session["loginby"].ToString() + "','" + hdnUserID.Value + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            //else
            //{
            //    lblMsg.Text = "Data Saved Successfully";
            //}
            lblMsg.Text = "Data Saved Successfully";
            ClientScript.RegisterStartupScript(GetType(), "hwa", "swal('Good job!', 'Blogg Created!', 'success').then(function(){location.href = 'BloggList.aspx'});", true);
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
                string query1 = "Insert into Blogg(BloggTitle,  ShortDescription, Description, category,Status ,createdate, createby,createUserId,SubCatagoryId)values('" + txtTitle.Text + "','" + txtShortDescription.Text + "','" + txtEditor.Text + "','" + ddlCatagory.SelectedValue.Trim() + "','" + ddlStatus.SelectedValue.Trim() + "',getdate(),'" + Session["loginby"].ToString() + "','" + hdnUserID.Value + "','"+ddlSubCatagory.SelectedValue.Trim()+"')";
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
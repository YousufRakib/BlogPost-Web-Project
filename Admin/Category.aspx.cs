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

public partial class Admin_Category : System.Web.UI.Page
{
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        lblMsg.Text = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        try
        {
            if (txtName.Text == "")
            {
                lblError.Text = "Catagory Name Required!";
                return;
            }
            if (txtName.Text != "")
            {

                SqlDataAdapter das = new SqlDataAdapter("select * from Category where CategoryName='" + txtName.Text + "'", con);
                DataSet dt1 = new DataSet();
                das.Fill(dt1);
                if (dt1.Tables[0].Rows.Count > 0)
                {
                    lblError.Text = "This Category is Already Used.";
                    txtName.Focus();
                    return;
                }


            }

            HttpFileCollection fileCollection = Request.Files;
            string DestinationPath = null;

            DestinationPath = Server.MapPath("~/upload//Category//") + hdnUserID.Value + "//";
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
                        return;
                    }
                    if (image.Height > 800)
                    {
                        lblError.Text = "Image Height cant be more than 800px";
                        return;
                    }
                    int iFileSize = uploadfile.ContentLength;
                    if ((iFileSize / (1024 * 2014)) > 2)  // 2MB approx (actually less though)
                    {
                        lblError.Text = "File size maximum allowed 2MB";

                        return;
                    }

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
                        return;
                    }
                    uploadfile.SaveAs(DestinationPath + fileName);
                    string fullPath = DestinationPath + fileName;
                    //   
                    //string query = "update tblorder set  path='" + fullPath + "',status='Pending' where orderid='" + Session["orderid"].ToString() + "' ";
                    //string query1 = "update Category set  CategoryImage='" + fullPath + "' where CategroyId='" + hdnCategroyId.Value + "' ";
                    //SqlCommand cmd1 = new SqlCommand(query1, con);
                    //con.Open();
                    //cmd1.ExecuteNonQuery();
                    //con.Close();


                    string query = "Insert into Category(CategoryName,updatedate,createdate,createby,updateby,CategoryImage)values('" + txtName.Text + "',getdate(),getdate(),'" + Session["loginby"].ToString()+ "','" + Session["loginby"].ToString()+ "','" + fullPath + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblMsg.Text = "Data & Image Saved Successfully";
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "swal('Good job!', 'Catagory Created!', 'success').then(function(){location.href = 'dashboard.aspx'});", true);
                    lblError.Text = "";


                }
                else
                {
                    lblError.Text = "Image required";
                    return;
                }
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }
}
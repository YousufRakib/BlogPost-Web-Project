using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"].ToString() != null)
            {
                hdnUserId.Value = Session["UserID"].ToString();
                deatil();
            }
         
        }
       


    }




    public void deatil()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select * from Registration where UserID = '" + Session["UserID"].ToString() + "'", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtUserName.Text = dt.Rows[0]["Username"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtphn.Text = dt.Rows[0]["Phone"].ToString();
            ddlProfession.SelectedValue = dt.Rows[0]["Profession"].ToString();
            CountryDropDownListBind();
            string Country = dt.Rows[0]["Country"].ToString();
            ddlCountry.SelectedValue = Country.Trim();
            StateDropDownListBind();
            ddlState.SelectedValue = dt.Rows[0]["State"].ToString().Trim();
            string imgPath = dt.Rows[0]["ImagePath"].ToString();
            if (imgPath != null && imgPath != "")
            {
                string file = imgPath.Substring(imgPath.LastIndexOf("//"));
                string file_name = file.Remove(0, 2);
                img.ImageUrl = "~/upload/User/" + hdnUserId.Value + "/" + file_name + "";
            }
            else
            {
                img.Visible = false;
              //  lblMsg.Text = "Image N/A";
            }
            Session["loginby"] = dt.Rows[0]["Name"].ToString();
        }

    }
    private void StateDropDownListBind()
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

                SqlDataAdapter da = new SqlDataAdapter("select * from Registration where Email='" + txtEmail.Text + "' and  UserID !='" + Session["UserID"].ToString() + "'", con);
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
            SqlDataAdapter da = new SqlDataAdapter("select * from Registration where Phone='" + txtphn.Text + "' and   UserID !='" + Session["UserID"].ToString() + "'", con);
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
            SqlDataAdapter da = new SqlDataAdapter("select * from Registration where Username='" + txtUserName.Text + "' and  UserID !='" + Session["UserID"].ToString() + "'", con);
            DataSet dt = new DataSet();
            da.Fill(dt);
            if (dt.Tables[0].Rows.Count > 0)
            {
                lblError.Text = "Username is Already Used.";
                txtEmail.Focus();
                return 0;
            }

        }

        if (txtPassword.Text.Trim() != "")
        {
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
        }
      

        return 1;
    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {
       
        if (Validation() == 0)
        {
            lblMsg.Text = "";
            return;
        }
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            string query = @"update Registration set  Name='" + txtName.Text + "',"
                          + "Email = '" + txtEmail.Text + "',"
                          + "Phone = '" + txtphn.Text + "',"
                          + "State = '" + ddlState.SelectedValue.Trim() + "',"
                          + "updatedate = getdate(),"
                          + "Country = '" + ddlCountry.SelectedValue.Trim() + "'"
                 + " where UserID='" + Session["UserID"].ToString() + "'";
            // string query = "Insert into Registration(Name,Email,Phone,Country,State,Profession,Username,Password,updatedate,createdate)values('" + txtName.Text + "','" + txtEmail.Text.Trim() + "','" + txtphn.Text + "','" + ddlCountry.SelectedValue.Trim() + "','" + ddlState.SelectedValue.Trim() + "','" + ddlProfession.SelectedValue.Trim() + "','" + txtUserName.Text.Trim() + "','" + txtPassword.Text + "',getdate(),getdate())";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
          
          
            if (file_upload.HasFile)
            {

                if (FileUpload() == 0)
                {
                    return;
                }
            }
        
            // pnlSuccess.Visible = true;
            lblError.Text = "";
            Session["UserID"] = Session["UserID"].ToString();
            Session["loginby"] = txtName.Text;
         //   Response.Redirect(Request.Url.AbsoluteUri);
            //((Admin_AdminMaster)this.Master).ProfileDetails();
         //   Response.Redirect(Request.Url.AbsoluteUri);
            lblMsg.Text = "Data upadted successfully";
            ClientScript.RegisterStartupScript(GetType(), "hwa", "swal('Good job!', 'Profile Updated!', 'success').then(function(){location.href = 'dashboard.aspx'});", true);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
      // Response.Redirect(Request.Url.AbsoluteUri);
        //lblMsg.Text = "Data upadted successfully";
    }


    private int FileUpload()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        HttpFileCollection fileCollection = Request.Files;
        string DestinationPath = null;

        DestinationPath = Server.MapPath("~/upload//User//") + hdnUserId.Value + "//";
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
                //   
                //string query = "update tblorder set  path='" + fullPath + "',status='Pending' where orderid='" + Session["orderid"].ToString() + "' ";
                string query = "update Registration set  ImagePath='" + fullPath + "' where UserID='" + hdnUserId.Value + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }
          
          
        }

        return 1;

    }
}
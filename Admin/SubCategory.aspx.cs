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

public partial class Admin_SubCategory : System.Web.UI.Page
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
        lblError.Text = "";
        lblMsg.Text = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        try
        {
            if (ddlCatagory.SelectedIndex == 0)
            {
                lblError.Text = "Catagory  Required!";
                return;
            }
            if (txtName.Text == "")
            {
                lblError.Text = "Sub Catagory Name Required!";
                return;
            }
            if (txtName.Text != "")
            {

                SqlDataAdapter das = new SqlDataAdapter("select * from SubCatagory where SubCatagoryName='" + txtName.Text + "' and CatagoryId='"+ddlCatagory.SelectedValue.Trim()+"'", con);
                DataSet dt1 = new DataSet();
                das.Fill(dt1);
                if (dt1.Tables[0].Rows.Count > 0)
                {
                    lblError.Text = "This Sub Category is Already Used.";
                    txtName.Focus();
                    return;
                }
            }
            string query1 = "Insert into SubCatagory(CatagoryId,  SubCatagoryName,createby,createUserId,createdate)values('" + ddlCatagory.SelectedValue.Trim() + "','" + txtName.Text + "','" + Session["loginby"].ToString() + "','" + hdnUserID.Value + "',getdate())";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Data Saved Successfully!";
            ClientScript.RegisterStartupScript(GetType(), "hwa", "swal('Good job!', 'Sub Catagory Created!', 'success').then(function(){location.href = 'dashboard.aspx'});", true);

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }
}
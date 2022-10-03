using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class WelcomeRegistration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString[0] != null)
            {
                lblrequestid.Text = Request.QueryString[0].ToString();
                SqlDataAdapter da = new SqlDataAdapter("select * from tblogin;select * from tblmember where memsponsorid='" + lblrequestid.Text + "'", con);
                DataSet dt = new DataSet();
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count > 0)
                {

                    lblwelcome.Text = dt.Tables[0].Rows[0]["welcomeletter"].ToString();

                }
                if (dt.Tables[1].Rows.Count > 0)
                {
                    lblname.Text = dt.Tables[1].Rows[0]["memname"].ToString();
                    lblphn.Text = dt.Tables[1].Rows[0]["phone"].ToString();
                    lblmail.Text = dt.Tables[1].Rows[0]["email"].ToString();
                    lblpass.Text = dt.Tables[1].Rows[0]["Password"].ToString();
                    lblsponser.Text = dt.Tables[1].Rows[0]["spnorcode"].ToString();
                    lblmemid.Text = dt.Tables[1].Rows[0]["memsponsorid"].ToString();
                    lbldoj.Text = string.Format("{0:dd/MM/yyyy}", dt.Tables[1].Rows[0]["DOJ"]);
                    lbldob.Text = string.Format("{0:dd/MM/yyyy}", dt.Tables[1].Rows[0]["DOB"]);

                }
            }
        }

    }
}
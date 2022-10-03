using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for datatable
/// </summary>
public class datatablefetch
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    public DataTable datatabledata(string query)
    {
        SqlDataAdapter cmd = new SqlDataAdapter(query, con);
        DataTable dt = new DataTable();
        cmd.Fill(dt);
        return dt;


    }
}
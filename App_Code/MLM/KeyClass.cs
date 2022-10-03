using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for KeyClass
/// </summary>
namespace MLM
{
    public class KeyClass
    {
        public KeyClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string GetTreeCode()
        {
            string id = "";
            string QueryString = "select TreeCode from tblmember where memberid=(select max(memberid) from tblmember)";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand(QueryString, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            object ob = cmd.ExecuteScalar();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (ob == DBNull.Value)
            {
                id = "A0";
            }
            else
            {
                int number = int.Parse(ob.ToString().Substring(1));

                string st = ob.ToString().Substring(0, 1);
                if (number >= 99)
                {
                    int asc = 0;
                    asc = Convert.ToInt32(char.Parse(st));
                    if (asc >= 90)
                    {
                        asc = 65;
                        number = number + 1;
                    }
                    else
                    {
                        if ((number + 1).ToString().Length == number.ToString().Length)
                        {
                            number = number + 1;
                        }
                        else
                        {
                            asc = asc + 1;
                            number = (number + 1) / 10;
                        }
                    }
                    char c;
                    c = Convert.ToChar(asc);
                    id = c + number.ToString();
                }
                else
                {
                    number = number + 1;
                    id = st + number.ToString();
                }
            }
            cmd.Dispose();
            con.Dispose();
            return (id);
        }

        public string GetTreeKey(string upline, string membertreecode)
        {
            string id = "";
            string QueryString = "select TreeKey from tblmember where MemSponsorID=@MemberID";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand(QueryString, con);
            cmd.Parameters.AddWithValue("@MemberID", upline);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            object ob = cmd.ExecuteScalar();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            id = ob + "," + membertreecode.ToString();
            cmd.Dispose();
            con.Dispose();
            return (id);
        }
        public string GetSponsorTreeKey(string sponsor, string membertreecode)
        {
            string id = "";
            string QueryString = "select SponsorTreeKey from tblmember where MemSponsorID=@MemberID";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand(QueryString, con);
            cmd.Parameters.AddWithValue("@MemberID", sponsor);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            object ob = cmd.ExecuteScalar();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            id = ob + "," + membertreecode.ToString();
            cmd.Dispose();
            con.Dispose();
            return (id);
        }
    }
}
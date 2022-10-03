using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DBLayer
/// </summary>
/// 

namespace Libraries
{
    public static class  DBLayer
    {
        public static int ScalerReturnInteger(string QueryString, string param1, string param2, string param3, string param4,string param5, string connection)
        {
            int Value;
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.Parameters.AddWithValue("@param4", param4);
            cmd.Parameters.AddWithValue("@param5", param5);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            object ob = cmd.ExecuteScalar();
            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            if (ob == DBNull.Value)
            {
                Value = 0;
            }
            else
            {
                try
                {
                    Value = int.Parse(ob.ToString());
                }
                catch (Exception ex)
                {
                    Value = 0;
                }
            }
            cmd.Dispose();
            CON.Dispose();
            return Value;
        }
        public static int ScalerReturnInteger(string QueryString, string param1, string param2, string param3, string param4, string connection)
        {
            int Value;
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.Parameters.AddWithValue("@param4", param4);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            object ob = cmd.ExecuteScalar();
            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            if (ob == DBNull.Value)
            {
                Value = 0;
            }
            else
            {
                try
                {
                    Value = int.Parse(ob.ToString());
                }
                catch (Exception ex)
                {
                    Value = 0;
                }
            }
            cmd.Dispose();
            CON.Dispose();
            return Value;
        }
        public static int ScalerReturnInteger(string QueryString, string param1, string param2, string param3, string connection)
        {
            int Value;
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            object ob = cmd.ExecuteScalar();
            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            if (ob == DBNull.Value)
            {
                Value = 0;
            }
            else
            {
                try
                {
                    Value = int.Parse(ob.ToString());
                }
                catch (Exception ex)
                {
                    Value = 0;
                }
            }
            cmd.Dispose();
            CON.Dispose();
            return Value;
        }
        public static int ScalerReturnInteger(string QueryString, string param1, string param2, string connection)
        {
            int Value;
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);

            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            object ob = cmd.ExecuteScalar();
            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            if (ob == DBNull.Value)
            {
                Value = 0;
            }
            else
            {
                try
                {
                    Value = int.Parse(ob.ToString());
                }
                catch (Exception ex)
                {
                    Value = 0;
                }
            }
            cmd.Dispose();
            CON.Dispose();
            return Value;
        }
        public static int ScalerReturnInteger(string QueryString, string param1, string connection)
        {
            int Value;
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@param1", param1);

            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            object ob = cmd.ExecuteScalar();
            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            if (ob == DBNull.Value)
            {
                Value = 0;
            }
            else
            {
                try
                {
                    Value = int.Parse(ob.ToString());
                }
                catch (Exception ex)
                {
                    Value = 0;
                }
            }
            cmd.Dispose();
            CON.Dispose();
            return Value;
        }
        public static int ScalerReturnInteger(string QueryString, string connection)
        {
                     
                int Value;
                SqlConnection CON = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(QueryString, CON);
                if (CON.State == ConnectionState.Closed)
                { CON.Open(); }
                object ob = cmd.ExecuteScalar();
                if (CON.State == ConnectionState.Open)
                { CON.Close(); }
                if (ob == DBNull.Value)
                {
                    Value = 0;
                }
                else
                {
                    try
                    {
                        Value = int.Parse(ob.ToString());
                    }
                    catch (Exception ex)
                    {
                        Value = 0;
                    }
                }
                cmd.Dispose();
                CON.Dispose();
                return Value;
            
        }

        public static string ScalerReturnString(string QueryString, string param1, string param2, string param3, string connection)
        {
           
                string Value;
                SqlConnection CON = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(QueryString, CON);
                cmd.Parameters.AddWithValue("@param1", param1);
                cmd.Parameters.AddWithValue("@param2", param2);
                cmd.Parameters.AddWithValue("@param3", param3);
                if (CON.State == ConnectionState.Closed)
                { CON.Open(); }
                object ob = cmd.ExecuteScalar();
                if (CON.State == ConnectionState.Open)
                { CON.Close(); }
                if (ob == DBNull.Value)
                {
                    Value = "0";
                }
                else
                {
                    try
                    {
                        Value = ob.ToString();
                    }
                    catch (Exception ex)
                    {
                        Value = "0";
                    }
                }
                cmd.Dispose();
                CON.Dispose();
                return Value;
           
        }
        public static string ScalerReturnString(string QueryString, string param1, string param2, string connection)
        {
            
                string Value;
                SqlConnection CON = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(QueryString, CON);
                cmd.Parameters.AddWithValue("@param1", param1);
                cmd.Parameters.AddWithValue("@param2", param2);

                if (CON.State == ConnectionState.Closed)
                { CON.Open(); }
                object ob = cmd.ExecuteScalar();
                if (CON.State == ConnectionState.Open)
                { CON.Close(); }
                if (ob == DBNull.Value)
                {
                    Value = "0";
                }
                else
                {
                    try
                    {
                        Value = ob.ToString();
                    }
                    catch (Exception ex)
                    {
                        Value = "0";
                    }
                }
                cmd.Dispose();
                CON.Dispose();
                return Value;
            
        }

        public static string ScalerReturnString(string QueryString, string param1, string param2, string param3, string param4, string connection)
        {

            string Value;
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.Parameters.AddWithValue("@param4", param4);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            object ob = cmd.ExecuteScalar();
            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            if (ob == DBNull.Value)
            {
                Value = "0";
            }
            else
            {
                try
                {
                    Value = ob.ToString();
                }
                catch (Exception ex)
                {
                    Value = "0";
                }
            }
            cmd.Dispose();
            CON.Dispose();
            return Value;

        }
        public static string ScalerReturnString(string QueryString, string param1, string connection)
        {
           
                string Value;
                SqlConnection CON = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(QueryString, CON);
                cmd.Parameters.AddWithValue("@param1", param1);

                { CON.Open(); }
                object ob = cmd.ExecuteScalar();
                if (CON.State == ConnectionState.Open)
                { CON.Close(); }
                if (ob == DBNull.Value)
                {
                    Value = "0";
                }
                else
                {
                    try
                    {
                        Value = ob.ToString();
                    }
                    catch (Exception ex)
                    {
                        Value = "0";
                    }
                }
                cmd.Dispose();
                CON.Dispose();
                return Value;
           
        }
        public static string ScalerReturnString(string QueryString, string connection)
        {
           
                string Value;
                SqlConnection CON = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(QueryString, CON);
                if (CON.State == ConnectionState.Closed)
                { CON.Open(); }
                object ob = cmd.ExecuteScalar();
                if (CON.State == ConnectionState.Open)
                { CON.Close(); }
                if (ob == DBNull.Value)
                {
                    Value = "0";
                }
                else
                {
                    try
                    {
                        Value = ob.ToString();
                    }
                    catch (Exception ex)
                    {
                        Value = "0";
                    }
                }
                cmd.Dispose();
                CON.Dispose();
                return Value;
            }

        public static double ScalerReturnDouble(string QueryString, string param1, string param2, string param3, string connection)
        {
            
                double Value;
                SqlConnection CON = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(QueryString, CON);
                cmd.Parameters.AddWithValue("@param1", param1);
                cmd.Parameters.AddWithValue("@param2", param2);
                cmd.Parameters.AddWithValue("@param3", param3);
                if (CON.State == ConnectionState.Closed)
                { CON.Open(); }
                object ob = cmd.ExecuteScalar();
                if (CON.State == ConnectionState.Open)
                { CON.Close(); }
                if (ob == DBNull.Value)
                {
                    Value = 0;
                }
                else
                {
                    try
                    {
                        Value = double.Parse(ob.ToString());
                    }
                    catch (Exception ex)
                    {
                        Value = 0;
                    }
                }
                cmd.Dispose();
                CON.Dispose();
                return Value;
            
        }
        public static double ScalerReturnDouble(string QueryString, string param1, string param2, string connection)
        {
           
                double Value;
                SqlConnection CON = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(QueryString, CON);
                cmd.Parameters.AddWithValue("@param1", param1);
                cmd.Parameters.AddWithValue("@param2", param2);

                if (CON.State == ConnectionState.Closed)
                { CON.Open(); }
                object ob = cmd.ExecuteScalar();
                if (CON.State == ConnectionState.Open)
                { CON.Close(); }
                if (ob == DBNull.Value)
                {
                    Value = 0;
                }
                else
                {
                    try
                    {
                        Value = double.Parse(ob.ToString());
                    }
                    catch (Exception ex)
                    {
                        Value = 0;
                    }
                }
                cmd.Dispose();
                CON.Dispose();
                return Value;
            
        }
        public static double ScalerReturnDouble(string QueryString, string param1, string connection)
        {
           
                double Value;
                SqlConnection CON = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(QueryString, CON);
                cmd.Parameters.AddWithValue("@param1", param1);

                if (CON.State == ConnectionState.Closed)
                { CON.Open(); }
                object ob = cmd.ExecuteScalar();
                if (CON.State == ConnectionState.Open)
                { CON.Close(); }
                if (ob == DBNull.Value)
                {
                    Value = 0;
                }
                else
                {
                    try
                    {
                        Value = double.Parse(ob.ToString());
                    }
                    catch (Exception ex)
                    {
                        Value = 0;
                    }
                }
                cmd.Dispose();
                CON.Dispose();
                return Value;
           
        }
        public static double ScalerReturnDouble(string QueryString, string connection)
        {            
                double Value;
                SqlConnection CON = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(QueryString, CON);
                if (CON.State == ConnectionState.Closed)
                { CON.Open(); }
                object ob = cmd.ExecuteScalar();
                if (CON.State == ConnectionState.Open)
                { CON.Close(); }
                if (ob == DBNull.Value)
                {
                    Value = 0;
                }
                else
                {
                    try
                    {
                        Value = double.Parse(ob.ToString());
                    }
                    catch (Exception ex)
                    {
                        Value = 0;
                    }
                }
                cmd.Dispose();
                CON.Dispose();
                return Value;
            
        }

       
        /*New Addition*/

        public static DateTime ScalerReturnDate(string QueryString, string connection)
        {
            DateTime Value;
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            object ob = cmd.ExecuteScalar();
            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            if (ob == DBNull.Value)
            {
                Value = DateTime.Parse("08/15/1947");
            }
            else
            {
                try
                {
                    Value = DateTime.Parse(ob.ToString());
                }
                catch (Exception ex)
                {
                    Value = DateTime.Parse("08/15/1947");
                }
            }
            return Value;


        }

        public static DataSet FillDataset(string QueryString, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Connection = CON;
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tablename");

            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            return ds;

        }
        public static DataSet FillDataset(string QueryString, string param1, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Connection = CON;
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tablename");

            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            return ds;

        }
        public static DataSet FillDataset(string QueryString, string param1, string param2, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Connection = CON;
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tablename");

            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            return ds;

        }
        public static DataSet FillDataset(string QueryString, string param1, string param2, string param3, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Connection = CON;
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tablename");

            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            return ds;

        }
        public static DataSet FillDataset(string QueryString, string param1, string param2, string param3, string param4, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Connection = CON;
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.Parameters.AddWithValue("@param4", param4);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tablename");

            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            return ds;

        }
        public static DataSet FillDataset(string QueryString, string param1, string param2, string param3, string param4, string param5, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Connection = CON;
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.Parameters.AddWithValue("@param4", param4);
            cmd.Parameters.AddWithValue("@param5", param5);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "tablename");

            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            return ds;

        }

        public static void ExecuteQuery(string Query, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(Query, CON);
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            cmd.ExecuteNonQuery();
            if (CON.State == ConnectionState.Open)
            {
                CON.Close();
            }
        }
        public static void ExecuteQuery(string Query, string param1, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(Query, CON);
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.ExecuteNonQuery();
            if (CON.State == ConnectionState.Open)
            {
                CON.Close();
            }
        }
        public static void ExecuteQuery(string Query, string param1, string param2, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(Query, CON);
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.ExecuteNonQuery();
            if (CON.State == ConnectionState.Open)
            {
                CON.Close();
            }
        }
        public static void ExecuteQuery(string Query, string param1, string param2, string param3, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(Query, CON);
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.ExecuteNonQuery();
            if (CON.State == ConnectionState.Open)
            {
                CON.Close();
            }
        }

        public static void FillGridView(GridView gv, string QueryString, string connection)
        {
            DataSet dst = new DataSet();
            SqlConnection CON = new SqlConnection(connection);
            dst.Clear();
            dst.Dispose();
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dst);
            if (dst.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = dst;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }

        }
        public static void FillGridView(GridView gv, string QueryString, string param1, string connection)
        {
            DataSet dst = new DataSet();
            SqlConnection CON = new SqlConnection(connection);
            dst.Clear();
            dst.Dispose();
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@param1", param1);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dst);
            if (dst.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = dst;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }

        }
        public static void FillGridView(GridView gv, string QueryString, string param1, string param2, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            DataSet dst = new DataSet();
            dst.Clear();
            dst.Dispose();
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dst);
            if (dst.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = dst;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }

        }
        public static void FillGridView(GridView gv, string QueryString, string param1, string param2, string param3, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            DataSet dst = new DataSet();
            dst.Clear();
            dst.Dispose();
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dst);
            if (dst.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = dst;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }

        }
        public static void FillGridView(GridView gv, string QueryString, string param1, string param2, string param3, string param4, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            DataSet dst = new DataSet();
            dst.Clear();
            dst.Dispose();
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.Parameters.AddWithValue("@param4", param4);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dst);
            if (dst.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = dst;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }

        }
        public static void FillGridView(GridView gv, string QueryString, string param1, string param2, string param3, string param4, string param5, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            DataSet dst = new DataSet();
            dst.Clear();
            dst.Dispose();
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.Parameters.AddWithValue("@param4", param4);
            cmd.Parameters.AddWithValue("@param5", param5);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dst);
            if (dst.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = dst;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }

        }

        public static void FillDropDownSelect(DropDownList cbname, string QueryString, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                cbname.Items.Add(reader.GetString(0));
            }
            reader.Close();
        }

        public static void FillDropDownWithALL(DropDownList cbname, string QueryString, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("ALL");
            while (reader.Read())
            {
                cbname.Items.Add(reader.GetString(0));
            }
            reader.Close();
        }
        public static void FillDropDownSelect(DropDownList cbname, string QueryString, string param1, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                cbname.Items.Add(reader.GetString(0));
            }
            reader.Close();
        }
        public static void FillDropDownSelect(DropDownList cbname, string QueryString, string param1, string param2, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                cbname.Items.Add(reader.GetString(0));
            }
            reader.Close();
        }
        public static void FillDropDownSelect(DropDownList cbname, string QueryString, string param1, string param2, string param3, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                cbname.Items.Add(reader.GetString(0));
            }
            reader.Close();
        }
        public static void FillDropDownSelect(DropDownList cbname, string QueryString, string param1, string param2, string param3, string param4, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.Parameters.AddWithValue("@param4", param4);
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                cbname.Items.Add(reader.GetString(0));
            }
            reader.Close();
        }
        public static void FillDropDownSelect(DropDownList cbname, string QueryString, string param1, string param2, string param3, string param4, string param5, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.Parameters.AddWithValue("@param4", param4);
            cmd.Parameters.AddWithValue("@param5", param5);
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                cbname.Items.Add(reader.GetString(0));
            }
            reader.Close();
        }

        public static void FillDropDownWithValueSelect(DropDownList cbname, string QueryString, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                cbname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillDropDownWithValueSelect(DropDownList cbname, string QueryString, string param1, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                cbname.Items.Add(LItem);
            }
            reader.Close();
        }

        public static void FillDropDownWithValueSelect(DropDownList cbname, string QueryString, string param1, string param2, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                cbname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillDropDownWithValueSelect(DropDownList cbname, string QueryString, string param1, string param2, string param3, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                cbname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillDropDownWithValueSelect(DropDownList cbname, string QueryString, string param1, string param2, string param3, string param4, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.Parameters.AddWithValue("@param4", param4);
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                cbname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillDropDownWithValueSelect(DropDownList cbname, string QueryString, string param1, string param2, string param3, string param4, string param5, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.Parameters.AddWithValue("@param4", param4);
            cmd.Parameters.AddWithValue("@param5", param5);
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("---SELECT---");
            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                cbname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillDropDownWithValueAll(DropDownList cbname, string QueryString, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("ALL");
            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                cbname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillDropDownWithValueAll(DropDownList cbname, string QueryString, string param1, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            SqlDataReader reader = cmd.ExecuteReader();
            cbname.Items.Clear();
            cbname.Items.Add("ALL");
            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                cbname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillCheckBoxListWithValue(CheckBoxList chkname, string QueryString, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            SqlDataReader reader = cmd.ExecuteReader();
            chkname.Items.Clear();

            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                chkname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillCheckBoxListWithValue(CheckBoxList chkname, string QueryString, string param1, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            SqlDataReader reader = cmd.ExecuteReader();
            chkname.Items.Clear();

            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                chkname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillCheckBoxListWithValue(CheckBoxList chkname, string QueryString, string param1, string param2, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            SqlDataReader reader = cmd.ExecuteReader();
            chkname.Items.Clear();

            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                chkname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillCheckBoxListWithValue(CheckBoxList chkname, string QueryString, string param1, string param2, string param3, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            SqlDataReader reader = cmd.ExecuteReader();
            chkname.Items.Clear();

            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                chkname.Items.Add(LItem);
            }
            reader.Close();
        }

        public static void FillRadioButtonListWithValue(RadioButtonList rblname, string QueryString, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            SqlDataReader reader = cmd.ExecuteReader();
            rblname.Items.Clear();

            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                rblname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillRadioButtonListWithValue(RadioButtonList rblname, string QueryString, string param1, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            SqlDataReader reader = cmd.ExecuteReader();
            rblname.Items.Clear();

            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                rblname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillRadioButtonListWithValue(RadioButtonList rblname, string QueryString, string param1, string param2, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            SqlDataReader reader = cmd.ExecuteReader();
            rblname.Items.Clear();

            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                rblname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static void FillRadioButtonListWithValue(RadioButtonList rblname, string QueryString, string param1, string param2, string param3, string connection)
        {
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            SqlDataReader reader = cmd.ExecuteReader();
            rblname.Items.Clear();

            while (reader.Read())
            {
                ListItem LItem = new ListItem();
                LItem.Text = reader.GetValue(1).ToString();
                LItem.Value = reader.GetValue(0).ToString();
                rblname.Items.Add(LItem);
            }
            reader.Close();
        }
        public static DateTime ScalerReturnDate(string QueryString, string param1, string connection)
        {
            DateTime Value;
            SqlConnection CON = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(QueryString, CON);
            cmd.Parameters.AddWithValue("@Param1", param1);
            if (CON.State == ConnectionState.Closed)
            { CON.Open(); }
            object ob = cmd.ExecuteScalar();
            if (CON.State == ConnectionState.Open)
            { CON.Close(); }
            if (ob == DBNull.Value)
            {
                Value = DateTime.Parse("08/15/1947");
            }
            else
            {
                try
                {
                    Value = DateTime.Parse(ob.ToString());
                }
                catch (Exception ex)
                {
                    Value = DateTime.Parse("08/15/1947");
                }
            }
            return Value;


        }

    }
}
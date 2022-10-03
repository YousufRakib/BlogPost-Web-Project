using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

using System.Reflection;


namespace Inferme.App_Code
{
    public class CommonUtility
    {
        public CommonUtility()
        {
            //
            //
            //
        }

        public static bool CheckPreviewCode(string sPreviewCode)
        {
            bool isChecked = false;
            try
            {
                string strPreviewCode = ConfigurationManager.AppSettings["PreviewCode"].ToString();

                List<string> prevCode = strPreviewCode.Split(',').ToList<string>();

                if (prevCode.Where(x => x.Equals(sPreviewCode)).Any())
                {
                    isChecked = true;
                }

                return isChecked;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return isChecked;
            }
        }
        //public static void SaveThumbnailImage(string ImagePath, string NewPath)
        //{
        //    if (!System.IO.Directory.Exists(NewPath))
        //    {
        //        System.IO.Directory.CreateDirectory(NewPath);
        //    }

        //    int Width = 100;
        //    int Height = 75;

        //    string sImageName = Path.GetFileName(ImagePath);


        //    Image imgPhoto = resizeImage(Width, Height, ImagePath);

        //    EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);
        //    // JPEG image codec 
        //    ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
        //    EncoderParameters encoderParams = new EncoderParameters(1);
        //    encoderParams.Param[0] = qualityParam;


        //    imgPhoto.Save(NewPath + "//" + sImageName, jpegCodec, encoderParams);


        //}

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((System.Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        System.Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public static DataTable GetDataTable(string strQ)
        {
            DataTable table = new DataTable();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["InfermeConnectionString"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand(strQ, con);
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                table = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                con.Close();
                con.Dispose();
            }
            return table;
        }

        public static bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static string ExtractNumber(string original) { return new string(original.Where(c => Char.IsDigit(c)).ToArray()); }

        public static string GetPhoneFormat(string str)
        {
            string NoFormat = string.Empty;
            string Phone = string.Empty;

            //NoFormat = str.Replace(" ", "").Replace( "-", "").Replace("(", "").Replace(")", "").Replace("_", "").Replace("+", "").Replace(".","");

            if (str != null && str.Trim().Length > 0)
            {
                NoFormat = ExtractNumber(str);
                if (NoFormat.Length > 9)
                {
                    string countrycode = NoFormat.Substring(0, 3);
                    string Areacode = NoFormat.Substring(3, 3);
                    string number = NoFormat.Substring(6);
                    Phone = "(" + countrycode + ") " + Areacode + "-" + number;
                }
                else
                    Phone = NoFormat;
            }

            return Phone;

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

        private static Random random = new Random();
        public static string RandomString(int length = 50)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

       

  

        //Sort Number Alphabet String list
        //public class SemiNumericComparer : IComparer<string>
        //{

        //    public int Compare(string s1, string s2)
        //    {
        //        int s1r, s2r;
        //        var s1n = IsNumeric(s1, out s1r);
        //        var s2n = IsNumeric(s2, out s2r);

        //        if (s1n && s2n) return s1r - s2r;
        //        else if (s1n) return -1;
        //        else if (s2n) return 1;

        //        var num1 = Regex.Match(s1, @"\d+$");
        //        var num2 = Regex.Match(s2, @"\d+$");

        //        var onlyString1 = s1.Remove(num1.Index, num1.Length);
        //        var onlyString2 = s2.Remove(num2.Index, num2.Length);

        //        if (onlyString1 == onlyString2)
        //        {
        //            if (num1.Success && num2.Success) return Convert.ToInt32(num1.Value) - Convert.ToInt32(num2.Value);
        //            else if (num1.Success) return 1;
        //            else if (num2.Success) return -1;
        //        }

        //        return string.Compare(s1, s2, true);
        //    }

        //    public bool IsNumeric(string value, out int result)
        //    {
        //        return int.TryParse(value, out result);
        //    }
        //}
        public class setDMUserData
        {
            public int CustomerId { get; set; }
            public string Role { get; set; }
        }
    }
}
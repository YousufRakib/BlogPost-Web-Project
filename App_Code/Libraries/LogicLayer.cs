using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for LogicLayer
/// </summary>
/// 
namespace Libraries
{
    public static class LogicLayer
    {


/*New Addition*/

        

        public static void FillDays(DropDownList cbname)
        {
            for (int i = 1; i <= 9; i++)
            {
                cbname.Items.Add("0" + i.ToString());
            }
            for (int i = 10; i <= 31; i++)
            {
                cbname.Items.Add(i.ToString());
            }
        }
        public static void FillYear(DropDownList cbname)
        {
            for (int i = DateTime.Now.Year - 100; i <= DateTime.Now.Year; i++)
            {
                cbname.Items.Add(i.ToString());
            }
        }
        public static void FillMonthNumber(DropDownList cbname)
        {
            for (int i = 1; i <= 9; i++)
            {
                cbname.Items.Add("0" + i.ToString());
            }
            for (int i = 10; i <= 12; i++)
            {
                cbname.Items.Add(i.ToString());
            }

        }
        
        public static void FillMonthNames(DropDownList cbname)
        {
            cbname.Items.Add("January");
            cbname.Items.Add("February");
            cbname.Items.Add("March");
            cbname.Items.Add("April");
            cbname.Items.Add("May");
            cbname.Items.Add("June");
            cbname.Items.Add("July");
            cbname.Items.Add("August");
            cbname.Items.Add("September");
            cbname.Items.Add("October");
            cbname.Items.Add("November");
            cbname.Items.Add("December");
        }
        public static void FillSex(DropDownList cbname)
        {
            cbname.Items.Add("MALE");
            cbname.Items.Add("FEMALE");
        }
        public static void FillMaritalStatus(DropDownList cbname)
        {
            cbname.Items.Add("SINGLE");
            cbname.Items.Add("MARRIED");
            cbname.Items.Add("WIDOW");
            cbname.Items.Add("DIVORCE");
        }
        public static void FillPaymentMode(DropDownList cbname)
        {
            cbname.Items.Add("CASH");
            cbname.Items.Add("CHEQUE");
            cbname.Items.Add("DD");
        }
        public static void FillCategory(DropDownList cbname)
        {
            cbname.Items.Add("GENERAL");
            cbname.Items.Add("SC");
            cbname.Items.Add("ST");
            cbname.Items.Add("OBC");
        }
        public static string[] CastCategory = { "GENERAL", "SC", "ST", "OBC" };

        public static void EmptyTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))
                {
                    ((TextBox)(c)).Text = "";
                }
                if ((c.GetType() == typeof(HtmlInputText)))
                {
                    ((HtmlInputText)(c)).Value = "";
                }
                if ((c.GetType() == typeof(DropDownList)))
                {
                    ((DropDownList)(c)).SelectedIndex = 0;
                }
                if (c.HasControls())
                {
                    EmptyTextBoxes(c);
                }
            }
        }
        public static void DisableTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))
                {
                    ((TextBox)(c)).Enabled = false;
                }
                if ((c.GetType() == typeof(HtmlInputText)))
                {
                    ((HtmlInputText)(c)).Disabled = true;
                }
                if ((c.GetType() == typeof(DropDownList)))
                {
                    ((DropDownList)(c)).Enabled = false;
                }
                if (c.HasControls())
                {
                    DisableTextBoxes(c);
                }
            }
        }
        public static void EnableTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))
                {
                    ((TextBox)(c)).Enabled = true;
                }
                if ((c.GetType() == typeof(HtmlInputText)))
                {
                    ((HtmlInputText)(c)).Disabled = false;
                }
                if ((c.GetType() == typeof(DropDownList)))
                {
                    ((DropDownList)(c)).Enabled = true;
                }
                if (c.HasControls())
                {
                    EnableTextBoxes(c);
                }
            }
        }
        public static string pagename()
        {
            return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath);
        }
        public static void Message(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "alert", "alert('" + message + "');", true);
        }

        /*Check List Box */
        public static string SelectedCheckList(CheckBoxList chkbox)
        {
            string str = "";
            for (int i = 0; i < chkbox.Items.Count; i++)
            {
                if (chkbox.Items[i].Selected == true)
                {
                    if (str == "")
                    {
                        str = chkbox.Items[i].Value;
                    }
                    else
                    {
                        str = str + "," + chkbox.Items[i].Value;
                    }
                }
            }
            return str;
        }
        
        public static string SelectedCheckListClear(CheckBoxList chkbox)
        {
            string str = "";
            for (int i = 0; i < chkbox.Items.Count; i++)
            {
                chkbox.Items[i].Selected = false;
            }
            return str;
        }
        public static void refillCheckList(CheckBoxList chkbox, string Query)
        {
            // string permision = ScalerReturnString("select ','+BlogTopics+',' as BlogTopics from facultyRegistration where facultyId='" + ddlgroup.SelectedValue + "'");
            string permision = "," + Query + ",";
            for (int i = 0; i < chkbox.Items.Count; i++)
            {
                if (permision.Contains("," + chkbox.Items[i].Value + ","))
                {
                    chkbox.Items[i].Selected = true;
                }
            }
        }
        /*Check List Box without comma*/
        public static int SelectedCheckListlen(CheckBoxList chkbox)
        {
            int str = 0;
            for (int i = 0; i < chkbox.Items.Count; i++)
            {
                if (chkbox.Items[i].Selected == true)
                {
                    str = str + 1;
                }
            }
            return str;
        }
        

        /*Redio Button List*/
        public static string SelectedRedioButton(RadioButtonList rbtn)
        {
            string str = "";
            for (int i = 0; i < rbtn.Items.Count; i++)
            {
                if (rbtn.Items[i].Selected == true)
                {
                    if (str == "")
                    {
                        str = rbtn.Items[i].Value;
                    }

                }
            }
            return str;
        }
        public static string SelectedRedioButtonClear(RadioButtonList rbtn)
        {
            string str = "";
            for (int i = 0; i < rbtn.Items.Count; i++)
            {
                rbtn.Items[i].Selected = false;
            }
            return str;
        }
        public static void refillRedio(RadioButtonList rbbox, string Query)
        {
            string permision = Query;

            for (int i = 0; i < rbbox.Items.Count; i++)
            {

                if (permision.Contains(rbbox.Items[i].Value))
                {
                    rbbox.Items[i].Selected = true;
                }

            }

        }
       



    }
}
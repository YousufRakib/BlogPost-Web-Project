using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Inferme.App_Code;

public partial class PublicUser_Public : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadCategory();
       
            LoadData();
            LoadBlog();

        }

        dynamicDivPagination();

    }


    protected void dynamicDivPagination()
    {
        try
        {
            int PageCount = 0;

            string sSQL = string.Empty;
         //   sSQL = @"select   * from blogg order by BloggId desc";

            if (Request.QueryString.Get("cId") != null)
            {
                sSQL = @"select  * from blogg where category='" + Request.QueryString.Get("cId") + "' order by BloggId";
            }
            else
            {
                sSQL = @"select  * from blogg order by BloggId";
            }

            DataTable dtSection = CommonUtility.GetDataTable(sSQL);
            HtmlGenericControl divMain = new HtmlGenericControl("div");

            HtmlGenericControl divRowMain = new HtmlGenericControl("div");
            divRowMain.Attributes["class"] = "row";

            bool isCurrent = false;
            int j = 0;
            int i = 0;
            int k = 1;

          
            foreach (DataRow dr in dtSection.Rows)
            {
                i++;



                HtmlGenericControl divColumncol = new HtmlGenericControl("div");
                divColumncol.Attributes["class"] = "post-content aos-init aos-animate";
                // divColumncol.TagName = "data - aos =zoom-in data - aos - delay = 200";

                HtmlGenericControl divPostTitle = new HtmlGenericControl("div");
                divPostTitle.Attributes["class"] = "post-title  ";

                // Post Image
                HtmlGenericControl divPostImage = new HtmlGenericControl("div");
                divPostImage.Attributes["class"] = "post-image";
                HtmlGenericControl divImage = new HtmlGenericControl("div");

                HtmlGenericControl divColumncolpostinfo = new HtmlGenericControl("div");
                divColumncolpostinfo.Attributes["class"] = "post-info flex-row";




                #region blogg short



                HtmlGenericControl divRowBlogTitle = new HtmlGenericControl("div");
                divRowBlogTitle.Attributes["class"] = "row";

                HtmlGenericControl divBlogTitle = new HtmlGenericControl("div");
                divBlogTitle.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 ";

                HtmlGenericControl divRowBlogDescription = new HtmlGenericControl("div");
                divRowBlogDescription.Attributes["class"] = "row";

                HtmlGenericControl divBlogDescription = new HtmlGenericControl("div");
                divBlogDescription.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 ";

                HtmlGenericControl divRowBlogButton = new HtmlGenericControl("div");
                divRowBlogButton.Attributes["class"] = "row";

                HtmlGenericControl divBlogButton = new HtmlGenericControl("div");
                divBlogButton.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 ";


                HtmlGenericControl AnchorColumnPostTitle = new HtmlGenericControl("a");
                AnchorColumnPostTitle.Attributes["href"] = "blistDetails.aspx?bId=" + dr["BloggId"].ToString();
                AnchorColumnPostTitle.InnerText = dr["BloggTitle"].ToString();
                AnchorColumnPostTitle.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 ";
                AnchorColumnPostTitle.Attributes["style"] = "display:block;";

                HtmlGenericControl AnchorButton = new HtmlGenericControl("a");
                AnchorButton.Attributes["href"] = "blistDetails.aspx?bId=" + dr["BloggId"].ToString();
                AnchorButton.InnerText = "Read more";
                AnchorButton.Attributes["class"] = "btnclass";
                AnchorButton.Attributes["style"] = "display:block;;width:70px;margin-top:10px";








                Label lblPostTitle = new Label();
                lblPostTitle.Text = dr["BloggTitle"].ToString();
                lblPostTitle.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 font-bolder ";

                Label lblDescription = new Label();
                lblDescription.Text = dr["ShortDescription"].ToString();
                lblDescription.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 ";
                lblDescription.Attributes["style"] = "display:block;";

                Label lbluser = new Label();
                lbluser.Attributes["class"] = "fas fa-user text-gray";
                lbluser.Text = " " + dr["createby"].ToString();

                Label lblDate = new Label();
                lblDate.Attributes["class"] = "fas fa-calendar-alt text-gray";

                lblDate.Text = " " + dr["createdate"].ToString();



                Image img = new Image();


                string imgPath = dr["BloggImage"].ToString();
                if (imgPath != null && imgPath != "")
                {
                    string file = imgPath.Substring(imgPath.LastIndexOf("//"));
                    string file_name = file.Remove(0, 2);
                    img.ImageUrl = "~/upload/Blogg/" + dr["createUserId"].ToString() + "/" + file_name + "";
                    ///img.Attributes["style"] = "height:300px ";
                }
                else
                {
                    img.Visible = false;

                }





                #endregion




                HtmlGenericControl hr = new HtmlGenericControl("hr");




                divRowMain.Controls.Add(divColumncol);


                divColumncol.Controls.Add(divPostImage);


                divPostImage.Controls.Add(divImage);
                divImage.Controls.Add(img);
                divPostImage.Controls.Add(divColumncolpostinfo);

                divColumncolpostinfo.Controls.Add(lbluser);
                divColumncolpostinfo.Controls.Add(lblDate);



                divColumncol.Controls.Add(divPostTitle);

                divRowBlogTitle.Controls.Add(divBlogTitle);

                divBlogTitle.Controls.Add(AnchorColumnPostTitle);

                divPostTitle.Controls.Add(divRowBlogTitle);



                divRowBlogDescription.Controls.Add(divBlogDescription);

                divBlogDescription.Controls.Add(lblDescription);
                divPostTitle.Controls.Add(divRowBlogDescription);

                divRowBlogButton.Controls.Add(divBlogButton);
                divBlogButton.Controls.Add(AnchorButton);
                divPostTitle.Controls.Add(divRowBlogButton);




                ////---- Adding row in a div
                divMain.Attributes["id"] = "p" + k;

                j++;
                if (j == 1)
                {
                    divMain.Controls.Add(divRowMain);
                    j = 0;
                    divRowMain = new HtmlGenericControl("div");
                    divRowMain.Attributes["class"] = "row";

                }

                
                    if (!isCurrent)
                    {
                        divMain.Attributes["class"] = "pagedemo _current";
                        isCurrent = true;
                    }
                    else
                    {
                        divMain.Attributes["class"] = "pagedemo";
                        divMain.Attributes["style"] = "display:none;";
                    }

                    divProductsPagination.Controls.Add(divMain);


                    divMain = new HtmlGenericControl("div");
                    divMain.Attributes["class"] = "pagedemo";
                    divMain.Attributes["style"] = "display:none;";
                    k++;
                

            }

           
            
                
            


        }
        catch (Exception ex)
        {
            
        }

    }
    private void LoadCategory()
    {
        string sSQL = string.Empty;
        sSQL = @"SELECT  top(10) * from category";



        DataTable dtSection = CommonUtility.GetDataTable(sSQL);



        HtmlGenericControl divMain = new HtmlGenericControl("div");
        HtmlGenericControl divRowMain = new HtmlGenericControl("div");
        divRowMain.Attributes["class"] = "row";
        foreach (DataRow dr in dtSection.Rows)
        {

            HtmlGenericControl divColumncol = new HtmlGenericControl("div");
            divColumncol.Attributes["class"] = "list-items";
            // divColumncol.Attributes["style"] = "padding-left: 5px; padding-right: 5px;";

            HtmlGenericControl divRowItem = new HtmlGenericControl("div");
            divRowItem.Attributes["class"] = "list-items";
            //divRowItem.Attributes["style"] = "overflow-y: scroll;height:400px";
            HtmlGenericControl divCardBody = new HtmlGenericControl("div");
            divRowItem.Attributes["class"] = "list-items";


            string CategoryName = dr["CategoryName"].ToString();

            HtmlGenericControl divColumnMainCategoryName = new HtmlGenericControl("div");
            divColumnMainCategoryName.Attributes["class"] = "category - list";

            HtmlGenericControl divRowMainTitle = new HtmlGenericControl("div");
            divRowMainTitle.Attributes["class"] = "row";

            DataClasses2DataContext _db = new DataClasses2DataContext();
            int countBlogInIndividualCategory = _db.Bloggs.Where(x => x.category == Convert.ToInt32(dr["CategroyId"].ToString())).Count();

            Label lblTagName = new Label();
            lblTagName.Text = dr["CategoryName"].ToString() +"("+ countBlogInIndividualCategory+")";
            lblTagName.Attributes["class"] = "list - items";

            HtmlGenericControl AnchorColumnPostTitle = new HtmlGenericControl("a");
            AnchorColumnPostTitle.Attributes["href"] = "Public.aspx?cId=" + dr["CategroyId"].ToString();
            AnchorColumnPostTitle.InnerText = dr["CategoryName"].ToString() + "(" + countBlogInIndividualCategory + ")";
            AnchorColumnPostTitle.Attributes["class"] = "list - items";


            divRowMain.Controls.Add(divColumncol);
            divColumncol.Controls.Add(divRowItem);
            divColumncol.Controls.Add(divCardBody);

            divColumnMainCategoryName.Controls.Add(divRowMainTitle);
            divRowMainTitle.Controls.Add(AnchorColumnPostTitle);
            divRowItem.Controls.Add(divRowMainTitle);

            divMain.Controls.Add(divRowMain);
            divMainCardBody.Controls.Add(divMain);


        }
    }
    private void LoadBlog()
    {

        string sSQL = string.Empty;

       // sSQL = @"select top 3  * from blogg order by BloggId desc";

        if (Request.QueryString.Get("cId") != null)
        {
            sSQL = @"select  * from blogg where category='" + Request.QueryString.Get("cId") + "' order by BloggId";
        }
        else
        {
            sSQL = @"select  * from blogg order by BloggId desc";
        }

        DataTable dtSection = CommonUtility.GetDataTable(sSQL);

        

        HtmlGenericControl divMain = new HtmlGenericControl("div");
        HtmlGenericControl divRowMain = new HtmlGenericControl("div");
      //  divRowMain.Attributes["class"] = "post-content";




        foreach (DataRow dr in dtSection.Rows)
        {

            HtmlGenericControl divColumncol = new HtmlGenericControl("div");
            divColumncol.Attributes["class"] = "post-content aos-init aos-animate";
           // divColumncol.TagName = "data - aos =zoom-in data - aos - delay = 200";

            HtmlGenericControl divPostTitle = new HtmlGenericControl("div");
            divPostTitle.Attributes["class"] = "post-title  ";

            // Post Image
            HtmlGenericControl divPostImage = new HtmlGenericControl("div");
            divPostImage.Attributes["class"] = "post-image";
            HtmlGenericControl divImage = new HtmlGenericControl("div");

            HtmlGenericControl divColumncolpostinfo = new HtmlGenericControl("div");
            divColumncolpostinfo.Attributes["class"] = "post-info flex-row";




            #region blogg short



            HtmlGenericControl divRowBlogTitle = new HtmlGenericControl("div");
            divRowBlogTitle.Attributes["class"] = "row";

            HtmlGenericControl divBlogTitle = new HtmlGenericControl("div");
            divBlogTitle.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 ";

            HtmlGenericControl divRowBlogDescription = new HtmlGenericControl("div");
            divRowBlogDescription.Attributes["class"] = "row";

            HtmlGenericControl divBlogDescription = new HtmlGenericControl("div");
            divBlogDescription.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 ";

            HtmlGenericControl divRowBlogButton = new HtmlGenericControl("div");
            divRowBlogButton.Attributes["class"] = "row";

            HtmlGenericControl divBlogButton = new HtmlGenericControl("div");
            divBlogButton.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 ";


            HtmlGenericControl AnchorColumnPostTitle = new HtmlGenericControl("a");
            AnchorColumnPostTitle.Attributes["href"] = "blistDetails.aspx?bId=" + dr["BloggId"].ToString();
            AnchorColumnPostTitle.InnerText= dr["BloggTitle"].ToString();
            AnchorColumnPostTitle.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 ";
            AnchorColumnPostTitle.Attributes["style"] = "display:block;";

            HtmlGenericControl AnchorButton = new HtmlGenericControl("a");
            AnchorButton.Attributes["href"] = "blistDetails.aspx?bId=" + dr["BloggId"].ToString();
            AnchorButton.InnerText = "Read more";
            AnchorButton.Attributes["class"] = "btnclass";
            AnchorButton.Attributes["style"] = "display:block;;width:70px;margin-top:10px";





          


            Label lblPostTitle = new Label();
            lblPostTitle.Text = dr["BloggTitle"].ToString();
            lblPostTitle.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 font-bolder ";

            Label lblDescription = new Label();
            lblDescription.Text = dr["ShortDescription"].ToString();
            lblDescription.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 ";
            lblDescription.Attributes["style"] = "display:block;";

            Label lbluser = new Label();
            lbluser.Attributes["class"] = "fas fa-user text-gray";
            lbluser.Text= " " + dr["createby"].ToString(); 

            Label lblDate = new Label();
            lblDate.Attributes["class"] = "fas fa-calendar-alt text-gray";

            lblDate.Text = " " + Convert.ToDateTime(dr["createdate"].ToString()).ToString("dd-MM-yyyy");




            Image img = new Image();
            

            string imgPath = dr["BloggImage"].ToString();
            if (imgPath != null && imgPath != "")
            {
                string file = imgPath.Substring(imgPath.LastIndexOf("//"));
                string file_name = file.Remove(0, 2);
                img.ImageUrl = "~/upload/Blogg/" + dr["createUserId"].ToString() + "/" + file_name + "";
                ///img.Attributes["style"] = "height:300px ";
            }
            else
            {
                img.Visible = false;
                
            }





            #endregion




            HtmlGenericControl hr = new HtmlGenericControl("hr");
          



            divRowMain.Controls.Add(divColumncol);


            divColumncol.Controls.Add(divPostImage);
            

            divPostImage.Controls.Add(divImage);
            divImage.Controls.Add(img);
            divPostImage.Controls.Add(divColumncolpostinfo);

            divColumncolpostinfo.Controls.Add(lbluser);
            divColumncolpostinfo.Controls.Add(lblDate);



            divColumncol.Controls.Add(divPostTitle);

            divRowBlogTitle.Controls.Add(divBlogTitle);

            divBlogTitle.Controls.Add(AnchorColumnPostTitle); 

            divPostTitle.Controls.Add(divRowBlogTitle);



            divRowBlogDescription.Controls.Add(divBlogDescription);

            divBlogDescription.Controls.Add(lblDescription);
            divPostTitle.Controls.Add(divRowBlogDescription);

            divRowBlogButton.Controls.Add(divBlogButton);
            divBlogButton.Controls.Add(AnchorButton);
            divPostTitle.Controls.Add(divRowBlogButton);














            divColumncol.Controls.Add(hr);

            divMain.Controls.Add(divRowMain);
            div2.Controls.Add(divMain);



        }



    }
    private void LoadData()
    {

        string sSQL = string.Empty;
        if (Request.QueryString.Get("cId") != null)
        {
            sSQL = @"select  * from blogg where category='"+ Request.QueryString.Get("cId") + "' order by BloggId";
        }
        else
        {
            sSQL = @"select  * from blogg order by BloggId";
        }
          



        DataTable dtSection = CommonUtility.GetDataTable(sSQL);
       // ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("Content1");

        HtmlGenericControl divMain = new HtmlGenericControl("div");
        HtmlGenericControl divRowMain = new HtmlGenericControl("div");
        divRowMain.Attributes["class"] = "owl-carousel owl-theme blog-post";




        foreach (DataRow dr in dtSection.Rows)
        {

            HtmlGenericControl divColumncol = new HtmlGenericControl("div");
            divColumncol.Attributes["class"] = "blog-content ";

            HtmlGenericControl divColumncolTitle = new HtmlGenericControl("div");
            divColumncolTitle.Attributes["class"] = "blog-title";

           

     

            #region blogg short
           
         
            Label lblTagName = new Label();
            lblTagName.Text = dr["BloggTitle"].ToString();
            lblTagName.Attributes["class"] = "col-lg-12  col-md-12 col-sm-12 ";
            lblTagName.Attributes["style"] = "border - radius: 3rem";
            ;

            Image img = new Image();
         //   img.ImageUrl = "./assets/Blog-post/post-1.jpg";// dr["BloggImage"].ToString();

            string imgPath = dr["BloggImage"].ToString();
            if (imgPath != null && imgPath != "")
            {
                string file = imgPath.Substring(imgPath.LastIndexOf("//"));
                string file_name = file.Remove(0, 2);
                img.ImageUrl = "~/upload/Blogg/" + dr["createUserId"].ToString() + "/" + file_name + "";
                img.Attributes["style"] = "height:300px ";
            }
            else
            {
                img.Visible = false;
                //  lblMsg.Text = "Image N/A";
            }

            Label lblBlogCreateTime = new Label();
         
           // lblBlogCreateTime.Text = Convert.ToDateTime(dr["createdate"].ToString()).ToString("hh mm :tt");
            DateTime dt = Convert.ToDateTime(dr["createdate"].ToString());
            lblBlogCreateTime.Text =   TimeAgo(dt);

            Label lblCategory = new Label();
            lblCategory.Text = dr["category"].ToString();
            DataClasses2DataContext _db = new DataClasses2DataContext();
            Category obj = _db.Categories.Where(x => x.CategroyId == Convert.ToInt32(dr["category"].ToString())).FirstOrDefault();

            //Button btn = new Button();
            Label btn = new Label();
            btn.Text = obj.CategoryName;
            btn.Attributes["class"] = "btn btn-blog";
          
            #endregion








            divRowMain.Controls.Add(divColumncol);
            divColumncol.Controls.Add(img);

            //Title 1


            divColumncolTitle.Controls.Add(lblTagName);
            divColumncolTitle.Controls.Add(lblBlogCreateTime);
            divColumncolTitle.Controls.Add(btn);
            divColumncol.Controls.Add(divColumncolTitle);

            divMain.Controls.Add(divRowMain);
            div1.Controls.Add(divMain);



        }


       
    }

    public static string TimeAgo(DateTime dt)
    {
        TimeSpan span = DateTime.Now - dt;
        if (span.Days > 365)
        {
            int years = (span.Days / 365);
            if (span.Days % 365 != 0)
                years += 1;
            return String.Format("about {0} {1} ago",
            years, years == 1 ? "year" : "years");
        }
        if (span.Days > 30)
        {
            int months = (span.Days / 30);
            if (span.Days % 31 != 0)
                months += 1;
            return String.Format("about {0} {1} ago",
            months, months == 1 ? "month" : "months");
        }
        if (span.Days > 0)
            return String.Format("about {0} {1} ago",
            span.Days, span.Days == 1 ? "day" : "days");
        if (span.Hours > 0)
            return String.Format("about {0} {1} ago",
            span.Hours, span.Hours == 1 ? "hour" : "hours");
        if (span.Minutes > 0)
            return String.Format("about {0} {1} ago",
            span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
        if (span.Seconds > 5)
            return String.Format("about {0} seconds ago", span.Seconds);
        if (span.Seconds <= 5)
            return "just now";
        return string.Empty;
    }



    
}
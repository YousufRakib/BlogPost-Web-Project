<%@ Page Language="C#" AutoEventWireup="true" CodeFile="blistDetails.aspx.cs" Inherits="PublicUser_blistDetails" %>


<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Inferme </title>

    <!-- Font Awesome Icons -->
    <link rel="stylesheet" href="./css/all.css">


    <!-- --------- Owl-Carousel ------------------->
    <link rel="stylesheet" href="./css/owl.carousel.min.css">
    <link rel="stylesheet" href="./css/owl.theme.default.min.css">

    <!-- ------------ AOS Library ------------------------- -->
    <link rel="stylesheet" href="./css/aos.css">
    <link rel="stylesheet" href="./css/easyPaginate.css">

    <!-- Custom Style   -->
    <link rel="stylesheet" href="./css/Style.css">

    <style>
        .btnclass {
            border-radius: 0;
            padding: 0.7rem 1rem;
            background: var(--sky);
            border: none;
            font-size: 1rem !important;
            font-family: var(--Livvic);
            cursor: pointer;
        }

        .pic {
            display: block;
            -webkit-border-radius: 50%;
            -moz-border-radius: 50%;
            border-radius: 50%;
        }

        .table-bordered td, .table-bordered th {
            border: 0px solid #dee2e6;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <nav class="nav pull-center">
            <div class="nav-menu flex-row">
                <div class="nav-brand">
                    <a href="public.aspx" class="text-gray">Blooger</a>
                </div>
                <div class="toggle-collapse">
                    <div class="toggle-icons">
                        <i class="fas fa-bars"></i>
                    </div>
                </div>
                <div>
                    <ul class="nav-items">
                        <li class="nav-link">
                            <a href="public.aspx">Home</a>
                        </li>
                        <li class="nav-link">
                            <a href="#">Category</a>
                        </li>
                        <li class="nav-link">
                            <a href="#">Archive</a>
                        </li>
                        <li class="nav-link">
                            <a href="#">Pages</a>
                        </li>
                        <li class="nav-link">
                            <a href="#">Contact Us</a>
                        </li>
                    </ul>
                </div>
                <div class="d-none">
                    <div class="social text-gray">
                        <%--     <a href="#"><i class="fab fa-facebook-f"></i></a>
                    <a href="#"><i class="fab fa-instagram"></i></a>
                    <a href="#"><i class="fab fa-twitter"></i></a>
                    <a href="#"><i class="fab fa-youtube"></i></a>--%>
                    </div>
                </div>
            </div>
        </nav>

        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section>
                    <main>

                        <div class="blog">
                            <div class="container">
                                <div class="row justify-content-md-center">
                                    <div class="col-md-12">
                                        <div class="card card-primary">

                                            <div class="card-body">

                                                <asp:ScriptManager runat="server" />


                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="table-responsive-md">
                                                            <asp:GridView ID="grdBloggList" AlternatingRowStyle-BorderWidth="0px " ShowHeader="false" BorderStyle="None" BorderColor="Transparent" CssClass="table table-striped table-bordered" PageSize="10" runat="server" AllowPaging="True" AutoGenerateColumns="false" OnPageIndexChanging="grdBloggList_PageIndexChanging" OnRowDataBound="grdBloggList_RowDataBound">
                                                                <PagerStyle CssClass="pgr" />
                                                                <PagerSettings Position="TopAndBottom" />
                                                                <AlternatingRowStyle CssClass="alternateRowStyle" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="img" runat="server" class="pic" Height="150px" Width="150px" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle CssClass="text-center" />
                                                                        <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <h3 class="mb-2">
                                                                                <asp:HyperLink ID="hyTitle" Font-Names="Lora" runat="server" Font-Italic="true" ForeColor="#000" Text='<%# Eval("BloggTitle") %>'></asp:HyperLink>
                                                                            </h3>


                                                                            <asp:Label ID="Label1" CssClass="fa fa-calendar" ForeColor="#bfbfbf" runat="server" Text='<%#Eval("createdate", "{0:dd-MM-yyyy}")%>'></asp:Label>
                                                                            &nbsp; &nbsp;
                                                <asp:Label ID="lblcategory" runat="server" Text='' CssClass="fa fa-folder" ForeColor="#bfbfbf"></asp:Label>
                                                                            &nbsp;  &nbsp;        
                                                                <asp:Label ID="Label2" runat="server" ForeColor="#bfbfbf" CssClass="fa fa-clock" Text='<%#Eval("createdate", "{0:hh:mm tt}")%>'></asp:Label><br />
                                                                            <asp:Label ID="lblShortDescription" runat="server" ForeColor="#666" Text='<%# Eval("ShortDescription") %>'></asp:Label><br />
                                                                            <br />
                                                                            <br />
                                                                            <asp:Image ID="imgBlogg" runat="server" Height="30%" Width="100%" /><br />
                                                                            <br />
                                                                            <asp:Label ID="lblDescriptio" runat="server" ForeColor="#666" Text='<%# Eval("Description") %>'></asp:Label>
                                                                            <%--  Author- <asp:Label ID="Label3" Font-Italic="true" runat="server" Text='<%# Eval("createby") %>'></asp:Label>--%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle CssClass="text-center" />
                                                                        <ItemStyle HorizontalAlign="Left" Width="98%" />
                                                                    </asp:TemplateField>


                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                </div>


                                            </div>
                                            <!-- /.card-body -->
                                            <asp:HiddenField ID="hdnUserID" runat="server" />

                                            <asp:HiddenField ID="hdnbId" runat="server" />
                                        </div>
                                        <!-- /.card -->
                                    </div>

                                </div>
                            </div>
                        </div>
                    </main>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
          <script src="./js/Jquery3.4.1.min.js"></script>

            <!-- --------- Owl-Carousel js ------------------->
            <script src="./js/owl.carousel.min.js"></script>

            <!-- ------------ AOS js Library  ------------------------- -->
            <script src="./js/aos.js"></script>
            <script src="./js/jquery.easyPaginate.js"></script>

            <!-- Custom Javascript file -->
            <script src="./js/main.js"></script>


    </form>

 
</body>

</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="blistDetails.aspx.cs" Inherits="Public_blistDetails" %>


<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Inferme | Registration</title>

    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/adminlte.min.css">
    <style>
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

<body class="hold-transition login-page">
    <form id="form1" runat="server">


        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <div class="row justify-content-md-center">
                        <div class="col-md-12">
                            <div class="card card-primary">
                                <div class="card-header">
                                    <h3 class="card-title">Home</h3>

                                    <div class="card-tools">
                                        <button type="button"  class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                            Login
                                        </button>
                                     
                                    </div>
                                </div>
                                <div class="card-body">
                                    <h3 class="font-weight-bold " style="color: #0ec626"></h3>
                                    <asp:ScriptManager runat="server" />


                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="table-responsive-md">
                                                <asp:GridView ID="grdBloggList" AlternatingRowStyle-BorderWidth="0px " ShowHeader="false" BorderStyle="None" BorderColor="Transparent" CssClass="table table-striped table-bordered" PageSize="10" runat="server" AllowPaging="True" AutoGenerateColumns="false" OnPageIndexChanging="grdBloggList_PageIndexChanging" OnRowDataBound="grdBloggList_RowDataBound">
                                                    <PagerStyle CssClass="pgr" />
                                                    <PagerSettings Position="TopAndBottom" />
                                                    <AlternatingRowStyle CssClass="alternateRowStyle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="">
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
                                                                <br /><br /> <asp:Image ID="imgBlogg" runat="server"  Height="350px" Width="450px" /><br /><br />
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

                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <!-- jQuery -->
    <script src="plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- AdminLTE App -->
    <script src="dist/js/adminlte.min.js"></script>
</body>

</html>


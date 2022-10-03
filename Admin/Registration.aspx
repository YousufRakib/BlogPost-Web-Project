<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Admin_Registration" %>


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
</head>

<body class="hold-transition login-page">
    <form id="form1" runat="server">


        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content mt-2">
                    <div class="row justify-content-md-center">
                        <div class="col-md-10">
                            <div class="card card-primary">
                                <div class="card-header">
                                    <h3 class="card-title">Registration Form</h3>

                                    <div class="card-tools">
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                            <%--<i class="fas fa-minus"></i>--%>
                                        </button>
                                    </div>
                                </div>
                                <div class="card-body">
                                    <h3 class="font-weight-bold " style="color: #0ec626"></h3>
                                    <asp:ScriptManager runat="server" />


                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">

                                                    <div class="input-group-append">
                                                        <span class="input-group-text">Name<span style="color: red">*</span>
                                                        </span>
                                                    </div>
                                                    <div class="custom-file">
                                                        <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">

                                                    <div class="input-group-append">
                                                        <span class="input-group-text">Email<span style="color: red">*</span></span>
                                                    </div>
                                                    <div class="custom-file">
                                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <%--     <h3 class="font-weight-bold " style="color: #004f87">Personal Detail</h3>--%>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">

                                                    <div class="input-group-append">
                                                        <span class="input-group-text">Country<span style="color: red">*</span>
                                                        </span>
                                                    </div>
                                                    <div class="custom-file">

                                                        <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">

                                                    <div class="input-group-append">
                                                        <span class="input-group-text">State</span>
                                                    </div>
                                                    <div class="custom-file">
                                                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"></asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">

                                                    <div class="input-group-append">
                                                        <span class="input-group-text">Profession<span style="color: red">*</span>
                                                        </span>
                                                    </div>
                                                    <div class="custom-file">
                                                        <asp:DropDownList ID="ddlProfession" runat="server" CssClass="form-control">
                                                            <asp:ListItem Text="---Select---" Value="0" />
                                                            <asp:ListItem Text="Student" Value="1" />
                                                            <asp:ListItem Text="Doctor" Value="2" />
                                                            <asp:ListItem Text="Engineer" Value="3" />
                                                            <asp:ListItem Text="Others" Value="3" />
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">

                                                    <div class="input-group-append">
                                                        <span class="input-group-text">Mobile No.<span style="color: red">*</span>
                                                        </span>
                                                    </div>
                                                    <div class="custom-file">
                                                        <asp:TextBox runat="server" ID="txtphn" CssClass="form-control" />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <div class="input-group">

                                                    <div class="input-group-append">
                                                        <span class="input-group-text">User Name<span style="color: red">*</span>
                                                        </span>
                                                    </div>
                                                    <div class="custom-file">
                                                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                       
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">

                                                    <div class="input-group-append">
                                                        <span class="input-group-text">Password<span style="color: red">*</span>
                                                        </span>
                                                    </div>
                                                    <div class="custom-file">
                                                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <span style="color: red">(Password Must be 8 character,1 lower case,1 upper case,1 special Character,1 digit)</span>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">

                                                    <div class="input-group-append">
                                                        <span class="input-group-text">Confirm Password<span style="color: red">*</span>
                                                        </span>
                                                    </div>
                                                    <div class="custom-file">
                                                        <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                         <div class="col-md-6">
                                         <span style="color: dimgray"><b><i>Last Name of your best Friend?(Security Question)</i></b></span>
                                                 <div class="form-group">
                                                     <div class="input-group">

                                                         <div class="input-group-append">
                                                             <span class="input-group-text">Answer<span style="color: red">*</span>
                                                             </span>
                                                         </div>
                                                         <div class="custom-file">
                                                             <asp:TextBox runat="server" ID="txtSecurityAns"  CssClass="form-control" />

                                                         </div>
                                                     </div>
                                                 </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <div class="text-xl-center">
                                                        <asp:Label ID="lblError" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="text-xl-center">
                                        <asp:Button Text="Submit" runat="server" CssClass="btn btn-success" ID="btnSubmit" OnClick="btnSubmit_Click" />
                                        <%-- <a href="dashboard.aspx" class="btn btn-info">Cancel </a>--%>
                                    </div>

                                    <asp:Panel ID="pnlSuccess" runat="server" Visible="false">

                                        <h3 class="font-weight-bold " style="color: #3f57b9"><span style="color: #0ec626">Congratulation!</span> Your Registration is Successfull.Please Login
                                            <asp:LinkButton ID="lnkLogin" OnClick="lnkLogin_Click" runat="server" Font-Underline="true">here</asp:LinkButton>
                                        </h3>
                                    </asp:Panel>
                                </div>
                            <!-- /.card-body -->
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



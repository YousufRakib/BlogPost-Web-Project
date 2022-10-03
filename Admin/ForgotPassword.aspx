<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Admin_ForgotPassword" %>

<!DOCTYPE html>

<html lang="en">
<head>
    
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Inferme |Forgot Password</title>

    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/adminlte.min.css">
</head>
     <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
             <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updatepnl" runat="server">
       
            <ContentTemplate>
                <div class="login-box">
                    <!-- /.login-logo -->
                    <div class="card card-outline card-primary">
                        <div class="card-header text-center">
                            <a href="index2.html" class="h1"><b>Reset Password</b></a>
                        </div>
                        <div class="card-body">
                        


                            <div class="input-group mb-3">

                                <asp:TextBox runat="server" class="form-control" placeholder="Email" ID="txtEmail" />
                                <div class="input-group-append">
                                    <div class="input-group-text">
                                        <span class="fas fa-envelope"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="input-group mb-3">
                                <asp:TextBox runat="server" type="password" class="form-control" placeholder="New Password" ID="txtpass" />
                                <div class="input-group-append">
                                    <div class="input-group-text">
                                        <span class="fa fa-key"></span>
                                    </div>
                                </div>
                            </div>
                               <div class="input-group mb-3">
                                <asp:TextBox runat="server" type="password" class="form-control" placeholder="Confirm New Password" ID="txtConfirmpass" />
                                <div class="input-group-append">
                                    <div class="input-group-text">
                                        <span class="fa fa-key"></span>
                                    </div>
                                </div>
                            </div>
                               <div class="input-group mb-3">
                                <asp:TextBox runat="server"  class="form-control" placeholder="Last Name of your best Friend?" ID="txtSecurityAns" />
                                <div class="input-group-append">
                                    <div class="input-group-text">
                                        <span class="fas fa-lock"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                             <%--   <div class="col-8 hidden">
                                    <div class="icheck-primary ">
                                        <input type="checkbox" id="remember">
                                        <label for="remember">
                                            Remember Me
                                        </label>
                                    </div>
                                </div>--%>
                                <!-- /.col -->
                                <div class="col-12 justify-content-center">

                                    <asp:Button Text="Submit" runat="server" CssClass="btn btn-primary btn-block" ID="btnSubmit"  OnClick="btnSubmit_Click" />
                                </div>
                                <div class="col-12">
                                    <asp:Label ForeColor="Red" runat="server" ID="lblmsg"  />
                                    <asp:Label ForeColor="Green" Font-Bold="true" runat="server" ID="lblSuccess"  />
                                    <asp:HyperLink ID="hypLogin" NavigateUrl="~/Admin/Login.aspx" Visible="false" runat="server">Please Login</asp:HyperLink>
                                </div>
                                <!-- /.col -->
                            </div>


                            <!-- /.social-auth-links -->

                         

                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
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

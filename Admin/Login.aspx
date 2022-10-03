<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Inferme | Log in (v2)</title>

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
             <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updatepnl" runat="server">
       
            <ContentTemplate>
                <div class="login-box">
                    <!-- /.login-logo -->
                    <div class="card card-outline card-primary">
                        <div class="card-header text-center">
                            <a href="index2.html" class="h1"><b>Inferme</b></a>
                        </div>
                        <div class="card-body">
                            <p class="login-box-msg">Sign in to start your session</p>


                            <div class="input-group mb-3">

                                <asp:TextBox runat="server" class="form-control" placeholder="Username" ID="txtusername" />
                                <div class="input-group-append">
                                    <div class="input-group-text">
                                        <span class="fas fa-envelope"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="input-group mb-3">
                                <asp:TextBox runat="server" type="password" class="form-control" placeholder="Password" ID="txtpass" />
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

                                    <asp:Button Text="Sign In" runat="server" CssClass="btn btn-primary btn-block" ID="btnSignIn" OnClick="btnSignIn_Click" />
                                </div>
                                <div class="col-12">
                                    <asp:Label ForeColor="Red" runat="server" ID="lblmsg" Visible="false" />
                                </div>
                                <!-- /.col -->
                            </div>


                            <!-- /.social-auth-links -->

                            <p class="mb-1">
                                <br/>
                                <%-- <a href="forgot-password.html">I forgot my password</a>--%>
                        Not Register Yet? Click
                                <asp:LinkButton ID="lnkRegistration" Font-Underline="true" OnClick="lnkRegistration_Click" runat="server">Here</asp:LinkButton>
                               <br/>
                                 <asp:HyperLink ID="hypForgetPassword" NavigateUrl="~/Admin/ForgotPassword.aspx" runat="server">Forgot Password?</asp:HyperLink>
                            </p>

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

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="Admin_changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->


        <!-- Main content -->
        <section class="content mt-2">
            <div class="row">
                <div class="col-md-12">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">Change Password</h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">


                        <div class="col-12 justify-content-center">

                            <div class="row justify-content-center">
                                <div class="col-md-8">
                                    <div class="form-group ">
                                        <div class="input-group" style="text-align: center">
                                            <div class="input-group-append">
                                                <span style="color: red">(Password Must be 8 character,1 lower case,1 upper case,1 special Character,1 digit)</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">

                                            <div class="input-group-append">
                                                <span class="input-group-text">Old Password </span>
                                            </div>
                                            <div class="custom-file">
                                                <asp:TextBox runat="server" ID="txtOldpass" TextMode="Password" CssClass="form-control" />

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">

                                            <div class="input-group-append">
                                                <span class="input-group-text">New Password</span>
                                            </div>
                                            <div class="custom-file">
                                                <asp:TextBox runat="server" ID="txtpass" TextMode="Password" CssClass="form-control" />

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">

                                            <div class="input-group-append">
                                                <span class="input-group-text">Confrim Password</span>
                                            </div>
                                            <div class="custom-file">
                                                <asp:TextBox runat="server" ID="txtcnfrim" TextMode="Password" CssClass="form-control" />

                                            </div>

                                        </div>
                                        <asp:Label runat="server" ForeColor="Red" ID="lblmsg" />
                                        <asp:HiddenField ID="hdnUserID" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <hr />
                        <div class="text-xl-center">
                            <asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-danger" OnClick="btnSubmit_Click" />
                            <a href="dashboard.aspx" class="btn btn-info">Cancel </a>
                        </div>
                    </div>
                    <!-- /.card-body -->

                    <!-- /.card -->
                </div>

            </div>

        </section>
        <!-- /.content -->
    </div>
    <asp:Label ID="lblprefix" runat="server" Visible="false" />
</asp:Content>



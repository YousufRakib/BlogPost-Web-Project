<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Admin_Profile" %>

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
                            <h3 class="card-title">Profile</h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-4">
                                    <div class="text-center">
                                        <label for="inputName">Image<span style="color: red">(Max Height 800,Width 1200)</span></label>
                                        <asp:Image runat="server" class="mt-3 mb-3" ID="img" alt="User profile picture" Height="150" Width="280" />
                                        <asp:FileUpload ID="file_upload" class="multi" CssClass="blindInput" runat="server" accept=" .jpg, .jpeg, .png, " AllowMultiple="true" />
                                        <asp:Label runat="server" ID="lblimg" Visible="false" />
                                    </div>
                                </div>
                                <div class="col-8">
                                    <div class="row">
                                        <div class="col-12">
                                            <div class="form-group">

                                                <label for="inputName">UserName</label>

                                                <div class="custom-file">
                                                    <asp:TextBox runat="server" ID="txtUserName" ReadOnly="true" CssClass="form-control" />

                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="inputName">Name</label>

                                                <asp:TextBox runat="server" ID="txtName" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="inputName">Email</label>
                                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="inputName">Country</label>

                                                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="inputName">State</label>

                                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="inputName">Profession</label>
                                                <asp:DropDownList ID="ddlProfession" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="---Select---" Value="0" />
                                                    <asp:ListItem Text="Student" Value="1" />
                                                    <asp:ListItem Text="Doctor" Value="2" />
                                                    <asp:ListItem Text="Engineer" Value="3" />
                                                    <asp:ListItem Text="Others" Value="3" />
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="inputName">Mobile No.</label>
                                                <asp:TextBox runat="server" ID="txtphn" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                              
                                    <div class="row d-none">
                                        <div class="col-6">
                                            <div class="form-group">

                                                <label for="inputName">Password</label>

                                                <div class="custom-file">
                                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />

                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-md-6">

                                            <div class="form-group">
                                                <div class="custom-file">

                                                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label><br />
                                                    <span style="color: red">(Password Must be 8 character,1 lower case,1 upper case,1 special Character,1 digit)</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row d-none">
                                        <div class="col-6">
                                            <div class="form-group">

                                                <label for="inputName">Confirm Password</label>

                                                <div class="custom-file">
                                                    <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" />

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
                                                        <asp:Label ID="lblMsg" Font-Bold="true" ForeColor="Green" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>



                            <div class="col-12">
                                <div class="form-group  float-right">
                                    <asp:HiddenField ID="hdnUserId" runat="server" />
                                    <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" Text="Save Changes" runat="server" class="btn btn-success" />

                                    <a href="dashboard.aspx" class="btn btn-secondary">Cancel</a>
                                </div>
                            </div>
                        </div>

                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
            </div>
        </section>
    </div>


    <!-- /.content -->



</asp:Content>


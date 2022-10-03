<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Admin_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <div class="content-wrapper">
        <section class="content mt-2">
            <div class="row">
                <div class="col-md-12">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">Catagory</h3>

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

                                <div class="col-6">
                                    <asp:Image runat="server" class="mt-3 mb-3" ID="img" alt="User profile picture" Height="150" Width="300" Visible="false" />

                                </div>
                            </div>
                            <div class="row justify-content-center">

                                <div class="col-6">
                                        <label for="inputName">Choose Image<span style="color: red">(Max Height 800,Width 1200,Max 2MB)</span></label>
                                    <asp:FileUpload ID="file_upload" class="multi" CssClass="blindInput" runat="server" accept=" .jpg, .jpeg, .png, " AllowMultiple="true" /><br />
                                    <br />
                                    <asp:Label runat="server" ID="lblimg" Visible="false" />
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-6">
                                    <div class="form-group">
                                        <label for="inputName">Name</label>

                                        <asp:TextBox runat="server" ID="txtName" class="form-control" /><br />
                                        <asp:Label ID="lblError" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label><br />
                                        <asp:Label ID="lblMsg" Font-Bold="true" ForeColor="Green" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-6">
                                    <div class="form-group  float-right">
                                        <asp:HiddenField ID="hdnUserID" runat="server" />
                                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text="Save Changes" runat="server" class="btn btn-success" />

                                        <a href="dashboard.aspx" class="btn btn-secondary">Cancel</a>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </section>
    </div>
</asp:Content>


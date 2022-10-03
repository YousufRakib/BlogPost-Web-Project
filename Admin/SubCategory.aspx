<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="SubCategory.aspx.cs" Inherits="Admin_SubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
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
                                            <div class="form-group">
                                                <label for="inputName">Catagory<span style="color: red">*</span></label>
                                                <asp:DropDownList ID="ddlCatagory" runat="server" class="form-control"></asp:DropDownList>


                                            </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


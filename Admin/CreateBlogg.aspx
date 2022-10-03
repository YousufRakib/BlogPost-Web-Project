<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="CreateBlogg.aspx.cs" Inherits="Admin_CreateBlogg" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <div class="content-wrapper">
        <section class="content mt-2">
            <div class="row">
                <div class="col-md-12">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">Create Blogg</h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                    </div>

                    <div class="card-body">
                        <div class="col-12 justify-content-center">
                            <%--                  <div class="row justify-content-center">

                                <div class="col-6">
                                    <asp:Image runat="server" class="mt-3 mb-3" ID="img" alt="User profile picture" Height="150" Width="300" Visible="false" />

                                </div>
                            </div>
                            <div class="row justify-content-center">

                                <div class="col-6">

                                    <asp:FileUpload ID="file_upload" class="multi" CssClass="blindInput" runat="server" accept=" .jpg, .jpeg, .png, " AllowMultiple="true" /><br />
                                    <br />
                                    <asp:Label runat="server" ID="lblimg" Visible="false" />
                                </div>
                            </div>--%>
                            <div class="row justify-content-center">
                                <div class="col-6">
                                    <div class="form-group">
                                        <label for="inputName">Title<span style="color: red">*</span></label>

                                        <asp:TextBox runat="server" ID="txtTitle" class="form-control" />

                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-3">
                                    <div class="form-group">
                                        <label for="inputName">Catagory<span style="color: red">*</span></label>
                                        <asp:DropDownList ID="ddlCatagory" AutoPostBack="true" OnSelectedIndexChanged="ddlCatagory_SelectedIndexChanged" runat="server" class="form-control"></asp:DropDownList>


                                    </div>
                                </div>
                                <div class="col-3">
                                     <div class="form-group">
                                              <label for="inputName">Sub Catagory</label>
                                           <asp:DropDownList ID="ddlSubCatagory" runat="server" class="form-control"></asp:DropDownList>
                                     </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-3">
                                    <div class="form-group">
                                        <label for="inputName">Status<span style="color: red">*</span></label>
                                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control">
                                            <asp:ListItem Text="---Select---" Value="0" />
                                            <asp:ListItem Text="Active" Value="1" />
                                            <asp:ListItem Text="InActive" Value="2" />

                                        </asp:DropDownList>


                                    </div>
                                </div>
                                <div class="col-3">
                                    <div class="form-group">
                                        <label for="inputName">Image<span style="color: red">(Max Height 800,Width 1200)</span></label>
                                          <asp:FileUpload ID="file_upload" class="multi" CssClass="blindInput" runat="server" accept=" .jpg, .jpeg, .png, " AllowMultiple="true" />
                                    </div>
                                </div>
                            </div>
                             <div class="row justify-content-center">

                             </div>
                            <div class="row justify-content-center">
                                <div class="col-6">
                                    <div class="form-group">
                                        <label for="inputName">Short Description<span style="color: red">*</span></label>

                                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtShortDescription" class="form-control" />

                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="inputName">Description</label>
                                   
                                      <%--  <asp:TextBox ID="txtEditor" class="form-control" runat="server" Width="300" Height="200" />--%>
                                     <FTB:FreeTextBox ID="txtEditor"   runat="server" Width="100%"></FTB:FreeTextBox>  
                                     

                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <div class="col-6">
                                    <div class="form-group  float-right">
                                        <asp:HiddenField ID="hdnUserID" runat="server" />
                                        <asp:Label ID="lblError" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label><br />
                                        <asp:Label ID="lblMsg" Font-Bold="true" ForeColor="Green" runat="server" Text=""></asp:Label>
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


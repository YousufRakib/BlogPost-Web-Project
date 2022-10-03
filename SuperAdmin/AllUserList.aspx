<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="AllUserList.aspx.cs" Inherits="SuperAdmin_AllUserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <div class="content-wrapper">
                <section class="content mt-2">
               <%--     <div class="row">
                        <div class="col-md-4">
                            <label>Start Date</label>
                        </div>
                        <div class="col-md-4">
                            <label for="inputName">End Date</label>
                        </div>
                    </div>
                    <div class="row margin-bottom-5px">
                        <div class="col-md-4">


                            <asp:TextBox runat="server" ID="txtStartDate" TextMode="Date" class="form-control" />
                        </div>
                        <div class="col-md-4">


                            <asp:TextBox runat="server" ID="txtEndDate" TextMode="Date" class="form-control" />
                        </div>
                        <div class="col-md-4">

                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" Text="Search" runat="server" class="btn btn-success" /><br />

                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblError" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>--%>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive-md">
                                <asp:GridView ID="grdUserList" CssClass="table table-striped table-bordered" PageSize="10" runat="server" AllowPaging="True" AutoGenerateColumns="false" OnPageIndexChanging="grdUserList_PageIndexChanging" OnRowDataBound="grdUserList_RowDataBound">
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
                                        <asp:TemplateField >
                                            <ItemTemplate>
                                                <h3 class="mb-2">
                                                    <asp:HyperLink ID="hyName" Font-Underline="true" Font-Names="Lora" runat="server"  ForeColor="#000" Text='<%# Eval("Name") %>'></asp:HyperLink>
                                                </h3>

                                                Account Created:
                                                <asp:Label ID="Label1"  ForeColor="#bfbfbf" runat="server" Text='<%#Eval("createdate", "{0:dd-MM-yyyy}")%>'></asp:Label>
                                                <br/>
                                                <asp:Label ID="lblEmail" runat="server"  CssClass="fa fa-envelope" Text='<%# Eval("Email") %>'></asp:Label>
                                                 <br/>      
                                                <asp:Label ID="Label2" runat="server" CssClass="fa fa-phone" Text='<%#Eval("Phone")%>'></asp:Label>
                                                 <br/>
                                                <asp:HyperLink ID="hypReadMore" Font-Size="15px" runat="server" ForeColor="#1eafed" Text='See Bloggs..>>'></asp:HyperLink>

                                                <%--  Author- <asp:Label ID="Label3" Font-Italic="true" runat="server" Text='<%# Eval("createby") %>'></asp:Label>--%>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Left" Width="98%" />
                                        </asp:TemplateField>
                                     

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <asp:HiddenField ID="hdnUserID" runat="server" />
                    </div>
                </section>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


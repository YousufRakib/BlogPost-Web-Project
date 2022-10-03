<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="BloggList.aspx.cs" Inherits="SuperAdmindashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .pic {
            display: block;
            -webkit-border-radius: 50%;
            -moz-border-radius: 50%;
            border-radius: 50%;
        }

        .row {
            display: -webkit-flex;
            display: -ms-flexbox;
            display: flex;
            -webkit-flex-wrap: wrap;
            -ms-flex-wrap: wrap;
            flex-wrap: wrap;
            margin-right: -7.5px;
            margin-left: -7.5px;
            margin-bottom: 4px;
        }
    </style>
    <script>
        function DisplayDeleteConfirm() {
            if (confirm("Warning! OK will delete this Blogg."))
                return true;
            else
                return false;
        }
    </script>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <div class="content-wrapper">
                <section class="content mt-2">
                    <div class="row">
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
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive-md">
                                <asp:GridView ID="grdBloggList" CssClass="table table-striped table-bordered" PageSize="10" runat="server" AllowPaging="True" AutoGenerateColumns="false" OnPageIndexChanging="grdBloggList_PageIndexChanging" OnRowDataBound="grdBloggList_RowDataBound">
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
                                        <asp:TemplateField HeaderText="My Bloggs">
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
                                                <asp:HyperLink ID="hypReadMore" Font-Size="15px" runat="server" ForeColor="#1eafed" Text='Read More>>'></asp:HyperLink>

                                                <%--  Author- <asp:Label ID="Label3" Font-Italic="true" runat="server" Text='<%# Eval("createby") %>'></asp:Label>--%>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Left" Width="98%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBloggDelete" OnClick="lnkBloggDelete_Click" runat="server" CssClass="fa fa-trash"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
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


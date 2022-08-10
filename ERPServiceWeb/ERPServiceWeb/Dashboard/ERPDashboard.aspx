<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ERPDashboard.aspx.cs" Inherits="ERPServiceWeb.Dashboard.ERPDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/Table.css" rel="stylesheet" />
    <asp:UpdatePanel ID="upl_erpdashboard" runat="server">
        <ContentTemplate>
            <%-- Every 60-minutes time interval this page will auto update.--%>
            <meta http-equiv="refresh" content="3600">
            <link href="../css/CustomCss.css" rel="stylesheet" />
            <div id="content-wrapper" class="d-flex flex-column">
                <h1 class="h3 mb-0 text-gray-800">Dashboard </h1>
                <div id="content">
                    <div class="panel-group">
                    <%--    <div class="panel panel-danger">
                            <div class="panel-heading"><b id="b_title" runat="server"></b></div>
                            <div class="panel-body table-responsive text-nowrap">
                                <asp:GridView ID="grd_erpSignels" runat="server" AutoGenerateColumns="true" ShowHeaderWhenEmpty="true" CssClass="Grid table-hover table table-striped"
                                    OnRowDataBound="grd_erpSignels_RowDataBound">
                                    <EmptyDataRowStyle BackColor="LightCyan" />
                                    <HeaderStyle Font-Size="0.4em" />
                                    <EmptyDataTemplate>
                                        <div align="center" style="font-size: medium; color: red;"><b>No Records Found</b></div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

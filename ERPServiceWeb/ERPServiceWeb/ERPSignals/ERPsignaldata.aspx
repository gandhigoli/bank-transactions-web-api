<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ERPsignaldata.aspx.cs" Inherits="ERPServiceWeb.ERPSignals.ERPsignaldata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <link href="../css/Table.css" rel="stylesheet" />
    <asp:UpdatePanel ID="upl_erpdashboard" runat="server">
        <ContentTemplate>
            <link href="../css/CustomCss.css" rel="stylesheet" />
            <div id="content-wrapper" class="d-flex flex-column">
                <h1 class="h3 mb-0 text-gray-800">Dashboard </h1>
                <div id="content">
                    <div class="panel-group">
                        <div class="panel panel-danger">
                       <%--     <div class="panel-heading"><b id="b_title" runat="server"></b></div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td><span>Date :&nbsp;</span></td>
                                        <td>
                                            <asp:TextBox ID="txt_hoursdate" runat="server" class="form-control" AutoPostBack="true" OnTextChanged="txt_hoursdate_TextChanged"> </asp:TextBox>
                                            <cc1:CalendarExtender ID="cal_hoursdate" PopupButtonID="imgPopup" runat="server" TargetControlID="txt_hoursdate" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                        </td>
                                        <td>&nbsp;&nbsp;<label class="control-label" id="Label1" runat="server">Start Hour :&nbsp;</label>&nbsp;&nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_StartHours" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_StartHours_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;&nbsp;End Hour :&nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_EndHour" runat="server" class="form-control">
                                            </asp:DropDownList></td>
                                        <td>&nbsp;&nbsp;
                                                <asp:Button ID="btn_hoursdata" runat="server" Text="Search" class="btn btn-secondary" OnClick="btn_hoursdata_Click" /></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="panel-body table-responsive text-nowrap">
                                <asp:GridView ID="grd_erpSigneldata" runat="server" AutoGenerateColumns="true" ShowHeaderWhenEmpty="true" CssClass="Grid table-hover table table-striped"
                                    OnRowDataBound="grd_erpSigneldata_RowDataBound">
                                    <EmptyDataRowStyle BackColor="LightCyan" />
                                    <EmptyDataTemplate>
                                        <div align="center" style="font-size: medium; color: red;"><b>No Records Found</b></div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

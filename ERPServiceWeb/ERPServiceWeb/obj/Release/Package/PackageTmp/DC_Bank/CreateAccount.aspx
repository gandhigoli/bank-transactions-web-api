<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="ERPServiceWeb.DC_Bank.CreateAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/Table.css" rel="stylesheet" />
    <asp:UpdatePanel ID="upl_erpdashboard" runat="server">
        <ContentTemplate>
            <%-- Every 60-minutes time interval this page will auto update.--%>
            <%--  <meta http-equiv="refresh" content="3600">--%>
            <link href="../css/CustomCss.css" rel="stylesheet" />
            <section class="vh-100 gradient-custom">
                <div class="container py-5 h-100">
                    <div class="col-12 col-lg-9 col-xl-7">
                        <h3 class="mb-6 pb-2 pb-md-0 mb-md-5">Create Account</h3>

                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label" for="firstName">First Name</label>
                                    <asp:TextBox runat="server" type="text" ID="firstName" class="form-control form-control-lg" />
                                </div>
                            </div>
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label" for="lastName">Last Name</label>
                                    <asp:TextBox runat="server" type="text" ID="lastName" class="form-control form-control-lg" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label for="birthdayDate" class="form-label">Birthday</label>
                                    <asp:TextBox runat="server" type="text" class="form-control form-control-lg" ID="birthdayDate" />
                                </div>
                            </div>

                            <div class="col-md-6 mb-4 d-flex align-items-center">
                                <div class="form-outline datepicker w-100">
                                    <h6 class="mb-2 pb-1">Gender </h6>

                                    <div class="form-check form-check-inline">
                                        <asp:RadioButtonList ID="rdb_gender" runat="server" class="form-check-input" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="&nbsp; Male &nbsp;" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="&nbsp; Female &nbsp;" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="&nbsp; Other &nbsp;" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4 pb-2">

                                <div class="form-outline">
                                    <label class="form-label" for="emailAddress">Email</label>
                                    <asp:TextBox runat="server" type="email" ID="emailAddress" class="form-control form-control-lg" />
                                </div>

                            </div>
                            <div class="col-md-6 mb-4 pb-2">

                                <div class="form-outline">
                                    <label class="form-label" for="phoneNumber">Phone Number</label>
                                    <asp:TextBox runat="server" type="tel" ID="phoneNumber" class="form-control form-control-lg" />
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <label class="form-label select-label">Randon Account ID</label>
                                <asp:Label runat="server" type="text" class="form-control form-control-lg" ID="txtaccountid" />
                                <input class="btn btn-primary btn-lg" type="submit" id="btnrandomAccountNumber" value="Generate IBAN" />

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4 pb-2">

                                <div class="form-outline">
                                    <label class="form-label" for="balance">Balance</label>
                                    <asp:TextBox runat="server" type="balance" ID="txtbalance" class="form-control form-control-lg" TextMode="Number" />
                                </div>
                            </div>
                        </div>

                        <div class="mt-4 pt-2" align="right">
                            <input class="btn btn-primary btn-lg" type="submit" value="Submit" />
                        </div>
                    </div>
            </section>
            <%--      <div id="content-wrapper" class="d-flex flex-column">
                <h1 class="h3 mb-0 text-gray-800">Create Account </h1>
                <div id="content">
                        <div class="panel-group">
                        <div class="panel panel-danger">
                            <div class="panel-heading"><b id="b_title" runat="server"></b></div>
                            <div class="panel-body table-responsive text-nowrap">
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

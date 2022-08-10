<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransferMoney.aspx.cs" Inherits="ERPServiceWeb.DC_Bank.TransferMoney" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <link href="../css/Table.css" rel="stylesheet" />
    <asp:UpdatePanel ID="upl_erpdashboard" runat="server">
        <ContentTemplate>
            <%-- Every 60-minutes time interval this page will auto update.--%>
          <%--  <meta http-equiv="refresh" content="3600">--%>
            <link href="../css/CustomCss.css" rel="stylesheet" />
       <%--     <div id="content-wrapper" class="d-flex flex-column">
                <h1 class="h3 mb-0 text-gray-800">Transfer Money </h1>
                <div id="content">
                    <div class="panel-group">
                        <div class="panel panel-danger">
                            <div class="panel-heading"><b id="b_title" runat="server"></b></div>
                            <div class="panel-body table-responsive text-nowrap">
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div
            </div>>--%>

             <section class="vh-100 gradient-custom">
                <div class="container py-5 h-100">
                    <div class="col-12 col-lg-9 col-xl-7">
                        <h3 class="mb-6 pb-2 pb-md-0 mb-md-5">Transfer Money</h3>
                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label" for="firstName">From Account Number</label>
                                    <asp:TextBox runat="server" type="text" ID="txtfromaccountnumber" TextMode="Number"  class="form-control form-control-lg" />
                                </div>
                            </div>
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <asp:Button runat="server" class="btn btn-primary btn-lg" type="submit" ID="btnFromAccount" Text="Show Details" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label select-label">Name</label>
                                    <asp:Label runat="server" class="form-control form-control-lg" ID="txtname" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label select-label">Current Balance</label>
                                    <asp:Label runat="server" class="form-control form-control-lg" ID="lblcurrentbalance" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                             <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label" for="lastName">Destination Account</label>
                                    <asp:TextBox runat="server" type="text" ID="txtDestinationAccount" TextMode="Number" class="form-control form-control-lg" />
                                </div>
                            </div>
                        </div>
               
                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <label class="form-label select-label">Transfer Amount</label>
                                <asp:TextBox runat="server" class="form-control form-control-lg" ID="txtdepositamount" />
                            </div>
                            <div class="col-md-6 mb-4" align="right">
                            <asp:Button class="btn btn-primary btn-lg" runat="server" Text="Submit" />
                            </div>
                        </div>

                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

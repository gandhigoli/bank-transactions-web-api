<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransferMoney.aspx.cs" Inherits="ERPServiceWeb.DC_Bank.TransferMoney" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/Table.css" rel="stylesheet" />

    <script type="text/javascript" src="https://cdn.jsdelivr.net/lodash/4.17.4/lodash.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <script type="text/javascript" src="http://chancejs.com/chance.min.js"></script>

    <asp:UpdatePanel ID="upl_erpdashboard" runat="server">
        <ContentTemplate>
            <link href="../css/CustomCss.css" rel="stylesheet" />
            <section class="vh-100 gradient-custom">
                <div class="container py-5 h-100">
                    <div class="col-12 col-lg-9 col-xl-7">
                        <h3 class="mb-6 pb-2 pb-md-0 mb-md-5">Transfer Money</h3>
                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label" for="firstName">From Account Number</label>
                                    <asp:TextBox runat="server" type="text" ID="txtfromaccountnumber" class="form-control form-control-sm" ClientIDMode="Static" />
                                    <b><span id="spnfromaccountnumber" style="color: red; font-family: monospace;"></span></b>
                                </div>
                            </div>
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <input class="btn btn-secondary btn-sm" id="btnFromAccount" value="Get Details" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label select-label">From Account Name</label>
                                    <asp:Label runat="server" class="form-control form-control-sm" ID="txtfromaccountname" ClientIDMode="Static" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label select-label">from Account Current Balance</label>
                                    <asp:Label runat="server" class="form-control form-control-sm" ID="lblfromaccountcurrentbalance" ClientIDMode="Static" />
                                    <b><span id="spnfromaccountcurrentbalance" style="color: red; font-family: monospace;"></span></b>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label" for="lastName">Destination Account</label>
                                    <asp:TextBox runat="server" type="text" ID="txtDestinationAccount" class="form-control form-control-sm" ClientIDMode="Static" />
                                    <b><span id="spnDestinationAccount" style="color: red; font-family: monospace;"></span></b>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <label class="form-label select-label">Transfer Amount</label>
                                <asp:TextBox runat="server" class="form-control form-control-sm" ID="txtdepositamount" ClientIDMode="Static" />
                                <b><span id="spndepositamount" style="color: red; font-family: monospace;"></span></b>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 mb-4" align="right">
                                <input class="btn btn-primary btn-sm" value="Submit" id="btnTransforMoney" />&nbsp;
                            <input class="btn btn-primary btn-sm" value="Clear" id="btnclear" />
                            </div>
                        </div>
                    </div>
                </div>

            </section>
            <script src="../Static/CreateTransferMoney.js"></script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

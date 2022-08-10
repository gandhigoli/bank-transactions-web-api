<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deposit.aspx.cs" Inherits="ERPServiceWeb.DC_Bank.Deposit" %>

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
                        <h3 class="mb-6 pb-2 pb-md-0 mb-md-5">Deposit Amout</h3>
                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label" for="firstName">Enter Account Number</label>
                                     <asp:TextBox runat="server" type="text" ID="txtenteraccountnumber" class="form-control form-control-sm" ClientIDMode="Static" />
                                   <%-- <input class="form-control" id="txtenteraccountnumber" type="text">--%>
                                    <b><span id="spnenteraccountnumber" style="color: red; font-family: monospace;"></span></b>
                                </div>
                            </div>
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <input class="btn btn-secondary btn-sm" id="btngetAccountinformationdata" value="Get Details" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label select-label">Name</label>
                                     <asp:Label runat="server" class="form-control form-control-sm" ID="txtname" ClientIDMode="Static" />
                                  <%--  <input class="form-control" id="txtname" type="text">--%>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <label class="form-label select-label">Current Balance</label>
                                     <asp:Label runat="server" class="form-control form-control-sm" ID="lblcurrentbalance" ClientIDMode="Static" />
                                    <%--<input class="form-control" id="lblcurrentbalance" type="text">--%>
                                    <b><span id="spncurrentbalance" style="color: red; font-family: monospace;"></span></b>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <label class="form-label select-label">Mode</label>
                                 <asp:DropDownList runat="server" class="form-control form-control-sm" ID="ddlmode" ClientIDMode="Static">
                                    <asp:ListItem Text="--select--" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Cash" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Cheque" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                               <%-- <select id="ddlmode" class="form-control form-control-sm">
                                    <option value="-1">--select--</option>
                                    <option value="0">Cash</option>
                                    <option value="1">Cheque</option>
                                </select>--%>
                                <b><span id="spnmode" style="color: red; font-family: monospace;"></span></b>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <label class="form-label select-label">Deposit Amount</label>
                                 <asp:TextBox runat="server" class="form-control form-control-sm" ID="txtdepositamount" ClientIDMode="Static" />
                               <%-- <input class="form-control" id="txtdepositamount" type="text">--%>
                                <b><span id="spndepositamount" style="color: red; font-family: monospace;"></span></b>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-12 mb-4">
                                <div class="col-md-12 mb-4" align="right">
                                    <input class="btn btn-primary btn-sm" value="Submit" id="btnsubmit" />&nbsp;
                           <%-- <input class="btn btn-primary btn-sm" value="Clear" id="btnclear" />--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <script src="../Static/CreateDeposit.js"></script>
          <%--  <link href="../Scripts/bootstrap.min.css" rel="stylesheet" />--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

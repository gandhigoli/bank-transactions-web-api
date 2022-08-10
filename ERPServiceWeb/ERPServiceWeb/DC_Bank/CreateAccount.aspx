<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="ERPServiceWeb.DC_Bank.CreateAccount" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/Table.css" rel="stylesheet" />

    <script type="text/javascript" src="https://cdn.jsdelivr.net/lodash/4.17.4/lodash.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <script type="text/javascript" src="http://chancejs.com/chance.min.js"></script>

    <script src="../Static/mapp4.js"></script>
    <script src="../Static/countries.js"></script>
    <script src="../Static/functions.js"></script>

    <script type="text/javascript">
        function clientValidate() {
            var divVal = document.getElementById('demo');
            //alert(divVal.innerHTML);
            return true;
        }

        function executeAfter() {
            alert("execute after");
        }
    </script>

    <link href="../css/CustomCss.css" rel="stylesheet" />
    <section class="vh-100 gradient-custom">
        <div class="container py-5 h-100">
            <div class="col-12 col-lg-9 col-xl-7">
                <h3 class="mb-6 pb-2 pb-md-0 mb-md-5">Create Account</h3>

                <div class="row">
                    <div class="col-md-6 mb-4">
                        <div class="form-outline">
                            <label class="form-label" for="firstName">First Name</label>
                            <asp:TextBox runat="server" type="text" ID="txtfirstName" class="form-control form-control-sm" ClientIDMode="Static" />
                            <b><span id="spnfirstName" style="color: red; font-family: monospace;"></span></b>
                        </div>
                    </div>
                    <div class="col-md-6 mb-4">
                        <div class="form-outline">
                            <label class="form-label" for="lastName">Last Name</label>
                            <asp:TextBox runat="server" type="text" ID="txtlastName" class="form-control form-control-sm" ClientIDMode="Static" />
                            <b><span id="spnlastName" style="color: red; font-family: monospace;"></span></b>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6 mb-4">
                        <div class="form-outline">
                            <label for="birthdayDate" class="form-label">Birthday</label>
                            <asp:TextBox runat="server" type="text" class="form-control form-control-sm" ID="txtbirthdayDate" ClientIDMode="Static" placeholder="dd/MM/yyyy"/>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbirthdayDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <b><span id="spnbirthdayDate" style="color: red; font-family: monospace;"></span></b>
                        </div>
                    </div>

                    <div class="col-md-6 mb-4 d-flex align-items-center">
                        <div class="form-outline datepicker w-100">
                            <h6 class="mb-2 pb-1">Gender </h6>
                            <div class="form-check form-check-inline">
                                <asp:RadioButtonList ID="rdb_gender" runat="server" class="form-check-input" RepeatDirection="Horizontal" ClientIDMode="Static">
                                    <asp:ListItem Text="&nbsp; Male &nbsp;" Value="0" Selected="True"></asp:ListItem>
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
                            <asp:TextBox runat="server" type="email" ID="txtemailAddress" class="form-control form-control-sm" ClientIDMode="Static" />
                            <b><span id="spnemail" style="color: red; font-family: monospace;"></span></b>
                        </div>

                    </div>
                    <div class="col-md-6 mb-4 pb-2">
                        <div class="form-outline">
                            <label class="form-label" for="phoneNumber">Phone Number</label>
                            <asp:TextBox runat="server" type="tel" ID="txtphoneNumber" class="form-control form-control-sm" ClientIDMode="Static" />
                            <b><span id="spnphonenumber" style="color: red; font-family: monospace;"></span></b>
                        </div>

                    </div>
                </div>

                <div class="row">
                    <div class="col-6">
                        <div class="center_align">
                            <select id="country_input" align="middle" onchange="display(this.value);" class="form-control form-control-sm"></select>
                        </div>
                    </div>

                    <div class="col-12">
                        <label class="form-label select-label">Randon Account ID <b>:</b></label>
                        <asp:Label ID="lbldemo" runat="server" ClientIDMode="Static" Font-Bold="true" Font-Size="Large" ForeColor="red"></asp:Label>
                        <br />
                        <input type="button" onclick="display();" id="gen_button" align="middle" class="btn btn-secondary btn-sm" value="Generate IBAN" />
                        <b><span id="spnaccountid" style="color: red; font-family: monospace;"></span></b>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6 mb-4 pb-2">
                        <div class="form-outline">
                            <label class="form-label" for="balance">Balance</label>
                            <asp:TextBox runat="server" type="balance" ID="txtbalance" class="form-control form-control-sm" TextMode="Number" ClientIDMode="Static" />
                            <b><span id="spnbalance" style="color: red; font-family: monospace;"></span></b>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12 mb-4 d-flex align-items-center">
                        <div class="form-outline datepicker w-100">
                            <input class="btn btn-primary btn-sm" value="Submit" id="btnSubmit" />
                            &nbsp;&nbsp;
                            <input class="btn btn-primary btn-sm" value="Clear" id="btnclear" />

                        </div>
                    </div>

                </div>
            </div>
        </div>

    </section>
    <script src="../Static/CreateAccount.js"></script>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

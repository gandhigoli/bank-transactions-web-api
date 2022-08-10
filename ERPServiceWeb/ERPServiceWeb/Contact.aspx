<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ERPServiceWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upl1" runat="server">
        <ContentTemplate>
            <link href="../css/CustomCss.css" rel="stylesheet" />
            <div id="wrapper" class="container" style="max-width: 1600px">
                <div id="content-wrapper" class="d-flex flex-column">



                    <h2><%: Title %>.</h2>
                    <h3>Your contact page.</h3>
                    <address>
                        One Microsoft Way<br />
                        Redmond, WA 98052-6399<br />
                        <abbr title="Phone">P:</abbr>
                        425.555.0100
                    </address>
                    <address>
                        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
                        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
                    </address>




                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

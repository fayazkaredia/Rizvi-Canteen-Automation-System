<%@ Page Title="" Language="C#" MasterPageFile="~/a_site.Master" AutoEventWireup="true" CodeBehind="MainLogin.aspx.cs" Inherits="Canteen_Automation_System.MainLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <center><span class="auto-style2">Choose your Login
    </span></center>
    <table class="auto-style1">
        <tr>
            <td align="center" width="50%">&nbsp;</td>
            <td align="center" width="50%">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" width="50%">&nbsp;</td>
            <td align="center" width="50%">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="border-right-style: solid; border-right-width: 1px; border-right-color: #808080" width="50%">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/Admin.png" PostBackUrl="~/a_login.aspx" Width="40%" />
            </td>
            <td align="center" width="50%">
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/Canteen.png" PostBackUrl="~/c_login.aspx" Width="45%" />
            </td>
        </tr>
        <tr>
            <td align="center" width="50%">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="X-Large" PostBackUrl="~/a_login.aspx">Admin Login</asp:LinkButton>
            </td>
            <td align="center" width="50%">
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="X-Large" PostBackUrl="~/c_login.aspx">Canteen Login</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
&nbsp;<br />
&nbsp;<br />
&nbsp;<br />
&nbsp;<br />
</asp:Content>

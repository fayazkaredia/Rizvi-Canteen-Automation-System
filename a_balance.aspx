﻿<%@ Page Title="" Language="C#" MasterPageFile="~/a_site.Master" AutoEventWireup="true"
    CodeBehind="a_balance.aspx.cs" Inherits="Canteen_Automation_System.a_balance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="color: Black; padding-top: 60px;">
        <center>
            <table width="50%">
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="Label1" runat="server" Text="Add Balance" CssClass="heading"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right" width="40%">
                        <asp:Label ID="Label2" runat="server" CssClass="label" Text="Student Id:"></asp:Label>
                    </td>
                    <td align="left" width="60%">
                        <asp:TextBox ID="id_TextBox1" runat="server" required CssClass="txt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="40%">
                        <asp:Label ID="Label3" runat="server" CssClass="label" Text="Amount:"></asp:Label>
                    </td>
                    <td align="left" width="60%">
                        <asp:TextBox ID="bal_TextBox2" runat="server" required CssClass="txt" TextMode="Number"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Balance."
                            ControlToValidate="bal_TextBox2" ForeColor="Red" ValidationExpression="^\d+$"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Add Balance" CssClass="button" 
                            ValidationGroup="v1" onclick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

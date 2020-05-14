<%@ Page Title="" Language="C#" MasterPageFile="~/a_site.Master" AutoEventWireup="true"
    CodeBehind="c_additem.aspx.cs" Inherits="Canteen_Automation_System.c_additem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="color: Black; padding-top: 60px;">
        <center>
            <table width="50%" border="1">
                <tr>
                    <td colspan="4" align="center">
                        <asp:Label ID="Label1" runat="server" Text="Add Item" CssClass="heading"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" width="20%" height="30px;">
                    <br />
                        <asp:Label ID="Label8" runat="server" CssClass="label" Text="Food Name:"></asp:Label>
                    </td>
                    <td width="30%" align="left" height="30px;">
                    <br />
                        <asp:TextBox ID="food_TextBox3" runat="server" CssClass="txt" required></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="food_TextBox3"
                            ValidationGroup="v1" runat="server" ErrorMessage="Enter food name"></asp:RequiredFieldValidator>
                    </td>
                    <td align="center" width="20%" height="30px;">
                    <br />
                        <asp:Label ID="Label9" runat="server" CssClass="label" Text="Description:"></asp:Label>
                    </td>
                    <td width="30%" align="left" height="30px;">
                        <br />
                        <asp:TextBox ID="des_TextBox3" runat="server" CssClass="txt" required 
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" width="20%" >
                        <asp:Label ID="Label2" runat="server" CssClass="label" Text="Cost:"></asp:Label>
                    </td>
                    <td width="30%" align="left">
                        <asp:TextBox ID="cost_TextBox1" runat="server" CssClass="txt" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Cost"
                            ControlToValidate="cost_TextBox1" ForeColor="Red" ValidationExpression="^\d+$"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
                    </td>
                    <td align="center" class="style1" width="20%">
                        <asp:Label ID="Label4" runat="server" CssClass="label" Text="Time Required:"></asp:Label>
                    </td>
                    <td width="30%" align="left">
                        <asp:TextBox ID="time_TextBox3" runat="server" CssClass="txt" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Time."
                            ControlToValidate="time_TextBox3" ForeColor="Red" ValidationExpression="^\d+$"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="50%" colspan="2">
                        <asp:Label ID="Label3" runat="server" CssClass="label" Text="Id:"></asp:Label>
                    </td>
                    <td width="50%" align="left" colspan="2">
                        <asp:TextBox ID="id_TextBox3" runat="server" CssClass="txt" ReadOnly="true" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="button" 
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
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/a_site.Master" AutoEventWireup="true"
    CodeBehind="a_addcanteen.aspx.cs" Inherits="Canteen_Automation_System.a_addcanteen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 27%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="color: Black; padding-top: 60px;">
        <center>
            <table width="50%">
                <tr>
                    <td colspan="4" align="center">
                       
                        <asp:Label ID="Label1" runat="server" Text="Add Canteen" CssClass="heading"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                       
                        <asp:Label ID="Label9" runat="server" CssClass="label" Text="Canteen Name:"></asp:Label>
                    &nbsp;<asp:TextBox ID="m_TextBox0" runat="server" CssClass="txt" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                       
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" width="20%" class="style1">
                        <asp:Label ID="Label2" runat="server" CssClass="label" Text="Manager Name:"></asp:Label>
                    </td>
                    <td width="30%" align="left">
                        <asp:TextBox ID="m_TextBox1" runat="server" CssClass="txt" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Manager Name"
                            ControlToValidate="m_TextBox1" ForeColor="Red" ValidationExpression="[a-zA-Z]*$"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
                    </td>
                    
                    <td align="center" width="20%">
                        <asp:Label ID="Label3" runat="server" CssClass="label" Text="Handler Name:"></asp:Label>
                    </td>
                    <td width="30%" align="left">
                        <asp:TextBox ID="h_TextBox2" runat="server" CssClass="txt" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Handler Name"
                            ControlToValidate="h_TextBox2" ForeColor="Red" ValidationExpression="[a-zA-Z]*$"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style1" width="20%">
                        <asp:Label ID="Label4" runat="server" CssClass="label" Text="Mobile No:"></asp:Label>
                    </td>
                    <td width="30%" align="left">
                        <asp:TextBox ID="mo_TextBox3" runat="server" CssClass="txt" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Contact No."
                            ControlToValidate="mo_TextBox3" ForeColor="Red" ValidationExpression="^[7-9]\d{9}$"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
                    </td>
                  
                    <td align="center" width="20%">
                        <asp:Label ID="Label5" runat="server" CssClass="label" Text="No of Worker:"></asp:Label>
                    </td>
                    <td width="30%" align="left">
                        <asp:TextBox ID="wo_TextBox4" runat="server" CssClass="txt" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter No. of Workers"
                            ControlToValidate="wo_TextBox4" ForeColor="Red" ValidationExpression="^\d+$"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style1" width="20%">
                        <asp:Label ID="Label6" runat="server" CssClass="label" Text="Id:"></asp:Label>
                    </td>
                    <td width="30%" align="left">
                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" CssClass="txt" required></asp:TextBox>
                    </td>
                    
                    <td align="center" width="20%">
                        <asp:Label ID="Label7" runat="server" CssClass="label" Text="Password:"></asp:Label>
                    </td>
                    <td width="30%" align="left">
                        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" CssClass="txt" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Label ID="Label8" runat="server" CssClass="label" Text="Amount:"></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="bal_TextBox3" runat="server"  CssClass="txt" required></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Enter Amount"
                            ControlToValidate="bal_TextBox3" ForeColor="Red" ValidationExpression="^\d+$"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
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

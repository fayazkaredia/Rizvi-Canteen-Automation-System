<%@ Page Title="" Language="C#" MasterPageFile="~/a_site.Master" AutoEventWireup="true" CodeBehind="a_addstudent.aspx.cs" Inherits="Canteen_Automation_System.a_addstudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="color: Black; padding-top: 60px;">
        <center>
            <table width="50%">
                <tr>
                    <td colspan="4" align="center">
                       
                        <asp:Label ID="Label1" runat="server" Text="Add Student" CssClass="heading"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                     <td align="center" width="20%" class="style1">
                        <asp:Label ID="Label8" runat="server" CssClass="label" Text="Student Name:"></asp:Label>
                    </td>
                    <td width="30%" align="left" > 
                        <asp:TextBox ID="stu_TextBox3" runat="server" CssClass="txt" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Enter Student Name"
                            ControlToValidate="stu_TextBox3" ForeColor="Red" ValidationExpression="[a-zA-Z]*$"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
                    </td>

                     <td align="center" width="20%" class="style1">
                        <asp:Label ID="Label9" runat="server" CssClass="label" Text="Class:"></asp:Label>
                    </td>
                    <td width="30%" align="left">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txt">
                            <asp:ListItem>---SELECT---</asp:ListItem>
                            <asp:ListItem>IT</asp:ListItem>
                            <asp:ListItem>Civil</asp:ListItem>
                            <asp:ListItem>Electronics</asp:ListItem>
                            <asp:ListItem>Mechanical</asp:ListItem>
                            <asp:ListItem>Computer Science</asp:ListItem>
                            <asp:ListItem>Electrical</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center" width="20%" class="style1">
                        <asp:Label ID="Label2" runat="server" CssClass="label" Text="Email Id:"></asp:Label>
                    </td>
                    <td width="30%" align="left">
                        <asp:TextBox ID="email_TextBox1" runat="server" CssClass="txt" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Email Id"
                            ControlToValidate="email_TextBox1" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
                    </td>
                   
                    <td align="center" class="style1" width="20%">
                        <asp:Label ID="Label4" runat="server" CssClass="label" Text="Mobile No:"></asp:Label>
                    </td>
                    <td width="30%" align="left">
                        <asp:TextBox ID="mo_TextBox3" runat="server" CssClass="txt" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Contact No."
                            ControlToValidate="mo_TextBox3" ForeColor="Red" ValidationExpression="^[7-9]\d{9}$"
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
                    <td align="right" width="50%" class="style1" colspan="2">
                        <asp:Label ID="Label3" runat="server" CssClass="label" Text="Balance:"></asp:Label>
                    </td>
                    <td width="50%" align="left" colspan="2"> 
                        <asp:TextBox ID="bal_TextBox3" runat="server" CssClass="txt" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Amount"
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



</asp:Content>

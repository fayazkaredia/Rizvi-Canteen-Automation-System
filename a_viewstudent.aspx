<%@ Page Title="" Language="C#" MasterPageFile="~/a_site.Master" AutoEventWireup="true" CodeBehind="a_viewstudent.aspx.cs" Inherits="Canteen_Automation_System.a_viewstudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
    rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div style="padding-top:30px;"></div>
<center>
    <asp:Label ID="Label1" runat="server" Text="View Student" CssClass="heading"></asp:Label>
    <div style="padding-top:50px;"></div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="s_id"
            OnRowCommand="GridViewData_RowCommand" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            Width="80%" ForeColor="Black" GridLines="Vertical" Font-Size="Medium" Height="60px" >
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="s_id" HeaderText="Id" />
                <asp:BoundField DataField="s_name" HeaderText="Name" />
                <asp:BoundField DataField="s_class" HeaderText="Class" />
               <asp:BoundField DataField="s_email" HeaderText="Email" />
                <asp:BoundField DataField="s_mobile" HeaderText="Contact No." />
                <asp:BoundField DataField="s_bal" HeaderText="Balance" />
                <asp:TemplateField HeaderText="EDIT" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="ShowPopup"
CommandArgument='<%#Eval("s_id") %>'>Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="DELETE" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDel" runat="server" CommandName="delete"
CommandArgument='<%#Eval("s_id") %>'>Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
</center>

   
   <br />

   
   <style type="text/css">
        
        #mask
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 4;
            opacity: 0.4;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=40)"; /* first!*/
            filter: alpha(opacity=40); /* second!*/
            background-color: gray;
            display: none;
            width: 100%;
            height: 100%;
        }
    </style>
    
    <script type="text/javascript" language="javascript">
        function ShowPopup() {
            $('#mask').show();
            $('#<%=pnlpopup.ClientID %>').show();
        }
        function HidePopup() {
            $('#mask').hide();
            $('#<%=pnlpopup.ClientID %>').hide();
        }
        $(".btnClose").live('click', function () {
            HidePopup();
        });
    </script>
    
      <asp:Panel ID="pnlpopup" runat="server"  BackColor="White" Height="500px" Visible="true"
            Width="700px" Style="z-index:111;background-color: White; position: absolute; left: 25%; top: 0%; 
 
border: outset 2px gray;padding:5px;display:none">
            <table width="100%" style="width: 100%; height: 100%;" cellpadding="0" cellspacing="5">
                <tr style="background-color: green">
                    <td colspan="2" style="color:White; font-weight: bold; font-size: 1.2em; padding:3px"
                        align="center">
                        Student Detail <a id="closebtn" style="color: white; float: right;text-decoration:none" class="btnClose"  href="#">X</a>
                    </td>
                </tr>
               
                <tr>
                    <td align="right" style="width: 45%">
                        Id:   
                    </td>
                    <td style="padding-left:10px;">
                        <asp:Label ID="id" CssClass="label" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Name:   
                    </td>
                    <td style="padding-left:10px;">
                        <asp:TextBox ID="name" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Class:   
                    </td>
                    <td style="padding-left:10px;">
                        <asp:TextBox ID="class1"  CssClass="txt" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Email:   
                    </td>
                    <td style="padding-left:10px;">
                        <asp:TextBox ID="email" CssClass="txt" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid Email Id"
                            ControlToValidate="email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Contact:   
                    </td>
                    <td style="padding-left:10px;">
                        <asp:TextBox ID="contact" CssClass="txt" runat="server" />
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter valid Contact No."
                            ControlToValidate="contact" ForeColor="Red" ValidationExpression="^[7-9]\d{9}$"
                            ValidationGroup="v1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    <asp:Button ID="btnUpdate" CommandName="Update" CssClass="button" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    </td>
                    <td align="center">
                        
                        <asp:Button ID="btncancel" CommandName="Update" runat="server" CssClass="button" Text="Cancel" OnClick="btncancel_Click" />
                      
                    </td>
                </tr>
            </table>
        </asp:Panel>
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
        <br />


</asp:Content>

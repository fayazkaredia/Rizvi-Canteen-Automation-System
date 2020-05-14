<%@ Page Title="" Language="C#" MasterPageFile="~/a_site.Master" AutoEventWireup="true" CodeBehind="c_viewitem.aspx.cs" Inherits="Canteen_Automation_System.c_viewitem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
    rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



<div style="padding-top:30px;"></div>
<center>
    <asp:Label ID="Label1" runat="server" Text="View Item" CssClass="heading"></asp:Label>
    <div style="padding-top:50px;"></div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            OnRowCommand="GridViewData_RowCommand" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            Width="80%" ForeColor="Black" GridLines="Vertical" Font-Size="Medium" Height="60px" >
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="desc1" HeaderText="Description" />
               <asp:BoundField DataField="cost" HeaderText="Cost" />
                <asp:BoundField DataField="time" HeaderText="Time" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:TemplateField HeaderText="EDIT" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="ShowPopup"
CommandArgument='<%#Eval("id") %>'>Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="AVAILABILITY" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonstatus" runat="server" CommandName="status"
CommandArgument='<%#Eval("id") %>'>Status</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="DELETE" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDel" runat="server" CommandName="delete"
CommandArgument='<%#Eval("id") %>'>Delete</asp:LinkButton>
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
    <br />
    <asp:Label ID="LabelErr" runat="server" Font-Size="X-Large" Visible="False"></asp:Label>
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
            Width="500px" Style="z-index:111;background-color: White; position: absolute; left: 35%; top: 0%; 
 
border: outset 2px gray;padding:5px;display:none">
            <table width="100%" style="width: 100%; height: 100%;" cellpadding="0" cellspacing="5">
                <tr style="background-color: #0924BC">
                    <td colspan="2" style="color:White; font-weight: bold; font-size: 1.2em; padding:3px"
                        align="center">
                        Item Detail <a id="closebtn" style="color: white; float: right;text-decoration:none" class="btnClose"  href="#">X</a>
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
                        Description:   
                    </td>
                    <td style="padding-left:10px;">
                        <asp:TextBox ID="desc1"   CssClass="txt" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        cost:   
                    </td>
                    <td style="padding-left:10px;">
                        <asp:TextBox ID="Cost" CssClass="txt" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Time:   
                    </td>
                    <td style="padding-left:10px;">
                        <asp:TextBox ID="Time" CssClass="txt" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td align="right">
                        Status:   
                    </td>
                    <td style="padding-left:10px;">
                        <asp:TextBox ID="status" ReadOnly="true" CssClass="txt" runat="server" />
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

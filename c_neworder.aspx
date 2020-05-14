<%@ Page Title="" Language="C#" MasterPageFile="~/a_site.Master" AutoEventWireup="true"
    CodeBehind="c_neworder.aspx.cs" Inherits="Canteen_Automation_System.c_neworder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-top: 30px;">
    </div>
    <center>
        <asp:Label ID="Label1" runat="server" Text="Order Details" CssClass="heading"></asp:Label>
        <div style="padding-top: 50px;">
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="order_id"
            OnRowCommand="GridViewData_RowCommand" BackColor="White" BorderColor="#999999"
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" Width="80%" ForeColor="Black"
            GridLines="Vertical" Font-Size="Medium" Height="60px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="order_id" HeaderText="Order Id" />
                <asp:BoundField DataField="user_id" HeaderText="User Id" />
                <asp:BoundField DataField="food_item" HeaderText="Items" />
                <asp:BoundField DataField="amount" HeaderText="Amount" />
                <asp:BoundField DataField="date" HeaderText="Date" />
                <asp:BoundField DataField="time" HeaderText="Time" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Change Status" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="status" CommandArgument='<%#Eval("order_id") %>'>Change</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Payment" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDel" runat="server" CommandName="payment" CommandArgument='<%#Eval("order_id") %>'>Payment</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
        <br />
        <br />
        
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <table width="50%">
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Label2" runat="server" CssClass="label" Text="Order Id :"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="TextBox1" CssClass="txt" runat="server" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" width="50%">
                        <asp:Panel ID="Panel4" runat="server" Visible="False">
                            <table class="ui-accordion">
                                <tr>
                                    <td align="right" width="50%">
                                        <asp:Label ID="Label3" runat="server" CssClass="label" Text="Balance :"></asp:Label>
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:Label ID="LabelBal" runat="server" CssClass="label" Font-Bold="True"></asp:Label>
                                        &nbsp;<asp:Label ID="LabelAD" runat="server" CssClass="label" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%">&nbsp;</td>
                                    <td align="right" width="50%">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right" width="50%">
                                        <asp:Label ID="Label4" runat="server" CssClass="label" Text="By Cash :"></asp:Label>
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:Label ID="LabelCash" runat="server" CssClass="label" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="50%">&nbsp;</td>
                    <td align="left" width="50%">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Payment" CssClass="button" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
    </center>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

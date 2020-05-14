<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="c_login.aspx.cs" Inherits="Canteen_Automation_System.c_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Canteen Login</title>
    <style type="text/css">
        body
        {

        background: #fff url(../img/body_bg2.png);
        }
        .pan
        {
            background-color: White;
        }
        .pan:hover
        {
            background-color: #F5F5F5;
        }
        
        .button
        {
            background-color: white;
            border: 1px solid #00695c;
            color: #484848;
            text-align: center;
            padding: 10px 55px;
            text-align: center;
            font-family: Bell MT;
            font-size: 18px;
            -moz-border-radius: 7px;
            -webkit-border-radius: 7px;
            -khtml-border-radius: 7px;
        }
        .button:hover
        {
            background-color: white;
            border: 1px solid #00695c;
            box-shadow: 0 0 5px #00695c;
            color: #00695c;
        }
        
        .heading
        {
            font-family: Bell MT;
            font-size: 28px;
            color: #015987;
        }
        
        .label
        {
            font-family: Bell MT;
            font-size: 18px;
            color: #484848;
        }
        
        .txt
        {
            -webkit-transition: all 0.30s ease-in-out;
            -moz-transition: all 0.30s ease-in-out;
            -o-transition: all 0.30s ease-in-out;
            font-size: 16px;
            font-family: Palatino Linotype;
            padding: 8px 8px 8px 8px;
            border: 1px solid #DDDDDD;
        }
        
        .txt:focus
        {
            box-shadow: 0 0 5px #00695c;
            padding: 8px 8px 8px 8px;
            border: 1px solid #00695c;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div>
        <center>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/qw.png" />
            </center>
    </div>
    <center style="padding-top: 100px;">
        <div style="width: 400px; height: 320px; background-color: rgba(255, 127, 80, 0.3);">
            <br />
            <br />
            <table width="70%">
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="Label1" runat="server" CssClass="heading" Text="Canteen Login"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" CssClass="label" Text="Id:"></asp:Label>
                        <br />
                        <br />
                    </td>
                    <td>
                        <asp:TextBox ID="idtxt" CssClass="txt" required runat="server" title="Admin Id."></asp:TextBox>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" CssClass="label" Text="Password:" ></asp:Label>
                        <br />
                        <br />
                    </td>
                    <td>
                        <asp:TextBox ID="passtxt" CssClass="txt" required runat="server" TextMode="Password" ></asp:TextBox>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                    <br />
                        <asp:Button ID="Button1" runat="server" CssClass="button" Text="Submit" onclick="Button1_Click" 
                            />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </center>
    </form>
</body>
</html>

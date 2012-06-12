<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUserLogin.ascx.cs" Inherits="MS_siteAdmin_userControl_ucUserLogin" %>
<table width="350px">
<tr><td colspan="3"></td></tr>
<tr><td colspan="3" class="heading_text">Login Credentials</td></tr>
<tr><td colspan="3" class="errorHeader">
    <asp:Label ID="lblError" runat="server" ></asp:Label></td></tr>
<tr><td>Username</td><td>:</td><td><asp:TextBox ID="txtUsername" runat="server" CssClass="textarea_box" MaxLength="30"></asp:TextBox></td></tr>
<tr><td>Password</td><td>:</td><td><asp:TextBox ID="txtPassword" runat="server" CssClass="textarea_box" MaxLength="12" TextMode="Password"></asp:TextBox></td></tr>
<tr><td colspan="2"></td><td>
    <asp:Button ID="btnLogin" runat="server" Text="Sign in" OnClick="btnLogin_Click" CssClass="button_bg" /></td></tr>
</table>

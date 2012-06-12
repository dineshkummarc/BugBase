<%@ Page Language="C#" MasterPageFile="~/MS/siteAdmin/BugTrackerMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="MS_siteAdmin_Login" Title="Untitled Page" %>

<%@ Register Src="userControl/ucUserLogin.ascx" TagName="ucUserLogin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucUserLogin ID="UcUserLogin1" runat="server" />
</asp:Content>


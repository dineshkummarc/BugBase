<%@ Page Language="C#" MasterPageFile="~/MS/siteAdmin/BugTrackerMaster.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="MS_siteAdmin_Welcome" Title="Untitled Page" %>

<%@ Register Src="userControl/ucWelcome.ascx" TagName="ucWelcome" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucWelcome ID="UcWelcome1" runat="server" />
</asp:Content>


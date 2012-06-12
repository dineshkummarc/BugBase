<%@ Page Language="C#" MasterPageFile="~/MS/siteAdmin/BugTrackerMaster.master" AutoEventWireup="true" CodeFile="Bugs.aspx.cs" Inherits="MS_siteAdmin_Bugs" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Src="userControl/ucAddUpdateDeleteBugs.ascx" TagName="ucAddUpdateDeleteBugs"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucAddUpdateDeleteBugs ID="UcAddUpdateDeleteBugs1" runat="server" />
</asp:Content>


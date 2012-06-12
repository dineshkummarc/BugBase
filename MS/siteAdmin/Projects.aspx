<%@ Page Language="C#" MasterPageFile="~/MS/siteAdmin/BugTrackerMaster.master" AutoEventWireup="true" CodeFile="Projects.aspx.cs" Inherits="MS_siteAdmin_Projects" Title="Untitled Page" %>

<%@ Register Src="userControl/ucAddUpdateDeleteProjects.ascx" TagName="ucAddUpdateDeleteProjects"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucAddUpdateDeleteProjects ID="UcAddUpdateDeleteProjects1" runat="server" />
</asp:Content>


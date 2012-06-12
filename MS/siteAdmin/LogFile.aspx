<%@ Page Language="C#" MasterPageFile="~/MS/siteAdmin/BugTrackerMaster.master" AutoEventWireup="true" CodeFile="LogFile.aspx.cs" Inherits="MS_siteAdmin_LogFile" Title="Untitled Page" %>

<%@ Register Src="userControl/ucViewLogFile.ascx" TagName="ucViewLogFile" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucViewLogFile ID="UcViewLogFile1" runat="server" />
</asp:Content>


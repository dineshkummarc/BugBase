<%@ Page Language="C#" MasterPageFile="~/MS/siteAdmin/BugTrackerMaster.master" AutoEventWireup="true" CodeFile="showBuglist.aspx.cs" Inherits="MS_siteAdmin_showBuglist" Title="Untitled Page" %>

<%@ Register Src="userControl/ucshowBuglist.ascx" TagName="ucshowBuglist" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucshowBuglist id="UcshowBuglist1" runat="server">
    </uc1:ucshowBuglist>
</asp:Content>


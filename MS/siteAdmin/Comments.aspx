<%@ Page Language="C#" MasterPageFile="~/MS/siteAdmin/BugTrackerMaster.master" AutoEventWireup="true" CodeFile="Comments.aspx.cs" Inherits="MS_siteAdmin_Comments" Title="Untitled Page" %>

<%@ Register Src="userControl/ucComments.ascx" TagName="ucComments" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucComments id="UcComments1" runat="server">
    </uc1:ucComments>
</asp:Content>


<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAddUpdateDeleteProjects.ascx.cs" Inherits="MS_siteAdmin_userControl_ucAddUpdateDeleteProjects" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<table width="950px">
<tr><td colspan="3" class="heading_text">Add New Project</td></tr>
    <tr>
        <td colspan="3" class="errorHeader">
            <asp:Label ID="lblError" runat="server" ></asp:Label></td>
    </tr>
<tr><td>Project Name</td><td>:</td><td><asp:TextBox ID="txtName" runat="server" CssClass="textarea_box"></asp:TextBox></td></tr>
<tr><td>
    Project Team Members</td><td>:</td><td><asp:TextBox ID="txtTeam" runat="server" TextMode="MultiLine"></asp:TextBox></td></tr>
<tr><td>Start Date</td><td>:</td><td>
    <asp:TextBox ID="txtStartDate" runat="server" CssClass="textarea_box"></asp:TextBox></td></tr>
<tr><td>End Date</td><td>:</td><td>
    <asp:TextBox ID="txtEndDate" runat="server" CssClass="textarea_box"></asp:TextBox></td></tr>
<tr><td>Project Status</td><td>:</td><td>
    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdown_box">
        <asp:ListItem Value="0">-Select-</asp:ListItem>
        <asp:ListItem>New</asp:ListItem>
        <asp:ListItem Value="InProgress">In Progress</asp:ListItem>
        <asp:ListItem Value="C">Complete</asp:ListItem>
        <asp:ListItem Value="R">Reject</asp:ListItem>
    </asp:DropDownList></td></tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="button_bg" /></td>
    </tr>
<tr><td colspan="3" align="left">
    </td></tr>

</table>

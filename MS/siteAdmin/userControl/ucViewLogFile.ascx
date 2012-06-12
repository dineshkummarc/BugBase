<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucViewLogFile.ascx.cs" Inherits="MS_siteAdmin_userControl_ucViewLogFile" %>
<table width="950px">
<tr><td colspan="3" class="heading_text">View Log File</td></tr>
<tr><td colspan="3" class="errorHeader"><asp:Label ID="lblError" runat="server" Text=""></asp:Label></td></tr>
<tr><td>
    Select Project &nbsp; : &nbsp;<asp:DropDownList ID="ddlProjects" CssClass="dropdown_box" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged">
    </asp:DropDownList></td><td></td><td>
    </td></tr>
    <tr><td colspan="3">&nbsp;</td></tr>
    <tr><td colspan="3">
        <asp:Repeater ID="rptLogList" runat="server">
        <HeaderTemplate>
        <table width="100%"><tr class="table_bg"><td>Sr. No.</td><td>Bug ID</td><td>Viewed By</td><td>Viewed On</td></tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td><%#Container.ItemIndex+1%></td>
        <td><%#DataBinder.Eval(Container.DataItem,"BugID") %></td>
        <td><%#DataBinder.Eval(Container.DataItem, "ViewedBy")%></td>
        <td><%#DataBinder.Eval(Container.DataItem, "ViewTime")%></td>
        </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <tr class="table_bg_1">
        <td><%#Container.ItemIndex+1%></td>
        <td><%#DataBinder.Eval(Container.DataItem,"BugID") %></td>
        <td><%#DataBinder.Eval(Container.DataItem, "ViewedBy")%></td>
        <td><%#DataBinder.Eval(Container.DataItem, "ViewTime")%></td>
        </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
    </td></tr>
</table>

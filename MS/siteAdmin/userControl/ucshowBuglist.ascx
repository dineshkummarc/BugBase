<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucshowBuglist.ascx.cs" Inherits="MS_siteAdmin_userControl_ucshowBuglist" %>
<table width="950px" >
<tr><td colspan="2" class="heading_text">Display Bug List</td></tr>
    <tr>
        <td align="left" >
            Select Project &nbsp; : &nbsp; 
                <asp:DropDownList ID="ddlProjects" CssClass="dropdown_box" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged">
                </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="right">
            <asp:HyperLink ID="hypBug" runat="server" CssClass="link_text_blue"  NavigateUrl="~/siteAdmin/Bugs.aspx">Add New Bug</asp:HyperLink></td>
    </tr>
    <tr>
        <td align="left" colspan="2" class="errorHeader">
            <asp:Label ID="lblError" runat="server"></asp:Label></td>
    </tr>
<tr><td colspan="2">
    <asp:GridView ID="grdBuglist" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdBuglist_RowDataBound" OnRowUpdating="grdBuglist_RowUpdating" OnRowCommand="grdBuglist_RowCommand" CssClass="GridViewCommon">
    <Columns>
    <asp:TemplateField Visible="False">
    <ItemTemplate>
    <asp:Label ID="lblBID" runat="server" Text='<%#Eval("BID") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="BugID">
    <ItemTemplate>
    <asp:LinkButton ID="lblBugID" runat="server" Text='<%#Eval("BugID") %>' CssClass="link_text" CommandArgument='<%#Eval("BID") %>' CommandName="BugDetail"></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Summary" >
    <ItemTemplate>
    <table><tr><td width="300px" style="text-align:justify;">
    <asp:Label ID="lblBugSummary" runat="server" Text='<%#Eval("BugSummary") %>'></asp:Label>
    </td></tr></table>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="View Snapshot">
    <ItemTemplate>
    <a href="" id="popUp" runat="server" class="link_text">Snapshot</a>
    <asp:Label ID="lblSnapshot"  runat="server" Text='<%#Eval("Attatchment") %>' Visible="false"></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Priority">
    <ItemTemplate>
    <asp:Label ID="lblPriority" runat="server" Text='<%#Eval("Priority") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Posted On">
    <ItemTemplate>
    <asp:Label ID="lblPostedOn" runat="server" Text='<%#Eval("CreatedOn","{0:MM/dd/yyyy}")%>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Updated On">
    <ItemTemplate>
    <asp:Label ID="lblUpdatedOn" runat="server" Text='<%#Eval("ModifiedOn","{0:MM/dd/yyyy}")%>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Status">
    <ItemTemplate>
   <asp:DropDownList ID="ddlBugStatus" runat="server" CssClass="dropdown_box">
                               <asp:ListItem Value="0">-Select-</asp:ListItem>
                               <asp:ListItem Value="N">New</asp:ListItem>
                               <asp:ListItem Value="O">Open</asp:ListItem>
                               <asp:ListItem Value="R">Rejected</asp:ListItem>
                               <asp:ListItem Value="F">Fixed</asp:ListItem>
                               <asp:ListItem Value="C">Closed</asp:ListItem>
                           </asp:DropDownList>&nbsp;<asp:Button ID="btnUpdate" CssClass="button_bg" Text="Update" runat="server" CommandName="Update" />
    </ItemTemplate>
        <ItemStyle Width="170px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Comments">
    <ItemTemplate>
    <asp:LinkButton ID="lnkPostComments" CssClass="link_text" runat="server" CommandName="PostComments" CommandArgument='<%#Eval("BID") %>' Text="Post/View Comments"></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <HeaderStyle CssClass="table_bg" />
        <AlternatingRowStyle CssClass="table_bg_1" />
        
    </asp:GridView>
</td></tr>
</table>
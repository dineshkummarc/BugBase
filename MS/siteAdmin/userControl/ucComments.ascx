<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucComments.ascx.cs" Inherits="MS_siteAdmin_userControl_ucComments" %>
<table width="961px">
<tr><td colspan="3" class="heading_text">
    Post / View Comments</td></tr>
<tr><td colspan="3" class="errorHeader">
    <asp:Label ID="lblError" runat="server" ></asp:Label></td></tr>
<tr><td>
    Name</td><td>:</td><td>
    <asp:TextBox ID="txtName" runat="server" CssClass="textarea_box"></asp:TextBox></td></tr>
<tr><td>
    Comments</td><td>:</td><td>
    <asp:TextBox ID="txtComments" runat="server" Columns="80" Rows="5" TextMode="MultiLine"></asp:TextBox></td></tr>
    <tr><td>
    </td><td></td><td>
        <asp:Button ID="btnPost" runat="server" Text="Post Comments" CssClass="button_bg" OnClick="btnPost_Click" /></td></tr>
        <tr><td colspan="3">&nbsp;
    </td></tr>
    <tr><td></td><td></td><td>
        <asp:DataList ID="dlShowComments" runat="server" Width="100%">
        <ItemTemplate>
        <table>
        
        <tr><td class="table_bg">Name</td><td>:</td><td><%#DataBinder.Eval(Container.DataItem, "UserName")%></td></tr>
        <tr><td class="table_bg_1" >Comments</td><td>:</td><td style="text-align:justify;font-size:12px;"><%#DataBinder.Eval(Container.DataItem, "Comments")%></td></tr>
        <tr><td align="right" style="font-style:italic;" class="table_bg">Posted On</td><td>:</td><td style="font-style:italic;"><%#DataBinder.Eval(Container.DataItem, "CreatedOn","{0:MM/dd/yyyy}")%><br /></td></tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        </table>
        </ItemTemplate>
      
        </asp:DataList></td></tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
            <asp:HyperLink ID="hypBack" NavigateUrl="~/MS/siteAdmin/showBuglist.aspx" Text="Back" runat="server" CssClass="link_text_blue"></asp:HyperLink></td>
    </tr>
</table>

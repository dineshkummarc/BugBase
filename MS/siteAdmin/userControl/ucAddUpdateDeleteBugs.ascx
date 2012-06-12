<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAddUpdateDeleteBugs.ascx.cs" Inherits="MS_siteAdmin_userControl_ucAddUpdateDeleteBugs" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<table width="650">
<tr><td colspan="3" class="heading_text">Add New Bugs</td></tr>
    <tr>
        <td colspan="3" class="errorHeader">
            <asp:Label ID="lblError" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td>
            Project</td>
        <td>
            :</td>
        <td>
            <asp:DropDownList ID="ddlProjects" CssClass="dropdown_box" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td>
            Bug ID</td>
        <td>
            :</td>
        <td>
            <asp:TextBox ID="txtBugID" runat="server" MaxLength="20"></asp:TextBox></td>
    </tr>
<tr><td>Bug Summary</td><td>:</td><td><asp:TextBox ID="txtBugSummary" CssClass="textarea_box" runat="server" MaxLength="250"></asp:TextBox></td></tr>
<tr><td>
    Bug Description</td><td>:</td><td>
            <FTB:FreeTextBox id="txtBugDesc" runat="server" ButtonWidth="15" ButtonHeight="15" Width="450px" Height="230px">
            </FTB:FreeTextBox>
    </td></tr>
<tr><td>
    URL</td><td>:</td><td><asp:TextBox ID="txtUrl" runat="server" CssClass="textarea_box" MaxLength="255"></asp:TextBox></td></tr>
<tr><td>
    Severity</td><td>:</td><td>
    <asp:DropDownList ID="ddlSeverity" runat="server" CssClass="dropdown_box">
        <asp:ListItem Value="0">-Select-</asp:ListItem>
        <asp:ListItem Value="Bl">Blocker</asp:ListItem>
        <asp:ListItem Value="Cr">Critical</asp:ListItem>
        <asp:ListItem Value="Ma">Major</asp:ListItem>
        <asp:ListItem Value="Mi">Minor</asp:ListItem>
        <asp:ListItem Value="Tr">Trival</asp:ListItem>
        <asp:ListItem Value="En">Enhancement</asp:ListItem>
    </asp:DropDownList></td></tr>
    <tr ><td>
        Attatchment</td><td>:</td><td>
        <asp:FileUpload ID="FileUpload1" runat="server" /><a href="#" id="popUp" name="popUp" class="link_text_blue" runat="server" visible="false">View Snapshot</a></td></tr>
         <tr id="tr2" runat="server"><td>
             Assign To (Email-ID)</td><td>:</td><td valign="top">
                 <asp:ListBox ID="dlAssignTo" runat="server" Width="300px"></asp:ListBox><br />
                 (Click to
                 select assignee, only one assignee can be selected from the list)</td></tr>
             <tr id="tr3" runat="server"><td>
                 Email To (Email-ID)</td><td>:</td><td>
                     <asp:DataList ID="dlEmailTo" runat="server" BorderColor="Black" BorderWidth="1px" Width="300px">
                     <ItemTemplate>
                     <asp:CheckBox ID="chkCCEmails" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"EmailAddress") %>' />
                     </ItemTemplate>
                     </asp:DataList></td></tr>
              <tr><td>
                  Priority</td><td>:</td><td>
                      <asp:DropDownList ID="ddlPriority" runat="server" CssClass="dropdown_box">
                          <asp:ListItem Value="0">-Select-</asp:ListItem>
                          <asp:ListItem Value="H">High</asp:ListItem>
                          <asp:ListItem Value="M">Medium</asp:ListItem>
                          <asp:ListItem Value="L">Low</asp:ListItem>
                      </asp:DropDownList></td></tr>
                       <tr><td>
                           Bug Status</td><td>:</td><td>
                           <asp:DropDownList ID="ddlBugStatus" runat="server" CssClass="dropdown_box">
                               <asp:ListItem Value="0">-Select-</asp:ListItem>
                               <asp:ListItem Value="N">New</asp:ListItem>
                               <asp:ListItem Value="O">Open</asp:ListItem>
                               <asp:ListItem Value="R">Rejected</asp:ListItem>
                               <asp:ListItem Value="F">Fixed</asp:ListItem>
                               <asp:ListItem Value="C">Closed</asp:ListItem>
                           </asp:DropDownList></td></tr>
<tr><td colspan="3" align="center">
    <asp:Button ID="btnSave" runat="server" Text="Save & Post" OnClick="btnSave_Click" CssClass="button_bg" />
    <asp:HyperLink ID="hypBack" runat="server" CssClass="link_text_blue" NavigateUrl="~/siteAdmin/showBuglist.aspx">Back</asp:HyperLink></td></tr>

</table>


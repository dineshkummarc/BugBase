using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using MSBLL;

public partial class MS_siteAdmin_userControl_ucComments : System.Web.UI.UserControl
{
    private Comments objComments = null;
    private int intBugID;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = String.Empty;

        if (Request.QueryString["Bid"] != null)
        {
            intBugID = Int32.Parse(Convert.ToString(Request.QueryString["Bid"]));
            if (!Page.IsPostBack)
            {
             
                fillComments();
            }
        }
        else
        {
            Response.Redirect("showBuglist.aspx");
        }
    }

    
    private void fillComments()
    {
        SqlDataReader dr = null;
        objComments = new Comments();
        objComments.BugID = intBugID;
        dr=(SqlDataReader)objComments.getallComments();
        if (dr.HasRows)
        {
            dlShowComments.DataSource = dr;
            dlShowComments.DataBind();
        }
        else
        {
            lblError.Text = "No Comments Found";
        }
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        objComments = new Comments();
        objComments.CommentID = 0;
        objComments.BugID = intBugID;
        objComments.Name = Server.HtmlEncode(txtName.Text.Trim());
        objComments.Comment = Server.HtmlEncode(txtComments.Text.Trim());
        int i=objComments.postComments();
        if (i == 1)
        {
            fillComments();
        }
       
    }
}

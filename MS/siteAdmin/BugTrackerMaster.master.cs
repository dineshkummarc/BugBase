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

public partial class MS_siteAdmin_BugTrackerMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
        {
            h1Login.Visible = false;
            hLogout.Visible = true;
        }
        else
        {
            h1Login.Visible = true;
            hLogout.Visible = false;
        }
    }
}

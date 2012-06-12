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

public partial class MS_siteAdmin_userControl_ucWelcome : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (String.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblName.Text = Convert.ToString(Session["UserName"]);
                lblDate.Text = DateTime.Now.ToLongDateString();
            }
        }
    }
}

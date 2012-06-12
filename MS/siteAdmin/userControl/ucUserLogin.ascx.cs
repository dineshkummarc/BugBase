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
using MSBLL;

public partial class MS_siteAdmin_userControl_ucUserLogin : System.Web.UI.UserControl
{
    private Common objCommon = null;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        objCommon = new Common();
        objCommon.username = txtUsername.Text.Trim();
        objCommon.password = txtPassword.Text.Trim();

        int status = objCommon.login();
        if (status <= 0)
        {
            lblError.Text = "The specified credentials are invalid";
        }
        else
        {
            //redirecty to ne w poage
            lblError.Text = "";
            Session["UserName"] = objCommon.username.ToString();
            Response.Redirect("Welcome.aspx");
        }
      
    }
}

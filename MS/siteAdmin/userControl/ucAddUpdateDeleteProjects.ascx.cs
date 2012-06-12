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
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using MSBLL;

public partial class MS_siteAdmin_userControl_ucAddUpdateDeleteProjects : System.Web.UI.UserControl
{
    private Projects objProject = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        objProject = new Projects();
        int returnStatus = 0;
        try
        {
            objProject.HitButton = "I";
            objProject.ProjectID = 0;
            objProject.ProjectName = Server.HtmlEncode(txtName.Text.Trim().ToUpper());
            objProject.ProjectTeam = Server.HtmlEncode(txtTeam.Text.Trim(',').Trim().ToUpper());
            objProject.StartDate = DateTime.Parse(txtStartDate.Text);
            objProject.EndDate = DateTime.Parse(txtEndDate.Text);
            objProject.ProjectStatus = ddlStatus.SelectedValue.ToString();
            returnStatus = objProject.insertUpdateDeleteProjects();

        }
        catch(Exception ex)
        {

        }
        finally
        {
        }
    }
}

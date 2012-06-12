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


public partial class MS_siteAdmin_userControl_ucViewLogFile : System.Web.UI.UserControl
{
    public Projects objProjects = null;
    private TrackUser objTrackUser = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (String.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                Response.Redirect("Login.aspx");
            }
            fillddlProjects();
        
        }
    }

    private void fillddlProjects()
    {
        DataSet ds = null;
        try
        {
            objProjects = new Projects();
            ds = objProjects.readProjectsAll();
            ddlProjects.DataSource = ds;
            ddlProjects.DataTextField = "ProjectName";
            ddlProjects.DataValueField = "ProjectID";

            ddlProjects.DataBind();

            ddlProjects.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message.ToString();
        }
        finally
        {
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }
        }
    }
    protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = null;
        objTrackUser = new TrackUser();
        objTrackUser.ProjectID = Int32.Parse(ddlProjects.SelectedValue);
        ds = objTrackUser.readLogFile();
        rptLogList.DataSource = ds;
        rptLogList.DataBind();
        if (ds.Tables[0].Rows.Count <= 0)
        {
            lblError.Text = "No records Found";
        }
        else
        {
            lblError.Text = String.Empty;
        }
    }
}

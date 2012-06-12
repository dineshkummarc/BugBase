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
using System.IO;
using MSBLL;

public partial class MS_siteAdmin_userControl_ucshowBuglist : System.Web.UI.UserControl
{
    private Bugs objBug = null;
    private Projects objProjects = null;
    private DataSet dsBug = null;
    private TrackUser objTrackUser = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        ddlProjects.Enabled = true;
        if (!Page.IsPostBack)
        {
            fillddlProjects();
        }
        if (Request.QueryString["pid"] != null && Request.QueryString["bid"] != null)
        {
            ddlProjects.Enabled = false;
            ddlProjects.SelectedValue = Convert.ToString(Request.QueryString["pid"]);

            if (!Page.IsPostBack)
            {
                //track user
                userTracker();

                //fill the list

                fillRefinedBugList();
            }

        }
        if (String.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
        {
            hypBug.Visible = false;
        }
        else
        {
            hypBug.Visible = true;
        }

    }
    private void userTracker()
    {
            objTrackUser = new TrackUser();
            objTrackUser.ProjectID = Int32.Parse(Request.QueryString["pid"]);
            objTrackUser.BID = Int32.Parse(Request.QueryString["bid"]);
            objTrackUser.ViewedBy = Convert.ToString(Request.QueryString["email"]);
            objTrackUser.intTrackUserRecord();
      
    }
    private void fillRefinedBugList()
    {
        objBug = new Bugs();
        try
        {
            objBug.ProjectID = Int32.Parse(Request.QueryString["pid"].ToString());
            objBug.BID = Int32.Parse(Request.QueryString["bid"].ToString());
            dsBug = objBug.readBugsRefined();
            grdBuglist.DataSource = dsBug;
            grdBuglist.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message.ToString();
        }
        finally
        {
            if (dsBug != null)
            {
                dsBug.Dispose();
                dsBug = null;
            }
        }
    }
    private void fillBugList()
    {
        
        objBug = new Bugs();
        try
        {
            objBug.ProjectID = Int32.Parse(ddlProjects.SelectedValue.ToString());
            dsBug = objBug.readBugsAll();
            grdBuglist.DataSource = dsBug;
            grdBuglist.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message.ToString();
        }
        finally
        {
            if (dsBug != null)
            {
                dsBug.Dispose();
                dsBug = null;
            }
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
        fillBugList();
    }
    protected void grdBuglist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HtmlAnchor popUp = null;
        Label lblSnapshot = null;
        string strpop = String.Empty;
        DropDownList ddlBugStatus = null;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ddlBugStatus = (DropDownList)e.Row.FindControl("ddlBugStatus");
            DataRow drow = dsBug.Tables[0].Rows[e.Row.RowIndex];
            ddlBugStatus.SelectedValue = drow["BugStatus"].ToString();
            
            popUp = (HtmlAnchor)e.Row.FindControl("popUp");
            lblSnapshot = (Label)e.Row.FindControl("lblSnapshot");
            if (File.Exists(MapPath("../screenShots").ToString() + "\\" + lblSnapshot.Text))
            {
                popUp.Target = "_blank";
                popUp.Name = "Snapshot";
                popUp.Title = "Snapshot";
                popUp.HRef = "http://localhost/BugTracker/MS/siteAdmin/screenShots/" + lblSnapshot.Text;

            }
            else
            {
                popUp.Target = "_blank";
                popUp.Target = "_blank";
                popUp.Name = "Snapshot";
                popUp.Title = "Snapshot";
                popUp.HRef = "http://localhost/BugTracker/MS/siteAdmin/images/NotAvailable.jpg";
            }
        }
    }
    protected void grdBuglist_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList ddlBugStatus = null;
        Label lblBID = null;
        ddlBugStatus = (DropDownList)grdBuglist.Rows[e.RowIndex].Cells[7].FindControl("ddlBugStatus");
        lblBID = (Label)grdBuglist.Rows[e.RowIndex].Cells[0].FindControl("lblBID");
        objBug = new Bugs();
        objBug.BID = Int32.Parse(lblBID.Text);
        objBug.BugStatus = ddlBugStatus.SelectedValue;
        objBug.ModifiedOn = DateTime.Now;
        objBug.intbugstatusDate();
        if (objBug.intbugstatusDate().Equals(1))
        {
            fillBugList();
        }
    }
    protected void grdBuglist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "PostComments")
        {
            Response.Redirect("Comments.aspx?Bid="+Convert.ToString(e.CommandArgument)+"&Pid="+Convert.ToString(ddlProjects.SelectedValue));
        }
        else if (e.CommandName == "BugDetail")
        {
            Response.Redirect("Bugs.aspx?Bid=" + Convert.ToString(e.CommandArgument) + "&Pid=" + Convert.ToString(ddlProjects.SelectedValue));
        }
    }
}

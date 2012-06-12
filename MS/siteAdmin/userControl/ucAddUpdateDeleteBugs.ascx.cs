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
using System.Text;
using System.Data.SqlClient;
using MSBLL;

public partial class MS_siteAdmin_userControl_ucAddUpdateDeleteBugs : System.Web.UI.UserControl
{
    public Projects objProjects = null;
    public Bugs objBugs = null;
    public Common objCommon = null;
    public int intBugID;
    
    private string strEmails;

    protected void Page_Load(object sender, EventArgs e)
    {
        hypBack.Visible = false;
        if (!this.IsPostBack)
        {
            fillddlProjects();
            
        }

        if(!String.IsNullOrEmpty(Convert.ToString(Request.QueryString["Bid"])))
        {
            intBugID = Int32.Parse(Convert.ToString(Request.QueryString["Bid"]));
            fillBugDetails();
        }
        //else if (String.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
        //{
        //    Response.Redirect("Login.aspx");
        //}

        
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

    private void fillEmailAddresses()
    {
        DataSet ds = null;
        DataTable dt = new DataTable();
        objCommon = new Common();
        objCommon.ProjectID = Int32.Parse(ddlProjects.SelectedValue.ToString());
        ds = objCommon.getEmailAddress();
        foreach (DataTable dtab in ds.Tables)
        {
           
            dt.Merge(dtab);
        }
        dlAssignTo.DataSource = dt.DefaultView;
        dlAssignTo.DataTextField = "EmailAddress";
        dlAssignTo.DataValueField = "EmailAddress";
        dlAssignTo.DataBind();

        dlEmailTo.DataSource = dt.DefaultView;
        dlEmailTo.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        objBugs = new Bugs();
        int returnStatus = 0;
        lblError.Text = String.Empty;

        try
        {

            objBugs.BID = 0;
            objBugs.BugID = Server.HtmlEncode(txtBugID.Text.Trim());
            objBugs.ProjectID = Int32.Parse(ddlProjects.SelectedValue.ToString());
            objBugs.BugSummary = Server.HtmlEncode(txtBugSummary.Text.Trim());
            objBugs.BugDesc = txtBugDesc.Text.Trim();
            objBugs.Url = txtUrl.Text.Trim();
            objBugs.Severity = ddlSeverity.SelectedValue.ToString();
            if (FileUpload1.HasFile)
            {
                if ((FileUpload1.PostedFile.ContentType == "image/jpeg") && FileUpload1.PostedFile.ContentLength < 102400)
                {
                    objBugs.Attachment = FileUpload1.PostedFile.FileName.ToString();

                    //need to save the file physically
                    if (File.Exists(MapPath("../screenShots").ToString() + "\\" + objBugs.Attachment))
                    {
                        File.Delete(MapPath("../screenShots").ToString() + "\\" + objBugs.Attachment.ToString());
                        FileUpload1.PostedFile.SaveAs(MapPath("../screenShots").ToString() + "\\" + objBugs.Attachment.ToString());
                    }
                    else
                    {
                        FileUpload1.PostedFile.SaveAs(MapPath("../screenShots").ToString() + "\\" + objBugs.Attachment.ToString());
                    }
                }
                else
                {
                    objBugs.Attachment = "";
                }
            }
            else
            {
                objBugs.Attachment = "";
            }


            objBugs.AssignTo = dlAssignTo.SelectedValue.ToString();

            objBugs.EmailTo = String.Empty;

            foreach (DataListItem ditem in dlEmailTo.Items)
            {
                CheckBox chkSelect = new CheckBox();
                chkSelect = (CheckBox)ditem.FindControl("chkCCEmails");
                if (chkSelect.Checked == true)
                {
                    objBugs.EmailTo += ',' + chkSelect.Text;
                }
            }

            objBugs.EmailTo = objBugs.EmailTo.Trim(',');
            objBugs.HitButton = "I";
            objBugs.Priority = ddlPriority.SelectedValue;
            objBugs.BugStatus = ddlBugStatus.SelectedValue;

            objBugs.insertUpdateDeleteBugs(out returnStatus);

            if (returnStatus >= 1)
            {
                //send mails to develpopers & cc to all others
                // string[] strTo = objBugs.AssignTo.ToString().Split(',');
                string[] strCc = objBugs.EmailTo.ToString().Split(',');
                objCommon = new Common();
                string From = ConfigurationManager.ConnectionStrings["adminEmailId"].ToString();
                string Subject = "Bug in project :: " + ddlProjects.SelectedItem.Text.ToString();
                int i = 0;


                string[] strToName = objBugs.AssignTo.ToString().Split('@');
                StringBuilder sBuild = new StringBuilder();
                sBuild.Append("<html><body><table><tr><td>Hi " + strToName.GetValue(i).ToString() + "</td></tr>");
                sBuild.Append("<tr><td></br></td></tr>");
                sBuild.Append("<tr><td><p>You have been assigned a new bug in Project :: " + ddlProjects.SelectedItem.Text.ToString() + "</p></td></tr>");
                sBuild.Append("<tr><td></br></td></tr>");
                sBuild.Append("<tr><td><p>To view the detail of the bug, please click the following link.</p></td></tr>");
                sBuild.Append("<tr><td></br></td></tr>");
                sBuild.Append("<tr><td><a href=http://localhost/BugTracker/MS/siteAdmin/showBuglist.aspx?pid=" + ddlProjects.SelectedValue.ToString() + "&bid=" + Convert.ToString(returnStatus) + "&email=" + dynamicEmails(objBugs.AssignTo.ToString()) + ">Show Bug List</a></td></tr>");
                sBuild.Append("<tr><td></br></td></tr>");
                sBuild.Append("<tr><td><FONT face=Arial size=2 color='navy'>");
                sBuild.Append("Regards,<BR>Pankaj Behl<BR>Software Quality Analyst<BR>");
                sBuild.Append("<img src='C:\\Inetpub\\wwwroot\\BugTracker\\MS\\siteAdmin\\images\\icon@pugmarks.gif' /><BR>");
                sBuild.Append("Pugmarks InterWeb Private Limited <BR>");

                sBuild.Append("SCO:  343-345, Sector 34-A, Chandigarh - 160 022,<BR>");
                sBuild.Append("Tel: +91-172-3911-411, +91-172-2622-753-55<BR>");
                sBuild.Append("Fax: + 91-172-2645-906<BR>");
                sBuild.Append("Pugmarks Inc. <BR>");
                sBuild.Append("1717 Park Street, Suite 110, Naperville, Illinois - 60563, USA<BR>");
                sBuild.Append("Tel: +1-630-579-1200. Fax: +1-630-579-1256 <BR>");
                sBuild.Append("Support: +1-630-364-4044. <BR>");
                sBuild.Append("www.pugmarks.in </FONT>");
                sBuild.Append("</td></tr></table></body></html>");

                bool sndTo = objCommon.sendMail(From, dynamicEmails(objBugs.AssignTo.ToString()), Subject, sBuild.ToString());
                for (int j = 0; j < strCc.Length; j++)
                {
                    StringBuilder sBuildCc = new StringBuilder();
                    sBuildCc.Append("<html><body><table><tr><td>Hi " + strToName.GetValue(i).ToString() + "</td></tr>");
                    sBuildCc.Append("<tr><td></br></td></tr>");
                    sBuildCc.Append("<tr><td><p>You have been assigned a new bug in Project :: " + ddlProjects.SelectedItem.Text.ToString() + "</p></td></tr>");
                    sBuildCc.Append("<tr><td></br></td></tr>");
                    sBuildCc.Append("<tr><td><p>To view the detail of the bug, please click the following link.</p></td></tr>");
                    sBuildCc.Append("<tr><td></br></td></tr>");
                    sBuildCc.Append("<tr><td><a href=http://localhost/BugTracker/MS/siteAdmin/showBuglist.aspx?pid=" + ddlProjects.SelectedValue.ToString() + "&bid=" + Convert.ToString(returnStatus) + "&email=" + dynamicEmails(strCc.GetValue(j).ToString()) + ">Show Bug List</a></td></tr>");
                    sBuildCc.Append("<tr><td></br></td></tr>");
                    sBuildCc.Append("<tr><td><FONT face=Arial size=2 color='navy'>");
                    sBuildCc.Append("Regards,<BR>Pankaj Behl<BR>Software Quality Analyst<BR>");
                    sBuildCc.Append("<img src='C:\\Inetpub\\wwwroot\\BugTracker\\MS\\siteAdmin\\images\\icon@pugmarks.gif' /><BR>");
                    sBuildCc.Append("Pugmarks InterWeb Private Limited <BR>");

                    sBuildCc.Append("SCO:  343-345, Sector 34-A, Chandigarh - 160 022,<BR>");
                    sBuildCc.Append("Tel: +91-172-3911-411, +91-172-2622-753-55<BR>");
                    sBuildCc.Append("Fax: + 91-172-2645-906<BR>");
                    sBuildCc.Append("Pugmarks Inc. <BR>");
                    sBuildCc.Append("1717 Park Street, Suite 110, Naperville, Illinois - 60563, USA<BR>");
                    sBuildCc.Append("Tel: +1-630-579-1200. Fax: +1-630-579-1256 <BR>");
                    sBuildCc.Append("Support: +1-630-364-4044. <BR>");
                    sBuildCc.Append("www.pugmarks.in </FONT>");
                    sBuildCc.Append("</td></tr></table></body></html>");

                    bool sndCc = objCommon.sendCC(From, dynamicEmails(strCc.GetValue(j).ToString()), Subject, sBuildCc.ToString());

                }

                Response.Redirect("showBuglist.aspx");
            }
            else
            {
                lblError.Text = "This Bug already exists in our Database.";
            }

            
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message.ToString();
        }
        finally
        {

        }
    }
    private string dynamicEmails(string dEmails)
    {
        return dEmails;
    }
    protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillEmailAddresses();
    }

    private void fillBugDetails()
    {

        SqlDataReader dr = null;
        objBugs = new Bugs();
        try
        {
            objBugs.BID = intBugID;
            dr = (SqlDataReader)objBugs.readBugDetails();
            if (dr.HasRows)
            {
                dr.Read();
                btnSave.Visible = false;
                popUp.Visible = true;
                hypBack.Visible = true;

                txtBugID.Text = dr["BugID"].ToString();
                ddlProjects.SelectedValue = dr["ProjectID"].ToString();
                txtBugSummary.Text = dr["BugSummary"].ToString();
                txtBugDesc.Text = Server.HtmlDecode(dr["BugDesc"].ToString());
                txtUrl.Text = dr["Url"].ToString();
                ddlSeverity.SelectedValue = dr["Severity"].ToString();
                ddlPriority.SelectedValue = dr["Priority"].ToString();
                ddlBugStatus.SelectedValue = dr["BugStatus"].ToString();

                tr2.Visible = false;
                tr3.Visible = false;
                FileUpload1.Visible = false;

                if (File.Exists(MapPath("../screenShots").ToString() + "\\" + dr["Attatchment"].ToString()))
                {
                    popUp.Target = "_blank";
                    popUp.Name = "Snapshot";
                    popUp.Title = "Snapshot";
                    popUp.HRef = "http://localhost/BugTracker/MS/siteAdmin/screenShots/" + dr["Attatchment"].ToString();

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
        catch
        {

        }
        finally
        {
            dr.Close();
        }
    }
}

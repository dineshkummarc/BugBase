using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MSBLL
{
    public class Common
    {
        public string strUname;
        public string strUpass;
        public string strRole;
        public int intProjectID;

        public string username
        {
            get
            {
                return strUname;
            }
            set
            {
                strUname = value;
            }
        }
        public string password
        {
            get
            {
                return strUpass;
            }
            set
            {
                strUpass = value;
            }
        }
        public string role
        {
            get
            {
                return strRole;
            }
            set
            {
                strRole = value;
            }
        }

        public int ProjectID
        {
            get
            {
                return intProjectID;
            }
            set
            {
                intProjectID = value;
            }

        }

        public Common()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int login()
        {
            int status = 0;
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;
            try
            {
                dbCommand = db.GetStoredProcCommand("bt_loginCheck");
                db.AddInParameter(dbCommand, "@username", DbType.String, username);
                db.AddInParameter(dbCommand, "@password", DbType.String, password);
                db.AddOutParameter(dbCommand, "@status", DbType.Int32, 4);
                db.ExecuteNonQuery(dbCommand);
                status = Convert.ToInt32(db.GetParameterValue(dbCommand, "@status"));
                if (status > 0)
                {

                    return 1;
                }

                else
                {

                    return 0;

                }
               
                
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                db = null;
                dbCommand = null;
               

            }


        }

        public bool sendMail(string pFrom, string pTo, string pSubject, string pMessage)
        {
 
            try
            {
              //  SmtpMail.SmtpServer = ConfigurationManager.ConnectionStrings["SMTPServerIP"].ToString();

                MailMessage msg = new MailMessage();
                System.Net.Mail.MailMessage mailMsg = new System.Net.Mail.MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = ConfigurationManager.ConnectionStrings["SMTPServerIP"].ToString();
                smtpClient.Port=25;

                mailMsg.To.Add(new System.Net.Mail.MailAddress(pTo));
                mailMsg.From=new MailAddress(pFrom,"Pugmarks Bug Tracker");
               
               // mailMsg.Sender.DisplayName = "Pugmarks Bug Tracker";
               
                mailMsg.Subject = pSubject;
                mailMsg.Body = pMessage;
                mailMsg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
              
                //for alll now
              //  msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", SmtpMail.SmtpServer.ToString());

                //for live & staging
                //msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "127.0.0.1");

              //  msg.BodyFormat = MailFormat.Html;
                smtpClient.Send(mailMsg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        public bool sendCC(string pFrom, string pCc, string pSubject, string pMessage)
        {
            try
            {
                MailMessage msg = new MailMessage();
                System.Net.Mail.MailMessage mailMsg = new System.Net.Mail.MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = ConfigurationManager.ConnectionStrings["SMTPServerIP"].ToString();
                smtpClient.Port = 25;

                mailMsg.CC.Add(new System.Net.Mail.MailAddress(pCc));
                mailMsg.From = new MailAddress(pFrom, "Pugmarks Bug Tracker");

                // mailMsg.Sender.DisplayName = "Pugmarks Bug Tracker";

                mailMsg.Subject = pSubject;
                mailMsg.Body = pMessage;
                mailMsg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;

                smtpClient.Send(mailMsg);
                return true;
                //SmtpMail.SmtpServer = ConfigurationManager.ConnectionStrings["SMTPServerIP"].ToString();

                //MailMessage msg = new MailMessage();
                //msg.From = pFrom;
                //msg.To = "";
                //msg.Cc = pCc;
                //msg.Subject = pSubject;
                //msg.Body = pMessage;
                ////for alll now
                //msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", SmtpMail.SmtpServer.ToString());

                ////for live & staging
                ////msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "127.0.0.1");

                //msg.BodyFormat = MailFormat.Html;
                //SmtpMail.Send(msg);
               
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        public DataSet getEmailAddress()
        {
            DataSet ds = null;
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;
            try
            {
                dbCommand = db.GetStoredProcCommand("bt_getEmailAddresses");
                db.AddInParameter(dbCommand, "@ProjectID", DbType.Int32,ProjectID);
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
 
            }
            catch (Exception ex)
            {
                return ds;
            }
            finally
            {

            }
        }


    }

   

}

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
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MSBLL
{
    public class Bugs
    {
        public int intBID;
        public string strBugID;
        public int intProjectID;
        public string strBugSummary;
        public string strBugDesc;
        public string strUrl;
        public string strSeverity;
        public string strPriority;
        public string strAttatchment;
        public string strBugStatus;
        public string strAssignTo;
        public string strEmailTo;
        
        public string strHitButton;

        public DateTime dtCreatedOn;
        public DateTime dtModifiedOn;

        public Bugs()
        {

        }

        public int BID
        {
            get
            {
                return intBID;
            }
            set
            {
                intBID = value;
            }

        }

        public string BugID
        {
            get
            {
                return strBugID;
            }
            set
            {
                strBugID = value;
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

        public string BugSummary
        {
            get
            {
                return strBugSummary;
            }
            set
            {
                strBugSummary = value;
            }
        }

        public string BugDesc
        {
            get
            {
                return strBugDesc;
            }
            set
            {
                strBugDesc = value;
            }
        }

        public string Url
        {
            get
            {
                return strUrl;
            }
            set
            {
                strUrl = value;
            }
        }

        public string Severity
        {
            get
            {
                return strSeverity;
            }
            set
            {
                strSeverity = value;
            }
        }

        public string Priority
        {
            get
            {
                return strPriority;
            }
            set
            {
                strPriority = value;
            }
        }

        public string Attachment
        {
            get
            {
                return strAttatchment;
            }
            set
            {
                strAttatchment = value;
            }
        }

        public string BugStatus
        {
            get
            {
                return strBugStatus;
            }
            set
            {
                strBugStatus = value;
            }
        }

        public string AssignTo
        {
            get
            {
                return strAssignTo;
            }
            set
            {
                strAssignTo = value;
            }
        }

        public string EmailTo
        {
            get
            {
                return strEmailTo;
            }
            set
            {
                strEmailTo = value;
            }
        }

        public string HitButton
        {
            get
            {
                return strHitButton;
            }
            set
            {
                strHitButton = value;
            }
        }

        public DateTime CreatedOn
        {
            get
            {
                return dtCreatedOn;
            }
            set
            {
                dtCreatedOn = value;
            }
        }

        public DateTime ModifiedOn
        {
            get
            {
                return dtModifiedOn;
            }
            set
            {
                dtModifiedOn = value;
            }
        }

        public int insertUpdateDeleteBugs(out int outBugStatus)
        {
            int status = 0;
            outBugStatus = 0;

            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;

            dbCommand = db.GetStoredProcCommand("bt_AddUpdateDeleteBugs");

            db.AddInParameter(dbCommand, "@BID", DbType.Int32, BID);
            db.AddInParameter(dbCommand, "@BugID", DbType.String, BugID);
            db.AddInParameter(dbCommand, "@ProjectID", DbType.Int32, ProjectID);
            db.AddInParameter(dbCommand, "@BugSummary", DbType.String, BugSummary);
            db.AddInParameter(dbCommand, "@BugDesc", DbType.String, BugDesc);
            db.AddInParameter(dbCommand, "@Url", DbType.String, Url);
            db.AddInParameter(dbCommand, "@Severity", DbType.String, Severity);
            db.AddInParameter(dbCommand, "@Priority", DbType.String, Priority);
            db.AddInParameter(dbCommand, "@Attatchment", DbType.String, Attachment);
            db.AddInParameter(dbCommand, "@BugStatus", DbType.String, BugStatus);
            db.AddInParameter(dbCommand, "@AssignTo", DbType.String, AssignTo);
            db.AddInParameter(dbCommand, "@EmailTo", DbType.String, EmailTo);

            db.AddInParameter(dbCommand, "@ButtonType", DbType.String, HitButton);
            db.AddOutParameter(dbCommand, "@Counter", DbType.Int32, 4);
            db.AddOutParameter(dbCommand, "@OutBugID", DbType.Int32, 4);

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    db.ExecuteNonQuery(dbCommand, transaction);

                    status = Convert.ToInt32(db.GetParameterValue(dbCommand, "@Counter"));
                    outBugStatus = Convert.ToInt32(db.GetParameterValue(dbCommand, "@OutBugID"));

                    transaction.Commit();

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
                    transaction.Rollback();
                    return -1;
                }
                finally
                {
                    db = null;
                    dbCommand = null;

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }

                }
            }
        }

        public int intbugstatusDate()
        {
           
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;

            dbCommand = db.GetStoredProcCommand("bt_updateBugStatus");

            db.AddInParameter(dbCommand, "@BID", DbType.Int32, BID);
            
            db.AddInParameter(dbCommand, "@BugStatus", DbType.String,BugStatus);
            db.AddInParameter(dbCommand, "@ModifiedOn", DbType.DateTime,ModifiedOn);

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    db.ExecuteNonQuery(dbCommand, transaction);

                    transaction.Commit();

                        return 1;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return 0;
                }
                finally
                {
                    db = null;
                    dbCommand = null;

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }

                }
            }
        }
        public DataSet readBugsAll()
        {
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;
            try
            {
                dbCommand = db.GetStoredProcCommand("bt_showBugs");
                db.AddInParameter(dbCommand, "@ProjectID", DbType.Int32, ProjectID);
                ds = db.ExecuteDataSet(dbCommand);
                return ds;

            }
            catch (Exception ex)
            {
                return ds;
            }

            finally
            {
                db = null;
                dbCommand = null;
                ds.Dispose();
            }
        }

        public DataSet readBugsRefined()
        {
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;
            try
            {
                dbCommand = db.GetStoredProcCommand("bt_showBugsRefined");
                db.AddInParameter(dbCommand, "@ProjectID", DbType.Int32, ProjectID);
                db.AddInParameter(dbCommand, "@BugID", DbType.Int32, BID);
                ds = db.ExecuteDataSet(dbCommand);
                return ds;

            }
            catch (Exception ex)
            {
                return ds;
            }

            finally
            {
                db = null;
                dbCommand = null;
                ds.Dispose();
            }
        }

        public IDataReader readBugDetails()
        {
            IDataReader dread = null;
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;
            try
            {
                dbCommand = db.GetStoredProcCommand("bt_readBugDetail");
                db.AddInParameter(dbCommand, "@BID", DbType.Int32, BID);

                dread = db.ExecuteReader(dbCommand);

                return dread;

            }
            catch (Exception ex)
            {
                return dread;
            }

            finally
            {
                db = null;
                dbCommand = null;
                dread = null;
            }
        }

    }
}

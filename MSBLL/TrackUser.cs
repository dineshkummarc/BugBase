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
    public class TrackUser
    {
        public int intProjectID;
        public int intBID;
        public string strViewedBy;
        public DateTime dtviewedDate;

        public TrackUser()
        {
            //constrctor
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

        public string ViewedBy
        {
            get
            {
                return strViewedBy;
            }
            set
            {
                strViewedBy = value;
            }
        }

        public int intTrackUserRecord()
        {

            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;

            dbCommand = db.GetStoredProcCommand("bt_TrackUser");

            db.AddInParameter(dbCommand, "@ProjectID", DbType.Int32, ProjectID);
            db.AddInParameter(dbCommand, "@BugID", DbType.Int32, BID);
            db.AddInParameter(dbCommand, "@ViewedBy", DbType.String, ViewedBy);
            

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

        public DataSet readLogFile()
        {
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;
            try
            {
                dbCommand = db.GetStoredProcCommand("bt_ViewTrackFile");
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

    }
}

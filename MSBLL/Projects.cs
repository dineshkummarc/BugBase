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
    public class Projects
    {
        public int intProjectID;
        public string strProjectName;
        public string strProjectTeam;
        public string strProjetStatus;
        public DateTime dtStartDate;
        public DateTime dtEndDate;

        public string strHitButton;


        public Projects()
        {

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
        public string ProjectName
        {
            get
            {
                return strProjectName;
            }
            set
            {
                strProjectName = value;
            }
        }
        public string ProjectTeam
        {
            get
            {
                return strProjectTeam;
            }
            set
            {
                strProjectTeam = value;
            }
        }
        public string ProjectStatus
        {
            get
            {
                return strProjetStatus;
            }
            set
            {
                strProjetStatus = value;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return dtStartDate;
            }
            set
            {
                dtStartDate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return dtEndDate;
            }
            set
            {
                dtEndDate = value;
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

        public int insertUpdateDeleteProjects()
        {
            int status = 0;
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;
            
            dbCommand = db.GetStoredProcCommand("bt_AddUpdateDeleteProjects");
            db.AddInParameter(dbCommand, "@ProjectID", DbType.Int32, ProjectID);
            db.AddInParameter(dbCommand, "@ProjectName", DbType.String, ProjectName);
            db.AddInParameter(dbCommand, "@ProjectTeam", DbType.String, ProjectTeam);
            db.AddInParameter(dbCommand, "@ProjectStatus", DbType.String, ProjectStatus);
            db.AddInParameter(dbCommand, "@StartDate", DbType.DateTime, StartDate);
            db.AddInParameter(dbCommand, "@EndDate", DbType.DateTime, EndDate);
            db.AddInParameter(dbCommand, "@ButtonType", DbType.String, HitButton);
            db.AddOutParameter(dbCommand, "@Counter", DbType.Int32,4);

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    db.ExecuteNonQuery(dbCommand, transaction);
                   
                    status = Convert.ToInt32(db.GetParameterValue(dbCommand, "@Counter"));
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

        public DataSet readProjectsAll()
        {
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;
            try
            {
                dbCommand = db.GetStoredProcCommand("bt_readAllProjects");

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

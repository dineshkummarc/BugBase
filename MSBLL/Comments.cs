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
    public class Comments
    {
        public int intCommentID;
        public int intBugID;
        public string strName;
        public string strComments;
        public string strStatus;
        public string strShowHide;


        public int CommentID
        {
            get
            { return intCommentID; }
            set
            { intCommentID = value; }
        }
        public int BugID
        {
            get
            { return intBugID; }
            set
            { intBugID = value;}
        }

        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }
        public string Comment
        {
            get { return strComments; }
            set { strComments = value; }
        }
        
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }
        public string ShowHide
        {
            get { return strShowHide; }
            set { strShowHide = value; }
        }

        public IDataReader getallComments()
        {
            IDataReader dread=null;
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;
            try
            {
                dbCommand = db.GetStoredProcCommand("bt_showComments");
                db.AddInParameter(dbCommand, "@BID", DbType.Int32, BugID);

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

        public int postComments()
        {
           
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand;

            dbCommand = db.GetStoredProcCommand("bt_PostComments");
            db.AddInParameter(dbCommand, "@CID", DbType.Int32, CommentID);
            db.AddInParameter(dbCommand, "@BugID", DbType.Int32, BugID);
            db.AddInParameter(dbCommand, "@Name", DbType.String, Name);
            db.AddInParameter(dbCommand, "@Comments", DbType.String, Comment);
            
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

    }
}

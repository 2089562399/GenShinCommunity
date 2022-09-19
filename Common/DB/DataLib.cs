using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace 原社区.Common.DB

{
    public class DataLib
    {
        private string connName = "";
        public DataLib(string connName)
        {
            this.connName = connName;
        }
        #region [===== Private ======]

        private Database GetDB()
        {
            return connName.Length == 0 ? DatabaseFactory.CreateDatabase() : DatabaseFactory.CreateDatabase(connName);
        }
        #endregion

        #region [===== DataReader =====]
        public IDataReader GetReader(string spName, params object[] arrParam)
        {
            Database db = GetDB();
            return db.ExecuteReader(spName, arrParam);
        }

        public IDataReader GetReaderSql(string sqlStr, params object[] arrParam)
        {
            Database db = GetDB();
            return db.ExecuteReader(CommandType.Text, string.Format(sqlStr, arrParam));
        }
        #endregion

        #region [===== ExecuteReturn =====]
        public int ExecuteReturn<T>(string spName, out T retValue, params object[] arrParam)
        {
            Database db = GetDB();
            DbCommand cmd = db.GetStoredProcCommand(spName, arrParam);
            int rowsAffected = db.ExecuteNonQuery(cmd);
            if (rowsAffected != 0)
            {
                retValue = (T)db.GetParameterValue(cmd, "Return_value");
            }
            else
            {
                retValue = default(T);
            }
            return rowsAffected;
        }
        #endregion

        #region [===== ExecuteReturn =====]
        public int ExecuteResult(string spName, string outParameter, out string retValue, params object[] arrParam)
        {
            Database db = GetDB();
            DbCommand cmd = db.GetStoredProcCommand(spName, arrParam);
            db.ExecuteNonQuery(cmd);

            retValue = (string)db.GetParameterValue(cmd, outParameter);

            return (int)db.GetParameterValue(cmd, "Return_value");
        }

        #endregion

        #region [===== ExecuteScalar =====]
        public T ExecuteScalar<T>(string spName, params object[] arrParam)
        {
            Database db = GetDB();
            return (T)db.ExecuteScalar(spName, arrParam);
        }

        public T ExecuteScalarSql<T>(string sqlStr, params object[] arrParam)
        {
            Database db = GetDB();
            return (T)db.ExecuteScalar(CommandType.Text, string.Format(sqlStr, arrParam));
        }

        #endregion

        #region [====== Execute ======]
        public int Execute(string spName, params object[] arrParam)
        {
            Database db = GetDB();
            return db.ExecuteNonQuery(spName, arrParam);
        }

        public int ExecuteSql(string sqlStr, params object[] arrParam)
        {
            Database db = GetDB();
            return db.ExecuteNonQuery(CommandType.Text, String.Format(sqlStr, arrParam));
        }
        #endregion
    }
}

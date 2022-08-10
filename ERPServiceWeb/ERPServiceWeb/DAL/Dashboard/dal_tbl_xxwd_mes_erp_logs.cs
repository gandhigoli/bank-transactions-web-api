using System;
using System.Web;
using System.Linq;

using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
//using WDHelpers.ConfigHelper;
//using WDHelpers.DatabaseHelper;
using System.Collections.Generic;

namespace ERPServiceWeb.DAL.Dashboard
{
    public class dal_tbl_xxwd_mes_erp_logs
    {

        #region Global Function & Params for this Class

        private string m_DatabaseName;
        private string m_DatabaseType;

        public dal_tbl_xxwd_mes_erp_logs() : this(false) { }
        public dal_tbl_xxwd_mes_erp_logs(bool isAuthenSecondaryDatabase)
        {
            //m_DatabaseName = AppConfig.GetString("Mitecs3Connection", "DatabaseName", "MESERP");
            //m_DatabaseType = AppConfig.GetString("Mitecs3Connection", "DatabaseType", "DEVELOPMENT");
        }

        //private string getMessageFromProcParm(ProcParm messageProcParm)
        //{
        //    if (messageProcParm == null)
        //        return null;

        //    string message = Convert.ToString(messageProcParm.ParmValue);
        //    if (message != null)
        //        message = message.Trim();

        //    return message;
        //}

        #endregion

        #region Current date with in 12 hours data displaying   [Dynamic data]

        /// <summary>
        /// Get DashBoard Signal Count Data
        /// </summary>
        /// <param name="_date">CurrentDate</param>
        /// <param name="message">Stored Procedure executed successfully or NOT. </param>
        /// <returns>Dataset</returns>
        //internal DataSet GetSignelData(string _date, out string message)
        //{
        //    DataSet ds = null;
        //    message = string.Empty;
        //    try
        //    {
        //        string spName = AppConfig.GetString("M3DAL", "GetLogLinkData", "usp_GetERPSignalsCount");
        //        IProcedureHelperEx ph = Mitecs3DatabaseHelperFactory.GetProcedureHelperEx(m_DatabaseName, m_DatabaseType);
        //        ph.CommandTimeout = AppConfig.GetInt("Mitecs3Connection", "CommandTimeout", ph.CommandTimeout);
        //        message = string.Empty;
        //        ProcParm messageProcParm = new ProcParm("MESSAGE", message, ProcParm.ParameterType.Char, ParameterDirection.Output, 8000);
        //        ds = ph.ProcedureResults(spName,
        //             new ProcParm("Date", _date, ProcParm.ParameterType.Char, ParameterDirection.Input),
        //            messageProcParm
        //            );
        //        message = getMessageFromProcParm(messageProcParm);
        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message;
        //    }
        //    return ds;
        //}

        //internal DataSet GetSignelData(string _date, int startTime, int endTime, string _StartTime, string _EndTime, int timeDuration, string StoredProcedureName, out string message)
        //{
        //    DataSet ds = null;
        //    message = string.Empty;
        //    try
        //    {
        //        string spName = AppConfig.GetString("M3DAL", "GetLogLinkData", StoredProcedureName);
        //        IProcedureHelperEx ph = Mitecs3DatabaseHelperFactory.GetProcedureHelperEx(m_DatabaseName, m_DatabaseType);
        //        ph.CommandTimeout = AppConfig.GetInt("Mitecs3Connection", "CommandTimeout", ph.CommandTimeout);
        //        message = string.Empty;
        //        ProcParm messageProcParm = new ProcParm("MESSAGE", message, ProcParm.ParameterType.Char, ParameterDirection.Output, 8000);
        //        ds = ph.ProcedureResults(spName,
        //             new ProcParm("Date", _date, ProcParm.ParameterType.Char, ParameterDirection.Input),
        //             new ProcParm("StartTime", startTime, ProcParm.ParameterType.Char, ParameterDirection.Input),
        //             new ProcParm("EndTime", endTime, ProcParm.ParameterType.Char, ParameterDirection.Input),
        //             new ProcParm("_StartTime", _StartTime, ProcParm.ParameterType.Char, ParameterDirection.Input),
        //             new ProcParm("_EndTime", _EndTime, ProcParm.ParameterType.Char, ParameterDirection.Input),
        //             new ProcParm("TimeDuration", timeDuration, ProcParm.ParameterType.Char, ParameterDirection.Input),
        //            messageProcParm
        //            );
        //        message = getMessageFromProcParm(messageProcParm);
        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message;
        //    }
        //    return ds;
        //}  
        
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
//using WDHelpers.ConfigHelper;
//using WDHelpers.DatabaseHelper;

namespace ERPServiceWeb.DAL
{
    public class Mitecs3DAL
    {
        private string m_DatabaseName;
        private string m_DatabaseType;

       // public Mitecs3DAL() : this(false) { }

        //public Mitecs3DAL(bool isAuthenSecondaryDatabase)
        //{
        //    m_DatabaseName = AppConfig.GetString("Mitecs3Connection", "DatabaseName", "MESERP");
        //    m_DatabaseType = AppConfig.GetString("Mitecs3Connection", "DatabaseType", "DEVELOPMENT");
        //}


        //public DataSet GetLogLinkDataFail(string _date, out string message)
        //{
        //    message = string.Empty;
        //    DataSet ds = new DataSet();

        //    try
        //    {
        //        string spName = AppConfig.GetString("M3DAL", "GetLogLinkData", "sp_XXWD_MES_ERP_LOGS_Select");
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
        //        ds.Tables.Add(new DataTable());
        //        message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message;
        //    }

        //    return ds;
        //}

        //private string getMessageFromProcParm(ProcParm messageProcParm)
        //{
        //    if (messageProcParm == null)
        //        return null;

        //    string message = Convert.ToString(messageProcParm.ParmValue);
        //    if (message != null)
        //        message = message.Trim();

        //    return message;
        //}
    }
}
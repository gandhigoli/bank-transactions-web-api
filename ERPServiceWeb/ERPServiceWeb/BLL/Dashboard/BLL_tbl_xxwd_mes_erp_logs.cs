using System;
using System.Web;
using System.Data;
using System.Linq;

using System.IO;
using System.Configuration;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using ERPServiceWeb.DAL.Dashboard;

namespace ERPServiceWeb.BLL.Dashboard
{
    public class BLL_tbl_xxwd_mes_erp_logs
    {
        dal_tbl_xxwd_mes_erp_logs _objDLL;

        #region Global Function for this Class
      
        /// <summary>
        /// Gets a Inverted DataTable
        /// </summary>
        /// <param name="table">Provided DataTable</param>
        /// <param name="columnX">X Axis Column</param>
        /// <param name="columnY">Y Axis Column</param>
        /// <param name="columnZ">Z Axis Column (values)</param>
        /// <param name="columnsToIgnore">Whether to ignore some column, it must be 
        /// provided here</param>
        /// <param name="nullValue">null Values to be filled</param> 
        /// <returns>C# Pivot Table Method  - Felipe Sabino</returns>
        private static DataTable GetInversedDataTable(DataTable table, string columnX, string columnY, string columnZ, string nullValue, bool sumValues, string _date)
        {
            //Create a DataTable to Return
            DataTable returnTable = new DataTable();

            if (columnX == "")
                columnX = table.Columns[0].ColumnName;

            //Add a Column at the beginning of the table
            returnTable.Columns.Add(columnY);

            //Read all DISTINCT values from columnX Column in the provided DataTale
            List<string> columnXValues = new List<string>();

            foreach (DataRow dr in table.Rows)
            {
                string columnXTemp = dr[columnX].ToString();
                if (!columnXValues.Contains(columnXTemp))
                {
                    //Read each row value, if it's different from others provided, add to 
                    //the list of values and creates a new Column with its value.
                    columnXValues.Add(columnXTemp);
                    returnTable.Columns.Add(columnXTemp);
                }
            }

            //Verify if Y and Z Axis columns re provided
            if (columnY != "" && columnZ != "")
            {
                //Read DISTINCT Values for Y Axis Column
                List<string> columnYValues = new List<string>();

                foreach (DataRow dr in table.Rows)
                {
                    if (!columnYValues.Contains(dr[columnY].ToString()))
                        columnYValues.Add(dr[columnY].ToString());
                }

                //Loop all Column Y Distinct Value
                foreach (string columnYValue in columnYValues)
                {
                    //Creates a new Row
                    DataRow drReturn = returnTable.NewRow();
                    drReturn[0] = columnYValue;
                    //foreach column Y value, The rows are selected distincted
                    DataRow[] rows = table.Select(columnY + "='" + columnYValue + "'");

                    //Read each row to fill the DataTable
                    foreach (DataRow dr in rows)
                    {
                        string rowColumnTitle = dr[columnX].ToString();

                        //Read each column to fill the DataTable
                        foreach (DataColumn dc in returnTable.Columns)
                        {
                            if (dc.ColumnName == rowColumnTitle)
                            {
                                //If Sum of Values is True it try to perform a Sum
                                //If sum is not possible due to value types, the value 
                                // displayed is the last one read
                                if (sumValues)
                                {
                                    try
                                    {
                                        drReturn[rowColumnTitle] =
                                             Convert.ToDecimal(drReturn[rowColumnTitle]) +
                                             Convert.ToDecimal(dr[columnZ]);
                                    }
                                    catch
                                    {
                                        drReturn[rowColumnTitle] = dr[columnZ];
                                    }
                                }
                                else
                                {
                                    drReturn[rowColumnTitle] = dr[columnZ];
                                }
                            }
                        }
                    }
                    returnTable.Rows.Add(drReturn);
                }
            }
            else
            {
                throw new Exception("The columns to perform inversion are not provided");
            }

            //if a nullValue is provided, fill the datable with it
            if (nullValue != "")
            {
                foreach (DataRow dr in returnTable.Rows)
                {
                    foreach (DataColumn dc in returnTable.Columns)
                    {
                        if (dr[dc.ColumnName].ToString() == "")
                            dr[dc.ColumnName] = nullValue;
                    }
                }
            }
            return returnTable;
        }

        private List<string> SplitHours_TimeSlot(string SHr, string EHr, int timeinterval)
        {
            var Hrslst = new List<string>();
            try
            {
                long TotalTime = 0;
                TotalTime = DateAndTime.DateDiff(DateInterval.Hour, Convert.ToDateTime(SHr), Convert.ToDateTime(EHr));
                TotalTime = TotalTime * 2 + 1;
                //int timeinterval = 0;
                //timeinterval = 30;
                DateTime CurrentHrs;
                DateTime HisHrs;
                CurrentHrs = Convert.ToDateTime(SHr);
                for (int i = 1; i <= TotalTime; i++)
                {
                    HisHrs = CurrentHrs;
                    CurrentHrs = CurrentHrs.AddMinutes(timeinterval);
                    if (CurrentHrs > Convert.ToDateTime(EHr))
                    {
                        break;
                    }
                    else
                    {
                        Hrslst.Add(HisHrs.ToString("HH:mm") + " - " + CurrentHrs.ToString("HH:mm"));
                    }
                }

            }
            catch (Exception ex)
            {
                String msg = ex.Message;
            }
            return Hrslst;
        }

        internal DataSet GetSignelData(string _date, out string message)
        {
            message = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                _objDLL = new dal_tbl_xxwd_mes_erp_logs();
                ds = _objDLL.GetSignelData(_date, out message);
            }
            catch (Exception ex)
            {
                message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message;
            }
            finally
            {
                _objDLL = null;
            }
            return ds;
        }

        #endregion

        #region Dashboard (Folder Name)
        /// <param name="_date">Selected Date(yyyy-MM-dd)</param>
        /// <param name="startTime">Selected Start Hour</param>
        /// <param name="endTime">Selected End Hour</param>
        /// <param name="timeDuration">Time Slot</param>
        /// <param name="message">Stored Procedure executed successfully or NOT. 
        /// <param name="retun">Return the datatable with data or without data.
        internal DataTable Get_12Hours_SignelData(string _date, int startTime, int endTime, int timeDuration, out string message)
        {
            message = string.Empty;
            DataTable dt = new DataTable();
            try
            {
               dt= GetSignelData(_date, startTime, endTime, timeDuration, out message);
            }
            catch (Exception ex)
            {
                message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message;
            }
            return dt;
        }

        #endregion

        #region ERPSignals (Folder Name)
        /// <param name="_date">Selected Date(yyyy-MM-dd)</param>
        /// <param name="startTime">Selected Start Hour</param>
        /// <param name="endTime">Selected End Hour</param>
        /// <param name="timeDuration">Time Slot</param>
        /// <param name="message">Stored Procedure executed successfully or NOT. 
        /// <param name="retun">Return the datatable with data or without data.
        internal DataTable GetERPSignelData(string _date, int startTime, int endTime, int timeDuration, out string message)
        {
            message = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                dt = GetSignelData(_date, startTime, endTime, timeDuration, out message);
                #region Timeslot checking
                string _StartTime = string.Empty;
                string _EndTime = string.Empty;
                if (startTime <= 9)
                {
                    _StartTime = "0" + startTime + ":00";
                }
                else
                {
                    _StartTime = startTime + ":00";
                }
                if (endTime <= 9)
                {
                    _EndTime = "0" + endTime + ":00";
                }
                else
                {
                    _EndTime = endTime + ":00";
                }
                if (endTime == 24)
                {
                    _EndTime = "00" + ":00";
                    endTime = 00;
                }
                #endregion
            }
            catch (Exception ex)
            {
                message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message;
            }
            return dt;
        }

        #endregion

        #region Database Table name =MESERPDB)
        /// <param name="_date">Current Date (yyyy-MM-dd)</param>
        /// <param name="startTime">Enddate-12</param>
        /// <param name="endTime">Current Hour</param>
        /// <param name="timeDuration">Time Slot (15 or 30 or 60), select from Web Config file</param>
        /// <param name="message">Return message</param>
        /// <returns>return datatable</returns>
        internal DataTable GetSignelData(string _date, int startTime, int endTime, int timeDuration, out string message)
        {
            message = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                _objDLL = new dal_tbl_xxwd_mes_erp_logs();
                #region Timeslot checking
                string _StartTime = string.Empty;
                string _EndTime = string.Empty;
                if (startTime <= 9)
                {
                    _StartTime = "0" + startTime + ":00";
                }
                else
                {
                    _StartTime = startTime + ":00";
                }
                if (endTime <= 9)
                {
                    _EndTime = "0" + endTime + ":00";
                }
                else
                {
                    _EndTime = endTime + ":00";
                }
                if (endTime == 24)
                {
                    _EndTime = "00" + ":00";
                    endTime = 00;
                }
                #endregion

                DataSet ds = _objDLL.GetSignelData(_date, startTime, endTime, _StartTime, _EndTime, timeDuration, "usp_GetERPLogs_TimeslotGap", out message);
                DataSet ds2 = _objDLL.GetSignelData(_date, startTime, endTime, _StartTime, _EndTime, timeDuration, "usp_GetERPLogs_TimeSlot", out message);

                #region Update TimeSlot Data
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        int Mints_diff = Convert.ToInt32(ds.Tables[0].Rows[i]["Mints_diff"]);
                        if (Mints_diff > 1)
                        {
                            string _timeslot = ds.Tables[0].Rows[i]["TimeSlot"].ToString();
                            string[] _timesplit = _timeslot.Split('-');
                            string sHr = _timesplit[0].ToString();
                            string eHr = _timesplit[1].ToString();
                            List<string> obj = SplitHours_TimeSlot(sHr.Trim(), eHr.Trim(), timeDuration);
                            // Loop the List and find the record from datatable and Update
                            for (int j = 0; j < obj.Count; j++)
                            {
                                string _type = ds.Tables[0].Rows[i]["Type"].ToString();
                                string _status = ds.Tables[0].Rows[i]["STATUS"].ToString();
                                string _time_slot = obj[j].ToString();
                                if (ds2.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in ds2.Tables[0].Rows) // search whole table
                                    {
                                        string _dbtimeslot = dr["TimeSlot"].ToString();
                                        string _dbtype = dr["Type"].ToString();
                                        if (_dbtimeslot == _time_slot && _dbtype == _type) // if _dbtimeslot==_time_slot && _dbtype == _type
                                        {
                                            dr["Status"] = _status; //_status //change the Status
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                dt = GetInversedDataTable(ds2.Tables[0], "TimeSlot", "Type", "STATUS", "3", true, _date);// Status =3 (Missing Records, it means record didn't insert, in that time period)
                ds.Dispose();
                ds2.Dispose();
            }
            catch (Exception ex)
            {
                message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message;
            }
            finally
            {
                _objDLL = null;
            }
            return dt;
        }
        #endregion

    }
}
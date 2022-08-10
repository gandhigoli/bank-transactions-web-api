using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;
using System.Configuration;
//using ERPServiceWeb.BLL.Dashboard;

namespace ERPServiceWeb.Dashboard
{
    public partial class ERPDashboard : System.Web.UI.Page
    {
        //BLL_tbl_xxwd_mes_erp_logs _objBLL =null;
        //DateTime date = DateTime.Now; 
        //List<string> _gvtooltip = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // Bind_DefaultTimeSlotData();
            }
        }

        ///// <summary>
        ///// Bind the Gridview with below params
        ///// _date       :  CurrentDate
        ///// startTime   :  CurrentHour-12
        ///// endTime     :  Current Hour
        ///// timeDuration : Time Slot
        ///// message     :  Stored Procedure executed successfully or NOT.
        ///// </summary>
        //private void Bind_DefaultTimeSlotData()
        //{
        //    DataTable dt = new DataTable();
        //    string _time = string.Empty;
        //    try
        //    {
        //        string _endTime = date.ToString("HH");
        //        int endTime = Convert.ToInt32(_endTime);
        //        int startTime = endTime - 12;
        //        string message = string.Empty;
        //        string _date = date.ToString("yyyy-MM-dd");
        //        int timeDuration = Convert.ToInt32(ConfigurationManager.AppSettings["Minutes"]);

        //        if (startTime < 0)
        //        {
        //            startTime = 0;
        //        }
        //        _objBLL = new BLL_tbl_xxwd_mes_erp_logs();
        //        dt = _objBLL.Get_12Hours_SignelData(_date, startTime, endTime, timeDuration, out message);

        //        #region Gridview Header Store in list object for displaying in Tooltip (bcoz Gridview Header Font-Size="0.7em")
        //        if (dt.Columns.Count > 0)
        //        {
        //            _gvtooltip = new List<string>();
        //            for (int i = 0; i < dt.Columns.Count; i++)
        //            {
        //                string _headername = dt.Columns[i].ColumnName.ToString();
        //                _gvtooltip.Add(_headername);
        //            }
        //        }
        //        #endregion

        //        if (dt.Rows.Count > 0)
        //        {
        //            DataView dv = dt.DefaultView;
        //            dv.Sort = "Type";
        //            grd_erpSignels.DataSource = dv;
        //            grd_erpSignels.DataBind();
        //            dv.Dispose();
        //        }
        //        else
        //        {
        //            grd_erpSignels.DataSource = dt;
        //            grd_erpSignels.DataBind();
        //        }

        //        #region TimeSlot Spliting and displaying at Sub title
        //        string _StartTime = string.Empty;
        //        string _EndTime = string.Empty;
        //        if (startTime <= 9)
        //        {
        //            _StartTime = "0" + startTime + ":00 AM";
        //        }
        //        else
        //        {
        //            _StartTime = startTime + ":00 PM";
        //        }
        //        if (endTime <= 9)
        //        {
        //            _EndTime = "0" + endTime + ":00 AM";
        //        }
        //        else
        //        {
        //            _EndTime = endTime + ":00 PM";
        //        }
        //        if (endTime == 24)
        //        {
        //            _EndTime = "00" + ":00 PM";
        //        }
        //        b_title.InnerText = "Today Signal Data between " + _StartTime + " to " + _EndTime + " hours.";
        //        #endregion


        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //    }
        //    finally
        //    {
        //        dt.Dispose();
        //        _objBLL = null;
        //        _gvtooltip = null;
        //    }
        //}

        ///// <summary>
        ///// Apply Colors based on Status
        ///// 0 : Red
        ///// 1 : Yellow
        ///// 4 : White [Missing Records]
        ///// </summary>
        //protected void grd_erpSignels_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        int ColumnCount = e.Row.Cells.Count;
        //        e.Row.Cells[0].Font.Bold = true;
        //        for (int j = 1; j <= ColumnCount - 1; j++)
        //        {
        //            if (e.Row.Cells[j].Text == "0")
        //            {
        //                e.Row.Cells[j].BackColor = System.Drawing.Color.Red;
        //                e.Row.Cells[j].ForeColor = System.Drawing.Color.Red;
        //            }
        //            else if (e.Row.Cells[j].Text == "1")
        //            {
        //                e.Row.Cells[j].BackColor = System.Drawing.Color.Yellow;
        //                e.Row.Cells[j].ForeColor = System.Drawing.Color.Yellow;
        //            }
        //            else if (e.Row.Cells[j].Text == "4")
        //            {
        //                e.Row.Cells[j].ForeColor = System.Drawing.Color.White;
        //                e.Row.Cells[j].BackColor = System.Drawing.Color.White;
        //            }
        //            else
        //            {
        //                e.Row.Cells[j].ForeColor = System.Drawing.Color.Pink;
        //                e.Row.Cells[j].BackColor = System.Drawing.Color.Pink;
        //            }
        //        }
        //    }
        //    if (_gvtooltip.Count > 0)
        //    {
        //        for (int i = 0; i < _gvtooltip.Count; i++)
        //        {
        //            e.Row.Cells[i].ToolTip = _gvtooltip[i].ToString();
        //        }
        //    }
        //}
    }
}
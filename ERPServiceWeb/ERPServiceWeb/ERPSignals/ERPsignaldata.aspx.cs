using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
//using ERPServiceWeb.BLL.Dashboard;

namespace ERPServiceWeb.ERPSignals
{
    public partial class ERPsignaldata : System.Web.UI.Page
    {
        DateTime date = DateTime.Now;
       // BLL_tbl_xxwd_mes_erp_logs _objBLL = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DateTime currentdate = DateTime.Now;
                //txt_hoursdate.Text = currentdate.ToString("yyyy-MM-dd");
                ////Current date can be select but not future date.  
                //cal_hoursdate.EndDate = DateTime.Now;
                ////dropdownBind();

                //// Hours Binding to Dropdownlits
                //int hours = date.Hour;
                //HoursdropdownBind(hours);

            }
        }

        //#region Events Time Auto Binding
        //protected void txt_hoursdate_TextChanged(object sender, EventArgs e)
        //{
        //    string userdate = txt_hoursdate.Text.Trim();
        //    var currentdate = DateTime.Now.ToString("yyyy-MM-dd");
        //    var _difference = Convert.ToDateTime(currentdate) - Convert.ToDateTime(userdate);
        //    if (_difference.ToString() == "00:00:00")// User will select Current date, based on Current time, i will display TimeSlot
        //    {
        //        int hours = date.Hour;
        //        HoursdropdownBind(hours);
        //    }
        //    else
        //    {
        //        HoursdropdownBind(24);
        //    }
        //}

        ///// <summary>
        ///// Bind the Data to DropDown lit, in Dynamically
        ///// Removing 0th Record from EndHour DropDown List
        ///// </summary>
        ///// <param name="hours">hour param</param>
        //private void HoursdropdownBind(int hours)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt.Columns.AddRange(new DataColumn[1] { new DataColumn("hours", typeof(string)) });
        //        for (int i = 0; i < hours; i++)
        //        {
        //            dt.Rows.Add(i);
        //        }
        //        if (dt.Rows.Count > 0)
        //        {
        //            //Start Hour
        //            ddl_StartHours.DataTextField = "hours";
        //            ddl_StartHours.DataSource = dt;
        //            ddl_StartHours.DataBind();
        //            EndHourBind(hours);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //    }
        //    finally
        //    {
        //        dt.Dispose();
        //    }
        //}

        ///// <summary>
        ///// Update EndHour Dropdown List
        ///// </summary>
        ///// <param name="hours">Hour Data coming from StartHour(Dropdown List)</param>
        //private void EndHourBind(int hours)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        int startTime = Convert.ToInt32(ddl_StartHours.SelectedItem.ToString().Trim());
        //        dt.Columns.AddRange(new DataColumn[1] { new DataColumn("hours", typeof(string)) });
        //        for (int i = startTime + 1; i < hours + 1; i++)
        //        {
        //            dt.Rows.Add(i);
        //        }

        //        ddl_EndHour.DataTextField = "hours";
        //        ddl_EndHour.DataSource = dt;
        //        ddl_EndHour.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //    }
        //    finally
        //    {
        //        dt.Dispose();
        //    }
        //}

        ///// <summary>
        ///// Update End Hour based on Start Hour
        ///// </summary>
        //protected void ddl_StartHours_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string userdate = txt_hoursdate.Text.Trim();
        //        var currentdate = DateTime.Now.ToString("yyyy-MM-dd");
        //        var _difference = Convert.ToDateTime(currentdate) - Convert.ToDateTime(userdate);
        //        if (_difference.ToString() == "00:00:00")// User will select Current date, based on Current time, i will display TimeSlot
        //        {
        //            int hours = date.Hour;
        //            EndHourBind(hours);
        //        }
        //        else
        //        {
        //            EndHourBind(24);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //    }
        //}

        //#endregion

        ///// <summary>
        ///// Bind the Gridview with below params
        ///// _date       :  CurrentDate
        ///// startTime   :  CurrentHour-12
        ///// endTime     :  Current Hour
        ///// timeDuration : Time Slot
        ///// message     :  Stored Procedure executed successfully or NOT.
        ///// </summary>
        //protected void btn_hoursdata_Click(object sender, EventArgs e)
        //{
        //    string message = string.Empty;
        //    DataTable dt_hr = new DataTable();
        //    try
        //    {
        //        string _date = txt_hoursdate.Text.Trim();
        //        int startTime = Convert.ToInt32(ddl_StartHours.SelectedItem.ToString().Trim());
        //        int endTime = Convert.ToInt32(ddl_EndHour.SelectedItem.ToString().Trim());
        //        int timeDuration = Convert.ToInt32(ConfigurationManager.AppSettings["Minutes"]);
        //        _objBLL = new BLL_tbl_xxwd_mes_erp_logs();
        //        dt_hr = _objBLL.GetSignelData(_date, startTime, endTime, timeDuration, out message);

        //        if (dt_hr.Rows.Count > 0)
        //        {
        //            DataView dv = dt_hr.DefaultView;
        //            dv.Sort = "Type";
        //            grd_erpSigneldata.DataSource = dv;
        //            grd_erpSigneldata.DataBind();
        //            dv.Dispose();
        //        }
        //        else
        //        {
        //            grd_erpSigneldata.DataSource = dt_hr;
        //            grd_erpSigneldata.DataBind();
        //        }
        //        b_title.InnerText = "Signal Data between " + startTime + " to " + endTime + " hours data.";
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //    }
        //    finally
        //    {
        //        dt_hr.Dispose();
        //        _objBLL = null;
        //    }
        //}

        ///// <summary>
        ///// Apply Colors based on Status
        ///// 0 : Red
        ///// 1 : Yellow
        ///// 4 : White [Missing Records]
        ///// </summary>
        //protected void grd_erpSigneldata_RowDataBound(object sender, GridViewRowEventArgs e)
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
        //                e.Row.Cells[j].ForeColor = System.Drawing.Color.White;
        //                e.Row.Cells[j].BackColor = System.Drawing.Color.White;
        //            }
        //        }
        //    }
        //}

    }
}
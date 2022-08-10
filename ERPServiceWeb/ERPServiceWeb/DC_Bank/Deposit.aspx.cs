using ERPServiceWeb.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPServiceWeb.DC_Bank
{
    public partial class Deposit : System.Web.UI.Page
    {
        //string _webAPIurl = "http://localhost:62530/api/hello";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            
            }
        }

        #region Commented [Button/

        //protected void Submit(object sender, EventArgs e)
        //{
        //    bool rtnval = false;
        //    try
        //    {
        //        //string _enterAccNo = txtenteraccountnumber.Text.ToString();
        //        //string _currentAccName = txtname.Text.ToString();
        //        //string _currentAccBalance = lblcurrentbalance.Text.ToString();
        //        //string _modetype = ddlmode.SelectedValue.ToString();
        //        //string _depositamount = txtdepositamount.Text.ToString();

        //        // Insert Deposit Amount using Web API
        //        clsDeposit objdeposit = new clsDeposit();

        //        objdeposit._enterAccNo = txtenteraccountnumber.Text.ToString();
        //        objdeposit._currentAccName = txtname.Text.ToString();
        //        objdeposit._currentAccBalance =Convert.ToInt32(lblcurrentbalance.Text.ToString());
        //        objdeposit._modetype = ddlmode.SelectedValue.ToString();
        //        objdeposit._depositamount = Convert.ToInt32(txtdepositamount.Text.ToString());
        //        var response = "";
        //        var request = (HttpWebRequest)WebRequest.Create(_webAPIurl);
        //        request.Method = "GET";
        //        request.ContentType = "application/json";
        //        using (var response1 = request.GetResponse())
        //        {
        //            using (var reader = new StreamReader(response1.GetResponseStream()))
        //            {
        //                response = reader.ReadToEnd();
        //            }
        //        }



        //        if (rtnval)
        //        {

        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lot(s) successfully Terminated')", true);
        //        }
        //        else
        //        {

        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lot(s) successfully Terminated')", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogWriter.LogWrite(this.GetType().Name + " Exception : " + ex.Message + ", Inner Exception : " + ex.InnerException.Message);
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lot(s) successfully Terminated')", true);
        //    }

        //}
        //protected void Clear(object sender, EventArgs e)
        //{
        //    txtname.Text = "";
        //    txtenteraccountnumber.Text = "";
        //    lblcurrentbalance.Text = "";
        //    ddlmode.SelectedValue = "-1";
        //    txtdepositamount.Text = "";
        //}

        #endregion
    }
}
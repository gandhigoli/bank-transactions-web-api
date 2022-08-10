using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace ERPServiceWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    lbl_userid.Text = Environment.UserName;
            //    // Set Anti-XSRF token
            //    ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            //    ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            //}
            //else
            //{
            //    // Validate the Anti-XSRF token
            //    if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
            //        || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            //    {
            //        throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            //    }
            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}
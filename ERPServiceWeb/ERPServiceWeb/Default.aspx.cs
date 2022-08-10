using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPServiceWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        //public static string GetApi(string ApiUrl)
        //{
        //    var responseString = "";
        //    var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
        //    request.Method = "GET";
        //    request.ContentType = "application/json";
        //    using (var response1 = request.GetResponse())
        //    {
        //        using (var reader = new StreamReader(response1.GetResponseStream()))
        //        {
        //            responseString = reader.ReadToEnd();
        //        }
        //    }
        //    return responseString;
        //}
    }
}
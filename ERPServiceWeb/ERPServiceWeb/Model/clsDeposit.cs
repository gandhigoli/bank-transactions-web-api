using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPServiceWeb.Model
{
    public class clsDeposit
    {
        public string _enterAccNo { get; set; }
        public string _currentAccName { get; set; }
        public int _currentAccBalance { get; set; }
        public string _modetype { get; set; }
        public int _depositamount { get; set; }
    }
}
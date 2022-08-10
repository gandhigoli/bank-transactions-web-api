using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPServiceWeb.Model
{
    public class clsTransferMoney
    {
        public string _fromaccountnumber { get; set; }
        public string _fromaccountname { get; set; }
        public int _fromaccountcurrentbalance { get; set; }
        public string _destinationAccount { get; set; }
        public int _depositamount { get; set; }
    }
}
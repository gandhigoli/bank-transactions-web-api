using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI2.Models
{
    public class clsDeposit
    {
        public string _enterAccNo { get; set; }
        public string _currentAccName { get; set; }
        public decimal _currentAccBalance { get; set; }
        public string _modetype { get; set; }
        public int _depositamount { get; set; }
    }
}
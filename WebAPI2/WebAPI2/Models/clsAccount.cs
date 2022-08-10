using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI2.Models
{
    public class clsAccount
    {
        public string _fname { get; set; }
        public string _lname { get; set; }
        public string _bod { get; set; }
        public string _Gender { get; set; }
        public string _email { get; set; }
        public string _phone { get; set; }
        public string _accountid { get; set; }
        public int _balanceamount { get; set; }
    }
}
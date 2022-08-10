using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI2.Controllers
{
    public class apiDepositController : Controller
    {
        // GET: apiDeposit
        [Route("api/apiDeposit")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
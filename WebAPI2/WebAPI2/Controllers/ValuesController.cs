using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using WebAPI2.Models;
using WebAPI2.Repository;

namespace WebAPI2.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {

        string Conn = @"Data Source=4XQBBS2\SQLEXPRESS;Initial Catalog=DC_Bank;Integrated Security=True";
        //creating the object of BankRepository class  
        static BankRepository repository = new BankRepository();
        #region Commented

        // GET api/values
        //public string Get()
        //{
        //    var resultds = GetCustomerInfor();
        //    var res = Newtonsoft.Json.JsonConvert.SerializeObject(resultds);
        //    return res;

        //   // return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}
        //public string GetCustomerInfor()
        //{
        //    return "value";
        //}
        #endregion

        [HttpGet]
        public DataSet GetCustomerInfor(string AccNo)
        {
            DataSet ds = new DataSet("AccontInfo");
            using (SqlConnection con = new SqlConnection(Conn))
            {
                try
                {
                    string query = @"SELECT [Fname]
                                      ,[Lname],[BOD],[Gender],[Email],[PhoneNumber]
                                      ,[AccountID],[AccountBalance],[TransationDatetime]
                                  FROM[DC_Bank].[dbo].[tbl_CustomerAccounts] where AccountID='"+ AccNo + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    LogWriter.LogWrite(this.GetType().Name + " Exception : " + ex.Message + ", Inner Exception : " + ex.InnerException.Message);
                }
            }
            return ds;
        }

      
        // POST api/values
        [HttpPost]
        public string Insert_CustomerInfo(clsAccount obj)
        {
            var response = repository.InsertCustomerInfo(obj);
            return response;
        }

      
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

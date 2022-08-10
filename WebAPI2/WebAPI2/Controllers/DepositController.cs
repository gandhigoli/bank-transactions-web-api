using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI2.Models;
using WebAPI2.Repository;

namespace WebAPI2.Controllers
{
    public class DepositController : ApiController
    {
        //creating the object of BankRepository class  
        static BankRepository repository = new BankRepository();
        string Conn = @"Data Source=4XQBBS2\SQLEXPRESS;Initial Catalog=DC_Bank;Integrated Security=True";

        #region Commented

        // GET: Deposit
        // public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Deposit/GetDepositData/5
        #endregion

        // [HttpGet]
        public DataSet GetDepositData(string AccNo)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Conn))
            {
                try
                {
                    string query = @"SELECT [DepositID],[AccountID]
                                      ,[Name],[CurrentBalance],[Mode],[DepositAmount],[TransationDatetime]
                                       FROM [DC_Bank].[dbo].[tbl_Deposit] where AccountID='"+AccNo+"'";
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

        [System.Web.Http.HttpPost]
        public string InsertDeposit(clsDeposit obj)
        {
            var response = repository.InsertDepositAmount(obj);
            return response;
        }
        #region Commented

        // GET: Deposit/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Deposit/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Deposit/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Deposit/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Deposit/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Deposit/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
   
        #endregion
    
    }
}

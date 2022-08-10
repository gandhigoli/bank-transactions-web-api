using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using WebAPI2.Models;
using System.Web.Http;
using WebAPI2.Repository;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace WebAPI2.Controllers
{
    public class TransferMoneyController : ApiController
    {
        //creating the object of BankRepository class  
        static BankRepository repository = new BankRepository();
        string Conn = @"Data Source=4XQBBS2\SQLEXPRESS;Initial Catalog=DC_Bank;Integrated Security=True";

        //// GET: TransferMoney
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: TransferMoney/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: TransferMoney/Create
        [System.Web.Http.HttpGet]
        public DataSet GetTransationData(string TransactionAccNo)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Conn))
            {
                try
                {
                    string query = @"SELECT TOP 1000 [TransactionID]
                                  ,[FromAccountID],[FromAccountName],[FromAccountBalance]
                                  ,[DestinationAccountID],[TransferAmount],[TransationDatetime]
                                  FROM [DC_Bank].[dbo].[tbl_TransferMoney]  where FromAccountID='" + TransactionAccNo + "'";
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

        // POST: TransferMoney/Create
        [System.Web.Http.HttpPost]
        public string Insert_TransferMoneyAmount(clsTransferMoney obj)
        {
            //calling BankRepository Class Method and storing Repsonse   
            var response = repository.InsertTransferMoneyAmount(obj);
            return response;
        }

        //// GET: TransferMoney/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TransferMoney/Edit/5
        //[System.Web.Http.HttpPost]
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

        // GET: TransferMoney/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: TransferMoney/Delete/5
        //[System.Web.Http.HttpPost]
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
    }
}

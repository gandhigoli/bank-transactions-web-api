using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPI2.Models;

namespace WebAPI2.Repository
{
    public class BankRepository
    {
        string Conn = ConfigurationManager.ConnectionStrings["DCBankConnection"].ToString();

        public string InsertCustomerInfo(clsAccount obj)
        {
            string rtnval = string.Empty;
            if (obj != null)
            {
                //SqlTransaction objTrans = null;
                using (SqlConnection con = new SqlConnection(Conn))
                {
                    try
                    {
                        con.Open();
                        #region Commented Code [Inline Insert]
                        //objTrans = con.BeginTransaction();
                        string Gender = (obj._Gender == null) ? "0" : obj._Gender;
                        string query = "INSERT INTO [DC_Bank].[dbo].[tbl_CustomerAccounts](Fname,Lname,BOD,Gender,Email,PhoneNumber,AccountID,AccountBalance)" +
                            " Values('" + obj._fname + "','" + obj._lname + "','" + obj._bod + "','" + Gender + "','" + obj._email + "'," +
                            "'" + obj._phone + "','" + obj._accountid + "','" + obj._balanceamount + "') ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        #endregion

                        #region Stored Procedure
                        //SqlCommand cmd = new SqlCommand("sp_StoreCustomerInfor", con);
                        //cmd.Parameters.AddWithValue("@Fname", obj._fname);
                        //cmd.Parameters.AddWithValue("@Lname", obj._lname);
                        //cmd.Parameters.AddWithValue("@BOD", obj._bod);
                        //cmd.Parameters.AddWithValue("@Gender", (obj._Gender==null)?"0": obj._Gender);
                        //cmd.Parameters.AddWithValue("@Email", obj._email);
                        //cmd.Parameters.AddWithValue("@PhoneNumber", obj._phone);
                        //cmd.Parameters.AddWithValue("@AccountID", obj._accountid);
                        //cmd.Parameters.AddWithValue("@AccountBalance", obj._balanceamount);
                        #endregion

                        int i = cmd.ExecuteNonQuery(); 
                        //objTrans.Commit();
                        if (i >= 1)
                        {
                            rtnval = "New Customer Added Successfully";
                        }
                        else
                        {
                            rtnval = "Customer Not Added";
                        }
                    }
                    catch (Exception ex)
                    {
                        rtnval = ex.Message;
                        //LogWriter.LogWrite(this.GetType().Name + " Exception : " + ex.Message + ", Inner Exception : " + ex.InnerException.Message);
                        // objTrans.Rollback();
                    }
                    finally
                    {
                        con.Close();
                    }
                    return rtnval;
                }
            }
            else
            {
                return "No data passing to insert (Object is null)";
            }
        }

        public string InsertDepositAmount(clsDeposit obj)
        {
            string rtnval = string.Empty;
            //SqlTransaction objTrans = null;
            using (SqlConnection con = new SqlConnection(Conn))
            {
                try
                {
                    decimal _depositamount = obj._depositamount;// 1000
                    decimal _actuvalamt = 0;
                    decimal _deductionamt = 0;

                    _deductionamt = Convert.ToDecimal(_depositamount * 0.001M);// 1B


                    _actuvalamt = obj._depositamount - _deductionamt;// 1000-1 = 999
                    decimal totalAmount = obj._currentAccBalance + _actuvalamt; // Full Amount(10) +999 = 1009
                    con.Open();

                    #region Commented [Inline Insert]
                    //objTrans = con.BeginTransaction();
                    string query = "INSERT INTO [dbo].[tbl_Deposit]([AccountID],[Name],[CurrentBalance],[Mode],[DepositAmount]) " +
                        " Values('" + obj._enterAccNo + "','" + obj._currentAccName + "','" + totalAmount + "'," +
                        "'" + obj._modetype + "','" + _actuvalamt + "')";

                    query = query + "  UPDATE [DC_Bank].[dbo].[tbl_CustomerAccounts] SET  AccountBalance = '"+ totalAmount + "' WHERE  AccountID ='"+ obj._enterAccNo + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    #endregion

                    #region Stored Procedure
                    //SqlCommand cmd = new SqlCommand("sp_UpdateCustomerBalance", con);
                    //cmd.Parameters.AddWithValue("@AccountID", obj._enterAccNo);
                    //cmd.Parameters.AddWithValue("@Name", obj._currentAccName);
                    ////cmd.Parameters.AddWithValue("@CurrentBalance", obj._currentAccBalance);
                    //cmd.Parameters.AddWithValue("@Mode", obj._modetype);
                    //cmd.Parameters.AddWithValue("@DepositAmount", obj._depositamount);
                    #endregion
                    int i = cmd.ExecuteNonQuery(); // Throws exception due to foreign key constraint   
                    //objTrans.Commit();
                    if (i >= 1)
                    {
                        rtnval = "New Deposit Added Successfully";
                    }
                    else
                    {
                        rtnval = "Deposit Not Added";
                    }
                }
                catch (Exception ex)
                {
                    LogWriter.LogWrite(this.GetType().Name + " Exception : " + ex.Message + ", Inner Exception : " + ex.InnerException.Message);
                    //objTrans.Rollback();
                }
                finally
                {
                    con.Close();
                }
            }
            return rtnval;

        }

        public string InsertTransferMoneyAmount(clsTransferMoney obj)
        {
            string rtnval = string.Empty;
            //SqlTransaction objTrans = null;
            using (SqlConnection con = new SqlConnection(Conn))
            {
                try
                {
                    con.Open();
                    //objTrans = con.BeginTransaction();
                    #region Commented Code [Inline Insert]
                    string query = "Insert  INTO dbo.tbl_TransferMoney([FromAccountID],[FromAccountName],[FromAccountBalance],[DestinationAccountID],[TransferAmount]) " +
                        " values('" + obj._fromaccountnumber + "','" + obj._fromaccountname + "','" + obj._fromaccountcurrentbalance + "'," +
                        "'" + obj._destinationAccount + "','" + obj._depositamount + "') ";

                    query = query + " UPDATE [DC_Bank].[dbo].[tbl_CustomerAccounts] SET  " +
                        "AccountBalance = (AccountBalance+"+ obj._depositamount + ") WHERE  AccountID = '"+ obj._destinationAccount + "'";

                    query = query + " UPDATE [DC_Bank].[dbo].[tbl_CustomerAccounts] SET  AccountBalance = (AccountBalance-"+ obj._depositamount + ") WHERE  AccountID = '"+ obj._fromaccountnumber + "'";


                    SqlCommand cmd = new SqlCommand(query, con);
                    #endregion

                    #region Stored Procedure
                    //SqlCommand cmd = new SqlCommand("sp_InsertTransforAmount", con);
                    //cmd.Parameters.AddWithValue("@FromAccountID", obj._fromaccountnumber);
                    //cmd.Parameters.AddWithValue("@FromAccountName", obj._fromaccountname);
                    //cmd.Parameters.AddWithValue("@FromAccountBalance", obj._fromaccountcurrentbalance);
                    //cmd.Parameters.AddWithValue("@DestinationAccountID", obj._destinationAccount);
                    //cmd.Parameters.AddWithValue("@TransferAmount", obj._depositamount);
                    #endregion

                    int i = cmd.ExecuteNonQuery(); // Throws exception due to foreign key constraint   
                   // objTrans.Commit();
                    if (i >= 1)
                    {
                        rtnval = "New Transfer Money Added Successfully";
                    }
                    else
                    {
                        rtnval = "Transfer Money Not Added";
                    }
                }
                catch (Exception ex)
                {
                    LogWriter.LogWrite(this.GetType().Name + " Exception : " + ex.Message + ", Inner Exception : " + ex.InnerException.Message);
                   // objTrans.Rollback();
                }
                finally
                {
                    con.Close();
                }
            }
            return rtnval;
        }

        public DataSet GetCustomerInfor()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Conn))
            {
                try
                {
                    string query = @"SELECT [Fname]
                                      ,[Lname],[BOD],[Gender],[Email],[PhoneNumber]
                                      ,[AccountID],[AccountBalance],[TransationDatetime]
                                  FROM[DC_Bank].[dbo].[tbl_CustomerAccounts]";
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

        public DataSet GetDepositData()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Conn))
            {
                try
                {
                    string query = @"SELECT TOP 1000 [DepositID],[AccountID]
                                      ,[Name],[CurrentBalance],[Mode],[DepositAmount],[TransationDatetime]
                                       FROM [DC_Bank].[dbo].[tbl_Deposit]";
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

        public DataSet GetTransationData()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Conn))
            {
                try
                {
                    string query = @"SELECT TOP 1000 [TransactionID]
                                  ,[FromAccountID],[FromAccountName],[FromAccountBalance]
                                  ,[DestinationAccountID],[TransferAmount],[TransationDatetime]
                                  FROM [DC_Bank].[dbo].[tbl_TransferMoney]";
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


    }
}
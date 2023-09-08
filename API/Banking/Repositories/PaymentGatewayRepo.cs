namespace RepoLib;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

//Saving and Restoring logic into json file
public class PaymentGatewayRepo:IPaymentGatewayRepo{
    private IConfiguration _configuration;
    private string _conString;
    public PaymentGatewayRepo(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    public int FundTransfer(PaymentGateway info)
    {
        int transactionId=0;
        MySqlConnection con = new MySqlConnection(_conString);
        //Create Command Object
        try{
            con.Open();
            MySqlCommand cmd = new MySqlCommand("fundtransfer", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fromaccountnumber",info.FromAcct);
            cmd.Parameters.AddWithValue("@toaccountnumber",info.ToAcct);
            cmd.Parameters.AddWithValue("@amount",info.Amount);
            cmd.Parameters["@transactionId"].Direction=ParameterDirection.Output;
            int rowsAffected = cmd.ExecuteNonQuery();
            transactionId=(int)cmd.Parameters["@transactionId"].Value;
        }
         catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return transactionId;
    }
}
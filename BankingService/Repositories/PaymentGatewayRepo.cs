namespace RepoLib;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

//Saving and Restoring logic into json file
public class PaymentGatewayRepo:IPaymentGatewayRepo{
    private string conString = @"server=localhost;user=root;database=banking;password=PASSWORD";
    public int FundTransfer(PaymentGateway info )
    {
        int transactionId=0;
        IDbConnection con = new MySqlConnection(conString);
        //Create Command Object
        try{
            con.Open();
            IDbCommand cmd = new MySqlCommand("fundtransfer", con as MySqlConnection);
            cmd.CommandType=CommandType.StoreProcedure;
            cmd.Parameters.AddWithValue("@fromaccountnumber",info.FromAcct);
            cmd.Parameters.AddWithValue("@toaccountnumber",info.ToAcct);
            cmd.Parameters.AddWithValue("@amount",info.Amount);
            cmd.Parameters["@transactionId"].Direction=ParameterDirection.Output;
            int rowsAffected = cmd.ExecuteNonQuery();
            transactionId=cmd.Parameters["@transactionId"].Value;
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
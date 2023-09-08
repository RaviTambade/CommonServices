namespace RepoLib;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

//Saving and Restoring logic into json file
public class LoanRepo : ILoanRepo
{
    private IConfiguration _configuration;
    private string _conString;

    public LoanRepo(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    /*public BankRepository(string connectionstring)
    {
        this.conString = connectionstring;
    }*/
    public List<Loan> GetAll()
    {
        List<Loan> loanlist = new List<Loan>();

        //Create connection object
        IDbConnection con = new MySqlConnection(_conString);

        Console.WriteLine("\n Connection status " + con.State);
        string query = "SELECT * FROM loan";

        //Create Command Object
        IDbCommand cmd = new MySqlCommand(query, con as MySqlConnection);
        Console.WriteLine("\n cmd status " + cmd.GetType());

        // Connected Data Access Mode
        // connected is kept alive till operations complete
        try
        {
            con.Open();
            Console.WriteLine("\n Connection status " + con.State);
            //Create Data reader object
            IDataReader reader = cmd.ExecuteReader();
            //Online data using streaming mechanism
            while (reader.Read())
            {
                int loanId = int.Parse(reader["loanid"].ToString());
                double amount = double.Parse(reader["amount"].ToString());
               // DateTime loanSanctionDate = reader["loansanctiondate"].ToString();
                int duration=int.Parse(reader["duration"].ToString());
                double intrestRate = double.Parse(reader["intrestrate"].ToString());           

                int acctId = int.Parse(reader["acctId"].ToString());
                loanlist.Add(
                    new Loan()
                    {
                        LoanId = loanId,
                        Amount = amount,
                        //LoanSanctionDate = loanSanctionDate,
                        Duration = duration,
                        IntrestRate = intrestRate
                        
                    }
                );
            }
            reader.Close();
        }
        catch (MySqlException exp)
        {
            string message = exp.Message;
            //report to developer
            //log exception message log file
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        return loanlist;
    }

    
}

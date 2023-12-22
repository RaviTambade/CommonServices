namespace RepoLib;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

//Saving and Restoring logic into json file
public class LoanTypeRepo : ILoanTypeRepo
{
    private IConfiguration _configuration;
    private string _conString;

    public LoanTypeRepo(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public List<LoanType> GetAll()
    {
        List<LoanType> loantypelist = new List<LoanType>();

        //Create connection object
        IDbConnection con = new MySqlConnection(_conString);

        Console.WriteLine("\n Connection status " + con.State);
        string query = "SELECT * FROM loantype";

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
               int LoantypeId = int.Parse(reader["loantypeid"].ToString());
                string loanType=reader["loantype"].ToString(); 
                double IntrestRate = double.Parse(reader["Intrestrate"].ToString());
                loantypelist.Add(
                    new LoanType()
                    {
                        LoanTypeId = LoantypeId,
                        LoanTypeName = loanType,
                        IntrestRate = IntrestRate,

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
        return loantypelist;
    }

 

    public LoanType GetByLoanTypeId(int loantypeid)
    {
        LoanType loantype = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM loantype WHERE loantypeid=" + loantypeid;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int LoantypeId = int.Parse(reader["loantypeid"].ToString());
                string loanType=reader["loantype"].ToString(); 
                double IntrestRate = double.Parse(reader["Intrestrate"].ToString());
                 
                


                loantype = new LoanType
                {
                    LoanTypeId = LoantypeId,
                    LoanTypeName = loanType,
                    IntrestRate = IntrestRate,
                    
                };
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return loantype;
    }    
    
}

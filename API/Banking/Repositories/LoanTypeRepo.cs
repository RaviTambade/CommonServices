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

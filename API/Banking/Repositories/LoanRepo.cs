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
                DateTime loansanctiondate = DateTime.Parse(reader["loansanctiondate"].ToString());
                DateOnly dateOnlyLoanSanctionDate = DateOnly.FromDateTime(loansanctiondate);
                 //DateOnly loanSanctionDate = DateOnly.Parse(reader["loansanctiondate"].ToString());
                int EMIday = int.Parse(reader["emiday"].ToString());
                double EMIamount = double.Parse(reader["emiamount"].ToString());
                int applicationId = int.Parse(reader["applicationid"].ToString());  
                
                loanlist.Add(
                    new Loan()
                    {
                        LoanId = loanId,
                        EMIAmount = EMIamount,
                        LoanSanctionDate = dateOnlyLoanSanctionDate,
                        EMIDay = EMIday,
                        ApplicationId = applicationId

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

    public Loan GetByLoanId(int loanid)
    {
        Loan loan = null;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM loan WHERE loanid=" + loanid;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int loanId = int.Parse(reader["loanid"].ToString());
                
                DateTime loansanctiondate = DateTime.Parse(reader["loansanctiondate"].ToString());
                DateOnly dateOnlyloansanctiondate = DateOnly.FromDateTime(loansanctiondate);

                //DateOnly loanSanctionDate = DateOnly.Parse(reader["loansanctiondate"].ToString());
                int EMIday = int.Parse(reader["emiday"].ToString());
                double EMIamount = double.Parse(reader["emiamount"].ToString());
                int applicationId = int.Parse(reader["applicationid"].ToString()); 
                


                loan = new Loan
                {
                    LoanId = loanId,
                    EMIAmount = EMIamount,
                    LoanSanctionDate = dateOnlyloansanctiondate,
                    EMIDay = EMIday,
                    ApplicationId = applicationId
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
        return loan;
    }

    public bool Insert(Loan loan)
    {
        //Console.WriteLine("LoanSanctionDate"+loan.LoanSanctionDate);
        string loanSanctionDate = loan.LoanSanctionDate.ToString("yyyy-MM-dd");
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query =
                "INSERT INTO loan(loansanctiondate,emiamount, applicationid) VALUES(@Loansanctiondate,@Emiamount,@Applicationid)";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@Loansanctiondate", loanSanctionDate);
           // command.Parameters.AddWithValue("@Emiday", loan.EMIDay);
            command.Parameters.AddWithValue("@Emiamount", loan.EMIAmount);
            command.Parameters.AddWithValue("@Applicationid", loan.ApplicationId);

            con.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("rowsAffected", rowsAffected);
            if (rowsAffected > 0)
            {
                status = true;
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
        return status;
    }

    public bool Delete(int loanId)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM loan WHERE loanid=" + loanId;
            MySqlCommand command = new MySqlCommand(query, con);
            //if(con.State == ConnectionState.Closed)
            con.Open();
            command.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public bool Update(Loan loan)
    {
        string loanSanctionDate = loan.LoanSanctionDate.ToString("yyyy-MM-dd");
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query =
                "Update loan SET loansanctiondate=@loansanctiondate,emiday=@emiday,emiamount =@EMIamount,applicationId=@applicationId WHERE loanid=@loanid";
            System.Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@loanid", loan.LoanId);
            command.Parameters.AddWithValue("@loansanctiondate", loanSanctionDate);
            command.Parameters.AddWithValue("@emiday", loan.EMIDay);            
            command.Parameters.AddWithValue("@EMIamount", loan.EMIAmount);
            command.Parameters.AddWithValue("@applicationId", loan.ApplicationId);
            
            
            con.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("No of rows  affected " + rowsAffected);
            if (rowsAffected > 0)
            {
                status = true;
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
        return status;
    }

}

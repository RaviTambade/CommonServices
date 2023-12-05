namespace RepoLib;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using MySql.Data;
using MySql.Data.MySqlClient;

//Saving and Restoring logic into json file
public class LoanApplicantsRepo : ILoanApplicantRepo
{
    private IConfiguration _configuration;
    private string _conString;

    public LoanApplicantsRepo(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    public bool Insert(LoanApplicants applicant)
    {
        //Console.WriteLine("LoanSanctionDate"+loan.LoanSanctionDate);
       
        Console.WriteLine("ApplayDate In Repo:- " + applicant.ApplyDate);

        // DateTime aDate = DateTime.Parse(reader["applydate"].ToString());
                //DateOnly FormatDate = DateOnly.FromDateTime(aDate);
        DateOnly currentDateOnly = applicant.ApplyDate;

        string dateString = currentDateOnly.ToString("yyyy-MM-dd");

        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query =
            "INSERT INTO loanapplicants(accountid,applydate,panid,loantype,loanamount,loanstatus) VALUES(@Accountid,@Applydate,@Panid,@Loantype,@Amount,@Status)";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@Accountid", applicant.AccountId);
            
            
            command.Parameters.AddWithValue("@Applydate",dateString);
           
            command.Parameters.AddWithValue("@Panid", applicant.PanId);

            command.Parameters.AddWithValue("@Loantype", applicant.LoanType);

             command.Parameters.AddWithValue("@Amount", applicant.Amount);

            command.Parameters.AddWithValue("@Status", applicant.Status);

           

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

    public bool Delete(int laonapplicantId)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM loanapplicants WHERE applicatid=" + laonapplicantId;
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

    public List<LoanApplicants> GetAll()
    {

        List<LoanApplicants> applicantslist = new List<LoanApplicants>();

        //Create connection object
        IDbConnection con = new MySqlConnection(_conString);

        Console.WriteLine("\n Connection status " + con.State);
        string query = "SELECT * FROM loanapplicants";

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
                int applicntID = int.Parse(reader["applicatid"].ToString());
                int acctID = int.Parse(reader["accountid"].ToString());
                
                DateTime aDate = DateTime.Parse(reader["applydate"].ToString());
                DateOnly FormatDate = DateOnly.FromDateTime(aDate);



                //DateTime date = DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture);
               
                string panID = reader["panid"].ToString();
                string loanType = reader["loantype"].ToString();
                double amount = double.Parse(reader["loanamount"].ToString());
                string status = reader["loanstatus"].ToString();
                

                applicantslist.Add(
                    new LoanApplicants()
                    {
                        ApplicantId = applicntID,
                        AccountId = acctID,
                        
                        ApplyDate = FormatDate,
                        
                        PanId = panID,
                        LoanType = loanType,
                        Amount = amount,
                        Status = status
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
        return applicantslist;
    }

    public LoanApplicants GetById(int laonapplicantId)
    {
        LoanApplicants applicant = null;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM loanapplicants WHERE applicatid=" + laonapplicantId;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = int.Parse(reader["applicatid"].ToString());

                int acctid = int.Parse((reader["accountid"]).ToString());

                

                DateTime aDate = DateTime.Parse(reader["applydate"].ToString());
                DateOnly FormatDate = DateOnly.FromDateTime(aDate);

                //DateTime date = DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture);
                
                string panID = reader["panid"].ToString();
                string loanType = reader["loantype"].ToString();
                string status = reader["status"].ToString();
                double amount = double.Parse(reader["amount"].ToString());
                applicant = new LoanApplicants
                {
                    ApplicantId = id,
                    AccountId = acctid,
                    ApplyDate = FormatDate,
                    PanId = panID,
                    LoanType = loanType,
                     Amount = amount,
                    Status = status
                   
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
        return applicant;


    }

    public List<LoanApplicants> LoanApplicantsBetweenGivenDates(Date startDate,Date endDate)
    {
         DateOnly startDateOnly = startDate;
         DateOnly endDateOnly = endDate;
        string startDateString = startDateOnly.ToString("yyyy-MM-dd");
         string endDateString = endDateOnly.ToString("yyyy-MM-dd");


        List<LoanApplicants> applicantslist = new List<LoanApplicants>();

        //Create connection object
        IDbConnection con = new MySqlConnection(_conString);

        Console.WriteLine("\n Connection status " + con.State);
        string query = "SELECT * FROM loanapplicants WHERE applydate >= '@StartDateString' AND applydate <= '@EndDateString' ";

        //Create Command Object
        IDbCommand cmd = new MySqlCommand(query, con as MySqlConnection);
        cmd.Parameters.AddWithValue("@StartDateString", startDateString);
        cmd.Parameters.AddWithValue("@EndDateString",endDateString);

        try
        {
            con.Open();
            Console.WriteLine("\n Connection status " + con.State);
            //Create Data reader object
            IDataReader reader = cmd.ExecuteReader();
            //Online data using streaming mechanism
            while (reader.Read())
            {
                int applicntID = int.Parse(reader["applicatid"].ToString());
                int acctID = int.Parse(reader["accountid"].ToString());
                
                DateTime aDate = DateTime.Parse(reader["applydate"].ToString());
                DateOnly FormatDate = DateOnly.FromDateTime(aDate);



                //DateTime date = DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture);
               
                string panID = reader["panid"].ToString();
                string loanType = reader["loantype"].ToString();
                double amount = double.Parse(reader["loanamount"].ToString());
                string status = reader["loanstatus"].ToString();
                

                applicantslist.Add(
                    new LoanApplicants()
                    {
                        ApplicantId = applicntID,
                        AccountId = acctID,
                        
                        ApplyDate = FormatDate,
                        
                        PanId = panID,
                        LoanType = loanType,
                        Amount = amount,
                        Status = status
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
        return applicantslist;

    }


}
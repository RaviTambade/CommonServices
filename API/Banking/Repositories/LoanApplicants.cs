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
        Console.WriteLine("Amount In Repo:- "+applicant.Amount);
        string applicantBirthDate=applicant.BirthDate.ToString("yyyy-MM-dd");
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query =
<<<<<<< HEAD
            "INSERT INTO loanapplicants(accountid,firstname,middlename,lastname,birthdate,gender,contactnumber,email,address,adharid,panid,loantype,status,amount) VALUES(@Accountid,@Firstname,@Middlename,@Lastname,@Birthdate,@Gender,@Contactnumber,@Email,@Address,@Adharid,@Panid,@Loantype,@Status,@Amount)";
=======
                "INSERT INTO loanapplicants(accountid,firstname,middlename,lastname,birthdate,gender,contactnumber,email,address,aadharid,panid,loantype) VALUES(@Accountid,@Firstname,@Middlename,@Lastname,@Birthdate,@Gender,@Contactnumber,@Email,@Address,@Aadharid,@Panid,@Loantype)";
>>>>>>> 93a4fa34feb3b14e0953e49a9b3a34dc40cb29b6
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@Accountid", applicant.AccountId);
            command.Parameters.AddWithValue("@Firstname", applicant.FirstName);
            command.Parameters.AddWithValue("@Middlename", applicant.MiddleName);
            command.Parameters.AddWithValue("@Lastname", applicant.LastName);
            command.Parameters.AddWithValue("@Birthdate", applicantBirthDate);
            command.Parameters.AddWithValue("@Gender", applicant.Gender);
            command.Parameters.AddWithValue("@Contactnumber", applicant.ContactNumber);
            command.Parameters.AddWithValue("@Email", applicant.Email);
            command.Parameters.AddWithValue("@Address", applicant.Address);
            command.Parameters.AddWithValue("@Aadharid", applicant.AadharId);
            command.Parameters.AddWithValue("@Panid", applicant.PanId);
            command.Parameters.AddWithValue("@Loantype", applicant.LoanType);
             command.Parameters.AddWithValue("@Status", applicant.Status);
            
             command.Parameters.AddWithValue("@Amount", applicant.Amount);
            
            
            
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
                string fName = reader["firstname"].ToString();
                string mName = reader["middlename"].ToString();
                string lName = reader["lastname"].ToString();
                DateTime bDate = DateTime.Parse(reader["birthdate"].ToString());
                 DateOnly FormatDate = DateOnly.FromDateTime(bDate);
                
               

                //DateTime date = DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture);
                string gender = reader["gender"].ToString();
                string contact = reader["contactnumber"].ToString();
                string email = reader["email"].ToString();
                string address = reader["address"].ToString();
                string aadharID = reader["adharid"].ToString();
                string panID = reader["panid"].ToString();
                string loanType = reader["loantype"].ToString();
                string status = reader["status"].ToString();
                double amount = double.Parse(reader["amount"].ToString());
        
                applicantslist.Add(
                    new LoanApplicants()
                    {
                        ApplicantId = applicntID,
                        AccountId = acctID,
                        FirstName = fName,
                        MiddleName = mName,
                        LastName = lName,
                        BirthDate=FormatDate,
                        Gender=gender,
                        ContactNumber = contact,
                        Email = email,
                        Address=address,
                        AadharId = aadharID,
                        PanId = panID,
                        LoanType = loanType,
                        Status = status,
                        Amount = amount
                        
                        
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
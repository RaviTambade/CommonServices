namespace RepoLib;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Data;
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
        Console.WriteLine("ADHAR ID :- "+applicant.AadharId);
        string applicantBirthDate=applicant.BirthDate.ToString("yyyy-MM-dd");
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query =
                "INSERT INTO loanapplicants(accountid,firstname,middlename,lastname,birthdate,gender,contactnumber,email,address,aadharid,panid,loantype) VALUES(@Accountid,@Firstname,@Middlename,@Lastname,@Birthdate,@Gender,@Contactnumber,@Email,@Address,@Aadharid,@Panid,@Loantype)";
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
}
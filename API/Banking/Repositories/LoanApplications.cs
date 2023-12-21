namespace RepoLib;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using MySql.Data;
using MySql.Data.MySqlClient;

//Saving and Restoring logic into json file
public class LoanApplicationsRepo : ILoanApplicationsRepo
{
    private IConfiguration _configuration;
    private string _conString;

    public LoanApplicationsRepo(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    public List<LoanApplications> GetAll()
    {

        List<LoanApplications> applicationslist = new List<LoanApplications>();

        //Create connection object
        IDbConnection con = new MySqlConnection(_conString);

        //Console.WriteLine("\n Connection status " + con.State);
        string query = "SELECT * FROM loanapplications";

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
                int applicationID = int.Parse(reader["applicationid"].ToString());
                DateTime applicationDate = DateTime.Parse(reader["appldate"].ToString());
                DateOnly formatapplicationDate = DateOnly.FromDateTime(applicationDate);
                double loanamount = double.Parse(reader["loanamount"].ToString());
                int LoanDuration =int.Parse (reader["loanduration"].ToString());
                string loanStatus = reader["loanstatus"].ToString();          
                int accountId = int.Parse(reader["accountid"].ToString()); 
                int loantypeId = int.Parse(reader["loantypeid"].ToString());             

                applicationslist.Add(
                    new LoanApplications()
                    {
                        ApplicationId = applicationID,                      
                        ApplicationDate = formatapplicationDate,  
                        LoanAmount = loanamount,                      
                        LoanDuration = LoanDuration,
                        LoanStatus = loanStatus,
                        AccountId = accountId,
                        LoanTypeId=loantypeId
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
        return applicationslist;
    }
    public bool Insert(LoanApplications application)
    {
        //Console.WriteLine("LoanSanctionDate"+loan.LoanSanctionDate);
       
        Console.WriteLine("ApplayDate In Repo:- " + application.ApplicationDate);

        // DateTime aDate = DateTime.Parse(reader["applydate"].ToString());
                //DateOnly FormatDate = DateOnly.FromDateTime(aDate);
        DateOnly currentDateOnly = application.ApplicationDate;

        string dateString = currentDateOnly.ToString("yyyy-MM-dd");

        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query =
            "INSERT INTO loanapplications(applicationdate,loanamount,loanduration,loanstatus,accountid,loantypeid) VALUES(@Applicationdate,@Loanamount,@Loanduration,@Loanstatus,@Accountid,@Loantypeid)";
            MySqlCommand command = new MySqlCommand(query, con);
                       
            command.Parameters.AddWithValue("@Applicationdate",dateString);
           
            command.Parameters.AddWithValue("@Loanamount", application.LoanAmount);

            command.Parameters.AddWithValue("@Loanduration" , application.LoanDuration);

            command.Parameters.AddWithValue("@Loanstatus", application.LoanStatus);

            command.Parameters.AddWithValue("@Accountid", application.AccountId);
            command.Parameters.AddWithValue("@Loantypeid", application.LoanTypeId);

           

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

    public async Task <bool> UpdateStatus(LoanApplications application)
    {
       
        Console.WriteLine("ApplayDate In Repo:- " + application.ApplicationDate);

        // DateTime aDate = DateTime.Parse(reader["applydate"].ToString());
                //DateOnly FormatDate = DateOnly.FromDateTime(aDate);
        DateOnly currentDateOnly = application.ApplicationDate;

        string dateString = currentDateOnly.ToString("yyyy-MM-dd");

        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            await con.OpenAsync();

            string query =
            " UPDATE loanapplications SET loanstatus = @Status WHERE applicationid=@LoanApplicationId";
            MySqlCommand command = new MySqlCommand(query, con);

            command.Parameters.AddWithValue("@LoanApplicationId", application.ApplicationId);
            command.Parameters.AddWithValue("@Status", application.LoanStatus);

         
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
            await con.CloseAsync();;
        }
        return status;
    }

    public bool Delete(int laonapplicationId)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM loanapplications WHERE applicationid=" + laonapplicationId;
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

    


    public async Task<List<LoanaplicationInfo>> GetAllapplicationInfo()
    {
        Console.WriteLine("Inside LoanaplicantsInfo method in Repo....");
        List<LoanaplicationInfo> applicationslist = new List<LoanaplicationInfo>();

        //Create connection object
        MySqlConnection con = new MySqlConnection(_conString);//IDBConnection is not allowed here Why???

        string query = "SELECT loanapplications.* ,customers.bankcustomerid,customers.usertype from loanapplications inner join accounts on loanapplications.accountid = accounts.id inner join customers on accounts.customerid = customers.id";

        //Create Command Object
        MySqlCommand cmd = new MySqlCommand(query, con );

        // Connected Data Access Mode
        // connected is kept alive till operations complete
        try
        {
            Console.WriteLine("Inside LoanaplicantsInfo method in Repo Inside Try block....");
            await con.OpenAsync();
            Console.WriteLine("\n Connection status " + con.State);
            //Create Data reader object
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            //Online data using streaming mechanism
            while (await reader.ReadAsync())
            {
                Console.WriteLine("Inside LoanaplicantsInfo Reader loop....");
                int applicationID = int.Parse(reader["applicationid"].ToString());              
                
                DateTime aDate = DateTime.Parse(reader["applicationdate"].ToString());
                DateOnly FormatDate = DateOnly.FromDateTime(aDate);
                //DateTime date = DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture);
                double loanamount = double.Parse(reader["loanamount"].ToString());
                int loanduration = int.Parse (reader["loanduration"].ToString());
                string loanstatus = reader["loanstatus"].ToString();
                int accountID = int.Parse(reader["accountid"].ToString());
                int loantypeid = int.Parse(reader["loantypeid"].ToString());               
                                
                int custid = int.Parse(reader["bankcustomerid"].ToString());
                string custtype = reader["usertype"].ToString();
                
                applicationslist.Add(
                    new LoanaplicationInfo()
                    {
                        ApplicationId = applicationID,
                        ApplicationDate = FormatDate,
                        LoanAmount = loanamount,
                        LoanDuration=loanduration,
                        LoanStatus = loanstatus,
                        AccountId = accountID,
                        LoanTypeId=loantypeid,
                        
                        CustomerUserId= custid,
                        ApplicantType = custtype
                    }
                );
            }
            await reader.CloseAsync();
        }
        catch (MySqlException exp)
        {
            string message = exp.Message;
            Console.WriteLine(message);
            //report to developer
            //log exception message log file
        }
        finally
        {
            // if (con.State == ConnectionState.Open)
            // {
                await con.CloseAsync();
           // }
        }
        return applicationslist;
    }

    public async Task <LoanaplicationInfo> GetById(int loanapplicationId)
    {
        LoanaplicationInfo application = null;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            //string query = "SELECT * FROM loanapplicants WHERE applicatid=" + laonapplicantId;


            string query = " SELECT loanapplications.* ,customers.bankcustomerid,customers.usertype from loanapplications inner join accounts on loanapplications.accountid = accounts.id inner join customers on accounts.customerid = customers.id WHERE applicationid=" + loanapplicationId;
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                int id = int.Parse(reader["applicationid"].ToString());

                
                

                DateTime aDate = DateTime.Parse(reader["applicationdate"].ToString());
                DateOnly FormatDate = DateOnly.FromDateTime(aDate);
                //DateTime date = DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture);
                double amount = double.Parse(reader["loanamount"].ToString());                
                int loanduration =int.Parse( reader["loanduration"].ToString());
                string status = reader["loanstatus"].ToString();                
                int acctid = int.Parse((reader["accountid"]).ToString());
                int loantypeId = int.Parse((reader["loantypeid"]).ToString());
                int custid = int.Parse(reader["bankcustomerid"].ToString());
                string custtype = reader["usertype"].ToString();


                application = new LoanaplicationInfo
                {
                    ApplicationId = id,                    
                    ApplicationDate = FormatDate,
                    LoanAmount = amount,
                    LoanDuration=loanduration,
                    LoanStatus = status,                                      
                    AccountId = acctid,
                    LoanTypeId=loantypeId,
                    CustomerUserId= custid,
                    ApplicantType = custtype
                   
                };
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();

        }
        return application;

    }

    public List<LoanApplications> LoanApplicationBetweenGivenDates(DateTime startDate,DateTime endDate)
    {

        Console.WriteLine("Inside LoanApplicantsBetweenGivenDates method in Repo......");
        DateOnly startDateOnly = DateOnly.FromDateTime(startDate);
        DateOnly endDateOnly = DateOnly.FromDateTime(endDate);

        string startDateString = startDateOnly.ToString("yyyy-MM-dd");
        string endDateString = endDateOnly.ToString("yyyy-MM-dd");

        Console.WriteLine("startDateString : " + startDateString);
        Console.WriteLine("endDateString : " + endDateString);

        List<LoanApplications> applicationslist = new List<LoanApplications>();

        //Create connection object
        IDbConnection con = new MySqlConnection(_conString);

        Console.WriteLine("\n Connection status " + con.State);
        string query = "SELECT * FROM loanapplications WHERE applicationdate >= @StartDateString AND applicationdate <= @EndDateString ";
        
        //Create Command Object

        MySqlCommand cmd = new MySqlCommand(query, con as MySqlConnection);
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
                int applicationID = int.Parse(reader["applicationid"].ToString());
                
                
                DateTime aDate = DateTime.Parse(reader["applicationdate"].ToString());
                DateOnly FormatDate = DateOnly.FromDateTime(aDate);
                //DateTime date = DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture);
                double loanamount = double.Parse(reader["loanamount"].ToString());
                int loanduration = int.Parse(reader["loanduration"].ToString());
                string status = reader["loanstatus"].ToString();
                int acctID = int.Parse(reader["accountid"].ToString());
                int loantypeId = int.Parse(reader["loantypeid"].ToString());                
                Console.WriteLine(applicationID);

                applicationslist.Add(
                    new LoanApplications()
                    {
                        ApplicationId = applicationID,                       
                        ApplicationDate = FormatDate,
                        LoanAmount = loanamount,
                        LoanDuration=loanduration,
                        LoanStatus = status,
                        AccountId = acctID,
                        LoanTypeId=loantypeId                      
                         
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
        return applicationslist;

    }

    
    /*public async Task <List<LoanaplicationInfo>> LoanApplicationsAccordingLoanStatus(string LoanType)
    {
        //SELECT * FROM loanapplicants 
        //WHERE loanstatus = @Loanstatus;

        
        Console.WriteLine("Inside LoanApplicantsAccordingLoanStatus Repo method....");
        List<LoanaplicantsInfo> applicantslist = new List<LoanaplicantsInfo>();

        //Create connection object
        MySqlConnection con = new MySqlConnection(_conString);

        Console.WriteLine("\n Connection status " + con.State);

        string query = "SELECT loanapplicants.* ,customers.bankcustomerid,customers.usertype from loanapplicants inner join accounts on loanapplicants.accountid = accounts.id inner join customers on accounts.customerid = customers.id WHERE loanstatus =  @Loanstatus";
        //string query = "SELECT * FROM loanapplicants WHERE loanstatus = @Loanstatus";

        //Create Command Object

        MySqlCommand cmd = new MySqlCommand(query, con as MySqlConnection);
        cmd.Parameters.AddWithValue("@Loanstatus", LoanType);
    
        try
        {
            await con.OpenAsync();
           
            //Create Data reader object
             MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();

            //MysqlDataReader reader = cmd.ExecuteReader();
            //Online data using streaming mechanism
            while (await reader.ReadAsync())
            {
                int applicntID = int.Parse(reader["applicatid"].ToString());
                int acctID = int.Parse(reader["accountid"].ToString());
                
                DateTime aDate = DateTime.Parse(reader["applydate"].ToString());
                DateOnly FormatDate = DateOnly.FromDateTime(aDate);
    
                string panID = reader["panid"].ToString();
                string loanType = reader["loantype"].ToString();
                double amount = double.Parse(reader["loanamount"].ToString());
                string status = reader["loanstatus"].ToString();
                int custid = int.Parse(reader["bankcustomerid"].ToString());
                string custtype = reader["usertype"].ToString();

                
                Console.WriteLine(applicntID);

                applicantslist.Add(
                    new LoanaplicantsInfo()
                    {
                        ApplicantId = applicntID,
                        AccountId = acctID,
                        
                        ApplyDate = FormatDate,
                        
                        PanId = panID,
                        LoanType = loanType,
                        Amount = amount,
                        Status = status,
                        CustomerUserId= custid,
                        ApplicantType = custtype                    }
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
    }*/

}
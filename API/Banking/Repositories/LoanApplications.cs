namespace RepoLib;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.ComponentModel;

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
                int applicationID = int.Parse(reader["id"].ToString());
                DateTime applicationDate = DateTime.Parse(reader["applicationdate"].ToString());
                DateOnly formatapplicationDate = DateOnly.FromDateTime(applicationDate);
                double loanamount = double.Parse(reader["amount"].ToString());
                int LoanDuration =int.Parse (reader["duration"].ToString());
                string loanStatus = reader["status"].ToString();          
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

        Console.WriteLine(application.LoanTypeId);
        try
        {

            Console.WriteLine("Inside try block....Inside Repo");
            string query =
            "INSERT INTO loanapplications(applicationdate,amount,duration,status,accountid,loantypeid) VALUES(@Applicationdate,@Loanamount,@Loanduration,@Loanstatus,@Accountid,@Loantypeid)";
            MySqlCommand command = new MySqlCommand(query, con);
                       
            command.Parameters.AddWithValue("@Applicationdate",dateString);
           
            command.Parameters.AddWithValue("@amount", application.LoanAmount);

            command.Parameters.AddWithValue("@duration" , application.LoanDuration);

            command.Parameters.AddWithValue("@status", application.LoanStatus);

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
        Console.WriteLine("LoanStatus In Repo:- " + application.LoanStatus);

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
            " UPDATE loanapplications SET status = @Status WHERE id=@LoanApplicationId";
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
            string query = "DELETE FROM loanapplications WHERE id=" + laonapplicationId;
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

    public async Task<List<LoanResponse>> GetAllapplicantsInfo()
    {
        Console.WriteLine("Inside LoanaplicantsInfo method in Repo....");
        List<LoanResponse> applicationslist = new List<LoanResponse>();

        //Create connection object
        MySqlConnection con = new MySqlConnection(_conString);//IDBConnection is not allowed here Why???

        string query = "SELECT loanapplications.* ,customers.customerid,customers.customertype,loantypes.loantype from loanapplications inner join accounts on loanapplications.accountid = accounts.id inner join customers on accounts.customerid = customers.id "+
        "inner join loantypes on loanapplications.loantypeid=loantypes.id ";

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
                int applicationID = int.Parse(reader["id"].ToString());              
                
                DateTime aDate = DateTime.Parse(reader["applicationdate"].ToString());
                DateOnly FormatDate = DateOnly.FromDateTime(aDate);
                //DateTime date = DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture);
                double loanamount = double.Parse(reader["amount"].ToString());
                int loanduration = int.Parse (reader["duration"].ToString());
                string loanstatus = reader["status"].ToString();
                int accountID = int.Parse(reader["accountid"].ToString());
                int loantypeid = int.Parse(reader["id"].ToString()); 
                string loantypename = reader["loantype"].ToString();                
                                
                int custid = int.Parse(reader["customerid"].ToString());
                string custtype = reader["customertype"].ToString();
                
                //LoanApplications loanApplication = new LoanApplications();
                applicationslist.Add(
                    new LoanResponse()
                    {
                        TheApplication =  new LoanApplications(){
                        
                        ApplicationId = applicationID,
                        ApplicationDate = FormatDate,
                        LoanAmount = loanamount,
                        LoanDuration=loanduration,
                        LoanStatus = loanstatus,
                        AccountId = accountID,
                        LoanTypeId=loantypeid,
                        },
                    
                        TheApplicant = new LoanapplicationInfo(){

                            LoanTypeName = loantypename,
                            CustomerUserId= custid,
                            ApplicantType = custtype
                        }
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

    public async Task <LoanResponse> GetById(int loanapplicationId)
    {
        LoanResponse application = null;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            //string query = "SELECT * FROM loanapplicants WHERE applicatid=" + laonapplicantId;


            string query = " SELECT loanapplications.* ,customers.customerid,customers.customertype,loantypes.loantype from loanapplications inner join accounts on loanapplications.accountid = accounts.id inner join customers on accounts.customerid = customers.id "+
                             "inner join loantypes on loanapplications.loantypeid=loantypes.id WHERE loanapplications.id=" + loanapplicationId;
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());               
                
               // int applicationID = int.Parese(reader[""].ToString);
                DateTime aDate = DateTime.Parse(reader["applicationdate"].ToString());
                DateOnly FormatDate = DateOnly.FromDateTime(aDate);
                //DateTime date = DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture);
                double amount = double.Parse(reader["amount"].ToString());                
                int loanduration =int.Parse( reader["duration"].ToString());
                string status = reader["status"].ToString();                
                int acctid = int.Parse((reader["accountid"]).ToString());
                int loantypeId = int.Parse((reader["loantypeid"]).ToString());
                string loantypename = reader["loantype"].ToString();  
                int custid = int.Parse(reader["customerid"].ToString());
                string custtype = reader["customertype"].ToString();


                application = new LoanResponse
                {
                    TheApplication =  new LoanApplications(){
                        
                        ApplicationId = id,
                        ApplicationDate = FormatDate,
                        LoanAmount = amount,
                        LoanDuration=loanduration,
                        LoanStatus = status,
                        AccountId = acctid,
                        LoanTypeId=loantypeId,
                        },
                    
                        TheApplicant = new LoanapplicationInfo(){

                            LoanTypeName = loantypename,
                            CustomerUserId= custid,
                            ApplicantType = custtype
                        }

                   
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

    public async Task<List<LoanResponse>> GetAllLoans(DateTime startDate,DateTime endDate)
    {

        Console.WriteLine("Inside LoanApplicantsBetweenGivenDates method in Repo......");
        DateOnly startDateOnly = DateOnly.FromDateTime(startDate);
        DateOnly endDateOnly = DateOnly.FromDateTime(endDate);

        string startDateString = startDateOnly.ToString("yyyy-MM-dd");
        string endDateString = endDateOnly.ToString("yyyy-MM-dd");

        Console.WriteLine("startDateString : " + startDateString);
        Console.WriteLine("endDateString : " + endDateString);

        List<LoanResponse> applicationslist = new List<LoanResponse>();

        //Create connection object
        MySqlConnection con = new MySqlConnection(_conString);

        Console.WriteLine("\n Connection status " + con.State);
        string query = "SELECT loanapplications.* ,customers.customerid,customers.customertype,loantypes.loantype from loanapplications inner join accounts on loanapplications.accountid = accounts.id inner join customers on accounts.customerid = customers.id "+
                       "inner join loantypes on loanapplications.loantypeid=loantypes.id  WHERE applicationdate >= @StartDateString AND applicationdate <= @EndDateString;";
        
        //Create Command Object

        MySqlCommand cmd = new MySqlCommand(query, con as MySqlConnection);
        cmd.Parameters.AddWithValue("@StartDateString", startDateString);
        cmd.Parameters.AddWithValue("@EndDateString",endDateString);

        try
        {
            await con.OpenAsync();
            Console.WriteLine("\n Connection status " + con.State);
            //Create Data reader object
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            //Online data using streaming mechanism
            while (await reader.ReadAsync())
            {
                int applicationID = int.Parse(reader["id"].ToString());
                
                
                DateTime aDate = DateTime.Parse(reader["applicationdate"].ToString());
                DateOnly FormatDate = DateOnly.FromDateTime(aDate);
                //DateTime date = DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture);
                double loanamount = double.Parse(reader["amount"].ToString());
                int loanduration = int.Parse(reader["duration"].ToString());
                string status = reader["status"].ToString();
                int acctID = int.Parse(reader["accountid"].ToString());
                int loantypeId = int.Parse(reader["id"].ToString()); 
                string loantypename = reader["loantype"].ToString();  
                int custid = int.Parse(reader["customerid"].ToString()); 
                string custtype = reader["customertype"].ToString();
          
                Console.WriteLine("Loantypename in repo :"+loantypename);


                applicationslist.Add(
                    new LoanResponse()
                    {
                        TheApplication =  new LoanApplications(){
                        
                        ApplicationId = applicationID,
                        ApplicationDate = FormatDate,
                        LoanAmount = loanamount,
                        LoanDuration=loanduration,
                        LoanStatus = status,
                        AccountId = acctID,
                        LoanTypeId=loantypeId,
                        },
                    
                        TheApplicant = new LoanapplicationInfo(){

                            LoanTypeName = loantypename,
                            CustomerUserId= custid,
                            ApplicantType = custtype
                        }
                    }
                );
            }
            await reader.CloseAsync();
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
                await con.CloseAsync();
            }
        }
        return applicationslist;

    }

     
    public async Task <List<LoanResponse>> GetAllLoans(string LoanType)
    {
        //SELECT * FROM loanapplicants 
        //WHERE loanstatus = @Loanstatus;

        
        Console.WriteLine("Inside LoanApplicantsAccordingLoanStatus Repo method....");
        List<LoanResponse> applicationslist = new List<LoanResponse>();

        //Create connection object
        MySqlConnection con = new MySqlConnection(_conString);

        Console.WriteLine("\n Connection status " + con.State);

        string query = "SELECT loanapplications.* ,customers.customerid,customers.customertype,loantypes.loantype from loanapplications inner join accounts on loanapplications.accountid = accounts.id inner join customers on accounts.customerid = customers.id "+
        "inner join loantypes on loanapplications.loantypeid=loantypes.id WHERE status =  @Loanstatus";
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
                int applictionID = int.Parse(reader["id"].ToString());
                int acctID = int.Parse(reader["accountid"].ToString());
                
                DateTime aDate = DateTime.Parse(reader["applicationdate"].ToString());
                DateOnly FormatDate = DateOnly.FromDateTime(aDate);
    
                int loanTypeid = int.Parse(reader["id"].ToString());
                string loantypename = reader["loantype"].ToString(); 
                int loanduration = int.Parse(reader["duration"].ToString());
                double amount = double.Parse(reader["amount"].ToString());
                string status = reader["status"].ToString();
                int custid = int.Parse(reader["customerid"].ToString());
                string custtype = reader["customertype"].ToString();

                
                Console.WriteLine(applictionID);

                applicationslist.Add(
                    new LoanResponse()
                    {
                        TheApplication =  new LoanApplications(){
                        
                        ApplicationId = applictionID,
                        ApplicationDate = FormatDate,
                        LoanAmount = amount,
                        LoanDuration=loanduration,
                        LoanStatus = status,
                        AccountId = acctID,
                        LoanTypeId=loanTypeid,
                        },
                    
                        TheApplicant = new LoanapplicationInfo(){

                            LoanTypeName = loantypename,
                            CustomerUserId= custid,
                            ApplicantType = custtype
                        }
                   
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

}
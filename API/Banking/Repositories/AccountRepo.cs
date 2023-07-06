namespace RepoLib;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

//Saving and Restoring logic into json file
public class AccountRepo:IAccountRepo{

    private IConfiguration _configuration;
    private string _conString;
    public AccountRepo(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    /*public BankRepository(string connectionstring)
    {
        this.conString = connectionstring;
    }*/
     public List<Account> GetAll()
      {
          List<Account> acctlist = new List<Account>();

        //Create connection object
        IDbConnection con = new MySqlConnection(_conString);

        Console.WriteLine("\n Connection status "+ con.State);
        string query = "SELECT * FROM accounts";
        
        //Create Command Object
        IDbCommand cmd = new MySqlCommand(query, con as MySqlConnection);
        Console.WriteLine("\n cmd status "+ cmd.GetType());

            // Connected Data Access Mode
            // connected is kept alive till operations complete
            try
            {
                con.Open();
                  Console.WriteLine("\n Connection status "+ con.State);
                //Create Data reader object
                IDataReader reader = cmd.ExecuteReader();
                //Online data using streaming mechanism
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());

                    string acctNumber = reader["acctnumber"].ToString();
                    
                    string acctType = reader["accttype"].ToString();
                     
                    string ifscCode = reader["ifsccode"].ToString();
                     
                    double Balance = double.Parse(reader["balance"].ToString());
                    
                   //DateTime date = reader["registereddate"].ToString();
                    int custId = int.Parse(reader["customerid"].ToString());
                    acctlist.Add(new Account()
                    {
                        Id = id,
                        AcctNumber = acctNumber,
                        AcctType = acctType,
                        IFSCCode = ifscCode,
                        Balance = Balance,
                        CustomerId = custId
                    });
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
            return acctlist;
      }   
    public Account GetByAccountNumber(string acctNumber)
    {
        Account acct = null;
         
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM accounts WHERE acctnumber=" + acctNumber;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());

                string acctNum = reader["acctnumber"].ToString();
                    
                string acctType = reader["accttype"].ToString();
                     
                string ifscCode = reader["ifsccode"].ToString();
                     
                double Balance = double.Parse(reader["balance"].ToString());
                    
                   //DateTime date = reader["registereddate"].ToString();
                int custId = int.Parse(reader["peopleid"].ToString());
                acct = new Account
                {
                        Id = id,
                        AcctNumber = acctNum,
                        AcctType = acctType,
                        IFSCCode = ifscCode,
                        Balance = Balance,
                        CustomerId = custId
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
        return acct;
    }

    public Account GetById(int Id)
    {
        Account acct = null;
         
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM accounts WHERE id=" + Id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());

                string acctNum = reader["acctnumber"].ToString();
                    
                string acctType = reader["accttype"].ToString();
                     
                string ifscCode = reader["ifsccode"].ToString();
                     
                double Balance = double.Parse(reader["balance"].ToString());
                    
                   //DateTime date = reader["registereddate"].ToString();
                int custId = int.Parse(reader["customerid"].ToString());
                acct = new Account
                {
                        Id = id,
                        AcctNumber = acctNum,
                        AcctType = acctType,
                        IFSCCode = ifscCode,
                        Balance = Balance,
                        CustomerId = custId
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
        return acct;
    }
    public bool Delete(string acctNumber)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM accounts WHERE acctnumber=" + acctNumber;
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
    public bool Insert(Account acct)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "INSERT INTO accounts(acctnumber,accttype,ifsccode,peopleid,balance) VALUES(@acctNumber,@acctType,@ifscCode,@peopleId,@balance)";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@acctNumber", acct.AcctNumber);
            command.Parameters.AddWithValue("@acctType", acct.AcctType);
            command.Parameters.AddWithValue("@ifscCode", acct.IFSCCode);
            command.Parameters.AddWithValue("@peopleId", acct.PeopleId);
            command.Parameters.AddWithValue("@balance", acct.Balance);
             
            con.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("rowsAffected",rowsAffected);
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
    public bool Update(Account acct)
    {
         bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "Update accounts SET acctnumber =@acctNumber,accttype=@acctType,ifsccode =@ifscCode,balance=@balance,customerid=@customerid WHERE id=@Id";
            System.Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@customerid", acct.CustomerId);
            command.Parameters.AddWithValue("@acctNumber", acct.AcctNumber);
            command.Parameters.AddWithValue("@acctType", acct.AcctType);
            command.Parameters.AddWithValue("@ifscCode", acct.IFSCCode);
           // command.Parameters.AddWithValue("@registerationDate", acct.RegisterationDate);
            command.Parameters.AddWithValue("@balance", acct.Balance);
            command.Parameters.AddWithValue("@id", acct.Id);
            con.Open();
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("No of rows  affected "+rowsAffected);
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
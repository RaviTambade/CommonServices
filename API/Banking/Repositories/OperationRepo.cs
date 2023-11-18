namespace RepoLib;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

//Saving and Restoring logic into json file
public class OperationRepo : IOperationRepo
{

    private IConfiguration _configuration;
    private string _conString;
    public OperationRepo(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    /*public BankRepository(string connectionstring)
    {
        this.conString = connectionstring;
    }*/
    List<Operation> IOperationRepo.GetAll()
    {
        List<Operation> operationlist = new List<Operation>();

        //Create connection object
        IDbConnection con = new MySqlConnection(_conString);

        Console.WriteLine("\n Connection status " + con.State);
        string query = "SELECT * FROM operations";

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
                int operationId = int.Parse(reader["operationid"].ToString());
                int acctId = int.Parse(reader["acctid"].ToString());
                string acctNumber = reader["acctnumber"].ToString();
                double amount = double.Parse(reader["amount"].ToString());
                DateTime operationdate = Convert.ToDateTime(reader["operationdate"].ToString());
                char operationmode = Convert.ToChar(reader["operationmode"].ToString());

                operationlist.Add(new Operation()
                {
                    OperationId = operationId,
                    AcctId = acctId,
                    AccountNumber = acctNumber,
                    Amount = amount,
                    OperationTime = operationdate,
                    OperationMode = operationmode
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
        return operationlist;
    }
    public List<Operation> GetByAccountNumber(string acctNumber)
    {
        List<Operation> opr = new List<Operation>();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM operations WHERE acctnumber='" + acctNumber + "'";
            Console.WriteLine(query);
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int operationId = int.Parse(reader["operationid"].ToString());
                int acctId = int.Parse(reader["acctid"].ToString());
                string acctNum = reader["acctnumber"].ToString();
                double amount = double.Parse(reader["amount"].ToString());
                DateTime operationdate = Convert.ToDateTime(reader["operationdate"].ToString());
                char operationmode = Convert.ToChar(reader["operationmode"].ToString());

                opr.Add(new Operation
                {
                    OperationId = operationId,
                    AcctId = acctId,
                    AccountNumber = acctNum,
                    Amount = amount,
                    OperationTime = operationdate,
                    OperationMode = operationmode
                });
            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return opr;
    }

    Operation IOperationRepo.GetById(int id)
    {

        Operation opr = null;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM operations WHERE operationid=" + id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int operationId = int.Parse(reader["operationid"].ToString());
                int acctId = int.Parse(reader["acctid"].ToString());
                string acctNum = reader["acctnumber"].ToString();
                double amount = double.Parse(reader["amount"].ToString());
                DateTime operationdate = Convert.ToDateTime(reader["operationdate"].ToString());
                char operationmode = Convert.ToChar(reader["operationmode"].ToString());

                opr = new Operation()
                {
                    OperationId = operationId,
                    AcctId = acctId,
                    AccountNumber = acctNum,
                    Amount = amount,
                    OperationTime = operationdate,
                    OperationMode = operationmode
                };
            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return opr;
    }

    List<Operation> IOperationRepo.GetByMode(string mode)
    {

        List<Operation> oprlist = new List<Operation>();
        Console.WriteLine(mode);
        MySqlConnection con = new MySqlConnection();
        Console.WriteLine(con.State);
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM operations WHERE operationmode= @mode";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@mode", mode);
            Console.WriteLine(command.CommandText);
            con.Open();

            MySqlDataReader reader = command.ExecuteReader();
            //if((reader.Read())!=null)
            // Console.WriteLine(reader);
            while (reader.Read())
            {

                int operationId = int.Parse(reader["operationid"].ToString());
                int acctId = int.Parse(reader["acctid"].ToString());
                string acctNumber = reader["acctnumber"].ToString();
                double amount = double.Parse(reader["amount"].ToString());
                DateTime operationdate = Convert.ToDateTime(reader["operationdate"].ToString());
                char operationmode = Convert.ToChar(reader["operationmode"].ToString());


                oprlist.Add(new Operation()
                {
                    OperationId = operationId,
                    AcctId = acctId,
                    AccountNumber = acctNumber,
                    Amount = amount,
                    OperationTime = operationdate,
                    OperationMode = operationmode
                });


            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return oprlist;
    }
    bool IOperationRepo.Delete(string acctNumber)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM operations WHERE acctnumber=" + acctNumber;
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
    bool IOperationRepo.Insert(Operation opr)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "INSERT INTO operations(operationid,acctid,acctnumber,amount,operationdate,operationmode) VALUES(@OperationId,@AcctID,@acctNumber,@Amount,@Operationdate,@operationMode)";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@operationid", opr.OperationId);
            command.Parameters.AddWithValue("@acctid", opr.AcctId);
            command.Parameters.AddWithValue("@acctnumber", opr.AccountNumber);
            command.Parameters.AddWithValue("@amount", opr.Amount);
            command.Parameters.AddWithValue("@operationdate", opr.OperationTime);
            command.Parameters.AddWithValue("@operationmode", opr.OperationMode);

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
    bool IOperationRepo.Update(Operation opr)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "Update operations SET amount=@amount,operationdate=@operationdate,operationmode=@operationmode WHERE operationid=@OperationId";
            System.Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@amount", opr.Amount);
            command.Parameters.AddWithValue("@operationdate", opr.OperationTime);
            command.Parameters.AddWithValue("@operationmode", opr.OperationMode);

            command.Parameters.AddWithValue("@operationId", opr.OperationId);
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

    public List<Statement> GetStatement(string acctNumber)
    {
        List<Statement> statements = new();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = @"SELECT o.amount, o.operationdate, o.operationmode,
                            ( SELECT SUM(CASE
                                        WHEN o2.operationmode = 'D' THEN o2.amount
                                        WHEN o2.operationmode = 'W' THEN -o2.amount
                                        ELSE 0 END )FROM operations o2
                                WHERE o2.acctId = o.acctId AND (o2.operationid <= o.operationid))AS balance
                        FROM operations o
                        JOIN accounts a ON o.acctId = a.id
                        WHERE a.acctnumber = @acctnumber
                        ORDER BY o.operationdate, o.operationid";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@acctnumber", acctNumber);
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                statements.Add(new Statement()
                {
                    Amount = reader.GetDouble("amount"),
                    Date = reader.GetDateTime("operationdate"),
                    Mode = reader.GetString("operationmode"),
                    Balance = reader.GetDouble("balance")
                });
            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return statements;
    }
}


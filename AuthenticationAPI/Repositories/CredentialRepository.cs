using AuthenticationAPI.Models;
using AuthenticationAPI.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace AuthenticationAPI.Repositories;

public class CredentialRepository : ICredentialRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _conString;

    public CredentialRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

public bool Validate(Credential credential)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                "SELECT EXISTS(SELECT * FROM credentials WHERE contactnumber=@contactNumber AND password=@password)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@contactNumber", credential.ContactNumber);
            cmd.Parameters.AddWithValue("@password", credential.Password);
            con.Open();
            long result = (long)cmd.ExecuteScalar();
            if (result == 1)
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
  
    public bool Register(Credential credential)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                "INSERT INTO credentials(contactnumber,password)VALUES(@contactNumber,@password)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@contactNumber", credential.ContactNumber);
            cmd.Parameters.AddWithValue("@password", credential.Password);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
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

    public bool UpdateContactNumber(ChangeContactNumber credential)
    {
       bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                "UPDATE credentials SET contactnumber=@newContactNumber  WHERE password=@password AND contactnumber=@oldContactNumber";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@oldContactNumber", credential.OldContactNumber);
            cmd.Parameters.AddWithValue("@newContactNumber", credential.NewContactNumber);
            cmd.Parameters.AddWithValue("@password", credential.Password);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
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

    public bool UpdatePassword(ChangePassword credential)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                "UPDATE credentials SET password=@newPassword  WHERE password=@oldpassword AND contactnumber=@contactNumber";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@contactNumber", credential.ContactNumber);
            cmd.Parameters.AddWithValue("@oldPassword", credential.OldPassword);
            cmd.Parameters.AddWithValue("@newPassword", credential.NewPassword);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
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

      public bool Delete(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query = "DELETE FROM credentials WHERE id=@credentialId";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@credentialId", id);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
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
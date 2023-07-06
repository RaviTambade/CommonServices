using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AuthenticationAPI.Models;
using AuthenticationAPI.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;

namespace AuthenticationAPI.Repositories;

public class CredentialRepository : ICredentialRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _conString;

    public  CredentialRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

       public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var credential =await GetCredentials(request);
        
        if (credential == null)
        {
            return null;
        }

        var token = await generateJwtToken(credential);
        return  new AuthenticateResponse(token);
    }

   


    public async Task<bool> Register(Credential credential)
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
           await con.OpenAsync();
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
           await con.CloseAsync();
        }
        return status;
    }

    public async Task<bool> UpdateContactNumber(ChangeContactNumber credential)
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
           await con.OpenAsync();
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
           await con.CloseAsync();
        }
        return status;
    }

    public async Task<bool> UpdatePassword(ChangePassword credential)
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
           await con.OpenAsync();
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
           await con.CloseAsync();
        }
        return status;
    }

    public async Task<bool> Delete(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query = "DELETE FROM credentials WHERE id=@credentialId";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@credentialId", id);
           await con.OpenAsync();
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
           await con.CloseAsync();
        }
        return status;
    }

 
    private  async Task<string> generateJwtToken(Credential credential)
    {
        //token will expire after one hour 
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = System.Text.Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Secret"));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(await AllClaims(credential)),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
       SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    private async Task<List<Claim>> AllClaims(Credential credential)
      {
        List<Claim> claims = new List<Claim>
        {
            new Claim("contactNumber", credential.ContactNumber)
        };

        return claims;
    }

    private async Task<Credential?> GetCredentials(AuthenticateRequest request)
    {
         Credential credential = null;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                "SELECT * FROM credentials WHERE contactnumber=@contactNumber AND password=@password";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@contactNumber", request.ContactNumber);
            cmd.Parameters.AddWithValue("@password", request.Password);
           await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            if ( await reader.ReadAsync())
            {
                string contactNumber = reader["contactnumber"].ToString();
                string password = reader["password"].ToString();

                 credential = new Credential()
                {
                    ContactNumber = contactNumber,
                    Password = password
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
        return credential;
    }
}

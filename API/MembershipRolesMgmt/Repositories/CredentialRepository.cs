using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using Transflower.MembershipRolesMgmt.Helpers;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Claim = Transflower.MembershipRolesMgmt.Models.Requests.Claim;

namespace Transflower.MembershipRolesMgmt.Repositories;

public class CredentialRepository : ICredentialRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _conString;
   

    public CredentialRepository(IConfiguration configuration, IOptions<JwtSettings> jwtSettings)
    {
        _configuration = configuration;
        _conString =
            this._configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentException(nameof(_conString));
    }

    public async Task<bool> Authenticate(Claim claim)
    {
        bool status=false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                "SELECT * FROM credentials WHERE contactnumber=@contactNumber AND BINARY password=@password";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@contactNumber", claim.ContactNumber);
            cmd.Parameters.AddWithValue("@password", claim.Password);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {   

                status=true;


               /*UserRepository repo=new UserRepository(_configuration);

                User user=await repo.GetUserByContact(claim.ContactNumber);
                TokenHelper tokenHelper=new TokenHelper();
                jwtToken = await tokenHelper.GenerateJwtToken(user);
               */ 
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
        return status;
    }



    public async Task<bool> Insert(Credential credential)
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
            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return status;
    }

    //Update contactNumber
    public async Task<bool> Update(string oldContactNumber, ContactNumberDetails details)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                "UPDATE credentials SET contactnumber=@newContactNumber  WHERE password=@password AND contactnumber=@oldContactNumber";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@oldContactNumber", oldContactNumber);
            cmd.Parameters.AddWithValue("@newContactNumber", details.NewContactNumber);
            cmd.Parameters.AddWithValue("@password", details.Password);

            await con.OpenAsync();
            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return status;
    }

    //Update Password
    public async Task<bool> Update(string contactNumber, PasswordDetails details)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                "UPDATE credentials SET password=@newPassword  WHERE password=@oldpassword AND contactnumber=@contactNumber";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@contactNumber", contactNumber);
            cmd.Parameters.AddWithValue("@oldPassword", details.OldPassword);
            cmd.Parameters.AddWithValue("@newPassword", details.NewPassword);
            await con.OpenAsync();
            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
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
            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return status;
    }

   
   


    
}

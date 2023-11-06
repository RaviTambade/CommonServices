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
    private readonly JwtSettings _jwtSettings;

    public CredentialRepository(IConfiguration configuration, IOptions<JwtSettings> jwtSettings)
    {
        _configuration = configuration;
        _jwtSettings = jwtSettings.Value;
        _conString =
            this._configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentException(nameof(_conString));
    }

    public async Task<AuthToken> Authenticate(Claim claim)
    {
        var credential = await GetCredentials(claim);

        if (credential is null)
        {
            return new AuthToken("");
        }

        var jwtToken = await generateJwtToken(credential);
        return new AuthToken(jwtToken);
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

    private async Task<string> GenerateJwtToken(Credential credential)
    {
        //token will expire after one hour
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = System.Text.Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(await AllClaims(credential)),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private async Task<List<System.Security.Claims.Claim>> AllClaims(Credential credential)
    {
        var rolesTask = GetRolesOfUser(credential.ContactNumber);
        var userIdTask = GetUserIdByContactNumber(credential.ContactNumber);

        await Task.WhenAll(rolesTask, userIdTask);

        List<string> roles = await rolesTask;
        int userId = await userIdTask;

        List<System.Security.Claims.Claim> claims = new List<System.Security.Claims.Claim>
        {
            new System.Security.Claims.Claim("contactNumber", credential.ContactNumber),
            new System.Security.Claims.Claim("userId", userId.ToString()),
        };

        foreach (var role in roles)
        {
            claims.Add(new System.Security.Claims.Claim("roles", role));
        }

        return claims;
    }

    private async Task<Credential?> GetCredentials(Claim claim)
    {
        Credential? credential = null;
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
                credential = new Credential()
                {
                    ContactNumber = reader.GetString("contactnumber"),
                    Password = reader.GetString("password"),
                };
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
        return credential;
    }

    private async Task<List<string>> GetRolesOfUser(string contactNumber)
    {
        List<string> roles = new();
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                @"SELECT roles.name,roles.lob FROM roles INNER JOIN userroles on userroles.roleid = roles.id
                  INNER JOIN  users ON users.id=userroles.userid
                 WHERE users.contactnumber=@contactNumber"; //and  lob='Ekrushi
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@contactNumber", contactNumber);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                roles.Add(reader.GetString("name"));
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
        return roles;
    }

    private async Task<int> GetUserIdByContactNumber(string contactNumber)
    {
        int userId = 0;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select id from users where contactnumber=@contactNumber";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@contactNumber", contactNumber);
            await con.OpenAsync();
            userId = Convert.ToInt32(await command.ExecuteScalarAsync());
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return userId;
    }
}

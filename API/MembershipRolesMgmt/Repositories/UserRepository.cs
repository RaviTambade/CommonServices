
using MySql.Data.MySqlClient;
using System.Globalization;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Claim = Transflower.MembershipRolesMgmt.Models.Requests.Claim;
namespace Transflower.MembershipRolesMgmt.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IConfiguration _configuration;

    private readonly string _conString;

    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection") ??
        throw new ArgumentNullException(nameof(_conString));
    }


    public async Task<bool> Authenticate(Claim claim)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                "SELECT * FROM users WHERE contactnumber=@contactNumber AND BINARY password=@password";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@contactNumber", claim.ContactNumber);
            cmd.Parameters.AddWithValue("@password", claim.Password);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {

                status = true;


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
    public async Task<List<User>> GetAllUsers()
    {
        List<User> users = new List<User>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select * from users";
            MySqlCommand cmd = new MySqlCommand(query, con);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string? imageUrl = reader["imageurl"].ToString();
                string? aadharId = reader["aadharid"].ToString();
                string? firstName = reader["firstname"].ToString();
                string? lastName = reader["lastname"].ToString();
                DateTime birthDate = DateTime.Parse(reader["birthdate"].ToString());
                DateOnly dateOnlyBirthDate = DateOnly.FromDateTime(birthDate);
                string? gender = reader["gender"].ToString();
                string? email = reader["email"].ToString();
                string? contactNumber = reader["contactnumber"].ToString();
                string? password = reader["password"].ToString();
                DateTime createdOn = DateTime.Parse(reader["createdon"].ToString());
                DateTime modifiedOn = DateTime.Parse(reader["modifiedon"].ToString());

                User user = new User()
                {
                    Id = id,
                    ImageUrl = imageUrl,
                    AadharId = aadharId,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = dateOnlyBirthDate,
                    Gender = gender,
                    Email = email,
                    ContactNumber = contactNumber,
                    Password = password,
                    CreatedOn = createdOn,
                    ModifiedOn = modifiedOn
                };
                users.Add(user);
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return users;
    }
    public async Task<User> GetUser(int userId)
    {
        User user = new User();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select * from users where id=@userId";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userId", userId);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string? imageUrl = reader["imageurl"].ToString();
                string? aadharId = reader["aadharid"].ToString();
                string? firstName = reader["firstname"].ToString();
                string? lastName = reader["lastname"].ToString();
                DateTime birthDate = DateTime.Parse(reader["birthdate"].ToString());
                DateOnly dateOnlyBirthDate = DateOnly.FromDateTime(birthDate);
                string? gender = reader["gender"].ToString();
                string? email = reader["email"].ToString();
                string? contactNumber = reader["contactnumber"].ToString();
                

                user = new User()
                {
                    Id = id,
                    ImageUrl = imageUrl,
                    AadharId = aadharId,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = dateOnlyBirthDate,
                    Gender = gender,
                    Email = email,
                    ContactNumber = contactNumber,
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
            await con.CloseAsync();
        }
        return user;
    }



    public async Task<List<User>> GetUsers(string roleName)
    {
        List<User> users = new();
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query = "select * from users inner join userroles on users.id=userroles.userid inner join roles on roles.id=userroles.roleid where roles.name=@roleName";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@roleName", roleName);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string? imageUrl = reader["imageurl"].ToString();
                string? aadharId = reader["aadharid"].ToString();
                string? firstName = reader["firstname"].ToString();
                string? lastName = reader["lastname"].ToString();
                DateTime birthDate = DateTime.Parse(reader["birthdate"].ToString());
                DateOnly dateOnlyBirthDate = DateOnly.FromDateTime(birthDate);
                string? gender = reader["gender"].ToString();
                string? email = reader["email"].ToString();
                string? contactNumber = reader["contactnumber"].ToString();
               

                User user = new User()
                {
                    Id = id,
                    ImageUrl = imageUrl,
                    AadharId = aadharId,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = dateOnlyBirthDate,
                    Gender = gender,
                    Email = email,
                    ContactNumber = contactNumber,
                };
                users.Add(user);
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
        return users;
    }

    public async Task<User> GetUserByContact(string contactNumber)
    {
        User user = new User();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select * from users where contactnumber=@contactNumber";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@contactNumber", contactNumber);
            await con.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string? imageUrl = reader["imageurl"].ToString();
                string? aadharId = reader["aadharid"].ToString();
                string? firstName = reader["firstname"].ToString();
                string? lastName = reader["lastname"].ToString();
                DateTime birthDate = DateTime.Parse(reader["birthdate"].ToString());
                DateOnly dateOnlyBirthDate = DateOnly.FromDateTime(birthDate);
                string? gender = reader["gender"].ToString();
                string? email = reader["email"].ToString();
                string? contact = reader["contactnumber"].ToString();
                


                user = new User()
                {
                    Id = id,
                    ImageUrl = imageUrl,
                    AadharId = aadharId,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = dateOnlyBirthDate,
                    Gender = gender,
                    Email = email,
                    ContactNumber = contact,
                   
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
            await con.CloseAsync();
        }
        return user;
    }

    public async Task<List<User>> GetUsersDetails(string ids)
    {
        List<User> users = new();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = $"select id,firstname,lastname,imageurl,aadharid,birthdate,gender,email,contactnumber from users where id IN ({ids})";
            MySqlCommand cmd = new MySqlCommand(query, con);
            await con.OpenAsync();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string? imageUrl = reader["imageurl"].ToString();
                string? aadharId = reader["aadharid"].ToString();
                string? firstName = reader["firstname"].ToString();
                string? lastName = reader["lastname"].ToString();
                DateTime birthDate = DateTime.Parse(reader["birthdate"].ToString());
                DateOnly dateOnlyBirthDate = DateOnly.FromDateTime(birthDate);
                string? gender = reader["gender"].ToString();
                string? email = reader["email"].ToString();
                string? contact = reader["contactnumber"].ToString();
                

                User theUser = new User()
                {
                    Id = id,
                    ImageUrl = imageUrl,
                    AadharId = aadharId,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = dateOnlyBirthDate,
                    Gender = gender,
                    Email = email,
                    ContactNumber = contact,
                };
                users.Add(theUser);
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
        return users;
    }
    public async Task<UserDetails> GetUserDetailsByContactNumber(string contactNumber)
    {
        UserDetails userName = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = $"select id,firstname,lastname from users where contactnumber=@contactNumber";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@contactNumber", contactNumber);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string? firstName = reader["firstname"].ToString();
                string? lastName = reader["lastname"].ToString();

                userName = new UserDetails()
                {
                    UserId = id,
                    FullName = $"{firstName} {lastName}"
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
            await con.CloseAsync();
        }
        return userName;
    }
    public async Task<bool> Add(User user)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;

        try
        {
            string birthDateString = user.BirthDate.ToString("yyyy-MM-dd");
            string query =
                "Insert Into users(imageurl,aadharid,firstname,lastname,birthdate,gender,email,contactnumber,password,createdon,modifiedon) Values(@imageurl,@aadharId,@firstName,@lastName,@birthDate,@gender,@email,@contactNumber,@password,@createdOn,@modifiedOn)";
            MySqlCommand command = new MySqlCommand(query, con);
            await con.OpenAsync();
            command.Parameters.AddWithValue("@imageurl", user.ImageUrl);
            command.Parameters.AddWithValue("@aadharId", user.AadharId);
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@birthDate", birthDateString);
            command.Parameters.AddWithValue("@gender", user.Gender);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@contactNumber", user.ContactNumber);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@createdOn", user.CreatedOn);
            command.Parameters.AddWithValue("@modifiedOn", user.ModifiedOn);
            int rowsAffected = command.ExecuteNonQuery();
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
    public async Task<bool> Update(int id, User user)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;

        try
        {
            string birthDateString = user.BirthDate.ToString("yyyy-MM-dd");
            string query =
                "Update users set aadharid=@aadharId, imageurl=@imageUrl,firstname=@firstName,lastname=@lastName,birthdate=@birthDate,gender=@gender,email=@email where id=@Id";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            await con.OpenAsync();
            command.Parameters.AddWithValue("@aadharId", user.AadharId);
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@birthDate", birthDateString);
            command.Parameters.AddWithValue("@gender", user.Gender);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@imageUrl", user.ImageUrl);
            command.Parameters.AddWithValue("@Id", id);

            int rowsAffected = command.ExecuteNonQuery();
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

    public async Task<bool> Update(string oldContactNumber, ContactNumberDetails details)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                "UPDATE users SET contactnumber=@newContactNumber  WHERE password=@password AND contactnumber=@oldContactNumber";
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
                "UPDATE users SET password=@newPassword  WHERE password=@oldpassword AND contactnumber=@contactNumber";
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
    public async Task<bool> Delete(int userId)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;

        try
        {
            string query = "Delete from users where id=@userId";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@userId", userId);
            await con.OpenAsync();
            int rowsAffected = command.ExecuteNonQuery();
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
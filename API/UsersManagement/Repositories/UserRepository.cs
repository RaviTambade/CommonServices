using UsersManagement.Models;
using UsersManagement.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace UsersManagement.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IConfiguration _configuration;

    private readonly string _constring;

    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _constring = this._configuration.GetConnectionString("DefaultConnection")??
        throw new ArgumentNullException(nameof(_constring));
    }

    public async Task<bool> Add(User user)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;

        try
        {
            string birthDateString = user.BirthDate.ToString("yyyy-MM-dd");
            string query =
                "Insert Into users(imageurl,aadharid,firstname,lastname,birthdate,gender,email,contactnumber) Values(@imageurl,@aadharId,@firstName,@lastName,@birthDate,@gender,@email,@contactNumber)";
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
        con.ConnectionString = _constring;

        try
        {
            string birthDateString = user.BirthDate.ToString("yyyy-MM-dd");
            string query =
                "Update users set aadharid=@aadharId,firstname=@firstName,lastname=@lastName,birthdate=@birthDate,gender=@gender,email=@email,contactnumber=@contactNumber where id=@Id";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            await con.OpenAsync();
            command.Parameters.AddWithValue("@aadharId", user.AadharId);
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@birthDate", birthDateString);
            command.Parameters.AddWithValue("@gender", user.Gender);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@contactNumber", user.ContactNumber);
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

    public async Task<List<User>> GetAll()
    {
        List<User> peoples = new List<User>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;
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

                User people = new User()
                {
                    Id = id,
                    ImageUrl=imageUrl,
                    AadharId = aadharId,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = dateOnlyBirthDate,
                    Gender = gender,
                    Email = email,
                    ContactNumber = contactNumber
                };
                peoples.Add(people);
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
        return peoples;
    }

    public async Task<List<UserNameWithId>> GetUserNameById(string userIdString)
    {
        List<UserNameWithId> userList = new();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;
        try
        {
            string query = $"select id,firstname,lastname from users where id IN ({userIdString})";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userIdString",userIdString);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string? firstName = reader["firstname"].ToString();
                string? lastName = reader["lastname"].ToString();

                userList.Add(new UserNameWithId(){
                      Id = id,
                      Name=$"{firstName} {lastName}"
                });
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
        return userList;
    }
  public async Task<UserNameWithId> GetUserName(string contactNumber)
    {
        UserNameWithId userName = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;
        try
        {
            string query = $"select id,firstname,lastname from users where contactnumber=@contactNumber";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@contactNumber",contactNumber);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string? firstName = reader["firstname"].ToString();
                string? lastName = reader["lastname"].ToString();

               userName=new UserNameWithId(){
                      Id = id,
                      Name=$"{firstName} {lastName}"
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

    public async Task<User> GetDetails(string aadharid)
    {
        User people = new User();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;
        try
        {
            string query = "select * from users where aadharid=@AadharId";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@AadharId", aadharid);
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
                string? contactNumber = reader["contactnumber"].ToString();

                people = new User()
                {
                    Id = id,
                    ImageUrl=imageUrl,
                    AadharId = aadharId,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = dateOnlyBirthDate,
                    Gender = gender,
                    Email = email,
                    ContactNumber = contactNumber
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
        return people;
    }

    public async Task<long> GetIdByContactNumber(string contactNumber)
    {
        long userId = 0;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;
        try
        {
            string query = "select * from users where contactnumber=@contactNumber";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@contactNumber", contactNumber);
            await con.OpenAsync();
            userId = Convert.ToInt64(command.ExecuteScalar());
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

    public async Task<User> GetUserByContact(string contactNumber)
    {
        User user = new User();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;
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
                    ImageUrl=imageUrl,
                    AadharId = aadharId,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = dateOnlyBirthDate,
                    Gender = gender,
                    Email = email,
                    ContactNumber = contact
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

    public async Task<User> GetById(int userId)
    {
        User people = new User();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;
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
                people = new User()
                {
                    Id = id,
                    ImageUrl=imageUrl,
                    AadharId = aadharId,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = dateOnlyBirthDate,
                    Gender = gender,
                    Email = email,
                    ContactNumber = contactNumber
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
        return people;
    }

    public async Task<bool> DeleteByAadharId(string aadharid)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;

        try
        {
            //string birthDateString = people.BirthDate.ToString("yyyy-MM-dd");
            string query = "Delete from users where aadharid=@AadharId";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@AadharId", aadharid);
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

    public async Task<bool> DeletebyId(int userId)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;

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

using PersonalInfoAPI.Models;
using PersonalInfoAPI.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace PersonalInfoAPI.Repositories;

public class PeopleRepository : IPeopleRepository
{
    private readonly IConfiguration _configuration;

    private readonly string _constring;

    public PeopleRepository(IConfiguration configuration)
    {

        _configuration = configuration;
        _constring = this._configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<bool> AddPerson(People people)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;

        try
        {
            string birthDateString = people.BirthDate.ToString("yyyy-MM-dd");
            string query = "Insert Into peoples(aadharid,firstname,lastname,birthdate,gender,email,contactnumber) Values(@aadharId,@firstName,@lastName,@birthDate,@gender,@email,@contactNumber)";
            MySqlCommand command = new MySqlCommand(query, con);
            await con.OpenAsync();
            command.Parameters.AddWithValue("@aadharId", people.AadharId);
            command.Parameters.AddWithValue("@firstName", people.FirstName);
            command.Parameters.AddWithValue("@lastName", people.LastName);
            command.Parameters.AddWithValue("@birthDate", birthDateString);
            command.Parameters.AddWithValue("@gender", people.Gender);
            command.Parameters.AddWithValue("@email", people.Email);
            command.Parameters.AddWithValue("@contactNumber", people.ContactNumber);
            int rowsAffected = command.ExecuteNonQuery();
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

    public async Task<bool> UpdatePerson(int id,People people)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _constring;

        try
        {
            string birthDateString = people.BirthDate.ToString("yyyy-MM-dd");
            string query = "Update peoples set aadharid=@aadharId,firstname=@firstName,lastname=@lastName,birthdate=@birthDate,gender=@gender,email=@email,contactnumber=@contactNumber where id=@Id";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            await con.OpenAsync();
            command.Parameters.AddWithValue("@aadharId", people.AadharId);
            command.Parameters.AddWithValue("@firstName", people.FirstName);
            command.Parameters.AddWithValue("@lastName", people.LastName);
            command.Parameters.AddWithValue("@birthDate", birthDateString);
            command.Parameters.AddWithValue("@gender", people.Gender);
            command.Parameters.AddWithValue("@email", people.Email);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@contactNumber", people.ContactNumber);
            int rowsAffected = command.ExecuteNonQuery();
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

    public async Task<List<People>> GetAllPeoples()
    {
            List<People> peoples = new List<People>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = _constring;
            try
            {
                string query = "select * from peoples";
                MySqlCommand cmd = new MySqlCommand(query,con);
                await con.OpenAsync();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(await reader.ReadAsync())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string? aadharId = reader["aadharid"].ToString();
                    string? firstName = reader["firstname"].ToString();
                    string? lastName = reader["lastname"].ToString();
                    DateOnly birthDate = DateOnly.Parse(reader["birthdate"].ToString());
                    string? gender = reader["gender"].ToString();
                    string? email = reader["email"].ToString();
                    string? contactNumber = reader["contactnumber"].ToString();

                    People people = new People()
                    {
                        Id = id,
                        AadharId = aadharId,
                        FirstName = firstName,
                        LastName = lastName,
                        BirthDate = birthDate,
                        Gender = gender,
                        Email = email,
                        ContactNumber = contactNumber

                    };
                    peoples.Add(people);
                }
                await reader.CloseAsync();
            }
            catch(Exception e){
                throw e;
            }
            finally{
                await con.CloseAsync();
            }
            return peoples;
    }


    public async Task<People> GetDetails(string addharid){
      
          People people =new People();
       MySqlConnection con = new MySqlConnection();
       con.ConnectionString= _constring;
       try{
        string query = "select * from peoples where aadharid=@AadharId";
        MySqlCommand command = new MySqlCommand(query,con);
        await con.OpenAsync();
         MySqlDataReader reader = command.ExecuteReader();
            if(await reader.ReadAsync())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string? aadharId = reader["aadharid"].ToString();
                    string? firstName = reader["firstname"].ToString();
                    string? lastName = reader["lastname"].ToString();
                    DateOnly birthDate = DateOnly.Parse(reader["birthdate"].ToString());
                    string? gender = reader["gender"].ToString();
                    string? email = reader["email"].ToString();
                    string? contactNumber = reader["contactnumber"].ToString();

                     people =  new People()
                    {
                        Id = id,
                        AadharId = aadharId,
                        FirstName = firstName,
                        LastName = lastName,
                        BirthDate = birthDate,
                        Gender = gender,
                        Email = email,
                        ContactNumber = contactNumber

                    };
                }
                await reader.CloseAsync();
       }

       catch(Exception e){
                throw e;
            }
            finally{
                await con.CloseAsync();
            }
            return people;

    }

   
}
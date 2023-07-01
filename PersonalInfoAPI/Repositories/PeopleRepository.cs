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
}
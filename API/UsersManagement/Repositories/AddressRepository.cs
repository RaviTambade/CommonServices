using MySql.Data.MySqlClient;
using UsersManagement.Models;
using UsersManagement.Repositories.Interfaces;

namespace UsersManagement.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly IConfiguration _configuration;

    private readonly string _connectionString;

    public AddressRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString =
            _configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException(nameof(_connectionString));
    }

    public async Task<List<Address>> GetAddresses(int userId)
    {
        List<Address> addresses = new List<Address>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query = "select * from addresses where userid=@userid";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@userid", userId);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                
                Address address  = new Address()
                {
                    Id=reader.GetInt32("id"),
                    UserId=reader.GetInt32("userid"),
                    Area=reader.GetString("area"),
                    LandMark=reader.GetString("landmark"),
                    City=reader.GetString("city"),
                    State=reader.GetString("state"),
                    AlternateContactNumber=reader.GetString("alternatecontactnumber"),
                    PinCode=reader.GetString("pincode"),  
                };
               addresses.Add(address);
            }
            await reader.CloseAsync();
        }
        catch (Exception )
        {
            throw ;
        }
        finally
        {
            await con.CloseAsync();
        }
        return addresses;
    }

    public async Task<bool> Add(Address address)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;

        try
        {
            string query =
                @"INSERT INTO addresses(userid,area,landmark,city,state,alternatecontactnumber,pincode) 
            VALUES(@userid, @area,@landmark, @city,@state,@alternatecontactnumber,@pincode)";
            MySqlCommand command = new MySqlCommand(query, con);
            await con.OpenAsync();
            command.Parameters.AddWithValue("@userid", address.UserId);
            command.Parameters.AddWithValue("@area", address.Area);
            command.Parameters.AddWithValue("@landmark", address.LandMark);
            command.Parameters.AddWithValue("@city", address.City);
            command.Parameters.AddWithValue("@state", address.State);
            command.Parameters.AddWithValue(
                "@alternatecontactnumber",
                address.AlternateContactNumber
            );
            command.Parameters.AddWithValue("@pincode", address.PinCode);
            int rowsAffected = await command.ExecuteNonQueryAsync();
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

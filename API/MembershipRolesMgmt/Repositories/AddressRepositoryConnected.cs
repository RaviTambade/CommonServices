using System.Data;
using MySql.Data.MySqlClient;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;

namespace Transflower.MembershipRolesMgmt.Repositories.Connected;

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

    public async Task<List<Address>> GetAllAddresses(int userId)
    {
        List<Address> addresses = new List<Address>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT addresses.id, addresses.area,addresses.landmark,addresses.city,
            addresses.state,addresses.pincode,users.contactnumber,
            CONCAT(users.firstname, ' ', users.lastname) as name  FROM addresses
            INNER JOIN users on addresses.userid=users.id
            WHERE users.id=@userid";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@userid", userId);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                Address address = new Address()
                {
                    Id = reader.GetInt32("id"),
                    Area = reader.GetString("area"),
                    LandMark = reader.GetString("landmark"),
                    City = reader.GetString("city"),
                    State = reader.GetString("state"),
                    PinCode = reader.GetString("pincode"),
                    Name = reader.GetString("name"),
                    ContactNumber=reader.GetString("contactnumber"),

                };
                addresses.Add(address);
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
        return addresses;
    }

    public async Task<List<Address>> GetAllAddresses(string addressIds)
    {
        List<Address> addresses = new();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query =
                @$"SELECT addresses.id, addresses.area,addresses.landmark,addresses.city,
            addresses.state,addresses.pincode,users.contactnumber,
            CONCAT(users.firstname, ' ', users.lastname) as name  FROM addresses
            INNER JOIN users on addresses.userid=users.id
            WHERE addresses.id IN ({addressIds})";
            MySqlCommand command = new MySqlCommand(query, con);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                Address address = new Address()
                {
                    Id = reader.GetInt32("id"),
                    Area = reader.GetString("area"),
                    LandMark = reader.GetString("landmark"),
                    City = reader.GetString("city"),
                    State = reader.GetString("state"),
                    PinCode = reader.GetString("pincode"),
                    Name = reader.GetString("name"),
                    ContactNumber=reader.GetString("contactnumber"),
                };
                addresses.Add(address);
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
        return addresses;
    }

    public async Task<bool> Insert(Address address)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;

        try
        {
            string query =
                @"INSERT INTO addresses(userid,area,landmark,city,state,pincode) 
            VALUES(@userid, @area,@landmark, @city,@state,@pincode)";
            MySqlCommand command = new MySqlCommand(query, con);
            await con.OpenAsync();
            command.Parameters.AddWithValue("@userid", address.UserId);
            command.Parameters.AddWithValue("@area", address.Area);
            command.Parameters.AddWithValue("@landmark", address.LandMark);
            command.Parameters.AddWithValue("@city", address.City);
            command.Parameters.AddWithValue("@state", address.State);
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

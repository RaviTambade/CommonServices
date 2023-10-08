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

    public async Task<List<AddressInfo>> GetAddresses(int userId)
    {
        List<AddressInfo> addresses = new List<AddressInfo>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT addresses.id, addresses.area,addresses.landmark,addresses.city,
            addresses.state,addresses.alternatecontactnumber,addresses.pincode,users.contactnumber,
            CONCAT(users.firstname, ' ', users.lastname) as name  FROM addresses
            INNER JOIN users on addresses.userid=users.id
            WHERE users.id=@userid";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@userid", userId);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                AddressInfo address = new AddressInfo()
                {
                    Id = reader.GetInt32("id"),
                    Area = reader.GetString("area"),
                    LandMark = reader.GetString("landmark"),
                    City = reader.GetString("city"),
                    State = reader.GetString("state"),
                    AlternateContactNumber = reader.GetString("alternatecontactnumber"),
                    PinCode = reader.GetString("pincode"),
                    Name = reader.GetString("name"),
                    ContactNumber = reader.GetString("contactNumber"),
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

    public async Task<AddressInfo?> GetAddressInfo(int addressId)
    {
        AddressInfo? address = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query =
                @"SELECT addresses.id, addresses.area,addresses.landmark,addresses.city,
            addresses.state,addresses.alternatecontactnumber,addresses.pincode,users.contactnumber,
            CONCAT(users.firstname, ' ', users.lastname) as name  FROM addresses
            INNER JOIN users on addresses.userid=users.id
            WHERE addresses.id=@addressId";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@addressId", addressId);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                address = new AddressInfo()
                {
                    Id = reader.GetInt32("id"),
                    Area = reader.GetString("area"),
                    LandMark = reader.GetString("landmark"),
                    City = reader.GetString("city"),
                    State = reader.GetString("state"),
                    AlternateContactNumber = reader.GetString("alternatecontactnumber"),
                    PinCode = reader.GetString("pincode"),
                    Name = reader.GetString("name"),
                    ContactNumber = reader.GetString("contactNumber"),
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
        return address;
    }

    public async Task<int> GetNearestAddressId(AddressIdRequest request)
    {
        List<AddressDistance> distances = new();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
        try
        {
            string query =
                $"SELECT id AS addressid,pincode,CalculateDistanceByAddress(@addressId, id) AS distance FROM addresses WHERE id IN ({request.AddressIdString})";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@addressId", request.AddressId);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                AddressDistance data = new AddressDistance()
                {
                    Id = reader.GetInt32("addressid"),
                    PinCode = reader.GetString("pincode"),
                    Distance = reader.GetDecimal("distance"),
                };

                if (data.Distance == 0)
                {
                    return data.Id;
                }

                distances.Add(data);
            }
            await reader.CloseAsync();
            foreach (var d in distances)
            {
                Console.WriteLine(d.Distance);
            }

            int? id = distances.MinBy(ad => ad.Distance)?.Id;
            return id ?? 0;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await con.CloseAsync();
        }
    }
}

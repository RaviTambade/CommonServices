using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System.Data;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;

namespace Transflower.MembershipRolesMgmt.Repositories.Disconnected;

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
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();

            await dataAdapter.FillAsync(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Address address = new Address()
                {
                    Id = int.Parse(dataRow["id"].ToString()),
                    UserId = userId, 
                    Area = dataRow["area"].ToString(),
                    LandMark = dataRow["landmark"].ToString(),
                    City = dataRow["city"].ToString(),
                    State = dataRow["state"].ToString(),
                    PinCode = dataRow["pincode"].ToString(),
                    Name = dataRow["name"].ToString(),
                    ContactNumber = dataRow["contactnumber"].ToString(),
                };
                addresses.Add(address);
            }
        }
        catch (Exception)
        {
            throw;
        }
        return addresses;
    }

    public async Task<List<Address>> GetAllAddresses(string addressIds)
    {
        List<Address> addresses = new();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;

        string query =
            @$"SELECT addresses.id, addresses.area,addresses.landmark,addresses.city,
            addresses.state,addresses.pincode,users.contactnumber,users.id as userid,
            CONCAT(users.firstname, ' ', users.lastname) as name  FROM addresses
            INNER JOIN users on addresses.userid=users.id
            WHERE addresses.id IN ({addressIds})";
        MySqlCommand command = new MySqlCommand(query, con);
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
        DataSet dataSet = new DataSet();
        try
        {
            await dataAdapter.FillAsync(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Address address = new Address()
                {
                    Id = int.Parse(dataRow["id"].ToString()),
                    UserId = int.Parse(dataRow["userid"].ToString()),
                    Area = dataRow["area"].ToString(),
                    LandMark = dataRow["landmark"].ToString(),
                    City = dataRow["city"].ToString(),
                    State = dataRow["state"].ToString(),
                    PinCode = dataRow["pincode"].ToString(),
                    Name = dataRow["name"].ToString(),
                    ContactNumber = dataRow["contactnumber"].ToString(),
                };
                addresses.Add(address);
            }
        }
        catch (Exception)
        {
            throw;
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

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();

            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            await dataAdapter.FillAsync(dataSet);
            status = true;
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }

 
}

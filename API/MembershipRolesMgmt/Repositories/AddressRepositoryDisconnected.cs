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

    public async Task<bool> Update(int existingId, Address theAddress)
    {
         bool status = false;
        MySqlConnection con = new MySqlConnection(_connectionString);
        try
        {
            string query =
                "UPDATE addresses SET area=@area , landmark=@landmark, city=@city,state=@state, pincode=@pincode ,addresstype=@addresstype WHERE id=@existingId ";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@existingId", theAddress.Id);
            command.Parameters.AddWithValue("@userid", theAddress.UserId);
            command.Parameters.AddWithValue("@area", theAddress.Area);
            command.Parameters.AddWithValue("@landmark", theAddress.LandMark);
            command.Parameters.AddWithValue("@city", theAddress.City);
            command.Parameters.AddWithValue("@state", theAddress.State);
            command.Parameters.AddWithValue("@pincode", theAddress.PinCode);
            command.Parameters.AddWithValue("@addresstype", theAddress.AddressType);
    
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();

            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            await dataAdapter.FillAsync(dataSet);
            dataAdapter.Update(dataSet);
            status = true;
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }
      public async Task<bool> Delete(int existingId)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;

        try
        {
            string query = "Delete from addresses where id=@existingId";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@existingId", existingId);
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

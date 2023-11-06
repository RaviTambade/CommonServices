using MySql.Data.MySqlClient;
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

    public async Task<List<AddressInfo>> GetAddressesofUser(int userId)
    {
        List<AddressInfo> addresses = new List<AddressInfo>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;

        string query =
            @"SELECT addresses.id, addresses.area,addresses.landmark,addresses.city,
            addresses.state,addresses.alternatecontactnumber,addresses.pincode,users.contactnumber,
            CONCAT(users.firstname, ' ', users.lastname) as name  FROM addresses
            INNER JOIN users on addresses.userid=users.id
            WHERE users.id=@userid";
        MySqlCommand command = new MySqlCommand(query, con);
        command.Parameters.AddWithValue("@userid", userId);
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
        DataSet dataSet = new DataSet();
        try
        {
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                AddressInfo address = new AddressInfo()
                {
                    Id = int.Parse(dataRow["id"].ToString()),
                    Area = dataRow["area"].ToString(),
                    LandMark = dataRow["landmark"].ToString(),
                    City = dataRow["city"].ToString(),
                    State = dataRow["state"].ToString(),
                    AlternateContactNumber = dataRow["alternatecontactnumber"].ToString(),
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

    public async Task<AddressInfo?> GetAddress(int addressId)
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
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            DataTable dataTable = dataSet.Tables[0];

            DataColumn[] keyColumn = new DataColumn[1];
            keyColumn[0] = dataTable.Columns["id"];
            dataTable.PrimaryKey = keyColumn;

            DataRow dataRow = dataTable.Rows.Find(addressId);

            address = new AddressInfo()
            {
                Id = int.Parse(dataRow["id"].ToString()),
                Area = dataRow["area"].ToString(),
                LandMark = dataRow["landmark"].ToString(),
                City = dataRow["city"].ToString(),
                State = dataRow["state"].ToString(),
                AlternateContactNumber = dataRow["alternatecontactnumber"].ToString(),
                PinCode = dataRow["pincode"].ToString(),
                Name = dataRow["name"].ToString(),
                ContactNumber = dataRow["contactnumber"].ToString(),
            };
        }
        catch (Exception)
        {
            throw;
        }
        return address;
    }

    public async Task<List<AddressInfo>> GetAddressesInformation(string addressIds)
    {
        List<AddressInfo> addresses = new();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;

        string query =
            @$"SELECT addresses.id, addresses.area,addresses.landmark,addresses.city,
            addresses.state,addresses.alternatecontactnumber,addresses.pincode,users.contactnumber,
            CONCAT(users.firstname, ' ', users.lastname) as name  FROM addresses
            INNER JOIN users on addresses.userid=users.id
            WHERE addresses.id IN ({addressIds})";
        MySqlCommand command = new MySqlCommand(query, con);
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
        DataSet dataSet = new DataSet();
        try
        {
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                AddressInfo address = new AddressInfo()
                {
                    Id = int.Parse(dataRow["id"].ToString()),
                    Area = dataRow["area"].ToString(),
                    LandMark = dataRow["landmark"].ToString(),
                    City = dataRow["city"].ToString(),
                    State = dataRow["state"].ToString(),
                    AlternateContactNumber = dataRow["alternatecontactnumber"].ToString(),
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

    public async Task<int> GetNearestAddressId(AddressIdRequest request)
    {
        List<AddressDistance> distances = new();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;
       
            string query =
                $"SELECT id AS addressid,pincode,CalculateDistanceByAddress(@addressId, id) AS distance FROM addresses WHERE id IN ({request.AddressIds})";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@addressId", request.AddressId);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            try
            {
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                AddressDistance data = new AddressDistance()
                {
                    Id =  int.Parse(dataRow["addressid"].ToString()),
                    PinCode = dataRow["pincode"].ToString(),
                    Distance = decimal.Parse(dataRow["distance"].ToString()),
                };
                if (data.Distance == 0)
                {
                    return data.Id;
                }

                distances.Add(data);
            }
            int? id = distances.MinBy(ad => ad.Distance)?.Id;
            return id ?? 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Insert(Address address)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _connectionString;

        MySqlCommand command = new MySqlCommand();
        command.CommandText = "SELECT * FROM addresses";
        command.Connection = con;

        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
        DataSet dataSet = new DataSet();

        try
        {
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            DataRow row = dataTable.NewRow();
            row["userid"] = address.UserId;
            row["area"] = address.Area;
            row["landmark"] = address.LandMark;
            row["city"] = address.City;
            row["state"] = address.State;
             row["pincode"] = address.PinCode;
            row["alternatecontactnumber"] = address.AlternateContactNumber;

            dataTable.Rows.Add(row);
            dataAdapter.Update(dataSet);
            status = true;
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }
}

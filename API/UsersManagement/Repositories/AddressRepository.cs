using UsersManagement.Models;
using UsersManagement.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace UsersManagement.Repositories;

public class AddressRepository : IAddressRepository
{
    private IConfiguration _configuration;
    private string _conString;
    public AddressRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<bool> Insert(Location theAddress)
    {
       bool status = false;
       MySqlConnection con = new MySqlConnection();
       con.ConnectionString = _conString;
       try
       {
        string query = "INSERT INTO locations (userId, longitude, latitude, landmark, pincode) VALUES (@userId, @longitude, @latitude, @landMark, @pinCode)";
        MySqlCommand cmd = new MySqlCommand(query, con);
        cmd.Parameters.AddWithValue("@userId",theAddress.UserId);
        cmd.Parameters.AddWithValue("@longitude",theAddress.Longitude);
        cmd.Parameters.AddWithValue("@latitude",theAddress.Latitude);
        cmd.Parameters.AddWithValue("@landMark",theAddress.LandMark);
        cmd.Parameters.AddWithValue("@pinCode",theAddress.PinCode);
        await con.OpenAsync();
        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            status = true;
        }
       }
       catch(Exception e)
       {
        throw e;
       }
       finally
       {
        await con.CloseAsync();
       }
       return status;
    }

    public async Task<bool> Update(Location theAddress)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "UPDATE locations SET pincode = @pinCode, longitude = @langitude, latitude = @latitude, landmark = @landMark  WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query,con);
            cmd.Parameters.AddWithValue("@pinCode",theAddress.PinCode);
            cmd.Parameters.AddWithValue("@langitude",theAddress.Longitude);
            cmd.Parameters.AddWithValue("@latitude",theAddress.Latitude);
            cmd.Parameters.AddWithValue("@landMark",theAddress.LandMark);
            cmd.Parameters.AddWithValue("@id",theAddress.Id);
            await con.OpenAsync();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
            }
        }
        catch(Exception e)
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
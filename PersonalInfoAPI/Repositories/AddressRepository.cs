using PersonalInfoAPI.Models;
using PersonalInfoAPI.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace PersonalInfoAPI.Repositories;

public class AddressRepository : IAddressRepository
{
    private IConfiguration _configuration;
    private string _conString;
    public AddressRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public bool Insert(Address theAddress)
    {
       bool status = false;
       MySqlConnection con = new MySqlConnection();
       con.ConnectionString = _conString;
       try
       {
        string query = "INSERT INTO addresses (personId, longitude, latitude, landmark, pincode) VALUES (@personId, @longitude, @latitude, @landMark, @pinCode)";
        Console.WriteLine(theAddress.Latitude);
        MySqlCommand cmd = new MySqlCommand(query, con);
        cmd.Parameters.AddWithValue("@personId",theAddress.PersonId);
        cmd.Parameters.AddWithValue("@longitude",theAddress.Longitude);
        cmd.Parameters.AddWithValue("@latitude",theAddress.Latitude);
        cmd.Parameters.AddWithValue("@landMark",theAddress.LandMark);
        cmd.Parameters.AddWithValue("@pinCode",theAddress.PinCode);
        con.Open();
        cmd.ExecuteNonQuery();
        status = true;
       }
       catch(Exception e)
       {
        throw e;
       }
       finally
       {
        con.Close();
       }
       return status;
    }

    public bool Update(Address theAddress)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "UPDATE addresses SET pincode = @pinCode, longitude = @langitude, latitude = @latitude, landmark = @landMark  WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query,con);
            cmd.Parameters.AddWithValue("@pinCode",theAddress.PinCode);
            cmd.Parameters.AddWithValue("@langitude",theAddress.Longitude);
            cmd.Parameters.AddWithValue("@latitude",theAddress.Latitude);
            cmd.Parameters.AddWithValue("@landMark",theAddress.LandMark);
            cmd.Parameters.AddWithValue("@id",theAddress.Id);
            con.Open();
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch(Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return status;
    }
}
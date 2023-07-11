using Corporate.Models;
using Corporate.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace Corporate.Repositories;

public class CorporateRepository : ICorporateRepository
{
    private IConfiguration _configuration;
    private string _conString;

    public CorporateRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<Corporation>> GetAll()
    {
        List<Corporation> corporates = new List<Corporation>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM corporations";
            MySqlCommand cmd = new MySqlCommand(query, con);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                string contactnumber = reader["contactnumber"].ToString();
                string email = reader["email"].ToString();
                string personid = reader["personid"].ToString();

                Corporation corporate = new Corporation
                {
                    Id = id,
                    Name = name,
                    ContactNumber = contactnumber,
                    Email = email,
                    PersonId = personid
                };
                corporates.Add(corporate);
            }
            await reader.CloseAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return corporates;
    }

    public async Task<Corporation> GetById(int id)
    {
        Corporation corporate = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM corporations where id=@id";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int cid = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                string contactnumber = reader["contactnumber"].ToString();
                string email = reader["email"].ToString();
                string personid = reader["personid"].ToString();

                corporate = new Corporation
                {
                    Id = cid,
                    Name = name,
                    ContactNumber = contactnumber,
                    Email = email,
                    PersonId = personid
                };
            }
            await reader.CloseAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return corporate;
    }

    public async Task<List<CorporateNameWithId>> GetNames(string id)
    {
        List<CorporateNameWithId> list = new();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = $"SELECT id,name FROM corporations where id IN ({id}) ";
            // string query = $"SELECT * FROM corporations where id IN (@ids) ";
            System.Console.WriteLine(query);
            MySqlCommand cmd = new MySqlCommand(query, con);
            // cmd.Parameters.AddWithValue("@ids", id);
            await con.OpenAsync();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int cid = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                list.Add(new CorporateNameWithId() { Id = cid, Name = name, });
            }
            await reader.CloseAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return list;
    }

    public async Task<bool> Insert(Corporation corporate)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query =
                "INSERT INTO corporations (name , contactnumber, email,personid) VALUES (@name, @contactnumber, @email, @personid)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", corporate.Name);
            cmd.Parameters.AddWithValue("@contactnumber", corporate.ContactNumber);
            cmd.Parameters.AddWithValue("@email", corporate.Email);
            cmd.Parameters.AddWithValue("@personid", corporate.PersonId);

            await con.OpenAsync();
            int rowsAffected = cmd.ExecuteNonQuery();
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

    public async Task<bool> Update(int id, Corporation corporate)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query =
                "UPDATE corporations SET name=@name, contactnumber=@contactnumber, email=@email,personid=@personid WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", corporate.Name);
            cmd.Parameters.AddWithValue("@contactnumber", corporate.ContactNumber);
            cmd.Parameters.AddWithValue("@email", corporate.Email);
            cmd.Parameters.AddWithValue("@personid", corporate.PersonId);
            cmd.Parameters.AddWithValue("@id", id);
            await con.OpenAsync();
            int rowsAffected = cmd.ExecuteNonQuery();
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

    public async Task<bool> Delete(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM corporations WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            await con.OpenAsync();
            int rowsAffected = cmd.ExecuteNonQuery();
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

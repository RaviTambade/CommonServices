using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
namespace Transflower.MembershipRolesMgmt.Repositories;

public class RoleRepository : IRoleRepository
{

    private readonly IConfiguration _configuration;
    private readonly string _conString;
    private readonly RoleContext _context;

    public RoleRepository(RoleContext context)
    {
        _context = context;
    }

    public async Task<List<UserRole>> GetAll()
    {
        try
        {
            var userRoles = await _context.UserRoles.ToListAsync();
            return userRoles;
        }
        catch (Exception)
        {
            throw;
        }
    }


 public async Task<List<Role>> GetRoles()
    {
        try
        {
            var userRoles = await _context.Roles.ToListAsync();
            return userRoles;
        }
        catch (Exception)
        {
            throw;
        }
    }

   
    public async Task<List<Role>> GetRolesOfUser(int userId)
    {
        List<Role> roles = new();
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query =
                @"SELECT * FROM roles INNER JOIN userroles on userroles.roleid = roles.id
                  INNER JOIN  users ON users.id=userroles.userid
                 WHERE users.id=@userid"; //and  lob='Ekrushi
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userid", userId);
            await con.OpenAsync();
            MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                
               int roleId=int.Parse(reader["id"].ToString());
               string roleName= reader["name"].ToString();
               string lob=reader["lob"].ToString();
               Role role = new Role(){
                Id=roleId,
                Name=roleName,
                Lob=lob
               };
               roles.Add(role);
            }
            await reader.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
        return roles;
    }

    public async Task<Role> GetById(int userRoleId)
    {
        try
        {
            var userRole = await _context.Roles.FindAsync(userRoleId);
            return userRole;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Insert(UserRole userRole)
    {
        bool status = false;
        try
        {
            await _context.UserRoles.AddAsync(userRole);
            status = await SaveChanges(_context);
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }

    public async Task<bool> Update(UserRole userRole)
    {
        bool status = false;
        try
        {
            var oldMerchant = await _context.UserRoles.FindAsync(userRole.Id);
            if (oldMerchant is not null)
            {
                oldMerchant.UserId = userRole.UserId;
                oldMerchant.RoleId = userRole.RoleId;
                status = await SaveChanges(_context);
            }
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }

    public async Task<bool> Delete(int userRoleId)
    {
        bool status = false;
        try
        {
            var userRole = await _context.UserRoles.FindAsync(userRoleId);
            if (userRole is not null)
            {
                _context.UserRoles.Remove(userRole);
                status = await SaveChanges(_context);
            }
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }

    private async Task<bool> SaveChanges(RoleContext _context)
    {
        int rowsAffected = await _context.SaveChangesAsync();
        return rowsAffected > 0;
    }


   
   
}
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;


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

    public async Task<List<Role>> GetRoles(int userId)
    {
        try
        {
            var roles = await (
                from role in _context.Roles
                join userrole in _context.UserRoles on role.Id equals userrole.RoleId
                join user in _context.Users on userrole.UserId equals user.Id
                where user.Id == userId
                select role
            ).ToListAsync();

            return roles;
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
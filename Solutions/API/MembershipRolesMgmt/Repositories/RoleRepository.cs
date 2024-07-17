using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Transflower.MembershipRolesMgmt.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly RoleContext _context;

    public RoleRepository(RoleContext context)
    {
        _context = context;
    }

    public async Task<List<Role>> GetRoles()
    {
        try
        {
            var roles = await _context.Roles.ToListAsync();
            return roles;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<string>> GetLOBs()
    {
        try
        {
            // var roles = await _context.Roles.Where(r => roleIds.Contains(r.Id.ToString())).ToListAsync();
            var roles = await (
                from role in _context.Roles
                select role.Lob).Distinct().ToListAsync<string>();

            return roles;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Role>> GetRoles(string roleIds)
    {
        try
        {
            // var roles = await _context.Roles.Where(r => roleIds.Contains(r.Id.ToString())).ToListAsync();
            var roles = await (
                from role in _context.Roles
                where roleIds.Contains(role.Id.ToString())
                select role
            ).ToListAsync();
            return roles;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Role>> GetRolesOfUserByLOB(int userId, string lob)
    {
        try
        {
            var roles = await (
                from role in _context.Roles
                join userrole in _context.UserRoles on role.Id equals userrole.RoleId
                join user in _context.Users on userrole.UserId equals user.Id
                where user.Id == userId && role.Lob == lob
                select role
            ).ToListAsync();
            return roles;
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

    public async Task<List<Role>> GetRolesByLob(string lob)
    {
        try
        {
            var roles = await _context.Roles.Where(r => r.Lob == lob
            ).ToListAsync();

            return roles;
        }
        catch (Exception)
        {
            throw;
        }
    }

     public async Task<List<UserRoleDetails>> GetUserRoleDetailsByLOB(string lob)
    {
    
        try
        {
            var roles = await (from user in _context.Users
            join userRole in _context.UserRoles on user.Id equals userRole.UserId
            join role in _context.Roles on userRole.RoleId equals role.Id
            where role.Lob == lob
            select new UserRoleDetails
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleName = role.Name
            }).ToListAsync();

            return roles;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<User>> GetAllUsersByLOB(LOB lob)
    {
        try
        {
            var details = await (from user in _context.Users
                                 join userrole in _context.UserRoles on user.Id equals userrole.UserId
                                 join role in _context.Roles on userrole.RoleId equals role.Id
                                 where role.Name == lob.RoleName && role.Lob == lob.Lob
                                 select user).ToListAsync();
            return details;
        }
        catch (Exception)
        {
            throw;
        }
    }

    
    public async Task<bool> Insert(Role role)
    {
        bool status = false;
        try
        {
            await _context.Roles.AddAsync(role);
            status = await SaveChanges(_context);
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }

    public async Task<bool> Update(Role role)
    {
        bool status = false;
        try
        {
            var oldrole = await _context.Roles.FindAsync(role.Id);
            if (oldrole is not null)
            {
                oldrole.Name = role.Name;
                oldrole.Lob = role.Lob;
                status = await SaveChanges(_context);
            }
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }

    public async Task<bool> DeleteRole(int roleId)
    {
        bool status = false;
        try
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role is not null)
            {
                _context.Roles.Remove(role);
                status = await SaveChanges(_context);
            }
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }

     public async Task<bool> DeleteRoleByUserId(int userId,int roleId)
    {
        bool status = false;
        var userRoleToDelete = _context.UserRoles
        .Where(ur => ur.UserId == userId && ur.RoleId == roleId)
        .FirstOrDefault();
        _context.Remove(userRoleToDelete);
       status =await SaveChanges(_context);
 
        return status;
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
            var oldUserRole = await _context.UserRoles.FindAsync(userRole.Id);
            if (oldUserRole is not null)
            {
                oldUserRole.UserId = userRole.UserId;
                oldUserRole.RoleId = userRole.RoleId;
                status = await SaveChanges(_context);
            }
        }
        catch (Exception)
        {
            throw;
        }
        return status;
    }

    public async Task<bool> DeleteUserRole(int userRoleId)
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

    public async Task<bool> IsUserHasRole(int userId, int roleId)
    {
        try
        {
            var isAsign = await (
                from userroles in _context.UserRoles
                where userroles.UserId == userId && userroles.RoleId == roleId
                select userroles.Id
            ).AnyAsync();
            return isAsign;
        }
        catch (Exception)
        {
            throw;
        }

    }
}

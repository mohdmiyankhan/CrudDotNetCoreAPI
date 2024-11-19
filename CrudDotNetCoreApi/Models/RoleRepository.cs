using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDotNetCoreApi.Models
{
    public class RoleRepository
    {
        private readonly AppDbContext _dbContext;

        public RoleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Role>> GetAllRoleAsync()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            //return await _dbContext.Roles.FindAsync(id);
            var roleDetails = await _dbContext.Roles.FindAsync(id);
            if (roleDetails == null)
            {
                throw new Exception("Record not found.");
            }
            return roleDetails;
        }

        public async Task AddRoleAsync(Role role)
        {
            var details = await _dbContext.Roles.Where(x => x.RoleName == role.RoleName).FirstOrDefaultAsync();
            if (details != null)
            {
                throw new Exception("Role already exist.");
            }

            await _dbContext.Set<Role>().AddAsync(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(int id, Role model)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null)
            {
                throw new Exception("Record not found.");
            }

            role.RoleId = model.RoleId;
            role.RoleName = model.RoleName;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null)
            {
                throw new Exception("Record not found.");
            }
            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
        }
    }
}

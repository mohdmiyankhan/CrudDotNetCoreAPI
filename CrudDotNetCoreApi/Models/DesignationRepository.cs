using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDotNetCoreApi.Models
{
    public class DesignationRepository
    {
        private readonly AppDbContext _dbContext;

        public DesignationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Designation>> GetAllDesignationAsync()
        {
            return await _dbContext.Designations.ToListAsync();
        }

        public async Task<Designation> GetDesignationByIdAsync(int id)
        {
            //return await _dbContext.Designations.FindAsync(id);
            var designationDetails = await _dbContext.Designations.FindAsync(id);
            if (designationDetails == null)
            {
                throw new Exception("Record not found.");
            }
            return designationDetails;
        }

        public async Task AddDesignationAsync(Designation designation)
        {
            var details = await _dbContext.Designations.Where(x => x.DesignationName == designation.DesignationName).FirstOrDefaultAsync();
            if (details != null)
            {
                throw new Exception("Designation already exist.");
            }

            await _dbContext.Set<Designation>().AddAsync(designation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDesignationAsync(int id, Designation model)
        {
            var designation = await _dbContext.Designations.FindAsync(id);
            if (designation == null)
            {
                throw new Exception("Record not found.");
            }

            designation.DesignationId = model.DesignationId;
            designation.DesignationName = model.DesignationName;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDesignationAsync(int id)
        {
            var designation = await _dbContext.Designations.FindAsync(id);
            if (designation == null)
            {
                throw new Exception("Record not found.");
            }
            _dbContext.Designations.Remove(designation);
            await _dbContext.SaveChangesAsync();
        }
    }
}

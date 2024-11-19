using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDotNetCoreApi.Models
{
    public class ClientProjectRepository
    {
        private readonly AppDbContext _dbContext;

        public ClientProjectRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClientProject>> GetAllClientProjectsAsync()
        {
            return await _dbContext.ClientProjects.ToListAsync();
        }

        public async Task<ClientProject> GetClientProjectByIdAsync(int id)
        {
            //return await _dbContext.ClientProjects.FindAsync(id);
            var clientProjectDetails = await _dbContext.ClientProjects.FindAsync(id);
            if (clientProjectDetails == null)
            {
                throw new Exception("Record not found.");
            }
            return clientProjectDetails;
        }

        public async Task AddClientProjectAsync(ClientProject clientProject)
        {
            await _dbContext.Set<ClientProject>().AddAsync(clientProject);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateClientProjectAsync(int id, ClientProject model)
        {
            var clientProject = await _dbContext.ClientProjects.FindAsync(id);
            if (clientProject == null)
            {
                throw new Exception("Record not found.");
            }

            clientProject.ClientProjectId = model.ClientProjectId;
            clientProject.ProjectName = model.ProjectName;
            clientProject.StartDate = model.StartDate;
            clientProject.ExpectedDate = model.ExpectedDate;
            clientProject.LeadByEmpId = model.LeadByEmpId;
            clientProject.CompletedDate = model.CompletedDate;
            clientProject.ContactPersonName = model.ContactPersonName;
            clientProject.ContactPersonContactNo = model.ContactPersonContactNo;
            clientProject.ContactPersonEmailId = model.ContactPersonEmailId;
            clientProject.TotalEmpWorking = model.TotalEmpWorking;
            clientProject.ProjectCost = model.ProjectCost;
            clientProject.ProjectDetails = model.ProjectDetails;
            clientProject.ClientId = model.ClientId;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteClientProjectAsync(int id)
        {
            var clientProject = await _dbContext.ClientProjects.FindAsync(id);
            if (clientProject == null)
            {
                throw new Exception("Record not found.");
            }
            _dbContext.ClientProjects.Remove(clientProject);
            await _dbContext.SaveChangesAsync();
        }
    }
}

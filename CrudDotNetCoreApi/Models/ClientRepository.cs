using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDotNetCoreApi.Models
{
    public class ClientRepository
    {
        private readonly AppDbContext _dbContext;

        public ClientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            //return await _dbContext.Clients.FindAsync(id);
            var clientDetails = await _dbContext.Clients.FindAsync(id);
            if (clientDetails == null)
            {
                throw new Exception("Record not found.");
            }
            return clientDetails;
        }

        public async Task AddClientAsync(Client client)
        {
            await _dbContext.Set<Client>().AddAsync(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(int id, Client model)
        {
            var client = await _dbContext.Clients.FindAsync(id);
            if (client == null)
            {
                throw new Exception("Record not found.");
            }

            client.ClientId = model.ClientId;
            client.ContactPersonName = model.ContactPersonName;
            client.CompanyName = model.CompanyName;
            client.Address = model.Address;
            client.City = model.City;
            client.PinCode = model.PinCode;
            client.State = model.State;
            client.EmployeeStrength = model.EmployeeStrength;
            client.ContactNo = model.ContactNo;
            client.GSTNo = model.GSTNo;
            client.RegNo = model.RegNo;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _dbContext.Clients.FindAsync(id);
            if (client == null)
            {
                throw new Exception("Record not found.");
            }
            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();
        }
    }
}

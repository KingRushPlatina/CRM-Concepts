using CRM_Concepts_Api.DBContext.Context;
using CRM_Concepts_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CRM_Concepts_Api.Services
{
    public class ClientManager : IClientManager
    {
        private readonly ICRMContext _dbContext;

        public ClientManager(ICRMContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(string cf)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Cf == cf);
            if (client == null)
                return false;

            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<Client> GetAsync(string cf)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(c => c.Cf == cf);
        }

        public async Task<string> InsertAsync(Client client)
        {
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
            return client.Cf;
        }

        public async Task<bool> UpdateAsync(string cf, Client updatedClient)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Cf == cf);
            if (client == null)
                return false;

            // Update properties
            client.Name = updatedClient.Name;
            client.Address = updatedClient.Address;
            client.Sesso = updatedClient.Sesso;

            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<Client>> ListAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }



    }
}

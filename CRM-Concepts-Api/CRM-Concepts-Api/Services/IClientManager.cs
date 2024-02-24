using CRM_Concepts_Api.Models;

namespace CRM_Concepts_Api.Services
{
    public interface IClientManager
    {
        Task<string> InsertAsync(Client client);
        Task<bool> UpdateAsync(string cf, Client client);
        Task<bool> DeleteAsync(string cf);
        Task<Client> GetAsync(string cf);
        Task<List<Client>> ListAsync();
    }
}

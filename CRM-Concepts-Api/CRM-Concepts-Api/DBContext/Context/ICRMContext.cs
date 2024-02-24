using CRM_Concepts_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CRM_Concepts_Api.DBContext.Context
{
    public interface ICRMContext
    {
        DbSet<Client> Clients { get; set;  }
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

using CRM_Concepts_Api.DBContext.Context;
using CRM_Concepts_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CRM_Concepts_Api.DBContext
{
    public class CRMContext :DbContext, ICRMContext
    {
      
        public CRMContext(DbContextOptions<CRMContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DatabaseFacade Database;
    }
}

using Microsoft.EntityFrameworkCore;
using Multi_Tenancy_Deom.Models;
using Multi_Tenancy_Deom.Services;

namespace Multi_Tenancy_Deom.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ITenantService _tenantService;
        public string TenantId {get;set;}
        public ApplicationDbContext(DbContextOptions options, ITenantService tenantService) : base(options)
        {
            _tenantService = tenantService;
            TenantId = _tenantService.GetCurrentTenant()?.TenantId;
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantConnectionString = _tenantService.GetConnectionString();
            if(!string.IsNullOrEmpty(tenantConnectionString))
            {
                var dbProvider = _tenantService.GetDatabaseProvider();
                if (dbProvider?.ToLower() == "mssql" )
                {
                    optionsBuilder.UseSqlServer(tenantConnectionString); 
                }
            }
        }


    }



}

using Multi_Tenancy_Deom.Settings;

namespace Multi_Tenancy_Deom.Services
{
    public interface ITenantService
    {
        string? GetDatabaseProvider();
        string? GetConnectionString();
        Tenant? GetCurrentTenant();
    }
}

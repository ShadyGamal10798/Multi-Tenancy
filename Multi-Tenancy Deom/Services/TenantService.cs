using Multi_Tenancy_Deom.Settings;

namespace Multi_Tenancy_Deom.Services
{
    public class TenantService : ITenantService
    {
        private readonly TenantSettings _tenantSettings;
        private readonly HttpContext? _httpContext;
        private Tenant? _currentTenant;
        public TenantService(IHttpContextAccessor contextAccessor , Microsoft.Extensions.Options.IOptions<TenantSettings> tenantSettings)
        {
            _httpContext = contextAccessor.HttpContext;
            _tenantSettings = tenantSettings.Value;

            if(_httpContext != null)
            {
                if(_httpContext.Request.Headers.TryGetValue("tenant" , out var tenantId) != null)
                {
                    SetCurrentTenant(tenantId!);
                }
                else
                {
                    throw new Exception("No Tenant Provider");
                }
            }
        }
        public string? GetConnectionString()
        {
            var currentConnectionString = _currentTenant is null
                ? _tenantSettings.Default.ConnectionString
                : _currentTenant.ConnectionString;
            return currentConnectionString;
        }

        public Tenant? GetCurrentTenant()
        {
            return _currentTenant;
        }

        public string? GetDatabaseProvider()
        {
            return _tenantSettings.Default.DBProvider;
        }

        private void SetCurrentTenant(string tenantId)
        {
            _currentTenant = _tenantSettings.Tenants.FirstOrDefault(x => x.TenantId == tenantId);

            if (_currentTenant is null)
            {
                throw new Exception("Invalid TenantId");
            }

            if (string.IsNullOrEmpty(_currentTenant.ConnectionString))
            {
                _currentTenant.ConnectionString = _tenantSettings.Default.ConnectionString;
            }
        }
    }
}

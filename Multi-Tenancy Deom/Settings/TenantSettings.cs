namespace Multi_Tenancy_Deom.Settings
{
    public class TenantSettings
    {
        public Configuration Default { get; set; } = default!;
        public List<Tenant> Tenants { get; set; } = new();
    }
}

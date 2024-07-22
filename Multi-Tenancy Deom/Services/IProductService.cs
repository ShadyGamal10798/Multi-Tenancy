using Multi_Tenancy_Deom.Models;

namespace Multi_Tenancy_Deom.Services
{
    public interface IProductService
    {
        Task<Product> CreatedAsync(Product product);
        Task<Product?> GetByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetAllAsync();
    }
}

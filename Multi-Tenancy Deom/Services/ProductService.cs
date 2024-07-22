using Microsoft.EntityFrameworkCore;
using Multi_Tenancy_Deom.Data;
using Multi_Tenancy_Deom.Models;

namespace Multi_Tenancy_Deom.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreatedAsync(Product product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}

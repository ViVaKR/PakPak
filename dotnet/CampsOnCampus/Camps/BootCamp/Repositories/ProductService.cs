using BootCamp.Data;
using BootCamp.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace BootCamp.Repositories
{
    public class ProductService(VivContext db) : IProductService
    {
        private readonly VivContext _db = db;

        public async Task<List<Product>> GetProductListAsync()
        {
            return await _db.Products.FromSqlRaw<Product>("GetProductList").ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducebyIdAsync(int id)
        {
            var param = new SqlParameter("@ProductId", id);

            var details = Task.Run(() =>
                _db.Products.FromSqlRaw(@"exec GetProductById @ProductId", param).ToListAsync());

            return await details;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            _db.Products.Add(product);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            _db.Products.Update(product);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteProductAsync(Product product)
        {
            _db.Products.Remove(product);
            return await _db.SaveChangesAsync();
        }
    }
}
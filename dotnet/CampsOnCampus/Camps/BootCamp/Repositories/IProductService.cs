using BootCamp.Entities;

namespace BootCamp.Repositories
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductListAsync();

        public Task<IEnumerable<Product>> GetProducebyIdAsync(int id);

        public Task<int> AddProductAsync(Product product);

        public Task<int> UpdateProductAsync(Product product);

        public Task<int> DeleteProductAsync(Product product);
    }
}
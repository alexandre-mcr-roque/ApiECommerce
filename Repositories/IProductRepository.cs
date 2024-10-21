using ApiECommerce.Entities;

namespace ApiECommerce.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetBestSellerProductsAsync();
        Task<IEnumerable<Product>> GetPopularProductsAsync();
        Task<Product> GetProductDetailsAsync(int id);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    }
}
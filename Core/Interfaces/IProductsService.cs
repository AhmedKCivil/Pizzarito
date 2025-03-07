using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductsService
    {
        Task AddNewProductAsync(NewProductVM data);
        Task AddToCartAsync(int productId, string imageTitle, string productName, double productPrice, string cartSessionKey);
        Task UpdateAsync(int id, Product updatedProduct);
        Task<List<Product>> GetAllProductsAsync(string apiUrl, string category = null);
        Task<Product> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}

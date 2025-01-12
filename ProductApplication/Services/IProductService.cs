using ProductApplication.Models;

namespace ProductApplication.Services
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(long id);
        void DeleteProduct(long id);
        int UpdateProduct(Product product);
        void DecrementStock(long id, int quantity);
        void AddToStock(long id, int quantity);
    }
}
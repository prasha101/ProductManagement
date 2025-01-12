using ProductApplication.Models;

namespace ProductApplication.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        List<Product> GetAll();
        Product GetById(long id);
        void Delete(long id);
        int Update(Product product);
        void DecrementStock(long id, int quantity);
        void AddToStock(long id, int quantity);
    }
}

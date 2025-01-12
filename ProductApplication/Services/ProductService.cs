using ProductApplication.Models;
using ProductApplication.Repositories;

namespace ProductApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(long id)
        {
            return _productRepository.GetById(id);
        }

        public void CreateProduct(Product product)
        {
            _productRepository.Add(product);
        }

        public int UpdateProduct(Product product)
        {
           return _productRepository.Update(product);
        }

        public void DeleteProduct(long id)
        {
            _productRepository.Delete(id);
        }

        public void DecrementStock(long id, int quantity)
        {
            _productRepository.DecrementStock(id, quantity);
        }

        public void AddToStock(long id, int quantity)
        {
            _productRepository.AddToStock(id, quantity);
        }
    }
}

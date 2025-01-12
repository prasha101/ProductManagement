using Microsoft.EntityFrameworkCore;
using ProductApplication.Data;
using ProductApplication.Models;

namespace ProductApplication.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(long id)
        {
            return _context.Products.Find(id);
        }

        public void Add(Product product)
        {
            product.Id = GenerateProductId();
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public int Update(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct != null)
            {
                _context.Entry(existingProduct).CurrentValues.SetValues(product); 
               return _context.SaveChanges();
            }
            return 0;
        }

        public void Delete(long id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void DecrementStock(long id, int quantity)
        {
            var product = _context.Products.Find(id);
            if (product != null && product.StockAvailable >= quantity)
            {
                product.StockAvailable -= quantity;
                _context.SaveChanges();
            }
        }

        public void AddToStock(long id, int quantity)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                product.StockAvailable += quantity;
                _context.SaveChanges();
            }
        }

        public long GenerateProductId()
        {
           return  _context.Database.SqlQuery<ProductIdResult>($"EXEC GetProductId").AsEnumerable().First().ProductId;
        }
    }
}

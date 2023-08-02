using APIHomework.DAL.Context;
using APIHomework.DAL.Entities;

namespace APIHomework.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext _context;
        public ProductRepository(ProductContext productContext)
        {
            _context = productContext;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product == null)
            {
                return;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
             return _context.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}

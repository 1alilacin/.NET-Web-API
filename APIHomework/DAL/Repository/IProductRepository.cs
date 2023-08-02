using APIHomework.DAL.Entities;

namespace APIHomework.DAL.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        void DeleteProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
    }
}

using APIHomework.DAL.Entities;
using APIHomework.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIHomework.Services
{
    public interface IProductService 
    {
        List<Product> GetProducts();
        Product GetProductById(int  id);
        void DeleteProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
       
    }
}

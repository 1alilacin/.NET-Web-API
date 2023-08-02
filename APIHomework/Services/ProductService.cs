using APIHomework.DAL.Context;
using APIHomework.DAL.Entities;
using APIHomework.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIHomework.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }
        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
    }
}

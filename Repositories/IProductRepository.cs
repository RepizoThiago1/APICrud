using Microsoft.AspNetCore.Mvc;

namespace APICrud.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProductList();
        public Task<Product> GetProductById(int Id);
        public Task<Product> AddProduct(Product product);
        public Task<Product> EditProduct(Product product);
        public Task<Product> DeleteProductById(int Id);
    }
}

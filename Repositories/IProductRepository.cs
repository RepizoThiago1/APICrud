using Microsoft.AspNetCore.Mvc;

namespace APICrud.Repositories
{
    public interface IProductRepository
    {
        public List<Product> GetProductList();
        public Product GetProductById(int Id);
        public bool DeleteProductById(int Id);
        public Product AddProduct(Product product);
        public Product EditProduct(Product product);
    }
}

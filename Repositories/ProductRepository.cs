using Microsoft.AspNetCore.Mvc;

namespace APICrud.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public List<Product> GetProductList()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return null;
        }
        public Product GetProductById(int id)
        {
            var findDbProduct = _context.Products.Find(id);
            try
            {
                if (findDbProduct is null)
                {
                    return null;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return findDbProduct;
        }
        public Product AddProduct(Product product)
        {
            try
            {
                if (product is not null)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return product;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return null;
        }

        public Product EditProduct(Product product)
        {
            try
            {
                var findDbProduct = _context.Products.Find(product.Id);
                if (findDbProduct is null)
                {
                    return null;
                }

                findDbProduct.Name = product.Name;
                findDbProduct.Price = product.Price;
                findDbProduct.Description = product.Description;
                _context.SaveChanges();

                return product;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public bool DeleteProductById(int id)
        {
            var findDbProduct = _context.Products.Find(id);
            try
            {
                if (findDbProduct is null)
                {
                    return false;
                }
                _context.Products.Remove(findDbProduct);
                _context.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            
        }
    }
}

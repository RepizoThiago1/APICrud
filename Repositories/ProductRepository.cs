namespace APICrud.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProductList()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetProductById(int Id)
        {
            var dbResult = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);

            if (dbResult is null)
            {
                return null;
            }

            return dbResult;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var dbResult = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return dbResult.Entity;
        }
        public async Task<Product> EditProduct(Product product)
        {
            var dbResult = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (dbResult is not null)
            {
                dbResult.Name = product.Name;
                dbResult.Price = product.Price;
                dbResult.Description = product.Description;

                await _context.SaveChangesAsync();

                return dbResult;
            }

            return null;
        }

        public async Task<Product> DeleteProductById(int Id)
        {
            var dbResult = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);

            if (dbResult is not null)
            {
                _context.Remove(dbResult);
                await _context.SaveChangesAsync();
               
                return dbResult;
            }
            return null;
        }
    }
}

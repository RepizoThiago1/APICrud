using Microsoft.AspNetCore.Mvc;

namespace APICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        #region http methods
        [HttpGet]
        public ActionResult<List<Product>> GetProductList()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<List<Product>> GetSingleProduct(int Id)
        {
            var product = _context.Products.Find(Id);
            if (product == null)
            {
                return BadRequest("Produto não encontrado");
            }
            return Ok(product);
        }


        [HttpPost]
        public ActionResult<List<Product>> AddProduct(Product product)
        {
            return Ok(_context.Products.ToList());
        }

        [HttpPut]
        public ActionResult<List<Product>> EditProduct(Product product)
        {
            var findDbProduct = _context.Products.Find(product.Id);
            if (findDbProduct == null)
            {
                return BadRequest("Produto não encontrado");
            }
            findDbProduct.Name = product.Name;
            findDbProduct.Price = product.Price;
            findDbProduct.Description = product.Description;
            _context.SaveChanges();

            return Ok(_context.Products.ToList());
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Product>> DeleteProductById(Product product)
        {
            var findDbProduct = _context.Products.Find(product.Id);
            if (findDbProduct == null)
            {
                return NotFound("Produto não encontrado");
            }
            _context.Products.Remove(findDbProduct);
            return Ok(_context.Products.ToList());
        }

        #endregion
    }
}
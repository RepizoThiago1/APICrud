using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductList()
        {
            try
            {
                var dbQueryList = await _productRepository.GetProductList();

                if (dbQueryList is null)
                {
                    return NotFound("Produto não encontrado");
                }
                return Ok(dbQueryList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProductById(int id)
        {
            var findProduct = await _productRepository.GetProductById(id);

            if (findProduct is null)
            {
                return NotFound("Produto não encontrado");
            }

            return Ok(findProduct);

        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            try
            {
                if (product is null)
                {
                    return BadRequest("Produto que foi inserido é nulo");
                }
                var productAdd = await _productRepository.AddProduct(product);

                return Ok(productAdd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult<Product>> EditProduct(Product product)
        {
            try
            {
                var productEdit = await _productRepository.EditProduct(product);

                if (product is null)
                {
                    return NotFound("Produto não encontrado");
                }
                return Ok(productEdit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProductById(int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);

                if (product is null)
                {
                    return NotFound("Produto não encontrado");
                }
                return await _productRepository.DeleteProductById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

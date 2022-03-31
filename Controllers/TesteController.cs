using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        public readonly IProductRepository _productRepository;

        public TesteController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProductList()
        {
            return Ok(_productRepository.GetProductList());
        }

        [HttpGet("{id}")]
        public ActionResult<List<Product>> GetProductById(int id)
        {
            var findProduct = _productRepository.GetProductById(id);

            if (findProduct is null)
            {
                return NotFound("Produto não encontrado");
            }
            else
            {
                return Ok(findProduct);
            }
        }

        [HttpPost]
        public ActionResult<List<Product>> AddProduct(Product product)
        {
            var productAdd = _productRepository.AddProduct(product);

            if (productAdd is null)
            {
                return BadRequest("Produto que foi inserido é nulo");
            }
            return Ok(productAdd);
        }

        [HttpPut]
        public ActionResult<List<Product>> EditProduct(Product product)
        {
            var productEdit = _productRepository.EditProduct(product);
            return Ok(productEdit);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Product>> DeleteProductById(int Id)
        {
            var productDelete = _productRepository.DeleteProductById(Id);

            if (productDelete)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

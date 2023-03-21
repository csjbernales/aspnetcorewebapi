using aspnetcorewebapi.Services.ProductsService;

using Microsoft.AspNetCore.Mvc;

namespace aspnetcorewebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices productsServices;

        public ProductsController(IProductsServices productsServices)
        {
            this.productsServices = productsServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(productsServices.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var result = productsServices.GetProduct(id);

            if (result.Id == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            var result = productsServices.AddProduct(product);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            var result = productsServices.UpdateProduct(product);

            if (result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var result = productsServices.DeleteProduct(id);

            if (result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
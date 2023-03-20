using Microsoft.AspNetCore.Mvc;

namespace aspnetcorewebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Nike", Type = ProductType.Shoe },
                new Product { Id = 2, Name = "Logitech", Type = ProductType.Camera },
                new Product { Id = 3, Name = "Samsung", Type = ProductType.Gadget },
            };

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = products.Find(x => x.Id == id);

            if (product is null)
            {
                return NotFound("Product does not exist");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            products.Add(product);

            return Ok(products);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            var updatedProduct = products.Find(x => x.Id == product.Id);


            if (product is null)
            {
                return NotFound("Product does not exist");
            }

            updatedProduct.Name = product.Name;
            updatedProduct.Type = product.Type;

            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = products.Find(x => x.Id == id);

            if (product is null)
            {
                return NotFound("Product does not exist");
            }

            products.Remove(product);

            return Ok(products);
        }
    }
}
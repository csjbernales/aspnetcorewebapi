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

        /// <summary>
        /// Get the complete list of all products
        /// </summary>
        /// <returns>A list of Products</returns>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(productsServices.GetAllProducts());
        }


        /// <summary>
        /// Gets a product by Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>A single product record</returns>
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


        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product">Product content</param>
        /// <returns>Updated list of products</returns>
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            var result = productsServices.AddProduct(product);

            return Ok(result);
        }


        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="product">Product content</param>
        /// <returns>Updated list of products</returns>
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

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Updated list of products</returns>
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
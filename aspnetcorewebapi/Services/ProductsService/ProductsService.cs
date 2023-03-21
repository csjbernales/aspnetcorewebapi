namespace aspnetcorewebapi.Services.ProductsService
{
    /// <summary>
    /// ProductService class
    /// </summary>
    public class ProductsService : IProductsServices
    {
        private List<Product> products = new()
        {
                new Product { Id = 1, Name = "Nike", Type = ProductType.Shoe },
                new Product { Id = 2, Name = "Logitech", Type = ProductType.Camera },
                new Product { Id = 3, Name = "Samsung", Type = ProductType.Gadget },
            };

        /// <summary>
        /// Get the complete list of all products
        /// </summary>
        /// <returns>A list of Products</returns>
        public List<Product> GetAllProducts()
        {
            return products;
        }

        /// <summary>
        /// Gets a product by Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>A single product record</returns>
        public Product GetProduct(int id)
        {
            var product = products.Find(x => x.Id == id);

            if (product is null)
            {
                return new Product();
            }

            return product;
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product">Product content</param>
        /// <returns>Updated list of products</returns>
        public List<Product> AddProduct(Product product)
        {
            products.Add(product);

            return products;
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="product">Product content</param>
        /// <returns>Updated list of products</returns>
        public List<Product> UpdateProduct(Product product)
        {
            var updatedProduct = products.Find(x => x.Id == product.Id);


            if (updatedProduct is null)
            {
                return Array.Empty<Product>().ToList();
            }

            updatedProduct.Name = product.Name;
            updatedProduct.Type = product.Type;

            return products;
        }


        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Updated list</returns>
        public List<Product> DeleteProduct(int id)
        {
            var product = products.Find(x => x.Id == id);

            if (product is null)
            {
                return Array.Empty<Product>().ToList();
            }

            products.Remove(product);

            return products;
        }
    }
}

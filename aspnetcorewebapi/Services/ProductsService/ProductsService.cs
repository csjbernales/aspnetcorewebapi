namespace aspnetcorewebapi.Services.ProductsService
{
    /// <summary>
    /// ProductService class
    /// </summary>
    public class ProductsService : IProductsServices
    {
        public readonly DataContext dataContext;

        public ProductsService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        /// <summary>
        /// Get the complete list of all products
        /// </summary>
        /// <returns>A list of Products</returns>
        public async Task<List<Product>> GetAllProducts()
        {
            var productList = await dataContext.Products.ToListAsync();
            return productList;
        }

        /// <summary>
        /// Gets a product by Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>A single product record</returns>
        public async Task<Product> GetProduct(int id)
        {
            var product = await dataContext.Products.FindAsync(id);

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
        public async Task<List<Product>> AddProduct(Product product)
        {
            dataContext.Products.Add(product);
            await dataContext.SaveChangesAsync();

            return await GetAllProducts();
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="product">Product content</param>
        /// <returns>Updated list of products</returns>
        public async Task<List<Product>> UpdateProduct(Product product)
        {
            var updatedProduct = await dataContext.Products.FindAsync(product.Id);


            if (updatedProduct is null)
            {
                return Array.Empty<Product>().ToList();
            }

            updatedProduct.Name = product.Name;
            updatedProduct.Type = product.Type;

            await dataContext.SaveChangesAsync();

            return await GetAllProducts();
        }


        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Updated list</returns>
        public async Task<List<Product>> DeleteProduct(int id)
        {
            var product = await dataContext.Products.FindAsync(id);

            if (product is null)
            {
                return Array.Empty<Product>().ToList();
            }

            dataContext.Products.Remove(product);
            await dataContext.SaveChangesAsync();

            return await GetAllProducts();
        }
    }
}

namespace aspnetcorewebapi.Services.ProductsService
{
    public interface IProductsServices
    {

        Task<Product> GetProduct(int id);

        Task<List<Product>> AddProduct(Product product);

        Task<List<Product>> UpdateProduct(Product product);

        Task<List<Product>> DeleteProduct(int id);
        Task<List<Product>> GetAllProducts();
    }
}
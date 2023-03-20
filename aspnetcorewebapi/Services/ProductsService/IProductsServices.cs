namespace aspnetcorewebapi.Services.ProductsService
{
    public interface IProductsServices
    {
        List<Product> GetAllProducts();

        Product GetProduct(int id);

        List<Product> AddProduct(Product product);

        List<Product> UpdateProduct(Product product);

        List<Product> UpdateProduct(int id);
    }
}
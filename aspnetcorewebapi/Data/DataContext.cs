global using Microsoft.EntityFrameworkCore;

namespace aspnetcorewebapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=laptop-nonps;Database=productsdb;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public DbSet<Product> Products { get; set; }
    }
}

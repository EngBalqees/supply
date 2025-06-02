using Microsoft.EntityFrameworkCore;
namespace supply.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<InvoiceItem> InvoiceItem { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}

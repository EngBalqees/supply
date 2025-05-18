using Microsoft.EntityFrameworkCore;
namespace supply.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Supplier> Supplier { get; set; }

       
    }
}

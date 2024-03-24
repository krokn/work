using Microsoft.EntityFrameworkCore;
using test.Entity;

namespace test.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options)
         {


         }
         public DbSet<Item> items { get; set; }

         public DbSet<User> users { get; set; }
    }
}

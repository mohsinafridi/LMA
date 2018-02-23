using Microsoft.EntityFrameworkCore;

namespace LMA.Data.Model
{
    public class LMADbContext :DbContext
    {
        public LMADbContext(DbContextOptions<LMADbContext> option) : base(option)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Cusotmers{ get; set; }
    }
}

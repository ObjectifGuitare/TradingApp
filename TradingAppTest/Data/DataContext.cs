using Microsoft.EntityFrameworkCore;
/*using Microsoft.AspNetCore.Identity.EntityFrameworkCore;*/
using Microsoft.EntityFrameworkCore.Design;

namespace TradingAppTest.Data
{
        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options) { }

            /*protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.UseIdentityColumns();
                base.OnModelCreating(modelBuilder);
            }*/
            public DbSet<User> users { get; set; }
            public DbSet<Profile> profiles { get; set; }
            public DbSet<Trade> trades { get; set; }
            public DbSet<Wire> wires { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLink> OrderLink { get; set; }

        #region override functions

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //below line to remove error while creating identity
            base.OnModelCreating(modelBuilder);
            //end
        }

        #endregion
    }
}

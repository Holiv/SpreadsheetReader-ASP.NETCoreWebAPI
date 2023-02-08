using Microsoft.EntityFrameworkCore;
using SpreadSheetReader.Models;

namespace SpreadSheetReader.Data
{
    public class OrdersDbContext: DbContext
    {
        public OrdersDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}

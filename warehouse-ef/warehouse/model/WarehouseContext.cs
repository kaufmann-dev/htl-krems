using Microsoft.EntityFrameworkCore;

namespace warehouse.model
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        {
            
        }
        
        public DbSet<Dish> dishes { get; set; }
    }
}
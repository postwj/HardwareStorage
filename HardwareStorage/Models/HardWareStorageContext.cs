using Microsoft.EntityFrameworkCore;

namespace HardwareStorage.Models
{
    public class HardWareStorageContext : DbContext
    {
        public HardWareStorageContext(DbContextOptions<HardWareStorageContext> options) 
        : base(options)
        {   
        }

        public DbSet<HardwareItem> Items { get; set; } = null;
    }
}

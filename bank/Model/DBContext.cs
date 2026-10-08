using Microsoft.EntityFrameworkCore;

namespace bank.Model
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) :base (options)
            
         { }
        public DbSet<Bank> bank { get; set; }
    }
}

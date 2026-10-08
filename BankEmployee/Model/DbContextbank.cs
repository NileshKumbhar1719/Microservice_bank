using Microsoft.EntityFrameworkCore;

namespace BankEmployee.Model
{
    public class DbContextbank : DbContext
    {
        public DbContextbank(DbContextOptions<DbContextbank> options): base(options) 
        {
            
        }
        public DbSet<Employees> employees { get; set; }
    }
}

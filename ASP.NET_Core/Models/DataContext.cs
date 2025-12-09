using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Test> News { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace EFCore.Models
{
	public class PContext:DbContext
	{
        public PContext(DbContextOptions<PContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}

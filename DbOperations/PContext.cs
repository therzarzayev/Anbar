using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.DbOperations
{
    public class PContext : DbContext
    {
        public PContext(DbContextOptions<PContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using LinkAggregation.Models;

namespace DataAccess.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<HyperLink> HyperLink { get; set; }
    }
}

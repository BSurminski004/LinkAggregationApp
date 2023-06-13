using LinkAggregation.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkAggregator.DataAccess.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<HyperLink> HyperLink { get; set; }
        public DbSet<Statistic> Statistic { get; set; }
    }
}

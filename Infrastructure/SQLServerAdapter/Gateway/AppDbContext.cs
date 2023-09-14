using College.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.Infrastructure.SQLServerAdapter.Gateway
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
using College.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.Infrastructure.SQLServerAdapter.Gateway
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectEnrollments> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la entidad sin clave para SubjectEnrollments
            modelBuilder.Entity<SubjectEnrollments>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}
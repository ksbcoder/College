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
        public DbSet<SubjectEnrollment> SubjectEnrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la clave foranea de Subject - Teacher
            modelBuilder.Entity<Subject>()
                        .HasOne(s => s.Teacher)
                        .WithMany()
                        .HasForeignKey(s => s.TeacherID);

            // Configurar la entidad sin clave para SubjectEnrollments y FKs
            modelBuilder.Entity<SubjectEnrollment>()
                        .HasKey(se => se.EnrollmentID); // Clave compuesta

            modelBuilder.Entity<SubjectEnrollment>()
                        .HasOne(se => se.Subject)
                        .WithMany()
                        .HasForeignKey(se => se.SubjectCode);

            modelBuilder.Entity<SubjectEnrollment>()
                        .HasOne(se => se.Student)
                        .WithMany()
                        .HasForeignKey(se => se.StudentID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
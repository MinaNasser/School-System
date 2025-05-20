using Microsoft.EntityFrameworkCore;
using School.DAL.Configurations;
using School.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace School.DAL
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new StudentSubjectConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

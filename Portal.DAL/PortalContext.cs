using Microsoft.EntityFrameworkCore;
using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL
{
    public class PortalContext : DbContext
    {
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=HUSSAIN\\SQLEXPRESS; Initial Catalog=New_EIMS_DB; Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<TeacherCourse>()
            //.HasKey(bc => new { bc.TeacherId, bc.CourseId });

            //modelBuilder.Entity<TeacherCourse>()
            //    .HasOne(bc => bc.Teacher)
            //    .WithMany(b => b.TeacherCourses)
            //    .HasForeignKey(bc => bc.TeacherId).OnDelete(DeleteBehavior.Cascade); ;

            //modelBuilder.Entity<TeacherCourse>()
            //    .HasOne(bc => bc.Courses)
            //    .WithMany(c => c.TeacherCourses)
            //    .HasForeignKey(bc => bc.CourseId).OnDelete(DeleteBehavior.Cascade); ;


            //modelBuilder.Entity<StudentCourse>()
            //.HasKey(bc => new { bc.StudentId, bc.CourseId });

            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne(bc => bc.Student)
            //    .WithMany(b => b.StudentCourses)
            //    .HasForeignKey(bc => bc.StudentId).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne(bc => bc.Courses)
            //    .WithMany(c => c.StudentCourses)
            //    .HasForeignKey(bc => bc.CourseId).OnDelete(DeleteBehavior.Cascade);
            //    ;


        }
    }
}

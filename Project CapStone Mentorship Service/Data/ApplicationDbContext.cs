using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_CapStone_Mentorship_Service.Models;

namespace Project_CapStone_Mentorship_Service.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<StudentMentor> Junctions { get; set; }
        public DbSet<LessonOverView> Lessons { get; set; }
        public DbSet<ActivityForm> Activities { get; set; }
        public DbSet<ReviewForm>  Reviews {get; set;}
        public DbSet<ApplicationForm> Applications { get; set; }
        public DbSet<Sign_UpForm> Forms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Student", NormalizedName = "STUDENT" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Mentor", NormalizedName = "MENTOR" });
        }
    }

}

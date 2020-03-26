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

     

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Student", NormalizedName = "STUDENT" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Mentor", NormalizedName = "MENTOR" });
        }
    }

}

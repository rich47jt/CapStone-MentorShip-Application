using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Project_CapStone_Mentorship_Service.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Parent_Email { get; set; }
        public string Instructor_Email { get; set; }
        public string City { get; set; }

        

        [ForeignKey("IdentityUser")]
        public int IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; } 

        [ForeignKey("Sign_UpForm")]
        public int Sign_FormId { get; set; }
        public Sign_UpForm Form { get; set; }


    }
}

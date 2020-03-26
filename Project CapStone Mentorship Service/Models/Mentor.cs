using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Project_CapStone_Mentorship_Service.Models
{
    public class Mentor
    {
        [Key]
        public int MentorId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Subject_Specialty { get; set; }
        public string Description { get; set; }
   
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }


        [ForeignKey("ApplicationForm")]
        public int ApplicantFromId { get; set; }
        public ApplicationForm applicationForm { get; set; }




    }

}

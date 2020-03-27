using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Project_CapStone_Mentorship_Service.Models;

namespace Project_CapStone_Mentorship_Service.Views
{
    public class MentorCreateViewModel
    {

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Subject_Specialty { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("ApplicationForm")]
        public int ApplicantFromId { get; set; }
        public ApplicationForm applicationForm { get; set; }

    }
       
}

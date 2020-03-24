using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CapStone_Mentorship_Service.Models
{
    public class ApplicationForm
    {
        [Key]
        public int ApplicationId { get; set; }
        public string ApplicantName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public string EducationalBackGround { get; set; }
        public string References { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsApproved { get; set; }

        [ForeignKey("Mentor")]

        public int MentorId { get; set; }
        public Mentor Mentor { get; set;  }

        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public Admin admin { get; set; }
    }
}

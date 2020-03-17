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
        public int Id { get; set; }
        public string ApplicantName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string DesiredPosition { get; set; }
        public bool Voulenteer { get; set; }
        public string PersonalDescription { get; set; }
        public string EducationalBackRound { get; set; }
        public string References { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Approval { get; set; }

        [ForeignKey("Mentor")]

        public int MentorId { get; set; }
    }
}

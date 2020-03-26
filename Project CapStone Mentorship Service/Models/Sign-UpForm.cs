using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CapStone_Mentorship_Service.Models
{
    public class Sign_UpForm
    {
        [Key]

        public int FormId { get; set; }
        public string StudentName { get; set; }
        public string TypeofTutor { get; set; }
        public string Description { get; set; }
        public string TutorName { get; set; }
        public bool IsApptoved { get;  set; }

        [ForeignKey("Mentor")]
        public int MentorId { get; set; }
        public Mentor mentor { get; set; }

        [ForeignKey("Studnet")]

        public int StudentId { get; set; }
        public Student student { get; set; }
    }
}

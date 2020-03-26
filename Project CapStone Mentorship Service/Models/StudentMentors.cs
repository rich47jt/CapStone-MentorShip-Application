using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CapStone_Mentorship_Service.Models
{
    public class StudentMentors
    {
        [Key]
        public int StudentMentorId { get; set; }

        [ForeignKey("Student")]

        public int StudentId { get; set; }

        public Student student { get; set; }

        [ForeignKey("Mentor")]

        public int MentorId { get; set; }

        public Mentor mentor { get; set; }


    }
}

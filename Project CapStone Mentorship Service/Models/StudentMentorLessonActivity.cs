 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CapStone_Mentorship_Service.Models
{
    public class StudentMentorLessonActivity
    {
        [Key]
        public int StudentMentorLessonActivityId { get; set; }

        [ForeignKey("StudentMentors")]
         
        public int StudentMentorId { get; set; }

        public StudentMentor studentMentor { get; set; }

        [ForeignKey("LessonActivites")]

        public int LessonActivity { get; set; }

        public LessonActivity lessonActivity { get; set; }



    }
}

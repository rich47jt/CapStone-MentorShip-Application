using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CapStone_Mentorship_Service.Models
{
    public class StudentMentor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Mentor")]

        public int MentorId { get; set; }
        public Mentor mentor { get; set; }

        [ForeignKey("Studnet")]

        public int StudentId { get; set; }
        public Student student { get; set; }

        [ForeignKey("LessonOverView")]
        public int LessonId { get; set; }
        public LessonOverView Lesson { get; set; }

        [ForeignKey("ActivityForm")]
        public int ActivityId { get; set; }
        public ActivityForm activity { get; set; }

        [ForeignKey("ReviewForm")]
        public int ReviewId { get; set; }
        public ReviewForm Review { get; set; }
    }
}

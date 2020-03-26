using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CapStone_Mentorship_Service.Models
{
    public class StudentMentorLessonActivities
    {
        [Key]
        public int StudentMentorLessonActivitiesId { get; set; }

        [ForeignKey("StudentMentors")]

        public int StudentMentorId { get; set; }

        public StudentMentors studentMentors { get; set; }

        [ForeignKey("LessonActivites")]

        public int LessonActivites { get; set; }

        public LessonActivities lessonActivities { get; set; }



    }
}

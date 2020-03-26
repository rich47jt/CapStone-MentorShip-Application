using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CapStone_Mentorship_Service.Models
{
    public class LessonActivity
    {
        [Key]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public  string Description { get; set; }
        public string Type { get; set; }



    }
}

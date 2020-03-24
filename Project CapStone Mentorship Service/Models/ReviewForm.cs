﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CapStone_Mentorship_Service.Models
{
    public class ReviewForm
    {
        [Key]
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string MentorName { get; set; }

        
    }
}

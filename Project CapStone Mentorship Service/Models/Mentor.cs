﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Project_CapStone_Mentorship_Service.Models
{
        public class Mentor
        {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string City { get; set; }
            public string Education { get; set; }
            public string EducationalExperinece { get; set; }

            [ForeignKey("IdentityUser")]
            public string IdentityUserId { get; set; }
            public IdentityUser IdentityUser { get; set; }
        }
    
}
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

        public int FormId { get; set;  }
        public string Studnet_Name { get; set; }
        public string Need_for_Academic_Help { get; set; }
        public string Mentor_Name { get; set; }
        public bool IsTutor { get; set; }



    }
}

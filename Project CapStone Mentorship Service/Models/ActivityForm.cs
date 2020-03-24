using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CapStone_Mentorship_Service.Models
{
    public class ActivityForm
    {
        [Key]
        public int ActivityFormId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public string StudentName { get; set; }

        

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Teach
    {
    	[Display(Name = "课程号")]
        public int ID { get; set; }
        public virtual Teacher Tch { get; set; }
        public virtual Lesson Crs { get; set; }
    }
}

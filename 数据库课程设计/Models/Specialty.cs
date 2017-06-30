using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Specialty
    {
    	[Display(Name = "专业编号")]
        public int Id { get; set; }
        [Display(Name = "专业")]
        public string Name { get; set; } 
        public virtual Collage Belongs { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Collage
    {
    	[Display(Name = "学院号")]
        public int Id { get; set; }
        [Display(Name = "学院名")]
        public string Name { get; set; }
        public virtual ICollection<Specialty> Specialtys { get; set; }
    }
}

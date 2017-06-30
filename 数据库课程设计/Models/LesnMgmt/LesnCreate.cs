using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.LesnMgmt
{
    public class LesnCreate
    {
        [Required]
        [Display(Name = "课程名")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "学时")]
        public int Hour { get; set; }
        [Required]
        [Display(Name = "学分")]
        public int Credit { get; set; }
        [Required]
        [Display(Name = "所属专业")]
        public String SpecialtyName { get; set; }
    }
}

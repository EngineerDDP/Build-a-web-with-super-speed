using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.StudentMgmt
{
    public class StuCreate
    {
        [Required]
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "性别")]
        public String Sex { get; set; }
        [Required]
        [Display(Name = "专业")]
        public String SpecialtyName { get; set; }
    }
}

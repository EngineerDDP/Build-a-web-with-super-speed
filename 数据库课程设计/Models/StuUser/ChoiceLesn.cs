using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.StuUser
{
    public class ChoiceLesn
    {
        [Required]
        [Display(Name = "学号")]
        public int id { get; set; }
        [Required]
        [Display(Name = "课程名")]
        public String LessonName { get; set; }
    }
}

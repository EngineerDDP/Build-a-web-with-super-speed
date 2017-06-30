using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.TchrMgmt
{
    public class TchCreate
    {
        [Required]
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "性别")]
        public String Sex { get; set; }
        [Required]
        [Display(Name = "工资")]
        public int Salary { get; set; }
        [Required]
        [Display(Name = "所属学院")]
        public String CollegeName { get; set; }
    }
}

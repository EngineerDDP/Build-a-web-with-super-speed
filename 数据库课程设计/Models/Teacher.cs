using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Teacher
    {
        [Display(Name = "职工号")]
        public int Id { get; set; }
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Display(Name = "性别")]
        public string Sex { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "工资")]
        public int Salary { get; set; }
        public virtual Specialty Belongs { get; set; }
        public virtual ICollection<Teach> Lessons { get; set; }
    }
}

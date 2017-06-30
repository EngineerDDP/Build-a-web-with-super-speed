using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Lesson
    {
        [Display(Name = "课程号")]
        public int Id { get; set; }
        [Display(Name = "课程名")]
        public string Name { get; set; }
        [Display(Name = "学时")]
        public int Hour { get; set; }
        [Display(Name = "学分")]
        public int Credit { get; set; }
        public virtual Specialty Belongs { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
        public virtual ICollection<Teach> Teachers { get; set; }
    }
}

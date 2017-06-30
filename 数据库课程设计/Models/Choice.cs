using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Choice
    {
    	[Display(Name = "课程号")]
        public int ID { get; set; }
        [Display(Name = "成绩")]
        public int Score { get; set; }
        public virtual Lesson Take { get; set; }
        public virtual Student Stu { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Student
    {	
    	[Display(Name = "学号")]
        public int ID { get; set; }
        [Display(Name = "姓名")]
        public String Name { get; set; }
        
        [Display(Name = "性别")]
        public String Sex { get; set; }
        [DataType(DataType.Password)]
        public String Password { get; set; }
        public virtual Specialty belongs { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class TchLoginViewModel
    {
        [Required]
        [Display(Name = "教工号")]
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public String Password { get; set; }
    }
}

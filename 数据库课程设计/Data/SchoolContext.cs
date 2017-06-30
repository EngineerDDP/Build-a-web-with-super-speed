using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }
        public DbSet<SchoolManagement.Models.Teacher> Teacher { get; set; }
        public DbSet<SchoolManagement.Models.Lesson> Lesson { get; set; }
        public DbSet<SchoolManagement.Models.Student> Student { get; set; }
        public DbSet<SchoolManagement.Models.Collage> Collage { get; set; }
        public DbSet<SchoolManagement.Models.Specialty> Specialty { get; set; }
    }
}

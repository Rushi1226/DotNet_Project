using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_MiniProject.Models
{
    class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDuration { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}

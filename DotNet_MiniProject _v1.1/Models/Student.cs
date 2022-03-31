using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace DotNet_MiniProject.Models
{
    class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }

       public virtual ICollection<Course> Courses { get; set; }


        public override string ToString()
        {
            return $"StudentName: {StudentName}, DateOfBirth: {DateOfBirth}, Email: {Email}, Location: {Location}, Gender: {Gender}, ContactNo: {ContactNo} ";
        }
    }
}

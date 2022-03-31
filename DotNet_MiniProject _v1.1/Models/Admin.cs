using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet_MiniProject.Models
{
    class Admin
    {
       [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
    }
}

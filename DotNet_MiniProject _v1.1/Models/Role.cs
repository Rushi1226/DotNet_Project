using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_MiniProject.Models
{
    class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Roles { get; set; }
    }
}

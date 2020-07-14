using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SDSDPms.Models
{
    public class Resource : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Department")]
        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

       [Display(Name = "Photo")]

        public string PhotoUrl { get; set; }
    }
}

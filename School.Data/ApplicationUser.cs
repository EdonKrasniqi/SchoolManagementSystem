using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ParentName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PlaceOfBirth { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public char Sex { get; set; }
        [Required]
        public int Student_ID { get; set; }
        [Required]
        public int ID_Number { get; set; }
    }
}

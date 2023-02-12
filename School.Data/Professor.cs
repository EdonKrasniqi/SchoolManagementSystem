using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Professor
    {
        public int Id { get; set; }
        [Required]
        public string Professor_Id { get; set; }
        public int? Course_Id { get; set; }
        [ForeignKey("Course_Id")]
        [ValidateNever]
        public Course Course { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [Display(Name = "Subjects")]
        public List<int> SubjectIds { get; set; } = new List<int>();
    }
}

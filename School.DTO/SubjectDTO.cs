using System.ComponentModel.DataAnnotations;

namespace School.DTOs
{
    public class SubjectDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Subject name is required")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}

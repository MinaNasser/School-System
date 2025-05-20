using System;
using System.Collections.Generic;

namespace School.DTOs
{
    public class StudentDetailsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public List<string> SubjectNames { get; set; } = new List<string>();
    }
}

using School.DTOs;
using School.Entities;

namespace School.Services.Mappers
{
    public static class StudentMapper
    {
        public static StudentDetailsDTO ToDetailsDto(this Student student)
        {
            return new StudentDetailsDTO
            {
                Id = student.Id,
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                SubjectNames = student.StudentSubjects
                                   .Select(ss => ss.Subject?.Name)
                                   .Where(name => name != null)
                                   .ToList()
            };
        }

        public static Student ToEntity(this StudentDTO dto)
        {
            return new Student
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                DateOfBirth = dto.DateOfBirth,
                StudentSubjects = dto.SubjectIds
                    .Select(id => new StudentSubject { SubjectId = id })
                    .ToList()
            };
        }
    }
}

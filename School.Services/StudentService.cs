using School.Entities;
using School.Repositories.Interfaces;
using School.Services.Interfaces;
using School.DTOs;

namespace School.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(StudentDTO dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Address = dto.Address,
                DateOfBirth = dto.DateOfBirth,
                StudentSubjects = dto.SubjectIds
                    .Select(subjectId => new StudentSubject
                    {
                        SubjectId = subjectId
                    }).ToList()
            };

            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Students.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAsync(Student student)
        {
            await _unitOfWork.Students.DeleteAsync(student);
            await _unitOfWork.SaveAsync();
        }
        public async Task<List<StudentDetailsDTO>> GetAllAsync()
        {
            var students = await _unitOfWork.Students.GetAllAsync();

            return students.Select(s => new StudentDetailsDTO
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                DateOfBirth = s.DateOfBirth,
                SubjectNames = s.StudentSubjects
                    .Select(ss => ss.Subject?.Name)
                    .Where(name => name != null)
                    .ToList()
            }).ToList();
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if (student == null) return null;

            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address,
                DateOfBirth = student.DateOfBirth,
                SubjectIds = student.StudentSubjects
                    .Select(ss => ss.SubjectId)
                    .ToList()
            };
        }

        public async Task UpdateAsync(StudentDTO dto)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(dto.Id);
            if (student == null) return;

            student.Name = dto.Name;
            student.Address = dto.Address;
            student.DateOfBirth = dto.DateOfBirth;

            student.StudentSubjects.Clear();
            foreach (var subjectId in dto.SubjectIds)
            {
                student.StudentSubjects.Add(new StudentSubject
                {
                    SubjectId = subjectId
                });
            }

            await _unitOfWork.Students.UpdateAsync(student);
            await _unitOfWork.SaveAsync();
        }
    }
}

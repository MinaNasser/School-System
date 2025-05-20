using School.Entities;
using School.Repositories.Interfaces;
using School.Services.Interfaces;

namespace School.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;


        public StudentService(IUnitOfWork work)
        {
            _unitOfWork = work;
        }
        public async Task AddAsync(Student student, List<int> subjectIds)
        {
            student.StudentSubjects = subjectIds
                .Select(subjectId => new StudentSubject
                {
                    StudentId = student.Id,
                    SubjectId = subjectId
                }).ToList();
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

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _unitOfWork.Students.GetAllAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _unitOfWork.Students.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Student student, List<int> subjectIds)
        {
            var existingStudent = await _unitOfWork.Students.GetByIdAsync(student.Id);
            if (existingStudent == null) return;

            existingStudent.Name = student.Name;
            existingStudent.Address = student.Address;
            existingStudent.DateOfBirth = student.DateOfBirth;


            existingStudent.StudentSubjects.Clear();

            foreach (var subjectId in subjectIds)
            {
                existingStudent.StudentSubjects.Add(new StudentSubject
                {
                    StudentId = student.Id,
                    SubjectId = subjectId
                });
            }
            await _unitOfWork.Students.UpdateAsync(existingStudent);
            await _unitOfWork.SaveAsync();
        }
    }
}

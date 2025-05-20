using School.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student, List<int> subjectIds);
        Task UpdateAsync(Student student, List<int> subjectIds);
        Task DeleteAsync(int id);
        Task DeleteAsync(Student student);
    }
}

using School.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<SubjectDTO>> GetAllAsync();
        Task<SubjectDTO> GetByIdAsync(int id);
        Task AddAsync(SubjectDTO dto);
        Task UpdateAsync(SubjectDTO dto);
        Task DeleteAsync(int id);
    }
}

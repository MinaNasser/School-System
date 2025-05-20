using School.DTOs;
using School.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDetailsDTO>> GetAllAsync();            
        Task<StudentDTO> GetByIdAsync(int id);                  
        Task AddAsync(StudentDTO dto);                         
        Task UpdateAsync(StudentDTO dto);                   
        Task DeleteAsync(int id);
        Task DeleteAsync(Student student);
    }
}

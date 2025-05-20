using School.DTOs;
using School.Entities;
using School.Repositories.Interfaces;
using School.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SubjectDTO>> GetAllAsync()
        {
            var subjects = await _unitOfWork.Subjects.GetAllAsync();

            return subjects.Select(s => new SubjectDTO
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
        }
        public async Task<SubjectDTO> GetByIdAsync(int id)
        {
            var subject = await _unitOfWork.Subjects.GetByIdAsync(id);
            if (subject == null) return null;

            return new SubjectDTO
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }
        public async Task AddAsync(SubjectDTO dto)
        {
            var subject = new Subject
            {
                Name = dto.Name
            };

            await _unitOfWork.Subjects.AddAsync(subject);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(SubjectDTO dto)
        {
            var subject = await _unitOfWork.Subjects.GetByIdAsync(dto.Id);
            if (subject == null) return;

            subject.Name = dto.Name;

            _unitOfWork.Subjects.UpdateAsync(subject);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var subject = await _unitOfWork.Subjects.GetByIdAsync(id);
            if (subject == null) return;

            _unitOfWork.Subjects.DeleteAsync(subject);
            await _unitOfWork.SaveAsync();
        }
    }
}

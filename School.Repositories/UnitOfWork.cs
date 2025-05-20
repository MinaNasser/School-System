using School.DAL;
using School.Entities;
using School.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace School.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext _context;

        public IRepository<Student> Students { get; }
        public IRepository<Subject> Subjects { get; }
        public IRepository<StudentSubject> StudentSubjects { get; }

        public UnitOfWork(
            SchoolDbContext context,
            IRepository<Student> students,
            IRepository<Subject> subjects,
            IRepository<StudentSubject> studentSubjects)
        {
            _context = context;
            Students = students;
            Subjects = subjects;
            StudentSubjects = studentSubjects;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
// This class implements the unit of work pattern, managing the lifecycle of the database context and repositories.
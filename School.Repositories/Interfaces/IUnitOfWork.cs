using School.Entities;


namespace School.Repositories.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {

        IRepository<Student> Students { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<StudentSubject> StudentSubjects { get; }
        Task<int> SaveAsync();

    }
}
// This interface defines a unit of work pattern for managing transactions and repositories.


namespace School.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}

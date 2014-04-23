namespace StudentSystem.Data.Repositories
{
    using StudentSystem.Model;
    using System.Linq;

    public class StudentsRepository : GenericRepository<Student>, IRepository<Student>
    {
        public StudentsRepository(IStudentSystemDbContext context)
            : base(context)
        {
        }

        public IQueryable<Student> Assistants()
        {
            return this.All().Where(st => st.Trainees.Count() > 0);
        }
    }
}

namespace StudentSystem.Data
{
    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;

    public interface IStudentSystemData
    {
        IRepository<Course> Courses 
        {
            get; 
        }

        IRepository<Homework> Homeworks
        {
            get;
        }

        StudentsRepository Students
        {
            get;
        }

        void SaveChanges();
    }
}

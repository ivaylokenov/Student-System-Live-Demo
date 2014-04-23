namespace StudentSystem.Data
{
    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;
    using System;
    using System.Collections.Generic;

    public class StudentSystemData : IStudentSystemData
    {
        private readonly IStudentSystemDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public StudentSystemData()
            : this(new StudentSystemDbContext())
        {
        }

        public StudentSystemData(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public IRepository<Homework> Homeworks
        {
            get
            {
                return this.GetRepository<Homework>();
            }
        }

        public StudentsRepository Students
        {
            get
            {
                return (StudentsRepository)this.GetRepository<Student>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var repositoryType = typeof(T);

            if (!this.repositories.ContainsKey(repositoryType))
            {
                var type = typeof(GenericRepository<T>);

                if (repositoryType.IsAssignableFrom(typeof(Student)))
                {
                    type = typeof(StudentsRepository);
                }

                this.repositories.Add(repositoryType, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[repositoryType];
        }
    }
}

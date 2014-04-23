namespace StudentSystem.Data
{
    using StudentSystem.Data.Configurations;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Model;
    using System.Data.Entity;

    public class StudentSystemDbContext : DbContext, IStudentSystemDbContext
    {
        public StudentSystemDbContext()
            : base("StudentSystemDbConnection")
        {
            Database.SetInitializer<StudentSystemDbContext>(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .Property(pr => pr.LastName)
                .HasMaxLength(20);

            modelBuilder.Configurations.Add(new CourseConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}

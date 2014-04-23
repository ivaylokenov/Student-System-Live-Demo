namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Model;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            var student = new Student
            {
                FirstName = "Ivaylo",
                LastName = "Kenov",
                Information = new StudentInfo()
            };

            student.Trainees.Add(new Student
            {
                FirstName = "Teodor",
                LastName = "Kurtev",
                Information = new StudentInfo()
            });

            context.Students.Add(student);
        }

        private void SeedCourses(StudentSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            var course = new Course { Name = "Code First", Description = "Entity Framework Rocks" };

            context.Courses.Add(course);
        }
    }
}

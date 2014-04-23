namespace StudentSystem.Data.Configurations
{
    using StudentSystem.Model;
    using System.Data.Entity.ModelConfiguration;

    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            this.Property(pr => pr.Description).IsUnicode();
        }
    }
}

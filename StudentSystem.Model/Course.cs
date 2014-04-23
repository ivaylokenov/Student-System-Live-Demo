namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CourseInstance")]
    public class Course
    {
        public Course()
        {
            this.Id = Guid.NewGuid();
            this.Students = new HashSet<Student>();
            this.Homeworks = new HashSet<Homework>();
        }

        [Key]
        public Guid Id { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}

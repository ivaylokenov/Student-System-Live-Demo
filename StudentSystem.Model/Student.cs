namespace StudentSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
            this.Trainees = new HashSet<Student>();
            this.Information = new StudentInfo();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MinLength(3)]
        public string LastName { get; set; }

        [Column("Number")]
        public long StudentNumber { get; set; }

        public virtual Student Assistant { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        [InverseProperty("Assistant")]
        public virtual ICollection<Student> Trainees { get; set; }

        public StudentInfo Information { get; set; }

        [NotMapped]
        public bool IsAssistant
        {
            get
            {
                return this.Trainees.Count > 0;
            }
        }
    }
}

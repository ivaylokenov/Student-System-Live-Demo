namespace StudentSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        [Key]
        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        [ForeignKey("Student")]
        public int StudentInstanceId { get; set; }

        public virtual Student Student { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }

        [NotMapped]
        public TimeSpan TimespanSinceReceived
        {
            get
            {
                return DateTime.Now - this.TimeSent;
            }
        }
    }
}

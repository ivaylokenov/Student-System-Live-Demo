namespace StudentSystem.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class StudentInfo
    {
        [Column("Address")]
        public string Address { get; set; }

        [Column("Email")]
        public string Email { get; set; }
    }
}

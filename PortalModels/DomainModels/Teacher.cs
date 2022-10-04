using System.ComponentModel.DataAnnotations;
namespace PortalModels.DomainModels
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string TeacherCode { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool? IsPermanent { get; set; }

        public int QualificationId { get; set; }
        public virtual Qualification Qualification { get; set; }

    }
}

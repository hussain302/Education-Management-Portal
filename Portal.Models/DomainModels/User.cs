using System.ComponentModel.DataAnnotations;

namespace Portal.Models.DomainModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string SecurityQuestion { get; set; }
        [Required]
        public string SecurityAnswer { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}

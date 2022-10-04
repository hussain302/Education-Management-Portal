using System.ComponentModel.DataAnnotations;

namespace PortalModels.WebModels
{
    public class UserModel
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
        public virtual RoleModel Role { get; set; }
        public bool IsApproved { get; set; }

    }
}

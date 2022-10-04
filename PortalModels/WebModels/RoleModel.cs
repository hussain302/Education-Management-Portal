using System.ComponentModel.DataAnnotations;

namespace PortalModels.WebModels
{
    public class RoleModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

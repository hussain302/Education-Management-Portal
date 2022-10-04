using System.ComponentModel.DataAnnotations;

namespace PortalModels.DomainModels
{
    public class Program
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PortalModels.WebModels
{
    public class ProgramModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        public virtual DepartmentModel Department { get; set; }
    }
}

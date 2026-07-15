using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        [StringLength(100)]
        public string PermissionCode { get; set; }

        [Required]
        [StringLength(150)]
        public string PermissionName { get; set; }

        [StringLength(100)]
        public string ModuleName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
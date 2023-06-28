using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [ForeignKey("ApplicationRole")]
        public Guid ApplicationRoleId { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Url]
        [MaxLength(4000)]
        public string RoleLogoUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        /* Relationships */

        //to 1
        public Guid CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [ForeignKey("RoleCreatedBy")]
        public Guid? RoleCreatedById { get; set; }
        public Person RoleCreatedBy { get; set; }

        [ForeignKey("RoleUpdatedBy")]
        public Guid? RoleUpdatedById { get; set; }
        public Person RoleUpdatedBy { get; set; }

        //to *
        public virtual ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();

        [InverseProperty("PersonRoles")]
        public virtual ICollection<Person> RoleMembers { get; set; } = new List<Person>();
    }
}

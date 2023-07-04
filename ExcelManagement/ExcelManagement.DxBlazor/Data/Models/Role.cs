using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [ForeignKey("ApplicationRole")]
        public string RoleId { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Url]
        [MaxLength(4000)]
        public string RoleLogoUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        /* Relationships */

        //to 1
        [ForeignKey("CompanyId")]
        public Guid? CompanyId { get; set; }
        [Required]
        public Company Company { get; set; }

        //CreatedBy / UpdatedBy
        public string? RoleCreatedById { get; set; }
        public Person RoleCreatedBy { get; set; }

        public string? RoleUpdatedById { get; set; }
        public Person RoleUpdatedBy { get; set; }

        //to *
        [NotMapped]
        public virtual ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();
        [NotMapped]
        public virtual ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}

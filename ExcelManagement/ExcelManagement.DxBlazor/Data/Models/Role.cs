using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string RoleName { get; set; }

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
        public ApplicationRole ApplicationRole { get; set; }

        [Required]
        public Company Company { get; set; }

        //CreatedBy / UpdatedBy
        public Person? CreatedBy { get; set; }
        public Person? UpdatedBy { get; set; }

        //to *
        public virtual ICollection<Person> Persons { get; set; } = new List<Person>();
        public virtual ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();
    }
}

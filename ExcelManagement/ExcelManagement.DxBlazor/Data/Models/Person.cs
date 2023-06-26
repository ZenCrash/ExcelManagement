using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExcelManagement.DxBlazor.Data;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string? JobTitle { get; set; }

        [StringLength(4000)]
        public string? Bio { get; set; }

        [Url]
        [MaxLength(4000)]
        public string? ProfileImageUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        //Relations

        //to 1
        [ForeignKey("ApplicationUser")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Company")]
        public Guid? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("Person")]
        public Guid? CreatedByPersonId { get; set; }
        public Person CreatedByPerson { get; set; }

        [ForeignKey("Person")]
        public Guid? UpdatedByPersonId { get; set; }
        public Person UpdatedByPerson { get; set; }

        //to many
        public ICollection<Role> Roles { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<FileAndFolder> FilesAndFolders { get; set; }

    }
}

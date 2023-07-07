using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("Groups")]
    public class Group
    {
        [Key]
        public Guid GroupId { get; set; }

        [Required]
        [MaxLength(512)]
        public string GroupName { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Url]
        [MaxLength(4000)]
        public string GroupLogoUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        /* Relationships */

        //Self Eefrence

        //to 1
        [ForeignKey("CompanyId")]
        public Guid? CompanyId { get; set; }
        [Required]
        public Company Company { get; set; }

        //CreatedBy / UpdatedBy
        public string? GroupCreatedById { get; set; }
        public Person GroupCreatedBy { get; set; }

        public string? GroupUpdatedById { get; set; }
        public Person GroupUpdatedBy { get; set; }

        //to *
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
        public virtual ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();
        [NotMapped]
        public virtual ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}

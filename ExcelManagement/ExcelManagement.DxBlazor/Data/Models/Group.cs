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
        public Guid Id { get; set; }

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

        /* Relationships */

        //Self Eefrence

        //to 1
        public Guid CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [ForeignKey("GroupCreatedBy")]
        public Guid? GroupCreatedById { get; set; }
        public Person GroupCreatedBy { get; set; }

        [ForeignKey("GroupUpdatedBy")]
        public Guid? GroupUpdatedById { get; set; }
        public Person GroupUpdatedBy { get; set; }

        //to *
        public virtual ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();

        [InverseProperty("PersonGroups")]
        public virtual ICollection<Person> GroupMembers { get; set; } = new List<Person>();

        //public ICollection<FileAndFolder> FilesAndFolders { get; set; } = new List<FileAndFolder>();

        //[InverseProperty("Groups")]
        //public ICollection<Person> GroupMembers { get; set; } = new List<Person>();

    }
}

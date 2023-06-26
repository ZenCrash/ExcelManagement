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

        // Relationships
        //to 1
        [Required]
        public Company Company { get; set; }
        public Person? CreatedByPerson { get; set; }
        public Person? UpdatedByPerson { get; set; }

        //to *
        public ICollection<FileAndFolder> FilesAndFolders { get; set; } = new List<FileAndFolder>();

        [InverseProperty("Groups")]
        public ICollection<Person> GroupMembers { get; set; } = new List<Person>();

    }
}

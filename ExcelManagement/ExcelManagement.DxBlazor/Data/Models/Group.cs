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
        public int Id { get; set; }

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
        [Required]
        public Company Company { get; set; }

        //CreatedBy / UpdatedBy
        public Person CreatedBy { get; set; }
        public Person UpdatedBy { get; set; }

        //to *
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
        public virtual ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();
        public virtual ICollection<Person> People { get; set; } = new List<Person>();
    }
}

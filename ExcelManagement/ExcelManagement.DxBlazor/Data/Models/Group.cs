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
        [ForeignKey("Company")]
        public Guid? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("Person")]
        public Guid? CreatedByPersonId { get; set; }
        public Person CreatedByPerson { get; set; }

        [ForeignKey("Person")]
        public Guid? UpdatedByPersonId { get; set; }
        public Person UpdatedByPerson { get; set; }

        //to *
        public ICollection<FileAndFolder> FilesAndFolders { get; set; }
        public ICollection<Person> People { get; set; }

    }
}

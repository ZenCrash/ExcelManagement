using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(2000)]
        public string CompanyName { get; set; }

        [MaxLength(4000)]
        public string? Description { get; set; }

        [Url]
        [MaxLength(4000)]
        public string? CompanyLogoUrl { get; set; }

        //Relationships
        public ICollection<Person> People { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<FileAndFolder> FilesAndFolders { get; set; }

    }
}

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
        public string Description { get; set; }

        [Url]
        [MaxLength(4000)]
        public string CompanyLogoUrl { get; set; }

        //Relationships
        [InverseProperty("Company")]
        public ICollection<Person> People { get; set; } = new List<Person>();
        [InverseProperty("Company")]
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        [InverseProperty("Company")]
        public ICollection<Group> Groups { get; set; } = new List<Group>();
        [InverseProperty("Company")]
        public ICollection<FileAndFolder> FilesAndFolders { get; set; } = new List<FileAndFolder>();

    }
}

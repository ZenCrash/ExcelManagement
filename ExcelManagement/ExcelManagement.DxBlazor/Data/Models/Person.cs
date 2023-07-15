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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        /* Relationships */

        //to 1
        [Required]
        public Company Company { get; set; }

        //CreatedBy / UpdatedBy
        public Person CreatedBy { get; set; }
        public Person UpdatedBy { get; set; }

        //to *
        public virtual ICollection<Role> Roles { get; set; } = new List <Role>();
        public virtual ICollection<Group> Groups { get; set; } = new List <Group>();
        public virtual ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();

        //CreatedBy / UpdatedBy
        public ICollection<Person> CreatedPeople { get; set; } = new List<Person>();
        public ICollection<Person> UpdatedPeople { get; set; } = new List<Person>();

        public ICollection<Company> CreatedCompanys { get; set; } = new List<Company>();
        public ICollection<Company> UpdatedCompanys { get; set; } = new List<Company>();

        public ICollection<Role> CreatedRoles { get; set; } = new List<Role>();
        public ICollection<Role> UpdatedRoles { get; set; } = new List<Role>();

        public ICollection<Group> CreatedGroups { get; set; } = new List<Group>();
        public ICollection<Group> UpdatedGroups { get; set; } = new List<Group>();

        public ICollection<FileAndFolder> CreatedFileAndFolders { get; set; } = new List<FileAndFolder>();
        public ICollection<FileAndFolder> UpdatedFileAndFolders { get; set; } = new List<FileAndFolder>();
    }
}

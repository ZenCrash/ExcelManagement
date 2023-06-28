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
        [ForeignKey("ApplicationUser")]
        public string PersonId { get; set; }

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
        public Guid? MemberCompanyId { get; set; }
        [Required]
        public Company MemberCompany { get; set; }

        //CreatedBy / UpdatedBy
        [ForeignKey("PersonCreatedBy")]
        public string? PersonCreatedById { get; set; }
        public Person PersonCreatedBy { get; set; }

        [ForeignKey("PersonUpdatedBy")]
        public string? PersonUpdatedById { get; set; }
        public Person PersonUpdatedBy { get; set; }

        //to *
        public virtual ICollection<Role> Roles { get; set; } = new List <Role>();
        public virtual ICollection<Group> Groups { get; set; } = new List <Group>();
        [NotMapped]
        public virtual ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();

        //CreatedBy / UpdatedBy
        [InverseProperty("PersonCreatedBy")]
        public ICollection<Person> CreatedPersons { get; set; } = new List<Person>();
        [InverseProperty("PersonUpdatedBy")]
        public ICollection<Person> UpdatedPersons { get; set; } = new List<Person>();

        [InverseProperty("CompanyCreatedBy")]
        public ICollection<Company> CreatedCompanys { get; set; } = new List<Company>();
        [InverseProperty("CompanyUpdatedBy")]
        public ICollection<Company> UpdatedCompanys { get; set; } = new List<Company>();

        [InverseProperty("RoleCreatedBy")]
        public ICollection<Role> CreatedRoles { get; set; } = new List<Role>();
        [InverseProperty("RoleUpdatedBy")]
        public ICollection<Role> UpdatedRoles { get; set; } = new List<Role>();

        [InverseProperty("GroupCreatedBy")]
        public ICollection<Group> CreatedGroups { get; set; } = new List<Group>();
        [InverseProperty("GroupUpdatedBy")]
        public ICollection<Group> UpdatedGroups { get; set; } = new List<Group>();

        [InverseProperty("FileAndFolderCreatedBy")]
        public ICollection<FileAndFolder> CreatedFileAndFolders { get; set; } = new List<FileAndFolder>();
        [InverseProperty("FileAndFolderUpdatedBy")]
        public ICollection<FileAndFolder> UpdatedFileAndFolders { get; set; } = new List<FileAndFolder>();
    }
}

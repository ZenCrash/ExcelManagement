using ExcelManagement.DxBlazor.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class PersonDTO
    {
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

        public Person PersonCreatedBy { get; set; }
        public Person PersonUpdatedBy { get; set; }

        //to *
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>(); //NotMapped

        //CreatedBy / UpdatedBy
        public ICollection<Person> CreatedPersons { get; set; } = new List<Person>();
        public ICollection<Person> UpdatedPersons { get; set; } = new List<Person>();
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

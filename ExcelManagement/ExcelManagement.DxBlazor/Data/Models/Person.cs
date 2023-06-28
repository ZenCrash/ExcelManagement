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
        public Guid ApplicationUserId { get; set; }

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
        public Guid CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company PersonCompany { get; set; }

        //to *
        [InverseProperty("RoleMembers")]
        public ICollection<Role> PersonRoles { get; set; } = new List <Role>();
        [InverseProperty("GroupMembers")]
        public ICollection<Group> PersonGroups { get; set; } = new List <Group>();
        [InverseProperty("FileAndFolderMembers")]
        public virtual ICollection<FileAndFolder> PersonFileAndFolders { get; set; } = new List<FileAndFolder>();

        //CreatedBy / UpdatedBy
        [InverseProperty("CompanyCreatedBy")]
        public virtual ICollection<Company> CreatedCompanys { get; set; } = new List<Company>();
        [InverseProperty("CompanyUpdatedBy")]
        public virtual ICollection<Company> UpdatedCompanys { get; set; } = new List<Company>();

        [InverseProperty("RoleCreatedBy")]
        public virtual ICollection<Role> CreatedRoles { get; set; } = new List<Role>();
        [InverseProperty("RoleUpdatedBy")]
        public virtual ICollection<Role> UpdatedRoles { get; set; } = new List<Role>();

        [InverseProperty("GroupCreatedBy")]
        public virtual ICollection<Group> CreatedGroups { get; set; } = new List<Group>();
        [InverseProperty("GroupUpdatedBy")]
        public virtual ICollection<Group> UpdatedGroups { get; set; } = new List<Group>();

        [InverseProperty("FileAndFolderCreatedBy")]
        public virtual ICollection<FileAndFolder> CreatedFileAndFolders { get; set; } = new List<FileAndFolder>();
        [InverseProperty("FileAndFolderUpdatedBy")]
        public virtual ICollection<FileAndFolder> UpdatedFileAndFolders { get; set; } = new List<FileAndFolder>();

        //Selfrefrence
        //[ForeignKey("UpdatedBy")]
        //public int? UpdatedById { get; set; }
        //public virtual Person UpdatedBy { get; set; }

        //// Collection of Persons that were updated by this Person
        //public virtual ICollection<Person> UpdatedPersons { get; set; }
    }
}

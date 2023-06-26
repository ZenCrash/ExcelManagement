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

        //Relations

        //to 1
        [Required]
        public Company Company { get; set; }

        //to many
        [InverseProperty("RoleMembers")]
        public ICollection<Role> Roles { get; set; }

        public ICollection<Group> Groups { get; set; }

        [InverseProperty("FileAndFolderMembers")]
        public ICollection<FileAndFolder> FileAndFolderMember { get; set; }

        //Inverse propertys

        //Filesandfolders
        [InverseProperty("CreatedByPerson")]
        public ICollection<FileAndFolder> FilesAndFoldersCreated { get; set; } = new List<FileAndFolder>();

        [InverseProperty("UpdatedByPerson")]
        public ICollection<FileAndFolder> FilesAndFoldersUpdated { get; set; } = new List<FileAndFolder>();

        //Roles
        [InverseProperty("CreatedByPerson")]
        public ICollection<Role> RolesCreated { get; set; } = new List<Role>();

        [InverseProperty("UpdatedByPerson")]
        public ICollection<Role> RolesUpdated { get; set; } = new List<Role>();

        //Groups
        [InverseProperty("CreatedByPerson")]
        public ICollection<Group> GroupsCreated { get; set; } = new List<Group>();

        [InverseProperty("UpdatedByPerson")]
        public ICollection<Group> GroupsUpdated { get; set; } = new List<Group>();

    }
}

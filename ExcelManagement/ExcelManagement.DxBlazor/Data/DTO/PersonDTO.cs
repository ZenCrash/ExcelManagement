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
        public CompanyDTO MemberCompanyDTO { get; set; }
        public PersonDTO PersonCreatedByDTO { get; set; }
        public PersonDTO PersonUpdatedByDTO { get; set; }

        //to *
        public ICollection<RoleDTO> RoleDTOs { get; set; } = new List<RoleDTO>();
        public ICollection<GroupDTO> GroupDTOs { get; set; } = new List<GroupDTO>();
        public ICollection<FileAndFolderDTO> FileAndFolderDTOs { get; set; } = new List<FileAndFolderDTO>(); //NotMapped

        //CreatedBy / UpdatedBy
        public ICollection<PersonDTO> CreatedPersonDTOs { get; set; } = new List<PersonDTO>();
        public ICollection<PersonDTO> UpdatedPersonDTOs { get; set; } = new List<PersonDTO>();
        public ICollection<CompanyDTO> CreatedCompanyDTOs { get; set; } = new List<CompanyDTO>();
        public ICollection<CompanyDTO> UpdatedCompanyDTOs { get; set; } = new List<CompanyDTO>();
        public ICollection<RoleDTO> CreatedRoleDTOs { get; set; } = new List<RoleDTO>();
        public ICollection<RoleDTO> UpdatedRoleDTOs { get; set; } = new List<RoleDTO>();
        public ICollection<GroupDTO> CreatedGroupDTOs { get; set; } = new List<GroupDTO>();
        public ICollection<GroupDTO> UpdatedGroupDTOs { get; set; } = new List<GroupDTO>();
        public ICollection<FileAndFolderDTO> CreatedFileAndFolderDTOs { get; set; } = new List<FileAndFolderDTO>();
        public ICollection<FileAndFolderDTO> UpdatedFileAndFolderDTOs { get; set; } = new List<FileAndFolderDTO>();
    }
}
